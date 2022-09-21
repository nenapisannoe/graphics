using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace rgbyohsv
{
    public partial class Form1 : Form
    {

        Bitmap _image;
        int _hue = 0;
        int _saturation = 0;
        int _brightness = 0;

        public Form1()
        {
            InitializeComponent();
        }

       

        private string getPath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Multiselect = false;
            ofd.Filter = "Image Filters(*.PNG;*.JPG)|*.PNG;*.JPG";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return "NONINIT";
            }

        }

        private Tuple<double, double, double> RGBtoHSV(Tuple<int, int, int> rgb)
        {
            double h = 0.0;
            double s = 0.0;
            double v = 0.0;
            double r = rgb.Item1 / 255.0;
            double g = rgb.Item2 / 255.0;
            double b = rgb.Item3 / 255.0;
            double min = Math.Min(r, Math.Min(g, b));
            double max = Math.Max(r, Math.Max(g, b));
            double d = max - min;
            
            if(max == min)
            {
                h = 0; 
            }
            else if (max == r && g >= b)
            {
                h = 60 * ((g - b) / d) /*+0*/;
            }
            else if(max ==r && g < b)
            {
                h = 60 * ((g - b) / d) + 360;
            }
            else if(max == g)
            {
                h = 60 * ((b - r) / d) + 120;
            }
            else if (max == b)
            {
                h = 60 * ((r - g) / d) + 240;    
            }
            
            if(max == 0)
            {
                s = 0;
            }
            else
            {
                s = 1 - (min / max);
            }

            v = max;

            h = Math.Abs((h + _hue) % 360);
            s = Math.Min(Math.Max(s + (_saturation / 100.0), 0), 1.0);
            v = Math.Min(Math.Max(v + (_brightness / 100.0), 0), 1.0);
            return Tuple.Create(h, s, v);
        }

        private Tuple<int, int, int> HSVtoRGB(Tuple<double, double, double> hsv)
        {
            double hue = hsv.Item1;
            double saturation = hsv.Item2 * 100;
            double value = hsv.Item3 * 100;
            int h_i = (int)Math.Floor(hsv.Item1 / 60) % 6;
            double vmin = ((100 - saturation) * value) / 100;
            double alpha = (value - vmin) * ((hue % 60) / 60);
            double vinc = vmin + alpha;
            double vdec = value - alpha;
            switch (h_i)
            {
                case 0:
                    return new Tuple<int, int, int>((int)(value * 2.55), (int)(vinc * 2.55), (int)(vmin * 2.55));
                case 1:
                    return new Tuple<int, int, int>((int)(vdec * 2.55), (int)(value * 2.55), (int)(vmin * 2.55));
                case 2:
                    return new Tuple<int, int, int>((int)(vmin * 2.55), (int)(value * 2.55), (int)(vinc * 2.55));
                case 3:
                    return new Tuple<int, int, int>((int)(vmin * 2.55), (int)(vdec * 2.55), (int)(value * 2.55));
                case 4:
                    return new Tuple<int, int, int>((int)(vinc * 2.55), (int)(vmin * 2.55), (int)(value * 2.55));
                case 5:
                    return new Tuple<int, int, int>((int)(value * 2.55), (int)(vmin * 2.55), (int)(vdec * 2.55));

                default:
                    throw new Exception();
            }
        }

        private void show()
        {
            var _width = _image.Width;
            var _height = _image.Height;
            Bitmap _bitmap = new Bitmap(_width, _height);
            for(int i = 0; i < _width; i++)
            {
                for(int j = 0; j < _height; j++)
                {
                    Tuple<int, int, int> t = new Tuple<int, int, int>(_image.GetPixel(i, j).R, _image.GetPixel(i, j).G, _image.GetPixel(i, j).B);
                    Tuple<int, int, int> res = HSVtoRGB(RGBtoHSV(t));
                    _bitmap.SetPixel(i, j, Color.FromArgb(255, Math.Abs(res.Item1 % 256), Math.Abs(res.Item2 % 256), Math.Abs(res.Item3 % 256)));
                }
            }
            pictureBox1.Image = _bitmap;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            _image = new Bitmap(getPath());
            show();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string _name = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "c:\\";
            sfd.Filter = "Image Files(*.PNG;*.JPG)|*.PNG;*.JPG";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _name = sfd.FileName;
            }
            pictureBox1.Image.Save(_name);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this._hue = 0;
            hueTrackBar.Value = 0;
            this._saturation = 0;
            saturationTrackBar.Value = 0;
            this._brightness = 0;
            brightnessTrackBar.Value = 0;
        }

        private void hueTrackBar_Scroll(object sender, EventArgs e)
        {
            _hue = hueTrackBar.Value;
        }

        private void saturationTrackBar_Scroll(object sender, EventArgs e)
        {
            _saturation = saturationTrackBar.Value;
        }

        private void brightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            _brightness = brightnessTrackBar.Value;
        }
    }
}
