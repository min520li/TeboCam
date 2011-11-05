using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Diagnostics;


namespace TeboCam
{
    class licence
    {
        private static List<int> camsSelected = new List<int>();

        public static string licenceKey;

        public static bool licenced = false;


        //3 parts 
        //version
        //key
        //
        //use the system hardrive serial number

        public static int camsAllowed = 9;


        public static int camsSuported()
        {

            return camsAllowed;

        }

        
        public static bool selectCam(int cam)
        {

            if (camsSelected.Count + 1 <= camsSuported())
            {
                camsSelected.Add(cam);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void deselectCam(int cam)
        {

            for (int i = 0; i < camsSelected.Count; i++)
            {

                if (camsSelected[i] == cam) camsSelected.RemoveAt(i);

            }

        }

        /// <summary>
        /// returns a bool showing if a camera is selected as active
        /// </summary>
        /// <returns>bool</returns>
        public static bool aCameraIsSelected()
        {

            return camsSelected.Count > 0;

        }


        /// <param name="cam"> The camera to check.</param>
        /// <returns>Bool showing if the camera is active.</returns>
        public static bool CamIsActive(int cam)
        {

            foreach (int camera in camsSelected)
            {

                if (camera == cam) return true;

            }

            return false;


        }



        public static int registerLicence()
        {

            string query = "update licence L set L.licence_date = '" + time.currentDateTimeSql() + "'";
            return database.set_licence_data(bubble.mysqlDriver, query);

        }


        public static int versionLicenced(string key)
        {


            int returnVal = 999;
            ArrayList result = new ArrayList();

            string query = "select cast(count(*) as char(100)) from licence L where L.key = '" + key + "' and L.licence_date is null and L.reset = 0";
            result.Clear();
            result = database.get_licence_data(bubble.mysqlDriver, query);

            //something went wrong
            if (result[0].ToString() == "NULL") returnVal = 0;

            //licence key probably already registered
            if (Convert.ToInt32(result[0].ToString()) == 0) returnVal = 2;

            //licence key not yet registered
            if (Convert.ToInt32(result[0].ToString()) > 0) returnVal = 3;


            //check if licence key exists
            if (returnVal == 2)
            {
                query = "select cast(count(*) as char(100)) from licence L where L.key = '" + key + "'";
                result.Clear();
                result = database.get_licence_data(bubble.mysqlDriver, query);

                //something went wrong
                if (result[0].ToString() == "NULL") returnVal = 0;

                //licence key is invalid
                if (Convert.ToInt32(result[0].ToString()) == 0) returnVal = 1;
            }



            result.Clear();
            return returnVal;

        }


        public static string createLocalKey()
        {
            //macaddress | yyyymmdd | version 

            string macaddress = GetMacAddress();
            string yyyymmdd = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            string version = bubble.version;

            string localKey;

            crypt crypt = new crypt();

            localKey = crypt.EncryptToString(macaddress + "|" + yyyymmdd + "|" + version);
            return localKey;


            //System.Diagnostics.Debug.WriteLine(macaddress + "|" + yyyymmdd + "|" + version);
            //System.Diagnostics.Debug.WriteLine(localKey);
            //System.Diagnostics.Debug.WriteLine(crypt.DecryptString(localKey));

        }

        public static bool keyValid(string licenceOnMachine)
        {

            crypt crypt = new crypt();
            string[] parts = crypt.DecryptString(licenceOnMachine).Split('|');
            string macAddressFomKey = parts[0];
            string dateFomKey = parts[1];
            string versionFomKey = parts[2];

            return macAddressFomKey == GetMacAddress();


        }


        public static string GetMacAddress()
        {


            string macAddress = "";

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    macAddress += nic.GetPhysicalAddress().ToString();
                    break;

                }
            }

            return macAddress;

        }

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //ensure only one instance is running
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        public static int IsApplicationAlreadyRunning(string thisProcess)
        {

            string proc = Process.GetCurrentProcess().ProcessName;

            //System.Windows.Forms.MessageBox.Show(proc);

            //check the name of this process
            if (proc == thisProcess)
            {

                //Debug.WriteLine(proc);
                Process[] processes = Process.GetProcessesByName(proc);
                //more than one occurence of this process is currently running
                if (processes.Length > 1)
                    return 0;
                //only one occurence of this process is currently running
                else
                    return 1;

            }
            //this process does not match the expected name
            else
            {
                return 2;
            }

        }


    }
}
