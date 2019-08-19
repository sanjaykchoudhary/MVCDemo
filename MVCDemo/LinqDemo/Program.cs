using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array array = Array.CreateInstance(typeof(int), new int[1] { 5 }, new int[1] { 1 });
            //array.SetValue(1, 1);
            int[] array = new int[] { 1, 2 };
            Console.WriteLine(array.Length);
            ArrayList arraylist = new ArrayList();

            arraylist.Add(1);
            arraylist.Add("Two");
            arraylist.Add(3);
            arraylist.Add(4.5f);
            foreach(var v in arraylist)
            {
                Console.WriteLine("Value: " + v);
                Console.WriteLine($"There are {arraylist.Count} data.");
                Console.ReadLine();
            }



            Student[] studentArray =
            {
               new Student() {StudentId=1,StudentName="John",Age=18 },
               new Student() {StudentId=2,StudentName="Steve",Age=21 },
               new Student() {StudentId=3,StudentName="Bill",Age=23 },
               new Student() {StudentId=4,StudentName="Ram",Age=20 },
               new Student() {StudentId=5,StudentName="Ron",Age=32 },
               new Student() {StudentId=6,StudentName="Chris",Age=17 },
               new Student() {StudentId=7,StudentName="Rob",Age=16 }
            };

            //Student[] students = new Student[10];
            //int i = 0;
            //foreach(Student std in studentArray)
            //{
            //    students[i] = std;
            //    Console.WriteLine("Students with ID: {0}, Name: {1}, Age: {2}", students[i].StudentId, students[i].StudentName, students[i].Age.ToString());
            //    i++;
            //}
            //Console.ReadLine();

            StudentExtend.where(studentArray, delegate (Student std)
             {
                 return std.Age > 12 && std.Age < 20;
             });
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    public delegate bool FindStudent(Student std);
    public class StudentExtend
    {
        public static Student[] where(Student[] studentArray,FindStudent del)
        {
            int i = 0;
            Student[] students = new Student[10];
            foreach(Student std in studentArray)
            {
                if(del(std))
                {
                    students[i] = std;
                    i++;
                }                
            }
            return students;
        }
    }
}
