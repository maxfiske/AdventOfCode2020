using AdventOfCode2020.Day01;
using AdventOfCode2020.Day02;
using AdventOfCode2020.Day03;
using AdventOfCode2020.Day04;
using AdventOfCode2020.Day05;
using AdventOfCode2020.Day06;
using AdventOfCode2020.Day08;
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
                case 3:
                    var solution3 = new SolutionDay3();
                    solution3.Initialize();
                    break;
                case 4:
                    var solution4 = new SolutionDay4();
                    solution4.Initialize();
                    break;
                case 5:
                    var solution5 = new SolutionDay5();
                    solution5.Initialize();
                    break;
                case 6:
                    var solution6 = new SolutionDay6();
                    solution6.Initialize();
                    break;
                case 7:
                    var solution7 = new SolutionDay7();
                 
                    break;
                case 8:
                    var solution8 = new SolutionDay8();
                    solution8.Initialize();
                    break;
            }
        }
        enum Days
        {
            AllDays,
            Day01,
            Day02,
            Day03,
            Day04,
            Day05,
            Day06,
            Day07,
            Day08,
        }
    }
}
