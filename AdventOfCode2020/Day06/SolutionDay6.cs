using AdventOfCode2020.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    //Part one: For each group, count the number of questions to which anyone answered "yes". What is the sum of those counts?
    //Parttwo: For each group, count the number of questions to which everyone answered "yes". What is the sum of those counts?
    class SolutionDay6 : ISolverSetup
    {
        public void Initialize()
        {
            var input = GetInput();

            var answerCountPartOne = PartOne(input);
            Console.WriteLine($"Day 6 - Part one. count is : {answerCountPartOne}");

            var answerCountPartTwo = PartTwo(input);
            Console.WriteLine($"Day 6 - Part two. count is : {answerCountPartTwo}");
        }
        private int PartOne(string[] input)
        {
            return string.Join("\n", input)
                        .Split("\n\n")
                        .Select(x => x.Replace("\n", "")
                        .ToCharArray()
                        .Distinct()
                        .Count())
                        .Sum();
        }

        private int PartTwo(string[] input)
        {
            var groups = string.Join("\n", input)
                        .Split("\n\n")
                        .Select(group => group.Split("\n"));

            var groupCountAllWhoAnsweredYes = new List<int>();

            foreach (var group in groups)
            {
                IEnumerable<char> groupAnswered = null;

                foreach (string personAnswers in group)
                {
                    groupAnswered = groupAnswered == null ? personAnswers.ToCharArray() : personAnswers.Intersect(groupAnswered);
                  
                }
                groupCountAllWhoAnsweredYes.Add(groupAnswered.Count());
            }

            return groupCountAllWhoAnsweredYes.Sum();
        }

        public string[] GetInput()
        {
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day06/input.txt"));
        }
    }
}
