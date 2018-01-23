using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver wjzhang, gyang, jguo, meeting,rhuang;
            wjzhang = new Director("张无忌");
            gyang = new VicePresident("杨过");
            jguo = new President("郭靖");
            meeting = new Congress("董事会");
            rhuang = new Manager("黄蓉");

            //创建职责链  
            wjzhang.setSuccessor(rhuang);
            rhuang.setSuccessor(gyang);
            gyang.setSuccessor(jguo);
            jguo.setSuccessor(meeting);            

            //创建采购单  
            PurchaseRequest pr1 = new PurchaseRequest(45000, 10001, "购买倚天剑");
            wjzhang.processRequest(pr1);

            PurchaseRequest pr2 = new PurchaseRequest(60000, 10002, "购买《葵花宝典》");
            wjzhang.processRequest(pr2);

            PurchaseRequest pr3 = new PurchaseRequest(160000, 10003, "购买《金刚经》");
            wjzhang.processRequest(pr3);

            PurchaseRequest pr4 = new PurchaseRequest(800000, 10004, "购买桃花岛");
            wjzhang.processRequest(pr4);
            Console.ReadKey();
        }
    }

    //采购单：请求类
    class PurchaseRequest
    {
        private double amount;  //采购金额  
        private int number;  //采购单编号  
        private String purpose;  //采购目的  

        public PurchaseRequest(double amount, int number, String purpose)
        {
            this.amount = amount;
            this.number = number;
            this.purpose = purpose;
        }

        public void setAmount(double amount)
        {
            this.amount = amount;
        }

        public double getAmount()
        {
            return this.amount;
        }

        public void setNumber(int number)
        {
            this.number = number;
        }

        public int getNumber()
        {
            return this.number;
        }

        public void setPurpose(String purpose)
        {
            this.purpose = purpose;
        }

        public String getPurpose()
        {
            return this.purpose;
        }
    }

    //审批者类：抽象处理者  
    abstract class Approver
    {
        protected Approver successor; //定义后继对象  
        protected string name; //审批者姓名  

        public Approver(string name)
        {
            this.name = name;
        }

        //设置后继者  
        public void setSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        //抽象请求处理方法  
        public abstract void processRequest(PurchaseRequest request);       
    }

    //主任类：具体处理者  
    class Director : Approver
    {
        public Director(string name) : base(name)
        {

        }

        public override void processRequest(PurchaseRequest request)
        {
            if (request.getAmount() < 50000)
            {
                Console.WriteLine("主任" + this.name + "审批采购单：" + request.getNumber() + "，金额：" + request.getAmount() + "元，采购目的：" + request.getPurpose() + "。");
                // System.out.println("主任" + this.name + "审批采购单：" + request.getNumber() + "，金额：" + request.getAmount() + "元，采购目的：" + request.getPurpose() + "。");  //处理请求  
            }
            else
            {
                this.successor.processRequest(request);  //转发请求  
            }
        }       
    }

    //副董事长类：具体处理者  
    class VicePresident : Approver
    {
        public VicePresident(string name) : base(name)
        {            
        }

        //具体请求处理方法  
        public override void processRequest(PurchaseRequest request)
        {
            if (request.getAmount() < 100000)
            {
                Console.WriteLine("副董事长" + this.name + "审批采购单：" + request.getNumber() + "，金额：" + request.getAmount() + "元，采购目的：" + request.getPurpose() + "。");  //处理请求  
            }
            else
            {
                this.successor.processRequest(request);  //转发请求  
            }
        }
    }

    //董事长类：具体处理者  
    class President : Approver
    {
        public President(string name) : base(name)
        {
            
        }

        //具体请求处理方法  
        public override void processRequest(PurchaseRequest request)
        {
            if (request.getAmount() < 500000)
            {
                Console.WriteLine("董事长" + this.name + "审批采购单：" + request.getNumber() + "，金额：" + request.getAmount() + "元，采购目的：" + request.getPurpose() + "。");  //处理请求  
            }
            else
            {
                this.successor.processRequest(request);  //转发请求  
            }
        }
    }

    //董事会类：具体处理者  
    class Congress : Approver
    {
        public Congress(string name) : base(name)
        {
           
        }

        //具体请求处理方法  
        public override void processRequest(PurchaseRequest request)
        {
            Console.WriteLine("召开董事会审批采购单：" + request.getNumber() + "，金额：" + request.getAmount() + "元，采购目的：" + request.getPurpose() + "。");        //处理请求  
        }
    }

    //经理类：具体处理者  
    class Manager : Approver
    {
        public Manager(String name) : base(name)
        {

        }

        //具体请求处理方法  
        public override void processRequest(PurchaseRequest request)
        {
            if (request.getAmount() < 80000)
            {
                Console.WriteLine("经理" + this.name + "审批采购单：" + request.getNumber() + "，金额：" + request.getAmount() + "元，采购目的：" + request.getPurpose() + "。");  //处理请求  
            }
            else
            {
                this.successor.processRequest(request);  //转发请求  
            }
        }
    } 
}
