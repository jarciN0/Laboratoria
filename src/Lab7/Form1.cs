using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {

        private int[,] maska = new int[3,3];
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
                pictureBox2.Image = new Bitmap(szer, wys);
            }
        }

        private void przetworz(int[,] maska, int suma_maski)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color[,] k = new Color[3, 3];
            int r = 0;
            int g = 0;
            int b = 0;
            int x_mniej, x_wiecej, y_mniej, y_wiecej;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {

                    if (x == 0)
                    {
                        x_mniej = x;
                    }
                    else
                    {
                        x_mniej = x - 1;
                    }

                    if (x == szer - 1)
                    {
                        x_wiecej = x;
                    }
                    else
                    {
                        x_wiecej = x + 1;
                    }

                    if (y == 0)
                    {
                        y_mniej = y;
                    }
                    else
                    {
                        y_mniej = y - 1;
                    }

                    if (y == wys - 1)
                    {
                        y_wiecej = y;
                    }
                    else
                    {
                        y_wiecej = y + 1;
                    }

                    k[0, 0] = b1.GetPixel(x_mniej, y_mniej);
                    k[0, 1] = b1.GetPixel(x, y_mniej);
                    k[0, 2] = b1.GetPixel(x_wiecej, y_mniej);
                    k[1, 0] = b1.GetPixel(x_mniej, y);
                    k[1, 1] = b1.GetPixel(x, y);
                    k[1, 2] = b1.GetPixel(x_wiecej, y);
                    k[2, 0] = b1.GetPixel(x_mniej, y_wiecej);
                    k[2, 1] = b1.GetPixel(x, y_wiecej);
                    k[2, 2] = b1.GetPixel(x_wiecej, y_wiecej);

                    r = 0;
                    g = 0;
                    b = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            r += k[i, j].R * maska[i, j];
                            g += k[i, j].G * maska[i, j];
                            b += k[i, j].B * maska[i, j];

                        }
                    }

                    if (suma_maski != 0)
                    {
                        r = r / suma_maski;
                        g = g / suma_maski;
                        b = b / suma_maski;
                    }


                    if (r > 255)
                    {
                        r = 255;
                    }
                    if (r < 0)
                    {
                        r = 0;
                    }

                    if (g > 255)
                    {
                        g = 255;
                    }
                    if (g < 0)
                    {
                        g = 0;
                    }

                    if (b > 255)
                    {
                        b = 255;
                    }
                    if (b < 0)
                    {
                        b = 0;
                    }

                    b2.SetPixel(x, y, Color.FromArgb(r, g, b));

                }
            }
            pictureBox2.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    maska[i, j] = 0;
            }
            maska[1, 1] = 1;
            maska[1, 2] = -1;
            int suma_maski = 0;
            przetworz(maska, suma_maski);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                        maska[i, j] = 1;
                    else if (i == 1)
                        maska[i, j] = 0;
                    else
                        maska[i, j] = -1;
                }
            }
            int suma_maski = 0;
            przetworz(maska, suma_maski);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0 && j != 1)
                        maska[i, j] = 1;
                    else if (i == 1)
                        maska[i, j] = 0;
                    else if (i == 2 && j != 1)
                        maska[i, j] = -1;
                }
            }
            maska[0, 1] = 2;
            maska[2, 1] = -2;
            int suma_maski = 0;
            przetworz(maska, suma_maski);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    maska[i, j] = 0;
            }
            maska[1, 1] = 1;
            maska[2, 1] = -1;
            int suma_maski = 0;
            przetworz(maska, suma_maski);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                        maska[i, j] = 1;
                    else if (j == 1)
                        maska[i, j] = 0;
                    else
                        maska[i, j] = -1;
                }
            }
            int suma_maski = 0;
            przetworz(maska, suma_maski);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        if (i != 1)
                            maska[i, j] = 1;
                        else
                            maska[i, j] = 2;
                    }
                    else if (j == 1)
                    {
                        maska[i, j] = 0;
                    }
                    else
                    {
                        if (i != 1)
                            maska[i, j] = -1;
                        else
                            maska[i, j] = -2;
                    }
                }
            }
            int suma_maski = 0;
            przetworz(maska, suma_maski);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != 1 && j != 1)
                        maska[i, j] = 0;
                    else
                        maska[i, j] = -1;
                }
            }
            maska[1, 1] = 4;
            int suma_maski = 0;

            przetworz(maska, suma_maski);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color[,] k = new Color[3, 3];
            int rmin;
            int gmin;
            int bmin;
            int x_mniej, x_wiecej, y_mniej, y_wiecej;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {

                    if (x == 0)
                    {
                        x_mniej = x;
                    }
                    else
                    {
                        x_mniej = x - 1;
                    }

                    if (x == szer - 1)
                    {
                        x_wiecej = x;
                    }
                    else
                    {
                        x_wiecej = x + 1;
                    }

                    if (y == 0)
                    {
                        y_mniej = y;
                    }
                    else
                    {
                        y_mniej = y - 1;
                    }

                    if (y == wys - 1)
                    {
                        y_wiecej = y;
                    }
                    else
                    {
                        y_wiecej = y + 1;
                    }

                    k[0, 0] = b1.GetPixel(x_mniej, y_mniej);
                    k[0, 1] = b1.GetPixel(x, y_mniej);
                    k[0, 2] = b1.GetPixel(x_wiecej, y_mniej);
                    k[1, 0] = b1.GetPixel(x_mniej, y);
                    k[1, 1] = b1.GetPixel(x, y);
                    k[1, 2] = b1.GetPixel(x_wiecej, y);
                    k[2, 0] = b1.GetPixel(x_mniej, y_wiecej);
                    k[2, 1] = b1.GetPixel(x, y_wiecej);
                    k[2, 2] = b1.GetPixel(x_wiecej, y_wiecej);
                    rmin = 255;
                    gmin = 255;
                    bmin = 255;

                    for (int l = 0; l < 3; l++)
                    {
                        for (int h = 1; h < 3; h++)
                        {
                            if (rmin > k[l, h].R)
                                rmin = k[l, h].R;
                            if (gmin > k[l, h].G)
                                gmin = k[l, h].G;
                            if (bmin > k[l, h].B)
                                bmin = k[l, h].B;
                        }
                    }


                    b2.SetPixel(x, y, Color.FromArgb(rmin, gmin, bmin));

                }
            }
            pictureBox2.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color[,] k = new Color[3, 3];
            int rmax;
            int gmax;
            int bmax;
            int x_mniej, x_wiecej, y_mniej, y_wiecej;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {

                    if (x == 0)
                    {
                        x_mniej = x;
                    }
                    else
                    {
                        x_mniej = x - 1;
                    }

                    if (x == szer - 1)
                    {
                        x_wiecej = x;
                    }
                    else
                    {
                        x_wiecej = x + 1;
                    }

                    if (y == 0)
                    {
                        y_mniej = y;
                    }
                    else
                    {
                        y_mniej = y - 1;
                    }

                    if (y == wys - 1)
                    {
                        y_wiecej = y;
                    }
                    else
                    {
                        y_wiecej = y + 1;
                    }

                    k[0, 0] = b1.GetPixel(x_mniej, y_mniej);
                    k[0, 1] = b1.GetPixel(x, y_mniej);
                    k[0, 2] = b1.GetPixel(x_wiecej, y_mniej);
                    k[1, 0] = b1.GetPixel(x_mniej, y);
                    k[1, 1] = b1.GetPixel(x, y);
                    k[1, 2] = b1.GetPixel(x_wiecej, y);
                    k[2, 0] = b1.GetPixel(x_mniej, y_wiecej);
                    k[2, 1] = b1.GetPixel(x, y_wiecej);
                    k[2, 2] = b1.GetPixel(x_wiecej, y_wiecej);
                    rmax = 0;
                    gmax = 0;
                    bmax = 0;

                    for (int l = 0; l < 3; l++)
                    {
                        for (int h = 1; h < 3; h++)
                        {
                            if (rmax < k[l, h].R)
                                rmax = k[l, h].R;
                            if (gmax < k[l, h].G)
                                gmax = k[l, h].G;
                            if (bmax < k[l, h].B)
                                bmax = k[l, h].B;
                        }
                    }


                    b2.SetPixel(x, y, Color.FromArgb(rmax, gmax, bmax));

                }
            }
            pictureBox2.Refresh();
        }

        //dla algorytmu Hoar'e - obliczanie mediany
        private int Partition(int[] c, int a, int b)
        {
            int e, tmp;
            e = c[a];        //elemennt dzielacy
            while (a < b)
            {
                while ((a < b) && (c[b] >= e)) b--;
                while ((a < b) && (c[a] < e)) a++;
                if (a < b)
                {
                    tmp = c[a];
                    c[a] = c[b];
                    c[b] = tmp;
                }
            }
            return a;
        }

        //algorytmu Hoar'e - obliczanie mediany
        private int Med(int[] c, int size)
        {
            //algorytm Hoare'a
            int i = 0;
            int j = size - 1;
            int w = j / 2;
            int k;
            while (i != j)
            {
                k = Partition(c, i, j);
                k = k - i + 1;
                if (k >= w)
                    j = i + k - 1;
                if (k < w)
                {
                    w -= k;
                    i += k;
                }
            }
            return c[i];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color[,] k = new Color[3, 3];
            int[] r = new int[9];
            int[] g = new int[9];
            int[] b = new int[9];
            int x_mniej, x_wiecej, y_mniej, y_wiecej;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {

                    if (x == 0)
                    {
                        x_mniej = x;
                    }
                    else
                    {
                        x_mniej = x - 1;
                    }

                    if (x == szer - 1)
                    {
                        x_wiecej = x;
                    }
                    else
                    {
                        x_wiecej = x + 1;
                    }

                    if (y == 0)
                    {
                        y_mniej = y;
                    }
                    else
                    {
                        y_mniej = y - 1;
                    }

                    if (y == wys - 1)
                    {
                        y_wiecej = y;
                    }
                    else
                    {
                        y_wiecej = y + 1;
                    }

                    k[0, 0] = b1.GetPixel(x_mniej, y_mniej);
                    k[0, 1] = b1.GetPixel(x, y_mniej);
                    k[0, 2] = b1.GetPixel(x_wiecej, y_mniej);
                    k[1, 0] = b1.GetPixel(x_mniej, y);
                    k[1, 1] = b1.GetPixel(x, y);
                    k[1, 2] = b1.GetPixel(x_wiecej, y);
                    k[2, 0] = b1.GetPixel(x_mniej, y_wiecej);
                    k[2, 1] = b1.GetPixel(x, y_wiecej);
                    k[2, 2] = b1.GetPixel(x_wiecej, y_wiecej);

                    int m = 0;

                    for (int l = 0; l < 3; l++)
                    {
                        for (int h = 1; h < 3; h++)
                        {
                            r[m] = k[l, h].R;
                            g[m] = k[l, h].G;
                            b[m] = k[l, h].B;
                            m++;
                        }
                    }


                    b2.SetPixel(x, y, Color.FromArgb(Med(r, 9), Med(g, 9), Med(b, 9)));

                }
            }
            pictureBox2.Refresh();
        }
    }
}
