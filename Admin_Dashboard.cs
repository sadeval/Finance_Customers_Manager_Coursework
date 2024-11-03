using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using FMS_PNP.Models;
using MetroFramework.Components;
using System.Data;
using LiveCharts;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts.Wpf;
using LiveChartsSeries = LiveCharts.SeriesCollection;
using LiveChartsColumnSeries = LiveCharts.Wpf.ColumnSeries;

namespace FMS_PNP
{
    public partial class Admin_Dashboard : MetroForm
    {
        

        public Admin_Dashboard()
        {
            InitializeComponent();
            HideAllPanels();
            InitializeSalaryFields();
            btnLoadChartStat.Click += async (s, e) => await LoadProductSalesChartAsync();
            cmbAdm.SelectedIndexChanged += cmbAdm_SelectedIndexChanged;
            cmbAdm.SelectedIndexChanged += async (s, e) => await UpdateSalaryStatisticsAsync();
            txtOklad.Validating += txtOklad_Validating;
            txtPercent.Validating += txtPercent_Validating;
            txtOklad.KeyPress += txtOklad_KeyPress;
            txtPercent.KeyPress += txtPercent_KeyPress;
            
        }

        private async void Admin_Dashboard_Load(object sender, EventArgs e)
        {
            HideAllPanels();
            await LoadCurrenciesAsync();
            await LoadOfficialRatesAsync();
            await LoadStatisticsComboBoxesAsync();
        }

        private void HideAllPanels()
        {
            // Скрываем все панели
            finance_groupBox.Visible = false;
            currencyConverterPanel.Visible = false;
            customerGroupBox.Visible = false;
            AddProductsGrpBox.Visible = false;
            grpBoxProfile.Visible = false;
        }

        #region Методы для конвертера валют

        private async Task LoadCurrenciesAsync()
        {
            try
            {
                cmbFromCurrency.Items.Add("UAH"); 
                cmbToCurrency.Items.Add("UAH");

                var currencies = await FetchCurrenciesFromNBU();
                foreach (var currency in currencies)
                {
                    cmbFromCurrency.Items.Add(currency);
                    cmbToCurrency.Items.Add(currency);
                }

                cmbFromCurrency.SelectedItem = "UAH";
                cmbToCurrency.SelectedItem = "USD";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке валют: {ex.Message}");
            }
        }

