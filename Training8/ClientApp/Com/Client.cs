using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp.Com
{
    public class Client
    {
        Socket clientSocket;
        const int port = 10100;
        string username = "";
        static Random rnd = new Random();

        public Client()
        {
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Loopback, port);
            clientSocket = client.Client;
            username = "user" + rnd.Next(1000,9999)+"@";
        }

        public void Send(string msg)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(username+msg));
        }


    }
}
