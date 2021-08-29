using System;
using System.IO;
using System.Net;
using System.Text;

namespace Task4_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var str = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(str);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8888/connection/");
                request.Method = "POST";
                request.ContentType = "text/*";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                Console.WriteLine(reader.ReadToEnd());
                response.Close();
            }
        }
    }
}
