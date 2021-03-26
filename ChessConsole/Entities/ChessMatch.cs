using System;
using ChessConsole.Exceptions;
using ChessConsole.Entities.Pieces;
using ChessConsole.Enums;

namespace ChessConsole.Entities
{
    class ChessMatch
    {
        public Board GameBoard { get; private set; } = new Board(8, 8);
        public Color PlayerTurn { get; private set; } = Color.White;
        public int Turn { get; private set; } = 1;
        public bool Match { get; private set; } = true;
        public ChessMatch()
        {
            GameBoard.InitBoard();
        }

        public Piece GetPiece()
        {
            bool valid = false;
            Piece p;
            do
            {
                try
                {

                    Console.Write("Turn: " + PlayerTurn);// PlayerTurn.ToString()
                    Console.WriteLine("Origin: ");
                    string origin = Console.ReadLine();
                    char collumChar = origin[0];
                    int row = origin[1];
                    int[] res = GameBoard.PosConverter(collumChar, row);
                    row = res[0];
                    int collum = res[1];
                    p = GameBoard.PieceBoard[row, collum];
                    if (p == null) Console.WriteLine("There is no piece in this position.");
                    else if (p.Color != PlayerTurn) Console.WriteLine("This piece isn't yours to move.");
                    else valid = true;

                }
                catch (InvalidPositionException e)
                {
                    throw new InvalidPositionException(e.Message);
                }

            } while (!valid);
            return p;
        }
        public void Move(Piece p, char collumChar, int row)
        {

        }
    }
}
