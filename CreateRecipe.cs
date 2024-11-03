using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MetroFramework.Forms;

namespace FMS_PNP
{
    public partial class CreateRecipe : MetroForm
    {
        // Добавляем переменные класса для хранения выбранного покупателя и администратора
        private string selectedCustomer = "Не указан";
        private string selectedAdministrator = "Не указан";

        public CreateRecipe()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            LoadData();

            // Подключаем обработчики событий
            gridItems.CellValueChanged += gridItems_CellValueChanged;
            gridItems.EditingControlShowing += gridItems_EditingControlShowing;
        }

        private void btnSaveToPDF_Click(object sender, EventArgs e)
        {
            SaveToPDF();
        }

        private void SaveToPDF()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string customerName = selectedCustomer;

                // Проверяем, указан ли покупатель
                if (string.IsNullOrWhiteSpace(customerName) || customerName == "Не указан")
                {
                    customerName = "Чек";
                }

                // Очищаем имя покупателя для использования в имени файла
                string cleanCustomerName = CleanFileName(customerName);
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Сохранить чек как PDF";
                saveFileDialog.FileName = $"{cleanCustomerName}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Путь к шрифту, поддерживающему кириллицу (например, Arial)
                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        // Здесь явно указываем класс Font из iTextSharp.text
                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontContent = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            Document doc = new Document(PageSize.A4, 50, 50, 25, 25);
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.Open();

                            // Загрузка изображения логотипа
                            string logoPath = @"D:\Logo.png"; // Указываем фактический путь к логотипу
                            if (File.Exists(logoPath))
                            {
                                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                                logo.ScaleToFit(100f, 100f); // Масштабируем изображение до нужных размеров

                                // Устанавливаем позицию логотипа
                                logo.Alignment = iTextSharp.text.Image.ALIGN_RIGHT | iTextSharp.text.Image.TEXTWRAP;
                                logo.SetAbsolutePosition(doc.PageSize.Width - doc.RightMargin - logo.ScaledWidth, doc.PageSize.Height - doc.TopMargin - logo.ScaledHeight);

                                doc.Add(logo);
                            }
                            else
                            {
                                MessageBox.Show("Логотип не найден по указанному пути.");
                            }

                            // Заголовок
                            Paragraph title = new Paragraph("ФОП \"Y'Style\"\nг.Одесса, ул.Гранитная 1, оф. 73\n", fontTitle);
                            title.Alignment = Element.ALIGN_LEFT;
                            doc.Add(title);

                            doc.Add(new Paragraph(" ", fontContent));

                            // Реквизиты
                            Paragraph rekvizit = new Paragraph("№ тел. +38(095) 528 98 73\n" +
                                "IBAN UA943052990000026208673497748\n" +
                                "ЄДРПОУ 3048522766", fontContent);
                            rekvizit.Alignment = Element.ALIGN_LEFT;
                            doc.Add(rekvizit);

                            doc.Add(new Paragraph(" ", fontContent));

                            // Дата и время
                            Paragraph dateTime = new Paragraph($"Оплачено: {lblDate.Text}  {lblTime.Text}", fontContent);
                            dateTime.Alignment = Element.ALIGN_LEFT;
                            doc.Add(dateTime);

                            doc.Add(new Paragraph(" ", fontContent));

                            // Покупатель
                            Paragraph customer = new Paragraph($"Покупатель: {customerName}", fontContent);
                            customer.Alignment = Element.ALIGN_LEFT;
                            doc.Add(customer);

                            // Продавец
                            string administratorName = selectedAdministrator;
                            Paragraph administrator = new Paragraph($"Продавец: {administratorName}", fontContent);
                            administrator.Alignment = Element.ALIGN_LEFT;
                            doc.Add(administrator);

                            doc.Add(new Paragraph(" ", fontContent));

                            // Проверка наличия данных в gridItems
                            if (gridItems.Rows.Count == 0)
                            {
                                MessageBox.Show("Нет данных для сохранения в PDF.");
                                return;
                            }

                            // Создание таблицы
                            PdfPTable table = new PdfPTable(gridItems.Columns.Count);
                            table.WidthPercentage = 100;
                            // Установка ширины столбцов (можно настроить по необходимости)
                            float[] widths = new float[] { 2f, 1f, 1f, 1f };
                            table.SetWidths(widths);

