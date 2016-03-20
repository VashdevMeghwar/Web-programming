using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI_Assignment.Algo;

namespace AI_Assignment
{
    
    public partial class Form1 : Form
    {
        private Graphics g1;
        private int num;
        private int sizeGrid;
        private int numSG;
        private byte[,] gird;
        private Point start;
        private Point end;
        private bool[,] noPath;
        private int percentage;


        public Form1(int num,int sizeGrid,int per)
        {
            InitializeComponent();
            this.num = num; 
            this.sizeGrid = sizeGrid;
            numSG = 0;
            
            gird = new byte[num, num];
            noPath=new bool[num,num];
            int hurdle = 0;
            this.percentage = per;
            hurdle = ((num*num)*percentage) / 100;

            Random rand=new Random();

            pictureBox1.Image = new Bitmap(500, 500);
            g1 = Graphics.FromImage(this.pictureBox1.Image);
            Pen gridPen = new Pen(Color.Black, 2);
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    g1.DrawRectangle(gridPen, i * sizeGrid, j * sizeGrid, sizeGrid, sizeGrid);
                    gird[i, j] = (byte)sizeGrid;
                    noPath[i, j] = false;
                }
            }
            int x = 0;
            int y = 0;
            Brush b1 = new System.Drawing.SolidBrush(System.Drawing.Color.Purple);
            while (hurdle > 0)
            {
                x = rand.Next(num);
                y = rand.Next(num);
                g1.FillRectangle(b1, x * sizeGrid, y * sizeGrid, sizeGrid, sizeGrid);
                noPath[x, y] = true;
                hurdle--;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (numSG < 2)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                int x = me.X / sizeGrid;
                int y = me.Y / sizeGrid;
                this.pictureBox1.Image = new Bitmap(this.pictureBox1.Image);
                g1 = Graphics.FromImage(this.pictureBox1.Image);
                Brush b1 = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
                if (numSG == 0 && !noPath[x,y])
                {
                    b1 = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
                    start = new Point(x, y);
                    numSG++;
                    g1.FillRectangle(b1, x * sizeGrid, y * sizeGrid, sizeGrid, sizeGrid);
                }
                else if(!noPath[x,y])
                {
                    b1 = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                    end = new Point(x, y);
                    numSG++;
                    g1.FillRectangle(b1, x * sizeGrid, y * sizeGrid, sizeGrid, sizeGrid);
                }
               
                
            }
 
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            PathFinder p=new PathFinder(gird,noPath);
            List<PathFinderNode> path = p.FindPath(start,end,this.num);
            if (path == null)
            {
                MessageBox.Show("Path not found");
            }
            else
            {
                this.pictureBox1.Image = new Bitmap(this.pictureBox1.Image);
                g1 = Graphics.FromImage(this.pictureBox1.Image);
                Brush b1 = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                int cost = 0;
                foreach (PathFinderNode pa in path)
                {
                    cost = cost+pa.g+pa.f;
                    g1.FillRectangle(b1, pa.x * sizeGrid, pa.y * sizeGrid, sizeGrid, sizeGrid);
                }
                txt_cost.Text = cost.ToString()+"$";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataForm f = new DataForm();
            this.Hide();
            f.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
            Form1 f = new Form1(num, sizeGrid, percentage);
            f.Show();

        }


    }
}
