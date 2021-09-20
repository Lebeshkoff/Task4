using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using SLAU;

namespace Task4_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new HTTPServer("http://localhost:8888/connection/");
            
            server.OnConnect += (Stream s) => 
            { 
                //MathHandler.SolveMatrix(new GaussMethod1(MathHandler.GetMatrix(s)));
                Console.WriteLine(MathHandler.GetMatrix(s));
            };
            Task.Run(() => server.Start());
            Thread.Sleep(2000);
            Console.ReadLine();
        }
    }
}
