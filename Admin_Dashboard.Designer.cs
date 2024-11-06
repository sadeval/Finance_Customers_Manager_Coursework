using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using MetroFramework.Components;
using LiveCharts;
using System.Globalization;

namespace FMS_PNP
{
    partial class Admin_Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        // Объявляем контролы
        private GroupBox optPanel_grpBox;
        private GroupBox finance_groupBox;
        private GroupBox customerGroupBox;
        private GroupBox statics;
        private Button btnAddCustomer;
        private Button btnGenerateReceipt;
        private Button btnDisplayPurchasingGraph;
        private GroupBox grpSalary;
        private GroupBox grpBoxGraf;
        private Button prod;
        private TextBox txtCustomerName;
        private TextBox txtCustomerMobile;
        private TextBox txtCustomerEmail;
        private TextBox txtCustomerAddress;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Label lblTotalSpent;
        private Button btnCurrencyConverter;
        private Panel currencyConverterPanel;
        private TextBox txtAmount;
        private ComboBox cmbFromCurrency;
        private ComboBox cmbToCurrency;
        private TextBox txtConvertedAmount;
        private Button btnConvert;

        private Panel panel1;
        private Button btnTransactions;
        private Button btnProfileClient;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label FullName;
        private Button AddCustom;
        private Label Adress;
        private Label Email;
        private Label PhoneNum;

        private GroupBox AddProductsGrpBox;
        private TextBox txtCategory;
        private TextBox txtProductName;
        private TextBox txtTextile;
        private TextBox txtSeason;
        private TextBox txtColor;
        private TextBox txtSize;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private Button btnAddProduct;
        private Label lblCategory;
        private Label lblProductName;
        private Label lblTextile;
        private Label lblSeason;
        private Label lblColor;
        private Label lblSize;
        private Label lblQuantity;
        private Label lblPrice;

        private MetroFramework.Controls.MetroToggle statistic_controler;
        private MetroStyleManager metroStyleManager1;
        private DataGridView dgvProducts;
        private Button btnDeleteProduct;
        private Button btnEditProduct;
        private Button btnSaveProduct;
        private DataGridView dgvCustomers;
        private Button btnDeleteCustomer;
        private Button btnEditCustomer;
        private Button btnSaveCustomer;
        private DataGridView dgvOfficialRates;
        private Button btnSearchProd;
        private MetroFramework.Controls.MetroLabel lblRemain;
        private MetroFramework.Controls.MetroLabel lblBillGrn;
        private ComboBox cmbNameProd1;
        private ComboBox cmbCategory1;
        private LiveCharts.WinForms.CartesianChart cartesianChartProd;
        private ComboBox cmbAdm;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblFrom;
        private ComboBox cmbProfileCustomer;