        private async Task<string[]> FetchCurrenciesFromNBU()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JArray data = JArray.Parse(responseBody);
                    return data.Select(item => item["cc"].ToString()).ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении списка валют: {ex.Message}");
                return new string[] { };
            }
        }

        private void btnCurrencyConverter_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            finance_groupBox.Visible = true;
            currencyConverterPanel.Visible = true;
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            await ConvertCurrencyAsync();
        }

        private async Task ConvertCurrencyAsync()
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount) &&
                cmbFromCurrency.SelectedItem != null &&
                cmbToCurrency.SelectedItem != null)
            {
                string fromCurrency = cmbFromCurrency.SelectedItem.ToString();
                string toCurrency = cmbToCurrency.SelectedItem.ToString();

                if (fromCurrency == toCurrency)
                {
                    txtConvertedAmount.Text = amount.ToString("F2");
                }
                else
                {
                    try
                    {
                        decimal conversionRate = await GetConversionRate(fromCurrency, toCurrency);
                        decimal convertedAmount = amount * conversionRate;
                        txtConvertedAmount.Text = convertedAmount.ToString("F2");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при конвертации валюты: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму и выберите валюты.");
            }
        }

        private async Task<decimal> GetConversionRate(string fromCurrency, string toCurrency)
        {
            decimal fromRate = fromCurrency == "UAH" ? 1 : await GetRateFromNBU(fromCurrency);
            decimal toRate = toCurrency == "UAH" ? 1 : await GetRateFromNBU(toCurrency);

            return toRate / fromRate;
        }

        private async Task<decimal> GetRateFromNBU(string currency)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?valcode={currency}&json";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JArray data = JArray.Parse(responseBody);
                    if (data.Count > 0)
                    {
                        return decimal.Parse(data[0]["rate"].ToString());
                    }
                    else
                    {
                        throw new Exception("Не удалось получить курс валюты.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении курса валюты {currency}: {ex.Message}");
                return 0;
            }
        }

        #endregion

        #region Методы для отображения официальных курсов валют

        private async Task<List<CurrencyRate>> FetchOfficialRatesFromNBU()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
                    HttpResponseMessage response = await client.GetAsync(url);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Проверка статуса ответа
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Ошибка при запросе к API НБУ: {response.StatusCode}");
                        return new List<CurrencyRate>();
                    }

                    // Выводим ответ API для диагностики
                    Console.WriteLine("NBU API Response:");
                    Console.WriteLine(responseBody);

                    JArray data = JArray.Parse(responseBody);

                    List<CurrencyRate> rates = new List<CurrencyRate>();

                    foreach (var item in data)
                    {
                        string rateString = item["rate"].ToString();
                        string dateString = item["exchangedate"].ToString();

                        decimal rateValue;
                        DateTime dateValue;

                        if (decimal.TryParse(rateString, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.GetCultureInfo("uk-UA"), out rateValue) &&
                            DateTime.TryParseExact(dateString, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue))
                        {
                            rates.Add(new CurrencyRate
                            {
                                CurrencyCode = item["cc"].ToString(),
                                CurrencyName = item["txt"].ToString(),
                                Rate = rateValue,
                                Date = dateValue
                            });
                        }
                        else
                        {
                            MessageBox.Show($"Не удалось распарсить данные для валюты {item["cc"]}");
                        }
                    }

                    return rates;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении курсов валют: {ex.Message}");
                return new List<CurrencyRate>();
            }
        }

        private async Task LoadOfficialRatesAsync()
        {
            var rates = await FetchOfficialRatesFromNBU();

            if (rates != null && rates.Count > 0)
            {
                dgvOfficialRates.DataSource = rates;
                dgvOfficialRates.Columns["CurrencyCode"].HeaderText = "Код";
                dgvOfficialRates.Columns["CurrencyName"].HeaderText = "Валюта";
                dgvOfficialRates.Columns["Rate"].HeaderText = "Курс";
                dgvOfficialRates.Columns["Date"].HeaderText = "Дата";
            }
        }

        #endregion

        #region Методы для работы с клиентами

        // Переменная для хранения ID редактируемого клиента
        private int? editingCustomerId = null;
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            customerGroupBox.Visible = true;
            LoadCustomersData();
        }
        
        private async void btnAddCustomerConfirm_Click(object sender, EventArgs e)
        {
            // Проверяем, не редактируем ли мы существующего клиента
            if (editingCustomerId != null)
            {
                MessageBox.Show("Вы находитесь в режиме редактирования. Пожалуйста, используйте кнопку 'Сохранить' для сохранения изменений.");
                return;
            }

            string name = txtCustomerName.Text.Trim();
            string mobile = txtCustomerMobile.Text.Trim();
            string email = txtCustomerEmail.Text.Trim();
            string address = txtCustomerAddress.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(mobile) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                await AddCustomerToDatabase(name, mobile, email, address);
                MessageBox.Show("Клиент успешно добавлен.");

                // Очистка полей и обновление таблицы
                ClearCustomerFields();
                LoadCustomersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}");
            }
        }

        private async Task AddCustomerToDatabase(string name, string mobile, string email, string address)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "INSERT INTO Customers (FullName, Mobile, Email, Address) VALUES (@Name, @Mobile, @Email, @Address)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Mobile", mobile);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Address", address);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении клиента в базу данных.", ex);
            }
        }

        private void LoadCustomersData()
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Customers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCustomers.DataSource = dt;

                    if (dgvCustomers.Columns["Id"] != null)
                        dgvCustomers.Columns["Id"].Width = 20;
                    if (dgvCustomers.Columns["FullName"] != null)
                        dgvCustomers.Columns["FullName"].Width = 150;
                    if (dgvCustomers.Columns["Mobile"] != null)
                        dgvCustomers.Columns["Mobile"].Width = 80;
                    if (dgvCustomers.Columns["Email"] != null)
                        dgvCustomers.Columns["Email"].Width = 110;
                    if (dgvCustomers.Columns["Address"] != null)
                        dgvCustomers.Columns["Address"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных клиентов: {ex.Message}");
            }
        }

        private async void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // Получаем ID выбранного клиента
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранного клиента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await DeleteCustomerFromDatabase(customerId);
                    LoadCustomersData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для удаления.");
            }
        }

        private async Task DeleteCustomerFromDatabase(int customerId)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM Customers WHERE Id = @CustomerId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Клиент успешно удален.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении клиента: {ex.Message}");
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // Получаем данные выбранного клиента
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);
                string fullName = dgvCustomers.SelectedRows[0].Cells["FullName"].Value.ToString();
                string mobile = dgvCustomers.SelectedRows[0].Cells["Mobile"].Value.ToString();
                string email = dgvCustomers.SelectedRows[0].Cells["Email"].Value.ToString();
                string address = dgvCustomers.SelectedRows[0].Cells["Address"].Value.ToString();

                // Заполняем поля ввода данными клиента
                txtCustomerName.Text = fullName;
                txtCustomerMobile.Text = mobile;
                txtCustomerEmail.Text = email;
                txtCustomerAddress.Text = address;

                // Устанавливаем цвет текста в черный
                txtCustomerName.ForeColor = System.Drawing.Color.Black;
                txtCustomerMobile.ForeColor = System.Drawing.Color.Black;
                txtCustomerEmail.ForeColor = System.Drawing.Color.Black;
                txtCustomerAddress.ForeColor = System.Drawing.Color.Black;

                // Устанавливаем ID редактируемого клиента
                editingCustomerId = customerId;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для редактирования.");
            }
        }

        private async void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            // Проверяем, редактируем ли мы существующего клиента
            if (editingCustomerId != null)
            {
                // Собираем данные из полей ввода
                string fullName = txtCustomerName.Text.Trim();
                string mobile = txtCustomerMobile.Text.Trim();
                string email = txtCustomerEmail.Text.Trim();
                string address = txtCustomerAddress.Text.Trim();

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(mobile) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }

                try
                {
                    int customerId = editingCustomerId.Value;
                    await UpdateCustomerInDatabase(customerId, fullName, mobile, email, address);
                    MessageBox.Show("Данные клиента успешно обновлены.");

                    // Очистка полей и обновление таблицы
                    ClearCustomerFields();
                    LoadCustomersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных клиента: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Нет выбранного клиента для сохранения.");
            }
        }

        private async Task UpdateCustomerInDatabase(int customerId, string fullName, string mobile, string email, string address)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE Customers SET FullName = @FullName, Mobile = @Mobile, Email = @Email, Address = @Address WHERE ID = @CustomerId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Mobile", mobile);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении данных клиента в базе данных.", ex);
            }
        }

        private void ClearCustomerFields()
        {
            txtCustomerName.Clear();
            txtCustomerMobile.Clear();
            txtCustomerEmail.Clear();
            txtCustomerAddress.Clear();

            txtCustomerName.ForeColor = System.Drawing.Color.Gray;
            txtCustomerMobile.ForeColor = System.Drawing.Color.Gray;
            txtCustomerEmail.ForeColor = System.Drawing.Color.Gray;
            txtCustomerAddress.ForeColor = System.Drawing.Color.Gray;

            txtCustomerName.Text = "Полное имя";
            txtCustomerMobile.Text = "Номер телефона";
            txtCustomerEmail.Text = "Email";
            txtCustomerAddress.Text = "Адрес";

            editingCustomerId = null; // Сбрасываем сохраненный ID клиента
        }

        private async Task<bool> CustomerExists(int idCustomer)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT COUNT(*) FROM Customers WHERE Id = @ID_Customer";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Customer", idCustomer);

                        int count = (int)await cmd.ExecuteScalarAsync();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке существования клиента: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Методы для транзакций

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            Transactions transactionsForm = new Transactions();
            transactionsForm.ShowDialog(); // Открывает форму как модальное диалоговое окно
        }

        private void btnDisplayPurchasingGraph_Click(object sender, EventArgs e)
        {
            var purchasingGraphForm = new PurchasingGraphForm();
            purchasingGraphForm.Show();
        }

        #endregion

        #region Методы для генерации отчетов

        private void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            CreateRecipe createRecipeForm = new CreateRecipe();
            createRecipeForm.ShowDialog();
        }

        #endregion

        #region Методы для профиля клиента

        private async void btnProfileClient_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            grpBoxProfile.Visible = true;
            await LoadProfileCustomersAsync();
        }

        private async Task LoadProfileCustomersAsync()
        {
            try
            {
                cmbProfileCustomer.Items.Clear();
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT Id, FullName FROM Customers ORDER BY FullName";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                cmbProfileCustomer.Items.Add(new Customer
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    FullName = reader["FullName"].ToString()
                                });
                            }
                        }
                    }
                }

                if (cmbProfileCustomer.Items.Count > 0)
                {
                    cmbProfileCustomer.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Нет доступных клиентов для отображения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearProfileFields();
                    dgvCustomerTransactions.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке клиентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbProfileCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProfileCustomer.SelectedItem is Customer selectedCustomer)
            {
                await LoadCustomerDetailsAsync(selectedCustomer.Id);
                await LoadCustomerTransactionsAsync(selectedCustomer.Id);
            }
        }

        private async Task LoadCustomerDetailsAsync(int customerId)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT Mobile, Email, Address FROM Customers WHERE Id = @CustomerId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                lblPhoneNumber.Text = $"Номер телефона: {reader["Mobile"]}";
                                lblEmail.Text = $"Email: {reader["Email"]}";
                                lblAddress.Text = $"Адрес: {reader["Address"]}";
                            }
                            else
                            {
                                lblPhoneNumber.Text = "Номер телефона: Не найдено";
                                lblEmail.Text = "Email: Не найдено";
                                lblAddress.Text = "Адрес: Не найдено";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCustomerTransactionsAsync(int customerId)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                    SELECT 
                        t.Date AS Date,
                        p.Category,
                        p.Name_of_Product AS Product,
                        t.Quantity, 
                        p.Price,
                        a.FullName AS FullNameAdm,
                        t.Return_of_goods AS Return_of_goods,
                        t.Summ AS Summ
                    FROM 
                        Transactions t
                    INNER JOIN 
                        Products p ON t.ProductId = p.ID
                    INNER JOIN 
                        Administrator a ON t.AdministratorId = a.Id
                    WHERE 
                        t.CustomerId = @CustomerId
                    ORDER BY 
                        t.Date DESC";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable transactionsTable = new DataTable();
                            adapter.Fill(transactionsTable);
                            dgvCustomerTransactions.DataSource = transactionsTable;

                            if (transactionsTable.Rows.Count == 0)
                            {
                                MessageBox.Show("У выбранного клиента нет транзакций.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            // Настройка заголовков столбцов и форматирование
                            SetupDataGridView();

                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL ошибка при загрузке транзакций клиента: {sqlEx.Message}", "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке транзакций клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            var dgv = dgvCustomerTransactions; 


            if (dgv.Columns.Contains("Date"))
                dgv.Columns["Date"].HeaderText = "Дата";

            if (dgv.Columns.Contains("Category"))
                dgv.Columns["Category"].HeaderText = "Категория";

            if (dgv.Columns.Contains("Product"))
                dgv.Columns["Product"].HeaderText = "Товар";

            if (dgv.Columns.Contains("Quantity"))
                dgv.Columns["Quantity"].HeaderText = "Количество";

            if (dgv.Columns.Contains("Price"))
                dgv.Columns["Price"].HeaderText = "Цена";

            if (dgv.Columns.Contains("FullNameAdm"))
                dgv.Columns["FullNameAdm"].HeaderText = "Администратор";

            if (dgv.Columns.Contains("Return_of_goods"))
                dgv.Columns["Return_of_goods"].HeaderText = "Возврат";

            if (dgv.Columns.Contains("Summ"))
                dgv.Columns["Summ"].HeaderText = "Сумма";

            if (dgv.Columns.Contains("Date"))
                dgv.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yyyy";

            if (dgvCustomerTransactions.Columns.Contains("Summ"))
            {
                dgvCustomerTransactions.Columns["Summ"].DefaultCellStyle.Format = "C2"; 
                dgvCustomerTransactions.Columns["Summ"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("uk-UA"); 
            }
        }

        private void ClearProfileFields()
        {
            lblPhoneNumber.Text = "Номер телефона: ";
            lblEmail.Text = "Email: ";
            lblAddress.Text = "Адрес: ";
            dgvCustomerTransactions.DataSource = null;
        }

        private async void btnLoadChart_Click(object sender, EventArgs e)
        {
            if (cmbProfileCustomer.SelectedItem is Customer selectedCustomer)
            {
                DateTime startDate = dateTimeStart.Value.Date;
                DateTime endDate = dateTimeEnd.Value.Date;

                if (startDate > endDate)
                {
                    MessageBox.Show("Начальная дата не может быть позже конечной даты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await LoadCustomerChartAsync(selectedCustomer.Id, startDate, endDate);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task LoadCustomerChartAsync(int customerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                    SELECT 
                        p.Name_of_Product AS ProductName, 
                        SUM(t.Quantity) AS TotalQuantity, 
                        SUM(t.Summ) AS TotalSum
                    FROM 
                        Transactions t
                    INNER JOIN 
                        Products p ON t.ProductId = p.ID
                    WHERE 
                        t.CustomerId = @CustomerId AND 
                        t.Date BETWEEN @StartDate AND @EndDate
                    GROUP BY 
                        p.Name_of_Product";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            var productNames = new List<string>();
                            var quantities = new List<double>();
                            var sums = new List<double>();

                            while (await reader.ReadAsync())
                            {
                                productNames.Add(reader["ProductName"].ToString());

                                if (double.TryParse(reader["TotalQuantity"].ToString(), out double qty))
                                    quantities.Add(qty);
                                else
                                    quantities.Add(0);

                                if (double.TryParse(reader["TotalSum"].ToString(), out double sum))
                                    sums.Add(sum);
                                else
                                    sums.Add(0);
                            }

                            // Настройка графика
                            SetupCustomerChart(productNames, quantities, sums);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных для графика: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetupCustomerChart(List<string> productNames, List<double> quantities, List<double> sums)
        {
            if (productNames.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения графика.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();
                return;
            }
            // Очищаем предыдущие серии
            cartesianChart2.Series.Clear();

            // Добавляем серию для количества
            cartesianChart2.Series.Add(new LineSeries
            {
                Title = "Количество",
                Values = new ChartValues<double>(quantities)
            });

            // Добавляем серию для суммы
            cartesianChart2.Series.Add(new LineSeries
            {
                Title = "Сумма",
                Values = new ChartValues<double>(sums)
            });

            // Настройка оси X
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Товар",
                Labels = productNames,
                LabelsRotation = 15
            });

            // Настройка оси Y
            cartesianChart2.AxisY.Clear();
            cartesianChart2.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Значение",
                LabelFormatter = value => value.ToString("N")
            });

            // Настройка легенды
            cartesianChart2.LegendLocation = LegendLocation.Top;
        }

        #endregion

        #region Методы для добавления товара

        private void Add_Prod_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            AddProductsGrpBox.Visible = true;
            LoadProductsData();
        }

        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Собираем данные из полей ввода
            string category = txtCategory.Text.Trim();
            string productName = txtProductName.Text.Trim();
            string textile = txtTextile.Text.Trim();
            string season = txtSeason.Text.Trim();
            string color = txtColor.Text.Trim();
            string size = txtSize.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            // Проверяем введенные данные
            if (string.IsNullOrEmpty(category) ||
                string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(textile) ||
                string.IsNullOrEmpty(season) || string.IsNullOrEmpty(color) ||
                string.IsNullOrEmpty(size) || string.IsNullOrEmpty(quantityText) ||
                string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (!int.TryParse(quantityText, out int quantity))
            {
                MessageBox.Show("Количество должно быть числом.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Цена должна быть числом.");
                return;
            }

            try
            {
                // Добавляем новый продукт
                await AddProductToDatabase(category, productName, textile, season, color, size, quantity, price);
                MessageBox.Show("Товар успешно добавлен.");

                // Очистка полей и обновление таблицы
                ClearProductFields();
                LoadProductsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
            }
        }

        private async Task UpdateProductInDatabase(int productId, string category, string productName, string textile, string season, string color, string size, int quantity, decimal price)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE Products SET Category = @Category, Name_of_Product = @Name_of_Product, Textile = @Textile, Season = @Season, Color = @Color, Size = @Size, Quantity = @Quantity, Price = @Price WHERE ID = @ProductId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Name_of_Product", productName);
                        cmd.Parameters.AddWithValue("@Textile", textile);
                        cmd.Parameters.AddWithValue("@Season", season);
                        cmd.Parameters.AddWithValue("@Color", color);
                        cmd.Parameters.AddWithValue("@Size", size);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@ProductId", productId);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении товара в базе данных.", ex);
            }
        }

        private void ClearProductFields()
        {
            txtCategory.Clear();
            txtProductName.Clear();
            txtTextile.Clear();
            txtSeason.Clear();
            txtColor.Clear();
            txtSize.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();

            txtCategory.Tag = null; // Сбрасываем сохраненный ID продукта
        }

        private async Task AddProductToDatabase(string category, string productName, string textile, string season, string color, string size, int quantity, decimal price)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "INSERT INTO Products (Category, Name_of_Product, Textile, Season, Color, Size, Quantity, Price) " +
                                   "VALUES (@Category, @Name_of_Product, @Textile, @Season, @Color, @Size, @Quantity, @Price)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Name_of_Product", productName);
                        cmd.Parameters.AddWithValue("@Textile", textile);
                        cmd.Parameters.AddWithValue("@Season", season);
                        cmd.Parameters.AddWithValue("@Color", color);
                        cmd.Parameters.AddWithValue("@Size", size);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Price", price);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении товара в базу данных.", ex);
            }
        }

        private async void LoadProductsData(string category = null)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM Products";
                    if (!string.IsNullOrEmpty(category))
                    {
                        query += " WHERE Category = @Category";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    if (!string.IsNullOrEmpty(category))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@Category", category);
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProducts.DataSource = dt;

                    // Установка ширины колонок
                    if (dgvProducts.Columns["ID"] != null)
                        dgvProducts.Columns["ID"].Width = 30;
                    if (dgvProducts.Columns["Category"] != null)
                        dgvProducts.Columns["Category"].Width = 70;
                    if (dgvProducts.Columns["Name_of_Product"] != null)
                        dgvProducts.Columns["Name_of_Product"].Width = 120;
                    if (dgvProducts.Columns["Textile"] != null)
                        dgvProducts.Columns["Textile"].Width = 70;
                    if (dgvProducts.Columns["Season"] != null)
                        dgvProducts.Columns["Season"].Width = 60;
                    if (dgvProducts.Columns["Color"] != null)
                        dgvProducts.Columns["Color"].Width = 70;
                    if (dgvProducts.Columns["Size"] != null)
                        dgvProducts.Columns["Size"].Width = 50;
                    if (dgvProducts.Columns["Quantity"] != null)
                        dgvProducts.Columns["Quantity"].Width = 30;
                    if (dgvProducts.Columns["Price"] != null)
                        dgvProducts.Columns["Price"].Width = 70;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных продуктов: {ex.Message}");
            }
        }

        private async void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Получаем ID выбранного продукта
                int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ID"].Value);

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный товар?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await DeleteProductFromDatabase(productId);
                    LoadProductsData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.");
            }
        }

        private async Task DeleteProductFromDatabase(int productId)
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM Products WHERE ID = @ProductId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Товар успешно удален.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении товара: {ex.Message}");
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Получаем данные выбранного продукта
                int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ID"].Value);
                string category = dgvProducts.SelectedRows[0].Cells["Category"].Value.ToString();
                string productName = dgvProducts.SelectedRows[0].Cells["Name_of_Product"].Value.ToString();
                string textile = dgvProducts.SelectedRows[0].Cells["Textile"].Value.ToString();
                string season = dgvProducts.SelectedRows[0].Cells["Season"].Value.ToString();
                string color = dgvProducts.SelectedRows[0].Cells["Color"].Value.ToString();
                string size = dgvProducts.SelectedRows[0].Cells["Size"].Value.ToString();
                int quantity = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(dgvProducts.SelectedRows[0].Cells["Price"].Value);

                // Заполняем поля ввода данными продукта
                txtCategory.Text = category;
                txtProductName.Text = productName;
                txtTextile.Text = textile;
                txtSeason.Text = season;
                txtColor.Text = color;
                txtSize.Text = size;
                txtQuantity.Text = quantity.ToString();
                txtPrice.Text = price.ToString();

                // Сохраняем ID редактируемого продукта
                txtCategory.Tag = productId;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для редактирования.");
            }
        }

        private async void btnSaveProduct_Click(object sender, EventArgs e)
        {
            // Проверяем, редактируем ли мы существующий продукт
            if (txtCategory.Tag != null)
            {
                // Собираем данные из полей ввода
                string category = txtCategory.Text.Trim();
                string productName = txtProductName.Text.Trim();
                string textile = txtTextile.Text.Trim();
                string season = txtSeason.Text.Trim();
                string color = txtColor.Text.Trim();
                string size = txtSize.Text.Trim();
                string quantityText = txtQuantity.Text.Trim();
                string priceText = txtPrice.Text.Trim();

                // Проверяем введенные данные
                if (string.IsNullOrEmpty(category) ||
                    string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(textile) ||
                    string.IsNullOrEmpty(season) || string.IsNullOrEmpty(color) ||
                    string.IsNullOrEmpty(size) || string.IsNullOrEmpty(quantityText) ||
                    string.IsNullOrEmpty(priceText))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }

                if (!int.TryParse(quantityText, out int quantity))
                {
                    MessageBox.Show("Количество должно быть числом.");
                    return;
                }

                if (!decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Цена должна быть числом.");
                    return;
                }

                try
                {
                    // Редактируем существующий продукт
                    int productId = (int)txtCategory.Tag;
                    await UpdateProductInDatabase(productId, category, productName, textile, season, color, size, quantity, price);
                    MessageBox.Show("Товар успешно обновлен.");

                    // Очистка полей и обновление таблицы
                    ClearProductFields();
                    LoadProductsData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении товара: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Нет выбранного товара для сохранения.");
            }
        }

        private async void btnSearchProd_Click(object sender, EventArgs e)
        {
            string selectedCategory = txtCategory.Text;

            if (string.IsNullOrEmpty(selectedCategory))
            {
                MessageBox.Show("Пожалуйста, введите категорию для поиска.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var products = await SearchProductsByCategoryAsync(selectedCategory);

                if (products.Rows.Count > 0)
                {
                    // Отображаем результаты в DataGridView
                    dgvProducts.DataSource = products;
                }
                else
                {
                    MessageBox.Show("Продукты по выбранной категории не найдены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProducts.DataSource = null; // Очищаем DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске продуктов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<DataTable> SearchProductsByCategoryAsync(string category)
        {
            DataTable dt = new DataTable();

            using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                await connection.OpenAsync();

                string query = @"
                SELECT 
                    ID, 
                    Category, 
                    Name_of_Product, 
                    Textile, 
                    Season, 
                    Color, 
                    Size, 
                    Quantity, 
                    Price 
                FROM 
                    Products 
                WHERE 
                    Category LIKE '%' + @Category + '%'";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Category", category);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
        #endregion

        #region Методы для статистики

        private void InitializeSalaryFields()
        {
            txtOklad.Tag = "0";
            txtPercent.Tag = "0";
        }

        private async Task LoadStatisticsComboBoxesAsync()
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    // Загрузка категорий
                    var categoryCommand = new SqlCommand("SELECT DISTINCT Category FROM Products", connection);
                    using (var reader = await categoryCommand.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cmbCategory1.Items.Add(reader["Category"].ToString());
                        }
                    }

                    // Загрузка наименований товаров
                    var productCommand = new SqlCommand("SELECT Name_of_Product FROM Products", connection);
                    using (var reader = await productCommand.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cmbNameProd1.Items.Add(reader["Name_of_Product"].ToString());
                        }
                    }
                }

                // Установка выбранного значения по умолчанию
                if (cmbCategory1.Items.Count > 0)
                    cmbCategory1.SelectedIndex = 0;

                if (cmbNameProd1.Items.Count > 0)
                    cmbNameProd1.SelectedIndex = 0;

                // Загрузка администраторов
                await LoadAdministratorsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных для статистики: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Подсчёт общего количества и суммы
            await CalculateTotalQuantityAsync();
            await CalculateTotalSummAsync();

            // Загрузка статистики топ клиента и администратора
            await LoadTopClientStatisticsAsync();
            await LoadTopAdminStatisticsAsync();
        }

        private async Task CalculateTotalQuantityAsync()
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT SUM(Quantity) AS Quantity FROM Products";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        var result = await cmd.ExecuteScalarAsync();
                        decimal totalQuantity = result != DBNull.Value && result != null ? Convert.ToDecimal(result) : 0;
                        lblRemain.Text = $"Остаток: {totalQuantity}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подсчёте общего количества: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CalculateTotalSummAsync()
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT SUM(Summ) AS TotalSumm FROM Transactions";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        var result = await cmd.ExecuteScalarAsync();
                        decimal totalSumm = result != DBNull.Value && result != null ? Convert.ToDecimal(result) : 0;
                        lblBillGrn.Text = $"На счету: {totalSumm.ToString("C", CultureInfo.GetCultureInfo("uk-UA"))}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подсчёте общей суммы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateStatisticsAsync();
        }

        private async void cmbNameProd1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateStatisticsAsync();
        }

        private async Task UpdateStatisticsAsync()
        {
            string selectedCategory = cmbCategory1.SelectedItem?.ToString();
            string selectedProduct = cmbNameProd1.SelectedItem?.ToString();

            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    // Подсчёт количества по фильтрам
                    string quantityQuery = "SELECT SUM(Quantity) FROM Products WHERE 1=1";
                    if (!string.IsNullOrEmpty(selectedCategory))
                        quantityQuery += " AND Category = @Category";
                    if (!string.IsNullOrEmpty(selectedProduct))
                        quantityQuery += " AND Name_of_Product = @ProductName";

                    using (SqlCommand cmd = new SqlCommand(quantityQuery, connection))
                    {
                        if (!string.IsNullOrEmpty(selectedCategory))
                            cmd.Parameters.AddWithValue("@Category", selectedCategory);
                        if (!string.IsNullOrEmpty(selectedProduct))
                            cmd.Parameters.AddWithValue("@ProductName", selectedProduct);

                        var result = await cmd.ExecuteScalarAsync();
                        decimal totalQuantity = result != DBNull.Value && result != null ? Convert.ToDecimal(result) : 0;
                        lblRemain.Text = $"Остаток: {totalQuantity}";
                    }

                    // Подсчёт общей суммы
                    string totalSummQuery = "SELECT SUM(Summ) FROM Transactions";
                    using (SqlCommand cmd = new SqlCommand(totalSummQuery, connection))
                    {
                        var result = await cmd.ExecuteScalarAsync();
                        decimal totalSumm = result != DBNull.Value && result != null ? Convert.ToDecimal(result) : 0;
                        lblBillGrn.Text = $"На счету: {totalSumm.ToString("C", CultureInfo.GetCultureInfo("uk-UA"))}";
                    }
                }

                // Обновление статистики топ клиента
                await LoadTopClientStatisticsAsync();

                // Обновление статистики топ администратора
                await LoadTopAdminStatisticsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении статистики: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTopClientStatisticsAsync()
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    // Поиск клиента с максимальным общим количеством товаров
                    string query = @"
                        SELECT TOP 1 t.Full_Name, SUM(t.Quantity) AS TotalQuantity
                        FROM Transactions t
                        GROUP BY t.Full_Name
                        ORDER BY SUM(t.Quantity) DESC";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string topClient = reader["Full_Name"].ToString();
                                decimal totalQuantity = reader["TotalQuantity"] != DBNull.Value ? Convert.ToDecimal(reader["TotalQuantity"]) : 0;

                                lblClient.Text = $"{topClient}";
                                lblCustQuan.Text = $"Куплено шт: {totalQuantity}";
                            }
                            else
                            {
                                lblClient.Text = "ФИО: Не найдено";
                                lblCustQuan.Text = "Куплено шт: 0";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке статистики клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTopAdminStatisticsAsync()
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    // Поиск администратора с максимальным общим количеством товаров
                    string query = @"
                        SELECT TOP 1 t.FullNameAdm, SUM(t.Quantity) AS TotalQuantity
                        FROM Transactions t
                        GROUP BY t.FullNameAdm
                        ORDER BY SUM(t.Quantity) DESC";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string topAdmin = reader["FullNameAdm"].ToString();
                                decimal totalQuantity = reader["TotalQuantity"] != DBNull.Value ? Convert.ToDecimal(reader["TotalQuantity"]) : 0;

                                lblAdm.Text = $"{topAdmin}";
                                lblAdmQuan.Text = $"Продано шт: {totalQuantity}";
                            }
                            else
                            {
                                lblAdm.Text = "Администратор: Не найдено";
                                lblAdmQuan.Text = "Продано шт: 0";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке статистики администратора: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadAdministratorsAsync()
        {
            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT FullName FROM Administrator ORDER BY FullName";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                cmbAdm.Items.Add(reader["FullName"].ToString());
                            }
                        }
                    }
                }

                if (cmbAdm.Items.Count > 0)
                    cmbAdm.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке администраторов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbAdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateSalaryStatisticsAsync();
        }

        private async void txtOklad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await UpdateSalaryStatisticsAsync();
        }

        private async void txtPercent_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await UpdateSalaryStatisticsAsync();
        }

        private void txtOklad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Позволяет вводить цифры, запятую и управляющие символы
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Разрешает только одну запятую
            if (e.KeyChar == ',' && ((TextBox)sender).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Позволяет вводить цифры, запятую и управляющие символы
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Разрешает только одну запятую
            if (e.KeyChar == ',' && ((TextBox)sender).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private async Task UpdateSalaryStatisticsAsync()
        {
            string selectedAdmin = cmbAdm.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedAdmin))
            {
                lblAdmSalary.Text = "Зарплата: ";
                lblSold.Text = "Продано: ";
                return;
            }

            // Парсинг оклада
            decimal oklad = 0;
            if (!string.IsNullOrWhiteSpace(txtOklad.Text))
            {
                if (!decimal.TryParse(txtOklad.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("uk-UA"), out oklad))
                {
                    lblAdmSalary.Text = "Зарплата: Некорректный ввод";
                    lblSold.Text = "Продано: ";
                    return;
                }
            }

            // Парсинг процента
            decimal percent = 0;
            if (!string.IsNullOrWhiteSpace(txtPercent.Text))
            {
                if (!decimal.TryParse(txtPercent.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("uk-UA"), out percent))
                {
                    lblAdmSalary.Text = "Зарплата: Некорректный ввод";
                    lblSold.Text = "Продано: ";
                    return;
                }
            }

            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    // Получение общей суммы продаж для администратора
                    string sumQuery = @"
                        SELECT SUM(t.Summ) 
                        FROM Transactions t 
                        INNER JOIN Administrator a ON t.AdministratorId = a.Id 
                        WHERE a.FullName = @FullName";
                    decimal totalSales = 0;

                    using (SqlCommand sumCmd = new SqlCommand(sumQuery, connection))
                    {
                        sumCmd.Parameters.AddWithValue("@FullName", selectedAdmin);
                        var sumResult = await sumCmd.ExecuteScalarAsync();
                        totalSales = sumResult != DBNull.Value && sumResult != null ? Convert.ToDecimal(sumResult) : 0;
                    }

                    // Получение общего количества проданных товаров для администратора
                    string quantityQuery = @"
                        SELECT SUM(t.Quantity) 
                        FROM Transactions t 
                        INNER JOIN Administrator a ON t.AdministratorId = a.Id 
                        WHERE a.FullName = @FullName";
                    int totalQuantity = 0;

                    using (SqlCommand qtyCmd = new SqlCommand(quantityQuery, connection))
                    {
                        qtyCmd.Parameters.AddWithValue("@FullName", selectedAdmin);
                        var qtyResult = await qtyCmd.ExecuteScalarAsync();
                        totalQuantity = qtyResult != DBNull.Value && qtyResult != null ? Convert.ToInt32(qtyResult) : 0;
                    }

                    // Расчёт зарплаты: оклад + процент от продаж
                    decimal salary = oklad + (percent / 100) * totalSales;

                    // Обновление меток
                    lblAdmSalary.Text = $"ЗП: {salary.ToString("C", CultureInfo.GetCultureInfo("uk-UA"))}";
                    lblSold.Text = $"Продано: {totalQuantity}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчёте зарплаты: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductSalesChartAsync()
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Начальная дата не может быть позже конечной даты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                    WITH DateRange AS (
                        SELECT @StartDate AS DateValue
                        UNION ALL
                        SELECT DATEADD(DAY, 1, DateValue)
                        FROM DateRange
                        WHERE DATEADD(DAY, 1, DateValue) <= @EndDate
                    )
                    SELECT dr.DateValue, ISNULL(t.TotalQuantity, 0) AS TotalQuantity
                    FROM DateRange dr
                    LEFT JOIN (
                        SELECT CAST(t.Date AS DATE) AS TransactionDate, SUM(t.Quantity) AS TotalQuantity
                        FROM Transactions t
                        WHERE t.Date BETWEEN @StartDate AND @EndDate
                        GROUP BY CAST(t.Date AS DATE)
                    ) t ON dr.DateValue = t.TransactionDate
                    ORDER BY dr.DateValue
                    OPTION (MAXRECURSION 0)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            var dates = new List<string>();
                            var quantities = new LiveCharts.ChartValues<int>();

                            while (await reader.ReadAsync())
                            {
                                DateTime date = reader.GetDateTime(reader.GetOrdinal("DateValue"));
                                int totalQuantity = reader.GetInt32(reader.GetOrdinal("TotalQuantity"));

                                dates.Add(date.ToString("dd.MM"));
                                quantities.Add(totalQuantity);
                            }

                            // Настройка графика
                            cartesianChartProd.Series.Add(new LineSeries
                            {

                                Title = "Количество",
                                Values = new ChartValues<int>(quantities)

                            });

                            cartesianChartProd.AxisX.Clear();
                            cartesianChartProd.AxisX.Add(new LiveCharts.Wpf.Axis
                            {
                                //Title = "Дата",
                                Labels = dates,
                                LabelsRotation = 15
                            });

                            cartesianChartProd.AxisY.Clear();
                            cartesianChartProd.AxisY.Add(new LiveCharts.Wpf.Axis
                            {
                                Title = "Количество",
                                LabelFormatter = value => value.ToString()
                            });

                            cartesianChartProd.LegendLocation = LiveCharts.LegendLocation.Top;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных для графика: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void statastic_controler_CheckedChanged(object sender, EventArgs e)
        {
            statics.Visible = statistic_controler.Checked;
        }

        #endregion

    }

    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }

    public class CurrencyRate
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
    }

    public class TransactionDetail
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
