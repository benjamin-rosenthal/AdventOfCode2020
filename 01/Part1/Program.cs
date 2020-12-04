using System;
using System.Collections.Generic;
using Common;

namespace Day01Part1
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
                    int number1 = 0;
                    int number2 = 0;

                    if (int.TryParse(inputStrings[i], out number1) && int.TryParse(inputStrings[j], out number2))
                    {
                        if (number1 + number2 == 2020)
                        {
                            Console.Write("The answer is: " + (number1 * number2));
                        }
                    }
                }
            }
        }
    }
}