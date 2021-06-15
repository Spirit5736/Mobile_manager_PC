using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_manager_PC_Backend
{
   public class Connecting
    {
        private static string ipString;
        private static TcpListener listener;
        public static TcpClient client;

        public static void DoGetHostAddresses()
        {
            IPAddress[] localIp = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIp)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipString = address.ToString();
                }
            }
        }

        public void ListenPort()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipString), 1234);
            listener = new TcpListener(ipEndPoint);
            listener.Start();
            Console.WriteLine(@"  
===================================================  
Started listening requests at: {0}:{1}  
===================================================",
            ipEndPoint.Address, ipEndPoint.Port);
            client = listener.AcceptTcpClient();
            Console.WriteLine("Connected to client!" + " \n");
        }
    }
}
