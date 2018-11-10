using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ritprogrammet
{
    public partial class Form1 : Form
    {
        public int x = 20;
        public int y = 20;
        public int radio;
        public Color farg = System.Drawing.Color.Black;
        Point lastPoint = Point.Empty;
        bool isMouseDown = new Boolean();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                x = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Error not a valid number of x", "Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                x = 0;
            }
            try
            {
                y = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Error not a valid number of y", "Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                y = 0;
            }
            if (radio == 1)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(farg);
                System.Drawing.Graphics formGraphics;
                formGraphics = pictureBox1.CreateGraphics();
                formGraphics.FillRectangle(myBrush, new Rectangle(e.Location.X, e.Location.Y, x, y));
                myBrush.Dispose();
                formGraphics.Dispose();
            }
            else if (radio == 2)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(farg);
                System.Drawing.Graphics formGraphics;
                formGraphics = pictureBox1.CreateGraphics();
                formGraphics.FillEllipse(myBrush, new Rectangle(e.Location.X, e.Location.Y, x, y));
                myBrush.Dispose();
                formGraphics.Dispose();
            }
            else if (radio == 3)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(farg);
                System.Drawing.Graphics formGraphics;
                formGraphics = pictureBox1.CreateGraphics();
                Point[] points = { new Point((e.Location.X) + x/2, e.Location.Y), new Point(e.Location.X, e.Location.Y - y), new Point((e.Location.X) -x/2, e.Location.Y) };
                formGraphics.FillPolygon(myBrush, points);
                myBrush.Dispose();
                formGraphics.Dispose();
            }
    }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                farg = colorDlg.Color;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Rektangel minRektangel = new Rektangel();
            minRektangel.rektangelRitare(x, y);
            radio = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Cirkel minRektangel = new Cirkel();
            minRektangel.cirkelRitare(x, y);
            radio = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Triangel minRektangel = new Triangel();
            minRektangel.triangelRitare(x, y);
            radio = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radio = 4;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (radio == 4)
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
                if (isMouseDown == true)
                {
                    if (lastPoint != null)
                    {
                        if (pictureBox1.Image == null)
                        {
                            Bitmap minMap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                            pictureBox1.Image = minMap;
                        }
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            g.DrawLine(new Pen(farg, 5), lastPoint, e.Location);
                        }
                        pictureBox1.Invalidate();
                        lastPoint = e.Location;
                    }
                }
            }
        }
    }
}
