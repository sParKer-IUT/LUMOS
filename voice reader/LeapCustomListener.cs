
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
    public class LeapCustomListener : Listener
    {
        public Boolean EnableLogging = false;
        public Controller controller;
        public LeapCustomListener()
        {
            // Empty Constructor
            OnFrame(controller);
            FrameReceived += NewFrameReceived;

            EnableLogging = true;
        }

        private void NewFrameReceived(Controller controller)
        {
            Frame frame = controller.Frame();
            GestureList gestures = frame.Gestures();
            int finger = frame.Fingers.Count;
            //MessageBox.Show(finger.ToString());

            //Gframe = frame;
            //Ggestures = gestures;
        }

        public delegate void OnLeapMotionDeviceOnLine(Controller deviceController);
        public event OnLeapMotionDeviceOnLine LeapMotionDeviceOnLine;


        public delegate void OnFrameReceived(Controller controller);
        public event OnFrameReceived FrameReceived;
       

        public override void OnConnect(Controller controller)
        {
            //Lets fire an event when the device gets connected

            if (this.LeapMotionDeviceOnLine != null&& EnableLogging == true)
            {
                this.LeapMotionDeviceOnLine(controller);
            }

            controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESWIPE);

        }


        public override void  OnFrame(Controller controller)
        {
            if (this.FrameReceived != null && EnableLogging == true)
            {
                this.FrameReceived(controller);
            }
        }
    }
}
