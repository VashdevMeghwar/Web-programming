namespace SquireGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picSide1 = new System.Windows.Forms.PictureBox();
            this.picSide2 = new System.Windows.Forms.PictureBox();
            this.picSide3 = new System.Windows.Forms.PictureBox();
            this.picSide6 = new System.Windows.Forms.PictureBox();
            this.picSide5 = new System.Windows.Forms.PictureBox();
            this.picSide4 = new System.Windows.Forms.PictureBox();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide4)).BeginInit();
            this.SuspendLayout();
            // 
            // picSide1
            // 
            this.picSide1.Location = new System.Drawing.Point(13, 13);
            this.picSide1.Name = "picSide1";
            this.picSide1.Size = new System.Drawing.Size(150, 150);
            this.picSide1.TabIndex = 0;
            this.picSide1.TabStop = false;
            // 
            // picSide2
            // 
            this.picSide2.Location = new System.Drawing.Point(170, 13);
            this.picSide2.Name = "picSide2";
            this.picSide2.Size = new System.Drawing.Size(150, 150);
            this.picSide2.TabIndex = 1;
            this.picSide2.TabStop = false;
            // 
            // picSide3
            // 
            this.picSide3.Location = new System.Drawing.Point(327, 13);
            this.picSide3.Name = "picSide3";
            this.picSide3.Size = new System.Drawing.Size(150, 150);
            this.picSide3.TabIndex = 2;
            this.picSide3.TabStop = false;
            // 
            // picSide6
            // 
            this.picSide6.Location = new System.Drawing.Point(327, 169);
            this.picSide6.Name = "picSide6";
            this.picSide6.Size = new System.Drawing.Size(150, 150);
            this.picSide6.TabIndex = 5;
            this.picSide6.TabStop = false;
            // 
            // picSide5
            // 
            this.picSide5.Location = new System.Drawing.Point(170, 169);
            this.picSide5.Name = "picSide5";
            this.picSide5.Size = new System.Drawing.Size(150, 150);
            this.picSide5.TabIndex = 4;
            this.picSide5.TabStop = false;
            // 
            // picSide4
            // 
            this.picSide4.Location = new System.Drawing.Point(13, 169);
            this.picSide4.Name = "picSide4";
            this.picSide4.Size = new System.Drawing.Size(150, 150);
            this.picSide4.TabIndex = 3;
            this.picSide4.TabStop = false;
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(121, 415);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(75, 23);
            this.btn_left.TabIndex = 6;
            this.btn_left.Text = "Left";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(203, 414);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(75, 23);
            this.btn_right.TabIndex = 7;
            this.btn_right.Text = "Right";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // btn_up
            // 
            this.btn_up.Location = new System.Drawing.Point(170, 385);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(75, 23);
            this.btn_up.TabIndex = 8;
            this.btn_up.Text = "Up";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_down
            // 
            this.btn_down.Location = new System.Drawing.Point(170, 452);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(75, 23);
            this.btn_down.TabIndex = 9;
            this.btn_down.Text = "Down";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(637, 487);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.picSide6);
            this.Controls.Add(this.picSide5);
            this.Controls.Add(this.picSide4);
            this.Controls.Add(this.picSide3);
            this.Controls.Add(this.picSide2);
            this.Controls.Add(this.picSide1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picSide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSide1;
        private System.Windows.Forms.PictureBox picSide2;
        private System.Windows.Forms.PictureBox picSide3;
        private System.Windows.Forms.PictureBox picSide6;
        private System.Windows.Forms.PictureBox picSide5;
        private System.Windows.Forms.PictureBox picSide4;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
    }
}

