using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using MetroFramework.Components;

namespace FMS_PNP
{
    partial class Transactions
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DateTimePicker dateTimePickerTransactionDate;
        private System.Windows.Forms.ComboBox cmbFullNameClient;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbFullNameAdm;
        private System.Windows.Forms.CheckBox chkReturnOfGoods;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Button btnEditTransaction;
        private System.Windows.Forms.Button btnSaveTransaction;
        private System.Windows.Forms.Button btnDeleteTransaction;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnResetSearch;

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
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.dateTimePickerTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.cmbFullNameClient = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbFullNameAdm = new System.Windows.Forms.ComboBox();
            this.chkReturnOfGoods = new System.Windows.Forms.CheckBox();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnEditTransaction = new System.Windows.Forms.Button();
            this.btnSaveTransaction = new System.Windows.Forms.Button();
            this.btnDeleteTransaction = new System.Windows.Forms.Button();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnResetSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(261, 27);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.Size = new System.Drawing.Size(877, 444);
            this.dgvTransactions.TabIndex = 0;
            // 
            // dateTimePickerTransactionDate
            // 
            this.dateTimePickerTransactionDate.CalendarMonthBackground = System.Drawing.Color.PaleGreen;
            this.dateTimePickerTransactionDate.CalendarTitleBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dateTimePickerTransactionDate.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTransactionDate.Location = new System.Drawing.Point(12, 63);
            this.dateTimePickerTransactionDate.Name = "dateTimePickerTransactionDate";
            this.dateTimePickerTransactionDate.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerTransactionDate.TabIndex = 1;
            // 
            // cmbFullNameClient
            // 
            this.cmbFullNameClient.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbFullNameClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFullNameClient.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFullNameClient.Location = new System.Drawing.Point(12, 172);
            this.cmbFullNameClient.Name = "cmbFullNameClient";
            this.cmbFullNameClient.Size = new System.Drawing.Size(200, 28);
            this.cmbFullNameClient.TabIndex = 2;
            this.cmbFullNameClient.Text = "ФИО Клиента";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCategory.Location = new System.Drawing.Point(12, 228);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 28);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.Text = "Категория";
            // 
            // cmbProductName
            // 
            this.cmbProductName.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbProductName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProductName.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbProductName.Location = new System.Drawing.Point(12, 282);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(200, 28);
            this.cmbProductName.TabIndex = 4;
            this.cmbProductName.Text = "Наименование Товара";
            this.cmbProductName.SelectedIndexChanged += new System.EventHandler(this.cmbProductName_SelectedIndexChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.Menu;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQuantity.Location = new System.Drawing.Point(12, 341);
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 26);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.Tag = "Количество";
            this.txtQuantity.Text = "Количество";
            this.txtQuantity.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtQuantity.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPrice.Location = new System.Drawing.Point(12, 394);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 26);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.Tag = "Цена";
            this.txtPrice.Text = "Цена";
            this.txtPrice.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtPrice.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // cmbFullNameAdm
            // 
            this.cmbFullNameAdm.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbFullNameAdm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFullNameAdm.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFullNameAdm.Location = new System.Drawing.Point(12, 443);
            this.cmbFullNameAdm.Name = "cmbFullNameAdm";
            this.cmbFullNameAdm.Size = new System.Drawing.Size(200, 28);
            this.cmbFullNameAdm.TabIndex = 7;
            this.cmbFullNameAdm.Text = "ФИО Администратора";
            // 
            // chkReturnOfGoods
            // 
            this.chkReturnOfGoods.AutoSize = true;
            this.chkReturnOfGoods.Location = new System.Drawing.Point(946, 513);
            this.chkReturnOfGoods.Name = "chkReturnOfGoods";
            this.chkReturnOfGoods.Size = new System.Drawing.Size(135, 20);
            this.chkReturnOfGoods.TabIndex = 8;
            this.chkReturnOfGoods.Text = "Возврат товара";
            this.chkReturnOfGoods.UseVisualStyleBackColor = true;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.BackColor = System.Drawing.Color.Black;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddTransaction.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddTransaction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddTransaction.Location = new System.Drawing.Point(12, 505);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(122, 33);
            this.btnAddTransaction.TabIndex = 9;
            this.btnAddTransaction.Text = "Добавить";
            this.btnAddTransaction.UseVisualStyleBackColor = false;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // btnEditTransaction
            // 
            this.btnEditTransaction.BackColor = System.Drawing.Color.Black;
            this.btnEditTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditTransaction.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditTransaction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditTransaction.Location = new System.Drawing.Point(261, 505);
            this.btnEditTransaction.Name = "btnEditTransaction";
            this.btnEditTransaction.Size = new System.Drawing.Size(122, 33);
            this.btnEditTransaction.TabIndex = 10;
            this.btnEditTransaction.Text = "Редактировать";
            this.btnEditTransaction.UseVisualStyleBackColor = false;
            this.btnEditTransaction.Click += new System.EventHandler(this.btnEditTransaction_Click);
            // 
            // btnSaveTransaction
            // 
            this.btnSaveTransaction.BackColor = System.Drawing.Color.Black;
            this.btnSaveTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveTransaction.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveTransaction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveTransaction.Location = new System.Drawing.Point(401, 505);
            this.btnSaveTransaction.Name = "btnSaveTransaction";
            this.btnSaveTransaction.Size = new System.Drawing.Size(122, 33);
            this.btnSaveTransaction.TabIndex = 11;
            this.btnSaveTransaction.Text = "Сохранить";
            this.btnSaveTransaction.UseVisualStyleBackColor = false;
            this.btnSaveTransaction.Click += new System.EventHandler(this.btnSaveTransaction_Click);
            // 
            // btnDeleteTransaction
            // 
            this.btnDeleteTransaction.BackColor = System.Drawing.Color.Black;
            this.btnDeleteTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteTransaction.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteTransaction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteTransaction.Location = new System.Drawing.Point(538, 505);
            this.btnDeleteTransaction.Name = "btnDeleteTransaction";
            this.btnDeleteTransaction.Size = new System.Drawing.Size(122, 33);
            this.btnDeleteTransaction.TabIndex = 12;
            this.btnDeleteTransaction.Text = "Удалить";
            this.btnDeleteTransaction.UseVisualStyleBackColor = false;
            this.btnDeleteTransaction.Click += new System.EventHandler(this.btnDeleteTransaction_Click);
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGrandTotal.Location = new System.Drawing.Point(808, 474);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(330, 27);
            this.lblGrandTotal.TabIndex = 0;
            this.lblGrandTotal.Text = "Итоговая сумма: 0";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(675, 505);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 33);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CalendarMonthBackground = System.Drawing.Color.PaleGreen;
            this.dateTimePickerEndDate.CalendarTitleBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dateTimePickerEndDate.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(12, 120);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerEndDate.TabIndex = 14;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEndDate.Location = new System.Drawing.Point(12, 97);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(35, 20);
            this.lblEndDate.TabIndex = 15;
            this.lblEndDate.Text = "До:";
            // 
            // btnResetSearch
            // 
            this.btnResetSearch.BackColor = System.Drawing.Color.Black;
            this.btnResetSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetSearch.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResetSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResetSearch.Location = new System.Drawing.Point(813, 505);
            this.btnResetSearch.Name = "btnResetSearch";
            this.btnResetSearch.Size = new System.Drawing.Size(122, 33);
            this.btnResetSearch.TabIndex = 19;
            this.btnResetSearch.Text = "Сбросить";
            this.btnResetSearch.UseVisualStyleBackColor = false;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);
            // 
            // Transactions
            // 
            this.ClientSize = new System.Drawing.Size(1181, 561);
            this.Controls.Add(this.btnResetSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.dateTimePickerTransactionDate);
            this.Controls.Add(this.cmbFullNameClient);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbProductName);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cmbFullNameAdm);
            this.Controls.Add(this.chkReturnOfGoods);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.btnEditTransaction);
            this.Controls.Add(this.btnSaveTransaction);
            this.Controls.Add(this.btnDeleteTransaction);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Name = "Transactions";
            this.Text = "Транзакции";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null && txt.Text == txt.Tag.ToString())
            {
                txt.Text = "";
                txt.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void AddPlaceholderText(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private Button btnSearch;
    }
}