        private Label lblPhoneNumber;
        private Label lblEmail;
        private Label lblAddress;
        private System.Windows.Forms.Button btnLoadChart;



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
            this.components = new System.ComponentModel.Container();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.optPanel_grpBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.statistic_controler = new MetroFramework.Controls.MetroToggle();
            this.btnProfileClient = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnCurrencyConverter = new System.Windows.Forms.Button();
            this.prod = new System.Windows.Forms.Button();
            this.btnGenerateReceipt = new System.Windows.Forms.Button();
            this.btnDisplayPurchasingGraph = new System.Windows.Forms.Button();
            this.AddProductsGrpBox = new System.Windows.Forms.GroupBox();
            this.btnSearchProd = new System.Windows.Forms.Button();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblTextile = new System.Windows.Forms.Label();
            this.txtTextile = new System.Windows.Forms.TextBox();
            this.lblSeason = new System.Windows.Forms.Label();
            this.txtSeason = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.finance_groupBox = new System.Windows.Forms.GroupBox();
            this.currencyConverterPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFromCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbToCurrency = new System.Windows.Forms.ComboBox();
            this.txtConvertedAmount = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.dgvOfficialRates = new System.Windows.Forms.DataGridView();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerMobile = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.customerGroupBox = new System.Windows.Forms.GroupBox();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnSaveCustomer = new System.Windows.Forms.Button();
            this.Adress = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.PhoneNum = new System.Windows.Forms.Label();
            this.FullName = new System.Windows.Forms.Label();
            this.AddCustom = new System.Windows.Forms.Button();
            this.statics = new System.Windows.Forms.GroupBox();
            this.btnLoadChartStat = new System.Windows.Forms.Button();
            this.lblAdmQuan = new MetroFramework.Controls.MetroLabel();
            this.lblAdm = new MetroFramework.Controls.MetroLabel();
            this.lblLidAdm = new MetroFramework.Controls.MetroLabel();
            this.lblCustQuan = new MetroFramework.Controls.MetroLabel();
            this.lblClient = new MetroFramework.Controls.MetroLabel();
            this.lblLiderCustom = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblFrom = new MetroFramework.Controls.MetroLabel();
            this.cmbNameProd1 = new System.Windows.Forms.ComboBox();
            this.cmbCategory1 = new System.Windows.Forms.ComboBox();
            this.lblBillGrn = new MetroFramework.Controls.MetroLabel();
            this.lblRemain = new MetroFramework.Controls.MetroLabel();
            this.grpBoxGraf = new System.Windows.Forms.GroupBox();
            this.cartesianChartProd = new LiveCharts.WinForms.CartesianChart();
            this.grpSalary = new System.Windows.Forms.GroupBox();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.txtOklad = new System.Windows.Forms.TextBox();
            this.lblAdmSalary = new MetroFramework.Controls.MetroLabel();
            this.lblSold = new MetroFramework.Controls.MetroLabel();
            this.lblPercent = new MetroFramework.Controls.MetroLabel();
            this.lblOklad = new MetroFramework.Controls.MetroLabel();
            this.cmbAdm = new System.Windows.Forms.ComboBox();
            this.lblTotalSpent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpBoxProfile = new System.Windows.Forms.GroupBox();
            this.btnLoadChart = new System.Windows.Forms.Button();
            this.dgvCustomerTransactions = new System.Windows.Forms.DataGridView();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.lblDateStrt = new System.Windows.Forms.Label();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.dateTimeEnd = new MetroFramework.Controls.MetroDateTime();
            this.dateTimeStart = new MetroFramework.Controls.MetroDateTime();
            this.cmbProfileCustomer = new System.Windows.Forms.ComboBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.optPanel_grpBox.SuspendLayout();
            this.AddProductsGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.finance_groupBox.SuspendLayout();
            this.currencyConverterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficialRates)).BeginInit();
            this.customerGroupBox.SuspendLayout();
            this.statics.SuspendLayout();
            this.grpBoxGraf.SuspendLayout();
            this.grpSalary.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpBoxProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(358, 44);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(662, 367);
            this.dgvCustomers.TabIndex = 0;
            // 
            // optPanel_grpBox
            // 
            this.optPanel_grpBox.BackColor = System.Drawing.Color.Black;
            this.optPanel_grpBox.Controls.Add(this.textBox1);
            this.optPanel_grpBox.Controls.Add(this.btnTransactions);
            this.optPanel_grpBox.Controls.Add(this.statistic_controler);
            this.optPanel_grpBox.Controls.Add(this.btnProfileClient);
            this.optPanel_grpBox.Controls.Add(this.btnAddCustomer);
            this.optPanel_grpBox.Controls.Add(this.btnCurrencyConverter);
            this.optPanel_grpBox.Controls.Add(this.prod);
            this.optPanel_grpBox.Controls.Add(this.btnGenerateReceipt);
            this.optPanel_grpBox.Controls.Add(this.btnDisplayPurchasingGraph);
            this.optPanel_grpBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.optPanel_grpBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.optPanel_grpBox.Location = new System.Drawing.Point(34, 79);
            this.optPanel_grpBox.Name = "optPanel_grpBox";
            this.optPanel_grpBox.Size = new System.Drawing.Size(381, 554);
            this.optPanel_grpBox.TabIndex = 0;
            this.optPanel_grpBox.TabStop = false;
            this.optPanel_grpBox.Text = "Панель опций";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(77, 508);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 27);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Спрятать статистику";
            // 
            // btnTransactions
            // 
            this.btnTransactions.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTransactions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTransactions.Location = new System.Drawing.Point(42, 411);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(294, 91);
            this.btnTransactions.TabIndex = 6;
            this.btnTransactions.Text = "Транзакции";
            this.btnTransactions.UseVisualStyleBackColor = false;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // statistic_controler
            // 
            this.statistic_controler.AutoSize = true;
            this.statistic_controler.BackColor = System.Drawing.Color.Black;
            this.statistic_controler.Location = new System.Drawing.Point(256, 508);
            this.statistic_controler.Name = "statistic_controler";
            this.statistic_controler.Size = new System.Drawing.Size(80, 27);
            this.statistic_controler.TabIndex = 9;
            this.statistic_controler.Text = "Off";
            this.statistic_controler.UseSelectable = true;
            this.statistic_controler.CheckedChanged += new System.EventHandler(this.statastic_controler_CheckedChanged);
            // 
            // btnProfileClient
            // 
            this.btnProfileClient.BackColor = System.Drawing.Color.DarkOrange;
            this.btnProfileClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProfileClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProfileClient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProfileClient.Location = new System.Drawing.Point(42, 320);
            this.btnProfileClient.Name = "btnProfileClient";
            this.btnProfileClient.Size = new System.Drawing.Size(294, 91);
            this.btnProfileClient.TabIndex = 5;
            this.btnProfileClient.Text = "Профиль клиента";
            this.btnProfileClient.UseVisualStyleBackColor = false;
            this.btnProfileClient.Click += new System.EventHandler(this.btnProfileClient_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddCustomer.Location = new System.Drawing.Point(42, 45);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(294, 97);
            this.btnAddCustomer.TabIndex = 7;
            this.btnAddCustomer.Text = "Добавить клиента";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnCurrencyConverter
            // 
            this.btnCurrencyConverter.BackColor = System.Drawing.Color.DarkBlue;
            this.btnCurrencyConverter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCurrencyConverter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCurrencyConverter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCurrencyConverter.Location = new System.Drawing.Point(42, 141);
            this.btnCurrencyConverter.Name = "btnCurrencyConverter";
            this.btnCurrencyConverter.Size = new System.Drawing.Size(91, 91);
            this.btnCurrencyConverter.TabIndex = 0;
            this.btnCurrencyConverter.Text = "Валюта";
            this.btnCurrencyConverter.UseVisualStyleBackColor = false;
            this.btnCurrencyConverter.Click += new System.EventHandler(this.btnCurrencyConverter_Click);
            // 
            // prod
            // 
            this.prod.BackColor = System.Drawing.Color.CornflowerBlue;
            this.prod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prod.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prod.Location = new System.Drawing.Point(130, 141);
            this.prod.Name = "prod";
            this.prod.Size = new System.Drawing.Size(206, 91);
            this.prod.TabIndex = 4;
            this.prod.Text = "Товар";
            this.prod.UseVisualStyleBackColor = false;
            this.prod.Click += new System.EventHandler(this.Add_Prod_Click);
            // 
            // btnGenerateReceipt
            // 
            this.btnGenerateReceipt.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnGenerateReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateReceipt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerateReceipt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateReceipt.Location = new System.Drawing.Point(42, 230);
            this.btnGenerateReceipt.Name = "btnGenerateReceipt";
            this.btnGenerateReceipt.Size = new System.Drawing.Size(144, 91);
            this.btnGenerateReceipt.TabIndex = 0;
            this.btnGenerateReceipt.Text = "Создать чек";
            this.btnGenerateReceipt.UseVisualStyleBackColor = false;
            this.btnGenerateReceipt.Click += new System.EventHandler(this.btnGenerateReceipt_Click);
            // 
            // btnDisplayPurchasingGraph
            // 
            this.btnDisplayPurchasingGraph.BackColor = System.Drawing.Color.Teal;
            this.btnDisplayPurchasingGraph.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisplayPurchasingGraph.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDisplayPurchasingGraph.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDisplayPurchasingGraph.Location = new System.Drawing.Point(185, 230);
            this.btnDisplayPurchasingGraph.Name = "btnDisplayPurchasingGraph";
            this.btnDisplayPurchasingGraph.Size = new System.Drawing.Size(151, 91);
            this.btnDisplayPurchasingGraph.TabIndex = 3;
            this.btnDisplayPurchasingGraph.Text = "Показать график";
            this.btnDisplayPurchasingGraph.UseVisualStyleBackColor = false;
            this.btnDisplayPurchasingGraph.Click += new System.EventHandler(this.btnDisplayPurchasingGraph_Click);
            // 
            // AddProductsGrpBox
            // 
            this.AddProductsGrpBox.BackColor = System.Drawing.Color.White;
            this.AddProductsGrpBox.Controls.Add(this.btnSearchProd);
            this.AddProductsGrpBox.Controls.Add(this.btnSaveProduct);
            this.AddProductsGrpBox.Controls.Add(this.btnDeleteProduct);
            this.AddProductsGrpBox.Controls.Add(this.btnEditProduct);
            this.AddProductsGrpBox.Controls.Add(this.dgvProducts);
            this.AddProductsGrpBox.Controls.Add(this.lblCategory);
            this.AddProductsGrpBox.Controls.Add(this.txtCategory);
            this.AddProductsGrpBox.Controls.Add(this.lblProductName);
            this.AddProductsGrpBox.Controls.Add(this.txtProductName);
            this.AddProductsGrpBox.Controls.Add(this.lblTextile);
            this.AddProductsGrpBox.Controls.Add(this.txtTextile);
            this.AddProductsGrpBox.Controls.Add(this.lblSeason);
            this.AddProductsGrpBox.Controls.Add(this.txtSeason);
            this.AddProductsGrpBox.Controls.Add(this.lblColor);
            this.AddProductsGrpBox.Controls.Add(this.txtColor);
            this.AddProductsGrpBox.Controls.Add(this.lblSize);
            this.AddProductsGrpBox.Controls.Add(this.txtSize);
            this.AddProductsGrpBox.Controls.Add(this.lblQuantity);
            this.AddProductsGrpBox.Controls.Add(this.txtQuantity);
            this.AddProductsGrpBox.Controls.Add(this.lblPrice);
            this.AddProductsGrpBox.Controls.Add(this.txtPrice);
            this.AddProductsGrpBox.Controls.Add(this.btnAddProduct);
            this.AddProductsGrpBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddProductsGrpBox.Location = new System.Drawing.Point(18, 23);
            this.AddProductsGrpBox.Name = "AddProductsGrpBox";
            this.AddProductsGrpBox.Size = new System.Drawing.Size(1033, 491);
            this.AddProductsGrpBox.TabIndex = 2;
            this.AddProductsGrpBox.TabStop = false;
            this.AddProductsGrpBox.Text = "Товары";
            // 
            // btnSearchProd
            // 
            this.btnSearchProd.BackColor = System.Drawing.Color.Black;
            this.btnSearchProd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchProd.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearchProd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchProd.Location = new System.Drawing.Point(393, 427);
            this.btnSearchProd.Name = "btnSearchProd";
            this.btnSearchProd.Size = new System.Drawing.Size(154, 43);
            this.btnSearchProd.TabIndex = 17;
            this.btnSearchProd.Text = "Поиск";
            this.btnSearchProd.UseVisualStyleBackColor = false;
            this.btnSearchProd.Click += new System.EventHandler(this.btnSearchProd_Click);
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.BackColor = System.Drawing.Color.Black;
            this.btnSaveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveProduct.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveProduct.Location = new System.Drawing.Point(871, 425);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(145, 43);
            this.btnSaveProduct.TabIndex = 0;
            this.btnSaveProduct.Text = "Сохранить";
            this.btnSaveProduct.UseVisualStyleBackColor = false;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackColor = System.Drawing.Color.Black;
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteProduct.Location = new System.Drawing.Point(553, 427);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(157, 43);
            this.btnDeleteProduct.TabIndex = 0;
            this.btnDeleteProduct.Text = "Удалить";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.BackColor = System.Drawing.Color.Black;
            this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditProduct.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditProduct.Location = new System.Drawing.Point(716, 426);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(149, 43);
            this.btnEditProduct.TabIndex = 1;
            this.btnEditProduct.Text = "Редактировать";
            this.btnEditProduct.UseVisualStyleBackColor = false;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeight = 29;
            this.dgvProducts.Location = new System.Drawing.Point(394, 44);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(622, 356);
            this.dgvProducts.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCategory.Location = new System.Drawing.Point(19, 57);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(95, 25);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Категория:";
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCategory.Location = new System.Drawing.Point(158, 47);
            this.txtCategory.Multiline = true;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(214, 35);
            this.txtCategory.TabIndex = 1;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProductName.Location = new System.Drawing.Point(19, 104);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(134, 25);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Наименование:";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtProductName.Location = new System.Drawing.Point(158, 94);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(214, 35);
            this.txtProductName.TabIndex = 3;
            // 
            // lblTextile
            // 
            this.lblTextile.AutoSize = true;
            this.lblTextile.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTextile.Location = new System.Drawing.Point(19, 150);
            this.lblTextile.Name = "lblTextile";
            this.lblTextile.Size = new System.Drawing.Size(60, 25);
            this.lblTextile.TabIndex = 4;
            this.lblTextile.Text = "Ткань:";
            // 
            // txtTextile
            // 
            this.txtTextile.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTextile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTextile.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTextile.Location = new System.Drawing.Point(158, 140);
            this.txtTextile.Multiline = true;
            this.txtTextile.Name = "txtTextile";
            this.txtTextile.Size = new System.Drawing.Size(214, 35);
            this.txtTextile.TabIndex = 5;
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSeason.Location = new System.Drawing.Point(19, 194);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(64, 25);
            this.lblSeason.TabIndex = 6;
            this.lblSeason.Text = "Сезон:";
            // 
            // txtSeason
            // 
            this.txtSeason.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSeason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSeason.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSeason.Location = new System.Drawing.Point(158, 184);
            this.txtSeason.Multiline = true;
            this.txtSeason.Name = "txtSeason";
            this.txtSeason.Size = new System.Drawing.Size(214, 35);
            this.txtSeason.TabIndex = 7;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblColor.Location = new System.Drawing.Point(19, 241);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(54, 25);
            this.lblColor.TabIndex = 8;
            this.lblColor.Text = "Цвет:";
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.SystemColors.Menu;
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtColor.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtColor.Location = new System.Drawing.Point(158, 230);
            this.txtColor.Multiline = true;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(214, 35);
            this.txtColor.TabIndex = 9;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSize.Location = new System.Drawing.Point(19, 284);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(73, 25);
            this.lblSize.TabIndex = 10;
            this.lblSize.Text = "Размер:";
            // 
            // txtSize
            // 
            this.txtSize.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSize.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSize.Location = new System.Drawing.Point(158, 274);
            this.txtSize.Multiline = true;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(214, 35);
            this.txtSize.TabIndex = 11;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuantity.Location = new System.Drawing.Point(19, 329);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(106, 25);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Количество:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.Menu;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQuantity.Location = new System.Drawing.Point(158, 319);
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(214, 35);
            this.txtQuantity.TabIndex = 13;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(19, 378);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(57, 25);
            this.lblPrice.TabIndex = 14;
            this.lblPrice.Text = "Цена:";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPrice.Location = new System.Drawing.Point(158, 365);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(214, 35);
            this.txtPrice.TabIndex = 15;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.Black;
            this.btnAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddProduct.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddProduct.Location = new System.Drawing.Point(24, 427);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(147, 43);
            this.btnAddProduct.TabIndex = 16;
            this.btnAddProduct.Text = "Добавить";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // finance_groupBox
            // 
            this.finance_groupBox.BackColor = System.Drawing.Color.White;
            this.finance_groupBox.Controls.Add(this.currencyConverterPanel);
            this.finance_groupBox.Controls.Add(this.dgvOfficialRates);
            this.finance_groupBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finance_groupBox.Location = new System.Drawing.Point(18, 23);
            this.finance_groupBox.Name = "finance_groupBox";
            this.finance_groupBox.Size = new System.Drawing.Size(1033, 491);
            this.finance_groupBox.TabIndex = 9;
            this.finance_groupBox.TabStop = false;
            this.finance_groupBox.Text = "Валюта";
            // 
            // currencyConverterPanel
            // 
            this.currencyConverterPanel.BackColor = System.Drawing.Color.White;
            this.currencyConverterPanel.Controls.Add(this.label3);
            this.currencyConverterPanel.Controls.Add(this.cmbFromCurrency);
            this.currencyConverterPanel.Controls.Add(this.label2);
            this.currencyConverterPanel.Controls.Add(this.label1);
            this.currencyConverterPanel.Controls.Add(this.txtAmount);
            this.currencyConverterPanel.Controls.Add(this.cmbToCurrency);
            this.currencyConverterPanel.Controls.Add(this.txtConvertedAmount);
            this.currencyConverterPanel.Controls.Add(this.btnConvert);
            this.currencyConverterPanel.Location = new System.Drawing.Point(729, 75);
            this.currencyConverterPanel.Name = "currencyConverterPanel";
            this.currencyConverterPanel.Size = new System.Drawing.Size(264, 325);
            this.currencyConverterPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(29, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Конвертер валют";
            // 
            // cmbFromCurrency
            // 
            this.cmbFromCurrency.Location = new System.Drawing.Point(32, 165);
            this.cmbFromCurrency.Name = "cmbFromCurrency";
            this.cmbFromCurrency.Size = new System.Drawing.Size(192, 31);
            this.cmbFromCurrency.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "to:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "From:";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Location = new System.Drawing.Point(33, 91);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(192, 46);
            this.txtAmount.TabIndex = 0;
            // 
            // cmbToCurrency
            // 
            this.cmbToCurrency.Location = new System.Drawing.Point(33, 60);
            this.cmbToCurrency.Name = "cmbToCurrency";
            this.cmbToCurrency.Size = new System.Drawing.Size(192, 31);
            this.cmbToCurrency.TabIndex = 2;
            // 
            // txtConvertedAmount
            // 
            this.txtConvertedAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtConvertedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConvertedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.txtConvertedAmount.Location = new System.Drawing.Point(33, 197);
            this.txtConvertedAmount.Multiline = true;
            this.txtConvertedAmount.Name = "txtConvertedAmount";
            this.txtConvertedAmount.ReadOnly = true;
            this.txtConvertedAmount.Size = new System.Drawing.Size(192, 46);
            this.txtConvertedAmount.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.Black;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConvert.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConvert.ForeColor = System.Drawing.Color.White;
            this.btnConvert.Location = new System.Drawing.Point(32, 258);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(192, 49);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Конвертировать";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // dgvOfficialRates
            // 
            this.dgvOfficialRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOfficialRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfficialRates.Location = new System.Drawing.Point(20, 34);
            this.dgvOfficialRates.Name = "dgvOfficialRates";
            this.dgvOfficialRates.ReadOnly = true;
            this.dgvOfficialRates.RowHeadersWidth = 51;
            this.dgvOfficialRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfficialRates.Size = new System.Drawing.Size(667, 434);
            this.dgvOfficialRates.TabIndex = 1;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerEnd.Location = new System.Drawing.Point(1239, 101);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerEnd.TabIndex = 1;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerStart.Location = new System.Drawing.Point(1239, 44);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerStart.TabIndex = 0;
            // 
            // txtCustomerMobile
            // 
            this.txtCustomerMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerMobile.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCustomerMobile.ForeColor = System.Drawing.Color.Gray;
            this.txtCustomerMobile.Location = new System.Drawing.Point(35, 173);
            this.txtCustomerMobile.Multiline = true;
            this.txtCustomerMobile.Name = "txtCustomerMobile";
            this.txtCustomerMobile.Size = new System.Drawing.Size(277, 37);
            this.txtCustomerMobile.TabIndex = 1;
            this.txtCustomerMobile.Tag = "380000000000";
            this.txtCustomerMobile.Text = "380000000000";
            this.txtCustomerMobile.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtCustomerMobile.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.Gray;
            this.txtCustomerName.Location = new System.Drawing.Point(35, 75);
            this.txtCustomerName.Multiline = true;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(277, 37);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.Tag = "Полное имя";
            this.txtCustomerName.Text = "Полное имя";
            this.txtCustomerName.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtCustomerName.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerEmail.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCustomerEmail.ForeColor = System.Drawing.Color.Gray;
            this.txtCustomerEmail.Location = new System.Drawing.Point(35, 271);
            this.txtCustomerEmail.Multiline = true;
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(277, 38);
            this.txtCustomerEmail.TabIndex = 2;
            this.txtCustomerEmail.Tag = "Email";
            this.txtCustomerEmail.Text = "Email";
            this.txtCustomerEmail.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtCustomerEmail.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerAddress.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCustomerAddress.ForeColor = System.Drawing.Color.Gray;
            this.txtCustomerAddress.Location = new System.Drawing.Point(35, 371);
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(277, 40);
            this.txtCustomerAddress.TabIndex = 3;
            this.txtCustomerAddress.Tag = "Адрес";
            this.txtCustomerAddress.Text = "Адрес";
            this.txtCustomerAddress.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtCustomerAddress.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // customerGroupBox
            // 
            this.customerGroupBox.BackColor = System.Drawing.Color.White;
            this.customerGroupBox.Controls.Add(this.dgvCustomers);
            this.customerGroupBox.Controls.Add(this.btnDeleteCustomer);
            this.customerGroupBox.Controls.Add(this.btnEditCustomer);
            this.customerGroupBox.Controls.Add(this.btnSaveCustomer);
            this.customerGroupBox.Controls.Add(this.Adress);
            this.customerGroupBox.Controls.Add(this.Email);
            this.customerGroupBox.Controls.Add(this.PhoneNum);
            this.customerGroupBox.Controls.Add(this.FullName);
            this.customerGroupBox.Controls.Add(this.AddCustom);
            this.customerGroupBox.Controls.Add(this.txtCustomerName);
            this.customerGroupBox.Controls.Add(this.txtCustomerAddress);
            this.customerGroupBox.Controls.Add(this.txtCustomerMobile);
            this.customerGroupBox.Controls.Add(this.txtCustomerEmail);
            this.customerGroupBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customerGroupBox.Location = new System.Drawing.Point(18, 23);
            this.customerGroupBox.Name = "customerGroupBox";
            this.customerGroupBox.Size = new System.Drawing.Size(1033, 491);
            this.customerGroupBox.TabIndex = 1;
            this.customerGroupBox.TabStop = false;
            this.customerGroupBox.Text = "Клиент";
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.BackColor = System.Drawing.Color.Black;
            this.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(449, 436);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(152, 32);
            this.btnDeleteCustomer.TabIndex = 0;
            this.btnDeleteCustomer.Text = "Удалить";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.BackColor = System.Drawing.Color.Black;
            this.btnEditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditCustomer.Location = new System.Drawing.Point(668, 436);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(142, 32);
            this.btnEditCustomer.TabIndex = 1;
            this.btnEditCustomer.Text = "Редактировать";
            this.btnEditCustomer.UseVisualStyleBackColor = false;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnSaveCustomer
            // 
            this.btnSaveCustomer.BackColor = System.Drawing.Color.Black;
            this.btnSaveCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveCustomer.Location = new System.Drawing.Point(873, 437);
            this.btnSaveCustomer.Name = "btnSaveCustomer";
            this.btnSaveCustomer.Size = new System.Drawing.Size(147, 32);
            this.btnSaveCustomer.TabIndex = 2;
            this.btnSaveCustomer.Text = "Сохранить";
            this.btnSaveCustomer.UseVisualStyleBackColor = false;
            this.btnSaveCustomer.Click += new System.EventHandler(this.btnSaveCustomer_Click);
            // 
            // Adress
            // 
            this.Adress.AutoSize = true;
            this.Adress.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Adress.Location = new System.Drawing.Point(30, 340);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(71, 28);
            this.Adress.TabIndex = 11;
            this.Adress.Text = "Адрес:";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Email.Location = new System.Drawing.Point(30, 240);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(61, 28);
            this.Email.TabIndex = 10;
            this.Email.Text = "Email:";
            // 
            // PhoneNum
            // 
            this.PhoneNum.AutoSize = true;
            this.PhoneNum.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneNum.Location = new System.Drawing.Point(30, 142);
            this.PhoneNum.Name = "PhoneNum";
            this.PhoneNum.Size = new System.Drawing.Size(163, 28);
            this.PhoneNum.TabIndex = 9;
            this.PhoneNum.Text = "Номер телефона:";
            // 
            // FullName
            // 
            this.FullName.AutoSize = true;
            this.FullName.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullName.Location = new System.Drawing.Point(30, 44);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(60, 28);
            this.FullName.TabIndex = 8;
            this.FullName.Tag = "ФИО";
            this.FullName.Text = "ФИО:";
            // 
            // AddCustom
            // 
            this.AddCustom.BackColor = System.Drawing.Color.Black;
            this.AddCustom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddCustom.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddCustom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddCustom.Location = new System.Drawing.Point(163, 436);
            this.AddCustom.Name = "AddCustom";
            this.AddCustom.Size = new System.Drawing.Size(149, 32);
            this.AddCustom.TabIndex = 7;
            this.AddCustom.Text = "Добавить";
            this.AddCustom.UseVisualStyleBackColor = false;
            this.AddCustom.Click += new System.EventHandler(this.btnAddCustomerConfirm_Click);
            // 
            // statics
            // 
            this.statics.BackColor = System.Drawing.Color.White;
            this.statics.Controls.Add(this.btnLoadChartStat);
            this.statics.Controls.Add(this.lblAdmQuan);
            this.statics.Controls.Add(this.lblAdm);
            this.statics.Controls.Add(this.lblLidAdm);
            this.statics.Controls.Add(this.lblCustQuan);
            this.statics.Controls.Add(this.lblClient);
            this.statics.Controls.Add(this.lblLiderCustom);
            this.statics.Controls.Add(this.metroLabel2);
            this.statics.Controls.Add(this.lblFrom);
            this.statics.Controls.Add(this.cmbNameProd1);
            this.statics.Controls.Add(this.cmbCategory1);
            this.statics.Controls.Add(this.lblBillGrn);
            this.statics.Controls.Add(this.lblRemain);
            this.statics.Controls.Add(this.dateTimePickerStart);
            this.statics.Controls.Add(this.dateTimePickerEnd);
            this.statics.Controls.Add(this.grpBoxGraf);
            this.statics.Controls.Add(this.grpSalary);
            this.statics.ForeColor = System.Drawing.Color.Black;
            this.statics.Location = new System.Drawing.Point(34, 648);
            this.statics.Name = "statics";
            this.statics.Size = new System.Drawing.Size(1463, 197);
            this.statics.TabIndex = 2;
            this.statics.TabStop = false;
            this.statics.Text = "Статистика";
            // 
            // btnLoadChartStat
            // 
            this.btnLoadChartStat.BackColor = System.Drawing.Color.Black;
            this.btnLoadChartStat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadChartStat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoadChartStat.Location = new System.Drawing.Point(1239, 146);
            this.btnLoadChartStat.Name = "btnLoadChartStat";
            this.btnLoadChartStat.Size = new System.Drawing.Size(200, 32);
            this.btnLoadChartStat.TabIndex = 17;
            this.btnLoadChartStat.Text = "Загрузить график";
            this.btnLoadChartStat.UseVisualStyleBackColor = false;
            // 
            // lblAdmQuan
            // 
            this.lblAdmQuan.AutoSize = true;
            this.lblAdmQuan.Location = new System.Drawing.Point(653, 158);
            this.lblAdmQuan.Name = "lblAdmQuan";
            this.lblAdmQuan.Size = new System.Drawing.Size(69, 20);
            this.lblAdmQuan.TabIndex = 16;
            this.lblAdmQuan.Text = "NULL  шт";
            // 
            // lblAdm
            // 
            this.lblAdm.AutoSize = true;
            this.lblAdm.Location = new System.Drawing.Point(653, 131);
            this.lblAdm.Name = "lblAdm";
            this.lblAdm.Size = new System.Drawing.Size(45, 20);
            this.lblAdm.TabIndex = 15;
            this.lblAdm.Text = "ФИО:";
            // 
            // lblLidAdm
            // 
            this.lblLidAdm.AutoSize = true;
            this.lblLidAdm.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblLidAdm.Location = new System.Drawing.Point(653, 101);
            this.lblLidAdm.Name = "lblLidAdm";
            this.lblLidAdm.Size = new System.Drawing.Size(111, 20);
            this.lblLidAdm.TabIndex = 14;
            this.lblLidAdm.Text = "Лидер продаж";
            // 
            // lblCustQuan
            // 
            this.lblCustQuan.AutoSize = true;
            this.lblCustQuan.Location = new System.Drawing.Point(653, 67);
            this.lblCustQuan.Name = "lblCustQuan";
            this.lblCustQuan.Size = new System.Drawing.Size(69, 20);
            this.lblCustQuan.TabIndex = 13;
            this.lblCustQuan.Text = "NULL  шт";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(653, 43);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(45, 20);
            this.lblClient.TabIndex = 12;
            this.lblClient.Text = "ФИО:";
            // 
            // lblLiderCustom
            // 
            this.lblLiderCustom.AutoSize = true;
            this.lblLiderCustom.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblLiderCustom.Location = new System.Drawing.Point(653, 14);
            this.lblLiderCustom.Name = "lblLiderCustom";
            this.lblLiderCustom.Size = new System.Drawing.Size(114, 20);
            this.lblLiderCustom.TabIndex = 11;
            this.lblLiderCustom.Text = "Лидер покупок";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(1239, 74);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(32, 20);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "По:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblFrom.Location = new System.Drawing.Point(1239, 14);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(21, 20);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "С:";
            // 
            // cmbNameProd1
            // 
            this.cmbNameProd1.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbNameProd1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbNameProd1.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbNameProd1.FormattingEnabled = true;
            this.cmbNameProd1.Location = new System.Drawing.Point(23, 74);
            this.cmbNameProd1.Name = "cmbNameProd1";
            this.cmbNameProd1.Size = new System.Drawing.Size(226, 31);
            this.cmbNameProd1.TabIndex = 8;
            this.cmbNameProd1.Text = "Наименование";
            // 
            // cmbCategory1
            // 
            this.cmbCategory1.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbCategory1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCategory1.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCategory1.FormattingEnabled = true;
            this.cmbCategory1.Location = new System.Drawing.Point(23, 32);
            this.cmbCategory1.Name = "cmbCategory1";
            this.cmbCategory1.Size = new System.Drawing.Size(226, 31);
            this.cmbCategory1.TabIndex = 7;
            this.cmbCategory1.Text = "Категория";
            // 
            // lblBillGrn
            // 
            this.lblBillGrn.AutoSize = true;
            this.lblBillGrn.Location = new System.Drawing.Point(23, 156);
            this.lblBillGrn.Name = "lblBillGrn";
            this.lblBillGrn.Size = new System.Drawing.Size(102, 20);
            this.lblBillGrn.TabIndex = 6;
            this.lblBillGrn.Text = "На счету:   грн";
            // 
            // lblRemain
            // 
            this.lblRemain.AutoSize = true;
            this.lblRemain.Location = new System.Drawing.Point(23, 121);
            this.lblRemain.Name = "lblRemain";
            this.lblRemain.Size = new System.Drawing.Size(94, 20);
            this.lblRemain.TabIndex = 5;
            this.lblRemain.Text = "Остаток:   шт";
            // 
            // grpBoxGraf
            // 
            this.grpBoxGraf.BackColor = System.Drawing.Color.White;
            this.grpBoxGraf.Controls.Add(this.cartesianChartProd);
            this.grpBoxGraf.ForeColor = System.Drawing.Color.Black;
            this.grpBoxGraf.Location = new System.Drawing.Point(920, 14);
            this.grpBoxGraf.Name = "grpBoxGraf";
            this.grpBoxGraf.Size = new System.Drawing.Size(296, 177);
            this.grpBoxGraf.TabIndex = 1;
            this.grpBoxGraf.TabStop = false;
            this.grpBoxGraf.Text = "График продаж";
            // 
            // cartesianChartProd
            // 
            this.cartesianChartProd.Location = new System.Drawing.Point(6, 26);
            this.cartesianChartProd.Name = "cartesianChartProd";
            this.cartesianChartProd.Size = new System.Drawing.Size(275, 138);
            this.cartesianChartProd.TabIndex = 0;
            this.cartesianChartProd.Text = "cartesianChart1";
            // 
            // grpSalary
            // 
            this.grpSalary.BackColor = System.Drawing.Color.White;
            this.grpSalary.Controls.Add(this.txtPercent);
            this.grpSalary.Controls.Add(this.txtOklad);
            this.grpSalary.Controls.Add(this.lblAdmSalary);
            this.grpSalary.Controls.Add(this.lblSold);
            this.grpSalary.Controls.Add(this.lblPercent);
            this.grpSalary.Controls.Add(this.lblOklad);
            this.grpSalary.Controls.Add(this.cmbAdm);
            this.grpSalary.ForeColor = System.Drawing.Color.Black;
            this.grpSalary.Location = new System.Drawing.Point(269, 14);
            this.grpSalary.Name = "grpSalary";
            this.grpSalary.Size = new System.Drawing.Size(378, 177);
            this.grpSalary.TabIndex = 0;
            this.grpSalary.TabStop = false;
            this.grpSalary.Text = "Зарплата";
            // 
            // txtPercent
            // 
            this.txtPercent.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPercent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPercent.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPercent.Location = new System.Drawing.Point(93, 117);
            this.txtPercent.Multiline = true;
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(100, 27);
            this.txtPercent.TabIndex = 24;
            // 
            // txtOklad
            // 
            this.txtOklad.BackColor = System.Drawing.SystemColors.Menu;
            this.txtOklad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOklad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOklad.Location = new System.Drawing.Point(93, 67);
            this.txtOklad.Multiline = true;
            this.txtOklad.Name = "txtOklad";
            this.txtOklad.Size = new System.Drawing.Size(100, 27);
            this.txtOklad.TabIndex = 23;
            // 
            // lblAdmSalary
            // 
            this.lblAdmSalary.AutoSize = true;
            this.lblAdmSalary.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAdmSalary.Location = new System.Drawing.Point(199, 117);
            this.lblAdmSalary.Name = "lblAdmSalary";
            this.lblAdmSalary.Size = new System.Drawing.Size(76, 20);
            this.lblAdmSalary.TabIndex = 21;
            this.lblAdmSalary.Text = "ЗП:     грн";
            // 
            // lblSold
            // 
            this.lblSold.AutoSize = true;
            this.lblSold.Location = new System.Drawing.Point(199, 67);
            this.lblSold.Name = "lblSold";
            this.lblSold.Size = new System.Drawing.Size(98, 20);
            this.lblSold.TabIndex = 17;
            this.lblSold.Text = "Продано:   шт";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(13, 117);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(68, 20);
            this.lblPercent.TabIndex = 18;
            this.lblPercent.Text = "Процент:";
            // 
            // lblOklad
            // 
            this.lblOklad.AutoSize = true;
            this.lblOklad.Location = new System.Drawing.Point(14, 67);
            this.lblOklad.Name = "lblOklad";
            this.lblOklad.Size = new System.Drawing.Size(53, 20);
            this.lblOklad.TabIndex = 17;
            this.lblOklad.Text = "Оклад:";
            // 
            // cmbAdm
            // 
            this.cmbAdm.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbAdm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbAdm.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbAdm.FormattingEnabled = true;
            this.cmbAdm.Location = new System.Drawing.Point(13, 26);
            this.cmbAdm.Name = "cmbAdm";
            this.cmbAdm.Size = new System.Drawing.Size(346, 31);
            this.cmbAdm.TabIndex = 9;
            this.cmbAdm.Text = "Администратор";
            // 
            // lblTotalSpent
            // 
            this.lblTotalSpent.Location = new System.Drawing.Point(20, 300);
            this.lblTotalSpent.Name = "lblTotalSpent";
            this.lblTotalSpent.Size = new System.Drawing.Size(200, 23);
            this.lblTotalSpent.TabIndex = 1;
            this.lblTotalSpent.Text = "Сумма потраченная клиентом:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.grpBoxProfile);
            this.panel1.Controls.Add(this.AddProductsGrpBox);
            this.panel1.Controls.Add(this.finance_groupBox);
            this.panel1.Controls.Add(this.customerGroupBox);
            this.panel1.Location = new System.Drawing.Point(421, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 545);
            this.panel1.TabIndex = 1;
            // 
            // grpBoxProfile
            // 
            this.grpBoxProfile.BackColor = System.Drawing.Color.White;
            this.grpBoxProfile.Controls.Add(this.btnLoadChart);
            this.grpBoxProfile.Controls.Add(this.dgvCustomerTransactions);
            this.grpBoxProfile.Controls.Add(this.lblDateEnd);
            this.grpBoxProfile.Controls.Add(this.lblDateStrt);
            this.grpBoxProfile.Controls.Add(this.cartesianChart2);
            this.grpBoxProfile.Controls.Add(this.dateTimeEnd);
            this.grpBoxProfile.Controls.Add(this.dateTimeStart);
            this.grpBoxProfile.Controls.Add(this.cmbProfileCustomer);
            this.grpBoxProfile.Controls.Add(this.lblPhoneNumber);
            this.grpBoxProfile.Controls.Add(this.lblEmail);
            this.grpBoxProfile.Controls.Add(this.lblAddress);
            this.grpBoxProfile.ForeColor = System.Drawing.Color.Black;
            this.grpBoxProfile.Location = new System.Drawing.Point(18, 23);
            this.grpBoxProfile.Name = "grpBoxProfile";
            this.grpBoxProfile.Size = new System.Drawing.Size(1033, 491);
            this.grpBoxProfile.TabIndex = 10;
            this.grpBoxProfile.TabStop = false;
            this.grpBoxProfile.Text = "Профиль клиента";
            // 
            // btnLoadChart
            // 
            this.btnLoadChart.BackColor = System.Drawing.Color.Black;
            this.btnLoadChart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadChart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoadChart.Location = new System.Drawing.Point(30, 380);
            this.btnLoadChart.Name = "btnLoadChart";
            this.btnLoadChart.Size = new System.Drawing.Size(200, 40);
            this.btnLoadChart.TabIndex = 4;
            this.btnLoadChart.Text = "Загрузить график";
            this.btnLoadChart.UseVisualStyleBackColor = false;
            this.btnLoadChart.Click += new System.EventHandler(this.btnLoadChart_Click);
            // 
            // dgvCustomerTransactions
            // 
            this.dgvCustomerTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerTransactions.Location = new System.Drawing.Point(349, 21);
            this.dgvCustomerTransactions.Name = "dgvCustomerTransactions";
            this.dgvCustomerTransactions.ReadOnly = true;
            this.dgvCustomerTransactions.RowHeadersWidth = 51;
            this.dgvCustomerTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerTransactions.Size = new System.Drawing.Size(667, 203);
            this.dgvCustomerTransactions.TabIndex = 4;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.Location = new System.Drawing.Point(31, 298);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(35, 20);
            this.lblDateEnd.TabIndex = 8;
            this.lblDateEnd.Text = "До: ";
            // 
            // lblDateStrt
            // 
            this.lblDateStrt.AutoSize = true;
            this.lblDateStrt.Location = new System.Drawing.Point(31, 228);
            this.lblDateStrt.Name = "lblDateStrt";
            this.lblDateStrt.Size = new System.Drawing.Size(25, 20);
            this.lblDateStrt.TabIndex = 7;
            this.lblDateStrt.Text = "С: ";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Location = new System.Drawing.Point(349, 230);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(667, 248);
            this.cartesianChart2.TabIndex = 6;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(34, 318);
            this.dateTimeEnd.MinimumSize = new System.Drawing.Size(0, 30);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 30);
            this.dateTimeEnd.TabIndex = 5;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(34, 251);
            this.dateTimeStart.MinimumSize = new System.Drawing.Size(0, 30);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(200, 30);
            this.dateTimeStart.TabIndex = 4;
            // 
            // cmbProfileCustomer
            // 
            this.cmbProfileCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfileCustomer.FormattingEnabled = true;
            this.cmbProfileCustomer.Location = new System.Drawing.Point(30, 50);
            this.cmbProfileCustomer.Name = "cmbProfileCustomer";
            this.cmbProfileCustomer.Size = new System.Drawing.Size(300, 28);
            this.cmbProfileCustomer.TabIndex = 0;
            this.cmbProfileCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbProfileCustomer_SelectedIndexChanged);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(30, 100);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(134, 20);
            this.lblPhoneNumber.TabIndex = 1;
            this.lblPhoneNumber.Text = "Номер телефона: ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 140);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email: ";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(30, 180);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 20);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Адрес: ";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // Admin_Dashboard
            // 
            this.ClientSize = new System.Drawing.Size(1531, 879);
            this.Controls.Add(this.statics);
            this.Controls.Add(this.optPanel_grpBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Admin_Dashboard";
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "Панель Администратора";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Admin_Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.optPanel_grpBox.ResumeLayout(false);
            this.optPanel_grpBox.PerformLayout();
            this.AddProductsGrpBox.ResumeLayout(false);
            this.AddProductsGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.finance_groupBox.ResumeLayout(false);
            this.currencyConverterPanel.ResumeLayout(false);
            this.currencyConverterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficialRates)).EndInit();
            this.customerGroupBox.ResumeLayout(false);
            this.customerGroupBox.PerformLayout();
            this.statics.ResumeLayout(false);
            this.statics.PerformLayout();
            this.grpBoxGraf.ResumeLayout(false);
            this.grpSalary.ResumeLayout(false);
            this.grpSalary.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grpBoxProfile.ResumeLayout(false);
            this.grpBoxProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

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

        private GroupBox grpBoxProfile;
        private MetroFramework.Controls.MetroDateTime dateTimeStart;
        private MetroFramework.Controls.MetroDateTime dateTimeEnd;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private Label lblDateEnd;
        private Label lblDateStrt;
        private DataGridView dgvCustomerTransactions;
        private MetroFramework.Controls.MetroLabel lblClient;
        private MetroFramework.Controls.MetroLabel lblLiderCustom;
        private MetroFramework.Controls.MetroLabel lblLidAdm;
        private MetroFramework.Controls.MetroLabel lblAdmQuan;
        private MetroFramework.Controls.MetroLabel lblAdm;
        private MetroFramework.Controls.MetroLabel lblSold;
        private MetroFramework.Controls.MetroLabel lblPercent;
        private MetroFramework.Controls.MetroLabel lblOklad;
        private MetroFramework.Controls.MetroLabel lblAdmSalary;
        private TextBox txtPercent;
        private TextBox txtOklad;
        private TextBox textBox1;
        private MetroFramework.Controls.MetroLabel lblCustQuan;
        private Button btnLoadChartStat;
    }
}
