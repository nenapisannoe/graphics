using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LAB3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point start_pos;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start_pos = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!button1.Enabled)
                draw_Bresenham_line(start_pos, e.Location);
            else draw_Wu_line(start_pos, e.Location);
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
        }

        void draw_Bresenham_line(Point p1, Point p2)
        {
            int x1 = p1.X;
            int x2 = p2.X;
            int y1 = p1.Y;
            int y2 = p2.Y;

            var delta = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);
                                                             
            if (delta)
            {
                (x1, y1) = (y1, x1);
                (x2, y2) = (y2, x2);
            }

            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
                (y1, y2) = (y2, y1);
            }

            int dx = x2 - x1;
            int dy = Math.Abs(y2 - y1);

            int error = dx / 2;
            int ystep = (y1 < y2) ? 1 : -1;
            int y = y1;

            var bitmap = new Bitmap(pictureBox1.Image);
            for (int x = x1; x <= x2; x++)
            {
                my_set_pixel(bitmap, Color.DarkOrange, delta, x, y, 255);
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
            pictureBox1.Image = bitmap;
        }

        void draw_Wu_line(Point p1, Point p2)
        {
            int x1 = p1.X;
            int x2 = p2.X;
            int y1 = p1.Y;
            int y2 = p2.Y;

            var delta = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            if (delta)
            {
                (x1, y1) = (y1, x1);
                (x2, y2) = (y2, x2);
            }

            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
                (y1, y2) = (y2, y1);
            }

            var bitmap = new Bitmap(pictureBox1.Image);

            float dx = x2 - x1;
            float dy = y2 - y1;
            float grad_k = dy / dx;
            float y = y1 + grad_k;

            my_set_pixel(bitmap, Color.DarkSeaGreen, delta, x1, y1, 255); 
            my_set_pixel(bitmap, Color.DarkSeaGreen, delta, x2, y2, 255);

            for (var x = x1 + 1; x <= x2 - 1; x++)
            {
                my_set_pixel(bitmap, Color.DarkSeaGreen, delta, x, (int)y, (int)(255 * (1 - (y - (int)y))));
                my_set_pixel(bitmap, Color.DarkSeaGreen, delta, x, (int)(y + 1), (int)(255 * (y - (int)y)));
                y += grad_k;
            }
            pictureBox1.Image = bitmap;
        }

        static void my_set_pixel(Bitmap b, Color col, bool delta, int x, int y, int color_k)
        {
            
            if (delta)
                (x, y) = (y, x);
            b.SetPixel(x, y, Color.FromArgb(color_k, col));
        }
    }
}
