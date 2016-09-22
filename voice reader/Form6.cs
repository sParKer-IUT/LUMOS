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
    public partial class Form6 : Form
    {
        string folder = @"C:\Users\User\Desktop\Project PDA\voice reader\sounds mp3";
        string filter = "*.mp3";
        string[] mp3_file_address;
        //string[] mp3_files;
        //public string[] SelectedMP3;
        int capacity;
        int position = 0;
        public int SongId;
        bool IsPaused = false;
        bool IsStopped = false;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        ControlForm cf;

        public Form6(ControlForm c)
        {
            InitializeComponent();
            cf = c;
        }

        public void setVoiceInstruction()
        {
            mp3_file_address = Directory.GetFiles(folder, filter);
            //mp3_files = Directory.GetFiles(folder, filter).Select(path => Path.GetFileName(path)).ToArray();
            capacity = mp3_file_address.Length;

            wplayer.URL = mp3_file_address[position];
            wplayer.controls.play();
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
            wplayer.URL = mp3_file_address[position];
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
            wplayer.URL = mp3_file_address[position];
            wplayer.controls.play();
        }

        public void Back()
        {
            wplayer.controls.stop();
        }

    }
}
