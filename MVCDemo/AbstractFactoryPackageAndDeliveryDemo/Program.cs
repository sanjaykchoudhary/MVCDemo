using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPackageAndDeliveryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            GetClientObject();
            Console.ReadLine();
        }
        public static void GetClientObject()
        {
            PacknDelvFactory sf = new StandardFactory();
            Client client = new Client(sf);
            Console.WriteLine(client.ClientPackaging.GetType().ToString());
            Console.WriteLine(client.ClientDocument.GetType().ToString());

            PacknDelvFactory df = new DelicateFactory();
            Client delicate = new Client(df);
            Console.WriteLine(delicate.ClientPackaging.GetType().ToString());
            Console.WriteLine(delicate.ClientDocument.GetType().ToString());            
        }        
    }

    public class Client
    {
        private Packaging _packaging;
        private DeliveryDocument _deliveryDocument;
        public Client(PacknDelvFactory factory)
        {
            _packaging = factory.CreatePackaging();
            _deliveryDocument = factory.CreateDeliveryDocument();
        }
        public Packaging ClientPackaging
        {
            get { return _packaging; }
        }
        public DeliveryDocument ClientDocument
        {
            get { return _deliveryDocument; }
        }
    }

    public abstract class PacknDelvFactory
    {
        public abstract Packaging CreatePackaging();
        public abstract DeliveryDocument CreateDeliveryDocument();
    }

    public class StandardFactory : PacknDelvFactory
    {
        public override Packaging CreatePackaging()
        {
            return new StandardPackaging();
        }
        public override DeliveryDocument CreateDeliveryDocument()
        {
            return new Postal();
        }
    }

    public class DelicateFactory: PacknDelvFactory
    {
        public override Packaging CreatePackaging()
        {
            return new ShockProofPackaging();
        }
        public override DeliveryDocument CreateDeliveryDocument()
        {
            return new Courier();
        }
    }

    public abstract class Packaging { }
    public class StandardPackaging : Packaging { }
    public class ShockProofPackaging : Packaging { }
    public abstract class DeliveryDocument { }
    public class Postal : DeliveryDocument { }
    public class Courier : DeliveryDocument { }
    
}
