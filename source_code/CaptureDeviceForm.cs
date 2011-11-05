using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using dshow;
using dshow.Core;

namespace TeboCam
{
    /// <summary>
    /// Summary description for CaptureDeviceForm.
    /// </summary>
    public class CaptureDeviceForm : System.Windows.Forms.Form
    {
        FilterCollection filters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox deviceCombo;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private string device;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Device
        public string Device
        {
            get { return device; }
        }

        // Constructor
        public CaptureDeviceForm(string dvc)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            try
            {
                filters = new FilterCollection(FilterCategory.VideoInputDevice);

                if (filters.Count == 0)
                    throw new ApplicationException();

                // add all devices to combo
                foreach (Filter filter in filters)
                {
                    deviceCombo.Items.Add(filter.Name);
                }

                // number the webcams in case there are more than one of the same type present
                int tmpInt = 0;
                foreach (Filter filter in filters)
                {

                    int cnt = 1;
                    for (int i = tmpInt + 1; i < filters.Count; i++)
                    {
                        deviceCombo.Items[tmpInt] = cnt.ToString() + " - " + deviceCombo.Items[tmpInt].ToString();
                        cnt++;
                        deviceCombo.Items[i] = cnt.ToString() + " - " + deviceCombo.Items[i].ToString();
                        cnt++;
                    }

                    tmpInt++;

                }

                // set the selected index to the current webcam
                if (dvc != null)
                {

                    for (int i = 0; i < filters.Count; i++)
                    {

                        if (filters[i].MonikerString.ToString() == dvc)
                        { deviceCombo.SelectedIndex = i; }

                    }

                }


            }
            catch (ApplicationException)
            {
                deviceCombo.Items.Add("No local capture devices");
                deviceCombo.Enabled = false;
                okButton.Enabled = false;
            }

            if (deviceCombo.SelectedIndex == -1) deviceCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureDeviceForm));
            this.label1 = new System.Windows.Forms.Label();
            this.deviceCombo = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a webcam";
            // 
            // deviceCombo
            // 
            this.deviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceCombo.Location = new System.Drawing.Point(10, 30);
            this.deviceCombo.Name = "deviceCombo";
            this.deviceCombo.Size = new System.Drawing.Size(325, 21);
            this.deviceCombo.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(180, 78);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(90, 78);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // CaptureDeviceForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(344, 113);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.deviceCombo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureDeviceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Webcam";
            this.ResumeLayout(false);

        }
        #endregion

        // On "Ok" button
        private void okButton_Click(object sender, System.EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(filters[deviceCombo.SelectedIndex].MonikerString.ToString());
            device = filters[deviceCombo.SelectedIndex].MonikerString;
        }
    }
}
