using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace SeleniumTutorialNet
{
    public class HttpServer : IDisposable
    {
        private HttpListener listener;
        private string url;
        private string content;
        private bool started = false;

        public HttpServer(string url, string content)
        {
            //Start(url, content);
            this.url = url;
            this.content = content;
        }

        public void Start()
        {
            if (!started)
            {
                listener = new HttpListener();
                listener.Prefixes.Add(url);
                listener.Start();
                started = true;
                while (true)
                {
                    Console.WriteLine("waiting....");
                    HttpListenerContext context = listener.GetContext();
                    context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(content);
                    context.Response.StatusCode = (int) HttpStatusCode.OK;
                    using (var stream = context.Response.OutputStream)
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            writer.Write(content);
                        }
                    }
                    Console.WriteLine("message sent....");
                }
            }
            else
            {
                Console.WriteLine("server already started");
            }
        }

        public void SetService(string content)
        {
            this.content = content;
        }

        public void Dispose()
        {
            Stop();
            this.started = false;
        }

        private void Stop()
        {
            this.listener.Stop();
        }
    }
}
