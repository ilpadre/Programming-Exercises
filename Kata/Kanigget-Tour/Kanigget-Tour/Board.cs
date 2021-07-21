using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace Kanigget_Tour
{
    public class Move
    {
        public int row;
        public int column;

        public Move(int theRow, int theColumn)
        {
            row = theRow;
            column = theColumn;
        }
    }

    public class Board
    {
        private bool[,] board;
        private int rows, columns;

        public Board(int numRows, int numColumns)
        {
            rows = numRows;
            columns = numColumns;
            initBoard(rows, columns);

        }

        private void initBoard(int numRows, int numColumns)
        {
            board = new bool[numRows, numColumns];
        }

        public bool AllSquaresVisited()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!board[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool NoSquaresVisited()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (board[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void VisitSquare(int row, int column)
        {
            board[row, column] = true;
        }

        public void ClearSquare(int row, int column)
        {
            board[row, column] = false;
        }

        public bool SquareVisited(int row, int column)
        {
            return board[row, column] == true;
        }

        public List<Move> GetLegalMoves(int row, int column)
        {
            var LegalMoves = new List<Move>();

            // row - 1 column - 2
            if (IsMoveOnBoard(row-1, column-2) && !SquareVisited(row - 1, column - 2))
            {
                LegalMoves.Add(new Move(row - 1, column - 2));
            }

            // row + 1 column - 2
            if (IsMoveOnBoard(row + 1, column - 2) && !SquareVisited(row + 1, column - 2))
            {
                LegalMoves.Add(new Move(row + 1, column - 2));
            }

            // row - 2, column - 1
            if (IsMoveOnBoard(row - 2, column - 1) && !SquareVisited(row - 2, column - 1))
            {
                LegalMoves.Add(new Move(row - 2, column - 1));
            }

            // row + 2, column - 1
            if (IsMoveOnBoard(row + 2, column - 1) && !SquareVisited(row + 1, column - 1))
            {
                LegalMoves.Add(new Move(row + 2, column - 1));
            }

            // row - 2, column + 1
            if (IsMoveOnBoard(row - 2, column + 1) && !SquareVisited(row - 2, column + 1))
            {
                LegalMoves.Add(new Move(row - 2, column + 1));
            }

            // row + 2, column + 1
            if (IsMoveOnBoard(row + 2, column + 1) && !SquareVisited(row + 2, column + 1))
            {
                LegalMoves.Add(new Move(row + 2, column + 1));
            }

            // row - 1, column + 2
            if (IsMoveOnBoard(row - 1, column + 2) && !SquareVisited(row - 1, column + 2))
            {
                LegalMoves.Add(new Move(row - 1, column + 2));
            }

            // row + 1, column + 2
            if (IsMoveOnBoard(row + 1, column + 2) && !SquareVisited(row + 1, column + 2))
            {
                LegalMoves.Add(new Move(row + 1, column + 2));
            }

            return LegalMoves;
        }

        public bool IsMoveOnBoard(int row, int column)
        {
            if ((row < rows && row >= 0) && (column < columns && column >= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
