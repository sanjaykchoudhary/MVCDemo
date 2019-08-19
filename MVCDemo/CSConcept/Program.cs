using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            


            ConstVariableTest cobj = new ConstVariableTest();
            cobj.MethodA();
            ConstVariableTest cobjp = new ConstVariableTest(45);
            cobjp.MethodA();
            Console.WriteLine("***********************************Shallow copy and Deep copy*********************8");
            Company companySource = new Company(234, "HP", "HP");
            Console.WriteLine("***********************************Shallow copy*********************8");
            Company companyShallow = (Company)companySource.ShalloCopy();
            Console.WriteLine("Company source");
            Console.WriteLine("GBRank: " + companySource.GbRank);
            Console.WriteLine("Name: " + companySource.desc.companyname);
            Console.WriteLine("Owner: " + companySource.desc.owner);
            Console.WriteLine("Company Target");
            Console.WriteLine("GBRank: " + companyShallow.GbRank);
            Console.WriteLine("Name: " + companyShallow.desc.companyname);
            Console.WriteLine("Owner: " + companyShallow.desc.owner);
            companySource.desc.companyname = "CSC";
            companySource.desc.owner = "CSC";
            Console.WriteLine("Company Target");
            Console.WriteLine("GBRank: " + companyShallow.GbRank);
            Console.WriteLine("Name: " + companyShallow.desc.companyname);
            Console.WriteLine("Owner: " + companyShallow.desc.owner);


            Console.WriteLine("***********************************Deep copy*********************8");
            Company companyTarget = (Company)companySource.Clone();
            Console.WriteLine("Company source");
            Console.WriteLine("GBRank: " + companySource.GbRank);
            Console.WriteLine("Name: " + companySource.desc.companyname);
            Console.WriteLine("Owner: " + companySource.desc.owner);
            Console.WriteLine("Company Target");
            Console.WriteLine("GBRank: " + companyTarget.GbRank);
            Console.WriteLine("Name: " + companyTarget.desc.companyname);
            Console.WriteLine("Owner: " + companyTarget.desc.owner);

            companySource = new Company(456, "DXC", "DS");
            Console.WriteLine("GBRank: " + companySource.GbRank);
            Console.WriteLine("Name: " + companySource.desc.companyname);
            Console.WriteLine("Owner: " + companySource.desc.owner);

            Console.WriteLine("Company Target");
            Console.WriteLine("GBRank: " + companyTarget.GbRank);
            Console.WriteLine("Name: " + companyTarget.desc.companyname);
            Console.WriteLine("Owner: " + companyTarget.desc.owner);

            ShallowCopy shalloSource = new ShallowCopy(30, "Raman");
            ShallowCopy shalloTarget = (ShallowCopy)shalloSource.GetShallowCopy();
            Console.WriteLine("*******Shallow copy********");
            Console.WriteLine("Age: " + shalloSource.age);
            Console.WriteLine("Name: " + shalloSource.p.name);
            Console.WriteLine("*******Target********");
            Console.WriteLine("Age: " + shalloTarget.age);
            Console.WriteLine("Name: " + shalloTarget.p.name);

            shalloSource.p.name = "Ramu";
            Console.WriteLine("Age: " + shalloTarget.age);
            Console.WriteLine("Name: " + shalloTarget.p.name);


            Console.ReadKey();
        }
    }

    public class ConstVariableTest: A
    {
        const string cons = "Constants";
        readonly string reonly = "ReadOnly";
        readonly static string readonlystatic = "Readonlystatic";
       

        public ConstVariableTest() : base()
        {
            base.testa = 23;
            Console.WriteLine("Assigning base abstract class variable value thru derived class " + testa);
            Console.WriteLine("Calling base abstract class constructor thru derived class");
        }
        public ConstVariableTest(int p) : base(p)
        {
            p = 34;
            Console.WriteLine("Calling parameterized constructor from derived P : " + p);
        }
        public void TestConst()
        {
            //cons = "variable";
            //reonly = "readonl";
        }

        public void MethodAB()
        {
            Console.WriteLine("Calling abstract class method");
        }
    }

    public abstract class A
    {
        int absTest;
        public A()
        {
            absTest = 12;
            Console.WriteLine("Abstract class constructor");
        }
        public A(int p)
        {
            absTest = p;
            Console.WriteLine("Calling parameterized constructor P: " + p);
        }
        public int testa;
        public  void MethodA()
        {
            Console.WriteLine("non-abstract method");
        }
    }

    

    public class Company : ICloneable
    {
        public int GbRank;
        public CompanyDescription desc;
        public Company(int gbrank, string c, string o)
        {
            this.GbRank = gbrank;
            desc = new CompanyDescription(c, o);
        }

        //Method for cloning object.
        public object ShalloCopy()
        {
            return this.MemberwiseClone();
        }

        //Method for cloning or deep cloning.       
        public object Clone()
        {
            Company company = new Company(this.GbRank, desc.companyname, desc.owner);
            return company;
        }
    }

    public class CompanyDescription
    {
       public string companyname, owner;
        public CompanyDescription(string c, string o)
        {
            this.companyname = c;
            this.owner = o;
        }
    }

    public class ShallowCopy
    {
       public int age;
       public Person p;
        public ShallowCopy(int age, string name)
        {
            this.age = age;
            p = new Person(name);
        }
        public object GetShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }

    public class DeepCopy : ICloneable
    {
        public int age;
        public Person p;
        public DeepCopy(int age, string name)
        {
            this.age = age;
            p = new Person(name);
        }
        public object Clone()
        {
            Person p = new Person(p.name);
            return p;
        }
    }
    public class Person
    {
        public string name;
        public Person(string name)
        {
            this.name = name;
        }
    }
}
