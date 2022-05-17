using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBase;

namespace Games
{
    public class KnightMoves
    {
        CoordinateData data = new CoordinateData();
        Knight knight = new Knight();
        /// <summary>
        /// checks is coordinate belong to chessboard
        /// </summary>
        /// <param letterCoord="x"></param>
        /// <param numberCoord="y"></param>
        /// <returns>true if belong's</returns>
        bool IsInside(int x, int y)
        {
            if (x >=0 && x < 8 && y >=0 && y < 8)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// findes minimum knight moves to position`
        /// </summary>
        /// <param name="stNum"></param>
        /// <param name="stLet"></param>
        /// <param name="tNum"></param>
        /// <param name="tLet"></param>
        /// <returns>count of moves</returns>
        public int MinKnightMoves((int,int)startPos,(int,int)targetPos)
        {
            data.tempNumber=startPos.Item2;
            data.tempLetter=startPos.Item1;
            data.number=targetPos.Item2;
            data.letter=targetPos.Item1;
            int m = 1;
            int k = 0;
            CoordinateData[] cells = new CoordinateData[64];
            cells[0] = new CoordinateData(data.tempLetter, data.tempNumber);
            bool[,] visit = new bool[9, 9];
            visit[data.tempLetter, data.tempNumber] = true;
            while (cells[0].dis < 7)
            {
                if (data.tempLetter == data.letter && data.tempNumber == data.number)
                {
                    return cells[0].dis;
                }
                for (int i = 0; i < 8; i++)
                {
                    data.tempLetter = cells[0].letter + knight.moveLetter[i];
                    data.tempNumber = cells[0].number + knight.moveNumber[i];
                    if (IsInside(data.tempLetter, data.tempNumber) && !visit[data.tempLetter, data.tempNumber])
                    {
                        visit[data.tempLetter, data.tempNumber] = true;
                        cells[m] = new CoordinateData(data.tempLetter, data.tempNumber, cells[0].dis + 1);
                        m++;
                    }
                }
                k++;
                data.tempLetter = cells[k].letter;
                data.tempNumber = cells[k].number;
                cells[0].letter = cells[k].letter;
                cells[0].number = cells[k].number;
                cells[0].dis = cells[k].dis;
            }
            return 404;
        }

    }
}
