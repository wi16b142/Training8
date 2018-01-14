using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training8.Com
{
    public class Server
    {
        Action<string> GuiInformer;
        Socket serverSocket;
        Thread acceptingThread;
        List<ClientHandler> Clients;
        const int port = 10100;


        public Server(Action<string> GuiInformer)
        {
            this.GuiInformer = GuiInformer;

            Clients = new List<ClientHandler>();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, port));
            serverSocket.Listen(10);

            StartAccepting();

        }

        private void StartAccepting()
        {
            acceptingThread = new Thread(Accept);
            acceptingThread.IsBackground = true;
            acceptingThread.Start();
        }

        private void Accept()
        {
            while (acceptingThread.IsAlive)
            {
                Clients.Add(new ClientHandler(serverSocket.Accept(), GuiInformer));
            }
        }



    }
}
