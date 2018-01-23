using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Component component, componentSB, componentBB; //全部使用抽象构件定义
            component = new Window();
            componentSB = new ScrollBarDecorator(component);
            componentBB = new BlackBorderDecorator(componentSB); //将装饰了一次之后的对象继续注入到另一个装饰类中，进行第二次装饰
            componentBB.display();
            Console.ReadKey();
        }
    }

    abstract class Component
    {
        public abstract void display();
    }

    //窗体类：具体构件类
    class Window : Component
    {
        public override void display()
        {
            Console.WriteLine("显示窗体！");
        }
    }

    //文本框类：具体构件类
    class TextBox : Component
    {
        public override void display()
        {
            Console.WriteLine("显示文本框！");
        }
    }

    //列表框类：具体构件类
    class ListBox : Component
    {
        public override void display()
        {
            Console.WriteLine("显示列表框！");
        }
    }

    //构件装饰类：抽象装饰类
    class ComponentDecorator : Component
    {
        private Component component;  //维持对抽象构件类型对象的引用

        public ComponentDecorator(Component component)  //注入抽象构件类型的对象
        {
            this.component = component;
        }

        public override void display()
        {
            component.display();
        }
    }

    //滚动条装饰类：具体装饰类
    class ScrollBarDecorator : ComponentDecorator
    {
        public ScrollBarDecorator(Component component) : base(component)
        {

        }

        public override void display()
        {
            this.setScrollBar();
            base.display();
        }

        public void setScrollBar()
        {
            Console.WriteLine("为构件增加滚动条！");
        }
    }

    //黑色边框装饰类：具体装饰类
    class BlackBorderDecorator : ComponentDecorator
    {
        public BlackBorderDecorator(Component component) : base(component)
        {

        }

        public override void display()
        {
            this.setBlackBorder();
            base.display();
        }

        public void setBlackBorder()
        {
            Console.WriteLine("为构件增加黑色边框！");
        }
    }
}
