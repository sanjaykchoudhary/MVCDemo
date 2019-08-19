using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepAndShalowCopyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Company c1 = new Company(568, "GeeksForGeek", "Sanjay");
            //Performing shallow copy.
            Company c2 = (Company)c1.ShallowCopy();
            Console.WriteLine("*********Shallow Copy example*********");
            Console.WriteLine("*********Before changing*********");
            //Before changing the value of c2 GBRank and companyRank.
            Console.WriteLine(c1.GBRank);
            Console.WriteLine(c2.GBRank);
            Console.WriteLine(c1.desc.CompanyName);
            Console.WriteLine(c2.desc.CompanyName);

            //Changing the value of GBRank and Company name for c2.
            c2.GBRank = 345;
            c2.desc.CompanyName = "GFG";
            Console.WriteLine("\n************After changing*************");
            //After changing the value of GBRank and company name for c2.
            Console.WriteLine(c1.GBRank);
            Console.WriteLine(c2.GBRank);
            Console.WriteLine(c1.desc.CompanyName);
            Console.WriteLine(c2.desc.CompanyName);

            Console.WriteLine("*********Deep Copy Demo*********");
            Console.WriteLine("********Before Changing***************");
            Company c3 = new Company(234, "GeeksForGeek_Deep", "Sanjay");
            Company c4 = c3.DeepCopy();
            //Before changing the value of c4 GBRank and companyRank.
            Console.WriteLine(c3.GBRank);
            Console.WriteLine(c4.GBRank);
            Console.WriteLine(c3.desc.CompanyName);
            Console.WriteLine(c4.desc.CompanyName);

            //Changing the value of GBRank and Company name for c4.
            c4.GBRank = 345;
            c4.desc.CompanyName = "GFG_deepCopy";
            Console.WriteLine("\n************After changing*************");
            //After changing the value of GBRank and company name for c2.
            Console.WriteLine(c3.GBRank);
            Console.WriteLine(c4.GBRank);
            Console.WriteLine(c3.desc.CompanyName);
            Console.WriteLine(c4.desc.CompanyName);

            Console.ReadKey();

        }
    }
    public class CompanyDescription
    {
        public string CompanyName;
        public string Owner;
        public CompanyDescription(string cn, string o)
        {
            this.CompanyName = cn;
            this.Owner = o;
        }
    }
    public class Company
    {
        public int GBRank;
        public CompanyDescription desc;
        public Company(int gbRank,string cn,string o)
        {
            this.GBRank = gbRank;
            desc = new CompanyDescription(cn, o);
        }
        //Method for cloning object.
        public object ShallowCopy()
        {
            //Creates a shallow copy of the current object.
            return this.MemberwiseClone();
        }
        //Method for cloning object.
        public Company DeepCopy()
        {
            Company deepCopyCompany = new Company(this.GBRank, desc.CompanyName, desc.Owner);
            return deepCopyCompany;
        }
    }
}
