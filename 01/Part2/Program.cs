using Common;
using System;

namespace Part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputStrings = InputReader.InputToList(System.IO.File.ReadAllText(@"../../../../input.txt"));

            for (int i = 0; i < inputStrings.Count; i++)
            {
                for (int j = i + 1; j < inputStrings.Count; j++)
                {
                    for (int h = j + 1; h < inputStrings.Count; h++) {
                        int number1 = 0;
                        int number2 = 0;
                        int number3 = 0;
                    if (int.TryParse(inputStrings.ToArray()[i], out number1) && int.TryParse(inputStrings.ToArray()[j], out number2) && int.TryParse(inputStrings.ToArray()[h], out number3))
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
