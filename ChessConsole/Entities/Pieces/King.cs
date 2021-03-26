using System;
using ChessConsole.Enums;

namespace ChessConsole.Entities.Pieces
{
    class King : Piece
    {
        public King(int collum, int row, Color color, Board gameBoard) : base(collum, row, color, gameBoard)
        {
        }
        public override string ToString()
        {
            return "K";
        }

        public override void Move(char collumChar, int row)
        {
            int[] origin = GameBoard.PosConverter(collumChar, row);
            row = origin[0];
            int collum = origin[1];            

            bool[,] moveMat = PossibleMovements();
            if(moveMat[row, collum] == true)
            {
                GameBoard.PieceBoard[row, collum] = this;
                Collum = collum;
                Row = row;
            }

        }
        private bool CanMove(int row, int collum)
        {
            return GameBoard.PieceBoard[row, collum] == null || GameBoard.PieceBoard[row, collum].Color != Color;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[GameBoard.Rows, GameBoard.Collums];
            int xx, yy;

            //for(int ang = 0; ang < 360; ang += 45)
            //{
            //    //Check the positions counter clockwise: East -> NE -> North -> NW -> ... -> SE
            //    //xx = Row + (int)(Math.Ceiling(Math.Sin(ang)));
            //    //yy = Collum + (int)(Math.Ceiling(Math.Cos(ang)));                
            //    //if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;
            //}

            //East
            xx = Row;
            yy = Collum + 1;
            if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;

            //NE
            xx = Row + 1;
            yy = Collum + 1;
            if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;

            //North
            xx = Row + 1;
            yy = Collum;
            if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;

            //NW
            xx = Row + 1;
            yy = Collum - 1;
            if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;

            //West
            xx = Row;
            yy = Collum - 1;
            if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;

            //SW
            xx = Row - 1;
            yy = Collum - 1;
            if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;

            //South
            xx = Row - 1;
            yy = Collum;
            if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;

            //SE
            xx = Row - 1;
            yy = Collum + 1;
            if (GameBoard.ValidPos(xx, yy) && CanMove(xx, yy)) mat[xx, yy] = true;

            return mat;
        }

        //public void DrawPossibleMovements()
        //{
        //    bool[,] mat = PossibleMovements();
        //    Console.WriteLine("   A B C D E F G H");
        //    for (int i = GameBoard.Rows - 1; i >= 0; i--)
        //    {

        //        Console.Write((i + 1) + " ");
        //        for (int j = 0; j < GameBoard.Collums; j++)
        //        {
        //            if (i == Row && j == Collum)    Console.Write("K ");
        //            else if (mat[i, j])             Console.Write("X ");
        //            else                            Console.Write("- ");
        //        }
        //        Console.WriteLine((i + 1) + " ");
        //    }
        //    Console.WriteLine("   A B C D E F G H");
        //}
    }
}
