using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    interface IExtendedMatrix
    {
        double[,] Matrix { get; }
        double[] Solutions { get; }
        int Number { get; }
    }
}
