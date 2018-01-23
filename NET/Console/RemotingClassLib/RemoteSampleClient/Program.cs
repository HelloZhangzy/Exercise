using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using RemotingClassLib;

namespace RemoteSampleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //同一通信方式只允许存在一个

            //ChannelServices.RegisterChannel(new TcpClientChannel());
            //RemoteObject remoteobj = (RemoteObject)Activator.GetObject(typeof(RemoteObject),"tcp://127.0.0.1:6666/RemoteObject");            
            //Console.WriteLine("1 + 2 = " + remoteobj.sum(1, 2).ToString());

            ChannelServices.RegisterChannel(new HttpClientChannel());
            RemoteObject remot = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "http://127.0.0.1:7777/RemoteObject");
            Console.WriteLine("3 + 4 = " + remot.sum(3, 4).ToString());

            
            ChannelServices.RegisterChannel(new TcpChannel());
            RemoteObject remoteobj2 = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "tcp://127.0.0.1:8888/RemoteObject");
            Console.WriteLine("5 + 6 = " + remoteobj2.sum(5, 6).ToString());

            Console.ReadLine();
        }
    }
}
