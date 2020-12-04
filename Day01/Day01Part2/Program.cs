using Common;
using System;

namespace Day01Part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputStrings = System.IO.File.ReadAllText(@"../../../../input.txt").Split();

            for (int i = 0; i < inputStrings.Length; i++)
            {
                for (int j = i + 1; j < inputStrings.Length; j++)
                {
                    for (int h = j + 1; h < inputStrings.Length; h++)
                    {
                        int number1 = 0;
                        int number2 = 0;
                        int number3 = 0;

                        if (int.TryParse(inputStrings[i], out number1) && int.TryParse(inputStrings[j], out number2) && int.TryParse(inputStrings[h], out number3))
                        {
                            if (number1 + number2 + number3 == 2020)
                            {
                                Console.Write("The answer is: " + (number1 * number2 * number3));
                            }
                        }
                    }
                }
            }
        }
    }
}
