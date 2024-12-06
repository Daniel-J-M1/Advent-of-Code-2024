using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day1
{
    class Day1
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
            Console.WriteLine($"Part One: The total is || {PartOne} ||.");

            //Outputs the answer to Puzzle 2.
            int PartTwo = SetTwo(Input);
            Console.WriteLine($"Part Two: The total is || {PartTwo} ||.");

            //Ensures Console stays on screen until closed or the program is stopped.
            Console.ReadKey();
        }

        //First Puzzle Code
        //Base Code for quick setup.
        private static int SetOne(string[] Input)
        {
            List<int> FirstList = new List<int>();
            List<int> SecondList = new List<int>();
            List<int> Difference = new List<int>();
            string[] TheSplit;

            foreach (string Line in Input)
            {
                TheSplit = Line.Split("   ");

                int[] ToANumber = Array.ConvertAll<string, int>(TheSplit, int.Parse);
                FirstList.Add(ToANumber[0]);
                SecondList.Add(ToANumber[1]);
            }

            FirstList.Sort();
            SecondList.Sort();
            
            int Index = 0;

            foreach (int A in FirstList)
            {
                int B = SecondList[Index];
                if (A < B)
                {
                    int C = B - A;
                    Difference.Add(C);
                } else if (A > B)
                {
                    int C = A - B;
                    Difference.Add(C);
                }

                Index++;

            }

            int Result = Difference.Sum();

            return Result;
        }

        //Second Puzzle Code
        //Base Code for quick setup.
        private static int SetTwo(string[] Input)
        {
            List<int> FirstList = new List<int>();
            List<int> SecondList = new List<int>();
            List<int> Similarity = new List<int>();
            string[] TheSplit;

            foreach (string Line in Input)
            {
                TheSplit = Line.Split("   ");

                int[] ToANumber = Array.ConvertAll<string, int>(TheSplit, int.Parse);
                FirstList.Add(ToANumber[0]);
                SecondList.Add(ToANumber[1]);
            }

            FirstList.Sort();
            SecondList.Sort();

            

            foreach (int A in FirstList)
            {
                int Control = A;
                int Counter = 0;
                foreach (int B in SecondList)
                {
                    if (Control == B)
                    {
                        Counter++;
                    }
                }
                Similarity.Add(A * Counter);
            }

            int Result = Similarity.Sum();

            return Result;
        }
    }
}
