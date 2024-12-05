using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthenticationApp;

namespace AdminApp
{
    public partial class Form1 : Form1
    {
        private readonly List<Problem> _problems = new List<Problem>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            //// Открываем форму аутентификации
            //using (var loginForm = new LoginForm())
            //{
            //    if (loginForm.ShowDialog() != DialogResult.OK)
            //    {
            //        // Если аутентификация не прошла, закрываем приложение
            //        this.Close();
            //        return;
            //    }
            //}
            LoginForm lf = new LoginForm();
             lf.Close();
            
            ////Если аутентификация прошла, запускаем сервер
            await Task.Run(() => StartServer());
        }

        private void StartServer()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 8080;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);
                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    ProcessClient(client, this);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }
            finally
            {
                server?.Stop();
            }
        }

        private static void ProcessClient(TcpClient client, Form1 mainForm)
        {
            NetworkStream stream = client.GetStream();
            byte[] bytes = new byte[256];
            int numBytesRead = stream.Read(bytes, 0, bytes.Length);
            string data = System.Text.Encoding.UTF8.GetString(bytes, 0, numBytesRead);
            mainForm.HandleMessage(data);
            client.Close();
        }

        private void HandleMessage(string message)
        {
            Problem problem = new Problem
            {
                Type = message,
                Status = "Неразрешенная",
                DateTime = DateTime.Now
            };

            _problems.Add(problem);
            UpdateUI(problem);
        }

        private delegate void UpdateUIDelegate(Problem problem);

        private void UpdateUI(Problem problem)
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateUIDelegate(UpdateUI), new object[] { problem });
            }
            else
            {
                // Обновление интерфейса
                // Например, добавление в DataGridView
            }
        }

        internal class Problem
        {
            public string Type { get; set; }
            public string Status { get; set; }
            public DateTime DateTime { get; set; }
        }
    }
}