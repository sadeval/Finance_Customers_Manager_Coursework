using System;

namespace FMS_PNP
{
    partial class CreateAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private MetroFramework.Controls.MetroTextBox txtAdminName;
        private MetroFramework.Controls.MetroTextBox txtAdminLogin;
        private MetroFramework.Controls.MetroTextBox txtAdminPassword;
        private MetroFramework.Controls.MetroTextBox txtConfirmPassword;
        private MetroFramework.Controls.MetroButton btn_Create_Admin;

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
            this.txtAdminName = new MetroFramework.Controls.MetroTextBox();
            this.txtAdminLogin = new MetroFramework.Controls.MetroTextBox();
            this.txtAdminPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtConfirmPassword = new MetroFramework.Controls.MetroTextBox();
            this.btn_Create_Admin = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtAdminName
            // 
            this.txtAdminName.CustomButton.Image = null;
            this.txtAdminName.CustomButton.Location = new System.Drawing.Point(297, 1);
            this.txtAdminName.CustomButton.Name = "";
            this.txtAdminName.CustomButton.Size = new System.Drawing.Size(43, 43);
            this.txtAdminName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdminName.CustomButton.TabIndex = 1;
            this.txtAdminName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdminName.CustomButton.UseSelectable = true;
            this.txtAdminName.CustomButton.Visible = false;
            this.txtAdminName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAdminName.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.txtAdminName.Lines = new string[] { "Имя администратора" };
            this.txtAdminName.Location = new System.Drawing.Point(48, 92);
            this.txtAdminName.MaxLength = 32767;
            this.txtAdminName.Multiline = true;
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.PasswordChar = '\0';
            this.txtAdminName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdminName.SelectedText = "";
            this.txtAdminName.SelectionLength = 0;
            this.txtAdminName.SelectionStart = 0;
            this.txtAdminName.ShortcutsEnabled = true;
            this.txtAdminName.Size = new System.Drawing.Size(341, 45);
            this.txtAdminName.TabIndex = 0;
            this.txtAdminName.Tag = "Имя администратора";
            this.txtAdminName.Text = "Имя администратора";
            this.txtAdminName.UseSelectable = true;
            this.txtAdminName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdminName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtAdminName.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtAdminName.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // txtAdminLogin
            // 
            this.txtAdminLogin.CustomButton.Image = null;
            this.txtAdminLogin.CustomButton.Location = new System.Drawing.Point(297, 1);
            this.txtAdminLogin.CustomButton.Name = "";
            this.txtAdminLogin.CustomButton.Size = new System.Drawing.Size(43, 43);
            this.txtAdminLogin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdminLogin.CustomButton.TabIndex = 1;
            this.txtAdminLogin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdminLogin.CustomButton.UseSelectable = true;
            this.txtAdminLogin.CustomButton.Visible = false;
            this.txtAdminLogin.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAdminLogin.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.txtAdminLogin.Lines = new string[] { "Логин" };
            this.txtAdminLogin.Location = new System.Drawing.Point(48, 163);
            this.txtAdminLogin.MaxLength = 32767;
            this.txtAdminLogin.Multiline = true;
            this.txtAdminLogin.Name = "txtAdminLogin";
            this.txtAdminLogin.PasswordChar = '\0';
            this.txtAdminLogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdminLogin.SelectedText = "";
            this.txtAdminLogin.SelectionLength = 0;
            this.txtAdminLogin.SelectionStart = 0;
            this.txtAdminLogin.ShortcutsEnabled = true;
            this.txtAdminLogin.Size = new System.Drawing.Size(341, 45);
            this.txtAdminLogin.TabIndex = 1;
            this.txtAdminLogin.Tag = "Логин";
            this.txtAdminLogin.Text = "Логин";
            this.txtAdminLogin.UseSelectable = true;
            this.txtAdminLogin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdminLogin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtAdminLogin.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtAdminLogin.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.CustomButton.Image = null;
            this.txtAdminPassword.CustomButton.Location = new System.Drawing.Point(297, 1);
            this.txtAdminPassword.CustomButton.Name = "";
            this.txtAdminPassword.CustomButton.Size = new System.Drawing.Size(43, 43);
            this.txtAdminPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdminPassword.CustomButton.TabIndex = 1;
            this.txtAdminPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdminPassword.CustomButton.UseSelectable = true;
            this.txtAdminPassword.CustomButton.Visible = false;
            this.txtAdminPassword.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAdminPassword.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.txtAdminPassword.Lines = new string[] { "Пароль" };
            this.txtAdminPassword.Location = new System.Drawing.Point(48, 241);
            this.txtAdminPassword.MaxLength = 32767;
            this.txtAdminPassword.Multiline = true;
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.PasswordChar = '\0';
            this.txtAdminPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdminPassword.SelectedText = "";
            this.txtAdminPassword.SelectionLength = 0;
            this.txtAdminPassword.SelectionStart = 0;
            this.txtAdminPassword.ShortcutsEnabled = true;
            this.txtAdminPassword.Size = new System.Drawing.Size(341, 45);
            this.txtAdminPassword.TabIndex = 2;
            this.txtAdminPassword.Tag = "Пароль";
            this.txtAdminPassword.Text = "Пароль";
            this.txtAdminPassword.UseSelectable = true;
            this.txtAdminPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdminPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtAdminPassword.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtAdminPassword.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.CustomButton.Image = null;
            this.txtConfirmPassword.CustomButton.Location = new System.Drawing.Point(297, 1);
            this.txtConfirmPassword.CustomButton.Name = "";
            this.txtConfirmPassword.CustomButton.Size = new System.Drawing.Size(43, 43);
            this.txtConfirmPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtConfirmPassword.CustomButton.TabIndex = 1;
            this.txtConfirmPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtConfirmPassword.CustomButton.UseSelectable = true;
            this.txtConfirmPassword.CustomButton.Visible = false;
            this.txtConfirmPassword.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtConfirmPassword.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.txtConfirmPassword.Lines = new string[] { "Подтвердить пароль" };
            this.txtConfirmPassword.Location = new System.Drawing.Point(48, 315);
            this.txtConfirmPassword.MaxLength = 32767;
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '\0';
            this.txtConfirmPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.SelectionLength = 0;
            this.txtConfirmPassword.SelectionStart = 0;
            this.txtConfirmPassword.ShortcutsEnabled = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(341, 45);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.Tag = "Подтвердить пароль";
            this.txtConfirmPassword.Text = "Подтвердить пароль";
            this.txtConfirmPassword.UseSelectable = true;
            this.txtConfirmPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtConfirmPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtConfirmPassword.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.AddPlaceholderText);
            // 
            // btn_Create_Admin
            // 
            this.btn_Create_Admin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Create_Admin.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_Create_Admin.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_Create_Admin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Create_Admin.Location = new System.Drawing.Point(48, 445);
            this.btn_Create_Admin.Name = "btn_Create_Admin";
            this.btn_Create_Admin.Size = new System.Drawing.Size(341, 77);
            this.btn_Create_Admin.TabIndex = 6;
            this.btn_Create_Admin.Text = "Создать аккаунт";
            this.btn_Create_Admin.UseSelectable = true;
            this.btn_Create_Admin.Click += new System.EventHandler(this.btn_Create_Admin_Click);
            // 
            // CreateAdmin
            // 
            this.ClientSize = new System.Drawing.Size(426, 589);
            this.Controls.Add(this.txtAdminName);
            this.Controls.Add(this.txtAdminLogin);
            this.Controls.Add(this.txtAdminPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btn_Create_Admin);
            this.Name = "CreateAdmin";
            this.Text = "Регистрация администратора";
            this.ResumeLayout(false);

        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null && txt.Text == txt.Tag.ToString())
            {
                txt.Text = "";
                txt.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void AddPlaceholderText(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
