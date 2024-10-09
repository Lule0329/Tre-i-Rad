using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tre_i_Rad
{
    internal class Model
    {   
        // matris som innehåller alla rutors tillstånd
        // "" betyder ospelad ruta
        // "x" betyder att spelare-x har markerat
        // "o" betyder att spelare-o har markerat
        private string[,] matrix = new string[4, 4];

        // indikerar vilken spelares tur som det är
        // true indikerar att det är spelare-x tur, annars spelare-o
        private bool xTurn = true;

        private int xWins = 0;
        private int oWins = 0;

        public Model()
        {
            Clear();
        }

        // tömmer spelplanen
        public void Clear()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    matrix[row, col] = "";
                }
            }

            xTurn = true;
        }

        // markerar ruta med "x" eller "o" beroende på vemst tur det är
        public void Set(int row, int col)
        {
            if (matrix[row, col] != "")
            {
                return;   
            }

            if (xTurn)
            {
                matrix[row, col] = "x";
            }
            else
            {
                matrix[row, col] = "o";
            }

            xTurn = !xTurn;
        }

        // true om rutan omarkerad
        public bool IsClear(int row, int col)
        {
            return matrix[row, col] == "";
        }

        // true om rutan markerad x
        public bool IsX(int row, int col)
        {
            return matrix[row, col] == "x";
        }

        // true om rutan markerad o
        public bool IsO(int row, int col)
        {
            return matrix[row, col] == "o";
        }

        public bool Which(int row, int col)
        {
            // returnar 'true' om det är ett x i rutan
            if (matrix[row, col] == "x")
            {
                return true;
            }
            else if (matrix[row, col] == "o")
            {
                return false;
            }

            return false;
        }

        // true om x är vinnare
        public bool IsWinnerX()
        {
            return IsWinner("x");
        }

        // true om o är vinnare
        public bool IsWinnerO()
        {
            return IsWinner("o");
        }

        // true om parametern mark är vinnare
        private bool IsWinner(string mark)
        {
            // kolla rader
            for (int row = 0; row < 3; row++)
            {
                bool all = true;
                for (int col = 0; col < 3; col++)
                {
                    all = all && matrix[row, col] == mark;
                }
                if (all)
                {
                    return true;
                }
            }

            // kolla kolumner
            for (int col = 0; col < 3; col++)
            {
                bool all = true;
                for (int row = 0; row < 3; row++)
                {
                    all = all && matrix[row, col] == mark;
                }
                if (all)
                {
                    return true;
                }
            }

            // kolla diagonaler
            if (matrix[0, 0] == mark && matrix[1, 1] == mark && matrix[2, 2] == mark)
            {
                return true;
            }
            if (matrix[2, 0] == mark && matrix[1, 1] == mark && matrix[0, 2] == mark)
            {
                return true;
            }

            // inga tre i rad
            return false;
        }

        // true om alla rutor markerade
        public bool IsGameOver()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (matrix[row, col] == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
