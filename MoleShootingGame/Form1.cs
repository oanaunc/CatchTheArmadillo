using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoleShootingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool doClick = true;

        Random r = new Random();
        int score = 0;
        int total_shots = 0;
        int missed_shots = 0;

        void fn_shots()
        {
            score++;
            label1.Text = "Score = " + score;
            total_shots++;
            label3.Text = "Total Shots = " + total_shots;
            shot_sound();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x, y;
            x = r.Next(50, 800);
            y = r.Next(150, 550);
            pictureBox1.Location = new Point(x, y);
            if (missed_shots >= 10)
            {
                timer1.Stop();
                label4.Visible = true;
                doClick = false;

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (doClick)
            {
                fn_shots();
            }

        }

        void fn_missed_shots()
        {
            missed_shots++;
            label2.Text = "Missed Shots = " + missed_shots;
            total_shots++;
            label3.Text = "Total Shots = " + total_shots;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            if (doClick)
            {
                fn_missed_shots();
            }

        }

        void shot_sound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\test\shot.wav");
            player.Play();
        }
        void reset()
        {
            score = 0;
            missed_shots = 0;
            total_shots = 0;
            label1.Text = "Score = " + score;
            label2.Text = "Missed Shots = " + missed_shots;
            label3.Text = "Total Shots = " + total_shots;
            label4.Visible = false;
            timer1.Start();
            doClick = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
