using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public class Board
    {
        /// <summary>
        /// is enable yet to do black long rock
        /// </summary>
        public bool BlackLongRock { get; set; } = true;
        /// <summary>
        /// is enable yet to do black short rock
        /// </summary>
        public bool BlackShortRock { get; set; } = true;
        /// <summary>
        /// is enable yet to do white short rock
        /// </summary>
        public bool WhiteShortRock { get; set; } = true;
        /// <summary>
        /// is enable yet to do white long rock
        /// </summary>
        public bool WhiteLongRock { get; set; } = true;
        /// <summary>
        /// here is located last move in game
        /// </summary>
        public (int, int,int,int) lastMove;
        /// <summary>
        /// board array for console
        /// </summary>
        public string[,] ConsoleBoard = new string[8, 8];
        public List<Figure> allFigures = new List<Figure>();
        public bool IsPositionAttacked(Figure figure)
        {
            List<Figure> enemyFigures = new List<Figure>();
            for (int i = 0; i < allFigures.Count; i++)
            {
                if (allFigures[i] != null && figure.color != allFigures[i]?.color)
                {
                    enemyFigures.Add(allFigures[i]);
                }
            }
            for (int i = 0; i < enemyFigures.Count; i++)
            {
                if (enemyFigures[i].GetAllMoves(enemyFigures[i], figure.position, allFigures)
                                   .Contains(figure.position))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// checks is check)
        /// </summary>
        /// <param name="color"></param>
        /// <returns>true if check otherwise false</returns>
        public bool IsCheck(ColorEnum color)
        {
            for (int i = 0; i < allFigures?.Count; i++)
            {
                for (int j = 0; j < allFigures.Count; j++)
                {
                    if (allFigures[j]?.position == allFigures[i]?.position && allFigures[j]?.color != allFigures[i]?.color)
                    {
                        if (allFigures[j]?.color == color)
                        {
                            Figure temp = allFigures[i];
                            if (color == ColorEnum.white && IsPositionAttacked(allFigures[4]))
                            {
                                if (allFigures[i].color != color)
                                    allFigures[i] = null;
                                if (IsPositionAttacked(allFigures[4]))
                                {
                                    allFigures[i] = temp;
                                    return true;
                                }
                                else
                                {
                                    allFigures[i] = temp;
                                    return false;
                                }
                            }
                            else if (color == ColorEnum.black && IsPositionAttacked(allFigures[20]))
                            {
                                if (allFigures[i].color != color)
                                {
                                    allFigures[i] = null;
                                }
                                if (IsPositionAttacked(allFigures[20]))
                                { 
                                    allFigures[i] = temp;
                                    return true;
                                }
                                else
                                {
                                    allFigures[i] = temp;
                                    return false;
                                }
                            }
                            else
                            {
                                allFigures[i] = temp;
                            }
                        }
                        else
                        {
                            Figure temp = allFigures[j];
                            if (color == ColorEnum.white && IsPositionAttacked(allFigures[4]))
                            {
                                if (allFigures[j].color != color)
                                    allFigures[j] = null;
                                if (IsPositionAttacked(allFigures[4]))
                                {
                                    allFigures[j] = temp;
                                    return true;
                                }
                                else
                                {
                                    allFigures[j] = temp;
                                    return false;
                                }
                            }
                            else if (color == ColorEnum.black && IsPositionAttacked(allFigures[20]))
                            {
                                if (allFigures[j].color != color)
                                    allFigures[j] = null;
                                if (IsPositionAttacked(allFigures[20]))
                                {
                                    allFigures[j] = temp;
                                    return true;
                                }
                                else
                                {
                                    allFigures[j] = temp;
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            if (color == ColorEnum.white && IsPositionAttacked(allFigures[4]))
                return true;
            else if (color == ColorEnum.black && IsPositionAttacked(allFigures[20]))
                return true;
            return false;
        }
        /// <summary>
        /// checks is mate on board
        /// </summary>
        /// <param name="color"></param>
        /// <returns>true if mate otherwise false</returns>
        public bool IsMate(ColorEnum color)
        {
            bool isMate = false;
            if (IsCheck(color))
            {
                isMate = true;
                for (int k = 0; k < allFigures.Count; k++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (allFigures[k] != null)
                            {
                                if (allFigures[k]?.color == color)
                                {
                                    if (allFigures[k].GetAllMoves(allFigures[k], (i, j), allFigures).Contains((i, j)))
                                    {
                                        (int, int) tempPos = allFigures[k].position;
                                        allFigures[k].position = (i, j);
                                        if (!IsCheck(color))
                                        {
                                            allFigures[k].position = tempPos;
                                            return false;
                                        }
                                        for (int x = 0; x < allFigures.Count; x++)
                                        {
                                            if (allFigures[k]?.position == allFigures[x]?.position && allFigures[k]?.color != allFigures[x].color)
                                            {
                                                Figure temp = allFigures[x];
                                                allFigures[x] = null;
                                                if (!IsCheck(color))
                                                {
                                                    allFigures[x] = temp;
                                                    allFigures[k].position = tempPos;
                                                    return false;
                                                }
                                                else
                                                {
                                                    allFigures[k].position = tempPos;
                                                    allFigures[x] = temp;
                                                }
                                            }
                                            else if (x == 31)
                                                allFigures[k].position = tempPos;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            return isMate;
        }
        /// <summary>
        /// checks is stalemate on board
        /// </summary>
        /// <param name="color"></param>
        /// <returns>true if stalemate on board otherwise false</returns>
        public bool IsStaleMate(ColorEnum color)
        {
            bool isStaleMate = false;
            if (!IsCheck(color))
            {
                isStaleMate = true;
                for (int k = 0; k < 32; k++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (allFigures[k] != null)
                            {
                                if (allFigures[k]?.color == color)
                                {
                                    if (allFigures[k].GetAllMoves(allFigures[k], (i, j), allFigures).Contains((i, j)))
                                    {
                                        (int, int) tempPos = allFigures[k].position;
                                        allFigures[k].position = (i, j);
                                        if (!IsCheck(color))
                                        {
                                            allFigures[k].position = tempPos;
                                            return false;
                                        }
                                        for (int x = 0; x < allFigures.Count; x++)
                                        {
                                            if (allFigures[k]?.position == allFigures[x]?.position && allFigures[k]?.color != allFigures[x].color)
                                            {
                                                Figure temp = allFigures[x];
                                                allFigures[x] = null;
                                                if (!IsCheck(color))
                                                {
                                                    allFigures[x] = temp;
                                                    allFigures[k].position = tempPos;
                                                    return false;
                                                }
                                                else
                                                {
                                                    allFigures[k].position = tempPos;
                                                    allFigures[x] = temp;
                                                }
                                            }
                                            else if (x == 31)
                                            {
                                                allFigures[k].position = tempPos;
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            return isStaleMate;
        }
        /// <summary>
        /// this method initializes fgiure
        /// </summary>
        /// <returns>figures</returns>
        public List<Figure> GetAllFigures()
        {
            ColorEnum color = ColorEnum.white;
            allFigures.Add(new Rook(color, (0, 0)));
            allFigures.Add(new Knight(color, (1, 0)));
            allFigures.Add(new Bishop(color, (2, 0)));
            allFigures.Add(new Queen(color, (3, 0)));
            allFigures.Add(new King(color, (4, 0)));
            allFigures.Add(new Bishop(color, (5, 0)));
            allFigures.Add(new Knight(color, (6, 0)));
            allFigures.Add(new Rook(color, (7, 0)));
            allFigures.Add(new Pawn(color, (0, 1)));
            allFigures.Add(new Pawn(color, (1, 1)));
            allFigures.Add(new Pawn(color, (2, 1)));
            allFigures.Add(new Pawn(color, (3, 1)));
            allFigures.Add(new Pawn(color, (4, 1)));
            allFigures.Add(new Pawn(color, (5, 1)));
            allFigures.Add(new Pawn(color, (6, 1)));
            allFigures.Add(new Pawn(color, (7, 1)));
            color = ColorEnum.black;
            allFigures.Add(new Rook(color, (0, 7)));
            allFigures.Add(new Knight(color, (1, 7)));
            allFigures.Add(new Bishop(color, (2, 7)));
            allFigures.Add(new Queen(color, (3, 7)));
            allFigures.Add(new King(color, (4, 7)));
            allFigures.Add(new Bishop(color, (5, 7)));
            allFigures.Add(new Knight(color, (6, 7)));
            allFigures.Add(new Rook(color, (7, 7)));
            allFigures.Add(new Pawn(color, (0, 6)));
            allFigures.Add(new Pawn(color, (1, 6)));
            allFigures.Add(new Pawn(color, (2, 6)));
            allFigures.Add(new Pawn(color, (3, 6)));
            allFigures.Add(new Pawn(color, (4, 6)));
            allFigures.Add(new Pawn(color, (5, 6)));
            allFigures.Add(new Pawn(color, (6, 6)));
            allFigures.Add(new Pawn(color, (7, 6)));
            return allFigures;
        }
        public static bool IsInside((int, int) pos, (int,int) borderSize)
        {
            if (pos.Item1 > borderSize.Item1 && pos.Item1 < borderSize.Item2 && pos.Item2 >borderSize.Item1 && pos.Item2 < borderSize.Item2)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// findes which figure is moving
        /// </summary>
        /// <param figures position="position"></param>
        /// <returns>moving figure</returns>
        public Figure GetFigure((int, int) position)
        {
            Figure? figure = null;
            if (position == allFigures[0]?.position || position == allFigures[7]?.position)
                figure = new Rook(ColorEnum.white, position);
            else if (position == allFigures[16]?.position || position == allFigures[23]?.position)
                figure = new Rook(ColorEnum.black, position);
            else if (position == allFigures[1]?.position || position == allFigures[6]?.position)
                figure = new Knight(ColorEnum.white, position);
            else if (position == allFigures[17]?.position || position == allFigures[22]?.position)
                figure = new Knight(ColorEnum.black, position);
            else if (position == allFigures[2]?.position || position == allFigures[5]?.position)
                figure = new Bishop(ColorEnum.white, position);
            else if (position == allFigures[18]?.position || position == allFigures[21]?.position)
                figure = new Bishop(ColorEnum.black, position);
            else if (position == allFigures[3]?.position)
                figure = new Queen(ColorEnum.white, position);
            else if (position == allFigures[19]?.position)
                figure = new Queen(ColorEnum.black, position);
            else if (position == allFigures[4]?.position)
                figure = new King(ColorEnum.white, position);
            else if (position == allFigures[20]?.position)
                figure = new King(ColorEnum.black, position);
            else
            {
                for (int i = 24; i < allFigures.Count; i++)
                {
                    if (position == allFigures[i]?.position)
                    {
                        if (allFigures[i].GetLetter()=='p')                        
                            return new Pawn(ColorEnum.black, position);
                        else if (allFigures[i].GetLetter() == 'q')
                            return new Queen(ColorEnum.black, position);
                        else if (allFigures[i].GetLetter() == 'n')
                            return new Knight(ColorEnum.black, position);
                        else if (allFigures[i].GetLetter() == 'r')
                            return new Rook(ColorEnum.black, position);
                        else if (allFigures[i].GetLetter() == 'b')
                            return new Bishop(ColorEnum.black, position);
                    }
                }
                for (int i = 8; i < 16; i++)
                {
                    if (position == allFigures[i]?.position)
                    {
                        if (allFigures[i].GetLetter() == 'P')
                            return new Pawn(ColorEnum.white, position);
                        else if (allFigures[i].GetLetter() == 'Q')
                            return new Queen(ColorEnum.white, position);
                        else if (allFigures[i].GetLetter() == 'N')
                            return new Knight(ColorEnum.white, position);
                        else if (allFigures[i].GetLetter() == 'R')
                            return new Rook(ColorEnum.white, position);
                        else if (allFigures[i].GetLetter() == 'B')
                            return new Bishop(ColorEnum.white, position);
                    }
                }
            }
            return figure;
        }
        /// <summary>
        /// checks can player make rock in current move
        /// </summary>
        /// <param moving figures color="color"></param>
        /// <param moving figures st position="stPos"></param>
        /// <param moving figure tg position="tgPos"></param>
        /// <returns>true if can make rock else false</returns>
        public bool CanRock(ColorEnum color, (int, int) stPos, (int, int) tgPos)
        {
            if (color == ColorEnum.white && WhiteShortRock)
            {
                if (allFigures[4]?.position == stPos && (6, 0) == tgPos)
                {
                    if (!IsCheck(color))
                    {
                        for (int i = 5; i < 7; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (allFigures[j]?.position == (i, 0))
                                    return false;
                            }
                            (int, int) temp = allFigures[4].position;
                            allFigures[4].position = (i, 0);
                            if (!IsCheck(color))
                            {
                                if (i == 6)
                                {
                                    allFigures[4].position = temp;
                                    WhiteShortRock = false;
                                    WhiteLongRock = false;
                                    return true;
                                }
                            }
                            else
                            {
                                allFigures[4].position = temp;
                                return false;
                            }
                        }
                    }
                }
            }
            if (color == ColorEnum.white && WhiteLongRock)
            {
                if (allFigures[4]?.position == stPos && (2, 0) == tgPos)
                {
                    if (!IsCheck(color))
                    {
                        for (int i = 2; i < 4; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (allFigures[j]?.position == (i, 0))
                                    return false;
                            }
                            (int, int) temp = allFigures[4].position;
                            allFigures[4].position = (i, 0);
                            if (!IsCheck(color))
                            {
                                allFigures[4].position = (4, 0);
                                if (i == 3)
                                {
                                    WhiteShortRock = false;
                                    WhiteLongRock = false;
                                    return true;
                                }
                            }
                            else
                            {
                                allFigures[4].position = temp;
                                return false;
                            }
                        }
                    }
                }
            }
            if (color == ColorEnum.black && BlackShortRock)
            {
                if (allFigures[20]?.position == stPos && (6, 7) == tgPos)
                {
                    if (!IsCheck(color))
                    {
                        for (int i = 5; i < 7; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (allFigures[j]?.position == (i, 7))
                                    return false;
                            }
                            (int, int) temp = allFigures[20].position;
                            allFigures[20].position = (i, 7);
                            if (!IsCheck(color))
                            {
                                if (i == 6)
                                {
                                    allFigures[20].position = temp;
                                    BlackShortRock = false;
                                    BlackLongRock = false;
                                    return true;
                                }
                            }
                            else
                            {
                                allFigures[20].position = temp;
                                return false;
                            }
                        }
                    }
                }
            }
            if (color == ColorEnum.black && BlackLongRock)
            {
                if (allFigures[20]?.position == stPos && (2, 7) == tgPos)
                {
                    if (!IsCheck(color))
                    {
                        for (int i = 2; i < 4; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (allFigures[j]?.position == (i, 7))
                                    return false;
                            }
                            (int, int) temp = allFigures[20].position;
                            allFigures[20].position = (i, 7);
                            if (!IsCheck(color))
                            {
                                if (i == 3)
                                {
                                    allFigures[20].position = temp;
                                    BlackShortRock = false;
                                    BlackLongRock = false;
                                    return true;
                                }
                            }
                            else
                            {
                                allFigures[20].position = temp;
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// checks can pawn 
        /// </summary>
        /// <param moving pawn color="color"></param>
        /// <param moving pawn stPos="stPos"></param>
        /// <param moving pawn tgPos="tgPos"></param>
        /// <returns>true if can change else false</returns>
        public bool CanChangePawnToFigure(ColorEnum color,(int, int) stPos, (int, int) tgPos)
        {
            Pawn pawn = new Pawn();
            for (int i = 0; i < 32; i++)
            {
                if (allFigures[i] != null)
                {
                    if (stPos == allFigures[i].position && (allFigures[i].GetLetter() == 'P' || allFigures[i].GetLetter() == 'p'))
                    {
                        if (color == ColorEnum.white)
                        {
                            if (stPos.Item2 == 6 && tgPos.Item2 == 7 && stPos.Item1 == tgPos.Item1)
                                return true;
                        }
                        else
                        {
                            if (stPos.Item2 == 1 && tgPos.Item2 == 0 && stPos.Item1 == tgPos.Item1)
                                return true;
                        }
                        for (int j = 0; j < 32; j++)
                        {
                            if (allFigures[j]?.position == tgPos && color != allFigures[j]?.color )
                            {
                                pawn.color = color;
                                if (pawn.CanEat(stPos, tgPos))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }         
            return false;
        }
        /// <summary>
        /// findes figure which player has chose 
        /// </summary>
        /// <param unique id for each figure="figureId"></param>
        /// <param figures color="color"></param>
        /// <param figures stPos="stPos"></param>
        /// <param figures tgPos="tgPos"></param>
        public void FindFigureForChange(int figureId,ColorEnum color, (int, int) stPos, (int, int) tgPos)
        {          
            if (color == ColorEnum.white)
            {
                for (int i = 8; i < 16; i++)
                {
                    if (allFigures[i]?.position == stPos)
                    {
                       if (figureId == 1)
                           allFigures[i] = new Queen(color, stPos);   
                       else if (figureId == 4)
                           allFigures[i] = new Knight(color, stPos);
                       else if (figureId == 2)
                           allFigures[i] = new Rook(color, stPos);
                       else if (figureId == 3)
                           allFigures[i] = new Bishop(color, stPos);
                    }
                }
            }
            if (color == ColorEnum.black)
            {
                for (int i = 24; i < 32; i++)
                {
                    if (allFigures[i]?.position == stPos)
                    {
                        if (figureId == 1)
                            allFigures[i] = new Queen(color, stPos);
                        else if (figureId == 4)
                            allFigures[i] = new Knight(color, stPos);
                        else if (figureId == 2)
                            allFigures[i] = new Rook(color, stPos);
                        else if (figureId == 3)
                            allFigures[i] = new Bishop(color, stPos);
                    }
                }
            }
        }
        /// <summary>
        /// checks can take pawn on pass enemy pawn
        /// </summary>
        /// <param pawns start position="stPos"></param>
        /// <param position where pawn want to go="tgPos"></param>
        /// <param pawns color="color"></param>
        /// <returns>true if can else false</returns>
        public bool EnPassant((int,int) stPos, (int,int) tgPos,ColorEnum color)
        {
            Pawn pawn = new Pawn();
            pawn.color = color;
            if (pawn.color == ColorEnum.white)
                pawn.color = ColorEnum.black;
            else
                pawn.color = ColorEnum.white;

            if (pawn.CanMoveTwoSquares((lastMove.Item1, lastMove.Item2), (lastMove.Item3, lastMove.Item4), allFigures))
            {
                pawn.color = color;
                for (int i = 0; i < 32; i++)
                {
                    if (allFigures[i] != null)
                    {
                        if (allFigures[i].position.Item2 == lastMove.Item4 && color == allFigures[i].color && (allFigures[i].GetLetter() == 'p' || allFigures[i].GetLetter() == 'P'))
                        {
                            if (allFigures[i].position.Item1 == lastMove.Item3 + 1 || allFigures[i].position.Item1 == lastMove.Item3 - 1)
                            {
                                if (stPos == allFigures[i].position && (tgPos == (lastMove.Item1, lastMove.Item2 - 1) || tgPos == (lastMove.Item1, lastMove.Item2 + 1)))
                                    return true;
                            }
                        }
                    }
                }
            }
            pawn.color = color;
            return false;
        }
    }
}           

