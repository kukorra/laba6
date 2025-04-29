using System;

namespace ConsoleApp10
{
    public class InputValidator
    {
        public double GetValidDouble()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                {
                    return number;
                }

                Console.WriteLine("Ошибка: введите корректное число.");
            }
        }
    }
}
