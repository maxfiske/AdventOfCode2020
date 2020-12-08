using AdventOfCode2020.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{

    //Part one: Count the number of valid passports - those that have all required fields.
    //Treat cid as optional. In your batch file, how many passports are valid?
    //Part two: Your job is to count the passports where all required fields are both present and valid according to the rules
    class SolutionDay4 : ISolverSetup
    {
        public void Initialize()
        {
            var input = GetInput();

            var validPasswordCountPartOne = PartOne(input);
            Console.WriteLine($"Day 4- Part One. Valid passwords count: {validPasswordCountPartOne}");

            var validPasswordCountPartTwo = PartTwo(input);
            Console.WriteLine($"Day 4- Part One. Valid passwords count: {validPasswordCountPartTwo}");
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
                    if (CheckRequiredFieldsPartOne(line, requiredFields) == true)
                    {
                        validPasswords++;
                    }
                    line = string.Empty;
                }
            }
            return validPasswords;
        }
        private int PartTwo(string[] input)
        {
            var requiredFields = GetExpectedFields();

            var validPasswords = 0;
            var line = string.Empty;

            foreach (var passport in input)
            {
                if (passport != "")
                {
                    line += passport + " ";
                }
                else
                {
                    if (CheckRequiredFieldsPartTwo(line, requiredFields) == true)
                    {
                        validPasswords++;
                    }
                    line = string.Empty;
                }
            }
            return validPasswords;
        }

        private bool CheckRequiredFieldsPartTwo(string line, Tuple<string, string>[] requiredFields)
        {
            var IsPresentList = new List<bool>();
            foreach (var field in requiredFields)
            {
                IsPresentList.Add(line.Contains(field.Item1));

                if (CheckStrictRules(line) == true)
                {
                    IsPresentList.Add(true);
                }
                else
                {
                    IsPresentList.Add(false);
                }
            }
            return !IsPresentList.Contains(false);
        }
        private bool CheckStrictRules(string password)
        {
            var rules = new List<string>() { @"byr:(200[0-2]|19[2-9][0-9])",
                                                     @"iyr:(2020|201[0-9])",
                                                     @"eyr:(2030|202[0-9])",
                                                     @"hgt:((1[5-8][0-9]|19[0-3])cm)|hgt:(7[0-6]|59|6[0-9])in",
                                                     @"hcl:(#[0-9a-f]{6})",
                                                     @"ecl:(amb|blu|brn|gry|grn|hzl|oth)",
                                                     @"pid:(\d{9}\b)" };

            return rules.All(reg => Regex.IsMatch(password, reg));
        }
        private bool CheckRequiredFieldsPartOne(string line, Tuple<string, string>[] requiredFields)
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
