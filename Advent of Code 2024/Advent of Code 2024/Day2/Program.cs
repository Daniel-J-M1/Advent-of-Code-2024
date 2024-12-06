using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day2
{
    class Day2
    {
        //Reads the Text File that has the days input
        //Example Input.
        static readonly string Info = @"C:\Users\Danie\Documents\Advent of Code\Advent of Code 2024\Advent of Code 2024\Day Inputs\Day2Input.txt";

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
            string[] TheSplit;

            int Safe = 0;
            foreach (string Line in Input)
            {
                bool Line1 = false;
                bool Down = false;
                bool Up = false;

                TheSplit = Line.Split(" ");

                int[] LineSplit = Array.ConvertAll<string, int>(TheSplit, int.Parse);
                int Counter = 0;

                for (int i = 0; i < LineSplit.Length - 1; i++)
                {
                    if (LineSplit[0] < LineSplit[1] && Line1 == false)
                    {
                        Line1 = true;
                        Up = true;
                    }
                    else if (LineSplit[0] > LineSplit[1])
                    {
                        Line1 = true;
                        Down = true;
                    }

                    if (LineSplit[i] < LineSplit[i + 1] && LineSplit[i + 1] - LineSplit[i] <= 3 && Up == true)
                    {
                        Counter++;
                    }
                    else if (LineSplit[i] > LineSplit[i + 1] && LineSplit[i] - LineSplit[i + 1] <= 3 && Down == true)
                    {
                        Counter++;
                    }

                    if (Counter == LineSplit.Length - 1)
                    {
                        Safe++;
                    }
                }

            }

            return Safe;
        }

        //Second Puzzle Code
        //Base Code for quick setup.
        //Did not work, brute force and luck got me the right answer.
        private static int SetTwo(string[] Input)
        {
            string[] TheSplit;

            int Safe = 0;
            foreach (string Line in Input)
            {
                bool Line1 = false;
                bool Down = false;
                bool Up = false;
                //bool Life = true;
                //bool ProtectSkip = false;
                //bool Skip = false;

                
                //int Index = 1;

                TheSplit = Line.Split(" ");
                //Console.WriteLine(Line);
                int[] LineSplit = Array.ConvertAll<string, int>(TheSplit, int.Parse);

                List<int> TheList = LineSplit.OfType<int>().ToList();

                int Counter = 0;
                
                for (int i = 0; i < TheList.Count - 1; i++)
                {

                    if (TheList[0] < TheList[1])
                    {
                        Line1 = true;
                        Up = true;
                    }
                    else if (TheList[0] > TheList[1])
                    {
                        Line1 = true;
                        Down = true;
                    }
                        
                    if (TheList[i] < TheList[i + 1] && TheList[i + 1] - TheList[i] <= 3 && Up == true)
                    
                    {
                        //Console.WriteLine($"Success {TheList[i]}");
                    }
                        
                    else if (TheList[i] > TheList[i + 1] && TheList[i] - TheList[i + 1] <= 3 && Down == true)
                    {
                        //Console.WriteLine($"Success {TheList[i]}");
                    }
                    else if (i <= TheList.Count - 1)
                    {

                        Console.WriteLine($"{Line}   {TheList[i + 1]}Break==========================================================");
                        TheList.RemoveAt(i + 1);
                        break;
                    }
                }
                Line1 = false;
                Up = false;
                Down = false;


                for (int i = 0; i < TheList.Count - 1; i++)
                {
                    //Console.WriteLine(TheList[i]);

                    if (TheList[0] < TheList[1] && Line1 == false)
                    {
                        Line1 = true;
                        Up = true;
                    }
                    else if (TheList[0] > TheList[1] && Line1 == false)
                    {
                        Line1 = true;
                        Down = true;
                    }
                    Console.WriteLine($"After {TheList[i]}");

                    if (TheList[i] < TheList[i + 1] && TheList[i + 1] - TheList[i] <= 3 && Up == true)
                        {
                            Counter++;
                        }
                        else if (TheList[i] > TheList[i + 1] && TheList[i] - TheList[i + 1] <= 3 && Down == true)
                        {
                            Counter++;
                        }
                    }
                

                if (Counter == TheList.Count - 1)
                {
                    Safe++;
                }


            }

            return Safe;
        }


            //for (int i = 0; i < LineSplit.Length - 1; i++)
            //{
            //    ProtectSkip = false;
            //    //Console.WriteLine(LineSplit[0]);
            //    if (LineSplit[0] < LineSplit[1] && Line1 == false && Life == true)
            //    {
            //        Line1 = true;
            //        Up = true;
            //    }
            //    else if (LineSplit[0] > LineSplit[1] && Line1 == false && Life == true)
            //    {
            //        Line1 = true;
            //        Down = true;
            //    }

            //    if (LineSplit[i] < LineSplit[i + 1] && LineSplit[i + 1] - LineSplit[i] <= 3 && Up == true && Skip == false)
            //    {
            //        Counter++;
            //    }
            //    else if (LineSplit[i] > LineSplit[i + 1] && LineSplit[i] - LineSplit[i + 1] <= 3 && Down == true && Skip == false)
            //    {
            //        Counter++;
            //    }
            //    else if (Life == true && i + 2 <= LineSplit.Length - 1)
            //    {

            //        //Console.WriteLine($"First is the index number {LineSplit[i]} and {LineSplit[i + 1]} and lastly the counter {Counter}.");
            //        //Console.WriteLine($"First is the Index {Index} and lastly the length {LineSplit.Length}.");
            //        if (LineSplit[0] < LineSplit[2] && i == 0)
            //        {
            //            Line1 = true;
            //            Up = true;
            //            Down = false;
            //        }
            //        else if (LineSplit[0] > LineSplit[2] && i == 0)
            //        {
            //            Line1 = true;
            //            Down = true;
            //            Up = false;
            //        }


            //        if (LineSplit[i] < LineSplit[i + 2] && LineSplit[i + 2] - LineSplit[i] <= 3 && Up == true && i < LineSplit.Length - 2)
            //        {
            //            Counter++;
            //        }
            //        else if (LineSplit[i] > LineSplit[i + 2] && LineSplit[i] - LineSplit[i + 2] <= 3 && Down == true && i < LineSplit.Length - 2)
            //        {
            //            Counter++;
            //        }

            //        Life = false;
            //        Skip = true;
            //        ProtectSkip = true;
            //        Index = 2;
            //    }
            //    else if (Life == true && i == LineSplit.Length - 1)
            //    {
            //        Counter++;
            //    }

            //if (Counter >= LineSplit.Length - Index)
            //{
            //    Safe++;
            //    //Console.WriteLine($"It went up {Counter} and {LineSplit.Length - Index}");
            //}

            //if (Skip == true && ProtectSkip == false)
            //{
            //    Skip = false;
            //}
            //}

            //}
            //Console.WriteLine(Input.Length);







            //    public object PartOne(string Input) =>
            //        ParseSamples(Input).Count(Valid);

            //    public object PartTwo(string Input) =>
            //        ParseSamples(Input).Count(samples => Attenuate(samples).Any(Valid));

            //    IEnumerable<int[]> ParseSamples(string Input) =>
            //        from line in Input.Split("\n")
            //        let samples = line.Split(" ").Select(int.Parse)
            //        select samples.ToArray();

            //    IEnumerable<int[]> Attenuate(int[] samples) =>
            //        from i in Enumerable.Range(0, samples.Length + 1)
            //        let before = samples.Take(i - 1)
            //        let after = samples.Skip(i)
            //        select Enumerable.Concat(before, after).ToArray();

            //    bool Valid(int[] samples)
            //    {
            //        var pairs = Enumerable.Zip(samples, samples.Skip(1));
            //            return
            //            pairs.All(p => 1 <= p.Second - p.First && p.Second - p.First <= 3) ||
            //            pairs.All(p => 1 <= p.First - p.Second && p.First - p.Second <= 3);
            //    }

        }
    }
