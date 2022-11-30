using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace LAB_3D
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        rotationFigure current_saved_figure;

        Pen pen_shape = new Pen(Color.Red);

        int centerX, centerY;
        Matrixes matr = new Matrixes();

        List<face> shape = new List<face>(); // фигура - список граней
        List<my_point> points = new List<my_point>(); // список точек
        List<my_point> initial_points = new List<my_point>();
        Dictionary<int, List<int>> relationships = new Dictionary<int, List<int>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            centerX = pictureBox.Width / 2;
            centerY = pictureBox.Height / 2;
            pictureBox.Image = bmp;

            g = Graphics.FromImage(pictureBox.Image);
            g.Clear(Color.White);

            pictureBox.Invalidate();
        }

        private List<my_point> Copy(List<my_point> l)
        {
            List<my_point> res = new List<my_point>(l.Count);
            for (int i = 0; i < l.Count; ++i)
                res.Add(new my_point(l[i].X, l[i].Y, l[i].Z));
            return res;
        }

        private void draw_face(face f)
        {
            List<my_point> points_to_draw = new List<my_point>(f.points.Count());

            if (isometry.Checked)
                points_to_draw = matr.get_transformed_my_points(matr.matrix_isometry(), Copy(f.points));
            else if (perspective.Checked)
                points_to_draw = matr.get_transformed_my_points(matr.matrix_perspective(1000), Copy(f.points));

            for (int i = 0; i < points_to_draw.Count(); i++)
            {
                int x1 = (int)Math.Round(points_to_draw[i].X + centerX);
                int x2 = (int)Math.Round(points_to_draw[(i + 1) % points_to_draw.Count()].X + centerX);
                int y1 = (int)Math.Round(-points_to_draw[i].Y + centerY);
                int y2 = (int)Math.Round(-points_to_draw[(i + 1) % points_to_draw.Count()].Y + centerY);
                g.DrawLine(pen_shape, x1, y1, x2, y2);
            }

            //pictureBox.Refresh();
        }

        private void redraw_image()
        {
            g.Clear(Color.White);

            foreach (var f in shape)
                draw_face(f);
            pictureBox.Refresh();
        }

        // центр фигуры
        private my_point center_point() 
        {
            double sumX = 0, sumY = 0, sumZ = 0;
            int count = 0;
            for (int i = 0; i < shape.Count; i++)
                for (int j = 0; j < shape[i].points.Count; j++)
                {
                    sumX += shape[i].points[j].X;
                    sumY += shape[i].points[j].Y;
                    sumZ += shape[i].points[j].Z;
                    count++;
                }
            return new my_point(sumX / count, sumY / count, sumZ / count);
        }

        private my_point normalize_vector(my_point pt1,my_point pt2)
        {
            if (pt2.Z < pt1.Z || (pt2.Z == pt1.Z && pt2.Y < pt1.Y) || (pt2.Z == pt1.Z && pt2.Y == pt1.Y) && pt2.X < pt1.X)
            {
                my_point tmp = pt1;
                pt1 = pt2;
                pt2 = tmp;
            }

            double x = pt2.X - pt1.X;
            double y = pt2.Y - pt1.Y;
            double z = pt2.Z - pt1.Z;
            double d = Math.Sqrt(x * x + y * y + z * z);
            if (d != 0)
                return new my_point(x / d, y / d, z / d); 
            return new my_point(0, 0, 0);
        }

        /*
        private my_point normalize_vector(my_point vctr)
        {
            double d = Math.Sqrt(vctr.X * vctr.X + vctr.Y * vctr.Y + vctr.Z * vctr.Z);
            if (d != 0)
                return new my_point(vctr.X / d, vctr.Y / d, vctr.Z / d);
            return new my_point(0, 0, 0);
        }*/

        // сдвиг
        private void displacement_button_Click(object sender, EventArgs e) 
        {
            int kx = (int)x_shift.Value, ky = (int)y_shift.Value, kz = (int)z_shift.Value;
            points = matr.get_transformed_my_points(matr.matrix_offset(kx, ky, kz), points);
            redraw_image();
        }

        // поворот
        private void rotate_button_Click(object sender, EventArgs e) 
        {
            double x_angle = ((double)x_rotate.Value * Math.PI) / 180;
            double y_angle = ((double)y_rotate.Value * Math.PI) / 180;
            double z_angle = ((double)z_rotate.Value * Math.PI) / 180;
            matr.get_transformed_my_points(matr.matrix_rotation_x_angular(x_angle), points);
            matr.get_transformed_my_points(matr.matrix_rotation_y_angular(y_angle), points);
            matr.get_transformed_my_points(matr.matrix_rotation_z_angular(z_angle), points);
            redraw_image();
        }

        // масштаб
        private void scale_button_Click(object sender, EventArgs e) 
        {
            my_point center_P = center_point();
            matr.get_transformed_my_points(matr.matrix_offset(-center_P.X, -center_P.Y, -center_P.Z), points);
            matr.get_transformed_my_points(matr.matrix_scale((double)x_scale.Value, (double)y_scale.Value, (double)z_scale.Value), points);
            matr.get_transformed_my_points(matr.matrix_offset(center_P.X, center_P.Y, center_P.Z), points);
            redraw_image();
        }

        private void cancel_button_Click(object sender, EventArgs e) 
        {
            shape_CheckedChanged(null, null);
            shape.Clear();

            tetrahedron.Checked = false;
            hexahedron.Checked = false;
            octahedron.Checked = false;
            dodecahedron.Checked = false;
            icosahedron.Checked = false;
            rotation_figure.Checked = false;

            redraw_image();
        }

        private void isometry_CheckedChanged(object sender, EventArgs e)
        { 
            if (!isometry.Checked) return;
            perspective.Checked = false;
            redraw_image();
        }

        private void perspective_CheckedChanged(object sender, EventArgs e)
        {
            if (!perspective.Checked) return;
            isometry.Checked = false;
            redraw_image();
        }

        private void rot_list_add_Click(object sender, EventArgs e)
        {
            initial_points.Add(new my_point((int)n_pt_X.Value, (int)n_pt_Y.Value, (int)n_pt_Z.Value));
        }

        private void rot_list_reset_Click(object sender, EventArgs e)
        {
            initial_points.Clear();
        }

        private void initiate_build_Click(object sender, EventArgs e)
        {
            my_point pt1 = new my_point((double)axis_1st_X.Value, (double)axis_1st_Y.Value, (double)axis_1st_Z.Value);
            my_point pt2 = new my_point((double)axis_2st_X.Value, (double)axis_2st_Y.Value, (double)axis_2st_Z.Value);
            this.current_saved_figure = new rotationFigure(this.initial_points, pt1, pt2, (int)dividence_count.Value);
            build_rotation_figure();  
        }

        private void save_to_file_Click(object sender, EventArgs e)
        {
            figure f = new figure(this.points, this.relationships);
            string file_str  = JsonConvert.SerializeObject(f);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "3-d files (*.trd)|*.trd";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.CheckFileExists)
                    File.Delete(saveFileDialog1.FileName);
                File.WriteAllText(saveFileDialog1.FileName, file_str);
            }
        }

        private void load_from_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "3-d files (*.trd)|*.trd";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                if (openFileDialog1.CheckFileExists)
                {
                    string res = File.ReadAllText(openFileDialog1.FileName);
                    figure f = JsonConvert.DeserializeObject<figure>(res);
                    this.points = f.points;
                    this.shape.Clear();

                    foreach (var item in f.relationships)
                    {
                        face q = new face();
                        foreach (var pt in item.Value)
                            q.add(points[pt]);
                        this.shape.Add(q);
                    }

                    build_points();
                    redraw_image();
                }
        }

        private double sum_sin_cos(double x, double y)
        {
            return Math.Sin(x)+Math.Cos(y);
        }

        private double sum(double x, double y)
        {
            return x+y;
        }

        private double mult(double x, double y)
        {
            return x*y;
        }

        private void process_points(List<my_point> cur_points, ref List<my_point> built_points, ref Dictionary<Tuple<double, double>, int> point_num, ref int cur_est, int i)
        {
            face f_func = new face();
            relationships[i] = new List<int>();

            foreach (my_point p in cur_points)
            {
                Tuple<double, double> t = new Tuple<double, double>(p.X, p.Y);
                if (!point_num.ContainsKey(t))
                {
                    f_func.add(p);
                    built_points.Add(p);
                    point_num.Add(t, cur_est);
                    cur_est++;
                }
                else f_func.add(built_points[point_num[t]]);
                relationships[i].Add(point_num[t]);
            }
            shape.Add(f_func);
        }

        private void make_func_shape(Func<double, double, double> f, double x1, double x2, double y1, double y2, double step)
        {
            relationships.Clear();
            shape.Clear();
            Dictionary<Tuple<double, double>, int> point_num = new Dictionary<Tuple<double, double>, int>();
            List<my_point> built_points = new List<my_point>();
            int i = 0;
            int cur_est = 0;

            for (double x = x1; x <= x2-step; x += step)
                for(double y = y1; y <= y2-step; y += step)
                {
                    List<my_point> cur_points = new List<my_point>(){
                        new my_point(x, y, f(x, y)),
                        new my_point(x+step, y, f(x+step, y)),
                        new my_point(x, y+step, f(x, y+step)),
                        new my_point(x + step, y + step, f(x + step, y + step))
                    };
                    process_points(cur_points, ref built_points, ref point_num, ref cur_est, i);
                    i++;
                }

            if (x1 == x2)
                for (double y = y1; y <= y2 - step; y += step)
                {
                    List<my_point> cur_points = new List<my_point>(){
                        new my_point(x1, y, f(x1, y)),
                        new my_point(x1, y+step, f(x1, y+step))
                    };
                    process_points(cur_points, ref built_points, ref point_num, ref cur_est, i);
                    i++;
                }
            else if (y1 == y2) 
                for (double x = x1; x <= x2 - step; x += step)
                {
                    List<my_point> cur_points = new List<my_point>(){
                        new my_point(x, y1, f(x1, y1)),
                        new my_point(x+step, y1, f(x1 + step, y1))
                    };
                    process_points(cur_points, ref built_points, ref point_num, ref cur_est, i);
                    i++;
                }
        }

        private void draw_graphic(Func<double, double, double> f)
        {
            double x1, x2, y1, y2, step;

            bool if_read = Double.TryParse(textBox_x1.Text, out x1);
            if_read = Double.TryParse(textBox_x2.Text, out x2);
            if_read = Double.TryParse(textBox_y1.Text, out y1);
            if_read = Double.TryParse(textBox_y2.Text, out y2);
            if_read = Double.TryParse(textBox_step.Text, out step);

            if(x1 > x2)
            {
                MessageBox.Show("x1 > x2");
                return;
            }
            if (y1 > y2)
            {
                MessageBox.Show("y1 > y2");
                return;
            }
            if(step <= 0)
            {
                MessageBox.Show("Шаг должен быть > 0");
                return;
            }

            make_func_shape(f, x1, x2, y1, y2, step);
            build_points();
            redraw_image();
        }

        private void button_build_Click(object sender, EventArgs e)
        {
            if(listBox_funs.SelectedItem == null)
            {
                MessageBox.Show("Выберите функцию!");
                return;
            }

            string chosen_fun = listBox_funs.SelectedItem.ToString();
            switch(chosen_fun)
            {
                case "x+y":
                    draw_graphic(sum);
                    break;
                case "x*y":
                    draw_graphic(mult);
                    break;
                case "sin(x)+cos(y)":
                    draw_graphic(sum_sin_cos);
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            redraw_image();
        }

        private void build_points()
        {
            points.Clear();
            foreach (face sh in shape)
                for (int i = 0; i < sh.points.Count; i++)
                    if (!points.Contains(sh.points[i]))
                        points.Add(sh.points[i]);
        }



        // построение всех фигур
        private void build_tetrahedron()
        {
            double h = Math.Sqrt(3) * 50;
            double h_big = 25 * Math.Sqrt(13);
            points.Clear();
            my_point p1 = new my_point(-50, -h / 3, 0);
            my_point p2 = new my_point(50, -h / 3, 0);
            my_point p3 = new my_point(0, 2 * h / 3, 0);
            my_point p4 = new my_point(0, 0, h_big);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            shape.Clear();
            relationships.Clear();
            relationships.Add(0, new List<int>() { 0, 1, 2 });
            relationships.Add(1, new List<int>() { 0, 3, 1 });
            relationships.Add(2, new List<int>() { 3, 1, 2 });
            relationships.Add(3, new List<int>() { 0, 3, 2 });
            face f1 = new face(); f1.add(p1); f1.add(p2); f1.add(p3); shape.Add(f1);
            face f2 = new face(); f2.add(p1); f2.add(p4); f2.add(p2); shape.Add(f2);
            face f3 = new face(); f3.add(p4); f3.add(p2); f3.add(p3); shape.Add(f3);
            face f4 = new face(); f4.add(p1); f4.add(p4); f4.add(p3); shape.Add(f4);
        }

        private void build_hexahedron()
        {
            points.Clear();
            my_point p1 = new my_point(-50, -50, -50);
            my_point p2 = new my_point(-50, 50, -50);
            my_point p3 = new my_point(50, 50, -50);
            my_point p4 = new my_point(50, -50, -50);
            my_point p5 = new my_point(-50, -50, 50);
            my_point p6 = new my_point(-50, 50, 50);
            my_point p7 = new my_point(50, 50, 50);
            my_point p8 = new my_point(50, -50, 50);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            points.Add(p6);
            points.Add(p7);
            points.Add(p8);
            shape.Clear();
            relationships.Clear();
            relationships.Add(0, new List<int>() { 0, 1, 2, 3 });
            face f1 = new face(); f1.add(p1); f1.add(p2); f1.add(p3); f1.add(p4); shape.Add(f1);
            relationships.Add(1, new List<int>() { 0, 4, 5, 1 });
            face f2 = new face(); f2.add(p1); f2.add(p2); f2.add(p6); f2.add(p5); shape.Add(f2);
            relationships.Add(2, new List<int>() { 4, 6, 7, 5 });
            face f3 = new face(); f3.add(p5); f3.add(p6); f3.add(p7); f3.add(p8); shape.Add(f3);
            relationships.Add(3, new List<int>() { 2, 6, 7, 3 });
            face f4 = new face(); f4.add(p4); f4.add(p3); f4.add(p7); f4.add(p8); shape.Add(f4);
            relationships.Add(4, new List<int>() { 1, 5, 6, 2 });
            face f5 = new face(); f5.add(p2); f5.add(p6); f5.add(p7); f5.add(p3); shape.Add(f5);
            relationships.Add(5, new List<int>() { 3, 7, 4, 0 });
            face f6 = new face(); f6.add(p1); f6.add(p5); f6.add(p8); f6.add(p4); shape.Add(f6);
        }

        private void build_octahedron()
        {
            double a = Math.Sqrt(3) / 2 * 100;
            double p = (a + a + 100) / 2;
            double h = 2 * Math.Sqrt(p * (p - 100) * (p - a) * (p - a)) / 100;
            points.Clear();
            my_point p1 = new my_point(0, -h, 0);
            my_point p2 = new my_point(-50, 0, -50);
            my_point p3 = new my_point(0, h, 0);
            my_point p4 = new my_point(50, 0, -50);
            my_point p5 = new my_point(-50, 0, 50);
            my_point p6 = new my_point(50, 0, 50);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            points.Add(p6);
            shape.Clear();
            relationships.Clear();
            relationships.Add(0, new List<int>() { 1, 2, 3 });
            face f1 = new face(); f1.add(p2); f1.add(p3); f1.add(p4); shape.Add(f1);
            relationships.Add(1, new List<int>() { 1, 0, 3 });
            face f2 = new face(); f2.add(p2); f2.add(p1); f2.add(p4); shape.Add(f2);
            relationships.Add(2, new List<int>() { 1, 2, 4 });
            face f3 = new face(); f3.add(p2); f3.add(p3); f3.add(p5); shape.Add(f3);
            relationships.Add(3, new List<int>() { 1, 0, 4 });
            face f4 = new face(); f4.add(p2); f4.add(p1); f4.add(p5); shape.Add(f4);
            relationships.Add(4, new List<int>() { 3, 2, 5 });
            face f5 = new face(); f5.add(p4); f5.add(p3); f5.add(p6); shape.Add(f5);
            relationships.Add(5, new List<int>() { 3, 0, 5 });
            face f6 = new face(); f6.add(p4); f6.add(p1); f6.add(p6); shape.Add(f6);
            relationships.Add(6, new List<int>() { 4, 2, 5 });
            face f7 = new face(); f7.add(p5); f7.add(p3); f7.add(p6); shape.Add(f7);
            relationships.Add(7, new List<int>() { 4, 0, 5 });
            face f8 = new face(); f8.add(p5); f8.add(p1); f8.add(p6); shape.Add(f8);
        }

        private void build_dodecahedron()
        {
            double r = 100 * (3 + Math.Sqrt(5)) / 4;
            double x = 100 * (1 + Math.Sqrt(5)) / 4;
            points.Clear();
            my_point p1 = new my_point(0, -50, -r);
            my_point p2 = new my_point(0, 50, -r);
            my_point p3 = new my_point(x, x, -x);
            my_point p4 = new my_point(r, 0, -50);
            my_point p5 = new my_point(x, -x, -x);
            my_point p6 = new my_point(50, -r, 0);
            my_point p7 = new my_point(-50, -r, 0);
            my_point p8 = new my_point(-x, -x, -x);
            my_point p9 = new my_point(-r, 0, -50);
            my_point p10 = new my_point(-x, x, -x);
            my_point p11 = new my_point(-50, r, 0);
            my_point p12 = new my_point(50, r, 0);
            my_point p13 = new my_point(-x, -x, x);
            my_point p14 = new my_point(0, -50, r);
            my_point p15 = new my_point(x, -x, x);
            my_point p16 = new my_point(0, 50, r);
            my_point p17 = new my_point(-x, x, x);
            my_point p18 = new my_point(x, x, x);
            my_point p19 = new my_point(-r, 0, 50);
            my_point p20 = new my_point(r, 0, 50);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            points.Add(p6);
            points.Add(p7);
            points.Add(p8);
            points.Add(p9);
            points.Add(p10);
            points.Add(p11);
            points.Add(p12);
            points.Add(p13);
            points.Add(p14);
            points.Add(p15);
            points.Add(p16);
            points.Add(p17);
            points.Add(p18);
            points.Add(p19);
            points.Add(p20);
            shape.Clear();
            relationships.Clear();
            relationships.Add(0, new List<int>() { 0, 1, 2, 3, 4 });
            face f1 = new face(); f1.add(p1); f1.add(p2); f1.add(p3); f1.add(p4); f1.add(p5); shape.Add(f1);
            relationships.Add(1, new List<int>() { 0, 4, 5, 6, 7 });
            face f2 = new face(); f2.add(p1); f2.add(p5); f2.add(p6); f2.add(p7); f2.add(p8); shape.Add(f2);
            relationships.Add(2, new List<int>() { 0, 1, 9, 8, 7 });
            face f3 = new face(); f3.add(p1); f3.add(p2); f3.add(p10); f3.add(p9); f3.add(p8); shape.Add(f3);
            relationships.Add(3, new List<int>() { 1, 9, 10, 11, 2 });
            face f4 = new face(); f4.add(p2); f4.add(p10); f4.add(p11); f4.add(p12); f4.add(p3); shape.Add(f4);
            relationships.Add(4, new List<int>() { 3, 4, 5, 14, 19 });
            face f5 = new face(); f5.add(p4); f5.add(p5); f5.add(p6); f5.add(p15); f5.add(p20); shape.Add(f5);
            relationships.Add(5, new List<int>() { 3, 2, 11, 17, 19 });
            face f6 = new face(); f6.add(p4); f6.add(p3); f6.add(p12); f6.add(p18); f6.add(p20); shape.Add(f6);
            relationships.Add(6, new List<int>() { 8, 7, 6, 12, 18 });
            face f7 = new face(); f7.add(p9); f7.add(p8); f7.add(p7); f7.add(p13); f7.add(p19); shape.Add(f7);
            relationships.Add(7, new List<int>() { 8, 7, 6, 12, 18 });
            face f8 = new face(); f8.add(p9); f8.add(p10); f8.add(p11); f8.add(p17); f8.add(p19); shape.Add(f8);
            relationships.Add(8, new List<int>() { 8, 9, 10, 16, 18 });
            face f9 = new face(); f9.add(p11); f9.add(p12); f9.add(p18); f9.add(p16); f9.add(p17); shape.Add(f9);
            relationships.Add(9, new List<int>() { 6, 5, 14, 13, 12 });
            face f10 = new face(); f10.add(p7); f10.add(p6); f10.add(p15); f10.add(p14); f10.add(p13); shape.Add(f10);
            relationships.Add(10, new List<int>() { 18, 16, 15, 13, 12 });
            face f11 = new face(); f11.add(p19); f11.add(p17); f11.add(p16); f11.add(p14); f11.add(p13); shape.Add(f11);
            relationships.Add(11, new List<int>() { 15, 13, 14, 19, 17 });
            face f12 = new face(); f12.add(p16); f12.add(p14); f12.add(p15); f12.add(p20); f12.add(p18); shape.Add(f12);
        }

        private void build_icosahedron()
        {
            double r = 100 * (1 + Math.Sqrt(5)) / 4;
            my_point p1 = new my_point(0, -50, -r);
            my_point p2 = new my_point(0, 50, -r);
            my_point p3 = new my_point(50, r, 0);
            my_point p4 = new my_point(r, 0, -50);
            my_point p5 = new my_point(50, -r, 0);
            my_point p6 = new my_point(-50, -r, 0);
            my_point p7 = new my_point(-r, 0, -50);
            my_point p8 = new my_point(-50, r, 0);
            my_point p9 = new my_point(r, 0, 50);
            my_point p10 = new my_point(-r, 0, 50);
            my_point p11 = new my_point(0, -50, r);
            my_point p12 = new my_point(0, 50, r);
            shape.Clear();
            relationships.Clear();
            relationships.Add(0, new List<int>()); relationships[0].Add(0);
            relationships[0].Add(1); relationships[0].Add(3);
            face f1 = new face(); f1.add(p1); f1.add(p2); f1.add(p4); shape.Add(f1);
            relationships.Add(1, new List<int>()); relationships[1].Add(0);
            relationships[1].Add(1); relationships[1].Add(6);
            face f2 = new face(); f2.add(p1); f2.add(p2); f2.add(p7); shape.Add(f2);
            relationships.Add(2, new List<int>()); relationships[2].Add(6);
            relationships[2].Add(1); relationships[2].Add(7);
            face f3 = new face(); f3.add(p7); f3.add(p2); f3.add(p8); shape.Add(f3);
            relationships.Add(3, new List<int>()); relationships[3].Add(7);
            relationships[3].Add(1); relationships[3].Add(2);
            face f4 = new face(); f4.add(p8); f4.add(p2); f4.add(p3); shape.Add(f4);
            relationships.Add(4, new List<int>()); relationships[4].Add(3);
            relationships[4].Add(1); relationships[4].Add(2);
            face f5 = new face(); f5.add(p4); f5.add(p2); f5.add(p3); shape.Add(f5);
            relationships.Add(5, new List<int>()); relationships[5].Add(5);
            relationships[5].Add(0); relationships[5].Add(4);
            face f6 = new face(); f6.add(p6); f6.add(p1); f6.add(p5); shape.Add(f6);
            relationships.Add(6, new List<int>()); relationships[6].Add(5);
            relationships[6].Add(9); relationships[6].Add(6);
            face f7 = new face(); f7.add(p6); f7.add(p7); f7.add(p10); shape.Add(f7);
            relationships.Add(7, new List<int>()); relationships[7].Add(9);
            relationships[7].Add(6); relationships[7].Add(7);
            face f8 = new face(); f8.add(p10); f8.add(p7); f8.add(p8); shape.Add(f8);
            relationships.Add(8, new List<int>()); relationships[8].Add(9);
            relationships[8].Add(7); relationships[8].Add(11);
            face f9 = new face(); f9.add(p10); f9.add(p8); f9.add(p12); shape.Add(f9);
            relationships.Add(9, new List<int>()); relationships[9].Add(11);
            relationships[9].Add(7); relationships[9].Add(2);
            face f10 = new face(); f10.add(p12); f10.add(p8); f10.add(p3); shape.Add(f10);
            relationships.Add(10, new List<int>()); relationships[10].Add(8);
            relationships[10].Add(3); relationships[10].Add(2);
            face f11 = new face(); f11.add(p9); f11.add(p4); f11.add(p3); shape.Add(f11);
            relationships.Add(11, new List<int>()); relationships[11].Add(4);
            relationships[11].Add(3); relationships[11].Add(8);
            face f12 = new face(); f12.add(p5); f12.add(p4); f12.add(p9); shape.Add(f12);
            relationships.Add(12, new List<int>()); relationships[12].Add(11);
            relationships[12].Add(2); relationships[12].Add(8);
            face f13 = new face(); f13.add(p12); f13.add(p3); f13.add(p9); shape.Add(f13);
            relationships.Add(13, new List<int>()); relationships[13].Add(4);
            relationships[13].Add(0); relationships[13].Add(3);
            face f14 = new face(); f14.add(p5); f14.add(p1); f14.add(p4); shape.Add(f14);
            relationships.Add(14, new List<int>()); relationships[14].Add(6);
            relationships[14].Add(0); relationships[14].Add(5);
            face f15 = new face(); f15.add(p7); f15.add(p1); f15.add(p6); shape.Add(f15);
            relationships.Add(15, new List<int>()); relationships[15].Add(10);
            relationships[15].Add(4); relationships[15].Add(5);
            face f16 = new face(); f16.add(p11); f16.add(p5); f16.add(p6); shape.Add(f16);
            relationships.Add(16, new List<int>()); relationships[16].Add(10);
            relationships[16].Add(5); relationships[16].Add(9);
            face f17 = new face(); f17.add(p11); f17.add(p6); f17.add(p10); shape.Add(f17);
            relationships.Add(17, new List<int>()); relationships[17].Add(10);
            relationships[17].Add(9); relationships[17].Add(11);
            face f18 = new face(); f18.add(p11); f18.add(p10); f18.add(p12); shape.Add(f18);
            relationships.Add(18, new List<int>()); relationships[18].Add(10);
            relationships[18].Add(11); relationships[18].Add(8);
            face f19 = new face(); f19.add(p11); f19.add(p12); f19.add(p9); shape.Add(f19);
            relationships.Add(19, new List<int>()); relationships[19].Add(10);
            relationships[19].Add(4); relationships[19].Add(8);
            face f20 = new face(); f20.add(p11); f20.add(p5); f20.add(p9); shape.Add(f20);
        }

        private void build_rotation_figure()
        {
            int cntr = 0;
            int cntrpt = 0;
            my_point pt1 = new my_point((double)axis_1st_X.Value, (double)axis_1st_Y.Value, (double)axis_1st_Z.Value);
            my_point pt2 = new my_point((double)axis_2st_X.Value, (double)axis_2st_Y.Value, (double)axis_2st_Z.Value);
            my_point c = normalize_vector(pt1, pt2);
            int rot = (int)(360 / dividence_count.Value);
            List<List<my_point>> transformed = new List<List<my_point>>();
            transformed.Add(this.Copy(initial_points));

            points.Clear();
            shape.Clear();
            relationships.Clear();

            for (int i = 1; i < dividence_count.Value; i++)
                transformed.Add(matr.get_transformed_my_points_nobr(matr.matrix_rotate_general(c.X, c.Y, c.Z, rot * i), initial_points));

            int ctr_depth = 0;
            if ((dividence_count.Value >= 3) && (initial_points.Count >= 2))
            {
                face tmp = new face();
                relationships.Add(cntr, new List<int>());

                foreach (var item in transformed)
                {
                    relationships[cntr].Add(cntrpt);
                    cntrpt += 1;
                    points.Add(item[ctr_depth]);
                    tmp.add(item[ctr_depth]);
                }

                shape.Add(tmp);
                cntr += 1;
                ctr_depth += 1;
                while (ctr_depth < initial_points.Count)
                {
                    for (int i = 0; i < dividence_count.Value - 1; i++)
                    {
                        relationships.Add(cntr, new List<int>());
                        points.Add(transformed[i][ctr_depth]);
                        face t2 = new face();

                        relationships[cntr].Add(cntrpt - (int)dividence_count.Value);
                        relationships[cntr].Add(cntrpt);
                        relationships[cntr].Add(cntrpt + 1);
                        relationships[cntr].Add(cntrpt - (int)dividence_count.Value + 1);

                        t2.add(transformed[i][ctr_depth - 1]);
                        t2.add(transformed[i][ctr_depth]);
                        t2.add(transformed[i + 1][ctr_depth]);
                        t2.add(transformed[i + 1][ctr_depth - 1]);

                        shape.Add(t2);
                        cntr += 1;
                        cntrpt += 1;
                    }

                    points.Add(transformed[(int)dividence_count.Value - 1][ctr_depth]);
                    face t = new face();

                    relationships.Add(cntr, new List<int>());
                    relationships[cntr].Add(cntrpt - (int)dividence_count.Value);
                    relationships[cntr].Add(cntrpt);
                    relationships[cntr].Add(cntrpt - (int)dividence_count.Value + 1);
                    relationships[cntr].Add(cntrpt - 2 * (int)dividence_count.Value + 1);

                    t.add(transformed[(int)(dividence_count.Value - 1)][ctr_depth - 1]);
                    t.add(transformed[(int)(dividence_count.Value - 1)][ctr_depth]);
                    t.add(transformed[0][ctr_depth]);
                    t.add(transformed[0][ctr_depth - 1]);

                    shape.Add(t);
                    ctr_depth += 1;
                    cntr += 1;
                    cntrpt += 1;
                }

                relationships.Add(cntr, new List<int>());
                face tmp2 = new face();

                foreach (var item in transformed)
                {
                    relationships[cntr].Add(cntrpt - (int)dividence_count.Value);
                    cntrpt++;
                    tmp2.add(item[initial_points.Count - 1]);
                }
                shape.Add(tmp2);
            }
            redraw_image();
        }

        private void shape_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            if ((sender as RadioButton).Checked == false)
                return;

            shape.Clear();
            if (tetrahedron.Checked)
            {
                build_tetrahedron();
                build_points();
                redraw_image();
            }
            else if (hexahedron.Checked)
            { 
                build_hexahedron();
                build_points();
                redraw_image();
            }
            else if (octahedron.Checked)
            { 
                build_octahedron();
                build_points();
                redraw_image();
            }
            else if (dodecahedron.Checked)
            { 
                build_dodecahedron();
                build_points();
                redraw_image();
            }
            else if (icosahedron.Checked)
            { 
                build_icosahedron();
                build_points();
                redraw_image();
            }
            else if (rotation_figure.Checked)
                groupBox1.Show();
        }
    }
}




/*
         // поворот вокруг оси
        private void axis_rotate(my_point pt1, my_point pt2, double angle)
        {
            my_point c = normalize_vector(pt1, pt2);
            matr.matrix_projection_xy();
            points = matr.get_transformed_my_points(matr.matrix_rotate_general(c.X, c.Y, c.Z, angle), points);         
        } 
 */