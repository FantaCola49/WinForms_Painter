using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab_29_30
{
    public partial class Form1 : Form
    {

        ArrayList x, y;
        bool doDraw = false;

        public Form1()
        {
            InitializeComponent();
            x = new ArrayList();
            y = new ArrayList();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            doDraw = true;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            doDraw = false;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (doDraw)
            {
                Graphics g = this.CreateGraphics();
                SolidBrush redBrush = new SolidBrush(Color.Red);
                g.FillRectangle(redBrush, e.X, e.Y, 2, 2);
                x.Add(e.X);
                y.Add(e.Y);
                g.Dispose();
                redBrush.Dispose();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush redBrush = new SolidBrush(Color.Red); //Цвет кисти
            for (int i = 0; i < x.Count; i++)
            {
                g.FillRectangle(redBrush, (int)(x[i]), (int)(y[i]), 2, 2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
