using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory vehicleFactory = new VehicleFactoryImpl();
            IFactory scooter = vehicleFactory.GetFactory("Scooter");
            scooter.Drive(50);

            IFactory bike = vehicleFactory.GetFactory("Bike");
            bike.Drive(100);

            Console.ReadLine();
        }
    }

    public abstract class VehicleFactory
    {
        public abstract IFactory GetFactory(string vehicle);
    }

    public class VehicleFactoryImpl: VehicleFactory
    {
        public override IFactory GetFactory(string vehicle)
        {
            switch(vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created.", nameof(vehicle)));

            }
        }

    }
}
