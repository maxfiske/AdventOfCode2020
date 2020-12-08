using AdventOfCode2020.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Day08
{

    class SolutionDay8 : ISolverSetup
    {
        static List<string> final = new List<string>();
        public void Initialize()
        {
            var input = GetInput();
        }

        public string[] GetInput()
        {
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day08/input.txt"));
        }
    }
}
