using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface Button
    {
        void display();
    }

    //Spring按钮类：具体产品  
    class SpringButton : Button
    {
        public void display()
        {
            Console.WriteLine("显示浅绿色按钮。");
        }
    }

    //Summer按钮类：具体产品  
    class SummerButton : Button
    {
        public void display()
        {
            Console.WriteLine("显示浅蓝色按钮。");
        }
    }

    //文本框接口：抽象产品  
    interface TextField
    {
        void display();
    }

    //Spring文本框类：具体产品  
    class SpringTextField : TextField
    {
        public void display()
        {
            Console.WriteLine("显示绿色边框文本框。");
        }
    }

    //Summer文本框类：具体产品  
    class SummerTextField : TextField
    {
        public void display()
        {
            Console.WriteLine("显示蓝色边框文本框。");
        }
    }

    //组合框接口：抽象产品  
    interface ComboBox
    {
        void display();
    }

    //Spring组合框类：具体产品  
    class SpringComboBox : ComboBox
    {
        public void display()
        {
            Console.WriteLine("显示绿色边框组合框。");
        }
    }

    //Summer组合框类：具体产品  
    class SummerComboBox : ComboBox
    {
        public void display()
        {
            Console.WriteLine("显示蓝色边框组合框。");
        }
    }

    //界面皮肤工厂接口：抽象工厂  
    interface SkinFactory
    {
        Button createButton();
        TextField createTextField();
        ComboBox createComboBox();
    }

    //Spring皮肤工厂：具体工厂  
    class SpringSkinFactory : SkinFactory
    {
        public Button createButton()
        {
            return new SpringButton();
        }

        public TextField createTextField()
        {
            return new SpringTextField();
        }

        public ComboBox createComboBox()
        {
            return new SpringComboBox();
        }
    }

    //Summer皮肤工厂：具体工厂  
    class SummerSkinFactory : SkinFactory
    {
        public Button createButton()
        {
            return new SummerButton();
        }

        public TextField createTextField()
        {
            return new SummerTextField();
        }

        public ComboBox createComboBox()
        {
            return new SummerComboBox();
        }
    }
}
