using NUnit.Framework;

namespace Kanigget_Tour.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoSquaresVisited_InitializedArray_ShouldReturnTrue()
        {
            Board myBoard = new Board(8, 8);
            Assert.AreEqual(true, myBoard.NoSquaresVisited());
        }

        [Test]
        public void AllSquaresVisited_InitializedArray_ShouldReturnFalse()
        {
            Board myBoard = new Board(8, 8);
            Assert.AreEqual(false, myBoard.AllSquaresVisited());
        }

        [Test]
        public void VisitSquareUnvisitSquare_InitializedArray()
        {
            Board myBoard = new Board(8, 8);
            Assert.AreEqual(true, myBoard.NoSquaresVisited());
            Assert.AreEqual(false, myBoard.SquareVisited(2, 2));
            myBoard.VisitSquare(2, 2);
            Assert.AreEqual(true, myBoard.SquareVisited(2, 2));
            Assert.AreEqual(false, myBoard.NoSquaresVisited());
            Assert.AreEqual(false, myBoard.AllSquaresVisited());
        }

        [Test]
        public void Square00_IsMoveOnBoardReturnsTrue()
        {
            Board myBoard = new Board(8, 8);
            Assert.AreEqual(true, myBoard.IsMoveOnBoard(0, 0));
        }

        [Test]
        public void Square70_IsMoveOnBoardReturnsTrue()
        {
            Board myBoard = new Board(8, 8);
            Assert.AreEqual(true, myBoard.IsMoveOnBoard(7, 0));
        }

        [Test]
        public void Square07_IsMoveOnBoardReturnsTrue()
        {
            Board myBoard = new Board(8, 8);
            Assert.AreEqual(true, myBoard.IsMoveOnBoard(0, 7));
        }

        [Test]
        public void Square77_IsMoveOnBoardReturnsTrue()
        {
            Board myBoard = new Board(8, 8);
            Assert.AreEqual(true, myBoard.IsMoveOnBoard(7, 7));
        }

    }
}