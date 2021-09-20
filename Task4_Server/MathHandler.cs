using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using SLAU;

namespace Task4_Server
{
    class MathHandler
    {
        public static double[,] GetMatrix(Stream s)
        {
            var sr = new StreamReader(s);
            MemoryStream ms = new();
            s.CopyTo(ms);
            BinaryFormatter binForm = new BinaryFormatter();
            ms.Position = 0;
            double[,] matrix = binForm.Deserialize(ms) as double[,];

            return matrix;

        }

        public static double[] SolveMatrix(ExtendedMatrix method)
        {
            return method.Solutions;
        }
    }
}
