using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Task4_test
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            
            listener.Prefixes.Add("http://localhost:8888/connection/");
            listener.Start();
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
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
            listener.Stop();
        }
    }
}
