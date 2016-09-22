using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Windows.Documents;
using System.IO;

//for string to voice
using System.Speech.Synthesis;

namespace voice_reader
{
    public partial class Form3 : Form
    {
        string folder = @"C:\Users\User\Desktop\Project PDA\voice reader\MP3";
        string filter = "*.mp3";
        string[] mp3_file_address;
        string[] mp3_files;
        public string[] SelectedMP3;
        int num_of_mp3;
        int index = -1;
        public int SongId;
        bool IsPaused = false;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        ControlForm cf;

        public Form3(ControlForm c)
        {
            InitializeComponent();
            cf = c;
            mp3_file_address = Directory.GetFiles(folder, filter);
            mp3_files = Directory.GetFiles(folder, filter).Select(path => Path.GetFileName(path)).ToArray();
            num_of_mp3 = mp3_files.Length;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        public void Next()
        {
            if (index < num_of_mp3 - 1)
                index++;
            richTextBox1.Text = mp3_files[index];

            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;     // -10...10
            // Asynchronous
            synthesizer.SpeakAsync(richTextBox1.Text);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (index < num_of_mp3 - 1)
            {
                index++;
                richTextBox1.Text = mp3_files[index];

                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();
                //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -3;     // -10...10
                // Asynchronous
                synthesizer.SpeakAsync(richTextBox1.Text);
            }
        }

        public void Previous()
        {
            if (index > 0)
            {
                index--;
                richTextBox1.Text = mp3_files[index];

                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();
                //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -3;     // -10...10
                // Asynchronous
                synthesizer.SpeakAsync(richTextBox1.Text);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (index > 0)
               index--;
            richTextBox1.Text = mp3_files[index];

            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;     // -10...10
            // Asynchronous
            synthesizer.SpeakAsync(richTextBox1.Text);
        }

        public void Start()
        {
            index = 0;
            richTextBox1.Text = mp3_files[index];
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;     // -10...10
            // Asynchronous
            synthesizer.SpeakAsync(richTextBox1.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            index = 0;
            richTextBox1.Text = mp3_files[index];
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;     // -10...10
            // Asynchronous
            synthesizer.SpeakAsync(richTextBox1.Text);
        }

        public bool SelectMP3()
        {
            //return true; 
            if (index != -1)
            {
                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();
                SelectedMP3 = mp3_file_address;
                SongId = index;
                return true;
            }
            else return false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();
                

                //Form4 f1 = new Form4(mp3_file_address,index);
                //f1.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                //this.Hide();
                //f1.Show();
            }
        }
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        public void Back()
        {
            //Cancelling synthesizer
            synthesizer.SpeakAsyncCancelAll();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            //Cancelling synthesizer
            synthesizer.SpeakAsyncCancelAll();
            //Form5 f1 = new Form5();
            //f1.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            //this.Hide();
            //f1.Show();
        }

        public void PausePlay()
        {
            if (IsPaused == false)
            {
                synthesizer.Pause();
                button2.Text = "Play";
                IsPaused = true;
            }
            else
            {
                synthesizer.Resume();
                button2.Text = "Pause";
                IsPaused = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (IsPaused == false)
            {
                synthesizer.Pause();
                button2.Text = "Play";
                IsPaused = true;
            }
            else
            {
                synthesizer.Resume();
                button2.Text = "Pause";
                IsPaused = false;
            }
        }
    }
}