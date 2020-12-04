using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day02Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = System.IO.File.ReadAllText(@"../../../../input.txt").Split("\n");

            List<UserPasswordRecord> userPasswordRecords = new List<UserPasswordRecord>();
            int validPasswordCount = 0;
            foreach (string line in inputArray)
            {
                UserPasswordRecord userPasswordRecord = new UserPasswordRecord();
                userPasswordRecord.PasswordPolicy = new PasswordPolicy();

                //BEHOLD THE POWER OF THE REGEX
                Regex regex = new Regex(@"^(\d+)-(\d+)\s([a-zA-Z]):\s([a-zA-Z]*)");
                Match match = regex.Match(line);
                while (match.Success)
                {
                    userPasswordRecord.PasswordPolicy.MinCharacterOccurrences = match.Groups[1].ToString();
                    userPasswordRecord.PasswordPolicy.MaxCharacterOccurrences = match.Groups[2].ToString();
                    userPasswordRecord.PasswordPolicy.RequiredCharacter = match.Groups[3].ToString();
                    userPasswordRecord.Password = match.Groups[4].ToString();

                    if (IsPasswordValid(userPasswordRecord)) validPasswordCount++;

                    match = match.NextMatch();
                }
            }

            Console.WriteLine("There are " + validPasswordCount + " valid passwords");
        }

        private static bool IsPasswordValid(UserPasswordRecord userPasswordRecord)
        {
            int min = 0;
            int max = 0;

            if (int.TryParse(userPasswordRecord.PasswordPolicy.MinCharacterOccurrences, out min) && int.TryParse(userPasswordRecord.PasswordPolicy.MaxCharacterOccurrences, out max))
            {
                int numberOfRequiredCharacterOccurances = 0;

                foreach (char passwordChar in userPasswordRecord.Password.ToCharArray())
                {
                    if (string.Equals(passwordChar.ToString(), userPasswordRecord.PasswordPolicy.RequiredCharacter)) numberOfRequiredCharacterOccurances++;
                }

                if (numberOfRequiredCharacterOccurances >= min && numberOfRequiredCharacterOccurances <= max) return true;
            }

            return false;
        }
    }

    public class UserPasswordRecord
    {
        public PasswordPolicy PasswordPolicy { get; set; }
        public string Password { get; set; }
    }

    public class PasswordPolicy
    {
        public string MinCharacterOccurrences { get; set; }
        public string MaxCharacterOccurrences { get; set; }
        public string RequiredCharacter { get; set; }
    }
}
