using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    public class FindCoordinates
    {
        LetterCoordinate letterCoordinate = new LetterCoordinate();
        /// <summary>
        /// findes index of number coordinate
        /// </summary>
        /// <param name="number"></param>
        /// <returns>index</returns>
        public int FindNumberCoordinate(int number)
        {
            Array enumData = Enum.GetValues(letterCoordinate.GetType());
            for (int i = 0; i < 8; i++)
            {
                if (number-1 == (int)enumData.GetValue(i))
                {
                    return i;
                }
            }
           throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// findes index of letter coordinate
        /// </summary>
        /// <param name="letter"></param>
        /// <returns>index</returns>
        public int FindLetterCoordinate(string letter)
        {
            Array enumData = Enum.GetValues(letterCoordinate.GetType());
            for (int i = 0; i < 8; i++)
            {
                    if (enumData.GetValue(i).ToString() == letter)
                        return i;           
            }
            throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// findes chess position
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>position</returns>
        public (int,int) ChessCoordinate(string coordinate)
        {
            if (coordinate.Length == 2)
            {
                int.TryParse(coordinate[1].ToString(), out int result);
                if (TryFindLetterCoordinate(coordinate[0].ToString()) && TryFindNumberCoordinate(result))
                        return (FindLetterCoordinate(coordinate[0].ToString().ToLower()), FindNumberCoordinate(result));
            }
            return (10, 10);
        }
        /// <summary>
        /// method finds out is letter correct
        /// </summary>
        /// <param name="letter"></param>
        /// <returns>true if letter is correct(inside board) else false</returns>
        public bool TryFindLetterCoordinate(string letter)
        {
            Array enumData = Enum.GetValues(letterCoordinate.GetType());
            for (int i = 0; i < 8; i++)
            {
                if (enumData.GetValue(i).ToString() == letter)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// method finds out is number correct
        /// </summary>
        /// <param name="number"></param>
        /// <returns>true if number is correct(inside board) else false</returns>
        public bool TryFindNumberCoordinate(int number)
        {
            Array enumData = Enum.GetValues(letterCoordinate.GetType());
            for (int i = 0; i < 8; i++)
            {
                if (number - 1 == (int)enumData.GetValue(i))
                    return true;
            }
            return false;
        }
    }
    
}
