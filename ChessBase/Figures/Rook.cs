using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public class  Rook : Figure
    {
        /// <summary>
        /// can rook go to given position 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true if can false if can't</returns>
        public override bool CanMove((int, int) stPos, (int, int) tgPos)
        {
            if (tgPos.Item1 ==stPos.Item1 || tgPos.Item2 == stPos.Item2)
            {
                return true;
            }
            return false;
        }
         public Rook()
         {

         }
        public Rook(ColorEnum color, (int, int) position) : base(color, position)
        {

        }
        /// <summary>
        /// gets possible moves for rook
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="tgPos"></param>
        /// <param name="figuresList"></param>
        /// <returns>list of possible moves</returns>
        public override List<(int, int)> GetAllMoves(Figure figure, (int, int) tgPos, List<Figure> figuresList)
        {
            List<(int, int)> moveList = new List<(int, int)>();
            bool figureOnRoad = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (CanMove(figure.position, (i,j)))
                        moveList.Add((i, j));
                }
            }
            for (int i = 0; i < figuresList.Count; i++)
            {
                if (figuresList[i]?.position == tgPos && figure.color == figuresList[i]?.color)
                    moveList.Remove(tgPos);;
            }
            int lCoordinate = figure.position.Item1;
            int nCoordinate = figure.position.Item2;
            int k = 0;
            for (int i = 0; i < 7; i++)
            {
                lCoordinate++;
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if (lCoordinate == figuresList[j]?.position.Item1 && nCoordinate == figuresList[j]?.position.Item2)
                    {
                        figureOnRoad = true;
                        k++;
                    }
                }
                if (figureOnRoad && k>0)
                    moveList.Remove((lCoordinate, nCoordinate));
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if ((lCoordinate, nCoordinate) == figuresList[j]?.position && figure.color != figuresList[j]?.color && k == 1)
                        moveList.Add((lCoordinate, nCoordinate));
                }
            }
            lCoordinate = figure.position.Item1;
            figureOnRoad = false;
            k = 0;
            for (int i = 0; i < 7; i++)
            {
                lCoordinate--;
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if (lCoordinate == figuresList[j]?.position.Item1 && nCoordinate == figuresList[j]?.position.Item2)
                    {
                        figureOnRoad = true;
                        k++;
                    }
                }
                if (figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if ((lCoordinate, nCoordinate) == figuresList[j]?.position && figure.color != figuresList[j]?.color && k == 1)
                        moveList.Add((lCoordinate, nCoordinate));
                }
            }
            lCoordinate = figure.position.Item1;
            figureOnRoad = false;
            k = 0;
            for (int i = 0; i < 7; i++)
            {
                nCoordinate--;
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if (lCoordinate == figuresList[j]?.position.Item1 && nCoordinate == figuresList[j]?.position.Item2)
                    {
                        figureOnRoad = true;
                        k++;
                    }
                }
                if (figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if ((lCoordinate, nCoordinate) == figuresList[j]?.position && figure.color != figuresList[j]?.color && k == 1)
                        moveList.Add((lCoordinate, nCoordinate));
                }
            }
            nCoordinate = figure.position.Item2;
            figureOnRoad = false;
            k = 0;
            for (int i = 0; i < 7; i++)
            {
                nCoordinate++;
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if (lCoordinate == figuresList[j]?.position.Item1 && nCoordinate == figuresList[j]?.position.Item2)
                    {
                        figureOnRoad = true;
                        k++;
                    }
                }
                if (figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if ((lCoordinate, nCoordinate) == figuresList[j]?.position && figure.color != figuresList[j]?.color && k == 1)
                        moveList.Add((lCoordinate, nCoordinate));
                }
            }
            return moveList;
        }
        /// <summary>
        /// gets letter for rook
        /// </summary>
        /// <returns>letter</returns>
        public override char GetLetter()
        {
            if (color == ColorEnum.white)
            {
                return 'R';
            }
            else
            {
                return 'r';
            }
        }
    }
}
 