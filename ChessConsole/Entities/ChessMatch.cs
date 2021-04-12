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
        public Piece PieceToMove { get; private set; } = null;
        private int[] Target;
        private bool[,] PossibleMovements;
        public ChessMatch()
        {
            InitBoard(GameBoard);
        }
        public void AddPiece(PieceType type, Color color, char collumChar, int row)
        {
            int[] res = GameBoard.PosConverter(collumChar, row);
            row = res[0];
            int collum = res[1];
            switch (type)
            {
                case PieceType.King:
                    Piece p = new King(row, collum, color, GameBoard);
                    GameBoard.AddPiece(p);
                    //PieceBoard[row, collum] = new King(row, collum, color, this);
                    break;
            }
        }
        public Piece getPieceToMove()
        {
            bool valid = false;
            Piece pieceToMove;
            ConsoleColor defaultColor = Console.ForegroundColor;
            do
            {
                try
                {
                    Console.Write("Turn: " );
                    if (PlayerTurn == Color.Black) Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(PlayerTurn); // PlayerTurn.ToString()
                    Console.Write("Origin: ");
                    string origin = Console.ReadLine();
                    Console.ForegroundColor = defaultColor;
                    char collumChar = origin[0];
                    int row = origin[1];
                    pieceToMove = GameBoard.GetPiece(collumChar, row);
                    if (pieceToMove == null) Console.WriteLine("There is no piece in this position.");
                    else if (pieceToMove.Color != PlayerTurn) Console.WriteLine("This piece isn't yours to move.");
                    else
                    {
                        PieceToMove = pieceToMove;
                        valid = true;
                        return pieceToMove;
                    }


                }
                catch (InvalidPositionException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!valid);
        }

        public void MovePiece()
        {

        }        
        public void Move(Piece p, char collumChar, int row)
        {

        }
        private void InitBoard(Board b)
        {
            AddPiece(PieceType.King, Color.White, 'A', 1);
        }
    }
}
