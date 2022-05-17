using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public abstract class Figure
    {
        public abstract bool CanMove((int, int) stPos, (int, int) tgPos);
        public ColorEnum color;
        /// <summary>
        /// gets possible moves
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="tgPos"></param>
        /// <param name="figuresList"></param>
        /// <returns>list of possible moves</returns>
        public abstract List<(int, int)> GetAllMoves(Figure figure, (int, int) tgPos, List<Figure> figuresList);
        public (int, int) position;
        public Figure(ColorEnum color,(int,int)position)
        {
            this.color = color;
            this.position = position;
        }
        public Figure()
        {

        }
        /// <summary>
        /// gets letter for each figure
        /// </summary>
        /// <returns>letter</returns>
        public abstract char GetLetter();
    }
}
