using AdventOfCode2020.Day01;
using AdventOfCode2020.Day02;
using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var availableSolutions = Enum.GetValues(typeof(Days));
            Console.WriteLine("Enter a number for the solution you want to run:");
            foreach (var sol in availableSolutions)
            {
                Console.WriteLine(sol.ToString() + ": " + (int)sol);
            }
            _ = int.TryParse(Console.ReadLine(), out int day);
            RunSolution(day);
        }
        private static void RunSolution(int day)
        {
            switch (day)
            {
                case 0:
                    break;
                case 1:
                    var solution = new SolutionDay1();
                    solution.Initialize();
                    break;
                case 2:
                    var solution2 = new SolutionDay2();
                    solution2.Initialize();
                    break;                 
            }
        }
        enum Days
        {
            AllDays,
            Day01,
            Day02,
            Day03,
        }
    }
}
