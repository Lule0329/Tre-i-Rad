using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Tre_i_Rad
{
    internal class Controller
    {
        private int xWins = 0;
        private int oWins = 0;
        
        private Model model;
        private Form1 Form1;

        public Controller(Model model, Form1 Form1)
        {
            this.model = model;
            this.Form1 = Form1;

            // lägg till controllern i viewn så att den kan meddela när
            // användaren trycker på knappar och bilder
            Form1.RegisterController(this);
        }

        Bitmap[] images = { Properties.Resources.nada, Properties.Resources.X, Properties.Resources.O };

        public void Winner()
        {
            if (model.IsWinnerX())
            {
                xWins++;
            }
            else if (model.IsWinnerO())
            {
                oWins++;
            }
            else if (model.IsGameOver())
            {

            }
        }

        public void Click(int row, int col)
        {
            model.Set(row, col);
            UpdateView(row, col);
        }

        private void UpdateView(int row, int col)
        {
            // kollar varje rad
            for (int i = 1; i <= 3; i++)
            {
                // kollar varje kolumn
                for (int a = 1; a <= 3; a++)
                {
                    // Om 'Which' är true så sätts pictureboxen till 'X'
                    // annars sätts den till 'O'
                    if (model.IsX(row, col))
                    {
                        Form1.Set(row, col, images[1]);
                    }
                    else if (model.IsO(row, col))
                    {
                        Form1.Set(row, col, images[2]);
                    }
                }
            }
        }

        public void ResetBoard()
        {
            for (int col = 0; col <= 2; col++)
            {
                for (int row = 0; row <= 2; row++)
                {
                    Form1.Set(row, col, images[0]);
                }
            }
        }

        public string GetXWins()
        {
            return $"X Wins: {xWins}";
        }

        public string GetOWins()
        {
            return $"O Wins: {oWins}";
        }
    }
}
