using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabInf4__2_
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Random rand = new Random();
        int card = 1;
        int xpos = 0;
        int ypos = 0;
        bool check = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            Graphics bufimg = Graphics.FromImage(image);
            bufimg.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ClientRectangle.Width, ClientRectangle.Height), Color.DarkGreen, Color.LightGreen), ClientRectangle);
            for (int i = 0; i <= 15; i += 3)
            {
                bufimg.DrawImage(imageList1.Images[0], 800 + i, 70 + i, 145, 227);
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xpos = e.X;
                ypos = e.Y;

            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, 0, 0);
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (xpos == 0 && ypos == 0)
            {
                return;
            }
            if (check == false)
            {
                return;
            }
            Graphics graphics = CreateGraphics();
            Graphics bufimg = Graphics.FromImage(image);
            bufimg.TranslateTransform(xpos, ypos);
            bufimg.RotateTransform(rand.Next(-360, 360));
            bufimg.TranslateTransform(-(xpos), -(ypos));
            bufimg.DrawImage(imageList1.Images[card], xpos - 60, ypos - 90, 145, 227);
            graphics.DrawImage(image, 0, 0);
            card++;
            xpos = 0;
            ypos = 0;
            check = false;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= 800 && e.X <= 945 && e.Y >= 70 && e.Y <= 397)
            {
                check = true;
                if (card == 37)
                {
                    MessageBox.Show("В колоде закончились карты нажмите F2");
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                image = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                Graphics bufimg = Graphics.FromImage(image);
                bufimg.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ClientRectangle.Width, ClientRectangle.Height), Color.LightGreen, Color.DarkGreen), ClientRectangle);
                for (int i = 0; i <= 15; i += 3)
                {
                    bufimg.DrawImage(imageList1.Images[0], 800 + i, 70 + i, 145, 227);
                }
                this.Refresh();
                card = 1;
                MessageBox.Show("Карты собраны в колоду");
            }
        }
    }
}
