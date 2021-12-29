using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба5_3семестр
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            map = new Bitmap(pictureBox_Image.Width, pictureBox_Image.Height);
            pictureBox_Image.Image = map;
        }

        Bitmap map;
        Pen pen = new Pen(Color.Black);
        double radian = Math.PI/180 ;

        private void Volni()
        {
            Graphics g = Graphics.FromImage(map);
            g.Clear(Color.White);

            Points[,] points = new Points[60, 60];
            double r = 5;
            for(int x = 0; x < 60; x++)
                for(int z = 0; z < 60; z++)
                {
                    double a = 0.000000002;
                    double vx = 1;
                    double vz = 1;
                    double x0 = x, z0 = z;
                    double x1 = x, z1 = z;
                    x1 = x + r * x;
                    z1 = z + r * z;

                    double y = Math.Pow(Math.E, -a * (x1 * x1 + z1 * z1))*Math.Cos(vx*x1)*Math.Cos(vz*z1);
                    double y0 = y;
                    double y1 = y;
                    y1 = y0 * Math.Cos(rxTrackBar.Value * radian) - z0 * Math.Sin(rxTrackBar.Value * radian);
                    z1 = y0 * Math.Sin(rxTrackBar.Value * radian) + z0 * Math.Cos(rxTrackBar.Value * radian);
                    y0 = y1;
                    z0 = z1;
                   
                    x1 = x0 * Math.Cos(ryTrackBar.Value * radian) - z0 * Math.Sin(ryTrackBar.Value * radian);
                    z1 = -x0 * Math.Sin(ryTrackBar.Value * radian) + z0 * Math.Cos(ryTrackBar.Value * radian);
                    x0 = x1;
                    z0 = z1;

                    x1 = x0 * Math.Cos(rzTrackBar.Value * radian) - y0 * Math.Sin(rzTrackBar.Value * radian);
                    y1 = x0 * Math.Sin(rzTrackBar.Value * radian) + y0 * Math.Cos(rzTrackBar.Value * radian);
                    x0 = x1;
                    y0 = y1;

                    //double angleB = (-45) * radian;
                    //double angleA = (-45) * radian;

                    x1 = x1 * trackBar1.Value + ofxTrackBar.Value;
                    
                    z1 = z1 * trackBar1.Value + ofzTrackBar.Value;

                     //x1 = x0 * Math.Cos(angleA) + y0 * Math.Sin(angleA);
                     //y1 = -x0 * Math.Sin(angleA) * Math.Cos(angleB) + y0 * Math.Cos(angleA) * Math.Cos(angleB) + z0 * Math.Sin(angleB);
                     //z1 = x0 * Math.Sin(angleA) * Math.Sin(angleB) - y0 * Math.Cos(angleA) * Math.Sin(angleB) + z0 * Math.Cos(angleB);

                   x1 = x1 + pictureBox_Image.Width / 2;
                   z1 = z1 + pictureBox_Image.Height / 2;

                    points[x, z] = new Points(x1, y1, z1); 
                }

            for (int i = 0; i < 59; i++)
                for (int j = 0; j < 59; j++)
                {
                    g.DrawLine(pen, (int)points[i, j].X, (int)points[i, j].Z, (int)points[i, j + 1].X, (int)points[i, j + 1].Z);
                    g.DrawLine(pen, (int)points[i, j + 1].X, (int)points[i, j + 1].Z, (int)points[i + 1, j + 1].X, (int)points[i + 1, j + 1].Z);
                    g.DrawLine(pen, (int)points[i + 1, j + 1].X, (int)points[i + 1, j + 1].Z, (int)points[i + 1, j].X, (int)points[i + 1, j].Z);
                    g.DrawLine(pen, (int)points[i + 1, j].X, (int)points[i + 1, j].Z, (int)points[i, j].X, (int)points[i, j].Z);
                }

            pictureBox_Image.Refresh();
        }

        private void ofxTrackBar_MouseMove(object sender, MouseEventArgs e)
        {
            Volni();
        }

        private void ofxTrackBar_Scroll(object sender, EventArgs e)
        {
            labelX.Text = ((double)ofxTrackBar.Value).ToString();
        }

        private void ofyTrackBar_Scroll(object sender, EventArgs e)
        {
            
        }

        private void ofzTrackBar_Scroll(object sender, EventArgs e)
        {
            labelZ.Text = ((double)ofzTrackBar.Value).ToString();
        }

        private void rxTrackBar_Scroll(object sender, EventArgs e)
        {
            labelX1.Text = ((double)rxTrackBar.Value).ToString();
        }

        private void ryTrackBar_Scroll(object sender, EventArgs e)
        {
            labelY1.Text = ((double)ryTrackBar.Value).ToString();
        }

        private void rzTrackBar_Scroll(object sender, EventArgs e)
        {
            labelZ1.Text = ((double)rzTrackBar.Value).ToString();
        }

        private void pictureBox_Image_Click(object sender, EventArgs e)
        {

        }
    }
}
