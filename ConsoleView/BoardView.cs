using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games;

namespace ConsoleView
{
    public class BoardView
    {  
        /// <summary>
        /// method is printing chessboard empty or with figure
        /// </summary>
        public void PrintChessBoard(FromBaseToGame game)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(8 - i);
                for (int j = 0; j < 8; j++)
                {
                    if (game.ChessBoard[i, j] == null)
                    {

                        if (((j % 2 == 0) && (i % 2 != 0)) || ((i % 2 == 0) && (j % 2 != 0)))
                            game.ChessBoard[i, j] = "+";
                        else
                            game.ChessBoard[i, j] = "-";
                    }
                        Console.Write($" {game.ChessBoard[i, j]}");
                }                
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");

        }      
    }
}
