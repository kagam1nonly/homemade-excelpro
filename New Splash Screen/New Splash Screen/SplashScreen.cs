using System;
using System.Windows.Forms;

namespace New_Splash_Screen
{
    public partial class SplashScreen : Form
    {
        public Form1 form1;
        private readonly Timer timer;
        private int progress;
        public SplashScreen()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            progressBar1.Value = 0;

            // Initialize the timer
            timer = new Timer();
            timer.Interval = 1000;// 1 second
            timer.Tick += Timer1_Tick;
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            // Start the timer
            timer.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Update the progress bar value
            progress++;
            progressBar1.Value = progress;

            // Check if the progress is complete
            if (progress == progressBar1.Maximum)
            {
                // Stop the timer and do something
                timer.Stop();
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
        }
    }
}
