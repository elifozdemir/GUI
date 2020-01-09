using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace buttonGame
{
    

    public partial class Form1 : Form
    {
        Random random = new Random();
        int actualTime = 0;
        bool gameOn = false;
        Button firstClicked, secondClicked;
        public Form1()
        {
            InitializeComponent();
            assign();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            

            if(gameOn==false)
            {
                gameOn = true;
                ((Button)sender).Text = "PAUSE";
                timer1.Start();
            }
            else 
            {
                gameOn = false;
                ((Button)sender).Text = "PLAY";
                timer1.Stop();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.BackColor==Color.AliceBlue)
            {
                b.BackColor = Color.DeepPink;
                b.ForeColor = Color.DeepPink;
            }

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.BackColor == Color.DeepPink)
            {
                b.BackColor = Color.AliceBlue;
                b.ForeColor = Color.AliceBlue;
            }
        }

        private void assign()
        {
            List<string> nums = new List<string>()
         {
           "1","1","2","2","3","3","4","4","5","5","6","6","7","7","8","8"
          };
            Button b;
            int randomnumber;
            for(int i=0; i<tableLayoutPanel2.Controls.Count; i++)
            {
                if (tableLayoutPanel2.Controls[i] is Button)
                    b = (Button)tableLayoutPanel2.Controls[i];
                else
                    continue;
                randomnumber = random.Next(0, nums.Count);
                b.Text = nums[randomnumber];
                b.ForeColor = Color.AliceBlue;
                nums.RemoveAt(randomnumber);


             
            }

        }
        private void checkFortheWinnner()
        {
            Button b;
            for(int i=0; i<tableLayoutPanel2.Controls.Count; i++)
            {
                b = tableLayoutPanel2.Controls[i] as Button;
                if (b!=null && b.Visible == true)
                    return;
            }
            timer1.Stop();
            keepon();
        }

        private void keepon()
        {
            DialogResult dialogResult = MessageBox.Show("Play again? Your time is "+ timerLabel.Text,"You finished!!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                resetGame();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                Close();
            }
        }
        private void resetGame()
        {
            timer1.Stop();

            timerLabel.Text = "0 s";

            Button b;
            for (int i = 0; i < tableLayoutPanel2.Controls.Count; i++)
            {
                b = tableLayoutPanel2.Controls[i] as Button;
                if (b.Visible == false)
                {
                    b.Visible = true;
                    b.BackColor = Color.AliceBlue;
                }
            }
            assign();

        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
           
            timerLabel.Text = "0 s";

            Button b;
            for (int i = 0; i < tableLayoutPanel2.Controls.Count; i++)
            {
                b = tableLayoutPanel2.Controls[i] as Button;
                if (b.Visible == false)
                {
                    b.Visible = true;
                    b.BackColor = Color.AliceBlue;
                }
            }
            assign();
        }


        private void timerLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actualTime++;
            timerLabel.Text = (actualTime / 2).ToString() + "s";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            firstClicked.Visible = false;
            secondClicked.Visible = false;
            checkFortheWinnner();
            firstClicked = null;
            secondClicked = null;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            firstClicked.BackColor = Color.AliceBlue;
            secondClicked.BackColor = Color.AliceBlue;
            firstClicked.ForeColor = Color.AliceBlue;
            secondClicked.ForeColor = Color.AliceBlue;
            firstClicked = null;
            secondClicked = null;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameOn == true)
            {
                
                if (firstClicked != null && secondClicked != null)
                    return;
                Button clicked = sender as Button;
                if (clicked == null)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clicked;
                    firstClicked.BackColor = Color.DarkGray;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clicked;
                secondClicked.BackColor = Color.DarkGray;
                secondClicked.ForeColor = Color.Black;
                
                if (firstClicked.Text == secondClicked.Text)
                {
                    timer2.Start();
                    
                   
                    
                }
                else
                {

                    timer3.Start();
                    
                }

            }

        }
    }
}
