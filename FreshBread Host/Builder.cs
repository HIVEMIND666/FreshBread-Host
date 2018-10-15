using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshBread_Host
{
    public partial class Builder : Form
    {
        public Builder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Copy("Stub.exe", textBox1.Text);
            using (FileStream fileStream = new FileStream(textBox1.Text, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    fileStream.Position = fileStream.Length + 1;
                    binaryWriter.Write("$$$$$"+"STUB"+"`"+textBox2.Text+"`"+textBox3.Text);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(new ThreadStart(saveFile));
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
        }

        public void saveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Executable File|*.exe";
            sfd.Title = "Save built client...";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                textBox1.Invoke(new Action(() => textBox1.Text = sfd.FileName));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
