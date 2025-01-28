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
    public partial class Form1 : Form
    {

        string words;
        string[] splitup;
        int totalWords;
        int counting = -1;
        int intervalSetting = 0;
        ReadingWindow reader;
        int localCounter;
        char[] charsToTrim = { '*', '.', ',','+' };
        string cleanText;



        public Form1()
        {

            InitializeComponent();
            speedbox.Text = "1";


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


          
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void StartReading(object sender, EventArgs e)
        {




            reader = new ReadingWindow();
            words = MainText.Text;
            splitup = words.Split();
            totalWords = splitup.Length;
            int value = Convert.ToInt32(speedbox.Text);
            readingTimer.Interval = 100*value;
            counting = -1;
            localCounter = 0;
            reader.Show();
            readingTimer.Start();
            


           

        }

        private void HelpButtonClick(object sender, EventArgs e)
        {

            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();


        }

        private void TimerEvent(object sender, EventArgs e)
        {

            localCounter = counting;
            if(counting >= totalWords - 1)
            {
                readingTimer.Stop();
                MessageBox.Show("Text Completed!");
                counting = -1;

            }
            else if(reader.isClosed == true)
            {
                readingTimer.Stop();
            }
            else
            {
                if(reader.isPaused == true)
                {
                    counting = localCounter;
                }
                else
                {
                    counting += 1;
                }
                cleanText = splitup[counting].Trim(charsToTrim);
                reader.lblWords.Text = cleanText;
            }

        }
    }
}




