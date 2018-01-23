using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单件模式
{
    
    //保证对象只有一个实例
    class SimpleSingleton
    {
        private static readonly object _padlock = new object(); //线程安全

        private static SimpleSingleton _instance;
        
        public static SimpleSingleton Instance()
        {
            if (_instance==null)
            {
                lock (_padlock) //线程安全
                {
                    _instance = new SimpleSingleton();
                }
                    
            }
            return _instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
