using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using RemotingClassLib;
using System.Collections;

namespace RemoteSampleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //注册通道
            //采用TCP
            TcpServerChannel channel = new TcpServerChannel(6666);
            ChannelServices.RegisterChannel(channel);
            //采用HTTP
            HttpServerChannel Channel2 = new HttpServerChannel(7777);
            ChannelServices.RegisterChannel(Channel2);

            // 自定义Formatter和通道名称的注册方式
            // 使用BinaryFormatter
            IServerChannelSinkProvider formatter = new BinaryServerFormatterSinkProvider();
            IDictionary propertyDic = new Hashtable();
            propertyDic["name"] = "CustomTcp";
            propertyDic["port"] = 8888;
            IChannel tcpChnl = new TcpChannel(propertyDic, null, formatter);
            ChannelServices.RegisterChannel(tcpChnl, false);

            //注册激活模式

                 
            //采用单件模式     
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject),"RemoteObject", WellKnownObjectMode.Singleton);
            //采用一个客户一对象模式
            // RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "RemoteObject", WellKnownObjectMode.SingleCall);

            // 采用客户端激活
            // RemotingConfiguration.RegisterActivatedServiceType(typeof(RemoteObject));  
            System.Console.WriteLine("Press Any Key");
            System.Console.ReadLine();
        }
    }
}
