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
    public partial class FileExplorer : Form
    {
        private TcpClient client;
        private string currentDirectory = "c:/";
        public FileExplorer(TcpClient theClient)
        {
            client = theClient;
            InitializeComponent();
        }

        private void FileExplorer_Load(object sender, EventArgs e)
        {
            LoadRoot();
        }

        private void LoadRoot()
        {
            Server.sendMessage(client, "fileexplorer`"+currentDirectory);
            waitResponse();
        }

        private void waitResponse()
        {
            listView1.Clear();
            listView1.Items.Add("Back");
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            string data;
            data = sReader.ReadLine();
            string[] fields = data.Split('`');

            //if access denied error
            if(fields[1] == "accessdenied")
            {
                MessageBox.Show("Access Denied");

                //Run method to go back a folder
                string[] directory = currentDirectory.Split('/');
                string replace = directory[directory.Length - 2] + "/";
                currentDirectory = currentDirectory.Replace(replace, "");
                Server.sendMessage(client, "fileexplorer`" + currentDirectory);
                waitResponse();
            }
            foreach(string field in fields)
            {
                if (field != "")
                {
                    if (field.Contains("."))
                    {
                        listView1.Items.Add(field, 1);
                    }
                    else
                    {
                        listView1.Items.Add(field, 0);
                    }
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!listView1.HitTest(e.X, e.Y).Item.Text.Contains("."));
            {
                if (listView1.HitTest(e.X, e.Y).Item == listView1.Items[0])
                {
                    string[] directory = currentDirectory.Split('/');
                    if (directory[1] != "")
                    {
                        string replace = directory[directory.Length - 2] + "/";
                        currentDirectory = currentDirectory.Replace(replace, "");
                        Server.sendMessage(client, "fileexplorer`" + currentDirectory);
                        waitResponse();
                    }
                }
                else
                {
                    currentDirectory = currentDirectory + listView1.HitTest(e.X, e.Y).Item.Text.ToString() + "/";
                    Server.sendMessage(client, "fileexplorer`" + currentDirectory);
                    waitResponse();
                }
                toolStripStatusLabel1.Text = currentDirectory;
            }
        }
    }
}
