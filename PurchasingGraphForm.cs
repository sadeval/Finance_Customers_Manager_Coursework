using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;

namespace FMS_PNP
{
    public enum FilterType
    {
        Category,
        Season,
        ProductName,
        CustomerName
    }

    public partial class PurchasingGraphForm : MetroForm
    {
        public PurchasingGraphForm()
        {
            InitializeComponent();
            InitializeChart();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await LoadCategoriesAsync();
            await LoadSeasonsAsync();
            await LoadCustomerNamesAsync();
            await LoadProductNamesAsync(); 
        }

        private void InitializeChart()
        {
            // Инициализация LiveCharts
            cartesianChartGrafProd.Series = new SeriesCollection();

            cartesianChartGrafProd.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Labels = new List<string>(),
                LabelsRotation = 45,
                Separator = new Separator { Step = 1 }
            });

            cartesianChartGrafProd.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Количество",
                LabelFormatter = value => value.ToString("N")
            });

            cartesianChartGrafProd.LegendLocation = LegendLocation.Right;

            cartesianChartGrafProd.DisableAnimations = true;
        }

        private async Task LoadCategoriesAsync()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT DISTINCT Category FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cmbCategory.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private async Task LoadSeasonsAsync()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT DISTINCT Season FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cmbSeason.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private async Task LoadProductNamesAsync()
        {
            cmbProductName.Items.Clear();

            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT DISTINCT Name_of_Product FROM Products";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cmbProductName.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private async Task LoadCustomerNamesAsync()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT DISTINCT FullName FROM Customers";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cmbCustomerName.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private async void btnGenerateChart_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart1.Value.Date;
            DateTime endDate = dateTimePickerEnd1.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания.");
                return;
            }

            // Собираем выбранные фильтры
            List<(FilterType, string)> selectedFilters = new List<(FilterType, string)>();

            if (cmbCategory.SelectedItem != null)
                selectedFilters.Add((FilterType.Category, cmbCategory.SelectedItem.ToString()));

            if (cmbSeason.SelectedItem != null)
                selectedFilters.Add((FilterType.Season, cmbSeason.SelectedItem.ToString()));

            if (cmbProductName.SelectedItem != null)
                selectedFilters.Add((FilterType.ProductName, cmbProductName.SelectedItem.ToString()));

            if (cmbCustomerName.SelectedItem != null)
                selectedFilters.Add((FilterType.CustomerName, cmbCustomerName.SelectedItem.ToString()));

            if (selectedFilters.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один фильтр.");
                return;
            }

            // Очистка существующих серий
            cartesianChartGrafProd.Series.Clear();

            // Список всех дат для оси X
            SortedSet<DateTime> allDates = new SortedSet<DateTime>();

            // Словарь для хранения данных по каждому фильтру
            Dictionary<(FilterType, string), Dictionary<DateTime, double>> allSalesData = new Dictionary<(FilterType, string), Dictionary<DateTime, double>>();

            // Получаем данные для каждого выбранного фильтра
            foreach (var filter in selectedFilters)
            {
                var salesData = await GetSalesDataAsync(filter.Item1, filter.Item2, startDate, endDate);
                allSalesData.Add(filter, salesData);

                foreach (var date in salesData.Keys)
                {
                    allDates.Add(date);
                }
            }

            // Если нет данных после всех запросов
            bool hasData = false;
            foreach (var salesData in allSalesData.Values)
            {
                if (salesData.Count > 0)
                {
                    hasData = true;
                    break;
                }
            }

            if (!hasData)
            {
                MessageBox.Show("Нет данных для отображения.");
                InitializeChart(); // Инициализация с пустым набором данных
                return;
            }

            // Преобразуем даты в строки для меток оси X
            List<string> labels = new List<string>();
            foreach (var date in allDates)
            {
                labels.Add(date.ToString("dd.MM"));
            }

            // Устанавливаем метки оси X
            if (cartesianChartGrafProd.AxisX.Count > 0)
            {
                cartesianChartGrafProd.AxisX[0].Labels = labels;
            }
            else
            {
                cartesianChartGrafProd.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    //Title = "Дата",
                    Labels = labels,
                    LabelsRotation = 45,
                    Separator = new Separator { Step = 1 }
                });
            }

            // Для каждой серии добавляем данные
            foreach (var filter in selectedFilters)
            {
                Dictionary<DateTime, double> salesData = allSalesData[filter];
                ChartValues<double> values = new ChartValues<double>();

                foreach (var date in allDates)
                {
                    if (salesData.ContainsKey(date))
                        values.Add(salesData[date]);
                    else
                        values.Add(0); // Можно использовать 0 или пропускать
                }

                string seriesTitle = "";

                switch (filter.Item1)
                {
                    case FilterType.Category:
                        seriesTitle = $"Категория: {filter.Item2}";
                        break;
                    case FilterType.Season:
                        seriesTitle = $"Сезон: {filter.Item2}";
                        break;
                    case FilterType.ProductName:
                        seriesTitle = $"Товар: {filter.Item2}";
                        break;
                    case FilterType.CustomerName:
                        seriesTitle = $"Клиент: {filter.Item2}";
                        break;
                }

                cartesianChartGrafProd.Series.Add(new LineSeries
                {
                    Title = seriesTitle,
                    Values = values,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8
                });
            }

            // Обновление графика
            cartesianChartGrafProd.Refresh();
        }

        private async Task<Dictionary<DateTime, double>> GetSalesDataAsync(FilterType filterType, string filterValue, DateTime startDate, DateTime endDate)
        {
            var salesData = new Dictionary<DateTime, double>();

            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    SELECT t.Date, SUM(t.Quantity) as TotalQuantity
                    FROM Transactions t
                    INNER JOIN Products p ON t.ProductId = p.Id
                    INNER JOIN Customers c ON t.CustomerId = c.Id
                    WHERE t.Date BETWEEN @StartDate AND @EndDate";

                // Добавляем условие в зависимости от типа фильтра
                switch (filterType)
                {
                    case FilterType.Category:
                        query += " AND p.Category = @FilterValue";
                        break;
                    case FilterType.Season:
                        query += " AND p.Season = @FilterValue";
                        break;
                    case FilterType.ProductName:
                        query += " AND p.Name_of_Product = @FilterValue";
                        break;
                    case FilterType.CustomerName:
                        query += " AND c.FullName = @FilterValue";
                        break;
                }

                query += " GROUP BY t.Date ORDER BY t.Date";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@FilterValue", filterValue);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DateTime date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            double totalQuantity = Convert.ToDouble(reader["TotalQuantity"]);
                            salesData.Add(date, totalQuantity);
                        }
                    }
                }
            }

            return salesData;
        }
    }
}
