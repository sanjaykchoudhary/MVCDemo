using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //A a = new A();
            //a.Display();
            //B b = new B();
            //B b1 = new B("Consturctor passed with single parameter");
            //Console.WriteLine("Message: "+ b1);
            //Console.WriteLine("***********************************Addition Class*************************");
            //Addition add = new Addition();
            //Console.WriteLine($"A is: {add.a}");
            //Console.WriteLine($"B is: {add.b}");
            //Console.WriteLine("***********************************Addition Class*************************");
            //Shape shape = new Shape(100, 100);
            //shape.Draw();
            //Circle cl = new Circle(200, 200);
            //cl.Draw();
            //Square sq = new Square(120, 120);
            //sq.Draw();

            //Console.WriteLine("***********************************Upcasting Class*************************");
            //Shape sh = new Circle(130, 130);
            //sh.Draw();

            //Shape shsq = new Square(20, 20);
            //shsq.Draw();

            //Console.WriteLine("***********************************Downcasting Class*************************");
            //Shape shc = new Circle(30, 30);
            //((Circle)shc).FillCircle();

            //Circle c;
            //c = (Circle)shc;
            //c.FillCircle();

            Circle c = new Circle();
            c.GetOwnerName();

            Shape s = new Circle();
            s.GetOwnerName();
            
            Console.ReadLine();
        }
    }

    public class Shape
    {
        protected int m_xpos;
        protected int m_ypos;
        public Shape()
        {
            Console.WriteLine($"Parameter less constructor Shape called.");
        }

        public Shape(int x, int y)
        {
            m_xpos = x;
            m_ypos = y;
            Console.WriteLine($"Constructor Shape called at {m_xpos},{m_ypos}");
        }

        public virtual void GetOwnerName()
        {
            Console.WriteLine("From shape base class");
        }

        //public virtual void Draw()
        //{
        //    Console.WriteLine($"Drawing a shape at {m_xpos},{m_ypos}");
        //}
    }

    public class Circle : Shape
    {
        //public Circle()
        //{
        //    Console.WriteLine("Parameter less constructor Circle called.");
        //}
        //public Circle(int x, int y) : base(x, y)
        //{
        //    Console.WriteLine($"Circle constructor called. {x},{y}");
        //}
        public override  void GetOwnerName()
        {
            Console.WriteLine("From Circle class");
        }
        //public override void Draw()
        //{
        //    Console.WriteLine($"Drawing a Circle at {m_xpos},{m_ypos}");
        //}

        //public void FillCircle()
        //{
        //    Console.WriteLine("Filling CIRCLE at {0},{1}", m_xpos, m_ypos);
        //}
    }
    public class CircleChild
    {
        
    }

    public class A
    {
        public A()
        {
            Console.WriteLine("Constructor A called.");
        }
        public A(string msg)
        {
            Console.WriteLine("Constructor A called with single parameter: " + msg);
        }

        public A(int x, int y)
        {
            Console.WriteLine("Constructor A called with double parameter.{0},{1}", x, y);
        }

        public void Display()
        {
            Console.WriteLine("Called with method.");
        }
    }

   public class B : A
    {
        public B() : base("Parent class constructor called from the derived class.")
        {
            Console.WriteLine("Constructor B called");
        }
        public B(string mesg): base(2,3)
        {
            Console.WriteLine("Constructor B called with single parameter. " + mesg);
        }

        public B(string a, string b)
        {
            Console.WriteLine("constructor B called with two parameter.{0}, {1} " + a, b);
        }
    }

    public class Addition
    {
       public int a, b;
        public Addition()
        {
            a = 10;
            b = 12;
        }
    }

    public class Car
    {

    }

    

    public class Square : Shape
    {
        public Square()
        {
            Console.WriteLine("Parameter less constructor Square called.");
        }
        public Square(int x,int y) : base(x, y)
        {
            Console.WriteLine($"Square constructor called.{x},{y}");
        }

        public new void Draw()
        {
            Console.WriteLine($"Drawing a Square at {m_xpos},{m_ypos}");
        }
    }

}
