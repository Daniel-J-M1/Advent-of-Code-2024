using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day0
{
    class BaseCode
    {
        //Reads the Text File that has the days input
        //Example Input.
        static readonly string Info = @"C:\Users\Danie\Documents\Advent of Code\Advent of Code 2024\Advent of Code 2024\Day Inputs\Day1InputA.txt";

        //Set up Input and outputs the answers to the Puzzles.
        static void Main(string[] args)
        {
            //Separates each in in the text file as a string, which is then added to an array called "Input".
            string[] Input = File.ReadAllLines(Info);

            //Outputs the answer to Puzzle 1.
            int PartOne = SetOne(Input);
            Console.WriteLine($"Part One: there are || {PartOne} || vaild passwords.");

            //Outputs the answer to Puzzle 2.
            int PartTwo = SetTwo(Input);
            Console.WriteLine($"Part Two: there are || {PartTwo} || vaild passwords.");

            //Ensures Console stays on screen until closed or the program is stopped.
            Console.ReadKey();
        }

        //First Puzzle Code
        //Base Code for quick setup.
        private static int SetOne(string[] Input)
        {
            return 0;
        }

        //Second Puzzle Code
        //Base Code for quick setup.
        private static int SetTwo(string[] Input)
        {
            return 0;
        }
    }
}
