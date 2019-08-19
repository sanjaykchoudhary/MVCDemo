using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;

namespace WebApiSelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:1234");
            var server = new HttpSelfHostServer(config, new MyWebAPIMessageHandler());
            var task = server.OpenAsync();
            task.Wait();

            Console.WriteLine("Web API Server has started at http://localhost:1234");
            Console.ReadLine();
        }
    }

    class MyWebAPIMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken)
        {
            var task = new Task<HttpResponseMessage>(() =>
              {
                  var resMsg = new HttpResponseMessage();
                  resMsg.Content = new StringContent("Hello World");
                  return resMsg;
              });
            task.Start();
            return task;
        }
    }
}
