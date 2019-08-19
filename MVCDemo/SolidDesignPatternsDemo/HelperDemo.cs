using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace SolidDesignPatternsDemo
{
    public class HelperDemo
    {

    }

    public class UserService
    {
        SmtpClient _smtpClient;

        public void Register(string email,string password)
        {
            //if(!ValidateEmail(email))
            //    throw new ValidationException()
        }
        public virtual bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
        public void SendEmail(MailMessage email)
        {
           _smtpClient.Send(email);
        }
    }
}
