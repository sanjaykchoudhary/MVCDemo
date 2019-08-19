using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignCardDemo
{
    /// <summary>
    /// Factory Pattern demo.
    /// </summary>
    class Program
    {   
        static void Main(string[] args)
        {
            CardFactory factory = null;
            Console.WriteLine("Enter the card type you would like to visit: ");
            string card = Console.ReadLine();
            switch (card.ToLower())
            {
                case "moneyback":
                    factory = new MoneyBackFactory(50000, 0);
                    break;
                case "titanium":
                    factory = new TitaniumFactory(100000, 500);
                    break;
                case "platinum":
                    factory = new PlatinumFactory(500000, 1000);
                    break;
                default:
                    break;
            }
            CreditCard creditCard = factory.GetCreditCard();
            Console.WriteLine("\n Your card details are below: \n");
            Console.WriteLine("Credit Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}\n", creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);
            Console.ReadLine();
        }
    }
    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    public abstract class CreditCard
    {
        public abstract string CardType { get; }
        public abstract int CreditLimit { get; set; }
        public abstract int AnnualCharge { get; set; }
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class MoneyBackCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;
        public MoneyBackCreditCard(int creditLimit, int annualCharge)
        {
            this._cardType = "MoneyBack";
            this._creditLimit = creditLimit;
            this._annualCharge = annualCharge;
        }
        public override string CardType
        {
            get { return _cardType; }
        }
        public override int CreditLimit
        {
            get { return _creditLimit; }

            set { _creditLimit = value; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }

            set { _annualCharge = value; }
        }
    }
    /// <summary>
    /// A 'ConcreteProduct class'
    /// </summary>
    public class TitaniumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;

        public TitaniumCreditCard(int creditLimit, int annualCharge)
        {
            this._cardType = "Titanium";
            this._creditLimit = creditLimit;
            this._annualCharge = annualCharge;
        }
        public override string CardType
        {
            get { return _cardType; }
        }
        public override int CreditLimit
        {
            get { return _creditLimit; }

            set { _creditLimit = value; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }

            set { _annualCharge = value; }
        }
    }
    /// <summary>
    /// A 'ConcreteProduct' class.
    /// </summary>
    public class PlatinumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;
        public PlatinumCreditCard(int creditLimit, int annualCharge)
        {
            this._cardType = "Platinum";
            this._creditLimit = creditLimit;
            this._annualCharge = annualCharge;
        }
        public override string CardType
        {
            get { return _cardType; }
        }
        public override int CreditLimit
        {
            get { return _creditLimit; }

            set { _creditLimit = value; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }

            set { _annualCharge = AnnualCharge; }
        }
    }
    /// <summary>
    /// The 'Creator' abstract class.
    /// </summary>
    public abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }
    /// <summary>
    /// A ConcreteCreator class.
    /// </summary>
    public class MoneyBackFactory: CardFactory
    {
        private int _creditLimit;
        private int _annualCharge;
        public MoneyBackFactory(int creditLimit, int annualCharge)
        {
            this._creditLimit = creditLimit;
            this._annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new MoneyBackCreditCard(_creditLimit, _annualCharge);
        }
    }
    /// <summary>
    /// The ConcreteCreator Class.
    /// </summary>
    public class TitaniumFactory : CardFactory
    {
        private int _creditLimit;
        private int _annualCharge;
        public TitaniumFactory(int creditLimit, int annualCharge)
        {
            this._creditLimit = creditLimit;
            this._annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new TitaniumCreditCard(_creditLimit, _annualCharge);
        }
    }
    /// <summary>
    /// A ConcreteCreator Class
    /// </summary>
    public class PlatinumFactory : CardFactory
    {
        private int _creditLimit;
        private int _annualCharge;
        public PlatinumFactory(int creditLimit,int annualCharge)
        {
            this._creditLimit = creditLimit;
            this._annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new PlatinumCreditCard(_creditLimit, _annualCharge);
        }
    }
}
