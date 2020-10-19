using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MontyHall.Tests
{
    public class Tests
    {
        private MontyHallGame _thisGame = null;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void HardCodedUsingDefaultConstructorGivesTwoGoatsAndACar()
        {
            ThreeDoors doors = new ThreeDoors();
            CountOccupantsAndAssert(doors);
        }

        [Test]
        public void HardCodedUsingSecondConstructorGivesTwoGoatsAndACar()
        {
            ThreeDoors doors = new ThreeDoors(OccupantType.Goat, OccupantType.Car, OccupantType.Goat);
            CountOccupantsAndAssert(doors);
        }

        [Test]
        public void GenerateFixedOccupantsGivesTwoGoatsAndACar()
        {
            ThreeDoors doors = _thisGame.GenerateFixedOccupants();
            CountOccupantsAndAssert(doors);
        }

        [Test]
        public void GenerateRandomOccupantsGivesTwoGoatsAndACar()
        {
            ThreeDoors doors = _thisGame.GenerateRandomPrizes();
            CountOccupantsAndAssert(doors);
        }

        [Test]
        public void GenerateContestantDoorChoice()
        {
            int[] nums = {1, 2, 3};
            _thisGame = new MontyHallGame();
            _thisGame.PlaceThePrizes();
            _thisGame.ContestantChoosesDoor();
            int doorNum = _thisGame.ChosenDoor.Id;
            Assert.IsTrue(nums.Contains(doorNum));
        }

        [Test]
        public void MontyDoorRevealsGoat()
        {
            _thisGame = new MontyHallGame();
            _thisGame.PlaceThePrizes();
            _thisGame.ContestantChoosesDoor();
            _thisGame.MontyOpensDoor();
            Assert.AreEqual(OccupantType.Goat, _thisGame.MontyDoor.Occupant);
        }

        [Test]
        public void DoorLeftClosedIsNotNull()
        {
            _thisGame = new MontyHallGame();
            _thisGame.PlaceThePrizes();
            _thisGame.ContestantChoosesDoor();
            _thisGame.MontyOpensDoor();
            _thisGame.MontyLeavesDoorShut();
            Assert.IsNotNull(_thisGame.ClosedDoor, "Remaining door not generated");
        }

        private void CountOccupantsAndAssert(ThreeDoors doors)
        {
            int goatCount = 0;
            int carCount = 0;
            if (doors.Door1.Occupant == OccupantType.Goat)
            {
                goatCount++;
            }
            else
            {
                carCount++;
            }

            if (doors.Door2.Occupant == OccupantType.Goat)
            {
                goatCount++;
            }
            else
            {
                carCount++;
            }

            if (doors.Door3.Occupant == OccupantType.Goat)
            {
                goatCount++;
            }
            else
            {
                carCount++;
            }

            Assert.AreEqual(2, goatCount, "Goats not right!");
            Assert.AreEqual(1, carCount, "Cars not right!");
        }
    }
}