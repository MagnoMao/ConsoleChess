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
            chessMatch.GameBoard.AddPiece(PieceType.King, Color.White, 'A', 2);

            while (chessMatch.Match)
            {
                chessMatch.GameBoard.Draw();
                Console.WriteLine("Origin: ");
                string origin = Console.ReadLine();
                Piece p = chessMatch.GameBoard.GetPiece(origin[0], origin[1]);

                Console.WriteLine("Target: ");
                string target = Console.ReadLine();
                chessMatch.Move(p,target[0], target[1]);

                chessMatch.GameBoard.GetPiece('A', 2).DrawPossibleMovements();
            }
        }
    }
}