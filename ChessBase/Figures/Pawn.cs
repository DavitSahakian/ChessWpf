using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public class Pawn : Figure
    {
        /// <summary>
        /// can pawn go to given position
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true if can false if can't</returns>
        public override bool CanMove((int, int) stPos, (int, int) tgPos)
        {
            if (color == ColorEnum.white && tgPos.Item2 != 7)
            {
                if (stPos.Item1 == tgPos.Item1 && stPos.Item2 == tgPos.Item2 - 1)
                {
                    return true;
                }
            }
            if (color == ColorEnum.black && tgPos.Item2 != 0)
            {
                if (stPos.Item1 == tgPos.Item1 && tgPos.Item2 == stPos.Item2 - 1)
                {
                    return true;
                }
            }         
            return false;
        }
        /// <summary>
        /// checks can pawn move 2 squares
        /// </summary>
        /// <param name="stPos"></param>
        /// <param name="tgPos"></param>
        /// <param name="figuresList"></param>
        /// <returns>true if can move 2 squares false if can't</returns>
        public bool CanMoveTwoSquares((int, int) stPos, (int, int) tgPos, List<Figure> figuresList)
        {
            if (color == ColorEnum.black)
            {
                if (stPos.Item2 == 6 && tgPos.Item2 == 4 && tgPos.Item1 == stPos.Item1)
                {
                    for (int i = 0; i < figuresList.Count; i++)
                    {
                        if ((stPos.Item1, 5) == figuresList[i]?.position)
                            return false;
                    }
                    return true;
                }
            }
            if (color == ColorEnum.white)
            {
                if (stPos.Item2 == 1 && tgPos.Item2 == 3 && tgPos.Item1 == stPos.Item1)
                {
                    for (int i = 0; i < figuresList.Count; i++)
                    {
                        if ((stPos.Item1, 2) == figuresList[i]?.position)
                            return false;
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
      /// checks can pawn eat enemy piece or not
      /// </summary>
      /// <param name="stPos"></param>
      /// <param name="tgPos"></param>
      /// <returns>true if can otherwise no</returns>
        public bool CanEat((int, int) stPos, (int, int) tgPos)
        {

            if (color == ColorEnum.white)
            {
                if (stPos.Item2 + 1 == tgPos.Item2 && (stPos.Item1 == tgPos.Item1 + 1 || stPos.Item1 == tgPos.Item1 - 1))
                {
                    return true;
                }
            }
            if (color == ColorEnum.black)
            {
                if (stPos.Item2 - 1 == tgPos.Item2 && (stPos.Item1 == tgPos.Item1 + 1 || stPos.Item1 == tgPos.Item1 - 1))
                {
                    return true;
                }
            }
            return false;
        }
        public Pawn(ColorEnum color, (int, int) position) : base(color, position)
        {

        }
        public Pawn() : base()
        {

        }
        public override List<(int, int)> GetAllMoves(Figure figure, (int, int) tgPos, List<Figure> figuresList)
        {
            List<(int, int)> moveList = new List<(int, int)>();
            if (CanMove(figure.position, tgPos) || CanMoveTwoSquares(figure.position, tgPos, figuresList))
                moveList.Add(tgPos);            
            for (int i = 0; i < figuresList.Count; i++)
            {
                if ((CanMove(figure.position, tgPos) || CanMoveTwoSquares(figure.position, tgPos, figuresList)) && figuresList[i]?.position == tgPos)
                    moveList.Remove(tgPos);
                if (figuresList[i]?.position == tgPos && figure.color != figuresList[i]?.color && CanEat(figure.position, tgPos) && ((tgPos.Item2>0 && tgPos.Item2<7)||i==4||i==20))
                    moveList.Add(tgPos);
            }
            return moveList;
        }
        public override char GetLetter()
        {
            if (color == ColorEnum.white)
            {
                return 'P';
            }
            else
            {
                return 'p';
            }
        }
    }
}
