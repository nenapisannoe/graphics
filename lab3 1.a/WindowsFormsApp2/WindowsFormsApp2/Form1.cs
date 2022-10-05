using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Bitmap imageForPictureBox;
        List<Point> pointsMouseClick;
        Pen penFill;
        bool isNotFirstClick;
        bool isPen;

        Graphics g;

        public Form1()
        {
            InitializeComponent();
            setting();
        }

        void setting()
        {
            pointsMouseClick = new List<Point>();

            var random = new Random();
            penFill = new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));

            isNotFirstClick = false;
            isPen = true;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            imageForPictureBox = (Bitmap)pictureBox1.Image;
            var temp = Graphics.FromImage(pictureBox1.Image);
            temp.Clear(pictureBox1.BackColor);
            pictureBox1.Image = pictureBox1.Image;
            g = Graphics.FromImage(imageForPictureBox);
            pictureBox1.Image = imageForPictureBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isPen)
            {
                button1.Text = "Поменять на карандаш";
                pictureBox1.MouseClick -= pictureBox1_MouseClick_Pen;
                pictureBox1.MouseClick += pictureBox1_MouseClick_Fill;
            }
            else
            {
                button1.Text = "Поменять на заливку";
                pictureBox1.MouseClick += pictureBox1_MouseClick_Pen;
                pictureBox1.MouseClick -= pictureBox1_MouseClick_Fill;

            }
            isPen = !isPen;
        }


        private void pictureBox1_MouseClick_Pen(object sender, MouseEventArgs e)
        {
            if (isNotFirstClick)
            {
                pointsMouseClick.Add(new Point(e.X, e.Y));
                g.DrawLines(new Pen(Color.Black, 2), pointsMouseClick.ToArray());
            }
            else
            {
                pointsMouseClick.Add(new Point(e.X, e.Y));
                isNotFirstClick = true;
            }
            pictureBox1.Image = imageForPictureBox;
        }

        private void pictureBox1_MouseClick_Fill(object sender, MouseEventArgs e)
        {
            fill(new Point(e.X, e.Y));
        }

        private bool colorIsNotEquals(Color color, Color color2)
        {
            return !(color.R == color2.R && color.G == color2.G && color.B == color2.B);
        }

        private void fill(Point p)
        {
            Color formColor = imageForPictureBox.GetPixel(p.X, p.Y);
            if (0 <= p.X &&
                p.X < imageForPictureBox.Width &&
                0 <= p.Y &&
                p.Y < imageForPictureBox.Height - 1 &&
                colorIsNotEquals(formColor, Color.Black) &&
                colorIsNotEquals(formColor, penFill.Color))
            {
                Point leftBound = new Point(p.X, p.Y);
                Point rightBound = new Point(p.X, p.Y);
                Color currentColor = formColor;

                while (0 < leftBound.X && colorIsNotEquals(currentColor, Color.Black))
                {
                    leftBound.X -= 1;
                    currentColor = imageForPictureBox.GetPixel(leftBound.X, p.Y);
                }
                currentColor = formColor;

                while (rightBound.X < pictureBox1.Width - 1 && colorIsNotEquals(currentColor, Color.Black))
                {
                    rightBound.X += 1;
                    currentColor = imageForPictureBox.GetPixel(rightBound.X, p.Y);
                }

                if (leftBound.X != 0)
                    leftBound.X += 1;

                rightBound.X -= 1;

                if (rightBound.X - leftBound.X == 0)
                    imageForPictureBox.SetPixel(rightBound.X, rightBound.Y, penFill.Color);

                g.DrawLine(penFill, leftBound, rightBound);
                pictureBox1.Image = imageForPictureBox;

                for (int i = leftBound.X; i < rightBound.X + 1; ++i)
                    fill(new Point(i, p.Y + 1));

                for (int i = leftBound.X; i < rightBound.X + 1; ++i)
                    if (p.Y > 0)
                        fill(new Point(i, p.Y - 1));
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            setting();
            isPen = false;
            button1_Click(null, null);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
