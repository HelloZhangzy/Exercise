using SuperSocket.SocketBase.Config;
using SuperSocket.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebSocket
{
    class Program
    {
        private static WebSocketServer appServer = new WebSocketServer();

        private static Dictionary<string, object> clients = new Dictionary<string, object>();

        private static ServerConfig serverConfig = new ServerConfig
        {
            Ip = "127.0.0.1",
            Port = 2015,//set the listening port
            MaxConnectionNumber = 10000
        };

        private static void appServer_NewSessionConnected(WebSocketSession session)
        {
            session.Send("连接成功");
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.Append("连接成功:" + "\n");
            //strBuilder.Append("Host:" + session.Host + ";");//服务器的ip
            //strBuilder.Append("Uri:" + session.UriScheme + ";");
            //strBuilder.Append("Path:" + session.Path + ";");
            //strBuilder.Append("CurrentToken:" + session.CurrentToken + ";");
            //strBuilder.Append("SessionID:" + session.SessionID + ";");
            //strBuilder.Append("Connection" + session.Connection + ";");
            //strBuilder.Append("Origin" + session.Origin + ";");
            //strBuilder.Append("LocalEndPoint" + session.LocalEndPoint + ";");
            //strBuilder.Append("RemoteEndPoint" + session.RemoteEndPoint);
            clients.Add(session.SessionID, session);
        }
        private static void appServer_NewMessageReceived(WebSocketSession session, string message)
        {
           // session.Send("服务端收到了客户端发来的消息");
            Console.WriteLine("Re=>"+message);

            //这里判断接收消息
            //session.Send(message);//将消息发送到客户端
            // SessionResponse.get().InitResponseJsonData(message);  //解析数据（将数据保存到数据库中）
            //WebSocketHelper.get().setWebSocketSession(session); //将这个session传给session
            //调用发送消息的类
            // SessionRequest.get().sendUserInfo();

        }

        private static void appServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {            
            //sessionManager.Remove(session.SessionID.ToString());
            session.Close();
        }
        static void Main(string[] args)
        {           
           
            if (!appServer.Setup(serverConfig)) //Setup the appServer
            {
                Console.WriteLine("开启服务器失败");
                return;
            }

            if (!appServer.Start())//Try to start the appServer
            {
                Console.WriteLine("开启服务器失败");
                return;
            }
            //注册事件
            appServer.NewSessionConnected += appServer_NewSessionConnected;//客户端连接
            appServer.NewMessageReceived += appServer_NewMessageReceived;//客户端接收消息
            appServer.SessionClosed += appServer_SessionClosed;//客户端关闭

            while (true)
            {
                Console.WriteLine("服务器开启成功！");
                Console.WriteLine();
                Console.WriteLine("1：退出");
                Console.WriteLine("Other：发送数据");
                string temp = Console.ReadLine();
                if (temp == "1")
                {
                    appServer.Stop();
                    break;
                }
                else
                {
                    foreach (var item in clients)
                    {
                        ((WebSocketSession)item.Value).Send(temp);
                    }
                }
            }
        }
    }
}
