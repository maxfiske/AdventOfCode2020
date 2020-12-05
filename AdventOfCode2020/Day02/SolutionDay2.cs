using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day02
{
    //The password policy indicates the lowest and highest number of times 
    // a given letter must appear for the password to be valid. For example,
    //1-3 a means that the password must contain a at least 1 time and at most 3 times.
    //How many passwords are valid according to their policies?
    class SolutionDay2
    {
        public void Initialize()
        {
            var input = GetInput();
            var numberOfValidPolicies = CheckPolicy(input);
            
            Console.WriteLine("Number of valid policies: " + numberOfValidPolicies.Count());

        }

        private List<string> CheckPolicy(string[] input)
        {
            char[] delimiterChars = { ':', ' ', '-' };
            var validPasswords = new List<string>();

            foreach (var item in input)
            {
                var characters = item.Split(delimiterChars);

                var firstNumber = int.Parse(characters.First());
                var secondNumber = int.Parse(characters.Skip(1).First());
                var letter = characters.Skip(2).First();
                var lettersequence = characters.Skip(4).First();

                var letterCount = lettersequence.Count(l => l == char.Parse(letter));

                if(letterCount >= firstNumber && letterCount <= secondNumber)
                {
                    validPasswords.Add(item);
                }
            }

            return validPasswords;
        }

        private string[] GetInput()
        {
            var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day02/input.txt"));
            return input;
        }
    }
}
