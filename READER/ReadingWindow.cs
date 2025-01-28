using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace READER
{
    public partial class ReadingWindow : Form
    {
        public bool isPaused = false;
        public bool isClosed = false;


        public ReadingWindow()
        {
            InitializeComponent();
        }

        private void PauseResume(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if(isPaused == true)
            {
                btnPause.Text = "Resume";
            }
            if(isPaused == false)
            {
                btnPause.Text = "Pause";
            }
        }

        private void ReaderWindowLoaded(object sender, EventArgs e)
        {

            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
            lblWords.Height = height;
            lblWords.Width = width;
            isClosed = false;
            isPaused = false;



        }

        private void ReaderWindowClosed(object sender, FormClosedEventArgs e)
        {
            isClosed = true;
        }
    }
}
