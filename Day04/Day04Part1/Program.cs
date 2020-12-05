using System;
using System.Linq;

namespace Day04Part1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputArray = System.IO.File.ReadAllText(@"../../../../input.txt").Split("\n\n");

            int validPassports = 0;
            foreach (var passportRecord in inputArray)
            {
                if (IsPassportValid(passportRecord)) validPassports++;
            }

            Console.WriteLine("Number of valid passports: " + validPassports);
        }

        public static bool IsPassportValid(string passportRecord)
        {
            if (passportRecord.Contains("byr:") &&
                passportRecord.Contains("iyr:") &&
                passportRecord.Contains("eyr:") &&
                passportRecord.Contains("hgt:") &&
                passportRecord.Contains("hcl:") &&
                passportRecord.Contains("ecl:") &&
                passportRecord.Contains("pid:"))
            {
                return true;
            }

            return false;
        }
    }
}
