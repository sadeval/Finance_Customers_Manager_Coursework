namespace FMS_PNP
{
    partial class CreateRecipe
    {
        private System.ComponentModel.IContainer components = null;
        private MetroFramework.Controls.MetroLabel lblGrandTotal;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroLabel lblTime;
        private MetroFramework.Controls.MetroGrid gridItems;
        private MetroFramework.Controls.MetroLabel lblItemCount;
        private MetroFramework.Controls.MetroComboBox cmbCustomers;
        private MetroFramework.Controls.MetroComboBox cmbProducts;
        private MetroFramework.Controls.MetroComboBox cmbAdministrators;
        private MetroFramework.Controls.MetroButton btnSaveToPDF;
        private MetroFramework.Controls.MetroButton btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
        private System.Windows.Forms.Label lblAdministrator;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox textBox3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblGrandTotal = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.lblTime = new MetroFramework.Controls.MetroLabel();
            this.gridItems = new MetroFramework.Controls.MetroGrid();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblItemCount = new MetroFramework.Controls.MetroLabel();
            this.cmbCustomers = new MetroFramework.Controls.MetroComboBox();
            this.cmbProducts = new MetroFramework.Controls.MetroComboBox();
            this.cmbAdministrators = new MetroFramework.Controls.MetroComboBox();
            this.lblAdministrator = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnSaveToPDF = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Location = new System.Drawing.Point(23, 485);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(249, 23);
            this.lblGrandTotal.TabIndex = 0;
            this.lblGrandTotal.Text = "Общая сумма: 0.00";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(488, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(150, 23);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Дата:";
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(311, 30);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(150, 23);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Время:";
            // 
            // gridItems
            // 
            this.gridItems.AllowUserToResizeRows = false;
            this.gridItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colQuantity,
            this.colPrice,
            this.colTotalPrice});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridItems.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridItems.EnableHeadersVisualStyles = false;
            this.gridItems.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gridItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridItems.Location = new System.Drawing.Point(23, 74);
            this.gridItems.Name = "gridItems";
            this.gridItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridItems.RowHeadersWidth = 51;
            this.gridItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridItems.RowTemplate.Height = 24;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(748, 350);
            this.gridItems.TabIndex = 3;
            this.gridItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItems_CellValueChanged);
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Наименование товара";
            this.colProductName.MinimumWidth = 6;
            this.colProductName.Name = "colProductName";
            this.colProductName.Width = 270;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Количество";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 125;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Цена";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 150;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.HeaderText = "Сумма";
            this.colTotalPrice.MinimumWidth = 6;
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Width = 150;
            // 
            // lblItemCount
            // 
            this.lblItemCount.Location = new System.Drawing.Point(23, 437);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(200, 23);
            this.lblItemCount.TabIndex = 4;
            this.lblItemCount.Text = "Количество товаров: 0";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.ItemHeight = 24;
            this.cmbCustomers.Location = new System.Drawing.Point(451, 430);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(320, 30);
            this.cmbCustomers.TabIndex = 5;
            this.cmbCustomers.UseSelectable = true;
            this.cmbCustomers.SelectedIndexChanged += new System.EventHandler(this.cmbCustomers_SelectedIndexChanged);
            // 
            // cmbProducts
            // 
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.ItemHeight = 24;
            this.cmbProducts.Location = new System.Drawing.Point(451, 478);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(320, 30);
            this.cmbProducts.TabIndex = 6;
            this.cmbProducts.UseSelectable = true;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);
            // 
            // cmbAdministrators
            // 
            this.cmbAdministrators.FormattingEnabled = true;
            this.cmbAdministrators.ItemHeight = 24;
            this.cmbAdministrators.Location = new System.Drawing.Point(451, 528);
            this.cmbAdministrators.Name = "cmbAdministrators";
            this.cmbAdministrators.Size = new System.Drawing.Size(320, 30);
            this.cmbAdministrators.TabIndex = 7;
            this.cmbAdministrators.UseSelectable = true;
            this.cmbAdministrators.SelectedIndexChanged += new System.EventHandler(this.cmbAdministrators_SelectedIndexChanged);
            // 
            // lblAdministrator
            // 
            this.lblAdministrator.AutoSize = true;
            this.lblAdministrator.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAdministrator.Location = new System.Drawing.Point(306, 533);
            this.lblAdministrator.Name = "lblAdministrator";
            this.lblAdministrator.Size = new System.Drawing.Size(94, 25);
            this.lblAdministrator.TabIndex = 8;
            this.lblAdministrator.Text = "Продавец:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCustomer.Location = new System.Drawing.Point(306, 435);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(106, 25);
            this.lblCustomer.TabIndex = 9;
            this.lblCustomer.Text = "Покупатель:";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProduct.Location = new System.Drawing.Point(306, 483);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(134, 25);
            this.lblProduct.TabIndex = 10;
            this.lblProduct.Text = "Наименование:";
            // 
            // btnSaveToPDF
            // 
            this.btnSaveToPDF.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSaveToPDF.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnSaveToPDF.Location = new System.Drawing.Point(451, 597);
            this.btnSaveToPDF.Name = "btnSaveToPDF";
            this.btnSaveToPDF.Size = new System.Drawing.Size(150, 30);
            this.btnSaveToPDF.TabIndex = 11;
            this.btnSaveToPDF.Text = "Сохранить в PDF";
            this.btnSaveToPDF.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSaveToPDF.UseSelectable = true;
            this.btnSaveToPDF.Click += new System.EventHandler(this.btnSaveToPDF_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDelete.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDelete.Location = new System.Drawing.Point(621, 597);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 30);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // CreateRecipe
            // 
            this.ClientSize = new System.Drawing.Size(799, 662);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveToPDF);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblAdministrator);
            this.Controls.Add(this.cmbAdministrators);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.cmbCustomers);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblGrandTotal);
            this.Name = "CreateRecipe";
            this.Text = "Создание чека";
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
