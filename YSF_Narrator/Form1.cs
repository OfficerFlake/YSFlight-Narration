using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace YSF_Narrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string narrationPath = "./Narration/";
        List<Demonstration> demonstrations = new List<Demonstration>();
        Demonstration activedemonstration = null;
        Manoeuvre activemanoeuvre = null;
        Pilot activePilot = null;

        private void LoadFiles(object sender, EventArgs e)
        {
            #region Get All Demonstrations
            foreach (string thisFileName in Directory.GetFiles(narrationPath))
            {

                string[] thisFileLines = File.ReadAllLines(thisFileName);
                string outtemp = "";
                foreach(string templine in thisFileLines) {
                    if (templine == "") continue;
                    outtemp += templine + "\n";
                }
                outtemp = outtemp.Replace("\n", "%NEWLINE%");
                outtemp = outtemp.Replace(">%NEWLINE%", ">\n");
                thisFileLines = outtemp.Split('\n');
                #region Get Demonstration Details
                foreach (string thisLine in thisFileLines)
                {
                    if (thisLine.StartsWith("<DEMONSTRATION>"))
                    {
                        string thisDemonstrationName = thisLine.Substring("<DEMONSTRATION>".Length).Split(new string[] { "</DEMONSTRATION>" }, 2, StringSplitOptions.None)[0];
                        activedemonstration = new Demonstration();
                        activedemonstration.name = thisDemonstrationName;
                        demonstrations.Add(activedemonstration);
                    }

                    if (activedemonstration != null)
                    {
                        if (thisLine.StartsWith("<DEMONSTRATION-PILOT>"))
                        {
                            string thisPilotName = thisLine.Substring("<DEMONSTRATION-PILOT>".Length).Split(new string[] { "</DEMONSTRATION-PILOT>" }, 2, StringSplitOptions.None)[0];
                            activePilot = new Pilot();
                            activePilot.callSign = thisPilotName;
                            activedemonstration.pilots.Add(activePilot);
                        }

                        if (thisLine.StartsWith("<DEMONSTRATION-TEAM>"))
                        {
                            string thisTeamName = thisLine.Substring("<DEMONSTRATION-TEAM>".Length).Split(new string[] { "</DEMONSTRATION-TEAM>" }, 2, StringSplitOptions.None)[0];
                            activedemonstration.teamName = thisTeamName;
                        }

                        if (thisLine.StartsWith("<DEMONSTRATION-MANOEUVRE>"))
                        {
                            string thisManoeuverName = thisLine.Substring("<DEMONSTRATION-MANOEUVRE>".Length).Split(new string[] { "</DEMONSTRATION-MANOEUVRE>" }, 2, StringSplitOptions.None)[0];
                            activemanoeuvre = new Manoeuvre();
                            activemanoeuvre.name = thisManoeuverName;
                            activedemonstration.maneuvers.Add(activemanoeuvre);
                        }
                    }

                    if (activePilot != null)
                    {
                        if (thisLine.StartsWith("<DEMONSTRATION-PILOT-RANK>"))
                        {
                            string thisPilotRank = thisLine.Substring("<DEMONSTRATION-PILOT-RANK>".Length).Split(new string[] { "</DEMONSTRATION-PILOT-RANK>" }, 2, StringSplitOptions.None)[0];
                            activePilot.rank = thisPilotRank;
                        }

                        if (thisLine.StartsWith("<DEMONSTRATION-PILOT-FIRSTNAME>"))
                        {
                            string thisPilotName = thisLine.Substring("<DEMONSTRATION-PILOT-FIRSTNAME>".Length).Split(new string[] { "</DEMONSTRATION-PILOT-FIRSTNAME>" }, 2, StringSplitOptions.None)[0];
                            activePilot.firstName = thisPilotName;
                        }

                        if (thisLine.StartsWith("<DEMONSTRATION-PILOT-SURNAME>"))
                        {
                            string thisPilotName = thisLine.Substring("<DEMONSTRATION-PILOT-SURNAME>".Length).Split(new string[] { "</DEMONSTRATION-PILOT-SURNAME>" }, 2, StringSplitOptions.None)[0];
                            activePilot.surname = thisPilotName;
                        }


                        if (thisLine.StartsWith("<DEMONSTRATION-PILOT-LOCATION>"))
                        {
                            string thisPilotName = thisLine.Substring("<DEMONSTRATION-PILOT-LOCATION>".Length).Split(new string[] { "</DEMONSTRATION-PILOT-LOCATION>" }, 2, StringSplitOptions.None)[0];
                            activePilot.location = thisPilotName;
                        }

                        if (thisLine.StartsWith("<DEMONSTRATION-PILOT-DESCRIPTION>"))
                        {
                            string thisPilotName = thisLine.Substring("<DEMONSTRATION-PILOT-DESCRIPTION>".Length).Split(new string[] { "</DEMONSTRATION-PILOT-DESCRIPTION>" }, 2, StringSplitOptions.None)[0];
                            activePilot.description = thisPilotName;
                        }
                    }

                    if (activemanoeuvre != null)
                    {

                        if (thisLine.StartsWith("<MANOEUVRE-PILOTS>"))
                        {
                            string thisPilotList = thisLine.Substring("<MANOEUVRE-PILOTS>".Length).Split(new string[] { "</MANOEUVRE-PILOTS>" }, 2, StringSplitOptions.None)[0];
                            thisPilotList = thisPilotList.Replace(", ", ",");
                            string[] splitString = thisPilotList.Split(',');
                            int output = 0;
                            #region Get Bitwise
                            foreach (string thisString in splitString)
                            {
                                try
                                {
                                    int i = Int32.Parse(thisString);
                                    output += (int)Math.Pow(2, i - 1);
                                }
                                catch
                                {
                                    //Possible Error Point
                                }
                            }
                            #endregion
                            activemanoeuvre.pilotBitwise = output;
                        }

                        if (thisLine.StartsWith("<MANOEUVRE-NARRATION>"))
                        {
                            string thisManoeuvreNarration = thisLine.Substring("<MANOEUVRE-NARRATION>".Length).Split(new string[] { "</MANOEUVRE-NARRATION>" }, 2, StringSplitOptions.None)[0];
                            activemanoeuvre.narration = thisManoeuvreNarration;
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region convert the lists to combo boxes
            comboBox_Demonstration.Items.Clear();
            comboBox_Demonstration.Items.AddRange(demonstrations.Select(x => x.name).ToArray());

            comboBox_Manoeuvre.Items.Clear();
            comboBox_Manoeuvre.Items.AddRange(activedemonstration.maneuvers.Select(x => x.name).ToArray());
            #endregion

            comboBox_Demonstration.SelectedIndex = 0;
            comboBox_Manoeuvre.SelectedIndex = 0;
        }

        private void ChangeDemonstration(object sender, EventArgs e)
        {
            activedemonstration = demonstrations[comboBox_Demonstration.SelectedIndex];
            comboBox_Manoeuvre.SelectedIndex = 0;

            #region update manoeuver list.
            /*
            string textout = "";
            foreach (string thisstring in activedemonstration.maneuvers.Select(x => x.name))
            {
                textout += thisstring + "\n";
            }
            textout.Remove(textout.Length - 1);
            comboBox_Manoeuvre.Text = textout;
             */
            comboBox_Manoeuvre.Items.Clear();
            comboBox_Manoeuvre.Items.AddRange(activedemonstration.maneuvers.Select(x => x.name).ToArray());
            #endregion
        }

        private void ChangeManoeuvre(object sender, EventArgs e)
        {
            activemanoeuvre = activedemonstration.maneuvers[comboBox_Manoeuvre.SelectedIndex];
            richTextBox_Narration.Text = activemanoeuvre.narration;

            #region update pilots
            string output = "";
            int i = 0;
            foreach (Pilot thisPilot in activedemonstration.pilots)
            {
                i++;
                if (((int)Math.Pow(2, i - 1) & activemanoeuvre.pilotBitwise) > 0)
                {
                    output += thisPilot.callSign + ", ";
                }

                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%CALLSIGN" + i.ToString() + "%", thisPilot.callSign);
                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%RANK" + i.ToString() + "%", thisPilot.rank);
                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%FIRSTNAME" + i.ToString() + "%", thisPilot.firstName);
                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%SURNAME" + i.ToString() + "%", thisPilot.surname);
                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%LOCATION" + i.ToString() + "%", thisPilot.location);
                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%DESCRIPTION" + i.ToString() + "%", thisPilot.description);

                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%TEAM" + i.ToString() + "%", activedemonstration.teamName);
                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%MANEOUVRE" + i.ToString() + "%", activemanoeuvre.name);

                richTextBox_Narration.Text = richTextBox_Narration.Text.Replace("%NEWLINE%", "\n");
            }
            if (output.Length >= 2)
            {
                output = output.Remove(output.Length - 2) + ".";
            }

            textBox_Pilots.Text = output;
            #endregion
        }

        private void goPrevious(object sender, EventArgs e)
        {
            if (comboBox_Manoeuvre.SelectedIndex > 0)
            {
                comboBox_Manoeuvre.SelectedIndex -= 1;
            }
        }

        private void goNext(object sender, EventArgs e)
        {
            if (comboBox_Manoeuvre.SelectedIndex < comboBox_Manoeuvre.Items.Count - 1)
            {
                comboBox_Manoeuvre.SelectedIndex += 1;
            }
        }

    }
}
