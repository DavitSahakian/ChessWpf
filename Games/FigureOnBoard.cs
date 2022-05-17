using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBase;

namespace Games
{
    public class FigureOnBoard
    {
        /// <summary>
        /// gives coordinates to figure on board array
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="letter"></param>
        /// <param name="number"></param>
        /// <returns>chosed figures letter</returns>
        public string ChooseFigure(string figure, (int,int)position)
        {
            Board board = new Board();
            switch (figure.ToLower())
            {
                case "king":
                    return "K";
                case "queen":
                    return "Q";
                case "rook":
                    return "R";
                case "bishop":
                    return "B";
                case "knight":
                    return "N";
                case "pawn":
                    return "p";
            }
            return board.ConsoleBoard[position.Item2, position.Item1];
        }
    }
}
