using AdventOfCode2020.Interface;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    //Part one: For each group, count the number of questions to which anyone answered "yes". What is the sum of those counts?
    class SolutionDay6 : ISolverSetup
    {
        public void Initialize()
        {
            var input = GetInput();

            var answerCount = PartOne(input);
            Console.WriteLine($"Day 6 - Part one. count is : {answerCount}");
            //var two = PartTwo(input);
        }
        private int PartOne(string[] input)
        {
            return string.Join("\n", input)
                        .Split("\n\n")
                        .Select(x => x.Replace("\n", "").ToCharArray().Distinct().Count())
                        .Sum();
        }

        private object PartTwo(string[] input)
        {
            throw new NotImplementedException();
        }


        public string[] GetInput()
        {
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day06/input.txt"));
        }
    }
}
