namespace voice_reader
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.AutoSize = global::voice_reader.Properties.Settings.Default.IsMdiContainer;
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DataBindings.Add(new System.Windows.Forms.Binding("AutoSize", global::voice_reader.Properties.Settings.Default, "IsMdiContainer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button2.Location = new System.Drawing.Point(567, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 39);
            this.button2.TabIndex = 5;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(60, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.BurlyWood;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Location = new System.Drawing.Point(183, 84);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 39);
            this.button6.TabIndex = 3;
            this.button6.Text = "Select";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.OliveDrab;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(313, 84);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 39);
            this.button5.TabIndex = 2;
            this.button5.Text = "Previous";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkKhaki;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(443, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 39);
            this.button4.TabIndex = 1;
            this.button4.Text = "Next";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(726, 84);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(576, 576);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button7
            // 
            this.button7.AutoSize = global::voice_reader.Properties.Settings.Default.IsMdiContainer;
            this.button7.BackColor = System.Drawing.Color.MediumOrchid;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.DataBindings.Add(new System.Windows.Forms.Binding("AutoSize", global::voice_reader.Properties.Settings.Default, "IsMdiContainer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button7.Location = new System.Drawing.Point(313, 154);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 39);
            this.button7.TabIndex = 7;
            this.button7.Text = "Back";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImage = global::voice_reader.Properties.Resources.pdfreader;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 742);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.richTextBox1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("IsMdiContainer", global::voice_reader.Properties.Settings.Default, "False", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IsMdiContainer = global::voice_reader.Properties.Settings.Default.False;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button7;



    }
}