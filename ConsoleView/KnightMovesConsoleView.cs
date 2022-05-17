using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games;


namespace ConsoleView
{    
    internal class KnightMovesConsoleView
    {
        KnightMoves knightMoves = new KnightMoves();
        /// <summary>
        /// Runs MinKinghtMoves method 
        /// </summary>
        public void Run()
        {
            var game = new FromBaseToGame();
            var fView = new FigureOnBoard();
            var boardView = new BoardView();
            Console.WriteLine("insert figure's start position");
            string? position = Console.ReadLine();
            int stLetter = game.GetLetterCoordinate(position[0].ToString().ToLower());
            int.TryParse(position[1].ToString(), out int result);
            int stNumber = game.GetNumberCoordinate(result);
            game.ChessBoard[7 - stNumber, stLetter] = fView.ChooseFigure("knight", (stLetter, stNumber));
            Console.WriteLine("insert figure's target position");
            string? position1 = Console.ReadLine();
            int tgLetter = game.GetLetterCoordinate(position1[0].ToString().ToLower());
            int.TryParse(position1[1].ToString().ToLower(), out int result1);
            int tgNumber = game.GetNumberCoordinate(result1);
            game.ChessBoard[7 - tgNumber, tgLetter] = fView.ChooseFigure("knight", (tgLetter, tgNumber));
            Console.WriteLine($"min moves from start position to target position {knightMoves.MinKnightMoves((stLetter,stNumber), (tgLetter, tgNumber))}");
            boardView.PrintChessBoard(game);
        }
    }
}
