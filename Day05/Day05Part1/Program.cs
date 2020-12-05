using System;
using System.Collections.Generic;
using System.Linq;

namespace Day05Part1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputArray = System.IO.File.ReadAllText(@"../../../../input.txt").Split("\n");
            List<int> uniqueSeatIDs = new List<int>();

            foreach (var seat in inputArray)
            {
                int rowLowerBound = 0;
                int rowUpperBound = 127;
                int row = 0;

                int columnLowerBound = 0;
                int columnUpperBound = 7;
                int column = 0;

                foreach (char character in seat.ToCharArray())
                {
                    if (character == 'F') rowUpperBound = RecalculateUpperBound(rowLowerBound, rowUpperBound);
                    if (character == 'B') rowLowerBound = RecalculateLowerBound(rowLowerBound, rowUpperBound);
                    if (character == 'L') columnUpperBound = RecalculateUpperBound(columnLowerBound, columnUpperBound);
                    if (character == 'R') columnLowerBound = RecalculateLowerBound(columnLowerBound, columnUpperBound);

                    if (rowUpperBound == rowLowerBound) row = rowUpperBound;
                    if (columnUpperBound == columnLowerBound) column = columnUpperBound;
                }
                uniqueSeatIDs.Add((row * 8) + column);
            }

            Console.WriteLine("Highest seat ID: " + uniqueSeatIDs.Max());
        }

        public static int RecalculateLowerBound(int lowerBound, int upperBound)
        {
            double newLowerBound = (((upperBound - lowerBound) / 2 + 1)) + lowerBound;
            return Convert.ToInt32(Math.Round(newLowerBound));
        }

        public static int RecalculateUpperBound(int lowerBound, int upperBound)
        {
            double newUpperBound = upperBound - (((upperBound - lowerBound) / 2) + 1);
            return Convert.ToInt32(newUpperBound);
        }
    }
}
