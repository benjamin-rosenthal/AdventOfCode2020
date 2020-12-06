using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllText(@"../../../../input.txt").Split("\n\n");

            int numberOfQuestionsThatEveryoneAnsweredYesTo = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string[] answersByPerson = input[i].Split("\n");
                answersByPerson = answersByPerson.OrderByDescending(x => x.Length).ToArray();

                List<char> sharedAnswers = answersByPerson[0].ToCharArray().ToList();
                for (int j = 0; j < answersByPerson.Length; j++)
                {
                    List<char> currentPersonAnswers = answersByPerson[j].ToCharArray().ToList();
                    sharedAnswers = sharedAnswers.Intersect(currentPersonAnswers.Select(x => x)).ToList();
                }
                numberOfQuestionsThatEveryoneAnsweredYesTo += sharedAnswers.Count;
            }

            Console.WriteLine("There are " + numberOfQuestionsThatEveryoneAnsweredYesTo + " questions that everyone answered yes to.");
        }

        //static void Main(string[] args)
        //{
        //    string[] input = new string[5];
        //    input[0] = "abc";
        //    input[1] = "a\nb\nc";
        //    input[2] = "ab\nac";
        //    input[3] = "a\na\na\na";
        //    input[4] = "b";

        //    int numberOfQuestionsThatEveryoneAnsweredYesTo = 0;
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        string[] answersByPerson = input[i].Split("\n");
        //        answersByPerson = answersByPerson.OrderByDescending(x => x.Length).ToArray();

        //        List<char> sharedAnswers = answersByPerson[0].ToCharArray().ToList();
        //        for (int j = 0; j < answersByPerson.Length; j++)
        //        {
        //            List<char> currentPersonAnswers = answersByPerson[j].ToCharArray().ToList();
        //            sharedAnswers = sharedAnswers.Intersect(currentPersonAnswers.Select(x => x)).ToList();
        //        }
        //        Console.WriteLine("Everyone answered yes to " + sharedAnswers.Count() + " questions");
        //        numberOfQuestionsThatEveryoneAnsweredYesTo += sharedAnswers.Count;

        //    }

        //    Console.WriteLine("There are " + numberOfQuestionsThatEveryoneAnsweredYesTo + " questions that everyone answered yes to.");
        //}
    }
}
