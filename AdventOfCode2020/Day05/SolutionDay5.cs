using AdventOfCode2020.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day05
{
    //Part One: As a sanity check, look through your list of boarding passes. What is the highest seat ID on a boarding pass?
    //Every seat also has a unique seat ID: multiply the row by 8, then add the column. 
    //Part Two: Your seat wasn't at the very front or back, though; the seats with IDs +1 and -1 from yours will be in your list.
    class SolutionDay5 : ISolverSetup
    {
        private List<Seat> SeatList = new List<Seat>();
        public void Initialize()
        {
            var input = GetInput();
            PartOne(input);
            Console.WriteLine($"Day 5- Part One. Highest seat id: {SeatList.Max(s=>s.Index)}");

            var mySeat = PartTwo();
            Console.WriteLine($"Day 5- Part Two. My seat id is: {mySeat.Index+1}");
        }

        private Seat PartTwo()
        {
            var index = SeatList
                .OrderBy(s => s.Index)
                .ToList();

           return index
                .Where(s => !SeatList
                .Exists(myseat => myseat.Index == s.Index + 1))
                .First();
        }

        private void PartOne(string[] input)
        {
            foreach (var row in input)
            {
               CheckPosition(row);
            }
        }
        private void CheckPosition(string row)
        {
            var limits = new Limits();
            foreach (var letter in row.ToCharArray())
            {
                switch (letter.ToString())
                {
                    case "F":
                        limits.ColumnUpperLimit = (limits.ColumnUpperLimit + limits.ColumnLowerLimit) / 2;
                        break;
                    case "B":
                        limits.ColumnLowerLimit = (int)Math.Ceiling((decimal)(limits.ColumnUpperLimit + limits.ColumnLowerLimit) / 2);
                        break;
                    case "R":
                        limits.RowLowerLimit = (int)Math.Ceiling((decimal)(limits.RowUpperLimit + limits.RowLowerLimit) / 2);
                        break;
                    case "L":
                        limits.RowUpperLimit = (limits.RowUpperLimit + limits.RowLowerLimit) / 2;
                        break;
                }
            }
            var seat = new Seat() { Column = limits.ColumnUpperLimit, Row = limits.RowUpperLimit, Index = limits.ColumnUpperLimit * 8 + limits.RowUpperLimit };
            SeatList.Add(seat);
        }
        public string[] GetInput()
        {
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day05/input.txt"));
        }
    }
    class Seat
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public int Index { get; set; }

    }
     class Limits
    {
        public int ColumnLowerLimit { get; set; } = 0;
        public int ColumnUpperLimit { get; set; } = 127;
        public int RowUpperLimit { get; set; } = 7;
        public int RowLowerLimit { get; set; } = 0;
    }
}
