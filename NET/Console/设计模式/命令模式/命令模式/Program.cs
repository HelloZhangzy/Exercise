using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Debug 命令模式");
            FBSettingWindow fbsw = new FBSettingWindow("功能键设置");

            FunctionButton fb1, fb2;
            fb1 = new FunctionButton("功能键1");
            fb2 = new FunctionButton("功能键2");

            Command command1, command2;
            //通过读取配置文件和反射生成具体命令对象  
            command1 = new HelpCommand();
            command2 = new MinimizeCommand();
            //将命令对象注入功能键
            fb1.setCommand(command1);
            fb2.setCommand(command2);
            fbsw.addFunctionButton(fb1);
            fbsw.addFunctionButton(fb2);
            fbsw.display();

            //调用功能键的业务方法  
            fb1.onClick();
            fb2.onClick();
            Console.WriteLine("》》-----------------------------");

            FunctionButton2 fb3 = new FunctionButton2("功能设置3");
            CommandQueue cmd = new CommandQueue();
            cmd.addCommand(command1);
            cmd.addCommand(command2);
            fb3.setCommandQueue(cmd);            
            fb3.onClick();

            Console.WriteLine("-----------------------------");
            CalculatorForm form = new CalculatorForm();
            AbstractCommand command;
            command = new ConcreteCommand();
            form.setCommand(command); //向发送者注入命令对象  

            form.compute(10);
            form.compute(5);
            form.compute(10);
            form.undo();

            Console.ReadKey();
        }
    }

    #region 命令模式1
    //功能键设置窗口类  
    class FBSettingWindow
    {
        private String title; //窗口标题  
                              //定义一个ArrayList来存储所有功能键  
        private List<FunctionButton> functionButtons = new List<FunctionButton>();

        public FBSettingWindow(String title)
        {
            this.title = title;
        }

        public void setTitle(String title)
        {
            this.title = title;
        }

        public String getTitle()
        {
            return this.title;
        }

        public void addFunctionButton(FunctionButton fb)
        {
            functionButtons.Add(fb);
        }

        public void removeFunctionButton(FunctionButton fb)
        {
            functionButtons.Remove(fb);
        }

        //显示窗口及功能键  
        public void display()
        {
            Console.WriteLine("显示窗口：" + this.title);
            Console.WriteLine("显示功能键：");
           
            foreach (var obj in functionButtons)
            {
                Console.WriteLine(((FunctionButton)obj).getName());
            }
            Console.WriteLine("------------------------------");
        }
    }

    //命令队列
    class CommandQueue
    {
        //定义一个ArrayList来存储命令队列  
        private List<Command> commands = new List<Command>();

        public void addCommand(Command command)
        {
            commands.Add(command);
        }

        public void removeCommand(Command command)
        {
            commands.Remove(command);
        }

        //循环调用每一个命令对象的execute()方法  
        public void execute()
        {
            foreach (Object command in commands)
            {
                ((Command)command).execute();
            }
        }
    }

    //命令队列模式
    class FunctionButton2
    {
        private CommandQueue commandQueue; //维持一个CommandQueue对象的引用  
        
        //设值注入  
        public void setCommandQueue(CommandQueue commandQueue)
        {
            this.commandQueue = commandQueue;
        }        

        private String name; //功能键名称  
        private Command command; //维持一个抽象命令对象的引用  

        public FunctionButton2(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }    

        //发送请求的方法  
        public void onClick()
        {
            Console.WriteLine("点击功能键：");
            commandQueue.execute();
        }
    }


    //功能键类：请求发送者  
    class FunctionButton
    {
        private String name; //功能键名称  
        private Command command; //维持一个抽象命令对象的引用  

        public FunctionButton(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        //为功能键注入命令  
        public void setCommand(Command command)
        {
            this.command = command;
        }

        //发送请求的方法  
        public void onClick()
        {            
            Console.WriteLine("点击功能键：");            
            command.execute();
        }
    }

    //抽象命令类  
    abstract class Command
    {
        public abstract void execute();
    }

    //帮助命令类：具体命令类
    class HelpCommand : Command
    {
        private HelpHandler hhObj; //维持对请求接收者的引用  

        public HelpCommand()
        {
            hhObj = new HelpHandler();
        }

        //命令执行方法，将调用请求接收者的业务方法  
        public override void execute()
        {
            hhObj.display();
        }
    }

    //最小化命令类：具体命令类  
    class MinimizeCommand : Command
    {
        private WindowHanlder whObj; //维持对请求接收者的引用  

        public MinimizeCommand()
        {
            whObj = new WindowHanlder();
        }

        //命令执行方法，将调用请求接收者的业务方法  
        public override void execute()
        {
            whObj.minimize();
        }
    }

    //窗口处理类：请求接收者  
    class WindowHanlder
    {
        public void minimize()
        {
            Console.WriteLine("将窗口最小化至托盘！");
        }
    }

    //帮助文档处理类：请求接收者  
    class HelpHandler
    {
        public void display()
        {
            Console.WriteLine("显示帮助文档！");
        }
    }

    #endregion

    #region 命令模式之撤销执行
    //加法类：请求接收者  
    class Adder
    {
        private int num = 0; //定义初始值为0  

        //加法操作，每次将传入的值与num作加法运算，再将结果返回  
        public int add(int value)
        {
            num += value;
            return num;
        }
    }

    //抽象命令类  
    abstract class AbstractCommand
    {
        public abstract int execute(int value); //声明命令执行方法execute()  
        public abstract int undo(); //声明撤销方法undo()  
    }

    //具体命令类  
    class ConcreteCommand : AbstractCommand
    {
        private Adder adder = new Adder();
        private int value;

        //实现抽象命令类中声明的execute()方法，调用加法类的加法操作  
        public override int execute(int value)
        {
            this.value = value;
            return adder.add(value);
        }

        //实现抽象命令类中声明的undo()方法，通过加一个相反数来实现加法的逆向操作  
        public override int undo()
        {
            return adder.add(-value);
        }
    }

    //计算器界面类：请求发送者  
    class CalculatorForm
    {
        private AbstractCommand command;

        public void setCommand(AbstractCommand command)
        {
            this.command = command;
        }

        //调用命令对象的execute()方法执行运算  
        public  void compute(int value)
        {
            int i = command.execute(value);
            Console.WriteLine("执行运算，运算结果为：" + i);
        }

        //调用命令对象的undo()方法执行撤销  
        public void undo()
        {
            int i = command.undo();
            Console.WriteLine("执行撤销，运算结果为：" + i);
        }
    }
#endregion
}
