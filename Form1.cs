using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock
{
    public partial class Form1 : Form
    {
        int cx = 300;
        int cy = 300;

        int time = 0;

        double sec_length = 130;
        double min_length = 100;
        double hou_length = 65;

        double sec_degree = 0;
        double min_degree = 0;
        double hou_degree = 0;

        double increase_degree = 15;
        
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 5;
        }
        private int to_x(double d, double l)
        {
            int x = (int)(l * Math.Cos(d * Math.PI / 180));
            return x;
        }
        private int to_y(double d, double l)
        {
            int y = (int)(l * Math.Sin(d * Math.PI / 180));
            return y;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen sec = new Pen(Color.Black, 4);
            g.DrawLine(sec, cx, cy,
                cx + to_x(sec_degree, sec_length),
                cy + to_y(sec_degree, sec_length));
            
            Pen min = new Pen(Color.Black, 7);
            g.DrawLine(min, cx, cy,
                cx + to_x(min_degree, min_length),
                cy + to_y(min_degree, min_length));

            Pen hou = new Pen(Color.Black, 10);
            g.DrawLine(hou, cx, cy,
                cx + to_x(hou_degree, hou_length),
                cy + to_y(hou_degree, hou_length));

            g.DrawEllipse(hou, 80, 80, 435, 435);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate(false);

            time++;

            sec_degree = time * increase_degree;
            min_degree = time * increase_degree / 12;
            hou_degree = time * increase_degree / 12 / 12;
        }
    }
}
