using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ClientApp
{
    public partial class MainForm : Form
    {
        // IP-адрес сервера (администратора)
        private const string ServerIP = "127.0.0.1";

        // Порт сервера
        private const int Port = 8080;
        public int a;
        public MainForm()
        {
            InitializeComponent();
            this.groupBox1.Controls.Clear();


            Button btComputer = new Button
            {
                Text = "Проблема с компьютером",
                Width = (groupBox1.Width * 4 / 10),
                Height = (groupBox1.Height * 2 / 10),
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            btComputer.Location = new Point(10, 60);
            btComputer.Click += new EventHandler(btComputer_Click);
            groupBox1.Controls.Add(btComputer);

            Button btInternet = new Button
            {
                Text = "Проблема с интернетом",
                Width = (groupBox1.Width * 4 / 10),
                Height = (groupBox1.Height * 2 / 10),
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            btInternet.Location = new Point(10, 180);
            btInternet.Click += new EventHandler(btInternet_Click);
            groupBox1.Controls.Add(btInternet);

            Button btStudent = new Button
            {
                Text = "Проблема у студента",
                Width = (groupBox1.Width * 4 / 10),
                Height = (groupBox1.Height * 2 / 10),
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            btStudent.Location = new Point(10, 300);
            btStudent.Click += new EventHandler(btStudent_Click);
            groupBox1.Controls.Add(btStudent);

            btComputer.Location = new Point(10, 60);
            btComputer.Click += new EventHandler(btComputer_Click);
            groupBox1.Controls.Add(btComputer);

            Button btAlarm = new Button
            {
                Text = "Проблема с интернетом",
                Width = (groupBox1.Width * 3 / 10),
                Height = (groupBox1.Height * 1 / 10),
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            btAlarm.Location = new Point(300, 90);
            btAlarm.Click += new EventHandler(btAlarm_Click);
            groupBox1.Controls.Add(btAlarm);
        }

        private void btAlarm_Click(object sender, EventArgs e)
        {
            if (a > 0)
            {
                switch (a)
                {

                    case 1:
                        try
                        {
                            using (TcpClient client = new TcpClient())
                            {
                                client.Connect(ServerIP, Port);

                                NetworkStream stream = client.GetStream();

                                if (stream.CanWrite)
                                {
                                    byte[] message = Encoding.UTF8.GetBytes("Проблема с компьютером");

                                    stream.Write(message, 0, message.Length);

                                    MessageBox.Show("Сообщение отправлено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка: {ex.Message}");
                        }

                        break;

                    case 2:
                        try
                        {
                            using (TcpClient client = new TcpClient())
                            {
                                client.Connect(ServerIP, Port);

                                NetworkStream stream = client.GetStream();

                                if (stream.CanWrite)
                                {
                                    byte[] message = Encoding.UTF8.GetBytes("Проблема с интернетом");

                                    stream.Write(message, 0, message.Length);

                                    MessageBox.Show("Сообщение отправлено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка: {ex.Message}");
                        }

                        break;

                    case 3:
                        try
                        {
                            using (TcpClient client = new TcpClient())
                            {
                                client.Connect(ServerIP, Port);

                                NetworkStream stream = client.GetStream();

                                if (stream.CanWrite)
                                {
                                    byte[] message = Encoding.UTF8.GetBytes("Проблема у студента");

                                    stream.Write(message, 0, message.Length);

                                    MessageBox.Show("Сообщение отправлено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка: {ex.Message}");
                        }
                        break;
                }
                a = 0;
            }
            else
            {
                MessageBox.Show($"Ошибка: \nВыберите проблему");
            }
        }

        
        private void btComputer_Click(object sender, EventArgs e)
        {
            a = 1;
        }

        private void btInternet_Click(object sender, EventArgs e)
        {
            a = 2;
        }

        private void btStudent_Click(object sender, EventArgs e)
        {
            a = 3;
        }
    }
}