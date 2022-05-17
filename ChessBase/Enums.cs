using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public enum Figures
    {
        pawn = 1,
        knight = 2,
        bishop = 3,
        rook = 4,
        queen = 5,
        king = 6
    }
    public enum FigureLetters
    {
        p = 1,
        N = 2,
        B = 3,
        R = 4,
        Q = 5,
        K = 6
    }
    public enum LetterCoordinate
    {
        a = 0,
        b = 1,
        c = 2,
        d = 3,
        e = 4,
        f = 5,
        g = 6,
        h = 7
    }
}
