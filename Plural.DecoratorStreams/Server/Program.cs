using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ip, 5200);
            tcpListener.Start();

            int bytesReceived, totalReceived = 0;
            byte[] receivedData = new byte[2000000];

            Console.Write("Listening... ");

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();

            Console.WriteLine("Client connected.");
            Console.Write("Receiving data... ");

            do
            {
                bytesReceived = ns.Read(receivedData, 0, receivedData.Length);
                totalReceived += bytesReceived;
            }
            while (bytesReceived != 0);

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
