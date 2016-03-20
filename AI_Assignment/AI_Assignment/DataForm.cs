using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_Assignment
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
            cmb_GridSize.Items.Add("10*10");
            cmb_GridSize.Items.Add("20*20");
            cmb_GridSize.Items.Add("30*30");
            cmb_GridSize.Items.Add("40*40");
            cmb_GridSize.Items.Add("50*50");
            cmb_GridSize.Items.Add("60*60");
            cmb_GridSize.Items.Add("70*70");
            cmb_GridSize.Items.Add("80*80");
            cmb_GridSize.Items.Add("90*90");
            cmb_GridSize.Items.Add("100*100");

            cmb_hurdle.Items.Add("10%");
            cmb_hurdle.Items.Add("25%");
            cmb_hurdle.Items.Add("50%");
            cmb_hurdle.Items.Add("75%");

            cmb_GridSize.SelectedIndex = 0;
            cmb_hurdle.SelectedIndex = 0;
            cmb_GridSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_hurdle.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btn_genert_grid_Click(object sender, EventArgs e)
        {
            int num = 10, sizeGrid = 50;
            int index = cmb_GridSize.SelectedIndex;
            switch (index)
            {
                case 0:
                    num = 10;
                    sizeGrid = 50;
                    break;
                case 1:
                    num = 20;
                    sizeGrid = 25;
                    break;
                case 2:
                    num = 30;
                    sizeGrid = 16;
                    break;
                case 3:
                    num = 40;
                    sizeGrid = 12;
                    break;
                case 4:
                    num = 50;
                    sizeGrid = 10;
                    break;
                case 5:
                    num = 60;
                    sizeGrid = 8;
                    break;
                case 6:
                    num = 70;
                    sizeGrid = 7;
                    break;
                case 7:
                    num = 80;
                    sizeGrid = 6;
                    break;
                case 8:
                    num = 90;
                    sizeGrid = 5;
                    break;
                case 9:
                    num = 100;
                    sizeGrid = 5;
                    break;

            }

            int index2 = cmb_hurdle.SelectedIndex;
            int percentage = 0;
            switch (index2)
            {
                case 0:
                    percentage = 10;
                    break;
                case 1:
                    percentage = 25;
                    break;
                case 2:
                    percentage = 50;
                    break;
                case 3:
                    percentage = 75;
                    break;
            }
            Form1 f = new Form1(num,sizeGrid,percentage);
            Hide();
            f.ShowDialog();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This A* Algorithm is Implemet and Design By vashdev & Natesh.","About",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void cmb_GridSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_hurdle_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
