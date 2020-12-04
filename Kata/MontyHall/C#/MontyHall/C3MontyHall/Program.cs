using System;

namespace C3MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            int stayWinCount = 0;
            int switchWinCount = 0;

            Random rand = new Random();
            for (int i = 0; i < 100000; i++)
            {
                // Initialize bool[] with each option set to false

                bool[] doors = { false, false, false };
                
                // Set the one of the bools to be true - the prize


                int winningChoice = rand.Next(doors.Length);

                doors[winningChoice] = true;

                // Choose a door randomly, random 1-3

                int contestentChoice = rand.Next(doors.Length);


                int revealedDoor;
                int closedDoor = -1;

                while (true)
                {
                    int choice = rand.Next(doors.Length);
                    if (!doors[choice] && choice != contestentChoice)
                    {
                        revealedDoor = choice;
                        break;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    if (j != contestentChoice && j != revealedDoor)
                    {
                        closedDoor = j;
                        break;
                    }
                }

                if (doors[contestentChoice])
                {
                    stayWinCount++;
                    continue;
                }

                if (doors[closedDoor])
                {
                    switchWinCount++;
                }
            }

            Console.WriteLine($"Stay:\nWins: {stayWinCount}\nPercentage Won: {stayWinCount / 100000.0}");
            Console.WriteLine($"Switch:\nWins: {switchWinCount}\nPercentage Won: {switchWinCount / 100000.0}");

        }
    }
}
