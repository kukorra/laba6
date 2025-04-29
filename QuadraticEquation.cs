using System;

namespace ConsoleApp10
{
    public class QuadraticEquation
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        public QuadraticEquation()
        {
            _a = 0;
            _b = 0;
            _c = 0;
        }

        public QuadraticEquation(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double A => _a;
        public double B => _b;
        public double C => _c;

        public double[] Solve()
        {
            double d = _b * _b - 4 * _a * _c;

            if (d < 0)
            {
                return Array.Empty<double>();
            }

            if (d == 0)
            {
                double x = -_b / (2 * _a);
                return new[] { x };
            }

            double sqrtD = Math.Sqrt(d);
            double x1 = (-_b + sqrtD) / (2 * _a);
            double x2 = (-_b - sqrtD) / (2 * _a);
            return new[] { x1, x2 };
        }

        public override string ToString()
        {
            return $"{_a}x^2 + {_b}x + {_c} = 0";
        }

        public static QuadraticEquation operator ++(QuadraticEquation eq)
        {
            return new QuadraticEquation(eq._a + 1, eq._b + 1, eq._c + 1);
        }

        public static QuadraticEquation operator --(QuadraticEquation eq)
        {
            return new QuadraticEquation(eq._a - 1, eq._b - 1, eq._c - 1);
        }

        public static implicit operator double(QuadraticEquation eq)
        {
            return eq._b * eq._b - 4 * eq._a * eq._c;
        }

        public static explicit operator bool(QuadraticEquation eq)
        {
            return (eq._b * eq._b - 4 * eq._a * eq._c) >= 0;
        }

        public static bool operator ==(QuadraticEquation eq1, QuadraticEquation eq2)
        {
            return eq1._a == eq2._a &&
                   eq1._b == eq2._b &&
                   eq1._c == eq2._c;
        }

        public static bool operator !=(QuadraticEquation eq1, QuadraticEquation eq2)
        {
            return !(eq1 == eq2);
        }

        public override bool Equals(object obj)
        {
            return obj is QuadraticEquation other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_a, _b, _c);
        }
    }
}
