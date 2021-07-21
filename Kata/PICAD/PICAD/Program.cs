using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PICAD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static WitnessCount DetermineSuspects(int[] rawData)
        {
            var data = rawData;
            var crimeData = new Interval(data[0], data[1]);
            List<Interval> intervals = null;
            if (rawData.Length > 2)
            {
                intervals = ParseIntervals(rawData);
            }

            var witnessCount = ParseWitnesses(crimeData, intervals);
            return witnessCount;
        }

        private static WitnessCount ParseWitnesses(Interval crimeData, List<Interval> intervals)
        {
            int max = 0;
            int min = intervals.Count;
            if (intervals != null)
            {
                for (int i = crimeData.StartTime; i <= crimeData.EndTime; i++)
                {
                    int numWitnessesAtThisTime = 0;
                    foreach (var interval in intervals)
                    {
                        for (int j = interval.StartTime; j <= interval.EndTime; j++)
                        {
                            if (j == i)
                            {
                                numWitnessesAtThisTime++;
                                break;
                            }
                        }
                    }
                    if (numWitnessesAtThisTime > max)
                    {
                        max = numWitnessesAtThisTime;
                    }
                    if (numWitnessesAtThisTime < min)
                    {
                        min = numWitnessesAtThisTime;
                    }
                }
            }
            return new WitnessCount(min, max);
        }

        private static List<Interval> ParseIntervals(int[] rawData)
        {
            List<Interval> witnesses = new List<Interval>();
            int numWitnesses = rawData[2];
            for (int i = 0; i < numWitnesses; i++)
            {
                int startIndex = 2 * i + 3;
                int endIndex = 2 * i + 4;
                if (startIndex < rawData.Length && endIndex < rawData.Length)
                {
                    var interval = new Interval(rawData[startIndex], rawData[endIndex]);
                    witnesses.Add(interval);
                }
            }


            return witnesses;
        }
    }

    public class Interval
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public Interval(int start, int end)
        {
            StartTime = start;
            EndTime = end;
        }
    }

    public class WitnessCount
    {
        public int min { get; set; }
        public int max { get; set; }

        public WitnessCount(int minimum, int maximum)
        {
            min = minimum;
            max = maximum;
        }
    }

    /*
        PICAD - Crime at Piccadily Circus

        Sherlock Holmes is carrying out an investigation into the crime at Piccadily Circus. Holmes is trying to determine the 
        maximal and minimal number of people staying simultaneously at the crime scene at a moment when the crime could have 
        been commited. Scotland Yard has already carried out a thorough investigation already, interrogated everyone seen at 
        the crime scene and determined what time they appeared at the crime scene and what time they left. Doctor Watson offered 
        his help to process the data gathered by Scotland Yard and find the numbers interesting Sherlock Holmes, but he has 
        some difficulties. Help him!
       
        Task

        Write a program which reads from standard input the time interval during which the crime was commited and the data gathered 
        by Scotland Yard, finds the minimal and the maximal number of people present simultaneously in the time interval when 
        the crime could have been commited, (these numbers can be zero, though it would seem strange that no one was present 
        at the crime scene when the crime was commited, but that's the type of crime Holmes and Watson have to deal with) writes 
        the outcome to standard output.
       
        Input

        Ten test cases (given one under another, you have to process all!). The first line of each test case consists of two 
        integer numbers p and k, 0<=p<=k<=100000000. These denote the first and the last moment when the crime could have been 
        commited. The second line of each test case contains one integer n, 3<=n<=5000. This is the number of people interrogated 
        by Scotland Yard. The next n lines consist of two integers - line i+2 contains numbers ai and bi separated by a single 
        space, 0<=ai<=bi<=1000000000. These are the moments at which the i-th person apperared at and left the crime scene 
        respectively. It means that the i-th person was at the crime scene for the whole time from moment ai until moment 
        bi (inclusive).
       
        Output

        For every test case your program should write to the standard output only one line with two integers separated by a 
        single space: the minimal and maximal number of people staying simultaneously at the crime scene, in the interval between 
        moment p and k, (inclusive).
       
        Example

        Only one test case.
       
        Input:
       
        5 10
       
        4
       
        1 8
       
        5 8
       
        7 10
       
        8 9
       
        Output:
       
        1 4


     */
}
