using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignPattern
{
    public class Factory
    {

    }
    /// <summary>
    /// The 'AbstractFactory' interface.
    /// </summary>
    public interface VehicleFactory
    {
        Bike GetBike(string bike);
        Scooter GetScooter(string scooter);
    }
    /// <summary>
    /// The 'AbstractProductA' interface.
    /// </summary>
    public interface Bike
    {
        string Name();
    }
    /// <summary>
    /// The 'AbstractProductB' interface.
    /// </summary>
    public interface Scooter
    {
        string Name();
    }
    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    public class HondaFactory : VehicleFactory
    {
        public Bike GetBike(string bike)
        {
            switch(bike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle {0} cannot be created.", nameof(bike)));
            }
        }

        public Scooter GetScooter(string scooter)
        {
            switch(scooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle {0} cannot be created.", nameof(scooter)));
            }
        }
    }
    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    public class HeroFactory: VehicleFactory
    {
        public Bike GetBike(string bike)
        {
            switch(bike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle {0} cannot be created.", nameof(bike)));

            }
        }

        public Scooter GetScooter(string scooter)
        {
            switch(scooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle {0} cannot be created.", nameof(scooter)));
            }
        }
    }

    public class SportsBike : Bike
    {
        public string Name()
        {
            return "Sports Bike - Name";
        }
    }

    public class RegularBike : Bike
    {
        public string Name()
        {
            return "Regular Bike - Name";
        }
    }
    /// <summary>
    /// The 'ProductB2' Class.
    /// </summary>
    public class RegularScooter : Scooter
    {
        public string Name()
        {
            return "Regular Scooter name";
        }
    }
    /// <summary>
    /// The 'ProductClassB2' class.
    /// </summary>
    public class Scooty: Scooter
    {
        public string Name()
        {
            return "SCooty Name";
        }
    }
    /// <summary>
    /// The 'Client' class.
    /// </summary>
    public class VehicleClient
    {
        Bike bike;
        Scooter scooter;
        public VehicleClient(VehicleFactory factory, string type)
        {
            bike = factory.GetBike(type);
            scooter = factory.GetScooter(type);
        }

        public string GetBikeName()
        {
            return bike.Name();
        }
        public string GetScooterName()
        {
            return scooter.Name();
        }
    }

}
