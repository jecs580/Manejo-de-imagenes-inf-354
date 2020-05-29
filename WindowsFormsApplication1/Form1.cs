using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Color c1;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Carga una imagen y la muestra desde un PictureBox
            openFileDialog1.Filter = "Archivos JPG |*.jpg|Archivos BMP|*.bmp|Todos los archivos|*.*";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Muestra los numeros de RGB de un pixel seleccionado por el mouse
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            c1 = c;
            //textBox4.BackColor=c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cambia la imagen para que sea solo de color rojo
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                Color c = new Color();

                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(c.R, 0, 0));
                }
                pictureBox1.Image = bmp2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Cambia de color color a los pixeles que se igual al pixel seleccionado con el mouse
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            Bitmap bmp3 = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                Color c = new Color();

                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp1.GetPixel(i, j);
                    if (c.R == c1.R && c.G == c1.G && c.B == c1.B)
                    {

                        bmp3.SetPixel(i, j, Color.Red);
                    }
                    else
                    {
                        bmp3.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }
                    pictureBox1.Image = bmp3;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Cambia de color rojo a los pixeles que esten en un rango de +-5 al numero de cada color.
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            Bitmap bmp3 = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                Color c = new Color();

                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp1.GetPixel(i, j);
                    if ((c.R > c1.R - 5 && c.R < c1.R + 5) && (c.G > c1.G - 5 && c.G < c1.G + 5) && (c.B > c1.B - 5 && c.B < c1.B + 5))
                    {

                        bmp3.SetPixel(i, j, Color.Red);
                    }
                    else
                    {
                        bmp3.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }
                    pictureBox1.Image = bmp3;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Cambia de color rojo a bloques de pixeles que esten el promedio del color del pixel seleccionado por el mouse.
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            Bitmap bmp3 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int rm, gm, bm;
            for (int i = 0; i < bmp.Width - 10; i=i+10)
            {
                for (int j = 0; j < bmp.Height - 10; j=j+10)
                {
                    rm = 0; gm = 0; bm = 0;
                    for (int im = i; im < i + 10; im++)
                    {
                        for (int jm = j; jm < j + 10; jm++)
                        {
                            c = bmp1.GetPixel(i, j);
                            rm = rm + c.R;
                            gm = gm + c.G;
                            bm = bm + c.B;
                        }
                    }
                    rm = rm / 100;
                    gm = gm / 100;
                    bm = bm / 100;
                    if ((rm > c1.R - 10 && rm < c1.R + 10) && (gm > c1.G - 10 && gm < c1.G + 10) && (bm > c1.B - 10 && bm < c1.B + 10))
                    {
                        for (int im = i; im < i + 10; im++)
                        {
                            for (int jm = j; jm < j + 10; jm++)
                            {
                                bmp3.SetPixel(im, jm, Color.Red);
                            }
                        }
                    }
                    else
                    {
                        for (int im = i; im < i + 10; im++)
                        {
                            for (int jm = j; jm < j + 10; jm++)
                            {
                                c = bmp1.GetPixel(im, jm);
                                bmp3.SetPixel(im, jm, Color.FromArgb(c.R, c.G, c.B));
                            }
                        }
                    }
                    pictureBox1.Image = bmp3;
                }
            }
        }
    }
}