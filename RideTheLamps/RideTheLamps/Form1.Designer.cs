namespace RideTheLamps
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Ldataframe = new System.Windows.Forms.Label();
            this.Bstart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBsm2 = new System.Windows.Forms.RadioButton();
            this.RBsm1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBy = new System.Windows.Forms.RadioButton();
            this.RBx = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Bblink = new System.Windows.Forms.Button();
            this.Breset1 = new System.Windows.Forms.Button();
            this.Breset2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 19200;
            this.serialPort1.PortName = "COM4";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Ldataframe
            // 
            this.Ldataframe.AutoSize = true;
            this.Ldataframe.Location = new System.Drawing.Point(13, 55);
            this.Ldataframe.Name = "Ldataframe";
            this.Ldataframe.Size = new System.Drawing.Size(54, 13);
            this.Ldataframe.TabIndex = 0;
            this.Ldataframe.Text = "dataframe";
            // 
            // Bstart
            // 
            this.Bstart.Location = new System.Drawing.Point(12, 12);
            this.Bstart.Name = "Bstart";
            this.Bstart.Size = new System.Drawing.Size(75, 23);
            this.Bstart.TabIndex = 1;
            this.Bstart.Text = "Start";
            this.Bstart.UseVisualStyleBackColor = true;
            this.Bstart.Click += new System.EventHandler(this.Bstart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBsm2);
            this.groupBox1.Controls.Add(this.RBsm1);
            this.groupBox1.Location = new System.Drawing.Point(163, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 109);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Method";
            // 
            // RBsm2
            // 
            this.RBsm2.AutoSize = true;
            this.RBsm2.Location = new System.Drawing.Point(7, 43);
            this.RBsm2.Name = "RBsm2";
            this.RBsm2.Size = new System.Drawing.Size(61, 17);
            this.RBsm2.TabIndex = 1;
            this.RBsm2.Text = "Sel M 2";
            this.RBsm2.UseVisualStyleBackColor = true;
            // 
            // RBsm1
            // 
            this.RBsm1.AutoSize = true;
            this.RBsm1.Checked = true;
            this.RBsm1.Location = new System.Drawing.Point(7, 20);
            this.RBsm1.Name = "RBsm1";
            this.RBsm1.Size = new System.Drawing.Size(61, 17);
            this.RBsm1.TabIndex = 0;
            this.RBsm1.TabStop = true;
            this.RBsm1.Text = "Sel M 1";
            this.RBsm1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBy);
            this.groupBox2.Controls.Add(this.RBx);
            this.groupBox2.Location = new System.Drawing.Point(276, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 109);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Brightness Controll";
            // 
            // RBy
            // 
            this.RBy.AutoSize = true;
            this.RBy.Location = new System.Drawing.Point(6, 43);
            this.RBy.Name = "RBy";
            this.RBy.Size = new System.Drawing.Size(51, 17);
            this.RBy.TabIndex = 1;
            this.RBy.Text = "y axis";
            this.RBy.UseVisualStyleBackColor = true;
            // 
            // RBx
            // 
            this.RBx.AutoSize = true;
            this.RBx.Checked = true;
            this.RBx.Location = new System.Drawing.Point(6, 20);
            this.RBx.Name = "RBx";
            this.RBx.Size = new System.Drawing.Size(51, 17);
            this.RBx.TabIndex = 0;
            this.RBx.TabStop = true;
            this.RBx.Text = "x axis";
            this.RBx.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Bblink
            // 
            this.Bblink.Location = new System.Drawing.Point(16, 127);
            this.Bblink.Name = "Bblink";
            this.Bblink.Size = new System.Drawing.Size(75, 23);
            this.Bblink.TabIndex = 5;
            this.Bblink.Text = "Blink";
            this.Bblink.UseVisualStyleBackColor = true;
            this.Bblink.Click += new System.EventHandler(this.Bblink_Click);
            // 
            // Breset1
            // 
            this.Breset1.Location = new System.Drawing.Point(163, 127);
            this.Breset1.Name = "Breset1";
            this.Breset1.Size = new System.Drawing.Size(75, 23);
            this.Breset1.TabIndex = 7;
            this.Breset1.Text = "Reset";
            this.Breset1.UseVisualStyleBackColor = true;
            this.Breset1.Click += new System.EventHandler(this.Breset1_Click);
            // 
            // Breset2
            // 
            this.Breset2.Location = new System.Drawing.Point(276, 127);
            this.Breset2.Name = "Breset2";
            this.Breset2.Size = new System.Drawing.Size(75, 23);
            this.Breset2.TabIndex = 8;
            this.Breset2.Text = "Reset";
            this.Breset2.UseVisualStyleBackColor = true;
            this.Breset2.Click += new System.EventHandler(this.Breset2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 171);
            this.Controls.Add(this.Breset2);
            this.Controls.Add(this.Breset1);
            this.Controls.Add(this.Bblink);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Bstart);
            this.Controls.Add(this.Ldataframe);
            this.Name = "Form1";
            this.Text = "Ride the Lamps";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label Ldataframe;
        private System.Windows.Forms.Button Bstart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBsm2;
        private System.Windows.Forms.RadioButton RBsm1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBy;
        private System.Windows.Forms.RadioButton RBx;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Bblink;
        private System.Windows.Forms.Button Breset1;
        private System.Windows.Forms.Button Breset2;
    }
}

