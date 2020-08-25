using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarioMove
{
    public partial class Form1 : Form
    {
        Random num = new Random(); //variable num for random number.
        Rectangle Rect1;//creates rectangle
        Rectangle Rect2;
        Image LMarioS;
        Image LMarioR;
        Image LMarioM;
        Image LMarioj;
        Image RMarioS;
        Image RMarioR;
        Image RMarioM;
        Image RMarioj;


        Timer tick1;//creates timer
        Timer tick2;
        int dx = 2;//creates int for dx to move across the x axis.
        //int dy = 2;//creates int 
        int ddx = 2;


        bool jump;  //bool that would check if jump is true or false
        int gravity = 9;  //sets the gravity to 9 
        int force;  // the force that rectangle needs to jump 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // LMarioS = Image.FromFile(Application.StartupPath + @"\LMarS.JPEG", true);

            this.BackColor = Color.White;//sets background color black

            this.Height = 600;
            this.Width = 1000; // this sets the the size of the form
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.MinimumSize = new Size(500, 500);
            //sets image file location

            this.DoubleBuffered = true;
            //sets height and width for rectangle
            ;

            //sets image file location
            //sets height and width for rectangle

            this.DoubleBuffered = true;
            //creates paint
            this.Paint += Form1_Paint;
            //creates keydown and key up 
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;


            //creates timer and sets intrerval
            tick1 = new Timer();
            tick1.Interval = 10;
            tick1.Tick += Tick1_Tick;
            tick1.Start();
            //creates timer and sets intrerval
            tick2 = new Timer();
            tick2.Interval = 10;
            tick2.Tick += Tick2_Tick;
            tick2.Start();

            Rect1 = new Rectangle(num.Next(300), num.Next(300), 30, 30);  //sets the location of both rectnagles and the size
            Rect2 = new Rectangle(300, 300, 50, 25);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == (Keys.Up) || e.KeyCode ==(Keys.Down))
            //{
            //    dy = 0;

            //}

            if (e.KeyCode == (Keys.Left) || e.KeyCode == (Keys.Right))
            {
                dx = 0;

            }


        }

        private void Tick2_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            Rect2.X = Rect2.X + ddx;  //

            if (Rect2.Left <= 0)
            {

                ddx = 2;
            }
            else if (Rect2.Right >= this.ClientSize.Width)
            {

                ddx = -2;
            }

            //if (Rect1.IntersectsWith(Rect2))
            //{

            //    MessageBox.Show("You were hit!", "Game Over");//opens message box 
            //    tick1.Stop();
            //    tick2.Stop();
            //}
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            {
                //draws all object in app
                e.Graphics.FillRectangle(Brushes.Brown, Rect1);
                e.Graphics.FillRectangle(Brushes.Black, Rect2);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //sets keys to move objects in the application
            //if (e.KeyCode ==(Keys.Up) )
            //{
            //    dy = -2;
            //}
            //if (e.KeyCode ==(Keys.Down) )
            //{
            //    dy = 2;
            //}
            if (jump != true)
            {
                force = 0;
                if (e.KeyCode == Keys.Up)
                {
                    jump = true;

                    force = -20;

                }
            }
            if (e.KeyCode == (Keys.Left))
            {

                if (jump == true)
                {
                    dx = -2;
                }
                else if (jump == false)
                {
                    dx = -5;
                }

            }
            if (e.KeyCode == (Keys.Right))
            {
                if (jump == true)
                {
                    dx = 2;
                }
                else if (jump == false)
                {
                    dx = 5;
                }
            }


        }

        private void Tick1_Tick(object sender, EventArgs e)
        {


            this.Invalidate();
            Rect1.X = Rect1.X + dx;
            Rect1.Y = Rect1.Y + force + gravity;

            if (jump == true)
            {
                force += 1;
                Rect1.Y = Rect1.Y + force;

            }
            if (rect1.intersectswith(rect2))
            {

                if (rect1.bottom <= this.clientsize.height - rect2.height)
                {


                    rect1.y = this.clientsize.height - rect2.height;
                    jump = false;

                }
                else if (rect1.left <= rect2.right + rect2.width)
                {
                    rect1.x = rect2.right;
                }
                else if (rect1.right >= rect2.left)
                {
                    rect1.x = rect2.left;
                }
                else if (rect1.top > rect2.bottom)
                {


                    rect1.y = rect2.bottom - this.clientsize.height;
                    jump = false;

                }
            }

            if (Rect1.Left < 0)
            {

                Rect1.X = 0;
            }
            else if (Rect1.Right > this.ClientSize.Width)
            {

                Rect1.X = this.ClientSize.Width - Rect1.Width;
            }

            else if (Rect1.Top < 0)
            {
                Rect1.Y = 0;

            }
            else if (Rect1.Bottom > this.ClientSize.Height)
            {
                Rect1.Y = this.ClientSize.Height - Rect1.Height;
                jump = false;

            }

        }
    }
}
