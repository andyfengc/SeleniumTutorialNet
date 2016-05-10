using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTutorialNet
{
    public class HttpServerAsync : IDisposable
    {
        private HttpListener listener;
        private string url;
        private string content;

        public HttpServerAsync(string url, string content)
        {
            this.url = url;
            this.content = content;
        }

        public async void Start()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            while (true)
            {
                Console.WriteLine("waiting....");
                HttpListenerContext context = await listener.GetContextAsync();
                // Respond to the request:
                string msg = "You asked for: " + context.Request.RawUrl;
                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(content);
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                using (var stream = context.Response.OutputStream)
                {
                    using (var writer = new StreamWriter(stream))
                    {
                       await writer.WriteAsync(content);
                    }
                }
                Console.WriteLine("message sent....");
            }
        }

        public void SetService(string content)
        {
            this.content = content;
        }

        public void Dispose()
        {
            Stop();
        }

        private void Stop()
        {
            this.listener.Stop();
        }
    }
}
