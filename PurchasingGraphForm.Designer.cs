namespace FMS_PNP
{
    partial class PurchasingGraphForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистка всех используемых ресурсов.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                cartesianChartGrafProd.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbSeason = new System.Windows.Forms.ComboBox();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd1 = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateChart = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblSeason = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.cartesianChartGrafProd = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(1118, 91);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 31);
            this.cmbCategory.TabIndex = 0;
            // 
            // cmbSeason
            // 
            this.cmbSeason.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeason.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSeason.FormattingEnabled = true;
            this.cmbSeason.Location = new System.Drawing.Point(1118, 162);
            this.cmbSeason.Name = "cmbSeason";
            this.cmbSeason.Size = new System.Drawing.Size(180, 31);
            this.cmbSeason.TabIndex = 1;
            // 
            // cmbProductName
            // 
            this.cmbProductName.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductName.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(1119, 234);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(180, 31);
            this.cmbProductName.TabIndex = 2;
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerName.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(1119, 309);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(180, 31);
            this.cmbCustomerName.TabIndex = 3;
            // 
            // dateTimePickerStart1
            // 
            this.dateTimePickerStart1.CalendarFont = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerStart1.Location = new System.Drawing.Point(1118, 392);
            this.dateTimePickerStart1.Name = "dateTimePickerStart1";
            this.dateTimePickerStart1.Size = new System.Drawing.Size(180, 22);
            this.dateTimePickerStart1.TabIndex = 4;
            // 
            // dateTimePickerEnd1
            // 
            this.dateTimePickerEnd1.CalendarFont = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerEnd1.Location = new System.Drawing.Point(1118, 456);
            this.dateTimePickerEnd1.Name = "dateTimePickerEnd1";
            this.dateTimePickerEnd1.Size = new System.Drawing.Size(180, 22);
            this.dateTimePickerEnd1.TabIndex = 5;
            // 
            // btnGenerateChart
            // 
            this.btnGenerateChart.BackColor = System.Drawing.Color.Black;
            this.btnGenerateChart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateChart.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerateChart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateChart.Location = new System.Drawing.Point(1118, 547);
            this.btnGenerateChart.Name = "btnGenerateChart";
            this.btnGenerateChart.Size = new System.Drawing.Size(180, 30);
            this.btnGenerateChart.TabIndex = 6;
            this.btnGenerateChart.Text = "Построить график";
            this.btnGenerateChart.UseVisualStyleBackColor = false;
            this.btnGenerateChart.Click += new System.EventHandler(this.btnGenerateChart_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCategory.Location = new System.Drawing.Point(1115, 63);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(88, 23);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Категория";
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSeason.Location = new System.Drawing.Point(1118, 136);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(58, 23);
            this.lblSeason.TabIndex = 9;
            this.lblSeason.Text = "Сезон";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProductName.Location = new System.Drawing.Point(1114, 208);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(145, 23);
            this.lblProductName.TabIndex = 10;
            this.lblProductName.Text = "Название товара";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCustomerName.Location = new System.Drawing.Point(1115, 283);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(65, 23);
            this.lblCustomerName.TabIndex = 11;
            this.lblCustomerName.Text = "Клиент";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStartDate.Location = new System.Drawing.Point(1115, 362);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(25, 23);
            this.lblStartDate.TabIndex = 12;
            this.lblStartDate.Text = "С:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEndDate.Location = new System.Drawing.Point(1114, 430);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(36, 23);
            this.lblEndDate.TabIndex = 13;
            this.lblEndDate.Text = "По:";
            // 
            // cartesianChartGrafProd
            // 
            this.cartesianChartGrafProd.Location = new System.Drawing.Point(23, 63);
            this.cartesianChartGrafProd.Name = "cartesianChartGrafProd";
            this.cartesianChartGrafProd.Size = new System.Drawing.Size(1070, 514);
            this.cartesianChartGrafProd.TabIndex = 14;
            this.cartesianChartGrafProd.Text = "cartesianChart1";
            // 
            // PurchasingGraphForm
            // 
            this.ClientSize = new System.Drawing.Size(1329, 600);
            this.Controls.Add(this.cartesianChartGrafProd);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblSeason);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnGenerateChart);
            this.Controls.Add(this.dateTimePickerEnd1);
            this.Controls.Add(this.dateTimePickerStart1);
            this.Controls.Add(this.cmbCustomerName);
            this.Controls.Add(this.cmbProductName);
            this.Controls.Add(this.cmbSeason);
            this.Controls.Add(this.cmbCategory);
            this.Name = "PurchasingGraphForm";
            this.Text = "График продаж";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbSeason;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd1;
        private System.Windows.Forms.Button btnGenerateChart;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private LiveCharts.WinForms.CartesianChart cartesianChartGrafProd;
    }
}
