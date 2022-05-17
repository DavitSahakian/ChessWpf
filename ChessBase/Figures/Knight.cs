using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public class Knight:Figure 
    {
        /// <summary>
        /// where can go knight in x direction
        /// </summary>
        public int[] moveLetter = { -2, -1, 1, 2, -2, -1, 1, 2 };
        /// <summary>
        /// where can go king in y direction
        /// </summary>
        public int[] moveNumber = { -1, -2, -2, -1, 1, 2, 2, 1 };
        /// <summary>
        /// can knight go to given position
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true if can false if can't</returns>
        public override bool CanMove((int, int) stPos, (int, int) tgPos)
        {
            int stLetter = stPos.Item1;
            int stNumber = stPos.Item2;
            for (int i = 0; i < 8; i++)
            {
                stPos.Item1 = stLetter + moveLetter[i];
                stPos.Item2 = stNumber + moveNumber[i];
                if (stPos.Item1 == tgPos.Item1 && stPos.Item2 == tgPos.Item2)
                {
                    return true;
                }
            }
            return false;
        }
        public Knight(ColorEnum color, (int, int) position) : base(color, position)
        {

        }
        public Knight() : base()
        {

        }
        /// <summary>
        /// gets possible moves for knight
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="tgPos"></param>
        /// <param name="figuresList"></param>
        /// <returns>knights possible move list</returns>
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
            for (int i = 0; i < figuresList.Count; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (figuresList[i]?.position == figuresList[j]?.position && figuresList[i]?.color != figuresList[j]?.color)
                        moveList.Add(figuresList[i].position);
                }
            }
            return moveList;
        }
        public override char GetLetter()
        {
            if (color == ColorEnum.white)
            {
                return 'N';
            }
            else
            {
                return 'n';
            }
        }
    }
}
