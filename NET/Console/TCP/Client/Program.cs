using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;

            ServerClient client = new ServerClient();
            client.SendMessage();

            Console.WriteLine("\n\n输入\"Q\"键退出。");
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }

    public class ServerClient
    {
        private const int BufferSize = 8192;
        private byte[] buffer;
        private TcpClient client;
        private NetworkStream streamToServer;
        private string msg = "Welcome to TraceFact.Net!";

        public ServerClient()
        {
            try
            {
                client = new TcpClient();
                client.Connect("192.168.1.3", 8500);      // 与服务器连接
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            buffer = new byte[BufferSize];

            // 打印连接到的服务端信息
            Console.WriteLine("Server Connected！{0} --> {1}",
                client.Client.LocalEndPoint, client.Client.RemoteEndPoint);

            streamToServer = client.GetStream();
        }

        // 连续发送三条消息到服务端
        public void SendMessage(string msg)
        {

            msg = String.Format("[length={0}]{1}", msg.Length, msg);

            for (int i = 0; i <= 2; i++)
            {
                byte[] temp = Encoding.Unicode.GetBytes(msg);   // 获得缓存
                try
                {
                    streamToServer.Write(temp, 0, temp.Length); // 发往服务器
                    Console.WriteLine("Sent: {0}", msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            lock (streamToServer)
            {
                AsyncCallback callBack = new AsyncCallback(ReadComplete);
                streamToServer.BeginRead(buffer, 0, BufferSize, callBack, null);
            }
        }

        public void SendMessage()
        {
            SendMessage(this.msg);
        }

        // 读取完成时的回调方法
        private void ReadComplete(IAsyncResult ar)
        {
            int bytesRead;

            try
            {
                lock (streamToServer)
                {
                    bytesRead = streamToServer.EndRead(ar);
                }
                if (bytesRead == 0) throw new Exception("读取到0字节");

                string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: {0}", msg);
                Array.Clear(buffer, 0, buffer.Length);      // 清空缓存，避免脏读

                lock (streamToServer)
                {
                    AsyncCallback callBack = new AsyncCallback(ReadComplete);
                    streamToServer.BeginRead(buffer, 0, BufferSize, callBack, null);
                }
            }
            catch (Exception ex)
            {
                if (streamToServer != null)
                    streamToServer.Dispose();
                client.Close();

                Console.WriteLine(ex.Message);
            }
        }
    }
}
