namespace TeboCam
{
    partial class timestamp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(timestamp));
            this.label32 = new System.Windows.Forms.Label();
            this.apply = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.addStamp = new System.Windows.Forms.CheckBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.ddmmyyhhmm = new System.Windows.Forms.RadioButton();
            this.hhmm = new System.Windows.Forms.RadioButton();
            this.ddmmyy = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.br = new System.Windows.Forms.RadioButton();
            this.bl = new System.Windows.Forms.RadioButton();
            this.tr = new System.Windows.Forms.RadioButton();
            this.tl = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.white = new System.Windows.Forms.RadioButton();
            this.black = new System.Windows.Forms.RadioButton();
            this.red = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.drawRect = new System.Windows.Forms.CheckBox();
            this.statsBox = new System.Windows.Forms.GroupBox();
            this.statsChk = new System.Windows.Forms.CheckBox();
            this.groupBox16.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(64, 9);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(139, 23);
            this.label32.TabIndex = 48;
            this.label32.Text = "Time Stamp";
            // 
            // apply
            // 
            this.apply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apply.Location = new System.Drawing.Point(169, 191);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(111, 96);
            this.apply.TabIndex = 64;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(286, 191);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(121, 96);
            this.cancel.TabIndex = 65;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipTitle = "Tip";
            // 
            // addStamp
            // 
            this.addStamp.AutoSize = true;
            this.addStamp.BackColor = System.Drawing.SystemColors.Control;
            this.addStamp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.addStamp.Location = new System.Drawing.Point(12, 44);
            this.addStamp.Name = "addStamp";
            this.addStamp.Size = new System.Drawing.Size(226, 17);
            this.addStamp.TabIndex = 69;
            this.addStamp.Text = "Add date/time stamp to image";
            this.toolTip1.SetToolTip(this.addStamp, "Enable or disable webcam image publishing to webpage.");
            this.addStamp.UseVisualStyleBackColor = false;
            this.addStamp.CheckedChanged += new System.EventHandler(this.addStamp_CheckedChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.ddmmyyhhmm);
            this.groupBox16.Controls.Add(this.hhmm);
            this.groupBox16.Controls.Add(this.ddmmyy);
            this.groupBox16.Location = new System.Drawing.Point(12, 77);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(145, 102);
            this.groupBox16.TabIndex = 67;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Time Stamp";
            // 
            // ddmmyyhhmm
            // 
            this.ddmmyyhhmm.AutoSize = true;
            this.ddmmyyhhmm.Location = new System.Drawing.Point(6, 66);
            this.ddmmyyhhmm.Name = "ddmmyyhhmm";
            this.ddmmyyhhmm.Size = new System.Drawing.Size(124, 17);
            this.ddmmyyhhmm.TabIndex = 2;
            this.ddmmyyhhmm.TabStop = true;
            this.ddmmyyhhmm.Text = "dd-mmm-yy hh:mm:ss";
            this.ddmmyyhhmm.UseVisualStyleBackColor = true;
            // 
            // hhmm
            // 
            this.hhmm.AutoSize = true;
            this.hhmm.Location = new System.Drawing.Point(6, 43);
            this.hhmm.Name = "hhmm";
            this.hhmm.Size = new System.Drawing.Size(69, 17);
            this.hhmm.TabIndex = 1;
            this.hhmm.TabStop = true;
            this.hhmm.Text = "hh:mm:ss";
            this.hhmm.UseVisualStyleBackColor = true;
            // 
            // ddmmyy
            // 
            this.ddmmyy.AutoSize = true;
            this.ddmmyy.Checked = true;
            this.ddmmyy.Location = new System.Drawing.Point(6, 19);
            this.ddmmyy.Name = "ddmmyy";
            this.ddmmyy.Size = new System.Drawing.Size(77, 17);
            this.ddmmyy.TabIndex = 0;
            this.ddmmyy.TabStop = true;
            this.ddmmyy.Text = "dd-mmm-yy";
            this.ddmmyy.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.br);
            this.groupBox1.Controls.Add(this.bl);
            this.groupBox1.Controls.Add(this.tr);
            this.groupBox1.Controls.Add(this.tl);
            this.groupBox1.Location = new System.Drawing.Point(286, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 102);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Position";
            // 
            // br
            // 
            this.br.AutoSize = true;
            this.br.Location = new System.Drawing.Point(86, 68);
            this.br.Name = "br";
            this.br.Size = new System.Drawing.Size(14, 13);
            this.br.TabIndex = 3;
            this.br.UseVisualStyleBackColor = true;
            // 
            // bl
            // 
            this.bl.AutoSize = true;
            this.bl.Location = new System.Drawing.Point(18, 68);
            this.bl.Name = "bl";
            this.bl.Size = new System.Drawing.Size(14, 13);
            this.bl.TabIndex = 2;
            this.bl.UseVisualStyleBackColor = true;
            // 
            // tr
            // 
            this.tr.AutoSize = true;
            this.tr.Location = new System.Drawing.Point(86, 29);
            this.tr.Name = "tr";
            this.tr.Size = new System.Drawing.Size(14, 13);
            this.tr.TabIndex = 1;
            this.tr.UseVisualStyleBackColor = true;
            // 
            // tl
            // 
            this.tl.AutoSize = true;
            this.tl.Checked = true;
            this.tl.Location = new System.Drawing.Point(18, 29);
            this.tl.Name = "tl";
            this.tl.Size = new System.Drawing.Size(14, 13);
            this.tl.TabIndex = 0;
            this.tl.TabStop = true;
            this.tl.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.white);
            this.groupBox2.Controls.Add(this.black);
            this.groupBox2.Controls.Add(this.red);
            this.groupBox2.Location = new System.Drawing.Point(169, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 102);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text Colour";
            // 
            // white
            // 
            this.white.AutoSize = true;
            this.white.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.white.ForeColor = System.Drawing.Color.White;
            this.white.Location = new System.Drawing.Point(6, 66);
            this.white.Name = "white";
            this.white.Size = new System.Drawing.Size(58, 17);
            this.white.TabIndex = 2;
            this.white.TabStop = true;
            this.white.Text = "White";
            this.white.UseVisualStyleBackColor = true;
            // 
            // black
            // 
            this.black.AutoSize = true;
            this.black.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.black.Location = new System.Drawing.Point(6, 43);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(57, 17);
            this.black.TabIndex = 1;
            this.black.TabStop = true;
            this.black.Text = "Black";
            this.black.UseVisualStyleBackColor = true;
            // 
            // red
            // 
            this.red.AutoSize = true;
            this.red.Checked = true;
            this.red.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red.ForeColor = System.Drawing.Color.Red;
            this.red.Location = new System.Drawing.Point(6, 19);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(48, 17);
            this.red.TabIndex = 0;
            this.red.TabStop = true;
            this.red.Text = "Red";
            this.red.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(244, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 70;
            this.label1.Text = "Apply To...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.drawRect);
            this.groupBox3.Location = new System.Drawing.Point(12, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 48);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Text Background";
            // 
            // drawRect
            // 
            this.drawRect.AutoSize = true;
            this.drawRect.Location = new System.Drawing.Point(6, 19);
            this.drawRect.Name = "drawRect";
            this.drawRect.Size = new System.Drawing.Size(103, 17);
            this.drawRect.TabIndex = 72;
            this.drawRect.Text = "Draw Rectangle";
            this.drawRect.UseVisualStyleBackColor = true;
            // 
            // statsBox
            // 
            this.statsBox.Controls.Add(this.statsChk);
            this.statsBox.Location = new System.Drawing.Point(12, 239);
            this.statsBox.Name = "statsBox";
            this.statsBox.Size = new System.Drawing.Size(145, 48);
            this.statsBox.TabIndex = 73;
            this.statsBox.TabStop = false;
            this.statsBox.Text = "Publish timestamp Stats";
            // 
            // statsChk
            // 
            this.statsChk.AutoSize = true;
            this.statsChk.Location = new System.Drawing.Point(6, 19);
            this.statsChk.Name = "statsChk";
            this.statsChk.Size = new System.Drawing.Size(106, 17);
            this.statsChk.TabIndex = 72;
            this.statsChk.Text = "Include Statistics";
            this.statsChk.UseVisualStyleBackColor = true;
            // 
            // timestamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 298);
            this.Controls.Add(this.statsBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addStamp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.label32);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "timestamp";
            this.Load += new System.EventHandler(this.timestamp_Load);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statsBox.ResumeLayout(false);
            this.statsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.RadioButton ddmmyyhhmm;
        private System.Windows.Forms.RadioButton hhmm;
        private System.Windows.Forms.RadioButton ddmmyy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton br;
        private System.Windows.Forms.RadioButton bl;
        private System.Windows.Forms.RadioButton tr;
        private System.Windows.Forms.RadioButton tl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton white;
        private System.Windows.Forms.RadioButton black;
        private System.Windows.Forms.RadioButton red;
        private System.Windows.Forms.CheckBox addStamp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox drawRect;
        private System.Windows.Forms.GroupBox statsBox;
        private System.Windows.Forms.CheckBox statsChk;
    }
}