using System;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

namespace MontyHall
{
    public static class MontyHall
    {
        public static void Main(string[] args)
        {

            int numberOfIterations = 1000000;

            RunSimulation(numberOfIterations, "First", "Stay");
            RunSimulation(numberOfIterations, "Second", "Switch");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void RunSimulation(int iterations, string whichRun, string policy)
        {
            Dictionary<string, int> gameResults = new Dictionary<string, int>();
            gameResults.Add("Won", 0);
            gameResults.Add("Lost", 0);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{whichRun} run: Policy = {policy}");
            for (int i = 0; i < iterations; i++)
            {
                var game = new MontyHallGame();
                game.PlayTheGameSimulated();
                if (policy == "Stay")
                {
                    if (game.ChosenDoor.Occupant == OccupantType.Car)
                    {
                        gameResults["Won"] += 1;
                    }
                    else
                    {
                        gameResults["Lost"] += 1;
                    }
                }
                else
                {

                    if (game.ClosedDoor.Occupant == OccupantType.Car)
                    {
                        gameResults["Won"] += 1;
                    }
                    else
                    {
                        gameResults["Lost"] += 1;
                    }

                }

            }
            Console.WriteLine("*********************************************************************");
            Console.WriteLine($"Wins:\t{gameResults["Won"]}\t\tLosses:\t{gameResults["Lost"]}");
            Console.WriteLine($"Win percentage: {((decimal)gameResults["Won"]/iterations)*100}");
            Console.WriteLine("*********************************************************************");
        }
    }

    public enum OccupantType
    {
        Goat,
        Car
    }

    public class Door
    {
        public int Id;
        public OccupantType Occupant;

        public Door(int id, OccupantType occ)
        {
            Id = id;
            Occupant = occ;
        }
    }

    public class ThreeDoors
    {


        public ThreeDoors()
        {
            Door1 = new Door(1, OccupantType.Car);
            Door2 = new Door(2, OccupantType.Goat);
            Door3 = new Door(3, OccupantType.Goat);
        }

        public ThreeDoors(OccupantType o1, OccupantType o2, OccupantType o3)
        {
            Door1 = new Door(1, o1);
            Door2 = new Door(2, o2);
            Door3 = new Door(3, o3);
        }

        public Door Door1 { get; set; }
        public Door Door2 { get; set; }
        public Door Door3 { get; set; }
    }

    public class MontyHallGame
    {
        private readonly Random _random = new Random();
        private ThreeDoors threeDoors { get; set; }

        public Door ChosenDoor { get; set; }
        public Door MontyDoor { get; set; }
        public Door ClosedDoor { get; set; }


        public MontyHallGame()
        {
        }

        public void PlayTheGameSimulated()
        {
            PlaceThePrizes();
            ContestantChoosesDoor();
            MontyOpensDoor();
            MontyLeavesDoorShut();
        }

        public void PlaceThePrizes()
        {

            threeDoors = GenerateRandomPrizes();
        }

        public void ContestantPicksADoor()
        {
            int firstChoice = RandomNumber(3);
            ChosenDoor = GetDoorFromNum(++firstChoice);
        }

        public void PlayGame()
        {
        }

        // Generates a random number within a range.      
        public int RandomNumber(int max)
        {
            return _random.Next(max);
        }
        public ThreeDoors GenerateFixedOccupants()
        {
            OccupantType[] occArray = { OccupantType.Car, OccupantType.Goat, OccupantType.Goat };
            return new ThreeDoors(occArray[0], occArray[1], occArray[2]);
        }

        public ThreeDoors GenerateRandomPrizes()
        {
            OccupantType[] occArray = { OccupantType.Car, OccupantType.Goat, OccupantType.Goat };
            List<int> numbers = GetRandomNumbers();
            return new ThreeDoors(occArray[numbers[0]], occArray[numbers[1]], occArray[numbers[2]]);
        }

