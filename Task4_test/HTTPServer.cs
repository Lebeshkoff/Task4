using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Task4_test
{
    class HTTPServer
    {
        private HttpListener _listener;
        public event Action<Stream> OnConnect = delegate { };
        public HTTPServer(string url, int port)
        {
            _listener.Prefixes.Add("http://" + url + ":" + port);
        }

        public Task Start()
        {
            while(true)
            {
                HttpListenerContext context = _listener.GetContext();
                HttpListenerRequest request = context.Request;
                Console.WriteLine(request.HttpMethod + " " + request.UserHostName + " " + request.UserAgent);
                Stream requestStream = request.InputStream;
                HttpListenerResponse response = context.Response;

                StreamReader reader = new StreamReader(requestStream);
                string responseStr = reader.ReadToEnd();

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr.ToUpper());
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}
