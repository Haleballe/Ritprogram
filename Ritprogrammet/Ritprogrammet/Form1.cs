using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void m(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            Graphics graphicsObj;
            graphicsObj = pictureBox1.CreateGraphics();
            Pen minpenna = new Pen(Color.Black, 50);
            Rectangle minrektangle = new Rectangle(e.Location.X, e.Location.Y, x, y);
            graphicsObj.DrawRectangle(minpenna, minrektangle);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
