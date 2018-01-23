using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式之数据计算
{
    public class Complex
    {
        float real;
        float imag;
        public Complex(float r,float i)
        {
            real = r;imag = i;
        }

        public void setReal(float r) { real = r; }
        public void setImag(float i) { imag = i; }
        public float getReal() { return real; }
        public float getImag() { return imag; }
    }

    public abstract class Butterfly
    {
        float y;
        public Butterfly() { }

        public Butterfly(float angle)
        {
            y = angle;  
        }
        abstract public void Execute(Complex x, Complex y);

    }

    class AddButterfly : Butterfly
    {
        float oldrl, oldil;
        public AddButterfly(float angle) { }
        public override void Execute(Complex x, Complex y)
        {
            oldrl = x.getReal();
            oldil = x.getImag();
            x.setReal(oldrl + y.getReal());
            y.setReal(oldrl - y.getReal());
            y.setImag(oldil + y.getImag());
            y.setImag(oldil - y.getImag());
        }
    }

    public class TrigButterfly : Butterfly
    {
        float y, oldrl, oldil;
        float cosy, siny;
        float r2cosy, r2siny, i2cosy, i2siny;
        public TrigButterfly(float angle)
        {
            y = angle;
            cosy = (float)Math.Cos(y);
            siny = (float)Math.Sin(y);
        }
        public override void Execute(Complex x, Complex y)
        {
            oldrl = x.getReal();
            oldil = x.getImag();
            r2cosy = y.getReal() * cosy;
            r2siny = y.getReal() * siny;
            i2cosy = y.getImag() * cosy;
            i2siny = y.getImag() * siny;
            y.setReal(oldrl+r2cosy+i2siny);
            y.setReal(oldil- r2siny + i2cosy);

        }
    }
    public class Cocoon
    {
        public static  Butterfly getButterfly(float y)
        {
            if (y != 0)
            {
                return new TrigButterfly(y);
            }
            else
                return new AddButterfly(y);
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
