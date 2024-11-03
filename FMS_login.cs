using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace FMS_PNP
{
    public partial class FMS_login : MetroForm
    {
        public FMS_login()
        {
            InitializeComponent();
        }

        private SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        private async void FMS_login_Load(object sender, EventArgs e)
        {
            try
            {
                await cnn.OpenAsync();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Administrator", cnn);
                int result = (int)await cmd.ExecuteScalarAsync();

                // Если администратор не найден, открываем форму для регистрации
                if (result == 0)
                {
                    this.Hide();
                    CreateAdmin createAdminForm = new CreateAdmin();
                    createAdminForm.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                await cnn.OpenAsync();
                // Используем хешированный пароль для проверки
                string hashedPassword = HashPassword(txt_login_password.Text);
                SqlCommand cmd = new SqlCommand("SELECT * FROM Administrator WHERE Login = @login AND PasswordHash = @password", cnn);
                cmd.Parameters.AddWithValue("@login", txt_login_username.Text);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                if (await rdr.ReadAsync())
                {
                    // Вход в Admin_Dashboard
                    Admin_Dashboard dashboard = new Admin_Dashboard();
                    dashboard.Show(); // Открываем Admin_Dashboard
                    LogLogin(txt_login_username.Text); // Логирование входа

                    // Завершаем форму FMS_login, но не закрываем приложение
                    this.Hide(); // Скрываем текущую форму
                    dashboard.FormClosed += (s, args) => this.Close(); // Закрываем FMS_login, когда Admin_Dashboard закроется
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во время входа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAdmin createAdminForm = new CreateAdmin();
            createAdminForm.ShowDialog();
            this.Show();
        }

        private void LogLogin(string username)
        {
            string filePath = "login_log.txt";
            string logEntry = $"Дата: {DateTime.Now}, Имя пользователя: {username} - Успешный вход";
            File.AppendAllText(filePath, logEntry + Environment.NewLine, Encoding.UTF8);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
