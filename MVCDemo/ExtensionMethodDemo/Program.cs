using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethodLib;

namespace ExtensionMethodDemo
{
    public static class Demo
    {
        //It is not allowed. this will be never called.
        public static void Display(this ExMethodDemo obj)
        {
            Console.WriteLine("Hello i am extension method");
        }
        public static void NewMethod(this ExMethodDemo obj)
        {
            Console.WriteLine("Hello i am extension method");
        }
    }

    public static class Extension
    {
        public static int WordCount(this string str)
        {
            string[] userString = str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = userString.Length;
            return wordCount;
        }

        public static int TotalCharWithoutSpace(this string str)
        {
            int totalCharWithoutSpace = 0;
            string[] userString = str.Split(' ');
            foreach(string stringValue in userString)
            {
                totalCharWithoutSpace += stringValue.Length;
            }
            return totalCharWithoutSpace;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ExMethodDemo objet = new ExMethodDemo();
            objet.Display();
            objet.Print();
            objet.NewMethod();
            Console.ReadLine();

            //Extension Class MEthod.
            string userSentence = string.Empty;
            int totalWords = 0;
            int totalCharWithoutSpace = 0;
            Console.WriteLine("Enter your Sentence to count: ");
            userSentence = Console.ReadLine();

            //calling Extension method WordCount.
            totalWords = userSentence.WordCount();
            Console.WriteLine("Total Number of words is: " + totalWords);
            //Calling Extension method to count character.
            totalCharWithoutSpace = userSentence.TotalCharWithoutSpace();
            Console.WriteLine("Total number of character without space: " + totalCharWithoutSpace);
            Console.ReadLine();
        }
    }
}
