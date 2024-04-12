using System;
using System.Windows.Forms;

namespace TheBaldMartinPetSim
{
    public partial class Form1 : Form
    {
        private int hunger;
        private int happiness;
        private int wisdom;

        private Timer decreaseFeedTimer;
        private Timer decreasePlayTimer;
        private Timer decreaseReadTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeTimers();
            // Set bars to start full
            FeedBar.Value = FeedBar.Maximum;
            PlayBar.Value = PlayBar.Maximum;
            ReadBar.Value = ReadBar.Maximum;
            // Set starting background color
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            pictureBox2.Visible = false; // Hide pictureBox1
        }

        private void InitializeTimers()
        {
            decreaseFeedTimer = new Timer();
            decreaseFeedTimer.Interval = 500; // 1000 milliseconds = 1 second
            decreaseFeedTimer.Tick += DecreaseFeedTimer_Tick;
            decreaseFeedTimer.Start();

            decreasePlayTimer = new Timer();
            decreasePlayTimer.Interval = 500; // 1000 milliseconds = 1 second
            decreasePlayTimer.Tick += DecreasePlayTimer_Tick;
            decreasePlayTimer.Start();

            decreaseReadTimer = new Timer();
            decreaseReadTimer.Interval = 500; // 1000 milliseconds = 1 second
            decreaseReadTimer.Tick += DecreaseReadTimer_Tick;
            decreaseReadTimer.Start();
        }

        private void DecreaseFeedTimer_Tick(object sender, EventArgs e)
        {
            // Decrease the value of FeedBar every second
            if (FeedBar.Value > 0)
            {
                FeedBar.Value--;
                UpdateBackgroundColor();
                EndGame(); // Call EndGame() method here
            }
        }

        private void DecreasePlayTimer_Tick(object sender, EventArgs e)
        {
            // Decrease the value of PlayBar every second
            if (PlayBar.Value > 0)
            {
                PlayBar.Value--;
                UpdateBackgroundColor();
                EndGame(); // Call EndGame() method here
            }
        }

        private void DecreaseReadTimer_Tick(object sender, EventArgs e)
        {
            // Decrease the value of ReadBar every second
            if (ReadBar.Value > 0)
            {
                ReadBar.Value--;
                UpdateBackgroundColor();
                EndGame(); // Call EndGame() method here
            }
        }

        private void UpdateBackgroundColor()
        {
            if (FeedBar.Value < FeedBar.Maximum * 0.2 ||
                PlayBar.Value < PlayBar.Maximum * 0.2 ||
                ReadBar.Value < ReadBar.Maximum * 0.2)
            {
                this.BackColor = System.Drawing.Color.Tomato;
            }
            else
            {
                // Set default background color
                this.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        private void EndGame()
        {
            if (FeedBar.Value < FeedBar.Maximum * 0.01 ||
                PlayBar.Value < PlayBar.Maximum * 0.01 ||
                ReadBar.Value < ReadBar.Maximum * 0.01)
            {
                decreaseFeedTimer.Stop();
                decreasePlayTimer.Stop();
                decreaseReadTimer.Stop();
                pictureBox1.Visible = false; // Hide pictureBox1
                pictureBox2.Visible = true; // Show pictureBox2
                MessageBox.Show("YOU HAVE DIED!", "GAME OVER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FeedButton_Click(object sender, EventArgs e)
        {
            // Increase the value of FeedBar when feeding
            if (FeedBar.Value < FeedBar.Maximum)
            {
                FeedBar.Value++;
                UpdateBackgroundColor();
            }
        }

        private void PlayButton_Click_1(object sender, EventArgs e)
        {
            // Increase the value of PlayBar when playing
            if (PlayBar.Value < PlayBar.Maximum)
            {
                PlayBar.Value++;
                UpdateBackgroundColor();
            }
        }

        private void ReadButton_Click_1(object sender, EventArgs e)
        {
            // Increase the value of ReadBar when reading
            if (ReadBar.Value < ReadBar.Maximum)
            {
                ReadBar.Value++;
                UpdateBackgroundColor();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
