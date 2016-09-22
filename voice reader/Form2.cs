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
    public partial class Form2 : Form
    {
        string folder = @"C:\Users\User\Desktop\Project PDA\voice reader\books";
        string filter = "*.pdf";
        string[] pdf_file_address;
        string[] pdf_files;
        public string SelectedPDF;
        int num_of_pdf;
        int index = -1;
        bool IsPaused = false;
        public SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public Form2(ControlForm cf)
        {
            InitializeComponent();
            pdf_file_address = Directory.GetFiles(folder, filter);
            pdf_files = Directory.GetFiles(folder, filter).Select(path => Path.GetFileName(path)).ToArray();
            num_of_pdf = pdf_files.Length;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void Next()
        {
            if (index < num_of_pdf - 1 && index != -1)
            {
                index++;
                richTextBox1.Text = pdf_files[index];

                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();
                //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -3;     // -10...10
                // Asynchronous
                synthesizer.SpeakAsync(richTextBox1.Text);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (index < num_of_pdf - 1 && index != -1)
            {
                index++;
                richTextBox1.Text = pdf_files[index];

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
            if (index > 0 && index != -1)
            {
                index--;
                richTextBox1.Text = pdf_files[index];

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
            if (index > 0 && index != -1)
            {
                index--;
                richTextBox1.Text = pdf_files[index];

                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();
                //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -3;     // -10...10
                // Asynchronous
                synthesizer.SpeakAsync(richTextBox1.Text);
            }
        }

        public void Start()
        {
            index = 0;
            richTextBox1.Text = pdf_files[index];
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
            richTextBox1.Text = pdf_files[index];
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;     // -10...10
            // Asynchronous
            synthesizer.SpeakAsync(richTextBox1.Text);
        }

        public bool SelectPDF()
        {
            if (index != -1)
            {
                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();
                SelectedPDF = pdf_file_address[index];
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
                //Form1 f1 = new Form1(pdf_file_address[index]);
                //f1.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                //this.Hide();
                //f1.Show();
            }
        }

        public void PausePlay()
        {
            if (index == -1) return;
            if (IsPaused == false)
            {
                IsPaused = true;
                synthesizer.Pause();
                button2.Text = "Play";
            }
            else
            {
                IsPaused = false;
                synthesizer.Resume();
                button2.Text = "Pause";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (index == -1) return;
            if (IsPaused == false)
            {
                IsPaused = true;
                synthesizer.Pause();
                button2.Text = "Play";
            }
            else
            {
                IsPaused = false;
                synthesizer.Resume();
                button2.Text = "Pause";
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        public void Back()
        {
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
            //Form5 f5 = new Form5();
            //f5.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            //this.Hide();
            //f5.Show();
        }
    }
}
