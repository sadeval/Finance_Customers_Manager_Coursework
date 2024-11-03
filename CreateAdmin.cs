using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace FMS_PNP
{
    public partial class CreateAdmin : MetroForm
    {
        public string AdminName => txtAdminName.Text;
        public string AdminLogin => txtAdminLogin.Text;
        public string AdminPassword => txtAdminPassword.Text;

        public CreateAdmin()
        {
            InitializeComponent();
        }

        private SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        private async void btn_Create_Admin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(AdminName) || string.IsNullOrEmpty(AdminLogin) || string.IsNullOrEmpty(AdminPassword))
                {
                    MessageBox.Show("Заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await cnn.OpenAsync();

                string query = "INSERT INTO Administrator (FullName, Login, PasswordHash) VALUES (@FullName, @Login, @PasswordHash)";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@FullName", AdminName);
                cmd.Parameters.AddWithValue("@Login", AdminLogin);
                cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(AdminPassword));

                await cmd.ExecuteNonQueryAsync();
                MessageBox.Show("Администратор успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnn.Close();
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
