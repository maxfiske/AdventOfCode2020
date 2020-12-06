using AdventOfCode2020.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day01
{
    class SolutionDay1 : ISolverSetup
    {
        //Part 1: Find two inputs that sum to 2020 and multiply them together

        private const int SumTo = 2020;

        public void Initialize()
        {
            var numbers = GetInput();

            var partOneResult = PartOne(numbers);
            Console.WriteLine($"Part One - Found match: {partOneResult}");

            var partTwoResult = PartTwo(numbers);
            Console.WriteLine($"Part Two - Found match: {partTwoResult}");
        }

        private static int PartOne(List<int> numbers)
        {
            return (from x in numbers
                    let y = SumTo - x
                    where numbers.Contains(y)
                    select x * y).First();
        }

        private static int PartTwo(List<int> numbers)
        {
            return (from x in numbers
                    from y in numbers
                    let z = SumTo - x - y
                    where numbers.Contains(z)
                    select x * y * z).First();
        }
        private List<int> GetInput()
        {
            var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day01/input.txt"));
            return input.Select(int.Parse).ToList();
        }
    }
}


