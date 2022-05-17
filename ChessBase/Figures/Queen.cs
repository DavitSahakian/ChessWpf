using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public class Queen : Figure
    {
        Rook rook = new Rook();
        Bishop bishop = new Bishop();
        /// <summary>
        /// can queen go to given position
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true if can false if can't</returns>
        public override bool CanMove((int, int) stPos, (int, int) tgPos)
        {
            if (rook.CanMove(stPos,tgPos) ||bishop.CanMove(stPos,tgPos))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// gets possible moves for queen
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="tgPos"></param>
        /// <param name="figuresList"></param>
        /// <returns>list of possible moves</returns>
        public override List<(int, int)> GetAllMoves(Figure figure, (int, int) tgPos, List<Figure> figuresList)
        {
            
            List<(int, int)> moveList = new List<(int, int)>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (rook.GetAllMoves(figure, tgPos, figuresList).Contains((i,j)) || bishop.GetAllMoves(figure, tgPos, figuresList).Contains((i,j)))
                    {
                        moveList.Add((i,j));
                    }
                }
            }
            return moveList;
        }
        public Queen(ColorEnum color, (int, int) position) : base(color, position)
        {

        }
        /// <summary>
        /// gets letter for queen
        /// </summary>
        /// <returns>letter</returns>
        public override char GetLetter()
        {
            if (color == ColorEnum.white)
            {
                return 'Q';
            }
            else
            {
                return 'q';
            }
        }
    }
}
