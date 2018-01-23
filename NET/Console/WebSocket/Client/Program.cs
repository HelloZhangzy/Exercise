using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;

namespace Client
{
    class Program
    {
        private static WebSocket websocket = null;
        private static string strSendText = string.Empty;

        private static string SendData = "";

        static void Main(string[] args)
        {
            //websocket = new WebSocket("ws://127.0.0.1:2015");            
            websocket = new WebSocket("wss://cn1.loriot.io/app?token=vnwCMgAAAA1jbjEubG9yaW90LmlvixEUyS6SAyR1Zrj-tZ3fOQ==");    
           // websocket = new WebSocket("wss://loraflow.io/v1/application/ws?appeui=1616161616161616&token=1v7rwa77f89de547bd9f10ed54e4a&feedback");    
            websocket.Opened += websocket_Opened;
            websocket.Closed += websocket_Closed;
            websocket.MessageReceived += websocket_MessageReceived;
            websocket.Open();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1：发送数据");
                Console.WriteLine("2：上行触发发送数据");
                Console.WriteLine("0：退出");
                
                string temp = Console.ReadLine();
                if (temp == "0")
                {
                    websocket.Close();
                    break;
                }
                if (temp=="1")
                {
                    Console.WriteLine();
                    Console.WriteLine("录入发送的数据：\n");
                    string str = Console.ReadLine();
                    websocket.Send(str);                    
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("录入发送的数据：\n");
                    SendData = Console.ReadLine();
                }
            }
        }


        private static void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine("Server=>"+ e.Message);
            websocket.Send(SendData);
        }        

        private static void websocket_Closed(object sender, EventArgs e)
        {
            //websocket.Send("一个客户端 下线");
            Console.WriteLine("Closed");
        }

        private static void websocket_Opened(object sender, EventArgs e)
        {
            //websocket.Send("一个客户端 上线");
            //Console.WriteLine("Server=>" + e.Message);
            Console.WriteLine("Open");
        }

    }
}
