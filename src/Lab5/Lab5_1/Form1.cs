using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_1
{
    public partial class Form1 : Form
    {

        private int szer = 0;
        private int wys = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Load(openFileDialog1.FileName);
                if (szer > pictureBox2.Image.Width)
                    szer = pictureBox2.Image.Width;
                if (wys > pictureBox2.Image.Height)
                    wys = pictureBox2.Image.Height;

                pictureBox3.Image = new Bitmap(szer, wys);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r1 + r2 < 255)
                        r = r1 + r2;
                    else
                        r = 255;

                    if (g1 + g2 < 255)
                        g = g1 + g2;
                    else
                        g = 255;

                    if (b1 + b2 < 255)
                        b = b1 + b2;
                    else
                        b = 255;
                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r1 + r2 - 255 > 0)
                        r = r1 + r2 - 255;
                    else
                        r = 0;

                    if (g1 + g2 - 255 > 0)
                        g = g1 + g2 - 255;
                    else
                        g = 0;

                    if (b1 + b2 - 255 > 0)
                        b = b1 + b2 - 255;
                    else
                        b = 0;
                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r1 > r2)
                        r = r1 - r2;
                    else
                        r = r2 - r1;

                    if (g1 > g2)
                        g = g1 - g2;
                    else
                        g = g2 - g1;

                    if (b1 > b2)
                        b = b1 - b2;
                    else
                        b = b2 - b1;
                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    r = (r1 * r2) / 255;

                    g = (g1 * g2) / 255;
                                       
                    b = (b1 * b2) / 255;

                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    r = 255 - ((255 - r1) * (255 - r2)) / 255;
                    g = 255 - ((255 - g1) * (255 - g2)) / 255;
                    b = 255 - ((255 - b1) * (255 - b2)) / 255;

                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    r = 255 - Math.Abs(255 - r1 - r2);

                    g = 255 - Math.Abs(255 - g1 - g2);

                    b = 255 - Math.Abs(255 - g1 - g2);
                    
                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r1 < r2)
                        r = r1;
                    else
                        r = r2;

                    if (g1 < g2)
                        g = g1;
                    else
                        g = g2;

                    if (b1 < b2)
                        b = b1;
                    else
                        b = b2;

                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r1 > r2)
                        r = r1;
                    else
                        r = r2;

                    if (g1 > g2)
                        g = g1;
                    else
                        g = g2;

                    if (b1 > b2)
                        b = b1;
                    else
                        b = b2;

                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    r = r1 + r2 - ((510 * r1 * r2) / 255) / 510;
                    
                    g = g1 + g2 - ((510 * g1 * g2) /255) / 510;

                    b = b1 + b2 - ((510 * b1 * b2) /255) / 510;

                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r1 < 256 / 2)
                        r = ((510 * r1 * r2) / 255) / 510;
                    else
                        r = 255 - ((510 * (255 - r1)) / 255) * ((255 - r2) / 255);

                    if (g1 < 256 / 2)
                        g = ((510 * g1 * g2) / 255) / 510;
                    else
                        g = 255 - ((510 * (255 - g1)) / 255) * ((255 - g2) / 255);

                    if (b1 < 256 / 2)
                        b = ((510 * b1 * b2) / 255) / 510;
                    else
                        b = 255 - ((510 * (255 - b1)) / 255) * ((255 - b2) / 255);

                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r2 < 256 / 2)
                        r = ((510 * r1 * r2) / 255) / 510;
                    else
                        r = 255 - ((510 * (255 - r1)) / 255) * ((255 - r2) / 255);

                    if (g2 < 256 / 2)
                        g = ((510 * g1 * g2) / 255) / 510;
                    else
                        g = 255 - ((510 * (255 - g1)) / 255) * ((255 - g2) / 255);

                    if (b2 < 256 / 2)
                        b = ((510 * b1 * b2) / 255) / 510;
                    else
                        b = 255 - ((510 * (255 - b1)) / 255) * ((255 - b2) / 255);

                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            double r, g, b;
            double r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r2 < 256 / 2)
                        r = (((510 * r1 * r2) / 255) / 510) + ((Math.Pow(r1, 2) / 255) * ((255 - (510 * r2) / 510)) / 255);
                    else
                        r = (Math.Sqrt(r1) * ((510 * r2 - 255) / 510) / 255) + (((510 * r1) / 510) * (255 - r2)) / 255;

                    if (g2 < 256 / 2)
                        g = (((510 * g1 * g2) / 255) / 510) + ((Math.Pow(g1, 2) / 255) * ((255 - (510 * g2) / 510)) / 255);
                    else
                        g = (Math.Sqrt(g1) * ((510 * g2 - 255) / 510) / 255) + (((510 * g1) / 510) * (255 - g2)) / 255;

                    if (b2 < 256 / 2)
                        b = (((510 * b1 * b2) / 255) / 510) + ((Math.Pow(b1, 2) / 255) * ((255 - (510 * b2) / 510)) / 255);
                    else
                        b = (Math.Sqrt(b1) * ((510 * b2 - 255) / 510) / 255) + (((510 * b1) / 510) * (255 - b2)) / 255;

                    k = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            double r, g, b;
            double r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r2 != 255)
                        r = r1 / (255 - r2);
                    else
                        r = r1;

                    if (g2 != 255)
                        g = g1 / (255 - g2);
                    else
                        g = g1;

                    if (b2 != 255)
                        b = b1 / (255 - b2);
                    else
                        b = b1;

                    if (r < 1)
                        r *= 255;

                    if (g < 1)
                        g *= 255;

                    if (b < 1)
                        b *= 255;
                    k = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            double r, g, b;
            double r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r2 != 0)
                        r = 255 - ((255 - r1) / r2);
                    else
                        r = 255 - (255 - r1);
                    
                    if (g2 != 0)
                        g = 255 - ((255 - g1) / g2);
                    else
                        g = 255 - (255 - g1);

                    if (b2 != 0)
                        b = 255 - ((255 - b1) / b2);
                    else
                        b = 255 - (255 - b1);

                    if (r < 1)
                        r *= 255;

                    if (g < 1)
                        g *= 255;
                    if (b < 1)
                        b *= 255;
                    k = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            double r, g, b;
            double r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    if (r2 != 255)
                        r = Math.Pow(r1, 2) / 255 / (255 - r2);
                    else
                        r = Math.Pow(r1, 2) / 255;

                    if (g2 != 255)
                        g = Math.Pow(g1, 2) / 255 / (255 - g2);
                    else
                        g = Math.Pow(g1, 2) / 255;

                    if (b2 != 255)
                        b = Math.Pow(b1, 2) / 255 / (255 - b2);
                    else
                        b = Math.Pow(b1, 2) / 255;

                    if (r < 1)
                        r *= 255;

                    if (g < 1)
                        g *= 255;

                    if (b < 1)
                        b *= 255;
                    k = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Bitmap bit1 = (Bitmap)pictureBox1.Image;
            Bitmap bit2 = (Bitmap)pictureBox2.Image;
            Bitmap bit3 = (Bitmap)pictureBox3.Image;
            Color k;
            int r, g, b;
            int r1, g1, b1, r2, g2, b2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = bit1.GetPixel(x, y);
                    r1 = k.R;
                    g1 = k.G;
                    b1 = k.B;

                    k = bit2.GetPixel(x, y);
                    r2 = k.R;
                    g2 = k.G;
                    b2 = k.B;

                    r = 0;
                    g = 0;
                    b = 0;

                    r = (((255 - trackBar1.Value) * r2) >> 8) + ((trackBar1.Value * r1) >> 8);

                    g = (((255 - trackBar1.Value) * g2) >> 8) + ((trackBar1.Value * g1) >> 8);

                    b = (((255 - trackBar1.Value) * b2) >> 8) + ((trackBar1.Value * b1) >> 8);

                    k = Color.FromArgb(r, g, b);
                    bit3.SetPixel(x, y, k);

                }
            }
            pictureBox3.Refresh();
        }
    }
}
