using System;
using System.Text.RegularExpressions;

namespace Day02Part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputArray = System.IO.File.ReadAllText(@"../../../../input.txt").Split("\n");

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
                    userPasswordRecord.PasswordPolicy.PossibleCharacterPositionOne = match.Groups[1].ToString();
                    userPasswordRecord.PasswordPolicy.PossibleCharacterPositionTwo = match.Groups[2].ToString();
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
            int indexOne = 0;
            int indexTwo = 0;

            bool indexOneEqual = false;
            bool indexTwoEqual = false;

            if (int.TryParse(userPasswordRecord.PasswordPolicy.PossibleCharacterPositionOne, out indexOne) && int.TryParse(userPasswordRecord.PasswordPolicy.PossibleCharacterPositionTwo, out indexTwo))
            {
                //Decrement for zero indexing
                indexOne--;
                indexTwo--;

                if (string.Equals(userPasswordRecord.Password.ToCharArray()[indexOne].ToString(), userPasswordRecord.PasswordPolicy.RequiredCharacter)) indexOneEqual = true;
                if (string.Equals(userPasswordRecord.Password.ToCharArray()[indexTwo].ToString(), userPasswordRecord.PasswordPolicy.RequiredCharacter)) indexTwoEqual = true;

                if ((indexOneEqual && !indexTwoEqual) || (!indexOneEqual && indexTwoEqual)) return true;
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
        public string PossibleCharacterPositionOne { get; set; }
        public string PossibleCharacterPositionTwo { get; set; }
        public string RequiredCharacter { get; set; }
    }
}
