using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinaryFileOp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadWriteBinary();
        }

        

        public void WriteBinary()
        {
            Console.WriteLine("Binary Writer");
            string authorName = "Sanjay Choudhary";
            int age = 30;
            string bookTitle = "ADO.NET Programming using C#";
            bool mvp = true;
            double price = 54.99;

            string fileName = @"C:\Temp\MC.bin";
            BinaryWriter bwStream = new BinaryWriter(new FileStream(fileName, FileMode.Create));
            Encoding ascii = Encoding.ASCII;

        }

        public static void ReadWriteBinary()
        {
            string path = @"C:\Temp\";

            FileStream mfs = new FileStream(path + "test.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(mfs);
            BinaryWriter bw = new BinaryWriter(mfs);

            short a = 2;
            short b = 3;
            string c = "JUMP";
            //bw.Write(a);
            bw.Write(c);
            //bw.Write(b);

            Console.WriteLine("Done writing to binary file");
            br.BaseStream.Seek(0, SeekOrigin.Begin); //Apprantly you have to seek to beginning

            //a = br.ReadInt16();
            c = br.ReadString();
            //b = br.ReadInt16();

            //Console.WriteLine("" + a);
            Console.WriteLine("" + c);
            Console.WriteLine("");
            //Console.WriteLine("" + b);
        }
    }
}
