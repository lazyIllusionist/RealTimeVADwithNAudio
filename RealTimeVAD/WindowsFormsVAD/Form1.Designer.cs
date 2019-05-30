namespace WindowsFormsVAD
{
    partial class Form1
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
            this.StartButton = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.waveformPainter1 = new NAudio.Gui.WaveformPainter();
            this.boolPanel = new System.Windows.Forms.Panel();
            this.zeroCounterLabel1 = new System.Windows.Forms.Label();
            this.zeroCounterLabel2 = new System.Windows.Forms.Label();
            this.zeroCounterLabel3 = new System.Windows.Forms.Label();
            this.zeroCounterLabel4 = new System.Windows.Forms.Label();
            this.zeroCounterLabel5 = new System.Windows.Forms.Label();
            this.zeroCounterLabel6 = new System.Windows.Forms.Label();
            this.zeroCounterLabel7 = new System.Windows.Forms.Label();
            this.zeroCounterLabel8 = new System.Windows.Forms.Label();
            this.zeroCounterLabel9 = new System.Windows.Forms.Label();
            this.zeroCounterLabel10 = new System.Windows.Forms.Label();
            this.framesComboBox = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(517, 26);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(105, 41);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point(12, 26);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(463, 357);
            this.Panel.TabIndex = 1;
            // 
            // waveformPainter1
            // 
            this.waveformPainter1.Location = new System.Drawing.Point(677, 287);
            this.waveformPainter1.Name = "waveformPainter1";
            this.waveformPainter1.Size = new System.Drawing.Size(75, 23);
            this.waveformPainter1.TabIndex = 2;
            this.waveformPainter1.Text = "waveformPainter1";
            this.waveformPainter1.Click += new System.EventHandler(this.WaveformPainter1_Click);
            // 
            // boolPanel
            // 
            this.boolPanel.BackColor = System.Drawing.Color.Red;
            this.boolPanel.Location = new System.Drawing.Point(517, 98);
            this.boolPanel.Name = "boolPanel";
            this.boolPanel.Size = new System.Drawing.Size(105, 75);
            this.boolPanel.TabIndex = 3;
            // 
            // zeroCounterLabel1
            // 
            this.zeroCounterLabel1.AutoSize = true;
            this.zeroCounterLabel1.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel1.Location = new System.Drawing.Point(12, 403);
            this.zeroCounterLabel1.Name = "zeroCounterLabel1";
            this.zeroCounterLabel1.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel1.TabIndex = 4;
            this.zeroCounterLabel1.Text = "100";
            this.zeroCounterLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroCounterLabel2
            // 
            this.zeroCounterLabel2.AutoSize = true;
            this.zeroCounterLabel2.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel2.Location = new System.Drawing.Point(50, 403);
            this.zeroCounterLabel2.Name = "zeroCounterLabel2";
            this.zeroCounterLabel2.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel2.TabIndex = 5;
            this.zeroCounterLabel2.Text = "100";
            this.zeroCounterLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zeroCounterLabel2.Click += new System.EventHandler(this.Label1_Click);
            // 
            // zeroCounterLabel3
            // 
            this.zeroCounterLabel3.AutoSize = true;
            this.zeroCounterLabel3.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel3.Location = new System.Drawing.Point(88, 403);
            this.zeroCounterLabel3.Name = "zeroCounterLabel3";
            this.zeroCounterLabel3.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel3.TabIndex = 6;
            this.zeroCounterLabel3.Text = "100";
            this.zeroCounterLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroCounterLabel4
            // 
            this.zeroCounterLabel4.AutoSize = true;
            this.zeroCounterLabel4.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel4.Location = new System.Drawing.Point(126, 403);
            this.zeroCounterLabel4.Name = "zeroCounterLabel4";
            this.zeroCounterLabel4.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel4.TabIndex = 7;
            this.zeroCounterLabel4.Text = "100";
            this.zeroCounterLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroCounterLabel5
            // 
            this.zeroCounterLabel5.AutoSize = true;
            this.zeroCounterLabel5.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel5.Location = new System.Drawing.Point(164, 403);
            this.zeroCounterLabel5.Name = "zeroCounterLabel5";
            this.zeroCounterLabel5.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel5.TabIndex = 8;
            this.zeroCounterLabel5.Text = "100";
            this.zeroCounterLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroCounterLabel6
            // 
            this.zeroCounterLabel6.AutoSize = true;
            this.zeroCounterLabel6.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel6.Location = new System.Drawing.Point(202, 403);
            this.zeroCounterLabel6.Name = "zeroCounterLabel6";
            this.zeroCounterLabel6.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel6.TabIndex = 9;
            this.zeroCounterLabel6.Text = "100";
            this.zeroCounterLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroCounterLabel7
            // 
            this.zeroCounterLabel7.AutoSize = true;
            this.zeroCounterLabel7.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel7.Location = new System.Drawing.Point(240, 403);
            this.zeroCounterLabel7.Name = "zeroCounterLabel7";
            this.zeroCounterLabel7.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel7.TabIndex = 10;
            this.zeroCounterLabel7.Text = "100";
            this.zeroCounterLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroCounterLabel8
            // 
            this.zeroCounterLabel8.AutoSize = true;
            this.zeroCounterLabel8.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel8.Location = new System.Drawing.Point(278, 403);
            this.zeroCounterLabel8.Name = "zeroCounterLabel8";
            this.zeroCounterLabel8.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel8.TabIndex = 11;
            this.zeroCounterLabel8.Text = "100";
            this.zeroCounterLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroCounterLabel9
            // 
            this.zeroCounterLabel9.AutoSize = true;
            this.zeroCounterLabel9.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel9.Location = new System.Drawing.Point(316, 403);
            this.zeroCounterLabel9.Name = "zeroCounterLabel9";
            this.zeroCounterLabel9.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel9.TabIndex = 12;
            this.zeroCounterLabel9.Text = "100";
            this.zeroCounterLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroCounterLabel10
            // 
            this.zeroCounterLabel10.AutoSize = true;
            this.zeroCounterLabel10.BackColor = System.Drawing.Color.Red;
            this.zeroCounterLabel10.Location = new System.Drawing.Point(354, 403);
            this.zeroCounterLabel10.Name = "zeroCounterLabel10";
            this.zeroCounterLabel10.Size = new System.Drawing.Size(32, 17);
            this.zeroCounterLabel10.TabIndex = 13;
            this.zeroCounterLabel10.Text = "100";
            this.zeroCounterLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // framesComboBox
            // 
            this.framesComboBox.FormattingEnabled = true;
            this.framesComboBox.Location = new System.Drawing.Point(517, 246);
            this.framesComboBox.Name = "framesComboBox";
            this.framesComboBox.Size = new System.Drawing.Size(183, 24);
            this.framesComboBox.TabIndex = 14;
            this.framesComboBox.SelectedIndexChanged += new System.EventHandler(this.FramesComboBox_SelectedIndexChanged);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.FolderBrowserDialog1_HelpRequest);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(517, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "Get .wav file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(639, 198);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(61, 33);
            this.Play.TabIndex = 16;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 440);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.framesComboBox);
            this.Controls.Add(this.zeroCounterLabel10);
            this.Controls.Add(this.zeroCounterLabel9);
            this.Controls.Add(this.zeroCounterLabel8);
            this.Controls.Add(this.zeroCounterLabel7);
            this.Controls.Add(this.zeroCounterLabel6);
            this.Controls.Add(this.zeroCounterLabel5);
            this.Controls.Add(this.zeroCounterLabel4);
            this.Controls.Add(this.zeroCounterLabel3);
            this.Controls.Add(this.zeroCounterLabel2);
            this.Controls.Add(this.zeroCounterLabel1);
            this.Controls.Add(this.boolPanel);
            this.Controls.Add(this.waveformPainter1);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Panel Panel;
        private NAudio.Gui.WaveformPainter waveformPainter1;
        private System.Windows.Forms.Panel boolPanel;
        private System.Windows.Forms.Label zeroCounterLabel1;
        private System.Windows.Forms.Label zeroCounterLabel2;
        private System.Windows.Forms.Label zeroCounterLabel3;
        private System.Windows.Forms.Label zeroCounterLabel4;
        private System.Windows.Forms.Label zeroCounterLabel5;
        private System.Windows.Forms.Label zeroCounterLabel6;
        private System.Windows.Forms.Label zeroCounterLabel7;
        private System.Windows.Forms.Label zeroCounterLabel8;
        private System.Windows.Forms.Label zeroCounterLabel9;
        private System.Windows.Forms.Label zeroCounterLabel10;
        private System.Windows.Forms.ComboBox framesComboBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Play;
    }
}

