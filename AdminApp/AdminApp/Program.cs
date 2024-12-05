using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthenticationApp;

namespace AdminApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        
        static void Main()

        {
            Application.Run(new LoginForm());
            //Application.EnableVisualStyles();

            //Application.SetCompatibleTextRenderingDefault(false);
            // Создаем и показываем форму логина
            //using (LoginForm loginForm = new LoginForm())
            //{
            //    if (loginForm.ShowDialog() == DialogResult.OK)
            //    {
            //        // Если вход успешен, открываем основную форму
            //        Application.Run(new Form1());
            //    }
            //    else
            //    {
            //        // Если вход не удался или отменен, закрываем приложение
            //        Application.Exit();
            //    }

            //}

        }
    }
}
