using System;

namespace Linear_Algebra
{
    public class Vector : Matrix
    {
        public Vector(int length) : base(1, length)
        {
            Values = new double[1][];

            Values[0] = new double[length];
        }

        public Vector(double[] values) : base(1, values.Length)
        {
            Values[0] = values;
        }
    }
}
