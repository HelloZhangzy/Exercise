using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    
//主要思想是基于现有的对象克隆一个新的对象出来，一般是有对象的内部提供克隆的方法，通过该方法返回一个对象的副本，这种创建对
//象的方式，相比我们之前说的几类创建型模式还是有区别的，之前的讲述的工厂模式与抽象工厂都是通过工厂封装具体的new操作的过程，返回一个新的对
//象，有的时候我们通过这样的创建工厂创建对象不值得，特别是以下的几个场景的时候，可能使用原型模式更简单也效率更高。

    /* 原型模式 一
    //public interface IClone<T>
    // {
    //     T Clone();
    // }

    //public class Player : IClone<Player>
    //{
    //    public Player Clone()
    //    {
    //        return MemberwiseClone() as Player;
    //    }
    //}

    //public abstract class Chess : IClone<Chess>
    //{
    //    protected string _type;
    //    public Chess Clone()
    //    {
    //        return MemberwiseClone() as Chess;
    //    }
    //    public override string ToString()
    //    {
    //        return _type;
    //    }
    //}

    //public class I_Go : Chess
    //{
    //    public I_Go()
    //    {
    //        _type = "I-GO";
    //    }
    //}

    //public class ChinaChess : Chess
    //{
    //    public ChinaChess()
    //    {
    //        _type = "ChinaChess";
    //    }
    //}
    //public class Game
    //{
    //    public static void Run(Player player, Chess chess)
    //    {
    //        Player player1 = player.Clone();
    //        Player player2 = player.Clone();
    //        Chess chess1 = chess.Clone();
    //        Console.WriteLine("Two players are playing {0}", chess1.ToString());
    //    }
    //}*/

    /// <summary> 
    /// 杯子类 
    /// </summary> 
    public class Cup : ICloneable
    {
        private double _rl;
        private int _height;
        private Factory _factory;

        public Cup()
        {
            _factory = new Factory();
        }

    /// <summary> 
    /// 高度 
    /// </summary> 
    public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        /// <summary> 
        /// 容量 
        /// </summary> 
        public double RL
        {
            get
            {
                return _rl;
            }
            set
            {
                _rl = value;
            }
        }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public Factory Factory
        {
            get
            {
                return _factory;
            }
            set
            {
                _factory = value;
            }
        }

        #region ICloneable 成员

        //浅复制 浅复制也是在副本中重新创建的成员，对应到内存的栈上，分配新的内存空间，引用类型则因为浅复制的时候，对象和对象副本共用同一个引用对象
        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}

        // 深复制 不管是值类型的成员还是引用类型的成员，这样的对象和对象副本，对任何一个成员属性的修改，都不会影响到改变对象的
        public object Clone()
        {
            Cup cup = (Cup)this.MemberwiseClone();
            Factory factory1 = new Factory();
            factory1.FactoryName = cup.Factory.FactoryName;
            cup.Factory = factory1;

            return cup;
        }
        #endregion 

    }

    public class Factory
    {
        private string factoryName;
        public string FactoryName
        {
            get
            {
                return this.factoryName;
            }
            set
            {
                this.factoryName = value;
            }
        }
    }


    #region 原型模式之线复制的实现
    public interface IColorDemo
    {
        IColorDemo Clone();

        int Red
        {
            get;
            set;
        }
        int Green
        {
            get;
            set;
        }
        int Blue
        {
            get;
            set;
        }
    }
    public class RedColor : IColorDemo
    {
        private int red;
        private int green;
        private int blue;
        public int Red
        {
            get
            {
                return this.red;
            }
            set
            {
                this.red = value;
            }
        }
        public int Green
        {
            get
            {
                return this.green;
            }
            set
            {
                this.green = value;
            }
        }
        public int Blue
        {
            get
            {
                return this.blue;
            }
            set
            {
                this.blue = value;
            }
        }

        #region IColorDemo 成员

        public IColorDemo Clone()
        {
            return (IColorDemo)this.MemberwiseClone();
        }

        #endregion 
    }
    #endregion

    #region 原型模式之深复制的实现

    /// <summary> 
    /// 序列化和反序列化辅助类 
    /// </summary> 
    /// <summary>
    /// 序列化和反序列化辅助类
    /// </summary>
    public class SerializableHelper
    {
        public static string Serializable(object target)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, target);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static object Derializable(string target)
        {
            byte[] targetArray = Convert.FromBase64String(target);

            using (MemoryStream stream = new MemoryStream(targetArray))
            {
                return new BinaryFormatter().Deserialize(stream);
            }
        }

        public static T Derializable<T>(string target)
        {
            return (T)Derializable(target);
        }
    }

    public interface IColorDemo2
    {
        IColorDemo2 Clone();
        

        int Red
        {
            get;
            set;
        }
        int Green
        {
            get;
            set;
        }
        int Blue
        {
            get;
            set;
        }
    }

    public class RedColor2 : IColorDemo2
    {
        private int red;
        private int green;
        private int blue;
        public int Red
        {
            get
            {
                return this.red;
            }
            set
            {
                this.red = value;
            }
        }
        public int Green
        {
            get
            {
                return this.green;
            }
            set
            {
                this.green = value;
            }
        }
        public int Blue
        {
            get
            {
                return this.blue;
            }
            set
            {
                this.blue = value;
            }
        }

        #region IColorDemo 成员

        public IColorDemo2 Clone()
        {
            string target = SerializableHelper.Serializable(this);
            return SerializableHelper.Derializable<IColorDemo2>(target);
        }

        #endregion 
    }
    #endregion 
    class Program
    {
        static void Main(string[] args)
        {
            Cup cup = new Cup();
            cup.Height = 2;
            Cup cup1 = (Cup)cup.Clone();
            cup1.Height = 1;
            cup1.Factory.FactoryName = "AAA";
            Console.WriteLine(cup.Height == cup1.Height);
            Console.WriteLine(cup.Factory == cup1.Factory);
           

            //颜色

            IColorDemo color = new RedColor();
            color.Red = 255;

            IColorDemo color1 = color.Clone();
            color1.Blue = 255;
            Console.WriteLine(color.Blue == color1.Blue);

            IColorDemo2 color2 = new RedColor2();
            color.Red = 255;

            IColorDemo2 color3 = color2.Clone();
            color2.Blue = 252;
            Console.WriteLine(color2.Blue == color3.Blue);


            Console.ReadKey();
        }
    }

}
