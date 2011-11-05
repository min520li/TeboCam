namespace TeboCam
{
    partial class fileprefix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileprefix));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.filenamePrefix = new System.Windows.Forms.TextBox();
            this.startCycle = new System.Windows.Forms.TextBox();
            this.endCycle = new System.Windows.Forms.TextBox();
            this.currentCycle = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timeStamp = new System.Windows.Forms.RadioButton();
            this.cycleStamp = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipTitle = "Tip";
            // 
            // filenamePrefix
            // 
            this.filenamePrefix.BackColor = System.Drawing.Color.LemonChiffon;
            this.filenamePrefix.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenamePrefix.ForeColor = System.Drawing.SystemColors.WindowText;
            this.filenamePrefix.Location = new System.Drawing.Point(13, 45);
            this.filenamePrefix.Name = "filenamePrefix";
            this.filenamePrefix.Size = new System.Drawing.Size(401, 21);
            this.filenamePrefix.TabIndex = 67;
            this.filenamePrefix.Text = "webcam";
            this.toolTip1.SetToolTip(this.filenamePrefix, "This sets the prefix for the image files saved.");
            this.filenamePrefix.Leave += new System.EventHandler(this.filenamePrefix_Leave);
            // 
            // startCycle
            // 
            this.startCycle.BackColor = System.Drawing.Color.LemonChiffon;
            this.startCycle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startCycle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.startCycle.Location = new System.Drawing.Point(41, 40);
            this.startCycle.Name = "startCycle";
            this.startCycle.Size = new System.Drawing.Size(67, 21);
            this.startCycle.TabIndex = 68;
            this.startCycle.Text = "1";
            this.toolTip1.SetToolTip(this.startCycle, "The start cycle number for the name of the\r\nimage file saved. \r\n\r\nIf the prefix i" +
                    "s set to \"webcam\" the first file \r\ncreated will be called webcam1.jpg");
            this.startCycle.Leave += new System.EventHandler(this.startCycle_Leave);
            // 
            // endCycle
            // 
            this.endCycle.BackColor = System.Drawing.Color.LemonChiffon;
            this.endCycle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endCycle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.endCycle.Location = new System.Drawing.Point(143, 40);
            this.endCycle.Name = "endCycle";
            this.endCycle.Size = new System.Drawing.Size(67, 21);
            this.endCycle.TabIndex = 69;
            this.endCycle.Text = "999999";
            this.toolTip1.SetToolTip(this.endCycle, resources.GetString("endCycle.ToolTip"));
            this.endCycle.Leave += new System.EventHandler(this.endCycle_Leave);
            // 
            // currentCycle
            // 
            this.currentCycle.BackColor = System.Drawing.Color.LemonChiffon;
            this.currentCycle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCycle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.currentCycle.Location = new System.Drawing.Point(263, 40);
            this.currentCycle.Name = "currentCycle";
            this.currentCycle.Size = new System.Drawing.Size(147, 21);
            this.currentCycle.TabIndex = 70;
            this.currentCycle.Text = "1";
            this.toolTip1.SetToolTip(this.currentCycle, "This is the number that will be used for the next \r\nimage file created.");
            this.currentCycle.Leave += new System.EventHandler(this.currentCycle_Leave);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(13, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(281, 17);
            this.checkBox1.TabIndex = 79;
            this.checkBox1.Text = "Append Cycle/Date Stamp To Filename";
            this.toolTip1.SetToolTip(this.checkBox1, "Check this to append a stamp to the filename.");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timeStamp
            // 
            this.timeStamp.AutoSize = true;
            this.timeStamp.Location = new System.Drawing.Point(7, 74);
            this.timeStamp.Name = "timeStamp";
            this.timeStamp.Size = new System.Drawing.Size(14, 13);
            this.timeStamp.TabIndex = 78;
            this.timeStamp.UseVisualStyleBackColor = true;
            // 
            // cycleStamp
            // 
            this.cycleStamp.AutoSize = true;
            this.cycleStamp.Checked = true;
            this.cycleStamp.Location = new System.Drawing.Point(7, 43);
            this.cycleStamp.Name = "cycleStamp";
            this.cycleStamp.Size = new System.Drawing.Size(14, 13);
            this.cycleStamp.TabIndex = 77;
            this.cycleStamp.TabStop = true;
            this.cycleStamp.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(10, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(195, 13);
            this.label13.TabIndex = 72;
            this.label13.Text = "Filename Prefix e.g. webcam";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(21, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(71, 23);
            this.lblTitle.TabIndex = 71;
            this.lblTitle.Text = "TITLE";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(27, 73);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(239, 13);
            this.label41.TabIndex = 76;
            this.label41.Text = "Time Stamp (yyyyMMddHHmmssfff)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(38, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(197, 13);
            this.label14.TabIndex = 73;
            this.label14.Text = "Start And End Cycle Numbers";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(260, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 13);
            this.label15.TabIndex = 74;
            this.label15.Text = "Current Cycle Number";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(114, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 75;
            this.label16.Text = "To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.filenamePrefix);
            this.groupBox1.Location = new System.Drawing.Point(8, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 212);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.startCycle);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.timeStamp);
            this.groupBox2.Controls.Add(this.endCycle);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cycleStamp);
            this.groupBox2.Controls.Add(this.currentCycle);
            this.groupBox2.Location = new System.Drawing.Point(4, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 102);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            // 
            // fileprefix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 267);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fileprefix";
            this.Load += new System.EventHandler(this.fileprefix_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fileprefix_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton timeStamp;
        private System.Windows.Forms.RadioButton cycleStamp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox filenamePrefix;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox startCycle;
        private System.Windows.Forms.TextBox endCycle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox currentCycle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}