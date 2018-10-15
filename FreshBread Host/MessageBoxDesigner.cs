using FreshBreadHost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshBread_Host
{
    public partial class MessageBoxDesigner : Form
    {
        private TcpClient client;
        public MessageBoxDesigner(TcpClient theClient)
        {
            client = theClient;
            InitializeComponent();
        }

        private void MessageBoxDesigner_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server.sendMessage(client, "msgbox`"+textBox1.Text+"`"+textBox2.Text+"`");
        }
    }
}
