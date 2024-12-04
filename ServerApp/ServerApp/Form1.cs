using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class Form1 : Form
    {
        private readonly List<TcpClient> _clients = new List<TcpClient>();
        private bool _isRunning = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() => StartServer());
        }
        private void StartServer()
        {
            TcpListener listener = null;
            try
            {
                int port = 8080;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                listener = new TcpListener(localAddr, port);
                listener.Start();

                while (_isRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    _clients.Add(client);

                    Task.Run(() => ProcessClientAsync(client));
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }
            finally
            {
                listener?.Stop();
            }
        }
            private async Task ProcessClientAsync(TcpClient client)
            {
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[256];
                int numBytesRead = 0;

                while ((numBytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string data = System.Text.Encoding.UTF8.GetString(buffer, 0, numBytesRead);

                    foreach (TcpClient adminClient in _clients)
                    {
                        SendToAdminAsync(adminClient, data);
                    }
                }

                client.Close();
                _clients.Remove(client);
            }
            private async Task SendToAdminAsync(TcpClient adminClient, string data)
            {
                NetworkStream adminStream = adminClient.GetStream();

                if (adminStream.CanWrite)
                {
                    byte[] message = Encoding.UTF8.GetBytes(data);

                    await adminStream.WriteAsync(message, 0, message.Length);
                }
            }

            private void StopServer()
            {
                _isRunning = false;
            }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void рморюрроюрюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Ошибка: \nВыберите проблему");
        }
    }
}
