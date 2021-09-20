using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Task4_Client
{
    class Program
    {
        public static byte[] DoubleMatrixToByte(double[,] matrix)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, matrix);
                ms.Position = 0;
                return ms.ToArray();
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                double[,] a = new double[,] { { 1, 1, 0, 1, 1 }, { 1, 1, 0, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } };
                byte[] data = DoubleMatrixToByte(a);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8888/connection/");
                request.Method = "POST";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new(stream);
                Console.WriteLine(reader.ReadToEnd());
                response.Close();
                Console.ReadLine();
            }
        }
    }
}
