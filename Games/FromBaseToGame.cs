using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBase;

namespace Games
{
    public class FromBaseToGame
    {
        FindCoordinates find = new FindCoordinates();
        Board board = new Board();
        /// <summary>
        /// field shows which color has moving figure
        /// </summary>
        public ColorEnum turn = ColorEnum.white;
        /// <summary>
        /// gets chess board
        /// </summary>
        public string[,] ChessBoard
        {
            get
            {
                return board.ConsoleBoard;
            }
            set
            {
                board.ConsoleBoard = value;
            }
        }
        /// <summary>
        /// gets number coordinate from chessbase
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int GetNumberCoordinate(int number)
        {
            return find.FindNumberCoordinate(number);
        }
        /// <summary>
        /// gets letter coordinate from chessbase
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public int GetLetterCoordinate(string letter)
        {
            return find.FindLetterCoordinate(letter);
        }
        /// <summary>
        /// gets chess coordinate from chessbase
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>chess coordinate</returns>
        public (int, int) GetChessCoordinate(string coordinate)
        {
            return find.ChessCoordinate(coordinate);
        }
        /// <summary>
        /// finds which figure want to move and checks can move or not
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="data"></param>
        /// <returns>true if figure can move else false</returns>
        public bool Move((int, int) stPos, (int, int) tgPos)
        {
            Figure figure = board.GetFigure(stPos);
            if (figure != null)
            {
                if (figure.color == turn)
                {
                        if (figure.GetAllMoves(figure, tgPos, board.allFigures).Contains(tgPos))
                        {
                            return true;
                        }
                }
            }
            return false;
        }
        public bool GetIsCheck()
        {
            return board.IsCheck(turn);
        }
        public bool GetIsMate()
        {
            return board.IsMate(turn);
        }
        public bool GetIsStaleMate()
        {
            return board.IsStaleMate(turn);
        }
        public List<Figure> GetALLFigure()
        {
            return board.GetAllFigures();
        }
        public Board GetBoard()
        {
            return board;
        }
        public ColorEnum GetBlackColor()
        {
            return ColorEnum.black;
        }
        public ColorEnum GetWhiteColor()
        {
            return ColorEnum.white;
        }

        public bool GetCanRock((int,int) stPos, (int,int) tgPos)
        {
            return board.CanRock(turn, stPos, tgPos);
        }
        public (int,int,int,int) GetLastMove
        {
            get
            {
                return board.lastMove;
            }
            set
            {
                board.lastMove = value;
            }
        }
        public bool GetEnPassant((int,int) stPos, (int,int) tgPos)
        {
            return board.EnPassant(stPos, tgPos, turn);
        }
    }
}
