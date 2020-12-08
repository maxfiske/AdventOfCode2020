using AdventOfCode2020.Interface;
using System;
using System.Collections.Generic;
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

            var encounteredTreesInMultipleSlopes = PartTwo(input);
            Console.WriteLine($"Day 3- Part One. Trees ecountered: {encounteredTreesInMultipleSlopes}");
        }

        private int PartOne(string[] input)
        {
            return input
                 .Skip(1)
                 .Select((row, i) => row[(i + 1) * 3 % row.Length]
                 .Equals('#') ? 1 : 0)
                 .Sum();
        }

        private long PartTwo(string[] input)
        {
            var trees = new List<long>();
            foreach (var slope in GetSlopes())
            {
                if (slope.Item1 != 2)
                {
                    trees.Add(input
                     .Skip(1)
                     .Select((row, i) => row[(i + slope.Item1) * slope.Item2 % row.Length]
                     .Equals('#') ? 1 : 0)
                     .Sum());
                }
                else
                {
                    trees.Add(input
                      .Select((row, i) => CheckRemainder(i, row, slope)
                      .Equals('#') ? 1 : 0)
                      .Sum());
                }
            }

            return trees.Aggregate(1L, (a, b) => a * b);
        }

        private static Tuple<int, int>[] GetSlopes()
        {
            Tuple<int, int>[] slopes =
            {
                new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(1, 3),
                    new Tuple<int, int>(1, 5),
                    new Tuple<int, int>(1, 7),
                    new Tuple<int, int>(2, 1),
             };
            return slopes;
        }
        private char CheckRemainder(int i, string row, Tuple<int,int> slope)
        {
            if (i % 2 == 0)
            {
                return row[(i / slope.Item1) % row.Length];
            }
            return char.Parse(".");
        }
        public string[] GetInput()
        {
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day03/input.txt"));
        }

    }
}
