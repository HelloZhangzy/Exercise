using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 状态模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account("段誉", 0.0);
            acc.deposit(1000);
            acc.withdraw(2000);
            acc.deposit(3000);
            acc.withdraw(4000);
            acc.withdraw(1000);
            acc.computeInterest();
            Console.ReadKey();
        }
    }


    //银行账户：环境类  
    class Account
    {
        private AccountState state; //维持一个对抽象状态对象的引用  
        private String owner; //开户名  
        private double balance = 0; //账户余额  

        public Account(String owner, double init)
        {
            this.owner = owner;
            this.balance = init;
            this.state = new NormalState(this); //设置初始状态  
            Console.WriteLine(this.owner + "开户，初始金额为" + init);
            Console.WriteLine("---------------------------------------------");
        }

        public double getBalance()
        {
            return this.balance;
        }

        public void setBalance(double balance)
        {
            this.balance = balance;
        }

        public void setState(AccountState state)
        {
            this.state = state;
        }

        public void deposit(double amount)
        {
            Console.WriteLine(this.owner + "存款" + amount);
            state.deposit(amount); //调用状态对象的deposit()方法  
            Console.WriteLine("现在余额为" + this.balance);
            Console.WriteLine("现在帐户状态为" + this.state.GetType().ToString());
            Console.WriteLine("---------------------------------------------");
        }

        public void withdraw(double amount)
        {
            Console.WriteLine(this.owner + "取款" + amount);
            state.withdraw(amount); //调用状态对象的withdraw()方法  
            Console.WriteLine("现在余额为" + this.balance);
            Console.WriteLine("现在帐户状态为" + this.state.GetType().ToString());
            Console.WriteLine("---------------------------------------------");
        }

        public void computeInterest()
        {
            state.computeInterest(); //调用状态对象的computeInterest()方法  
        }
    }

    //抽象状态类  
    abstract class AccountState
    {
        public Account acc;
        public abstract void deposit(double amount);
        public abstract void withdraw(double amount);
        public abstract void computeInterest();
        public abstract void stateCheck();
    }

    //正常状态：具体状态类  
    class NormalState : AccountState
    {
        public NormalState(Account acc)
        {
            this.acc = acc;
        }

        public NormalState(AccountState state)
        {
            this.acc = state.acc;
        }

        public override void deposit(double amount)
        {
            acc.setBalance(acc.getBalance() + amount);
            stateCheck();
        }

        public override void withdraw(double amount)
        {
            acc.setBalance(acc.getBalance() - amount);
            stateCheck();
        }

        public override void computeInterest()
        {
            Console.WriteLine("正常状态，无须支付利息！");
        }

        //状态转换  
        public override void stateCheck()
        {
            if (acc.getBalance() > -2000 && acc.getBalance() <= 0)
            {
                acc.setState(new OverdraftState(this));
            }
            else if (acc.getBalance() == -2000)
            {
                acc.setState(new RestrictedState(this));
            }
            else if (acc.getBalance() < -2000)
            {
                Console.WriteLine("操作受限！");
            }
        }
    }

    //透支状态：具体状态类  
    class OverdraftState : AccountState
    {
        public OverdraftState(AccountState state)
        {
            this.acc = state.acc;
        }

        public override void deposit(double amount)
        {
            acc.setBalance(acc.getBalance() + amount);
            stateCheck();
        }

        public override void withdraw(double amount)
        {
            acc.setBalance(acc.getBalance() - amount);
            stateCheck();
        }

        public override void computeInterest()
        {
            Console.WriteLine("计算利息！");
        }

        //状态转换  
        public override void stateCheck()
        {
            if (acc.getBalance() > 0)
            {
                acc.setState(new NormalState(this));
            }
            else if (acc.getBalance() == -2000)
            {
                acc.setState(new RestrictedState(this));
            }
            else if (acc.getBalance() < -2000)
            {
                Console.WriteLine("操作受限！");
            }
        }
    }

    //受限状态：具体状态类  
    class RestrictedState : AccountState
    {
        public RestrictedState(AccountState state)
        {
            this.acc = state.acc;
        }

        public override void deposit(double amount)
        {
            acc.setBalance(acc.getBalance() + amount);
            stateCheck();
        }

        public override void withdraw(double amount)
        {
            Console.WriteLine("帐号受限，取款失败");
        }

        public override void computeInterest()
        {
            Console.WriteLine("计算利息！");
        }

        //状态转换  
        public override void stateCheck()
        {
            if (acc.getBalance() > 0)
            {
                acc.setState(new NormalState(this));
            }
            else if (acc.getBalance() > -2000)
            {
                acc.setState(new OverdraftState(this));
            }
        }
    }
}
