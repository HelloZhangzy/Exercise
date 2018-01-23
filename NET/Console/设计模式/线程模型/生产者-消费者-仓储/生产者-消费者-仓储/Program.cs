using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 生产者_消费者_仓储
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }


    /** 
 * 仓库  
 */
    public class Godown
    {

        public const int max_size = 100;  //最大库存量  
        public int curnum;   //当前库存量  

        Godown()
        {

        }
        Godown(int curnum)
        {
            this.curnum = curnum;
        }

        /** 
        * 生产指定数量的产品  
        * @param neednum 
        */
        public  void produce(int neednum)
        {
            lock(this)
            { 
            //测试是否需要生产  
            while (neednum + curnum > max_size)
            {
                Console.WriteLine("要生产的产品数量" + neednum + "超过剩余库存量" + (max_size - curnum) + "，暂时不能执行生产任务!");
                try
                {
                    //当前的生产线程等待  
                    //wait();
                }
                catch (Exception e)
                {
                        Console.WriteLine(e.Message);
                }
            }
            //满足生产条件，则进行生产，这里简单的更改当前库存量  
            curnum += neednum;
            Console.WriteLine("已经生产了" + neednum + "个产品，现仓储量为" + curnum);
                //唤醒在此对象监视器上等待的所有线程  
                //notifyAll();
            }
        }

        /** 
         * 消费指定数量的产品  
         * @param neednum 
         */
        public  void consume(int neednum)
        {
            lock(this)
            { 
            //测试是否可消费  
            while (curnum < neednum)
            {
                try
                {
                    //wait();
                }
                catch (Exception e)
                {
                        Console.WriteLine(e.Message);
                }
            }
            //满足消费条件，则进行消费，这里简单的更改当前库存量  
            curnum -= neednum;
            Console.WriteLine("已经消费了" + neednum + "个产品，现仓储量为" + curnum);
            //唤醒在此对象监视器上等待的所有线程  
            //notifyAll();
            }
        }
    }
}
