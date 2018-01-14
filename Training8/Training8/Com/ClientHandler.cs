using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Training8.Com
{
    class ClientHandler
    {
        Action<string> guiInformer;
        Socket clientSocket;
        Thread receivingThread;
        string username = "";
        byte[] buffer = new byte[512];

        public ClientHandler(Socket accepted, Action<string> guiInformer)
        {
            clientSocket = accepted;
            this.guiInformer = guiInformer;
            StartReceiving();
        }

        private void StartReceiving()
        {
            receivingThread = new Thread(Receive);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        private void Receive()
        {
            string msg = "";
            while (receivingThread.IsAlive)
            {
                int length = clientSocket.Receive(buffer);
                msg = Encoding.UTF8.GetString(buffer, 0, length);

                if(username == "")
                {
                    username = msg.Split('@')[0];
                }

                guiInformer(msg);
            }
        }
    }
}
