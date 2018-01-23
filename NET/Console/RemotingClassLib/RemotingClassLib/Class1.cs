using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingClassLib
{
    public class RemoteObject : System.MarshalByRefObject
    {
         public RemoteObject()
         {
            System.Console.WriteLine("New Referance Added!");
         }
 
        public int sum(int a, int b)
        {
            return a + b;
        }
    }
}
