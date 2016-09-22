using Leap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Net.Mail;

namespace voice_reader
{
    public partial class ControlForm : Form
    {
        public int id = 0;
        public LeapCustomListener l;
        public Controller control;
        public Form1 f1;
        public Form4 f4;
        public Form3 f3;
        public Form2 f2;
        public Form5 f5;
        public Form6 f6;
        int sleeptime = 1000;
        public ControlForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            l = new LeapCustomListener();
            control = new Controller(l);
            this.l.FrameReceived += NewFrameReceived;
            
            f2 = new Form2(this);
            f2.WindowState = FormWindowState.Minimized;
            f2.Show();
            f2.Hide();

            f1 = new Form1(this);
            f1.WindowState = FormWindowState.Minimized;
            f1.Show();
            f1.Hide();

            f3 = new Form3(this);
            f3.WindowState = FormWindowState.Minimized;
            f3.Show();
            f3.Hide();

            f4 = new Form4(this);
            f4.WindowState = FormWindowState.Minimized;
            f4.Show();
            f4.Hide();

            f6 = new Form6(this);
            f6.WindowState = FormWindowState.Minimized;
            f6.Show();
            f6.Hide();

            f5 = new Form5(this);
            f5.WindowState = FormWindowState.Minimized;
            f5.Show();
            f5.Hide();
        }
        private void NewFrameReceived(Controller controller)
        {
            Frame frame = controller.Frame();
            GestureList gestures = frame.Gestures();
            
            float position = frame.Fingers[0].TipPosition.x;
            int finger = frame.Fingers.Count;
            int hands = frame.Hands.Count;
            
            if (frame.Hands.IsEmpty) return;

            switch (id)
            {
                case 0:   //Goto Main
                    if (gestures[0].Type == Gesture.GestureType.TYPECIRCLE)
                    {
                        this.Hide();
                        id = 5;
                        f5.Show();
                        f5.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    break;

                case 5:     //Main Menu
                    if (finger == 1)    //PDF reader
                    { 
                        f5.Hide(); 
                        id = 2;
                        f2.Show();
                        f2.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    else if (finger == 2) //MP3 player
                    {
                        f5.Hide();
                        id = 3;
                        f3.Show();
                        f3.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    else if (finger == 3) //Instruction
                    {
                        f5.Hide();
                        id = 6;
                        f6.setVoiceInstruction();
                        f6.Show();
                        f6.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    else if (hands == 2)    //EXIT
                    {

                        Thread.Sleep(sleeptime);
                    }
                    break;
                
                case 4: //Player
                    if (finger == 5) //Pause-Play
                    {
                        f4.PausePlay();
                        Thread.Sleep(sleeptime);
                    }
                    else if (gestures[0].Type == Gesture.GestureType.TYPECIRCLE) //Start-Stop
                    {
                        f4.StartStop();
                        Thread.Sleep(sleeptime);
                    }
                    else if (position > 15.0)   //next
                    {
                        f4.Next();
                        Thread.Sleep(sleeptime);
                    }
                    else if (position < -20)    //previous
                    {
                        f4.Previous();
                        Thread.Sleep(sleeptime);
                    }
                    else if (hands == 2)    //Back
                    {
                        f4.Back();
                        f4.Hide();
                        id = 3;
                        f3.Show();
                        f3.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    break;

                case 3: //MP3 Menu 
                    if (gestures[0].Type == Gesture.GestureType.TYPECIRCLE) //Start
                    {
                        f3.Start();
                        Thread.Sleep(sleeptime);
                    }
                    else if (gestures[0].Type == Gesture.GestureType.TYPEKEYTAP) //Select
                    {
                        if (f3.SelectMP3())
                        {
                            f3.Hide();
                            id = 4;
                            f4.setMediaPlayer(f3.SelectedMP3, f3.SongId);
                            f4.Show();
                            f4.WindowState = FormWindowState.Maximized;
                            Thread.Sleep(sleeptime);
                        }
                    }
                    else if (finger == 5)   //pause-play
                    {
                        f3.PausePlay();
                        Thread.Sleep(sleeptime);
                    }
                    else if (position > 15.0)   //next
                    {
                        f3.Next();
                        Thread.Sleep(sleeptime);
                    }
                    else if (position < -20)    //previous
                    {
                        f3.Previous();
                        Thread.Sleep(sleeptime);
                    }
                    else if (hands == 2)    //Back
                    {
                        f3.Back();
                        f3.Hide();
                        id = 5;
                        f5.Show();
                        f5.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    break;

                case 2: //PDF reader menu
                    if (gestures[0].Type == Gesture.GestureType.TYPECIRCLE) //Start
                    {
                        f2.Start();
                        Thread.Sleep(sleeptime);
                    }
                    else if (gestures[0].Type == Gesture.GestureType.TYPEKEYTAP) //Select
                    {
                        if (f2.SelectPDF())
                        {
                            f2.Hide();
                            id = 1;
                            f1.setPdfReader(f2.SelectedPDF);
                            f1.Show();
                            f1.WindowState = FormWindowState.Maximized;
                            Thread.Sleep(sleeptime);
                        }
                    }
                    else if (finger == 5) //Play-Pause
                    {
                        f2.PausePlay();
                        Thread.Sleep(sleeptime);
                    }
                    else if (hands == 2) //Back
                    {
                        f2.Back();
                        f2.Hide();
                        id = 5;
                        f5.Show();
                        f5.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    else if (position > 15.0)   //next
                    {
                        f2.Next();
                        Thread.Sleep(sleeptime);
                    }
                    else if (position < -20)    //previous
                    {
                        f2.Previous();
                        Thread.Sleep(sleeptime);
                    }
                    break;

                case 1:  //Reader 
                    if (gestures[0].Type == Gesture.GestureType.TYPECIRCLE)  //Start
                    {
                        f1.Start();
                        Thread.Sleep(sleeptime);
                    }
                    else if (finger == 5)  //PausePlay
                    {
                        f1.PausePlay();
                        Thread.Sleep(sleeptime);
                    }
                    else if (hands == 2) //Back
                    {
                        f1.Back();
                        f1.Hide();
                        id = 2;
                        f2.Show();
                        f2.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    else if (position > 15.0)   //next
                    {
                        f1.Next();
                        Thread.Sleep(sleeptime);
                    }
                    else if (position < -20)    //previous
                    {
                        f1.Previous();
                        Thread.Sleep(sleeptime);
                    }
                    break;

                case 6:
                    if (finger == 5) //Pause-Play
                    {
                        f6.PausePlay();
                        Thread.Sleep(sleeptime);
                    }
                    else if (gestures[0].Type == Gesture.GestureType.TYPECIRCLE) //Start-Stop
                    {
                        f6.StartStop();
                        Thread.Sleep(sleeptime);
                    }
                    else if (position > 15.0)   //next
                    {
                        f6.Next();
                        Thread.Sleep(sleeptime);
                    }
                    else if (position < -20)    //previous
                    {
                        f6.Previous();
                        Thread.Sleep(sleeptime);
                    }
                    else if (hands == 2)    //Back
                    {
                        f6.Back();
                        f6.Hide();
                        id = 5;
                        f5.Show();
                        f5.WindowState = FormWindowState.Maximized;
                        Thread.Sleep(sleeptime);
                    }
                    break;
            }
        } 

        private void Form1_Load(object sender, EventArgs e)
        { 
            l.FrameReceived += this.NewFrameReceived; 
        } 
    
        private void ControlForm_Load(object sender, EventArgs e)
        {

        }
    }
}
