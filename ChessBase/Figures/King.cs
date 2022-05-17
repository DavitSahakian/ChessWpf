using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public class King:Figure
    {
        /// <summary>
        /// where can go king in x direction
        /// </summary>
        public int[] dx = { -1, -1, -1, 0, 1, 1, 1, 0 };
        /// <summary>
        /// where can go king in y direction
        /// </summary>
        public int[] dy = { -1, 0, 1, 1, 1, 0, -1, -1 };
        /// <summary>
        /// can king go to given position
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true if can false if can't</returns>
        public override bool CanMove((int, int) stPos, (int, int) tgPos)
        {
            int stLetter;
            int stNumber;
            for (int i = 0; i < 8; i++)
            {
                stLetter = stPos.Item1 + dx[i];
                stNumber = stPos.Item2 + dy[i];
                if (stNumber == tgPos.Item2 && stLetter == tgPos.Item1)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// gets possible moves
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="tgPos"></param>
        /// <param name="figuresList"></param>
        /// <returns>list of possible moves for king</returns>
        public override List<(int, int)> GetAllMoves(Figure figure, (int, int) tgPos, List<Figure> figuresList)
        {
            List<(int, int)> moveList = new List<(int, int)>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (CanMove(figure.position, tgPos))
                        moveList.Add((i, j));
                }
            }
            for (int i = 0; i < figuresList.Count; i++)
            {
                if (figuresList[i]?.position == tgPos && figure.color == figuresList[i]?.color)
                    moveList.Remove(tgPos);
            }
            return moveList;
        }
        public King(ColorEnum color,(int,int)position) : base(color,position)
        {

        }
        public King() : base()
        {

        }
        /// <summary>
        /// gets kings letter
        /// </summary>
        /// <returns>letter</returns>
        public override char GetLetter()
        {
            if (color == ColorEnum.white)
            {
                return 'K';
            }
            else
            {
                return 'k';
            }
        }
    }
}
