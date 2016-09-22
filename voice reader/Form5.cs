using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voice_reader
{
    public partial class Form5 : Form
    {
        ControlForm cf;
        public Form5(ControlForm C)
        {
            InitializeComponent();
            cf = C;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
        
       //for mouse hovering...
        /*private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.ForeColor = Color.White;
        }
        private void label22_MouseEnter(object sender, EventArgs e)
        {
            this.label2.ForeColor = Color.White;
        }
        private void label3_MouseEnter(object sender, EventArgs e)
        {
            this.label3.ForeColor = Color.White;
        }
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            this.label4.ForeColor = Color.White;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.ForeColor = Color.DarkOrchid;
        }
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.label2.ForeColor = Color.LimeGreen;
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.label3.ForeColor = Color.Crimson;
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.label4.ForeColor = Color.Gray;
        }*/
        //....................

        private void label1_Click(object sender, EventArgs e)
        {

            cf.id=2;
            cf.f2.Show();
            this.Hide();
        }
        

        private void label2_Click(object sender, EventArgs e)
        {
            //Form3 f3 = new Form3();
            //f3.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            //this.Hide();
            //f3.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
               
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        



    }
}
