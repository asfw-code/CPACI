using System;
using System.Windows.Forms;
using AdminApp;
using AuthenticationApp;

namespace AuthenticationApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //InitializeMyControls();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void InitializeControls()
        {
            // Настройка TextBox для пароля
             // Отображение звёздочек
        }

        private bool IsValidUser(string username, string password)
        {
            // Пример проверки (замените на вашу логику)
            return username == "1" && password == "1";
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Логика проверки логина и пароля

            if (IsValidUser(txtUsername.Text, txtPassword.Text))
            {

                this.DialogResult = DialogResult.OK; // Успешный вход

                LoginForm lf = new LoginForm();
                Form1 fm = new Form1();
                lf.Close();
                fm.Show();
                this.Close();
                
                fm.Show();
                // Закрываем форму логина
                //MessageBox.Show("awgag.");
            }

            else
            {

                MessageBox.Show("Неверный логин или пароль.");

            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}