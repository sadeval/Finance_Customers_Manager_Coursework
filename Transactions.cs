using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Configuration;
using System.Globalization;

namespace FMS_PNP
{
    public partial class Transactions : MetroForm
    {
        private int? editingTransactionId = null;
        
        public Transactions()
        {
            InitializeComponent();
            this.Load += Transactions_Load; 

            // Подписка на событие CellValueChanged
            dgvTransactions.CellValueChanged += dgvTransactions_CellValueChanged;
        }

        private async void Transactions_Load(object sender, EventArgs e)
        {
            await LoadComboBoxDataAsync();
            LoadTransactionsData(); // Загрузка транзакций при загрузке формы
        }

        private async Task LoadComboBoxDataAsync()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                await connection.OpenAsync();

                // Загрузка клиентов
                var customerCommand = new SqlCommand("SELECT FullName FROM Customers", connection);
                using (var reader = await customerCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cmbFullNameClient.Items.Add(reader["FullName"].ToString());
                    }
                }

                // Загрузка администраторов
                var adminCommand = new SqlCommand("SELECT FullName FROM Administrator", connection);
                using (var reader = await adminCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cmbFullNameAdm.Items.Add(reader["FullName"].ToString());
                    }
                }

                // Загрузка категорий
                var categoryCommand = new SqlCommand("SELECT DISTINCT Category FROM Products", connection);
                using (var reader = await categoryCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cmbCategory.Items.Add(reader["Category"].ToString());
                    }
                }

                // Загрузка наименований товаров
                var productCommand = new SqlCommand("SELECT Name_of_Product FROM Products", connection);
                using (var reader = await productCommand.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cmbProductName.Items.Add(reader["Name_of_Product"].ToString());
                    }
                }
            }
        }

        private async void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productName = cmbProductName.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(productName))
            {
                try
                {
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                    {
                        await connection.OpenAsync();
                        var priceCommand = new SqlCommand("SELECT Price FROM Products WHERE Name_of_Product = @ProductName", connection);
                        priceCommand.Parameters.AddWithValue("@ProductName", productName);

                        var result = await priceCommand.ExecuteScalarAsync();
                        if (result != null)
                        {
                            txtPrice.Text = result.ToString(); // Устанавливаем цену
                        }
                        else
                        {
                            MessageBox.Show("Не удалось загрузить цену для выбранного товара.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке цены: {ex.Message}");
                }
            }
        }

        // Метод для пересчета итоговой суммы после изменения количества или цены
        private async void dgvTransactions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnName = dgvTransactions.Columns[e.ColumnIndex].Name;

                if (columnName == "Quantity" || columnName == "Price" || columnName == "Return_of_goods")
                {
                    DataGridViewRow row = dgvTransactions.Rows[e.RowIndex];

                    // Проверяем наличие необходимых ячеек
                    if (row.Cells["Quantity"].Value != null && row.Cells["Price"].Value != null && row.Cells["Return_of_goods"].Value != null)
                    {
                        bool isQuantityValid = int.TryParse(row.Cells["Quantity"].Value.ToString(), out int quantity);
                        bool isPriceValid = decimal.TryParse(row.Cells["Price"].Value.ToString(), out decimal price);
                        bool isReturnValid = bool.TryParse(row.Cells["Return_of_goods"].Value.ToString(), out bool isReturn);

                        if (isQuantityValid && isPriceValid && isReturnValid)
                        {
                            // Получаем Transaction объект из DataBoundItem
                            if (row.DataBoundItem is Transaction transaction)
                            {
                                // Получаем старую транзакцию
                                Transaction oldTransaction = await GetTransactionByIdAsync(transaction.TransactionID);
                                if (oldTransaction == null)
                                {
                                    MessageBox.Show("Старая транзакция не найдена.");
                                    return;
                                }
 
                                // Рассчитываем разницу в количестве и корректируем
                                int quantityDifference = quantity - oldTransaction.Quantity;
                                bool isReturnDifference = isReturnValid;

                                bool adjustSuccess = false;
                                if (isReturnDifference)
                                {
                                    // Если это возврат, увеличиваем количество
                                    adjustSuccess = await AdjustProductQuantityAsync(transaction.ProductId, quantityDifference, true);
                                }
                                else
                                {
                                    // Если это продажа, уменьшаем количество
                                    adjustSuccess = await AdjustProductQuantityAsync(transaction.ProductId, quantityDifference, false);
                                }

                                if (!adjustSuccess)
                                {
                                    // Если корректировка количества не удалась, отменяем изменения
                                    LoadTransactionsData();
                                    return;
                                }

                                // Обновляем транзакцию в базе данных без установки Summ
                                await UpdateTransactionInDatabase(transaction);

                                // Перезагружаем данные и пересчитываем итог
                                LoadTransactionsData();
                                CalculateGrandTotal();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, введите корректное количество, цену и статус возврата.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: количество, цена или статус возврата не указаны.");
                    }
                }
            }
        }
        
        private void CalculateGrandTotal()
        {
            decimal grandTotal = 0;

            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                if (row.Cells["Summ"].Value != null)
                {
                    if (decimal.TryParse(row.Cells["Summ"].Value.ToString(), out decimal sum))
                    {
                        grandTotal += sum;
                    }
                }
            }

            lblGrandTotal.Text = $"Итоговая сумма: {grandTotal.ToString("C", new CultureInfo("uk-UA"))}";
        }

        private async void btnAddTransaction_Click(object sender, EventArgs e)
        {
            // Проверка обязательных полей
            if (cmbFullNameClient.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента.");
                return;
            }

            if (cmbProductName.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар.");
                return;
            }

            if (cmbFullNameAdm.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите администратора.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Цена для выбранного товара не загружена или некорректна. Попробуйте выбрать товар заново.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Пожалуйста, введите корректное количество.");
                return;
            }

            string fullNameClient = cmbFullNameClient.SelectedItem.ToString();
            string fullNameAdm = cmbFullNameAdm.SelectedItem.ToString();
            string category = cmbCategory.SelectedItem?.ToString() ?? "";
            string productName = cmbProductName.SelectedItem.ToString();
            DateTime date = dateTimePickerTransactionDate.Value;
            bool isReturn = chkReturnOfGoods.Checked;

            // Получение идентификаторов
            int? customerId = await GetCustomerIdByNameAsync(fullNameClient);
            if (customerId == null)
            {
                MessageBox.Show("Не удалось найти ID клиента. Проверьте, что клиент существует.");
                return;
            }

            int? productId = await GetProductIdByNameAsync(productName);
            if (productId == null)
            {
                MessageBox.Show("Не удалось найти ID продукта. Проверьте, что продукт существует.");
                return;
            }

            int? administratorId = await GetAdministratorIdByNameAsync(fullNameAdm);
            if (administratorId == null)
            {
                MessageBox.Show("Не удалось найти ID администратора. Проверьте, что администратор существует.");
                return;
            }

            // Проверяем и обновляем количество товара
            bool updateSuccess = await AdjustProductQuantityAsync(productId.Value, quantity, isReturn);
            if (!updateSuccess)
            {
                // Если обновление количества не удалось (например, недостаточно товара), прерываем выполнение
                return;
            }

            Transaction transaction = new Transaction
            {
                Date = date,
                Full_Name = fullNameClient,
                Category = category,
                Name_of_Product = productName,
                Quantity = quantity,
                Price = price,
                FullNameAdm = fullNameAdm,
                Return_of_goods = isReturn,
                ProductId = productId.Value,
                AdministratorId = administratorId.Value,
                CustomerId = customerId.Value
            };

            await AddTransactionToDatabase(transaction);

            MessageBox.Show("Транзакция успешно добавлена.");
            LoadTransactionsData();
            CalculateGrandTotal();
        }

        private async Task AddTransactionToDatabase(Transaction transaction)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = @"INSERT INTO Transactions (Date, Full_Name, Category, Name_of_Product, Quantity, Price, FullNameAdm, Return_of_goods, ProductId, AdministratorId, CustomerId)
                    VALUES (@Date, @Full_Name, @Category, @Name_of_Product, @Quantity, @Price, @FullNameAdm, @Return_of_goods, @ProductId, @AdministratorId, @CustomerId)";


                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Date", transaction.Date);
                        cmd.Parameters.AddWithValue("@Full_Name", transaction.Full_Name);
                        cmd.Parameters.AddWithValue("@Category", transaction.Category);
                        cmd.Parameters.AddWithValue("@Name_of_Product", transaction.Name_of_Product);
                        cmd.Parameters.AddWithValue("@Quantity", transaction.Quantity);
                        cmd.Parameters.AddWithValue("@Price", transaction.Price);
                        cmd.Parameters.AddWithValue("@FullNameAdm", transaction.FullNameAdm);
                        cmd.Parameters.AddWithValue("@Return_of_goods", transaction.Return_of_goods);
                        cmd.Parameters.AddWithValue("@ProductId", transaction.ProductId);
                        cmd.Parameters.AddWithValue("@AdministratorId", transaction.AdministratorId);
                        cmd.Parameters.AddWithValue("@CustomerId", transaction.CustomerId);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении транзакции: {ex.Message}");
            }
        }

        private async Task<List<Transaction>> LoadTransactionsFromDatabase()
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM Transactions";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                transactions.Add(new Transaction
                                {
                                    TransactionID = reader.GetInt32(reader.GetOrdinal("TransactionID")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Full_Name = reader.GetString(reader.GetOrdinal("Full_Name")),
                                    Category = reader.GetString(reader.GetOrdinal("Category")),
                                    Name_of_Product = reader.GetString(reader.GetOrdinal("Name_of_Product")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    Summ = reader.GetDecimal(reader.GetOrdinal("Summ")),
                                    FullNameAdm = reader.GetString(reader.GetOrdinal("FullNameAdm")),
                                    Return_of_goods = reader.GetBoolean(reader.GetOrdinal("Return_of_goods")),
                                    ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : reader.GetInt32(reader.GetOrdinal("ProductId")),
                                    AdministratorId = reader.IsDBNull(reader.GetOrdinal("AdministratorId")) ? 0 : reader.GetInt32(reader.GetOrdinal("AdministratorId")),
                                    CustomerId = reader.IsDBNull(reader.GetOrdinal("CustomerId")) ? 0 : reader.GetInt32(reader.GetOrdinal("CustomerId"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке транзакций: {ex.Message}");
            }
            return transactions;
        }

        private async void LoadTransactionsData()
        {
            var transactions = await LoadTransactionsFromDatabase();
            dgvTransactions.DataSource = transactions;

            // Настройка отображения столбцов
            SetupDataGridView();

            // Обновление итоговой суммы
            CalculateGrandTotal();
        }

        private async Task DeleteTransactionFromDatabase(int transactionId)
        {
            try
            {
                // Получаем транзакцию 
                Transaction transaction = await GetTransactionByIdAsync(transactionId);
                if (transaction == null)
                {
                    MessageBox.Show("Транзакция не найдена.");
                    return;
                }

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    // Начинаем транзакцию SQL
                    using (var sqlTransaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Удаляем транзакцию
                            string deleteQuery = "DELETE FROM Transactions WHERE TransactionID = @TransactionID";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection, sqlTransaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@TransactionID", transactionId);
                                await deleteCmd.ExecuteNonQueryAsync();
                            }

                            // Корректируем количество товара
                            bool adjustSuccess = false;
                            if (transaction.Return_of_goods)
                            {
                                // Если транзакция была возвратом, уменьшаем количество товара
                                adjustSuccess = await AdjustProductQuantityAsync(transaction.ProductId, transaction.Quantity, false);
                            }
                            else
                            {
                                // Если транзакция была продажей, увеличиваем количество товара
                                adjustSuccess = await AdjustProductQuantityAsync(transaction.ProductId, transaction.Quantity, true);
                            }

                            if (!adjustSuccess)
                            {
                                throw new Exception("Ошибка при корректировке количества товара при удалении транзакции.");
                            }

                            // Подтверждаем транзакцию
                            sqlTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Откатываем транзакцию в случае ошибки
                            sqlTransaction.Rollback();
                            MessageBox.Show($"Ошибка при удалении транзакции: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении транзакции: {ex.Message}");
            }
        }

        private async Task UpdateTransactionInDatabase(Transaction newTransaction)
        {
            try
            {
                // Получаем старую транзакцию
                Transaction oldTransaction = await GetTransactionByIdAsync(newTransaction.TransactionID);
                if (oldTransaction == null)
                {
                    MessageBox.Show("Старая транзакция не найдена.");
                    return;
                }

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    // Начинаем транзакцию для обеспечения целостности данных
                    using (var sqlTransaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string query = @"UPDATE Transactions SET 
                            Date = @Date,
                            Full_Name = @Full_Name,
                            Category = @Category,
                            Name_of_Product = @Name_of_Product,
                            Quantity = @Quantity,
                            Price = @Price,
                            FullNameAdm = @FullNameAdm,
                            Return_of_goods = @Return_of_goods,
                            ProductId = @ProductId,
                            AdministratorId = @AdministratorId,
                            CustomerId = @CustomerId
                            WHERE TransactionID = @TransactionID";

                            using (SqlCommand cmd = new SqlCommand(query, connection, sqlTransaction))
                            {
                                cmd.Parameters.AddWithValue("@Date", newTransaction.Date);
                                cmd.Parameters.AddWithValue("@Full_Name", newTransaction.Full_Name);
                                cmd.Parameters.AddWithValue("@Category", newTransaction.Category);
                                cmd.Parameters.AddWithValue("@Name_of_Product", newTransaction.Name_of_Product);
                                cmd.Parameters.AddWithValue("@Quantity", newTransaction.Quantity);
                                cmd.Parameters.AddWithValue("@Price", newTransaction.Price);
                                cmd.Parameters.AddWithValue("@FullNameAdm", newTransaction.FullNameAdm);
                                cmd.Parameters.AddWithValue("@Return_of_goods", newTransaction.Return_of_goods);
                                cmd.Parameters.AddWithValue("@ProductId", newTransaction.ProductId);
                                cmd.Parameters.AddWithValue("@AdministratorId", newTransaction.AdministratorId);
                                cmd.Parameters.AddWithValue("@CustomerId", newTransaction.CustomerId);
                                cmd.Parameters.AddWithValue("@TransactionID", newTransaction.TransactionID);

                                await cmd.ExecuteNonQueryAsync();
                            }

                            // Корректируем количество товара

                            // Если товар изменился, нужно откатить старую транзакцию и применить новую
                            if (oldTransaction.Name_of_Product != newTransaction.Name_of_Product)
                            {
                                // Откатываем старую транзакцию
                                bool rollbackSuccess = await AdjustProductQuantityAsync(oldTransaction.ProductId, oldTransaction.Quantity, !oldTransaction.Return_of_goods);
                                if (!rollbackSuccess)
                                {
                                    throw new Exception("Ошибка при откате старой транзакции.");
                                }

                                // Применяем новую транзакцию
                                bool applySuccess = await AdjustProductQuantityAsync(newTransaction.ProductId, newTransaction.Quantity, newTransaction.Return_of_goods);
                                if (!applySuccess)
                                {
                                    throw new Exception("Ошибка при применении новой транзакции.");
                                }
                            }
                            else
                            {
                                // Товар не изменился, корректируем разницу в количестве
                                int quantityDifference = newTransaction.Quantity - oldTransaction.Quantity;
                                bool adjustSuccess = false;

                                if (newTransaction.Return_of_goods)
                                {
                                    // Если транзакция теперь возврат, увеличиваем количество
                                    adjustSuccess = await AdjustProductQuantityAsync(newTransaction.ProductId, quantityDifference, true);
                                }
                                else
                                {
                                    // Если транзакция теперь продажа, уменьшаем количество
                                    adjustSuccess = await AdjustProductQuantityAsync(newTransaction.ProductId, quantityDifference, false);
                                }

                                if (!adjustSuccess)
                                {
                                    throw new Exception("Ошибка при корректировке количества товара.");
                                }
                            }

                            // Подтверждаем транзакцию
                            sqlTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Откатываем транзакцию в случае ошибки
                            sqlTransaction.Rollback();
                            MessageBox.Show($"Ошибка при обновлении транзакции: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении транзакции: {ex.Message}");
            }
        }

        private async Task<bool> AdjustProductQuantityAsync(int productId, int quantity, bool isReturn)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    // Если это возврат, увеличиваем количество
                    if (isReturn)
                    {
                        string query = "UPDATE Products SET Quantity = Quantity + @Quantity WHERE Id = @ProductId";
                        using (var cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            int rowsAffected = await cmd.ExecuteNonQueryAsync();

                            if (rowsAffected == 0)
                            {
                                MessageBox.Show($"Не удалось найти товар с ID \"{productId}\" для обновления количества.", "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        // Если это продажа, проверяем достаточность количества
                        int currentQuantity = await GetCurrentProductQuantityAsync(productId);
                        if (currentQuantity < quantity)
                        {
                            MessageBox.Show($"Недостаточно товара на складе. Текущие запасы: {currentQuantity}.", "Недостаточно товара", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        string query = "UPDATE Products SET Quantity = Quantity - @Quantity WHERE Id = @ProductId";
                        using (var cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            int rowsAffected = await cmd.ExecuteNonQueryAsync();

                            if (rowsAffected == 0)
                            {
                                MessageBox.Show($"Не удалось найти товар с ID \"{productId}\" для обновления количества.", "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    return true; // Успешное обновление количества
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при корректировке количества товара: {ex.Message}");
                return false;
            }
        }

        private async void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                // Получаем выбранную транзакцию
                Transaction selectedTransaction = (Transaction)dgvTransactions.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную транзакцию?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await DeleteTransactionFromDatabase(selectedTransaction.TransactionID);
                    LoadTransactionsData(); // обновление таблицы после удаления
                    CalculateGrandTotal();  // пересчет итога
                    MessageBox.Show("Транзакция успешно удалена.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите транзакцию для удаления.");
            }
        }

        private async void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            if (editingTransactionId != null)
            {
                // Собераем данные из полей ввода
                string fullNameClient = cmbFullNameClient.Text.Trim();
                string category = cmbCategory.Text.Trim();
                string productName = cmbProductName.Text.Trim();
                string fullNameAdm = cmbFullNameAdm.Text.Trim();
                bool isReturn = chkReturnOfGoods.Checked;

                if (string.IsNullOrEmpty(fullNameClient) ||
                    string.IsNullOrEmpty(category) ||
                    string.IsNullOrEmpty(productName) ||
                    string.IsNullOrEmpty(fullNameAdm) ||
                    string.IsNullOrEmpty(txtQuantity.Text) ||
                    string.IsNullOrEmpty(txtPrice.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity))
                {
                    MessageBox.Show("Количество должно быть числом.");
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Цена должна быть числом.");
                    return;
                }

                Transaction transaction = new Transaction
                {
                    TransactionID = editingTransactionId.Value,
                    Date = dateTimePickerTransactionDate.Value,
                    Full_Name = fullNameClient,
                    Category = category,
                    Name_of_Product = productName,
                    Quantity = quantity,
                    Price = price,
                    FullNameAdm = fullNameAdm,
                    Return_of_goods = isReturn,
                    ProductId = (await GetProductIdByNameAsync(productName)) ?? 0,
                    AdministratorId = (await GetAdministratorIdByNameAsync(fullNameAdm)) ?? 0,
                    CustomerId = (await GetCustomerIdByNameAsync(fullNameClient)) ?? 0
                };

                await UpdateTransactionInDatabase(transaction);
                MessageBox.Show("Транзакция успешно обновлена.");

                ClearTransactionFields();
                LoadTransactionsData();

                editingTransactionId = null;
            }
            else
            {
                MessageBox.Show("Нет выбранной транзакции для сохранения.");
            }
        }

        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                // Получаем выбранную транзакцию
                Transaction selectedTransaction = (Transaction)dgvTransactions.SelectedRows[0].DataBoundItem;

                // Заполняем поля ввода данными транзакции
                dateTimePickerTransactionDate.Value = selectedTransaction.Date;
                cmbFullNameClient.Text = selectedTransaction.Full_Name;
                cmbCategory.Text = selectedTransaction.Category;
                cmbProductName.Text = selectedTransaction.Name_of_Product;
                txtQuantity.Text = selectedTransaction.Quantity.ToString();
                txtPrice.Text = selectedTransaction.Price.ToString();
                cmbFullNameAdm.Text = selectedTransaction.FullNameAdm;
                chkReturnOfGoods.Checked = selectedTransaction.Return_of_goods;

                // Сохраняем ID редактируемой транзакции
                editingTransactionId = selectedTransaction.TransactionID;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите транзакцию для редактирования.");
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            // Собираем критерии поиска
            DateTime? startDate = dateTimePickerTransactionDate.Value.Date;
            DateTime? endDate = dateTimePickerEndDate.Value.Date;

            string fullNameClient = cmbFullNameClient.SelectedItem?.ToString();
            string category = cmbCategory.SelectedItem?.ToString();
            string productName = cmbProductName.SelectedItem?.ToString();
            string fullNameAdm = cmbFullNameAdm.SelectedItem?.ToString();
            bool? isReturn = chkReturnOfGoods.Checked ? (bool?)true : null;


            int? quantity = null;
            decimal? price = null;

            // Попытка парсинга количества
            if (!string.IsNullOrWhiteSpace(txtQuantity.Text) &&
                txtQuantity.Text != txtQuantity.Tag.ToString())
            {
                if (int.TryParse(txtQuantity.Text, out int q))
                {
                    quantity = q;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное количество для поиска.");
                    return;
                }
            }

            // Попытка парсинга цены
            if (!string.IsNullOrWhiteSpace(txtPrice.Text) &&
                txtPrice.Text != txtPrice.Tag.ToString())
            {
                if (decimal.TryParse(txtPrice.Text, out decimal p))
                {
                    price = p;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректную цену для поиска.");
                    return;
                }
            }

            // Построение SQL-запроса
            string query = "SELECT * FROM Transactions WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (startDate.HasValue)
            {
                query += " AND Date >= @StartDate";
                parameters.Add(new SqlParameter("@StartDate", startDate.Value));
            }

            if (endDate.HasValue)
            {
                query += " AND Date <= @EndDate";
                parameters.Add(new SqlParameter("@EndDate", endDate.Value));
            }

            if (!string.IsNullOrEmpty(fullNameClient))
            {
                query += " AND Full_Name = @FullNameClient";
                parameters.Add(new SqlParameter("@FullNameClient", fullNameClient));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query += " AND Category = @Category";
                parameters.Add(new SqlParameter("@Category", category));
            }

            if (!string.IsNullOrEmpty(productName))
            {
                query += " AND Name_of_Product = @ProductName";
                parameters.Add(new SqlParameter("@ProductName", productName));
            }

            if (!string.IsNullOrEmpty(fullNameAdm))
            {
                query += " AND FullNameAdm = @FullNameAdm";
                parameters.Add(new SqlParameter("@FullNameAdm", fullNameAdm));
            }

            if (isReturn.HasValue)
            {
                query += " AND Return_of_goods = @ReturnOfGoods";
                parameters.Add(new SqlParameter("@ReturnOfGoods", isReturn.Value));
            }


            if (quantity.HasValue)
            {
                query += " AND Quantity = @Quantity";
                parameters.Add(new SqlParameter("@Quantity", quantity.Value));
            }

            if (price.HasValue)
            {
                query += " AND Price = @Price";
                parameters.Add(new SqlParameter("@Price", price.Value));
            }

            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            List<Transaction> transactions = new List<Transaction>();

                            while (await reader.ReadAsync())
                            {
                                transactions.Add(new Transaction
                                {
                                    TransactionID = reader.GetInt32(reader.GetOrdinal("TransactionID")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Full_Name = reader.GetString(reader.GetOrdinal("Full_Name")),
                                    Category = reader.GetString(reader.GetOrdinal("Category")),
                                    Name_of_Product = reader.GetString(reader.GetOrdinal("Name_of_Product")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    Summ = reader.GetDecimal(reader.GetOrdinal("Summ")), 
                                    FullNameAdm = reader.GetString(reader.GetOrdinal("FullNameAdm")),
                                    Return_of_goods = reader.GetBoolean(reader.GetOrdinal("Return_of_goods"))
                                });
                            }

                            if (transactions.Count == 0)
                            {
                                MessageBox.Show("Транзакции не найдены по заданным критериям поиска.", "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvTransactions.DataSource = null; // Очистить DataGridView
                                lblGrandTotal.Text = "Итоговая сумма: 0";
                            }
                            else
                            {
                                dgvTransactions.DataSource = transactions;

                                // Настройка отображения столбцов
                                SetupDataGridView();
                                // Обновление итоговой суммы
                                CalculateGrandTotal();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении поиска: {ex.Message}");
            }
        }

        private void SetupDataGridView()
        {
            // Скрываем ненужные столбцы
            if (dgvTransactions.Columns.Contains("TransactionID"))
                dgvTransactions.Columns["TransactionID"].Visible = false;

            if (dgvTransactions.Columns.Contains("ProductId"))
                dgvTransactions.Columns["ProductId"].Visible = false;

            if (dgvTransactions.Columns.Contains("AdministratorId"))
                dgvTransactions.Columns["AdministratorId"].Visible = false;

            if (dgvTransactions.Columns.Contains("CustomerId"))
                dgvTransactions.Columns["CustomerId"].Visible = false;

            if (dgvTransactions.Columns.Contains("Date"))
            {
                dgvTransactions.Columns["Date"].HeaderText = "Дата";
                dgvTransactions.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvTransactions.Columns["Date"].Width = 70; 
            }

            if (dgvTransactions.Columns.Contains("Full_Name"))
            {
                dgvTransactions.Columns["Full_Name"].HeaderText = "Клиент";
                dgvTransactions.Columns["Full_Name"].Width = 160;
            }

            if (dgvTransactions.Columns.Contains("Category"))
            {
                dgvTransactions.Columns["Category"].HeaderText = "Категория";
                dgvTransactions.Columns["Category"].Width = 60;
            }

            if (dgvTransactions.Columns.Contains("Name_of_Product"))
            {
                dgvTransactions.Columns["Name_of_Product"].HeaderText = "Товар";
                dgvTransactions.Columns["Name_of_Product"].Width = 120;
            }

            if (dgvTransactions.Columns.Contains("Quantity"))
            {
                dgvTransactions.Columns["Quantity"].HeaderText = "Количество";
                dgvTransactions.Columns["Quantity"].Width = 30;
            }

            if (dgvTransactions.Columns.Contains("Price"))
            {
                dgvTransactions.Columns["Price"].HeaderText = "Цена";
                dgvTransactions.Columns["Price"].DefaultCellStyle.Format = "C2";
                dgvTransactions.Columns["Price"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("uk-UA");
                dgvTransactions.Columns["Price"].Width = 80;
            }

            if (dgvTransactions.Columns.Contains("Summ"))
            {
                dgvTransactions.Columns["Summ"].HeaderText = "Сумма";
                dgvTransactions.Columns["Summ"].DefaultCellStyle.Format = "C2";
                dgvTransactions.Columns["Summ"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("uk-UA");
                dgvTransactions.Columns["Summ"].Width = 100;
            }

            if (dgvTransactions.Columns.Contains("FullNameAdm"))
            {
                dgvTransactions.Columns["FullNameAdm"].HeaderText = "Администратор";
                dgvTransactions.Columns["FullNameAdm"].Width = 160;
            }

            if (dgvTransactions.Columns.Contains("Return_of_goods"))
            {
                dgvTransactions.Columns["Return_of_goods"].HeaderText = "Возврат";
                dgvTransactions.Columns["Return_of_goods"].Width = 50;
            }

           
        }


        private async void btnResetSearch_Click(object sender, EventArgs e)
        {
            //// Очистка полей поиска
            cmbFullNameClient.Text = "ФИО Клиента";
            cmbCategory.Text = "Категория";
            txtQuantity.Text = "Количество";
            txtPrice.Text = "Цена";
            cmbProductName.Text = "Наименование Товара";
            cmbFullNameAdm.Text = "ФИО Администратора";

            // Загрузка всех транзакций
            LoadTransactionsData();
        }

        private async Task<int?> GetCustomerIdByNameAsync(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return null;

            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT Id FROM Customers WHERE FullName = @FullName";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        var result = await cmd.ExecuteScalarAsync();
                        return result != null ? (int?)Convert.ToInt32(result) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении ID клиента: {ex.Message}");
                return null;
            }
        }

        private async Task<int?> GetProductIdByNameAsync(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return null;

            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT ID FROM Products WHERE Name_of_Product = @ProductName";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        var result = await cmd.ExecuteScalarAsync();
                        return result != null ? (int?)Convert.ToInt32(result) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении ID продукта: {ex.Message}");
                return null;
            }
        }

        private async Task<int?> GetAdministratorIdByNameAsync(string fullNameAdm)
        {
            if (string.IsNullOrWhiteSpace(fullNameAdm))
                return null;

            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT Id FROM Administrator WHERE FullName = @FullNameAdm";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FullNameAdm", fullNameAdm);
                        var result = await cmd.ExecuteScalarAsync();
                        return result != null ? (int?)Convert.ToInt32(result) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении ID администратора: {ex.Message}");
                return null;
            }
        }

        private async Task<int> GetCurrentProductQuantityAsync(int productId)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT Quantity FROM Products WHERE Id = @ProductId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        var result = await cmd.ExecuteScalarAsync();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении текущего количества товара: {ex.Message}");
                return 0;
            }
        }

        private async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT * FROM Transactions WHERE TransactionID = @TransactionID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Transaction
                                {
                                    TransactionID = reader.GetInt32(reader.GetOrdinal("TransactionID")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Full_Name = reader.GetString(reader.GetOrdinal("Full_Name")),
                                    Category = reader.GetString(reader.GetOrdinal("Category")),
                                    Name_of_Product = reader.GetString(reader.GetOrdinal("Name_of_Product")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    Summ = reader.GetDecimal(reader.GetOrdinal("Summ")),
                                    FullNameAdm = reader.GetString(reader.GetOrdinal("FullNameAdm")),
                                    Return_of_goods = reader.GetBoolean(reader.GetOrdinal("Return_of_goods")),
                                    ProductId = reader.IsDBNull(reader.GetOrdinal("ProductId")) ? 0 : reader.GetInt32(reader.GetOrdinal("ProductId")),
                                    AdministratorId = reader.IsDBNull(reader.GetOrdinal("AdministratorId")) ? 0 : reader.GetInt32(reader.GetOrdinal("AdministratorId")),
                                    CustomerId = reader.IsDBNull(reader.GetOrdinal("CustomerId")) ? 0 : reader.GetInt32(reader.GetOrdinal("CustomerId"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении транзакции: {ex.Message}");
                return null;
            }

            return null;
        }

        private void ClearTransactionFields()
        {
            dateTimePickerTransactionDate.Value = DateTime.Now;
            cmbFullNameClient.SelectedItem = null;
            cmbCategory.SelectedItem = null;
            cmbProductName.SelectedItem = null;
            txtQuantity.Clear();
            txtPrice.Clear();
            cmbFullNameAdm.SelectedItem = null;
            chkReturnOfGoods.Checked = false;
         
        }

        public class Transaction
        {
            public int TransactionID { get; set; }
            public DateTime Date { get; set; }
            public string Full_Name { get; set; }
            public string Category { get; set; }
            public string Name_of_Product { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal Summ { get; set; }
            public string FullNameAdm { get; set; }
            public bool Return_of_goods { get; set; }
            public int ProductId { get; set; }
            public int AdministratorId { get; set; }
            public int CustomerId { get; set; }
        }

    }
}
