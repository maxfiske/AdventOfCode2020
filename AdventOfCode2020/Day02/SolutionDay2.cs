using AdventOfCode2020.Interface;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day02
{
    //Part 1: The password policy indicates the lowest and highest number of times 
    // a given letter must appear for the password to be valid. For example,
    //1-3 a means that the password must contain a at least 1 time and at most 3 times.
    //How many passwords are valid according to their policies?

    class SolutionDay2 : ISolverSetup
    {
        private static readonly char[] delimiterChars = { ':', ' ', '-' };
        public void Initialize()
        {
            var input = GetInput();

            var numberOfValidPoliciesRoundOne = PartOne(input);
            Console.WriteLine("Part one - Number of valid policies: " + numberOfValidPoliciesRoundOne);

            var numberOfValidPoliciesRoundTwo = PartTwo(input);
            Console.WriteLine("Part two - Number of valid policies: " + numberOfValidPoliciesRoundTwo);

        }
        private int PartOne(string[] input)
        {
            return CheckPolicyPartOne(input);
        }
        private int CheckPolicyPartOne(string[] input)
        {
            int validPasswordCount = 0;

            foreach (var line in input)
            {
                var isValid = IsValidPolicyPartOne(line);
                if (isValid)
                    validPasswordCount++;
            }
            return validPasswordCount;
        }

        public bool IsValidPolicyPartOne(string line)
        {
            ParseInputPartOne(line, out int firstNumber, out int secondNumber, out string letter, out string lettersequence);
            var letterCount = lettersequence.Count(l => l == char.Parse(letter));

            return letterCount >= firstNumber && letterCount <= secondNumber;
        }

        private void ParseInputPartOne(string line, out int firstNumber, out int secondNumber, out string letter, out string lettersequence)
        {
            var characters = line.Split(delimiterChars);
            firstNumber = int.Parse(characters.First());
            secondNumber = int.Parse(characters.Skip(1).First());
            letter = characters.Skip(2).First();
            lettersequence = characters.Skip(4).First();
        }

        private int PartTwo(string[] input)
        {
            return CheckPolicyPartTwo(input);
        }

        private int CheckPolicyPartTwo(string[] input)
        {
            int validpasswordCount = 0;
            foreach (var line in input)
            {
                var isValid = IsValidPolicyPartTwo(line);
                if (isValid)
                    validpasswordCount++;
            }
            return validpasswordCount;
        }

        public bool IsValidPolicyPartTwo(string line)
        {
            ParseInputPartTwo(line, out int min, out int max, out string requiredLetter, out char[] lettersequence);

            var matchesMin = lettersequence[min - 1] == requiredLetter[0];
            var matchesMax = lettersequence[max - 1] == requiredLetter[0];
            return matchesMin ^ matchesMax;
        }

        private static void ParseInputPartTwo(string line, out int min, out int max, out string requiredLetter, out char[] lettersequence)
        {
            var characters = line.Split(delimiterChars);
            min = int.Parse(characters.First());
            max = int.Parse(characters.Skip(1).First());
            requiredLetter = characters.Skip(2).First();
            lettersequence = characters.Skip(4).First().ToArray();
        }

        public string[] GetInput()
        {
            var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day02/input.txt"));
            return input;
        }
    }
}
