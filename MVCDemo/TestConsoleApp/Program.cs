using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************Parent p = new Parent(2, 3);****************************");
            Console.WriteLine("*******************************p.Display()****************************");
            Parent p = new Parent("2", "3");
            p.Display();

            Console.WriteLine("******************************((Child)pc).Show();*****************************");
            Console.WriteLine("((Child)pc).Show();");
            ((Child)p).Display();
            ((Child)p).Show();

            Console.WriteLine("*******************************Child c = new Child(4, 5);****************************");
            Child c = new Child("4", "5");
            c.Show();
            Console.WriteLine("*******************************((Parent)c).Display()****************************");
            Console.WriteLine("((Parent)c).Display()");
            ((Parent)c).Display();



            Console.WriteLine("*******************************((Child)pc).Show();****************************");
            Console.WriteLine("((Child)pc).Show();");
            ((Sibling)p).Display();
            ((Sibling)p).Show();
            ((Sibling)p).Print();

            

            Parent pc = new Child("6", "7");
            pc.Display();

            Child cc = ((Child)pc);
           
            ((Child)pc).Show();
            Console.WriteLine("((Child)pc).Show();");
            ((Child)pc).Display();

            Parent pcs = new Sibling("8", "9");
            pcs.Display();

            ((Child)pcs).Display();
            ((Child)pcs).Show();

            ((Sibling)pcs).Print();
            ((Sibling)pcs).Show();
            ((Sibling)pcs).Display();

            Sibling s = ((Sibling)cc);
            s.Display();
            s.Show();
            s.Print();


            Console.ReadLine();

        }
    }

   public class TestBase
    {
        public TestBase()
        {
            Console.WriteLine("Default constructor");
        }

        public virtual void TestMethod()
        {
            Console.WriteLine("Sealed method.");
        }
    }

    public class TestDerived : TestBase
    {
        //Derived class can't be more accessible than Base class.
        //means base class can't be internal and at the same time,
        //Derived class can't be public,
        public sealed override void TestMethod()
        {
            Console.WriteLine("Sealed method.");
        }

    }

    public class Parent
    {
        public string b;
        public string c;
        public Parent(string a, string c)
        {
            b = a;
            this.c = c;
            Console.WriteLine("Parent Constructor");
        }
        private void DisplayPrivate()
        {
            Console.WriteLine("Parent class implementation.");
            Console.WriteLine("B={0}", b);
            Console.WriteLine("C={0}", c);
        }

        public void Display()
        {
            Console.WriteLine("Parent class implementation.");
            Console.WriteLine("B={0}" , b);
            Console.WriteLine("C={0}" , c);
        }
    }
    public class Child : Parent
    {
        public string d;
        public string e;
        public Child(string c, string w) : base(c, w)
        {

        }
        public void Show()
        {
            Console.WriteLine("Child implemented");
            Console.WriteLine("C: ", c);
            Console.WriteLine("W: ", e);
        }
    }
    public class Sibling : Child
    {
        public string f;
        public string g;
        public Sibling(string r, string d): base(r, d) { }
        public void Print()
        {
            Console.WriteLine("Sibling implemented.");
            Console.WriteLine("F: ", f);
            Console.WriteLine("G: ", g);
        }
    }
}
