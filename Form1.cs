using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starfield
{
    public partial class Form1 : Form
    {

        class Star
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
        }

        private  Star[] stars = new Star[15000];
        private Random rnd = new Random();
        private Graphics grp; //GDI

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            grp.Clear(Color.Black); // очищаем окно и красим в черный
            foreach (Star star in stars)
            {
                Draw_star(star);
                Mode_star(star);
            }
            pictureBox1.Refresh(); // обновляем бокс
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Mode_star(Star star)
        {
            star.z -= 100;
            if (star.z < 1)
            {
                star.x = rnd.Next(-pictureBox1.Width, pictureBox1.Width);
                star.y = rnd.Next(-pictureBox1.Height, pictureBox1.Height);
                star.z = rnd.Next(1, pictureBox1.Width);
            }
               
        }

        private void Draw_star(Star star)
        {
            float s_size = map(star.z, 0, pictureBox1.Width, 10, 0);
            float x = map(star.x / star.z, 0, 1, 0, pictureBox1.Width) + pictureBox1.Width / 2;
            float y = map(star.y / star.z, 0, 1, 0, pictureBox1.Height) + pictureBox1.Height / 2;
            grp.FillEllipse(Brushes.GreenYellow, x, y, s_size, s_size);
        }

        private float map(float n, float start1, float stop1, float start2, float stop2)
        {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(pictureBox1.Image);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star()
                {
                    x = rnd.Next(-pictureBox1.Width, pictureBox1.Width),
                    y = rnd.Next(-pictureBox1.Height, pictureBox1.Height),
                    z = rnd.Next(1, pictureBox1.Width)
                };
            }
            timer1.Start();
        }
    }
}
