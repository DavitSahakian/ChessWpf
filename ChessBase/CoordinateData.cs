using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBase
{
    /// <summary>
    /// Class for data storing
    /// </summary>
    public class CoordinateData
    {
        public int letter;
        public int number;
        public int tempNumber;
        public int tempLetter;
        public int dis;

        public CoordinateData(int letter, int number)
        {
            this.number = number;
            this.letter = letter;
        }
        public CoordinateData(int letter, int number, int dis)
        {
            this.number = number;
            this.letter = letter;
            this.dis = dis;
        }
        public CoordinateData()
        {

        }
        public CoordinateData(int letter, int number, int tempLetter, int tempNumber)
        {
            this.number = number;
            this.letter = letter;
            this.tempNumber = tempNumber;
            this.tempLetter = tempLetter;
        }
    }
}
