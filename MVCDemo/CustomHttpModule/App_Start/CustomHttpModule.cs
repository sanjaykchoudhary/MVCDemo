using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CustomHttpModule.App_Start
{
    public class CustomHttpModule : IHttpModule
    {
        StreamWriter sw = null;
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.Application_BeginRequest);
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
           if(!File.Exists("Logger.txt"))
            {
                sw = new StreamWriter(@"Sanjay\VS\VS-15\MVC\MVCDemo\CustomHttpModule\Logger.txt");
            }
           else
            {
                sw = File.AppendText("Logger.txt");
            }
            sw.WriteLine("User sends request at {0}", DateTime.Now);
            sw.Close();
        }
    }
}