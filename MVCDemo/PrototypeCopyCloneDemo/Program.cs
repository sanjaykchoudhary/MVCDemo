using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeCopyCloneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Here it is creating the refrence of one object to another.
            //so, test2 also point to same memory location as test1
            //and if we change the test2 data, it will reflect to test1.
            Test test1 = new Test();
            test1.Name = "Sanjay";
            Test test2 = test1; //Trying to make copy in test2.
            test2.Name = "Reference Stored in test2";
            Console.WriteLine("Reference copied: " + test1.Name);


            //Here we are using to create copy of one object data to another.
            TestCopyObject obj1 = new TestCopyObject();
            obj1.Name = "Sanjay";
            TestCopyObject obj2 = obj1.CloneMe(obj1); //Trying to make copy in obj2.
            obj2.Name = "Here we are cloning the obj1";
            Console.WriteLine("Clone of obj1: " + obj1.Name);

            Console.ReadLine();
        }
    }
    /// <summary>
    /// Here we are trying to copy test1 obj to test2 object.
    /// but it will copy the memory location of test1 to test2
    /// means it will copy reference of test1 to test2 and both point to same data.
    /// </summary>
    public class Test
    {
        public string Name;        
    }

    /// <summary>
    /// Here we are copying the contents of one object to another.
    /// </summary>
    public class TestCopyObject
    {
        public string Name;
        public TestCopyObject CloneMe(TestCopyObject test)
        {
            return (TestCopyObject)this.MemberwiseClone();
        }
    }
}
