using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Kanigget_Tour
{

    public static class Tour
    {

        public static void GenerateTour(int row, int column, Board thisBoard)
        {
            // Mark the square visited
            thisBoard.VisitSquare(row, column);

            // Is the tour done?
            if (!thisBoard.AllSquaresVisited())
            {

                // Get all legal moves
                var moves = thisBoard.GetLegalMoves(row, column);

                // if no legal moves, then return
                if (moves.Count > 0)
                {
                    // legal moves--keep going
                    foreach (var move in moves)
                    {
                        GenerateTour(move.row, move.column, thisBoard);
                    }

                    if (thisBoard.AllSquaresVisited())
                    {
                        Console.WriteLine($"{row} {column} After foreach");
                    }
                }




            }




        }


    }
}
