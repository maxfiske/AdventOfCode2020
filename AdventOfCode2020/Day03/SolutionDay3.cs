using AdventOfCode2020.Interface;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day03
{
    //Part 1: Starting at the top-left corner of your map and following a slope of right 3 and down 1,
    //how many trees would you encounter?
    //Part 2: Determine the number of trees you would encounter if, for each of the following slopes,
    // you start at the top-left corner and traverse the map all the way to the bottom:
    //Right 1, down 1.
    //Right 3, down 1. (This is the slope you already checked.)
    //Right 5, down 1.
    //Right 7, down 1.
    //Right 1, down 2.
    class SolutionDay3 : ISolverSetup
    {
        public void Initialize()
        {
            var input = GetInput();
            var encounteredTrees = PartOne(input);
            Console.WriteLine($"Day 3- Part One. Trees ecountered: {encounteredTrees}");

            var test = PartTwo(input);
        }

        private int PartOne(string[] input)
        {
           return input
                .Skip(1)
                .Select((row, i) => row[(i + 1) * 3 % row.Length]
                .Equals('#') ? 1 : 0)
                .Sum();
        }
        private int PartTwo(string[] input)
        {
            return 5;
        }

        private string[] GetInput()
        {
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day03/input.txt"));
        }
    }
}
