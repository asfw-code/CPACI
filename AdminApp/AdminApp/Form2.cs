using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            TxbLogin.Text = "Введите логин";
            TxbLogin.ForeColor = Color.Gray;

            TxbPaswd.Text = "Введите пароль";
            TxbPaswd.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = TxbLogin.Text;
            string password = TxbPaswd.Text;

            // Проверка введенных данных
            if (username == "Admin" && password == "123456")
            {
                // Данные верны, открываем главную форму

                MainForm fm = new MainForm();
                fm.Show();
                this.Hide();


            }
            else
            {
                // Данные неверны, выводим сообщение об ошибке
                MessageBox.Show("Неверный логин или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxbPaswd_Enter(object sender, EventArgs e)
        {
            if (TxbPaswd.Text == "Введите пароль")
            {
                TxbPaswd.Text = "";
                TxbPaswd.ForeColor = Color.Black;
                TxbPaswd.PasswordChar = '*';
            }
        }

        private void TxbPaswd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxbPaswd.Text))
            {
                TxbPaswd.Text = "Введите пароль";
                TxbPaswd.ForeColor = Color.Gray;
                TxbPaswd.PasswordChar = '\0';
            }
        }

        private void TxbLogin_Enter(object sender, EventArgs e)
        {
            if (TxbLogin.Text == "Введите логин")
            {
                TxbLogin.Text = "";
                TxbLogin.ForeColor = Color.Black;
            }
        }

        private void TxbLogin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxbLogin.Text))
            {
                TxbLogin.Text = "Введите логин";
                TxbLogin.ForeColor = Color.Gray;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.bt1.Select();
        }
    }
}
