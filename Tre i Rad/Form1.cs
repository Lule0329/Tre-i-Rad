using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Tre_i_Rad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Controller controller;
        
        internal void RegisterController(Controller controller)
        {
            this.controller = controller;
        }

        private void UpdateBoard()
        {
            xWins.Text = controller.GetXWins();
            oWins.Text = controller.GetOWins();
        }

        // Top Row
        private void topleft_Click(object sender, EventArgs e) { Clicked(1, 1); }
        private void top_Click(object sender, EventArgs e) { Clicked(1, 2); }
        private void topright_Click(object sender, EventArgs e) { Clicked(1, 3); }

        // Middle Row
        private void left_Click(object sender, EventArgs e) { Clicked(2, 1); }
        private void middle_Click(object sender, EventArgs e) { Clicked(2, 2); }
        private void right_Click(object sender, EventArgs e) { Clicked(2, 3); }

        // Bottom Row
        private void bottomleft_Click(object sender, EventArgs e) { Clicked(3, 1); }
        private void bottom_Click(object sender, EventArgs e) { Clicked(3, 2); }
        private void bottomright_Click(object sender, EventArgs e) { Clicked(3, 3); }

        public void Set(int row, int col, Bitmap pic)
        {
            // Första raden
            if (row == 1 && col == 1) { topleft.Image = pic; }
            if (row == 1 && col == 2) { top.Image = pic; }
            if (row == 1 && col == 3) { topright.Image = pic; }

            // Andra raden
            if (row == 2 && col == 1) { left.Image = pic; }
            if (row == 2 && col == 2) { middle.Image = pic; }
            if (row == 2 && col == 3) { right.Image = pic; }

            // Tredje raden
            if (row == 3 && col == 1) { bottomleft.Image = pic; }
            if (row == 3 && col == 2) { bottom.Image = pic; }
            if (row == 3 && col == 3) { bottomright.Image = pic; }
        }

        private void Clicked(int row, int col)
        {
            controller.Click(row, col);
        }
    }
}
