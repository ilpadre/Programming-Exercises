using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine($"Human player registers a {RPS.PlayOneGame()}");
                Console.WriteLine();
            } while (RPS.Continue());

            Console.WriteLine("Record of wins, losses, and draws:");
            RPS.PrintResults();

            RPS.PrintHistory();

        }
    }

    public class RPS
    {
        public static string[] Plays = {"Rock", "Paper", "Scissors"};

        public static Dictionary<string, int> playStats = new Dictionary<string, int>();

        public static Dictionary<string, int> winsLosses = new Dictionary<string, int>();

        static RPS()
        {
            playStats.Add("Rock", 0);
            playStats.Add("Paper", 0);
            playStats.Add("Scissors", 0);

            winsLosses.Add("Win", 0);
            winsLosses.Add("Lose", 0);
            winsLosses.Add("Draw", 0);
        }

        public static string PlayOneGame(string computerPlayPassedIn = null)
        {
            string[] game = new string[2];
            game[0] = HumanPlays();           
            game[1] = ComputerPlays(computerPlayPassedIn);
            string result =  DecideOutcome(game[0], game[1]);
            RecordResult(result);
            StorePlayHistory(game[0]);
            return result;
        }

        public static string DecideOutcome(string player1, string player2)
        {
            if (player1 == "Rock")
            {
                if (player2 == "Scissors")
                {
                    return "Win";
                }
                else if (player2 == "Paper")
                {
                    return "Lose";
                }
            }
            else if (player1 == "Scissors")
            {
                if (player2 == "Paper")
                {
                    return "Win";
                }
                else if (player2 == "Rock")
                {
                    return "Lose";
                }
            }
            else if (player1 == "Paper")
            {
                if (player2 == "Rock")
                {
                    return "Win";
                }
                else if (player2 == "Scissors")
                {
                    return "Lose";
                }
            }
            return "Draw";
        }

        public static void StorePlayHistory(string play)
        {
            playStats[play]++;
        }

        public static void RecordResult(string result)
        {
            winsLosses[result]++;
        }

        public static string ComputerPlays(string testPlay = null)
        {
            if (testPlay != null)
            {
                return testPlay;
            }
            int num = GetRandomNum(0,3);
            return Plays[num];
        }

        public static string HumanPlays()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Rock, Paper, or Scissors: ");
            string response = Console.ReadLine();
            Console.WriteLine();
            return response;
        }

        public static int GetRandomNum(int from, int to)
        {
            Random rnd = new Random();
            return rnd.Next(from, to);

        }

        public static void PrintResults()
        {
            Console.WriteLine();
            Console.WriteLine("Number of wins, losses, and draws:");
            Console.WriteLine($"Wins: {winsLosses["Win"]}\t\tLosses: {winsLosses["Lose"]}\tDraws: {winsLosses["Draw"]}");
            Console.WriteLine();
        }

        public static void PrintHistory()
        {
            Console.WriteLine();
            Console.WriteLine("Number of times each input was played:");
            Console.WriteLine($"Rock: {playStats["Rock"]}\tPaper: {playStats["Paper"]}\tScissors: {playStats["Scissors"]}");
            Console.WriteLine();
        }

        public static bool Continue()
        {
            Console.WriteLine();
            Console.Write("Continue? (Y/N)    ");
            string input = Console.ReadLine();
            return input == "Y" ? true : false;
        }

    }
}
