using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    public abstract class ExtendedMatrix : IExtendedMatrix
    {
        protected int size;
        private static int _countOfMatrices;
        private readonly int _countOfLines;
        private readonly int _countOfColumns;
        public double[,] Matrix { get; }
        public double[] Solutions { get; }
        public int Number { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size"> Length of matrix </param>
        /// <param name="matrix"> Given matrix </param>
        public ExtendedMatrix(double[,] matrix)
        {
            this.size = matrix.Length;
            Matrix = matrix;
            Solutions = Solve((double[,])matrix.Clone());
            _countOfLines = size;
            _countOfColumns = size + 1;
            _countOfMatrices++;
            Number = _countOfMatrices;
        }

        /// <summary>
        /// Solving system of equations
        /// </summary>
        /// <param name="matrix"> Given matrix </param>
        /// <returns> Array of solutions </returns>
        public abstract double[] Solve(double[,] matrix);

        public override string ToString()
        {
            string result = "";

            result += $"\nMatrix #{Number}\n";

            for (int i = 0; i < _countOfLines; i++)
            {
                for (int j = 0; j < _countOfColumns; j++)
                {
                    result += Matrix[i, j] + " ";
                    if (j == _countOfLines - 1)
                    {
                        result += "| ";
                    }
                }
                result += "\n";
            }

            result += "Solutions: ";

            foreach (double num in Solutions)
            {
                result += num + " ";
            }

            result += "\n";

            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is ExtendedMatrix matrix &&
                   size == matrix.size &&
                   _countOfLines == matrix._countOfLines &&
                   _countOfColumns == matrix._countOfColumns &&
                   EqualityComparer<double[,]>.Default.Equals(Matrix, matrix.Matrix) &&
                   EqualityComparer<double[]>.Default.Equals(Solutions, matrix.Solutions) &&
                   Number == matrix.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(size, _countOfLines, _countOfColumns, Matrix, Solutions, Number);
        }
    }
}
