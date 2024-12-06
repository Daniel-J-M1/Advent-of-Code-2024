using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Day3
{
    class Day3
    {
        //Reads the Text File that has the days input
        //Example Input.
        static readonly string Info = @"C:\Users\Danie\Documents\Advent of Code\Advent of Code 2024\Advent of Code 2024\Day Inputs\Day3Input.txt";

        //Set up Input and outputs the answers to the Puzzles.
        static void Main(string[] args)
        {
            //Separates each in in the text file as a string, which is then added to an array called "Input".
            string[] Input = File.ReadAllLines(Info);

            //Trigger Cleanup for Puzzle
            List<string> CleanUp = SetOneCleanUp(Input);

            List<string> CleanUpPart2 = SetTwoCleanUp(Input);

            //Outputs the answer to Puzzle 1.
            int PartOne = SetOne(CleanUp);
            Console.WriteLine($"Part One: there are || {PartOne} || vaild passwords.");

            //Outputs the answer to Puzzle 2.
            int PartTwo = SetTwo(CleanUpPart2);
            Console.WriteLine($"Part Two: there are || {PartTwo} || vaild passwords.");

            //Ensures Console stays on screen until closed or the program is stopped.
            Console.ReadKey();
        }

        //Input Cleanup - Part 1

        public static List<string> SetOneCleanUp(string[] Input)
        {
            List<string> CleanedInput = new List<string>();
            List<string> CarryA = new List<string>();

            char y;

            foreach (string Line in Input)
            {
                string[] Attempt = Line.Split("mul(");

                string z;

                foreach (string x in Attempt)
                {
                    int Index = x.IndexOf(')');

                    if (Index >= 0)
                    {
                        z = x.Substring(0, Index);


                        CarryA.Add(z);
                    }
                }


            }

            foreach (string Line in CarryA)
            {
                //Console.WriteLine(Line);

                if (Regex.IsMatch(Line, @"^\d") && Line.Contains(',') && !Regex.IsMatch(Line, @"[a-zA-Z]") && !Line.Contains('-') && !Line.Contains('*') && !Line.Contains('{') && !Line.Contains('}') && !Line.Contains('{'))
                {
                    CleanedInput.Add(Line);
                }
            }

            return CleanedInput;
        }

        public static List<string> SetTwoCleanUp(string[] Input)
        {
            List<string> CleanedInput = new List<string>();
            List<string> CarryA = new List<string>();
            List<string> CarryB = new List<string>();
            List<string> CarryC = new List<string>();
            List<string> CarryD = new List<string>();

            bool AddToList = true;

            char y;

            foreach (string Line in Input)
            {
                string[] Attempt = Line.Split("mul(");



                foreach (string x in Attempt)
                {
                    CarryA.Add(x);
                }
            }

            foreach (string Q in CarryA)
            {
                string[] Removal1 = Q.Split("do()");

                for (int i = 0; i < Removal1.Length; i++)
                {
                    if (i != 0)
                    {
                        CarryB.Add("do()");
                    }
                    CarryB.Add(Removal1[i]);
                }
            }

            foreach (string E in CarryB)
            {

                string[] Removal2 = E.Split("don't()");

                for (int i = 0; i < Removal2.Length; i++)
                {
                    if (i != 0)
                    {
                        CarryC.Add("don't()");
                    }


                    CarryC.Add(Removal2[i]);
                }
            }

            string z;

            foreach (string R in CarryC)
            {
                int Index = R.IndexOf(')');
                if (Index >= 0 && R != "do()" && R != "don't()")
                {
                    z = R.Substring(0, Index);


                    CarryD.Add(z);
                }else if (R == "do()")
                {
                    CarryD.Add(R);
                }
                else if (R == "don't()")
                {
                    CarryD.Add(R);
                }
            }


            foreach (string Line in CarryD)
            {
                //Console.WriteLine(Line);
                if (Line == "do()")
                {
                    AddToList = true;
                }
                else if (Line == "don't()")
                {
                    AddToList = false;
                }

                if (Regex.IsMatch(Line, @"^\d") && Line.Contains(',') && !Regex.IsMatch(Line, @"[a-zA-Z]") && !Line.Contains('-') && !Line.Contains('*') && !Line.Contains('{') && !Line.Contains('}') && !Line.Contains('{') && AddToList == true)
                {
                    CleanedInput.Add(Line);
                    Console.WriteLine(Line);
                }
            }


            return CleanedInput;
        }

        //First Puzzle Code
        //Base Code for quick setup.
        private static int SetOne(List<string> Input)
        {
            int Total = new int();

            foreach (string Line in Input)
            {
                string[] SeparationString = Line.Split(',');
                int[] Separation = Array.ConvertAll<string, int>(SeparationString, int.Parse);
                Total = Total + (Separation[0] * Separation[1]);
            }
            return Total;
        }

        //Second Puzzle Code
        //Base Code for quick setup.
        private static int SetTwo(List<string> Input)
        {
            int Total = new int();

            foreach (string Line in Input)
            {
                string[] SeparationString = Line.Split(',');
                int[] Separation = Array.ConvertAll<string, int>(SeparationString, int.Parse);
                Total = Total + (Separation[0] * Separation[1]);
            }
            return Total;
        }
    }
}
