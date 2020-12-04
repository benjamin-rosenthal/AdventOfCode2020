using System;
using System.Linq;

namespace Day03Part1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Get the input from the file and convert it to a multidimensional char array
            string[] inputArray = System.IO.File.ReadAllText(@"../../../../input.txt").Split("\n");
            char[,] inputGrid = new char[inputArray.Length, inputArray[0].Length];
            for (int rowCount = 0; rowCount < inputGrid.GetLength(0); rowCount++)
            {
                for (int columnCount = 0; columnCount < inputGrid.GetLength(1); columnCount++)
                {
                    if (!string.IsNullOrWhiteSpace(inputArray[rowCount].ToString()))
                    {
                        var charToGet = inputArray[rowCount].ToCharArray()[columnCount];
                        inputGrid[rowCount, columnCount] = charToGet;
                    }
                }
            }

            int rowIndex = 0;
            int treeCount = 0;
            do
            {
                if (inputGrid[rowIndex, ((rowIndex * 3) % inputGrid.GetLength(1))] == '#') treeCount++;
                rowIndex++;
            }
            while (rowIndex < inputGrid.GetLength(0));

            Console.WriteLine("Augh! I ran into " + treeCount + " trees!");
        }
    }
}
