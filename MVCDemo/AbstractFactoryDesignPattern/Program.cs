using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignPattern
{
    /// <summary>
    /// Abstract Factory Pattern demo.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory honda = new HondaFactory();
            VehicleClient hondaClient = new VehicleClient(honda, "Regular");

            Console.WriteLine("****************Honda************");
            Console.WriteLine(hondaClient.GetBikeName());
            Console.WriteLine(hondaClient.GetScooterName());

            hondaClient = new VehicleClient(honda, "Sports");
            Console.WriteLine(hondaClient.GetBikeName());
            Console.WriteLine(hondaClient.GetScooterName());

            VehicleFactory hero = new HeroFactory();
            VehicleClient heroClient = new VehicleClient(hero, "Regular");

            Console.WriteLine("***********************Hero*******************");
            Console.WriteLine(heroClient.GetBikeName());
            Console.WriteLine(heroClient.GetScooterName());

            heroClient = new VehicleClient(hero, "Sports");
            Console.WriteLine(heroClient.GetBikeName());
            Console.WriteLine(heroClient.GetScooterName());

            Console.ReadKey();
        }
    }

    public class A
    {
        public virtual void Print()
        {
            Console.WriteLine("Class A Method");
        }
    }

    public class B : A
    {
        public override void Print()
        {
            Console.WriteLine("B class implementation");
        }
    }

    public class C : A
    {
        public override void Print()
        {
            Console.WriteLine("C class implementation");
        }
    }

    public class D 
    {
       
    }
}
