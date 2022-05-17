using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public class Bishop : Figure
    {
        Board board = new Board();
        /// <summary>
        /// can bishop go to target position
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true if can false if can't</returns>
        public override bool CanMove((int, int) stPos, (int, int) tgPos)
        {
            int lCoordinate = tgPos.Item1;
            int nCoordinate = tgPos.Item2;
            if (tgPos == stPos)
            {
                return false;
            }
            for (int i = 0; i < 7; i++)
            {
                lCoordinate++;
                nCoordinate++;
                if (lCoordinate == stPos.Item1 && nCoordinate == stPos.Item2)
                {
                    return true;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    lCoordinate = tgPos.Item1;
                    nCoordinate = tgPos.Item2;
                }
                lCoordinate++;
                nCoordinate--;
                if (lCoordinate == stPos.Item1 && nCoordinate == stPos.Item2)
                {
                    return true;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    lCoordinate = tgPos.Item1;
                    nCoordinate = tgPos.Item2;
                }
                nCoordinate++;
                lCoordinate--;
                if (lCoordinate == stPos.Item1 && nCoordinate == stPos.Item2)
                {
                    return true;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    lCoordinate = tgPos.Item1;
                    nCoordinate = tgPos.Item2;
                }
                nCoordinate--;
                lCoordinate--;
                if (lCoordinate == stPos.Item1 && nCoordinate == stPos.Item2)
                {
                    return true;
                }
            }
            return false;
        }
        public Bishop(ColorEnum color, (int, int) position) : base(color, position)
        {

        }
        public Bishop() : base()
        {

        }
        /// <summary>
        /// gets possible moves for bishop
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
                    if (CanMove(figure.position, (i, j)))
                        moveList.Add((i, j));
                }
            }
            for (int i = 0; i < figuresList.Count; i++)
            {
                if (figuresList[i]?.position == tgPos && figure.color == figuresList[i]?.color && i != 4 && i != 20 && figure.position != tgPos)
                    moveList.Remove(tgPos);
            }
            int lCoordinate = figure.position.Item1;
            int nCoordinate = figure.position.Item2;
            int k = 0;
            for (int i = 0; i < 7; i++)
            {
                lCoordinate++;
                nCoordinate++;
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if (lCoordinate == figuresList[j]?.position.Item1 && nCoordinate == figuresList[j]?.position.Item2)
                    {
                        figureOnRoad = true;
                        k++;
                    }
                }
                if (figureOnRoad && (figuresList[4]?.position != (lCoordinate, nCoordinate) &&
                              figuresList[20]?.position != (lCoordinate, nCoordinate)) && k>0)
                {
                    moveList.Remove((lCoordinate, nCoordinate));
                }
                else if (figuresList[20]?.position == (lCoordinate, nCoordinate) && figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                else if (figuresList[4]?.position == (lCoordinate, nCoordinate) && figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if ((lCoordinate,nCoordinate) == figuresList[j]?.position && figure.color != figuresList[j]?.color && k==1)
                        moveList.Add((lCoordinate, nCoordinate));
                }
            }
            lCoordinate = figure.position.Item1;
            nCoordinate = figure.position.Item2;
            figureOnRoad = false;
            k = 0;
            for (int i = 0; i < 7; i++)
            {
                lCoordinate--;
                nCoordinate++;
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if (lCoordinate == figuresList[j]?.position.Item1 && nCoordinate == figuresList[j]?.position.Item2)
                    {
                        figureOnRoad = true;
                        k++;
                    }
                }
                if (figureOnRoad && figuresList[4]?.position != (lCoordinate, nCoordinate) &&
                                     figuresList[20]?.position != (lCoordinate, nCoordinate) && k > 0)
                {
                    moveList.Remove((lCoordinate, nCoordinate));
                }
                else if (figuresList[20]?.position == (lCoordinate, nCoordinate) && figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                else if (figuresList[4]?.position == (lCoordinate, nCoordinate) && figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if ((lCoordinate, nCoordinate) == figuresList[j]?.position && figure.color != figuresList[j]?.color && k == 1)
                        moveList.Add((lCoordinate, nCoordinate));
                }

            }
            lCoordinate = figure.position.Item1;
            nCoordinate = figure.position.Item2;
            figureOnRoad = false;
            k = 0;
            for (int i = 0; i < 7; i++)
            {
                lCoordinate--;
                nCoordinate--;
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if (lCoordinate == figuresList[j]?.position.Item1 && nCoordinate == figuresList[j]?.position.Item2)
                    {
                        figureOnRoad = true;
                        k++;
                    }
                }
                if (figureOnRoad && (figuresList[4]?.position != (lCoordinate, nCoordinate) &&
                                     figuresList[20]?.position != (lCoordinate, nCoordinate)) && k > 0)
                {
                    moveList.Remove((lCoordinate, nCoordinate));
                }
                else if (figuresList[20]?.position == (lCoordinate, nCoordinate) && figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                else if (figuresList[4]?.position == (lCoordinate, nCoordinate) && figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if ((lCoordinate, nCoordinate) == figuresList[j]?.position && figure.color != figuresList[j]?.color && k == 1)
                        moveList.Add((lCoordinate, nCoordinate));
                }
            }
            lCoordinate = figure.position.Item1;
            nCoordinate = figure.position.Item2;
            figureOnRoad = false;
            k = 0;
            for (int i = 0; i < 7; i++)
            {
                lCoordinate++;
                nCoordinate--;
                for (int j = 0; j < figuresList.Count; j++)
                {
                    if (lCoordinate == figuresList[j]?.position.Item1 && nCoordinate == figuresList[j]?.position.Item2)
                    {
                        figureOnRoad = true;
                        k++;
                    }
                }
                if (figureOnRoad && (figuresList[4]?.position != (lCoordinate, nCoordinate) &&
                                  figuresList[20]?.position != (lCoordinate, nCoordinate)) && k > 0)
                {
                    moveList.Remove((lCoordinate, nCoordinate));
                }
                else if (figuresList[20]?.position == (lCoordinate, nCoordinate) && figureOnRoad && k > 0)
                    moveList.Remove((lCoordinate, nCoordinate));
                else if (figuresList[4]?.position == (lCoordinate, nCoordinate) && figureOnRoad && k > 0)
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
        /// gets letter for bishop
        /// </summary>
        /// <returns>letter</returns>
        public override char GetLetter()
        {
            if (color == ColorEnum.white)
            {
                return 'B';
            }
            else
            {
                return 'b';
            }
        }
    }
}

