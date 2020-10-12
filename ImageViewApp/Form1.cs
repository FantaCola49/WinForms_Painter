using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image img;

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            img = Image.FromFile(files[0]);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                //e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
                RectangleF winRect = new RectangleF(0, 0, e.Graphics.VisibleClipBounds.Width, 
                    e.Graphics.VisibleClipBounds.Height);
                SizeF size = new SizeF(img.Width / img.HorizontalResolution, 
                    img.Height / img.VerticalResolution);

                float scale = Math.Min(winRect.Width / size.Width, winRect.Height / size.Height);

                size.Width *= scale;
                size.Height *= scale;
                e.Graphics.DrawImage(img, winRect.X +
                    (winRect.Width - size.Width) / 2, winRect.Y +
                    (winRect.Height - size.Height) / 2, size.Width, size.Height);

            }
        }
    }
}
