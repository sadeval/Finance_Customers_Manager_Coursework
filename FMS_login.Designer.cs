namespace FMS_PNP
{
    partial class FMS_login
    {
        private System.ComponentModel.IContainer components = null;
        private MetroFramework.Controls.MetroLabel lblUsername;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroTextBox txt_login_username;
        private MetroFramework.Controls.MetroTextBox txt_login_password;
        private MetroFramework.Controls.MetroButton btn_login;
        private MetroFramework.Controls.MetroButton btnAddAdmin; 

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
            this.lblUsername = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.txt_login_username = new MetroFramework.Controls.MetroTextBox();
            this.txt_login_password = new MetroFramework.Controls.MetroTextBox();
            this.btn_login = new MetroFramework.Controls.MetroButton();
            this.btnAddAdmin = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(48, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(130, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Имя пользователя";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(48, 163);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 20);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Пароль";
            // 
            // txt_login_username
            // 
            // 
            // 
            // 
            this.txt_login_username.CustomButton.Image = null;
            this.txt_login_username.CustomButton.Location = new System.Drawing.Point(241, 2);
            this.txt_login_username.CustomButton.Name = "";
            this.txt_login_username.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txt_login_username.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_login_username.CustomButton.TabIndex = 1;
            this.txt_login_username.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_login_username.CustomButton.UseSelectable = true;
            this.txt_login_username.CustomButton.Visible = false;
            this.txt_login_username.Lines = new string[0];
            this.txt_login_username.Location = new System.Drawing.Point(48, 103);
            this.txt_login_username.MaxLength = 32767;
            this.txt_login_username.Name = "txt_login_username";
            this.txt_login_username.PasswordChar = '\0';
            this.txt_login_username.PromptText = "Введите имя пользователя";
            this.txt_login_username.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_login_username.SelectedText = "";
            this.txt_login_username.SelectionLength = 0;
            this.txt_login_username.SelectionStart = 0;
            this.txt_login_username.ShortcutsEnabled = true;
            this.txt_login_username.Size = new System.Drawing.Size(267, 28);
            this.txt_login_username.TabIndex = 2;
            this.txt_login_username.UseSelectable = true;
            this.txt_login_username.WaterMark = "Введите имя пользователя";
            this.txt_login_username.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_login_username.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_login_password
            // 
            // 
            // 
            // 
            this.txt_login_password.CustomButton.Image = null;
            this.txt_login_password.CustomButton.Location = new System.Drawing.Point(241, 2);
            this.txt_login_password.CustomButton.Name = "";
            this.txt_login_password.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txt_login_password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_login_password.CustomButton.TabIndex = 1;
            this.txt_login_password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_login_password.CustomButton.UseSelectable = true;
            this.txt_login_password.CustomButton.Visible = false;
            this.txt_login_password.Lines = new string[0];
            this.txt_login_password.Location = new System.Drawing.Point(48, 186);
            this.txt_login_password.MaxLength = 32767;
            this.txt_login_password.Name = "txt_login_password";
            this.txt_login_password.PasswordChar = '*';
            this.txt_login_password.PromptText = "Введите пароль";
            this.txt_login_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_login_password.SelectedText = "";
            this.txt_login_password.SelectionLength = 0;
            this.txt_login_password.SelectionStart = 0;
            this.txt_login_password.ShortcutsEnabled = true;
            this.txt_login_password.Size = new System.Drawing.Size(267, 28);
            this.txt_login_password.TabIndex = 3;
            this.txt_login_password.UseSelectable = true;
            this.txt_login_password.WaterMark = "Введите пароль";
            this.txt_login_password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_login_password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(48, 279);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(267, 37);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "Войти";
            this.btn_login.UseSelectable = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btnAddAdmin
            // 
            this.btnAddAdmin.Location = new System.Drawing.Point(48, 340);
            this.btnAddAdmin.Name = "btnAddCustomer";
            this.btnAddAdmin.Size = new System.Drawing.Size(267, 37);
            this.btnAddAdmin.TabIndex = 6;
            this.btnAddAdmin.Text = "Регистрация";
            this.btnAddAdmin.UseSelectable = true;
            this.btnAddAdmin.Click += new System.EventHandler(this.btnAddAdmin_Click);
            // 
            // FMS_login
            // 
            this.ClientSize = new System.Drawing.Size(370, 422);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txt_login_username);
            this.Controls.Add(this.txt_login_password);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btnAddAdmin);
            this.Name = "FMS_login";
            this.Text = "Логин";
            this.Load += new System.EventHandler(this.FMS_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
