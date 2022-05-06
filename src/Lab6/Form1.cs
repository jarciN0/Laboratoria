using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
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
    

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            int[] r = new int[256];
            int[] g = new int[256];
            int[] b = new int[256];
            Color k;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    r[k.R]++;
                    g[k.G]++;
                    b[k.B]++;
                }
            }
            chart1.Series["red"].Points.Clear();
            chart1.Series["green"].Points.Clear();
            chart1.Series["blue"].Points.Clear();
            for (int i = 0; i < 256; i++)
            {
                chart1.Series["red"].Points.AddXY(i, r[i]);
                chart1.Series["green"].Points.AddXY(i, g[i]);
                chart1.Series["blue"].Points.AddXY(i, b[i]);
            }
            chart1.Invalidate();
        }

        private int[] LUT(int[] wartosci, int wymiar)
        {
            double min = 0;
            for (int i = 0; i < 256; i++)
            {
                if (wartosci[i] != 0)
                {
                    min = wartosci[i];
                    break;
                }
            }

            int[] wynik = new int[256];
            double sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += wartosci[i];
                wynik[i] = (int)(((sum - min) / (wymiar - min)) * 255.0);
            }

            return wynik;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int[] r = new int[256];
            int[] g = new int[256];
            int[] b = new int[256];
            Color k, pixel, pixel2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    r[k.R]++;
                    g[k.G]++;
                    b[k.B]++;
                }
            }
            int[] LUTr = LUT(r, szer * wys);
            int[] LUTg = LUT(g, szer * wys);
            int[] LUTb = LUT(b, szer * wys);

            r = new int[256];
            g = new int[256];
            b = new int[256];

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    pixel = b1.GetPixel(x, y);
                    pixel2 = Color.FromArgb(LUTr[pixel.R], LUTg[pixel.G], LUTb[pixel.B]);
                    b2.SetPixel(x, y, pixel2);
                    r[pixel2.R]++;
                    g[pixel2.G]++;
                    b[pixel2.B]++;
                }
            }
            pictureBox2.Refresh();

            chart2.Series["red"].Points.Clear();
            chart2.Series["green"].Points.Clear();
            chart2.Series["blue"].Points.Clear();
            for (int i = 0; i < 256; i++)
            {
                chart2.Series["red"].Points.AddXY(i, r[i]);
                chart2.Series["green"].Points.AddXY(i, g[i]);
                chart2.Series["blue"].Points.AddXY(i, b[i]);
            }
            chart2.Invalidate();
        }

        private int[] calculateLUT(int[] wartosci)
        {
            int min = 0;
            for (int i = 0; i < 256; i++)
            {
                if (wartosci[i] != 0)
                {
                    min = i;
                    break;
                }
            }

            int max = 255;
            for (int i = 255; i >= 0; i--)
            {
                if (wartosci[i] != 0)
                {
                    max = i;
                    break;
                }
            }

            int[] wynik = new int[256];
            double a = 255.0 / (max - min);
            for (int i = 0; i < 256; i++)
            {
                wynik[i] = (int)(a * (i - min));
            }

            return wynik;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int[] r = new int[256];
            int[] g = new int[256];
            int[] b = new int[256];
            Color k, pixel, pixel2;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    r[k.R]++;
                    g[k.G]++;
                    b[k.B]++;
                }
            }
            int[] LUTr = calculateLUT(r);
            int[] LUTg = calculateLUT(g);
            int[] LUTb = calculateLUT(b);

            r = new int[256];
            g = new int[256];
            b = new int[256];

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    pixel = b1.GetPixel(x, y);
                    pixel2 = Color.FromArgb(LUTr[pixel.R], LUTg[pixel.G], LUTb[pixel.B]);
                    b2.SetPixel(x, y, pixel2);
                    r[pixel2.R]++;
                    g[pixel2.G]++;
                    b[pixel2.B]++;
                }
            }
            pictureBox2.Refresh();

            chart2.Series["red"].Points.Clear();
            chart2.Series["green"].Points.Clear();
            chart2.Series["blue"].Points.Clear();
            for (int i = 0; i < 256; i++)
            {
                chart2.Series["red"].Points.AddXY(i, r[i]);
                chart2.Series["green"].Points.AddXY(i, g[i]);
                chart2.Series["blue"].Points.AddXY(i, b[i]);
            }
            chart2.Invalidate();
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
                    k = Color.FromArgb(k.R, k.G, k.B);
                    b2.SetPixel(x, y, k);
                }
            }
            pictureBox2.Refresh();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double c = Convert.ToDouble(trackBar2.Value);
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k;
            double r, g, b;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    if (c >= 0)
                    {
                        r = 127.0 / (127.0 - c) * (k.R - c);
                        g = 127.0 / (127.0 - c) * (k.G - c);
                        b = 127.0 / (127.0 - c) * (k.B - c);
                    }
                    else
                    {
                        r = (127.0 + c) / 127.0 * (k.R - c);
                        g = (127.0 + c) / 127.0 * (k.G - c);
                        b = (127.0 + c) / 127.0 * (k.B - c);
                    }
                    if (r > 255.0)
                        r = 255.0;
                    if (g > 255.0)
                        g = 255.0;
                    if (b > 255.0)
                        b = 255.0;
                    if (r < 0.0)
                        r = 0.0;
                    if (g < 0.0)
                        g = 0.0;
                    if (b < 0.0)
                        b = 0.0;

                    k = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    b2.SetPixel(x, y, k);
                }
            }
            label4.Text = Convert.ToString(c);
            pictureBox2.Refresh();

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double c = Convert.ToDouble(trackBar3.Value);
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k;
            double r, g, b;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    k = b1.GetPixel(x, y);
                    if (c >= 0)
                    {
                        if (k.R < 127.0)
                            r = ((127.0 - c) / 127.0) * k.R;
                        else
                            r = ((127.0 - c) / 127.0) * k.R + (2.0 * c);
                        if (k.G < 127.0)
                            g = ((127.0 - c) / 127.0) * k.G;
                        else
                            g = ((127.0 - c) / 127.0) * k.G + (2.0 * c);
                        if (k.B < 127.0)
                            b = ((127.0 - c) / 127.0) * k.B;
                        else
                            b = ((127.0 - c) / 127.0) * k.B + (2.0 * c);
                    }
                    else
                    {
                        if (k.R < 127.0 + c)
                            r = (127.0 / (127.0 + c)) * k.R;
                        else if (k.R > 127.0 - c)
                            r = ((127.0 * k.R) + (255.0 * c)) / (127.0 + c);
                        else
                            r = 127.0;
                        if (k.G < 127.0 + c)
                            g = (127.0 / (127.0 + c)) * k.G;
                        else if (k.G > 127.0 - c)
                            g = ((127.0 * k.G) + (255.0 * c)) / (127.0 + c);
                        else
                            g = 127.0;
                        if (k.B < 127.0 + c)
                            b = (127.0 / (127.0 + c)) * k.B;
                        else if (k.B > 127.0 - c)
                            b = ((127.0 * k.B) + (255.0 * c)) / (127.0 + c);
                        else
                            b = 127.0;
                    }
                    if (r > 255.0)
                        r = 255.0;
                    if (g > 255.0)
                        g = 255.0;
                    if (b > 255.0)
                        b = 255.0;
                    if (r < 0.0)
                        r = 0.0;
                    if (g < 0.0)
                        g = 0.0;
                    if (b < 0.0)
                        b = 0.0;
                    k = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    b2.SetPixel(x, y, k);
                }
            }
            label6.Text = Convert.ToString(c);
            pictureBox2.Refresh();
        }

    } 

}
