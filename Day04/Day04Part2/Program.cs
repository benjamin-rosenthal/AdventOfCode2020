using System;
using System.Collections.Generic;
using System.Linq;

namespace Day04Part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputArray = System.IO.File.ReadAllText(@"../../../../input.txt").Split("\n\n");

            int validPassports = 0;
            foreach (var passportRecord in inputArray)
            {
                var splitPassportRecord = passportRecord.Split(new[] { ' ', '\\', '\n' });
                Dictionary<string, string> passportDictionary = new Dictionary<string, string>();

                    splitPassportRecord.ToList().ForEach(x =>
                    {
                        if (!string.IsNullOrWhiteSpace(x)) passportDictionary.Add(x.Split(':')[0], x.Split(':')[1]);
                    });

                    if (PassportInformationIsValid(passportDictionary)) validPassports++;
            }

            Console.WriteLine("Number of valid passports: " + validPassports);
        }

        public static bool PassportContainsNecessaryInformation(string passportRecord)
        {
            

            return false;
        }

        public static bool PassportInformationIsValid(Dictionary<string, string> passportDictionary)
        {
            int birthYear = 0;
            int issueYear = 0;
            int expirationYear = 0;
            int height = 0;
            int passportID = 0;

            if (passportDictionary.GetValueOrDefault("byr") == null ||
                passportDictionary.GetValueOrDefault("iyr") == null ||
                passportDictionary.GetValueOrDefault("eyr") == null ||
                passportDictionary.GetValueOrDefault("hgt") == null ||
                passportDictionary.GetValueOrDefault("hcl") == null ||
                passportDictionary.GetValueOrDefault("ecl") == null ||
                passportDictionary.GetValueOrDefault("pid") == null)
            {
                return false;
            }

            //validate birth year
            if (int.TryParse(passportDictionary.GetValueOrDefault("byr"), out birthYear))
            {
                if (birthYear < 1920 || birthYear > 2002) return false;
            }
            else
            {
                return false;
            }

            //validate issue year
            if (int.TryParse(passportDictionary.GetValueOrDefault("iyr"), out issueYear))
            {
                if (issueYear < 2010 || issueYear > 2020) return false;
            }
            else
            {
                return false;
            }

            //validate expiration year
            if (int.TryParse(passportDictionary.GetValueOrDefault("eyr"), out expirationYear))
            {
                if (expirationYear < 2020 || expirationYear > 2030) return false;
            }
            else
            {
                return false;
            }

            //validate height
            if (passportDictionary.GetValueOrDefault("hgt").EndsWith("in"))
            {
                if (int.TryParse(passportDictionary.GetValueOrDefault("hgt").Substring(0, 2), out height))
                {
                    if (height < 59 || height > 76) return false;
                }
                else
                {
                    return false;
                }
            }
            else if (passportDictionary.GetValueOrDefault("hgt").EndsWith("cm"))
            {
                if (int.TryParse(passportDictionary.GetValueOrDefault("hgt").Substring(0, 3), out height))
                {
                    if (height < 150 || height > 193) return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            //validate hair color
            if (passportDictionary.GetValueOrDefault("hcl").StartsWith("#"))
            {
                string hairColorSubstring = passportDictionary.GetValueOrDefault("hcl").Substring(1);

                if (hairColorSubstring.Length != 6 || !hairColorSubstring.All(x => (Char.IsDigit(x) || x == 'a' || x == 'b' || x == 'c' || x == 'd' || x == 'e' || x == 'f')))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            //validate eye color
            var eyeColor = passportDictionary.GetValueOrDefault("ecl");
            if (eyeColor != "amb" &&
                eyeColor != "blu" &&
                eyeColor != "brn" &&
                eyeColor != "gry" &&
                eyeColor != "grn" &&
                eyeColor != "hzl" &&
                eyeColor != "oth")
            {
                return false;
            }

            //Validate passport id
            if (int.TryParse(passportDictionary.GetValueOrDefault("pid"), out passportID))
            {
                if (passportID.ToString().Length != 9)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            //If nothing has returned false yet, we're good
            return true;
        }
    }
}
