using System;
using ChessConsole.Enums;
using ChessConsole.Exceptions;
using ChessConsole.Entities.Pieces;

namespace ChessConsole.Entities
{
    class Board
    {
        public int Rows { get; private set; }
        public int Collums { get; private set; }
        public Piece[,] PieceBoard { get; private set; }

        public Board(int rows, int collums)
        {
            Rows = rows;
            Collums = collums;
            PieceBoard = new Piece[Rows, Collums];
        }

        public void Draw()
        {
            //Console.WriteLine("  A B C D E F G H");
            Console.Write("  ");
            for (int j = 0; j < Collums; j++) Console.Write((char)('A' + 1) + " ");
            for (int i = Rows - 1; i >= 0; i--)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < Collums; j++)
                {
                    if (PieceBoard[i, j] == null) Console.Write("- ");
                    else
                    {
                        if(PieceBoard[i, j].Color == Color.White) Console.Write(PieceBoard[i, j] + " ");
                        else
                        {
                            ConsoleColor aux = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(PieceBoard[i, j] + " ");
                            Console.ForegroundColor = aux;
                        }
                    }
                }
                Console.WriteLine(i + 1);
            }
            //Console.WriteLine("  A B C D E F G H");
            Console.Write("  ");
            for (int j = 0; j < Collums; j++) Console.Write((char)('A' + 1) + " ");
        }

        public void DrawPossibleMovements(Piece p)
        {
            //Draw the possible move locations with another color
            bool[,] mat = p.PossibleMovements();
            ConsoleColor defColor = Console.ForegroundColor;
            Console.WriteLine("  A B C D E F G H");
            for (int i = Rows - 1; i >= 0; i--)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < Collums; j++)
                {
                    if (i == p.Row && j == p.Collum)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(p);
                        Console.ForegroundColor = defColor;
                        continue;
                    }
                    if (mat[i, j]) Console.ForegroundColor = ConsoleColor.Red;

                    if (PieceBoard[i, j] != null) Console.Write(PieceBoard[i, j] + " ");
                    else Console.Write("- ");
                    Console.ForegroundColor = defColor;
                }
                Console.WriteLine((i + 1) + " ");
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public bool ValidPos(int collum, int row)
        {
            if (collum < 0 || collum >= Collums || row < 0 || row >= Rows) return false;
            else return true;
        }
        ///<sumary>Return position in int[row, collum]</sumary>
        public int[] PosConverter(char collumChar, int row)
        {
            // Takes a position in Board coordinates and return in matrix coordinates
            int collum = char.ToUpper(collumChar) - 'A';
            row -= 1;
            if (!ValidPos(collum, row))
                throw new InvalidPositionException("Position out of bounds");
            int[] res = { row, collum };
            return res;
        }
        public bool AddPiece(Piece p)
        {
            if (PieceBoard[p.Row, p.Collum] == null)
            {
                PieceBoard[p.Row, p.Collum] = p;
                return true;
            }
            else return false;
        }
        
        public Piece GetPiece(char collumChar, int row)
        {
            int[] res = PosConverter(collumChar, row);
            row = res[0];
            int collum = res[1];
            return PieceBoard[row, collum];
        }

    }
}