                            // Добавление заголовков столбцов
                            foreach (DataGridViewColumn column in gridItems.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontContent));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cell);
                            }

                            // Добавление данных строк
                            foreach (DataGridViewRow row in gridItems.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        string cellText = cell.Value?.ToString() ?? string.Empty;

                                        // Если это сумма, форматируем с указанием культуры
                                        if (cell.ColumnIndex == 2 || cell.ColumnIndex == 3)
                                        {
                                            decimal value;
                                            if (decimal.TryParse(cellText, out value))
                                            {
                                                cellText = value.ToString("C", new CultureInfo("uk-UA"));
                                            }
                                        }

                                        PdfPCell pdfCell = new PdfPCell(new Phrase(cellText, fontContent));
                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        table.AddCell(pdfCell);
                                    }
                                }
                            }

                            doc.Add(table);

                            // Итоги
                            doc.Add(new Paragraph(" ", fontContent));
                            Paragraph totalItems = new Paragraph(lblItemCount.Text, fontContent);
                            totalItems.Alignment = Element.ALIGN_RIGHT;
                            doc.Add(totalItems);

                            Paragraph grandTotal = new Paragraph(lblGrandTotal.Text, fontContent);
                            grandTotal.Alignment = Element.ALIGN_RIGHT;
                            doc.Add(grandTotal);

                            doc.Close();
                        }
                        MessageBox.Show("Чек успешно сохранен в PDF.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении PDF: {ex.Message}");
                    }
                }
            }
        }

        private string CleanFileName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c.ToString(), "");
            }
            return fileName;
        }
        private void LoadData()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                connection.Open();

                // Загрузка покупателей
                var customerCommand = new SqlCommand("SELECT FullName FROM Customers", connection);
                using (var reader = customerCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbCustomers.Items.Add(reader["FullName"].ToString());
                    }
                }

                // Загрузка товаров
                var productCommand = new SqlCommand("SELECT Name_of_Product FROM Products", connection);
                using (var reader = productCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbProducts.Items.Add(reader["Name_of_Product"].ToString());
                    }
                }

                // Загрузка администраторов
                var adminCommand = new SqlCommand("SELECT FullName FROM Administrator", connection);
                using (var reader = adminCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbAdministrators.Items.Add(reader["FullName"].ToString());
                    }
                }
            }
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem == null)
                return;

            var selectedProduct = cmbProducts.SelectedItem.ToString();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Price FROM Products WHERE Name_of_Product = @ProductName", connection);
                command.Parameters.AddWithValue("@ProductName", selectedProduct);
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    var price = Convert.ToDecimal(result);
                    int quantity = 1;
                    decimal totalPrice = price * quantity;

                    // Добавляем выбранный товар в таблицу с количеством и суммой
                    gridItems.Rows.Add(selectedProduct, quantity, price, totalPrice);
                    UpdateTotals();
                }
                else
                {
                    MessageBox.Show("Цена товара не найдена.");
                }
            }
        }


        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedItem != null)
                selectedCustomer = cmbCustomers.SelectedItem.ToString();
        }

        private void cmbAdministrators_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdministrators.SelectedItem != null)
                selectedAdministrator = cmbAdministrators.SelectedItem.ToString();
        }

        private void UpdateTotals()
        {
            int itemCount = 0;
            decimal grandTotal = 0;

            foreach (DataGridViewRow row in gridItems.Rows)
            {
                if (!row.IsNewRow)
                {
                    int quantity = 1;
                    decimal price = 0;
                    decimal totalPrice = 0;

                    if (row.Cells[1].Value != null)
                    {
                        if (!int.TryParse(row.Cells[1].Value.ToString(), out quantity) || quantity < 1)
                        {
                            quantity = 1;
                            row.Cells[1].Value = quantity;
                        }
                    }
                    if (row.Cells[2].Value != null)
                    {
                        decimal.TryParse(row.Cells[2].Value.ToString(), out price);
                    }

                    totalPrice = price * quantity;
                    row.Cells[3].Value = totalPrice;

                    itemCount += quantity;
                    grandTotal += totalPrice;
                }
            }

            lblItemCount.Text = $"Количество товаров: {itemCount}";
            lblGrandTotal.Text = $"Общая сумма: {grandTotal.ToString("C", new CultureInfo("uk-UA"))}";
        }

        private void gridItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gridItems.CurrentCell.ColumnIndex == 1) // Индекс столбца "Количество"
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Tb_KeyPress; // Удаляем предыдущий обработчик
                    tb.KeyPress += Tb_KeyPress;  // Добавляем новый обработчик
                }
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и управляющие символы
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridItems.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in gridItems.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        gridItems.Rows.Remove(row);
                    }
                }
                UpdateTotals();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void gridItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1) // Индекс столбца "Количество"
            {
                var row = gridItems.Rows[e.RowIndex];
                int quantity = 1;
                decimal price = 0;
                decimal totalPrice = 0;

                if (row.Cells[1].Value != null)
                {
                    if (!int.TryParse(row.Cells[1].Value.ToString(), out quantity) || quantity < 1)
                    {
                        quantity = 1; // Устанавливаем количество в 1, если введено некорректное значение
                        row.Cells[1].Value = quantity;
                    }
                }
                if (row.Cells[2].Value != null)
                {
                    decimal.TryParse(row.Cells[2].Value.ToString(), out price);
                }

                totalPrice = price * quantity;
                row.Cells[3].Value = totalPrice;

                UpdateTotals();
            }
        }

    }
}
