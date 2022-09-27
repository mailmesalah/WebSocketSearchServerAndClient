using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alchemy;
using Alchemy.Classes;
using System.Net;
using System.Net.Sockets;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {


            WebSocketServer aServer = new WebSocketServer(8080, IPAddress.Any)
            {
                OnReceive = OnReceive,
                OnConnect = OnConnect,
                OnConnected = OnConnected,
                OnDisconnect = OnDisconnect,
                //Time out in 0 hours 5 minute 0 seconds
                TimeOut = new TimeSpan(0, 10, 0)
            };

            aServer.Start();
            Console.WriteLine("Server Starts");

        }

        private static void OnDisconnect(UserContext context)
        {
            Console.WriteLine("Client Disconnects");
        }

        private static void OnConnect(UserContext context)
        {
            Console.WriteLine("Server Connects");
        }


        private static void OnReceive(UserContext context)
        {

            Console.WriteLine("Server Receive" + context.DataFrame);
            context.Send("haaaifffsdhhshhsasaaaaaaaaaaaaaaaaaaaaaaaaaaaaassssssssssssssssffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssnnnnnnnnnnnnnnnnnnnnx");
        }

        static void OnConnected(UserContext aContext)
        {
            Console.WriteLine("Client Connection From : " + aContext.ClientAddress.ToString());
        }

    }
}
