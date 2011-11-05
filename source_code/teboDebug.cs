using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TeboCam
{
    class teboDebug
    {

        public static bool debugOn = false;
        public static bool debugToFile = false;
        public static string filePath = "";
        public static string fileName = "";

        private static StreamWriter debugWriter;

        public static int pingVal = 1000;
        public static int movementAddImagesVal = 2000;
        public static int publishImageVal = 3000;
        public static int webUpdateVal = 4000;
        public static int movementPublishVal = 5000;


        public static void openFile()
        {
            debugWriter = new StreamWriter(filePath + fileName, true);
        }

        public static void closeFile()
        {
            debugWriter.Close();
        }

        public static void writeline(string val)
        {

            if (debugOn) write(val.ToString());

        }

        public static void writeline(int val)
        {

            if (debugOn) write(val.ToString());

        }


        private static void write(string line)
        {

            string tmpStr = DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);
            string Outline = tmpStr + " | " + line;

            if (debugOn) Debug.WriteLine(Outline);
            if (debugToFile) debugWriter.WriteLine(Outline);

        }






    }

}
