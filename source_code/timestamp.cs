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


        private List<List<object>> stampList = new List<List<object>>();

        private List<object> alertList = new List<object>();
        private List<object> pingList = new List<object>();
        private List<object> publishList = new List<object>();
        private List<object> onlineList = new List<object>();


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


        private void populate(string name)
        {

            foreach (List<object> item in stampList)
            {
                if (item[0].ToString() == name)
                {

                    addTimeStamp = Convert.ToBoolean(item[1]);
                    inFormat = item[2].ToString();
                    inColour = item[3].ToString();
                    inPosition = item[4].ToString();
                    txtRect = Convert.ToBoolean(item[5]);
                    showStats = Convert.ToBoolean(item[6]);
                    includeStats = Convert.ToBoolean(item[7]);

                    addStamp.Checked = addTimeStamp;
                    groupBox1.Enabled = addStamp.Checked;
                    groupBox3.Enabled = addStamp.Checked;
                    stampColour.Enabled = addStamp.Checked;
                    stampType.Enabled = addStamp.Checked;
                    tl.Checked = inPosition == "tl";
                    tr.Checked = inPosition == "tr";
                    bl.Checked = inPosition == "bl";
                    br.Checked = inPosition == "br";



                }

            }
        
        
        }


        private void apply_Click(object sender, EventArgs e)
        {
            ArrayList i = new ArrayList();
            i.Add(fromString);

            //i[1]
            i.Add(addStamp.Checked);
            //i[2]
            i.Add(stampTypesetting());
            //i[3]
            i.Add(stampColoursetting());
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

        private string stampColoursetting()
        {

            switch (stampColour.SelectedIndex)
            {

                case 1:
                    return "black";
                case 0:
                    return "red";
                case 2:
                    return "white";
                default:
                    return "black";
            }

        }

        private string stampTypesetting()
        {

            switch (stampType.SelectedIndex)
            {

                case 1:
                    return "hhmm";
                case 0:
                    return "ddmmyy";
                case 2:
                    return "ddmmyyhhmm";
                case 3:
                    return "analogue";
                default:
                    return "hhmm";
            }

        }


        private void timestamp_Load(object sender, EventArgs e)
        {

            statsBox.Enabled = showStats;

            label1.Text = fromString + " image";

            addStamp.Checked = addTimeStamp;
            groupBox1.Enabled = addStamp.Checked;
            groupBox3.Enabled = addStamp.Checked;

            stampColour.Enabled = addStamp.Checked;
            stampType.Enabled = addStamp.Checked;


            switch (inFormat)
            {

                case "hhmm":
                    stampType.SelectedIndex = 1;
                    break;
                case "ddmmyy":
                    stampType.SelectedIndex = 0;
                    break;
                case "ddmmyyhhmm":
                    stampType.SelectedIndex = 2;
                    break;
                case "analogue":
                    stampType.SelectedIndex = 3;
                    break;
                default:
                    stampType.SelectedIndex = 0;
                    break;
            }

            switch (inColour)
            {

                case "black":
                    stampColour.SelectedIndex = 1;
                    break;
                case "red":
                    stampColour.SelectedIndex = 0;
                    break;
                case "white":
                    stampColour.SelectedIndex = 2;
                    break;
                default:
                    stampColour.SelectedIndex = 0;
                    break;
            }




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
            groupBox3.Enabled = addStamp.Checked;

            stampColour.Enabled = addStamp.Checked;
            stampType.Enabled = addStamp.Checked;

        }




    }
}
