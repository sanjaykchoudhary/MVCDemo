using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<IMessage> message = new List<IMessage>();
            message.Add(new SMS());
            message.Add(new Email());

            Notification n = new Notification(message);
            n.Send();
            Console.ReadLine();
        }
    }

    public interface IMessage
    {
        void SendMessage();
    }
    public class Email: IMessage
    {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Content { get; set; }

        public void SendMessage()
        {
            Console.Write("Email Sent");
        }
    }

    public class SMS : IMessage
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

        public void SendMessage()
        {
            Console.Write("SMS Sent");
        }
    }

    //With this refactoring, all Notification cares about is that there's an abstraction (the interface IMessage) that can actually send the notification.
    //we have allowed both high-level and low-level classes to rely on abstractions, thereby upholding the Dependency Inversion Principle.
    public class Notification
    {
        private ICollection<IMessage> _message;
        public Notification(ICollection<IMessage> message)
        {
            this._message = message;
        }

        public void Send()
        {
            foreach(var mes in _message)
            {
                mes.SendMessage();
            }
        }
    }
    //Without DIP applying.
    public class Notification_WDIP
    {
        private Email email;
        private SMS sms;
        public Notification_WDIP()
        {
            email = new Email();
            sms = new SMS();
        }

        public void Send()
        {
            email.SendMessage();
            sms.SendMessage();
        }
    }
}
