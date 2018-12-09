using System;
using static System.Math;

namespace Linear_Algebra
{
    public class Matrix
    {
        protected double[][] Values;
        public int LinesNumber { get => Values.Length; }
        public int ColumnsNumber { get => Values[0].Length; }

        /// <summary>
        /// Returns the norm of Matrix
        /// </summary>
        /// <returns></returns>
        public double Norm
        {
            get
            {
                int i, j;
                double output = 0;

                for (i = 0; i < LinesNumber; i++)
                {
                    for (j = 0; j < ColumnsNumber; j++)
                    {
                        output += Pow(this[i, j], 2);
                    }
                }

                return Sqrt(output);
            }
        }

        /// <summary>
        /// Initialises new Matrix with n lines and m columns
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="columns"></param>
        public Matrix(int n, int m)
        {
            int i;
            Values = new double[n][];

            for (i = 0; i < n; i++)
            {
                Values[i] = new double[m];
            }
        }

        /// <summary>
        /// Initialises Matrix with specific values
        /// </summary>
        /// <param name="values"></param>
        public Matrix(double[][] values)
        {
            Values = values;
        }

        public double this[int line, int column]
        {
            get => Values[line][column];
            set => Values[line][column] = value;
        }
        public Vector this[int line]
        {
            get => new Vector(Values[line]);
        }

        public static Matrix operator *(double number, Matrix matrix)
        {
            int i, j;

            for (i = 0; i < matrix.LinesNumber; i++)
            {
                for (j = 0; j < matrix.ColumnsNumber; j++)
                {
                    matrix[i, j] *= number;
                }
            }

            return matrix;
        }
        public static Matrix operator *(Matrix matrix, double number)
        {
            return number * matrix;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.ColumnsNumber != m2.LinesNumber) throw new Exception("Matrix 1 must have the same number of columns as Matrix 2 has lines.");

            int i, j, k;
            Matrix output = new Matrix(m1.LinesNumber, m2.ColumnsNumber);

            for (i = 0; i < m1.LinesNumber; i++)
            {
                for (j = 0; j < m2.ColumnsNumber; j++)
                {
                    for (k = 0; k < m1.ColumnsNumber; k++)
                    {
                        output[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return output;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.LinesNumber != m2.LinesNumber || m1.ColumnsNumber != m2.ColumnsNumber) throw new Exception("Matrixes are not the same size.");

            int i, j;
            Matrix output = new Matrix(m1.LinesNumber, m1.ColumnsNumber); 

            for (i = 0; i < m1.LinesNumber; i++)
            {
                for (j = 0; j < m1.ColumnsNumber; j++)
                {
                    output[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return output;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.LinesNumber != m2.LinesNumber || m1.ColumnsNumber != m2.ColumnsNumber) throw new Exception("Matrixes are not the same size.");
            
            Matrix output = new Matrix(m1.LinesNumber, m1.ColumnsNumber);

            return m1 + (-1 * m2);
        }

        /// <summary>
        /// Transposes current Matrix
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            Matrix output = new Matrix(ColumnsNumber, LinesNumber);
            int i, j;

            for (i = 0; i < ColumnsNumber; i++)
            {
                for (j = 0; j < LinesNumber; j++)
                {
                    output[i, j] = this[j, i];
                }
            }

            return output;
        }
    }
}
