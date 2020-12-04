using System;

namespace Day03Part2
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

            int count1 = GetTreesForSpecifiedSlope(inputGrid, 1, 1);
            int count2 = GetTreesForSpecifiedSlope(inputGrid, 3, 1);
            int count3 = GetTreesForSpecifiedSlope(inputGrid, 5, 1);
            int count4 = GetTreesForSpecifiedSlope(inputGrid, 7, 1);
            int count5 = GetTreesForSpecifiedSlope(inputGrid, 1, 2);

            int finalCount = count1 * count2 * count3 * count4 * count5;

            Console.WriteLine("I ran into " + finalCount +" trees. When will I learn?!");
        }

        public static int GetTreesForSpecifiedSlope(char[,] inputGrid, int right, int down) {

            int rowIndex = 0;
            int treeCount = 0;
            do
            {
                if (inputGrid[rowIndex, ((rowIndex * right/down) % inputGrid.GetLength(1))] == '#') treeCount++;
                rowIndex += down;
            }
            while (rowIndex < inputGrid.GetLength(0));

            return treeCount;
        }
    }
}
