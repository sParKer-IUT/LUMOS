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
    public partial class Form1 : Form
    {
        int page = 0;
        string text;
        string ppath;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        PdfReader pdfReader;
        int NumberOfPages;
        bool IsPaused = false;
        ControlForm cf;

        public Form1(ControlForm c)
        {
            InitializeComponent();
            cf = c;
        }

        public void setPdfReader(string path)
        {
            ppath = path;
            pdfReader = new PdfReader(ppath);
            NumberOfPages = pdfReader.NumberOfPages;
        }

        public void ExtractTextFromPDFPage(int pageNumber)
        {
            text = PdfTextExtractor.GetTextFromPage(pdfReader, pageNumber);
            try { pdfReader.Close(); }
            catch { }
            richTextBox1.Text = text;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        public void Start()
        {
            page = 1;
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();

            ExtractTextFromPDFPage(page);
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;     // -10...10
            // Asynchronous
            synthesizer.SpeakAsync(text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            page = 1;
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();

            ExtractTextFromPDFPage(page);
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;     // -10...10
            // Asynchronous
            synthesizer.SpeakAsync(text);
        }

        public void Next()
        {
            if (page < NumberOfPages && page != 0)
            {
                page++;
                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();

                ExtractTextFromPDFPage(page);
                //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -3;     // -10...10
                // Asynchronous
                synthesizer.SpeakAsync(text);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (page < NumberOfPages && page!=0)
            {
                page++;
                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();

                ExtractTextFromPDFPage(page);
                //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -3;     // -10...10
                // Asynchronous
                synthesizer.SpeakAsync(text);
            }
        }

        public void Previous()
        {
            if (page > 1)
            {
                page--;
                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();

                ExtractTextFromPDFPage(page);
                //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -3;     // -10...10
                // Asynchronous
                synthesizer.SpeakAsync(text);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                //Cancelling synthesizer if it is currently speaking
                synthesizer.SpeakAsyncCancelAll();

                ExtractTextFromPDFPage(page);
                //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -3;     // -10...10
                // Asynchronous
                synthesizer.SpeakAsync(text);
            }
        }

        public void PausePlay()
        {
            if (page == 0) return;
            if (IsPaused == false)
            {
                IsPaused = true;
                synthesizer.Pause();
                button4.Text = "Play";
            }
            else
            {
                IsPaused = false;
                synthesizer.Resume();
                button4.Text = "Pause";
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (page == 0) return;
            if (IsPaused == false)
            {
                IsPaused = true;
                synthesizer.Pause();
                button4.Text = "Play";
            }
            else
            {
                IsPaused = false;
                synthesizer.Resume();
                button4.Text = "Pause";
            }
        }

        public void Back()
        {
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Cancelling synthesizer if it is currently speaking
            synthesizer.SpeakAsyncCancelAll();
            //Form2 f1 = new Form2();
            //f1.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            //this.Hide();
            //f1.Show();
        }
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
       
    }
}
