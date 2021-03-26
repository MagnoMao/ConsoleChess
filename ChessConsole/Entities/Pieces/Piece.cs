using System;
using ChessConsole.Enums;

namespace ChessConsole.Entities.Pieces
{
    abstract class Piece
    {
        public int Collum { get; protected set; }
        public int Row { get; protected set; }
        public Color Color { get; private set; }
        public Board GameBoard { get; set; }        

        public Piece(int row, int collum, Color color, Board pieceBoard)
        {
            Collum = collum;
            Row = row;
            Color = color;
            GameBoard = pieceBoard;
        }
        public abstract void Move(char collumChar, int row);
        public abstract bool[,] PossibleMovements();
        public void DrawPossibleMovements()
        {
            bool[,] mat = PossibleMovements();
            Console.WriteLine("  A B C D E F G H");
            for (int i = GameBoard.Rows - 1; i >= 0; i--)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < GameBoard.Collums; j++)
                {
                    if (i == Row && j == Collum) Console.Write("K ");
                    else if (mat[i, j]) Console.Write("X ");
                    else Console.Write("- ");
                }
                Console.WriteLine((i + 1) + " ");
            }
            Console.WriteLine("  A B C D E F G H");
        }
    }
}
