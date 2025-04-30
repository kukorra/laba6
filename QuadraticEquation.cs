using System;

namespace ConsoleApp10
{
    public class QuadraticEquation
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

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
            if (_a == 0)
            {
                if (_b == 0)
                {
                    if (_c == 0)
                    {
                        // Бесконечно много решений — можно выбросить исключение или вернуть специальное значение
                        throw new InvalidOperationException("Уравнение имеет бесконечно много решений.");
                    }
                    else
                    {
                        // Нет решений
                        return new double[0];
                    }
                }
                else
                {
                    // Линейное уравнение: bx + c = 0
                    double x = -_c / _b;
                    return new[] { x };
                }
            }

            double discriminant = _b * _b - 4 * _a * _c;

            if (discriminant < 0)
            {
                return new double[0];
            }

            if (discriminant == 0)
            {
                double x = -_b / (2 * _a);
                return new[] { x };
            }

            double sqrtD = Math.Sqrt(discriminant);
            double x1 = (-_b + sqrtD) / (2 * _a);
            double x2 = (-_b - sqrtD) / (2 * _a);

            return new[] { x1, x2 };
        }


        public override string ToString()
        {
            return $"{_a}x^2 + {_b}x + {_c} = 0";
        }

        public static QuadraticEquation operator ++(QuadraticEquation equation)
        {
            return new QuadraticEquation(equation._a + 1, equation._b + 1, equation._c + 1);
        }

        public static QuadraticEquation operator --(QuadraticEquation equation)
        {
            return new QuadraticEquation(equation._a - 1, equation._b - 1, equation._c - 1);
        }

        public static implicit operator double(QuadraticEquation equation)
        {
            return equation._b * equation._b - 4 * equation._a * equation._c;
        }

        public static explicit operator bool(QuadraticEquation equation)
        {
            return (equation._b * equation._b - 4 * equation._a * equation._c) >= 0;
        }

        public static bool operator ==(QuadraticEquation left, QuadraticEquation right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left._a == right._a &&
                   left._b == right._b &&
                   left._c == right._c;
        }

        public static bool operator !=(QuadraticEquation left, QuadraticEquation right)
        {
            return !(left == right);
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
