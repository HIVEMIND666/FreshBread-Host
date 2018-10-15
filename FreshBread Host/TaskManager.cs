using FreshBreadHost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshBread_Host
{
    public partial class TaskManager : Form
    {
        private string process;
        TcpClient client;
        public TaskManager(TcpClient theClient)
        {
            client = theClient;
            InitializeComponent();
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            this.Text = "Task Manager - " + client.Client.RemoteEndPoint.ToString();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            Server.sendMessage(client, "taskmanager`load");
            waitResponse();
        }

        private void waitResponse()
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            string data;
            data = sReader.ReadLine();
            string[] fields = data.Split('`');
            foreach (string field in fields)
            {
                listBox1.Items.Add(field);
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                process = listBox1.Items[listBox1.IndexFromPoint(e.Location)].ToString();
                MessageBox.Show(process);
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add(new MenuItem("Terminate", new System.EventHandler(this.terminateProcess)));
                //show menu
                cm.Show(this, new Point(e.X, e.Y));
            }
        }

        private void terminateProcess(Object sender, EventArgs e)
        {
            Server.sendMessage(client, "taskmanager`kill`" + process);
        }
    }
}
