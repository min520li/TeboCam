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
    public partial class timestamp : Form
    {

        private formDelegate timestampDelegate;
        private string fromString;
        private bool addTimeStamp;
        private string inFormat;
        private string inColour;
        private string inPosition;
        private bool txtRect;
        private bool toolTip;
        private bool showStats;
        private bool includeStats;


        public timestamp(formDelegate sender, ArrayList from)
        {
            timestampDelegate = sender;
            fromString = from[0].ToString();
            addTimeStamp = Convert.ToBoolean(from[1]);
            inFormat = from[2].ToString();
            inColour = from[3].ToString();
            inPosition = from[4].ToString();
            txtRect = Convert.ToBoolean(from[5]);
            showStats = Convert.ToBoolean(from[6]);
            includeStats = Convert.ToBoolean(from[7]);
            toolTip = Convert.ToBoolean(from[8]);
            InitializeComponent();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            ArrayList i = new ArrayList();
            i.Add(fromString);

            //i[1]
            i.Add(addStamp.Checked);
            //i[2]
            if (hhmm.Checked) i.Add("hhmm");
            if (ddmmyy.Checked) i.Add("ddmmyy");
            if (ddmmyyhhmm.Checked) i.Add("ddmmyyhhmm");
            if (analogue.Checked) i.Add("analogue");
            //i[3]
            if (black.Checked) i.Add("black");
            if (white.Checked) i.Add("white");
            if (red.Checked) i.Add("red");
            //i[4]
            if (tl.Checked) i.Add("tl");
            if (tr.Checked) i.Add("tr");
            if (bl.Checked) i.Add("bl");
            if (br.Checked) i.Add("br");
            //i[5]
            i.Add(drawRect.Checked);
            //i[6]
            i.Add(statsChk.Checked);

            timestampDelegate(i);
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timestamp_Load(object sender, EventArgs e)
        {

            statsBox.Enabled = showStats;

            label1.Text = fromString + " image";

            addStamp.Checked = addTimeStamp;
            groupBox1.Enabled = addStamp.Checked;
            groupBox2.Enabled = addStamp.Checked;
            groupBox3.Enabled = addStamp.Checked;
            groupBox16.Enabled = addStamp.Checked;

            hhmm.Checked = inFormat == "hhmm";
            ddmmyy.Checked = inFormat == "ddmmyy";
            ddmmyyhhmm.Checked = inFormat == "ddmmyyhhmm";
            analogue.Checked = inFormat == "analogue";

            black.Checked = inColour == "black";
            red.Checked = inColour == "red";
            white.Checked = inColour == "white";

            tl.Checked = inPosition == "tl";
            tr.Checked = inPosition == "tr";
            bl.Checked = inPosition == "bl";
            br.Checked = inPosition == "br";

            drawRect.Checked = txtRect;

            if (showStats)
            {
                statsChk.Checked = includeStats;
            }
            else
            {
                statsChk.Checked = false;
            }

            toolTip1.Active = toolTip;

        }

        private void addStamp_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = addStamp.Checked;
            groupBox2.Enabled = addStamp.Checked;
            groupBox3.Enabled = addStamp.Checked;
            groupBox16.Enabled = addStamp.Checked;
        }


    }
}
