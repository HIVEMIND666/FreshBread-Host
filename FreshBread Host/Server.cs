using FreshBread_Host;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshBreadHost
{
    public class Server
    {
        private TcpListener server;
        private Boolean isRunning;
        private Boolean isScanning;
        public static List<TcpClient> tcpClients = new List<TcpClient>();
        public static Main main;
        DataTable clientTable = new DataTable();

        public Server(int port, Form form)
        {
            //set up the main form
            main = (Main)form;
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            //set up the client table for the list view
            clientTable.Columns.Add("IP Address");
            clientTable.Columns.Add("Status");
            main.clients.Invoke(new Action(() => main.clients.DataSource = clientTable));

            //start booleans used for while loops
            isRunning = true;
            isScanning = true;

            ScanClients();
        }

        public static void sendMessage(TcpClient client, String message)
        {

            // sets two streams
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested
            sWriter.WriteLine(message);
            sWriter.Flush();
        }

        public void ScanClients()
        {
            //scanning
            while (isScanning)
            {
                // wait for client connection
                TcpClient newClient = server.AcceptTcpClient();
                tcpClients.Add(newClient);

                //add to client table list
                clientTable.Rows.Add(newClient.Client.RemoteEndPoint.ToString(), "Connected");
                main.clients.Invoke(new Action(() => main.clients.Refresh()));
                main.clients.Invoke(new Action(() => main.clients.Update()));
                //starts a new thread to handle each client
                Thread t = new Thread(new ParameterizedThreadStart(ReadClient));
                t.Start(newClient);
            }
        }

        public void ReadClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;

            // sets two streams
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested


            //OUTDATED - FOR REFERENCE
            ////////////////////////////////
            /* Boolean bClientConnected = true;
            string sData = null;

            while (bClientConnected)
            {
                sData = Console.ReadLine();

                sWriter.WriteLine(sData);
                sWriter.Flush();
            }*/
            //////////////////////////////////
        }

        public void setupDataGrid()
        {
            
        }
    }
}
