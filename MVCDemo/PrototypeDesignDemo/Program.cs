using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method.");
            Console.ReadKey();
        }
        static void Main(int s)
        {
            Console.WriteLine("Overloaded main method.");
        }
        static void Main(int k,int y)
        {
            Console.WriteLine("Overloaded main method with 2 parameter");
        }
        
    }
}