        public void ContestantChoosesDoor()
        {

            int doorNum = GetRandomNumber();
            ChosenDoor = GetDoorFromNum(++doorNum);
        }

        public void MontyOpensDoor()
        {
            int shown; //the shown door
            do
            {
                shown = GetRandomNumber();
                shown++;
            }
            while (GetDoorFromNum(shown).Occupant == OccupantType.Car || shown == ChosenDoor.Id); //don't show the winner or the choice

            MontyDoor = GetDoorFromNum(shown);
        }

        public void MontyLeavesDoorShut()
        {
            if ((ChosenDoor.Id == 1 && MontyDoor.Id == 2)
                || (ChosenDoor.Id == 2 && MontyDoor.Id == 1))
            {
                ClosedDoor = threeDoors.Door3;
            }
            else if ((ChosenDoor.Id == 1 && MontyDoor.Id == 3)
                || (ChosenDoor.Id == 3 && MontyDoor.Id == 1))
            {
                ClosedDoor = threeDoors.Door2;
            }
            else 
            {
                ClosedDoor = threeDoors.Door1;
            }

        }

        public void PrintDoorsAndPrizes()
        {
            Console.WriteLine("Show 'em what they coulda won!");
            Console.WriteLine($"Behind Door 1: {threeDoors.Door1.Occupant}");
            Console.WriteLine($"Behind Door 2: {threeDoors.Door2.Occupant}");
            Console.WriteLine($"Behind Door 3: {threeDoors.Door3.Occupant}");
            Console.WriteLine();

        }

        private Door ReturnTheGoat(List<Door> doors)
        {
            // Second implementation
            int doorToTryFirst = RandomNumber(2);
            if (doorToTryFirst == 0)
            {
                if (doors[doorToTryFirst].Occupant == OccupantType.Goat)
                {
                    return doors[doorToTryFirst];
                }
                else if (doors[++doorToTryFirst].Occupant == OccupantType.Goat)
                {
                    return doors[doorToTryFirst];
                }

            }
            else
            {
                if (doors[doorToTryFirst].Occupant == OccupantType.Goat)
                {
                    return doors[doorToTryFirst];
                }
                else if (doors[--doorToTryFirst].Occupant == OccupantType.Goat)
                {
                    return doors[doorToTryFirst];
                }
            }

            return null;


            // Original implementation that results in 44% win rate
            // if (doors[0].Occupant == OccupantType.Goat)
            // {
            //     return doors[0];
            // }
            // else
            // {
            //     return doors[1];
            // }
        }

        private List<Door> GetRemainingDoors(Door d)
        {
            List<Door> doors = new List<Door>();
            if (d == threeDoors.Door1)
            {
                doors.Add(threeDoors.Door2);
                doors.Add(threeDoors.Door3);
            }
            else if (d == threeDoors.Door2)
            {
                doors.Add(threeDoors.Door1);
                doors.Add(threeDoors.Door3);
            }
            else if (d == threeDoors.Door3)
            {
                doors.Add(threeDoors.Door1);
                doors.Add(threeDoors.Door2);
            }

            return doors;
        }

        private Door GetDoorFromNum(int doorNum)
        {
            Door thisDoor = null;
            switch (doorNum)
            {
                case 1:
                    thisDoor = threeDoors.Door1;
                    break;
                case 2:
                    thisDoor = threeDoors.Door2;
                    break;
                case 3:
                    thisDoor = threeDoors.Door3;
                    break;
                default:
                    break;

            }

            return thisDoor;
        }

        private int GetRandomNumber()
        {
            return RandomNumber(3);
        }



        private List<int> GetRandomNumbers()
        {
            var numbers = new List<int>();
            do
            {
                int num = RandomNumber(3);
                if (numbers.Contains(num))
                {
                    continue;
                }

                numbers.Add(num);
            } while (numbers.Count < 3);

            return numbers;
        }
    }
}
