using AdventOfCode2020.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day04
{

    //Part one: Count the number of valid passports - those that have all required fields.
    //Treat cid as optional. In your batch file, how many passports are valid?
    class SolutionDay4 : ISolverSetup
    {
        public void Initialize()
        {
            var input = GetInput();

            var validPasswordCount = PartOne(input);
            Console.WriteLine($"Day 4- Part One. Valid passwords count: {validPasswordCount}");
        }

        private int PartOne(string[] input)
        {
            var validPasswords = 0;
            var requiredFields = GetExpectedFields();
            var line = string.Empty;

            foreach (var passport in input)
            {
                if (passport != "")
                {
                    line += passport + " ";
                }
                else
                {
                    if (CheckRequiredFields(line, requiredFields) == true)
                    {
                        validPasswords++;
                    }
                    line = string.Empty;
                }
            }
            return validPasswords;
        }
        private bool CheckRequiredFields(string line, Tuple<string, string>[] requiredFields)
        {
            var IsPresentList = new List<bool>();
            foreach (var field in requiredFields)
            {
                IsPresentList.Add(line.Contains(field.Item1));
            }
            return !IsPresentList.Contains(false);
        }
        private static Tuple<string, string>[] GetExpectedFields()
        {
            Tuple<string, string>[] fields =
            {
                    new Tuple<string, string>("byr", "Birth Year"),
                    new Tuple<string, string>("iyr", "Issue Year"),
                    new Tuple<string, string>("eyr", "Expiration Year"),
                    new Tuple<string, string>("hgt", "Height"),
                    new Tuple<string, string>("hcl", "Hair Color"),
                    new Tuple<string, string>("ecl", "Eye Color"),
                    new Tuple<string, string>("pid", "Passport ID"),
                    //new Tuple<string, string>("cid", "Country ID"), //Missing cid is fine
             };
            return fields;
        }
        private string[] GetInput()
        {
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day04/input.txt"));
        }
    }
}
