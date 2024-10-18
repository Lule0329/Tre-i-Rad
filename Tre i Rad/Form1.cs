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

        public void UpdateBoard()
        {
            xWins.Text = controller.GetXWins();
            oWins.Text = controller.GetOWins();
        }

        

        // Top Row
        private void topleft_Click(object sender, EventArgs e) { Clicked(0, 0); }
        private void top_Click(object sender, EventArgs e) { Clicked(0, 1); }
        private void topright_Click(object sender, EventArgs e) { Clicked(0, 2); }

        // Middle Row
        private void left_Click(object sender, EventArgs e) { Clicked(1, 0); }
        private void middle_Click(object sender, EventArgs e) { Clicked(1, 1); }
        private void right_Click(object sender, EventArgs e) { Clicked(1, 2); }

        // Bottom Row
        private void bottomleft_Click(object sender, EventArgs e) { Clicked(2, 0); }
        private void bottom_Click(object sender, EventArgs e) { Clicked(2, 1); }
        private void bottomright_Click(object sender, EventArgs e) { Clicked(2, 2); }

        public void Set(int row, int col, Bitmap pic)
        {
            // Första raden
            if (row == 0 && col == 0) { topleft.Image = pic; }
            if (row == 0 && col == 1) { top.Image = pic; }
            if (row == 0 && col == 2) { topright.Image = pic; }

            // Andra raden
            if (row == 1 && col == 0) { left.Image = pic; }
            if (row == 1 && col == 1) { middle.Image = pic; }
            if (row == 1 && col == 2) { right.Image = pic; }

            // Tredje raden
            if (row == 2 && col == 0) { bottomleft.Image = pic; }
            if (row == 2 && col == 1) { bottom.Image = pic; }
            if (row == 2 && col == 2) { bottomright.Image = pic; }
        }

        private void Clicked(int row, int col)
        {
            controller.Click(row, col);
        }
    }
}
