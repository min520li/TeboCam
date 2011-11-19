using System;
using System.Collections.Generic;
using System.Text;

namespace TeboCam
{
    class sensitiveInfo
    {

        public static string ver = "3.003";
        public const string versionDt = "21/08/2011";
        public const string product = "TeboCam";

        public static string processToEnd = "TeboCam";
        public static string newsFile = "tebocamnews.Zip";//"tebocamnewsTest.Zip";
        public static string versionFile = "tebover.txt";
        public static string versionFileDev = "teboverdev.txt";
        public static string downloadsURL = "http://teboweb.com/Downloads/";

        public const string tebowebUrl = "http://www.teboweb.com";
        public static string devMachineFile = "\\teboweb1970.txt";
        public static string databaseTrialFile = "\\dbasetest.txt";
        public static string dbaseConnectFile = "\\dbaseconnect.txt";
        public const string updaterPrefix = "M1970_";


        //database info
        public const string server = "88.208.216.18";
        public const string dbase = "tebowebco";
        public const string uid = "tebowebco";
        public const string pwd = "239193105113218010100130089155155206109079036212";
        //database info

        //crypt info
        public static byte[] Key =  { 123, 217, 19, 11, 24, 26, 34, 45, 114, 184, 27, 162, 24, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
        public static byte[] Vector = { 146, 64, 191, 111, 23, 7, 113, 119, 231, 121, 56, 112, 79, 32, 114, 156 };
        //crypt info

    }
}
