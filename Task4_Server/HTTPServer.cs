using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Task4_Server
{
    public class HTTPServer
    {
        private readonly HttpListener _listener = new HttpListener();
        public event Action<Stream> OnConnect = delegate { };
        public event Action OnStop = delegate { };
        public HTTPServer(string url)
        {
            _listener.Prefixes.Add(url);
        }

        public Task Start()
        {
            _listener.Start();
            Console.WriteLine("Server start");
            while(true)
            {
                HttpListenerContext context = _listener.GetContext();
                HttpListenerRequest request = context.Request;
                Console.WriteLine(request.HttpMethod + " " + request.UserHostName + " " + request.UserAgent);
                Stream requestStream = request.InputStream;
                HttpListenerResponse response = context.Response;
                //OnConnect?.Invoke(requestStream);
                //StreamReader reader = new StreamReader(requestStream);
                //string responseStr = reader.ReadToEnd();

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes("response");
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }

        public void StopServer()
        {
            _listener.Stop();
            OnStop?.Invoke();
        }
    }
}
