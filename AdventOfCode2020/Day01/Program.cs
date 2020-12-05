using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day01
{
    class Program
    {
        //Find two inputs that sum to 2020 and multiply them together

        private const int SumTo = 2020;
        static void Main(string[] args)
        {
            var numbers = GetInput();

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] + numbers[i] == SumTo)
                    {
                        Console.WriteLine($"Found match: {numbers[i]} + {numbers[j]} = {numbers[i] + numbers[j]}, {numbers[i]} * {numbers[j]} ={numbers[i] * numbers[j]}");
                        return;
                    }
                }

            }
            
        }

        private static List<int> GetInput()
        {
            var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day01/input.txt"));
            return input.Select(int.Parse).ToList();
        }
    }
}


