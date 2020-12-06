using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day06Part1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Wonder if I could make this a one liner somehow
            int answerCount = 0;
            System.IO.File.ReadAllText(@"../../../../input.txt").Split("\n\n").Select(x => x.Replace("\n", "")).ToList().ForEach(x => answerCount += x.ToCharArray().Distinct().Count());

            Console.WriteLine("There are " + answerCount + " distinct answers");
        }
    }
}
