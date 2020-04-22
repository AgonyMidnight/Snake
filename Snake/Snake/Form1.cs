using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        static int  width = 20, height = 20;
        Pen Field = new Pen(Color.Green, 3);
        public int count;
        Bitmap bitmap;
        AnySnake Snaky;
        SolidBrush Red = new SolidBrush(Color.Red);
        Berry RedBerry;

        private void Button1_Click(object sender, EventArgs e)
        {
            Snaky = new AnySnake();
            RedBerry = new Berry();
            timer1.Interval = 200;
            timer1.Enabled = true;
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {   
            for (int i = Snaky.coordinatSnakes.Count()-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    Snaky.Move();
                }
                else
                {
                    var temp = Snaky.coordinatSnakes[i];
                    temp.x = Snaky.coordinatSnakes[i - 1].x;
                    temp.y = Snaky.coordinatSnakes[i - 1].y;
                    Snaky.coordinatSnakes[i] = temp;
                }
            }

            if ( (Snaky.coordinatSnakes[0].x == RedBerry.x) && (Snaky.coordinatSnakes[0].y == RedBerry.y))
            {
                count++;
                label2.Text = count.ToString();
                RedBerry.ChangeCoordinate();
                var temp = Snaky.coordinatSnakes.Last();
                Snaky.coordinatSnakes.Add(new CoordinatSnake() { x = temp.x, y = temp.y });
            }

            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
           
            for (int i = 0; i< Snaky.coordinatSnakes.Count(); i++)
            {
                g.DrawRectangle(Field, Snaky.coordinatSnakes[i].x * width, Snaky.coordinatSnakes[i].y * height, width, height);
            }

            g.FillRectangle(Red, RedBerry.x * width, RedBerry.y * height, width, height);

            if ( (Snaky.coordinatSnakes[0].x <0)|| (Snaky.coordinatSnakes[0].x>width) || (Snaky.coordinatSnakes[0].y<0) || (Snaky.coordinatSnakes[0].y > height))
            {
                timer1.Stop();
                MessageBox.Show("Loose!");
            }

            pictureBox1.Image = bitmap;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "W":
                    {
                        Snaky.WantNavigation = 'T';
                        break;
                    }
                case "A":
                    {
                        Snaky.WantNavigation = 'L';
                        break;
                    }
                case "S":
                    {
                        Snaky.WantNavigation = 'D';
                        break;
                    }
                case "D":
                    {
                        Snaky.WantNavigation = 'R';
                        break;
                    }
                default:
                    {
                        Snaky.WantNavigation = Snaky.Navigation;
                        break;
                    }
            }
        }

        public Form1()
        {
            count = 0;
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            KeyPreview = true;
        }
    }
}
