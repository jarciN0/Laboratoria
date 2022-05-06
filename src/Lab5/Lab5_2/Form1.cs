using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_2
{
    public partial class Form1 : Form
    {
        private int szer = 0;
        private int wys = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k;
            int r, g, b;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    r = k.R;
                    g = k.G;
                    b = k.B;
                    k = Color.FromArgb(255 - r, 255 - g, 255 - b);
                    b2.SetPixel(x, y, k);

                }
            }
            pictureBox2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k;
            int r, g, b;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    r = k.R;
                    g = k.G;
                    b = k.B;
                    if (r + trackBar1.Value < 255)
                        r += trackBar1.Value;
                    else
                        r = 255;

                    if (g + trackBar1.Value < 255)
                        g += trackBar1.Value;
                    else
                        g = 255;

                    if (b + trackBar1.Value < 255)
                        b += trackBar1.Value;
                    else
                        b = 255;

                    k = Color.FromArgb(r, g, b);
                    b2.SetPixel(x, y, k);
                }
            }
            pictureBox2.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k;
            int r, g, b;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    r = k.R;
                    g = k.G;
                    b = k.B;
                    if (r - trackBar2.Value > 0)
                        r -= trackBar2.Value;
                    else
                        r = 0;

                    if (g - trackBar2.Value > 0)
                        g -= trackBar2.Value;
                    else
                        g = 0;

                    if (b - trackBar2.Value > 0)
                        b -= trackBar2.Value;
                    else
                        b = 0;

                    k = Color.FromArgb(r, g, b);
                    b2.SetPixel(x, y, k);
                }
            }
            pictureBox2.Refresh();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(trackBar3.Value) / 10;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k;
            double r, g, b;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    r = Math.Pow(k.R / 255.0, 1 / n) * 255.0;
                    g = Math.Pow(k.G / 255.0, 1 / n) * 255.0;
                    b = Math.Pow(k.B / 255.0, 1 / n) * 255.0;
                    k = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    b2.SetPixel(x, y, k);
                }
            }
            label2.Text = Convert.ToString(n);
            pictureBox2.Refresh();
        }

    }
}