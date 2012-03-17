using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TeboCam
{
    public partial class fileprefix : Form
    {
        private formDelegate prefixDelegate;
        private string fromString;
        private bool toolTip;
        private string i_fname;
        private string i_cycleStampChecked;
        private string i_startCycle;
        private string i_endCycle;
        private string i_currentCycle;
        private bool i_includeStamp;
        private string i_fileLoc = "";
        private string i_fileLocDefault = "";
        private bool i_displayStamp;
        //private bool i_pubcust;

        private string fileLoc;

        public fileprefix(formDelegate sender, ArrayList from)
        {
            InitializeComponent();

            prefixDelegate = sender;
            fromString = from[0].ToString();
            toolTip = Convert.ToBoolean(from[1]);
            i_fname = from[2].ToString();
            i_cycleStampChecked = from[3].ToString();
            i_startCycle = from[4].ToString();
            i_endCycle = from[5].ToString();
            i_currentCycle = from[6].ToString();
            i_includeStamp = Convert.ToBoolean(from[7]);
            i_displayStamp = Convert.ToBoolean(from[8]);
            groupBox21.Enabled = Convert.ToBoolean(from[12]);

            if (Convert.ToBoolean(from[12]))
            {
                i_fileLoc = from[9].ToString();
                i_fileLocDefault = from[10].ToString();
            }
            //i_pubcust = Convert.ToBoolean(from[11]);


        }

        private void fileprefix_Load(object sender, EventArgs e)
        {

            lblTitle.Text = fromString + " Filename Prefix";
            filenamePrefix.Text = i_fname;
            cycleStamp.Checked = i_cycleStampChecked == "1";
            timeStamp.Checked = !cycleStamp.Checked;
            startCycle.Text = i_startCycle;
            endCycle.Text = i_endCycle;
            currentCycle.Text = i_currentCycle;
            checkBox1.Checked = i_includeStamp;
            checkBox1.Enabled = i_displayStamp;
            if (i_displayStamp) groupBox2.Enabled = checkBox1.Checked;
            //radioButton10.Checked = !i_pubcust;
            //radioButton11.Checked = i_pubcust;
            fileLoc = i_fileLoc;

            if (i_fileLoc.TrimEnd('\\') == i_fileLocDefault.TrimEnd('\\'))
            {

                radioButton10.Checked = true;
                radioButton11.Checked = false;

            }
            else
            {

                radioButton10.Checked = false;
                radioButton11.Checked = true;

            }

            toolTip1.Active = toolTip;

        }


        private void filenamePrefix_Leave(object sender, EventArgs e)
        {


            filenamePrefix.Text = filenamePrefix.Text.Trim();

            if (!bubble.filenamePrefixValid(filenamePrefix.Text))
            {
                bubble.messageAlert("Filename prefix can only contain a-z and 0-9.", "Invalid filename prefix");
                filenamePrefix.BackColor = Color.Red;
                if (filenamePrefix.Text == "") { filenamePrefix.Text = "TeboCam"; }; filenamePrefix.Focus();
                Invalidate();
            }

            else
            {
                filenamePrefix.BackColor = Color.LemonChiffon;
            }




        }

        private void fileprefix_FormClosing(object sender, FormClosingEventArgs e)
        {

            ArrayList i = new ArrayList();

            i.Add(fromString);
            i.Add(filenamePrefix.Text);
            if (cycleStamp.Checked) i.Add(1); else i.Add(2);
            i.Add(startCycle.Text);
            i.Add(endCycle.Text);
            i.Add(currentCycle.Text);
            i.Add(checkBox1.Checked);
            i.Add(fileLoc);
            i.Add(radioButton11.Checked);

            prefixDelegate(i); // This will call ReturnMethod in form1 and pass it val.

        }

        private void startCycle_Leave(object sender, EventArgs e)
        {
            startCycle.Text = bubble.verifyInt(startCycle.Text, bubble.cycleMin, bubble.cycleMax - 1, bubble.cycleMin.ToString());
        }

        private void endCycle_Leave(object sender, EventArgs e)
        {
            endCycle.Text = bubble.verifyInt(endCycle.Text, bubble.cycleMin + 1, bubble.cycleMax, bubble.cycleMax.ToString());
        }

        private void currentCycle_Leave(object sender, EventArgs e)
        {
            currentCycle.Text = bubble.verifyInt(currentCycle.Text, Convert.ToInt64(startCycle.Text), Convert.ToInt64(endCycle.Text), startCycle.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = checkBox1.Checked;
        }

        private void button21_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = fileLoc;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileLoc = dialog.SelectedPath;
            }

            if (!fileLoc.EndsWith("\\")) fileLoc += "\\";

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

            button21.Enabled = radioButton11.Checked;
            if (radioButton10.Checked) fileLoc = i_fileLocDefault;


        }


    }
}