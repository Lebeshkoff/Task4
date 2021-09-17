using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using SLAU;

namespace Task4_test
{
    class MathHandler
    {
        public byte[] GfetMatrix(double[,] matrix)
        {
            Encoding.UTF8.GetBytes(matrix);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, );
                return ms.ToArray();
            }
        }
        public double[,] GetMatrix(Stream s)
        {
            var sr = new StreamReader(s);
            var str = sr.ReadToEnd();
            var bytes = Encoding.UTF8.GetBytes(str);
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(bytes, 0, str.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            double[,] matrix = binForm.Deserialize(memStream) as double[,];

            return matrix;

        }

        public double[] SolveMatrix(ExtendedMatrix method)
        {
            return method.Solutions;
        }
    }
}
