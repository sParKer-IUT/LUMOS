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
    public partial class Form4 : Form
    {
        bool IsPaused = false;
        bool IsStopped = false;
        int position;
        int capacity;
        String ppath;
        String[] list;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        ControlForm cf;
        public Form4(ControlForm c)
        {
            InitializeComponent();
            cf = c;
        }
        public void setMediaPlayer(String[] path, int index)
        {
            InitializeComponent();
            ppath = path[index];
            position = index;
            list = path;
            capacity = path.Length;
            wplayer.URL = ppath; ;
            wplayer.controls.play();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        public void PausePlay()
        {
            if (IsPaused == false)
            {
                IsPaused = true;
                wplayer.controls.pause();
            }
            else
            {
                IsPaused = false;
                wplayer.controls.play();
            }
        }

        public void StartStop()
        {
            if (IsStopped == false)
            {
                IsStopped = true;
                wplayer.controls.stop();
            }
            else
            {
                IsStopped = false;
                wplayer.controls.play();
            }
        }

        public void Next()
        {
            position++;
            if (position >= capacity)
            {
                position = 0;
            }
            wplayer.controls.stop();
            ppath = list[position];
            wplayer.URL = ppath;
            wplayer.controls.play();
        }

        public void Previous()
        {
            position--;
            if (position < 0)
            {
                position = capacity - 1;
            }
            wplayer.controls.stop();
            ppath = list[position];
            wplayer.URL = ppath;
            wplayer.controls.play();
        }

        public void Back()
        {
            wplayer.controls.stop();
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
