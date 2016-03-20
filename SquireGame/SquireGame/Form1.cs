using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquireGame
{
    public partial class Form1 : Form
    {
        private Graphics g1;
        private Graphics g2;
        private Graphics g3;
        private Graphics g4;
        private Graphics g5;
        private Graphics g6;
        private char[][] side1;
        private char[][] side2;
        private char[][] side3;
        private char[][] side4;
        private char[][] side5;
        private char[][] side6;
        private int sizeCell;
        public Form1()
        {
            sizeCell = 50;
            side1 = new char[3][];
            side2 = new char[3][];
            side3 = new char[3][];
            side4 = new char[3][];
            side5 = new char[3][];
            side6 = new char[3][];

            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                side1[i] = new char[3];
                side2[i] = new char[3];
                side3[i] = new char[3];
                side4[i] = new char[3];
                side5[i] = new char[3];
                side6[i] = new char[3];
                for (int j = 0; j < 3; j++)
                {
                    side1[i][j] = 'W';
                    side2[i][j] = 'Y';
                    side3[i][j] = 'B';
                    side4[i][j] = 'G';
                    side5[i][j] = 'R';
                    side6[i][j] = 'O';
                }
            }
            drawBoard();
            
           

        }
        private void drawBoard()
        {
            Pen gridPen = new Pen(Color.Black, 3);
            picSide1.Image = new Bitmap(150, 150);
            g1 = Graphics.FromImage(this.picSide1.Image);

            picSide2.Image = new Bitmap(150, 150);
            g2 = Graphics.FromImage(this.picSide2.Image);

            picSide3.Image = new Bitmap(150, 150);
            g3 = Graphics.FromImage(this.picSide3.Image);

            picSide4.Image = new Bitmap(150, 150);
            g4 = Graphics.FromImage(this.picSide4.Image);

            picSide5.Image = new Bitmap(150, 150);
            g5 = Graphics.FromImage(this.picSide5.Image);

            picSide6.Image = new Bitmap(150, 150);
            g6 = Graphics.FromImage(this.picSide6.Image);
            Brush b;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b = new System.Drawing.SolidBrush(bringColor(side1[i][j]));
                    g1.FillRectangle(b, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    b = new System.Drawing.SolidBrush(bringColor(side2[i][j]));
                    g2.FillRectangle(b, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    b = new System.Drawing.SolidBrush(bringColor(side3[i][j]));
                    g3.FillRectangle(b, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    b = new System.Drawing.SolidBrush(bringColor(side4[i][j]));
                    g4.FillRectangle(b, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    b = new System.Drawing.SolidBrush(bringColor(side5[i][j]));
                    g5.FillRectangle(b, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    b = new System.Drawing.SolidBrush(bringColor(side6[i][j]));
                    g6.FillRectangle(b, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    g1.DrawRectangle(gridPen, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    g2.DrawRectangle(gridPen, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    g3.DrawRectangle(gridPen, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    g4.DrawRectangle(gridPen, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    g5.DrawRectangle(gridPen, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                    g6.DrawRectangle(gridPen, i * sizeCell, j * sizeCell, sizeCell, sizeCell);
                }
            }
        }
        private void shfitLeft(int num)
        {
            char[] tem = new char[3];
            //Array.Copy(side1[num],0, tem,0, 3);

            //Array.Copy(side2[num],0, side1[num],0, 3);
            //Array.Copy(side3[num],0, side2[num],0, 3);
            //Array.Copy(side4[num],0, side3[num],0, 3);
            //Array.Copy(tem,0, side4[num],0, 3);
            for (int i = 0; i < 3; i++)
            {
                tem[i] = side1[i][num];
                side1[i][num] = side2[i][num];
                side2[i][num] = side3[i][num];
                side3[i][num] = side4[i][num];
                side4[i][num] = tem[i];
            }

        }
        private void shfitRight(int num)
        {
            char[] tem = new char[3];
            //Array.Copy(side1[num],0, tem,0, 3);

            //Array.Copy(side4[num],0, side1[num],0, 3);
            //Array.Copy(side3[num],0, side4[num],0, 3);
            //Array.Copy(side2[num],0, side3[num],0, 3);
            //Array.Copy(tem,0, side2[num],0, 3);
            for (int i = 0; i < 3; i++)
            {
                tem[i] = side1[i][num];
                side1[i][num] = side4[i][num];
                side4[i][num] = side3[i][num];
                side3[i][num] = side3[i][num];
                side2[i][num] = tem[i];
            }
        }
        private void shfitUp(int num)
        {
            char[] tem = new char[3];
            //Array.Copy(side1[num],0, tem,0, 3);

            //Array.Copy(side6[num],0, side1[num],0, 3);
            //Array.Copy(side3[num],0, side6[num],0, 3);
            //Array.Copy(side5[num],0, side3[num],0, 3);
            //Array.Copy(tem,0, side5[num],0, 3);

            for (int i = 0; i < 3; i++)
            {
                tem[i] = side1[num][i];
                side1[num][i] = side6[num][i];
                side6[num][i] = side3[num][i];
                side3[num][i] = side5[num][i];
                side5[num][i] = tem[i];
            }
        }
        private void shfitDown(int num)
        {
            char[] tem = new char[3];
            //Array.Copy(side1[num],0, tem,0, 3);

            //Array.Copy(side5[num],0, side1[num],0, 3);
            //Array.Copy(side3[num],0, side5[num],0, 3);
            //Array.Copy(side6[num],0, side3[num],0, 3);
            //Array.Copy(tem,0, side6[num],0, 3);

            for (int i = 0; i < 3; i++)
            {
                tem[i] = side1[num][i];
                side1[num][i] = side5[num][i];
                side5[num][i] = side3[num][i];
                side3[num][i] = side6[num][i];
                side6[num][i] = tem[i];
            }

        }
        private Color bringColor(char a)
        {
            Color c=Color.AliceBlue;
            switch (a)
            {
                case 'W':
                    c = Color.White;
                    break;
                case 'Y':
                    c = Color.Yellow;
                    break;
                case 'B':
                    c = Color.Blue;
                    break;
                case 'G':
                    c = Color.Green;
                    break;
                case 'R':
                    c = Color.Red;
                    break;
                case 'O':
                    c = Color.Orange;
                    break;
            }
            return c;
 
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            shfitUp(rand.Next(3));
            drawBoard();
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            shfitLeft(rand.Next(3));
            drawBoard();
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            shfitRight(rand.Next(3));
            drawBoard();
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            shfitDown(rand.Next(3));
            drawBoard();
        }
    }
}
