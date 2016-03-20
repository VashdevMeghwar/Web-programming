using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        private Graphics g1;
        private readonly int cellSize;
        private Node[,] pos;
        private int num;
        private Point start;
        private Point end;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(480,480);
            pictureBox1.BackColor = Color.Coral;
            g1 = Graphics.FromImage(this.pictureBox1.Image);
            num = 0;
            cellSize = 60;
            Pen gridPen = new Pen(Color.Black, 2);
            Point p = new Point(25, 25);
            Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Purple);
            int a = 0;
            pos=new Node[8,8];
            for (int i = 0; i < 8; i++)
            {
                a++;
                for (int j = 0; j < 8; j++)
                {
                   
                    if (a % 2 == 0)
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.Brown);
                    else
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.Wheat);
                    g1.FillRectangle(b, i * cellSize, j * cellSize, cellSize, cellSize);
                    a++;
                    if (i == 0 && j == 0 || i == 7 && j == 0)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        g1.DrawString("Rock", Font, b, p);
                        pos[i, j].x = i;
                        pos[i,j].y=j;
                        pos[i, j].power = 8;
                        pos[i, j].initial = true;
                        pos[i,j].player='b';


                    }
                    if (i == 1 && j == 0 || i == 6 && j == 0)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        g1.DrawString("Kight", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 4;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'b';
                    }
                    if (i == 2 && j == 0 || i == 5 && j == 0)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        g1.DrawString("Bishop", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 6;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'b';
                    }
                    if (i == 3 && j == 0)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        g1.DrawString("Queen", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 10;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'b';
                    }
                    if (i == 4 && j == 0)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        g1.DrawString("King", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 12;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'b';
                    }
                    if (j == 1)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        g1.DrawString("Pawn", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 2;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'b';
                    }



                    if (i == 0 && j == 7 || i == 7 && j == 7)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                        g1.DrawString("Rock", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 8;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'w';
                    }
                    if (i == 1 && j == 7 || i == 6 && j == 7)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                        g1.DrawString("Kinght", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 4;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'w';
                    }
                    if (i == 2 && j == 7 || i == 5 && j == 7)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                        g1.DrawString("Bishop",Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 6;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'w';
                    }
                    if (i == 3 && j == 7)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                        g1.DrawString("Queen", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 10;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'w';
                    }
                    if (i == 4 && j == 7)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                        g1.DrawString("King", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 12;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'w';
                    }
                    if (j == 6)
                    {
                        p = new Point(cellSize * i + 18, cellSize * j + 24);
                        b = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                        g1.DrawString("Pawn", Font, b, p);
                        pos[i, j].x = i;
                        pos[i, j].y = j;
                        pos[i, j].power = 2;
                        pos[i, j].initial = true;
                        pos[i, j].player = 'w';
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(pos[i,j].initial==true)
                        comboBox1.Items.Add(pos[i, j].x.ToString()+" "+pos[i,j].player+" "+pos[i,j].y.ToString()+" "+pos[i,j].power.ToString());
                }
                System.Console.WriteLine();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Logics l=new Logics();
            MouseEventArgs me = (MouseEventArgs)e;
            int x = me.X / cellSize;
            int y = me.Y / cellSize;
           // MessageBox.Show(x+" "+y);
            if (num == 0)
            {
                num++;
                start.X = x;
                start.Y = y;
            }
            else if (num == 1)
            {
                num = 0;
                end.X = x;
                end.Y = y;
                if (l.islegel(start, end))
                {
                    MessageBox.Show("Corrent postion");
                }
                else
                    MessageBox.Show("incorrent postion");
            }
        }
    }
}
