using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignInvitationCardDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           
            InvitationCard obj1 = new InvitationCard();
            obj1.To = "Sanjeev";
            obj1.Title = "Birthday celebration";
            obj1.Content = "Please come to the party";
            obj1.SendBy = "Sanjay";
            obj1.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //Here our first object has created.
            InvitationCard[] objList = new InvitationCard[5];
            string[] nameList = { "Sanjeev", "Shyam", "Hari", "Tapan", "Saroj" };
            int i = 0;
            foreach(string name in nameList)
            {
                objList[i] = obj1.CloneMe(obj1);
                objList[i].To = nameList[i];
                i++;
            }

            //Print all invitation card here.
            foreach(InvitationCard obj in objList)
            {
                Console.WriteLine("To: " + obj.To);
                Console.WriteLine("Title: " + obj.Title);
                Console.WriteLine("Content: " + obj.Content);
                Console.WriteLine("Send By: " + obj.SendBy);
                Console.WriteLine("Date: " + obj.Date);
            }
            Console.ReadLine();
        }
    }

    public class InvitationCard
    {
        public string _to;
        public string _title;
        public string _content;
        public string _sendBy;
        public DateTime _date;
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public string SendBy
        {
            get { return _sendBy; }
            set { _sendBy = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public InvitationCard CloneMe(InvitationCard obj)
        {
            return (InvitationCard)this.MemberwiseClone();
        }

    }
}