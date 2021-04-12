using System;
using ChessConsole.Entities;
using ChessConsole.Enums;
using ChessConsole.Entities.Pieces;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch chessMatch = new ChessMatch();
            chessMatch.AddPiece(PieceType.King, Color.White, 'A', 2);

            while (chessMatch.Match)
            {
                chessMatch.GameBoard.Draw();
                Piece piece = chessMatch.getPieceToMove();
                chessMatch.GameBoard.DrawPossibleMovements(piece);
                //possible ways to do it:

                //1- have the main program taking and passing the positions and pieces from the chess methods.
                int[] targetLocation = chessMatch.GetTargetlocation();
                chessMatch.MovePiece(piece, targetLocation[0], targetLocation[1]);
                
                //2- chessMatch have all the variables internally, the main program purpose is just to call
                //  the correct functions in the correct order.
            }
        }
    }
}