using System;

namespace ConsoleApp10
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var validator = new InputValidator();

                Console.WriteLine("Введите коэффициенты первого уравнения:");
                double a = validator.GetValidDouble();
                double b = validator.GetValidDouble();
                double c = validator.GetValidDouble();

                var eq1 = new QuadraticEquation(a, b, c);
                Console.WriteLine("Уравнение: " + eq1);

                double[] roots = eq1.Solve();

                if (roots.Length == 0)
                {
                    Console.WriteLine("Корней нет");
                }
                else
                {
                    Console.WriteLine("Корни уравнения:");
                    foreach (double root in roots)
                    {
                        Console.WriteLine(root);
                    }
                }

                Console.WriteLine("Проверка унарных операций:");
                eq1++;
                Console.WriteLine("После ++: " + eq1);
                eq1--;
                Console.WriteLine("После --: " + eq1);

                Console.WriteLine("Проверка приведения типа:");
                double discriminant = eq1;
                Console.WriteLine($"Дискриминант: {discriminant}");

                bool hasRoots = (bool)eq1;
                Console.WriteLine($"Есть ли корни: {hasRoots}");

                Console.WriteLine("Введите коэффициенты второго уравнения:");
                double a2 = validator.GetValidDouble();
                double b2 = validator.GetValidDouble();
                double c2 = validator.GetValidDouble();

                var eq2 = new QuadraticEquation(a2, b2, c2);

                Console.WriteLine($"eq1 == eq2: {eq1 == eq2}");
                Console.WriteLine($"eq1 != eq2: {eq1 != eq2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
