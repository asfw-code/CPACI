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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static AdminApp.MainForm;

namespace AdminApp
{

    public partial class MainForm : Form
    {
        private readonly List<Problem> _problems = new List<Problem>();

        public MainForm()
        {
            InitializeComponent();

            label1.Text = "Раздел проблем";





        }


        private void StartServer()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 8080;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);

                // Запускаем сервер
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

        private static void ProcessClient(TcpClient client, MainForm mainForm)
        {
            NetworkStream stream = client.GetStream();

            byte[] bytes = new byte[256];
            int numBytesRead = stream.Read(bytes, 0, bytes.Length);

            string data = System.Text.Encoding.UTF8.GetString(bytes, 0, numBytesRead);

            // Обработка полученного сообщения
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

        // Метод для обновления интерфейса администратора
        private delegate void UpdateUIDelegate(Problem problem);



        private void UpdateUI(Problem problem)
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateUIDelegate(UpdateUI), new object[] { problem });
            }
            else
            {
                dgvProblems.Rows.Add(new object[] { problem.Type, problem.Status, problem.DateTime });
                dgvProblems.Rows[dgvProblems.Rows.Count - 1].DefaultCellStyle.BackColor = problem.Status == "Разрешена" ? Color.Green : Color.Red;
            }
        }

        internal class Problem
        {
            public string Type { get; set; }
            public string Status { get; set; }
            public DateTime DateTime { get; set; }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await Task.Run(() => StartServer());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (dgvProblems.SelectedRows.Count > 0)
            //{
            //    // Получаем выбранную строку
            //    DataGridViewRow selectedRow = dgvProblems.SelectedRows[0];  

            //    // Если DataGridView связан с BindingSource
            //    if (dgvProblems.DataSource is BindingSource bindingSource)
            //    {
            //        // Удаляем строку из BindingSource
            //        bindingSource.Remove(selectedRow.DataBoundItem);
            //    }
            //    // Если DataGridView связан с DataTable
            //    else if (dgvProblems.DataSource is DataTable dataTable)
            //    {
            //        // Удаляем строку из DataTable
            //        dataTable.Rows.RemoveAt(selectedRow.Index);
            //    }
            //    // Другие типы источников данных обрабатываются аналогично
            //    else
            //    {
            //        MessageBox.Show("Не поддерживаемый тип источника данных.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Выберите строку для удаления.");
            //}



            //            if (dgvProblems.SelectedRows.Count >= 1)
            //            {
            //                // Получаем индекс выбранной строки
            //                int rowIndex = dgvProblems.SelectedRows[0].Index;

            //                // Создаем новую строку в dataGridView2
            //                DataGridViewRow newRow = (DataGridViewRow)dgvProblems.Rows[rowIndex].Clone();

            //                // Добавляем новую строку в dataGridView2
            //                datagrd2.Rows.Add(newRow);
            //            }
            //            else
            //            {

            //            }


           

            foreach (DataGridViewRow row in dgvProblems.SelectedRows)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(datagrd2); // Создаем ячейки для новой строки в dgvSolvedProblems

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = row.Cells[i].Value;
                    if (i == 1 && newRow.Cells[i].Value.ToString() == "Неразрешенная") // Assuming Status is at index 1
                    {
                        newRow.Cells[i].Value = "Решается";
                    }
                }

                datagrd2.Rows.Add(newRow);
                dgvProblems.Rows.RemoveAt(row.Index);
            }

            foreach (DataGridViewRow row in datagrd2.SelectedRows)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(datagrd3); // Создаем ячейки для новой строки в dgvSolvedProblems

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = row.Cells[i].Value;
                    if (i == 1 && newRow.Cells[i].Value.ToString() == "Решается") // Assuming Status is at index 1
                    {
                        newRow.Cells[i].Value = "Решено";
                    }
                }

                datagrd3.Rows.Add(newRow);
                datagrd2.Rows.RemoveAt(row.Index);
                //datagrd3.Rows.Add(new object[] {Column4.DateTime.Now});
                newRow.Cells[3].Value = DateTime.Now;
            }
        }


        private void dgvProblems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void datagrd2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void текущиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Раздел проблем";
            this.dgvProblems.Visible = true;
            this.datagrd2.Visible = false;
            this.datagrd3.Visible = false;
           
        }

        private void решённыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Раздел решаемых";
            this.dgvProblems.Visible = false;
            this.datagrd2.Visible = true;
            this.datagrd3.Visible = false;
        }

        private void toolStripTextBox2_ButtonClick(object sender, EventArgs e)
        {

        }

        private void решённыеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label1.Text = "Раздел решённых";
            this.dgvProblems.Visible = false;
            this.datagrd2.Visible = false;
            this.datagrd3.Visible = true;
        }
    }
}
