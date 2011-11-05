using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using TeboCam;

namespace TeboWeb
{

    public class Pulse
    {

        private decimal beatsPerMinute;
        private decimal checksPerMinute;
        private string directory;
        private string pulseAppLocation;
        private string pulseMessageDirectory;
        private string restartCommand;

        private string filename;
        private bool stopPulse;


        private int starttime;
        private int startday;
        private int lastPls = 0;

        public bool restarted = false;

        public Pulse(decimal i_beatsPerMinute,
                     decimal i_checksPerMinute,
                     string i_directory,
                     string i_filename,
                     string processToEnd,
                     string appToStart,
                     string i_pulseAppLocation,
                     string i_pulseMessageDirectory,
                     string i_restartCommand,
                     bool i_restarted)
        {

            beatsPerMinute = i_beatsPerMinute;
            checksPerMinute = i_checksPerMinute;
            directory = i_directory;
            filename = i_filename;
            restarted = i_restarted;
            pulseAppLocation = i_pulseAppLocation;
            pulseMessageDirectory = i_pulseMessageDirectory;
            restartCommand = i_restartCommand;

            if (checksPerMinute == 0 || checksPerMinute > beatsPerMinute) checksPerMinute = beatsPerMinute;

            setStart();

            writefile(secondsSinceStart());
            lastPls = secondsSinceStart();

            if (!restarted)
            {

                //bubble.postProcessCommand = @" /profile " + bubble.profileInUse;

                string cmdLn = "";

                cmdLn += @"""";
                cmdLn += "|pulseDirectory|" + directory;
                cmdLn += "|pulseFile|" + filename;
                cmdLn += "|pulseMessageDirectory|" + pulseMessageDirectory;
                cmdLn += "|beatsPerMinute|" + beatsPerMinute;
                cmdLn += "|checksPerMinute|" + checksPerMinute;
                cmdLn += "|processToEnd|" + processToEnd;
                cmdLn += "|appToStart|" + appToStart;
                cmdLn += "|firstPulse|" + secondsSinceStart().ToString();
                cmdLn += "|command|" + restartCommand;
                cmdLn += @"""";

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = pulseAppLocation;
                startInfo.Arguments = cmdLn;
                Process.Start(startInfo);

            }

        }


        /// <param name="processToEnd"> Name of the pulse checking application to close.</param>
        public bool stopCheck(string processToEnd)
        {

            bool processKilled = false;
            int attempts = 0;

            try
            {

                while (processKilled == false && attempts < 10)
                {

                    Process[] processes = Process.GetProcesses();

                    foreach (Process process in processes)
                    {
                        if (process.ProcessName == processToEnd)
                        {
                            process.Kill();
                            processKilled = true;
                        }

                    }

                    attempts++;
                    if (!processKilled) Thread.Sleep(1000);

                }

                return processKilled;

            }
            catch
            {

                return false;

            }


        }


        public void Beat(string i_restartCommand)
        {

            restartCommand = i_restartCommand;

            if (!stopPulse && secondsSinceStart() - lastPls >= (int)Math.Floor((60 / beatsPerMinute)))
            {
                writefile(secondsSinceStart());
                lastPls = secondsSinceStart();
            }

        }


        public void StopPulse()
        {

            stopPulse = true;

        }


        public void RestartPulse()
        {

            stopPulse = false;

        }

        private int secondsSinceStart()
        {

            int secsInDay = 86400;
            int thisday = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
            int daysSinceStart = Math.Abs(thisday - startday);


            int result = (daysSinceStart * secsInDay) - starttime + secondsSinceMidnight();
            return result;
        }

        private int secondsSinceMidnight()
        {
            string tmpStr = DateTime.Now.ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            int hour = Convert.ToInt32(LeftRightMid.Left(tmpStr, 2));
            int mins = Convert.ToInt32(LeftRightMid.Mid(tmpStr, 3, 2));
            int secs = Convert.ToInt32(LeftRightMid.Right(tmpStr, 2));
            int secsSinceMidnight = (hour * 3600) + (mins * 60) + secs;
            return secsSinceMidnight;
        }

        private void setStart()
        {
            startday = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
            starttime = secondsSinceMidnight();
        }

        private void writefile(int val)
        {

            try
            {
                XmlTextWriter pulseData = new XmlTextWriter(directory + filename, null);

                pulseData.Formatting = Formatting.Indented;
                pulseData.Indentation = 4;
                pulseData.Namespaces = false;
                pulseData.WriteStartDocument();

                pulseData.WriteStartElement("", "Pulse_Data", "");

                pulseData.WriteStartElement("", "beat", "");
                pulseData.WriteString(val.ToString());
                pulseData.WriteEndElement();

                pulseData.WriteStartElement("", "restartCommand", "");
                pulseData.WriteString(restartCommand);
                pulseData.WriteEndElement();

                pulseData.WriteEndElement();

                pulseData.WriteEndDocument();
                pulseData.Flush();
                pulseData.Close();

            }

            catch { }
        }








    }

}