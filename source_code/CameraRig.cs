using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TeboCam
{

    class rigItem
    {

        //private bool motionOn;
        public string cameraName;
        public string friendlyName;
        public int displayButton;
        public Camera cam;

    }

    class info
    {

        public string profileName = "";
        public string webcam = "";
        public string friendlyName = "";
        public bool areaDetection = false;
        public bool areaDetectionWithin = false;
        public bool areaOffAtMotion = false;
        public bool alarmActive = false;
        public bool publishActive = false;
        public int rectX = 0;
        public int rectY = 0;
        public int rectWidth = 0;
        public int rectHeight = 0;
        public int displayButton = 1;
        public double movementVal = 0;


    }


    class CameraRig
    {

        public static List<rigItem> rig = new List<rigItem>();
        public static List<info> camInfo = new List<info>();
        public static int activeCam = 0;
        public static int drawCam = 0;
        public static int trainCam = 0;
        private static int infoIdx = -1;
        public static List<bool> camSel = new List<bool>();
        private const int camLicense = 9;
        public static bool reconfiguring = false;


        //private CameraRig()
        //{
        //    addCamera(null);
        //}+++


        public static void camSelInit()
        {

            for (int i = 1; i < 10; i++)
            {

                camSel.Add(false);

            }

        }

        public static void cameraRemove(int cam)
        {

            Camera camera = rig[cam].cam;

            camera.motionLevelEvent -= new motionLevelEventHandler(bubble.levelLine);
            camera.SignalToStop();
            camera.WaitForStop();

            rig.RemoveAt(cam);

        }



        public static List<string> camerasListedUnderProfile(string profileName)
        {

            List<string> lst = new List<string>();

            foreach (info infoI in camInfo)
            {

                if (infoI.profileName == profileName) lst.Add(infoI.webcam);

            }

            return lst;

        }

        public static void clear()
        {
            reconfiguring = true;
            CameraRig.rig.Clear();
            reconfiguring = false;
        }



        public static void updateInfo(string profileName, string webcam, string infoType, object val)
        {

            if (camerasAttached())
            {

                foreach (info infoI in camInfo)
                {

                    if (infoI.profileName == profileName && infoI.webcam == webcam)
                    {

                        if (infoType == "friendlyName") { infoI.friendlyName = (string)val; }

                        if (infoType == "areaDetection") { infoI.areaDetection = (bool)val; }
                        if (infoType == "areaDetectionWithin") { infoI.areaDetectionWithin = (bool)val; }
                        if (infoType == "alarmActive") { infoI.alarmActive = (bool)val; }
                        if (infoType == "publishActive") { infoI.publishActive = (bool)val; }


                        //may be of use in future
                        if (infoType == "areaOffAtMotion") { infoI.areaOffAtMotion = (bool)val; }
                        //may be of use in future

                        if (infoType == "rectX") { infoI.rectX = (int)val; }
                        if (infoType == "rectY") { infoI.rectY = (int)val; }
                        if (infoType == "rectWidth") { infoI.rectWidth = (int)val; }
                        if (infoType == "rectHeight") { infoI.rectHeight = (int)val; }
                        if (infoType == "movementVal") { infoI.movementVal = (double)val; }
                        if (infoType == "displayButton") { infoI.displayButton = (int)val; }

                    }

                }

            }

        }

        public static void updateInfo(string profileName, string infoType, object val)
        {

            if (camerasAttached())
            {

                foreach (info infoI in camInfo)
                {

                    if (infoI.profileName == profileName && infoI.webcam == rig[activeCam].cameraName)
                    {

                        if (infoType == "friendlyName") { infoI.friendlyName = (string)val; }

                        if (infoType == "areaDetection") { infoI.areaDetection = (bool)val; }
                        if (infoType == "areaDetectionWithin") { infoI.areaDetectionWithin = (bool)val; }
                        if (infoType == "alarmActive") { infoI.alarmActive = (bool)val; }
                        if (infoType == "publishActive") { infoI.publishActive = (bool)val; }


                        //may be of use in future
                        if (infoType == "areaOffAtMotion") { infoI.areaOffAtMotion = (bool)val; }
                        //may be of use in future

                        if (infoType == "rectX") { infoI.rectX = (int)val; }
                        if (infoType == "rectY") { infoI.rectY = (int)val; }
                        if (infoType == "rectWidth") { infoI.rectWidth = (int)val; }
                        if (infoType == "rectHeight") { infoI.rectHeight = (int)val; }
                        if (infoType == "movementVal") { infoI.movementVal = (double)val; }
                        if (infoType == "displayButton") { infoI.displayButton = (int)val; }

                    }

                }

            }
        }


        public static void addInfo(string infoType, object val)
        {


            if (infoType == "webcam")
            {

                infoIdx++;
                info i_item = new info();
                camInfo.Add(i_item);
                camInfo[infoIdx].webcam = (string)val;

            }

            if (infoType == "profileName") { camInfo[infoIdx].profileName = (string)val; }
            if (infoType == "friendlyName") { camInfo[infoIdx].friendlyName = (string)val; }

            if (infoType == "areaDetection") { camInfo[infoIdx].areaDetection = (bool)val; }
            if (infoType == "areaDetectionWithin") { camInfo[infoIdx].areaDetectionWithin = (bool)val; }


            if (infoType == "alarmActive") { camInfo[infoIdx].alarmActive = (bool)val; }
            if (infoType == "publishActive") { camInfo[infoIdx].publishActive = (bool)val; }
            

            //may be of use in future
            if (infoType == "areaOffAtMotion") { camInfo[infoIdx].areaOffAtMotion = (bool)val; }
            //may be of use in future

            if (infoType == "rectX") { camInfo[infoIdx].rectX = (int)val; }
            if (infoType == "rectY") { camInfo[infoIdx].rectY = (int)val; }
            if (infoType == "rectWidth") { camInfo[infoIdx].rectWidth = (int)val; }
            if (infoType == "rectHeight") { camInfo[infoIdx].rectHeight = (int)val; }
            if (infoType == "movementVal") { camInfo[infoIdx].movementVal = (double)val; }
            if (infoType == "displayButton") { camInfo[infoIdx].displayButton = (int)val; }

        }



        public static void rigInfoPopulateForCam(string profileName, string webcam)
        {

            foreach (rigItem item in CameraRig.rig)
            {

                if (item.cameraName == webcam)
                {

                    item.friendlyName = (string)(CameraRig.rigInfoGet(profileName, webcam, "friendlyName"));
                    item.cam.MotionDetector.areaDetection = (bool)(CameraRig.rigInfoGet(profileName, webcam, "areaDetection"));
                    item.cam.MotionDetector.areaDetectionWithin = (bool)(CameraRig.rigInfoGet(profileName, webcam, "areaDetectionWithin"));

                }

            }

        }


        public static int idFromButton(int bttn)
        {

            foreach (rigItem item in CameraRig.rig)
            {

                if (item.displayButton == bttn) return item.cam.cam;

            }

            return 0;

        }

        public static int idxFromButton(int bttn)
        {

            for (int i = 0; i < rig.Count; i++)
            {

                if (rig[i].displayButton == bttn)
                {
                    return i;
                }

            }

            return 0;

        }



        /// <summary>
        /// swap camera buttons
        /// </summary>
        /// <returns>void</returns>
        public static void changeDisplayButton(string profileName, string camName, int id, int newBttn)
        {

            //newBttn--;
            int swapId = 0;
            string swappingCamName = "";

            foreach (info infoI in camInfo)
            {

                //we have found this button is already assigned to another camera
                if (infoI.profileName == profileName && infoI.displayButton == newBttn && infoI.webcam != camName)
                {

                    swapId = rig[id].displayButton;
                    swappingCamName = infoI.webcam;
                    infoI.displayButton = swapId;

                }

            }

            foreach (info infoI in camInfo)
            {

                if (profileName == infoI.profileName && infoI.webcam == camName)
                {

                    //infoI.displayButton = newBttn + 1;
                    infoI.displayButton = newBttn;

                }

            }

            foreach (rigItem item in CameraRig.rig)
            {

                if (item.cameraName == swappingCamName) item.displayButton = swapId;
                if (item.cameraName == camName) item.displayButton = newBttn;

            }



        }


        public static void rigInfoPopulate(string profileName, int id)
        {
            bool infoExists = false;

            foreach (info infoI in camInfo)
            {

                if (profileName == infoI.profileName && infoI.webcam == rig[id].cameraName)
                {

                    rig[id].friendlyName = infoI.friendlyName;
                    rig[id].displayButton = infoI.displayButton;

                    rig[id].cam.MotionDetector.areaDetectionWithin = infoI.areaDetectionWithin;
                    rig[id].cam.MotionDetector.areaDetection = infoI.areaDetection;

                    rig[id].cam.MotionDetector.rectX = infoI.rectX;
                    rig[id].cam.MotionDetector.rectY = infoI.rectY;
                    rig[id].cam.MotionDetector.rectHeight = infoI.rectHeight;
                    rig[id].cam.MotionDetector.rectWidth = infoI.rectWidth;
                    rig[id].cam.movementVal = infoI.movementVal;



                    rig[id].cam.alarmActive = infoI.alarmActive;
                    rig[id].cam.publishActive = infoI.publishActive;
                    
                    infoExists = true;

                    break;

                }

            }

            //create the info
            if (!infoExists)
            {

                info infoI = new info();

                infoI.profileName = profileName;
                infoI.friendlyName = "";
                infoI.webcam = rig[id].cameraName;
                infoI.areaDetectionWithin = false;
                infoI.areaDetection = false;
                infoI.rectX = 20;
                infoI.rectY = 20;
                infoI.rectHeight = 80;
                infoI.rectWidth = 80;
                infoI.movementVal = 0.99;
                infoI.displayButton = 1;
                camInfo.Add(infoI);

                rig[id].displayButton = 1;

                rig[id].cam.MotionDetector.areaDetectionWithin = false;
                rig[id].cam.MotionDetector.areaDetection = false;
                rig[id].cam.MotionDetector.rectX = 20;
                rig[id].cam.MotionDetector.rectY = 20;
                rig[id].cam.MotionDetector.rectHeight = 80;
                rig[id].cam.MotionDetector.rectWidth = 80;
                rig[id].cam.movementVal = 0.99;


            }

        }





        public static object rigInfoGet(string profile, string property)
        {

            foreach (info infoI in camInfo)
            {

                if (infoI.profileName == profile && infoI.webcam == rig[activeCam].cameraName)
                {

                    //if (property == "webcam") return infoI.webcam;
                    if (property == "friendlyName") return infoI.friendlyName;
                    if (property == "areaDetection") return infoI.areaDetection;
                    if (property == "areaDetectionWithin") return infoI.areaDetectionWithin;
                    if (property == "areaOffAtMotion") return infoI.areaOffAtMotion;
                    if (property == "rectX") return infoI.rectX;
                    if (property == "rectY") return infoI.rectY;
                    if (property == "rectWidth") return infoI.rectWidth;
                    if (property == "rectHeight") return infoI.rectHeight;
                    if (property == "movementVal") return infoI.movementVal;
                    if (property == "alarmActive") return infoI.alarmActive;
                    if (property == "publishActive") return infoI.publishActive;
                }

            }

            return null;
        }


        public static object rigInfoGet(string profile, string webcam, string property)
        {

            foreach (info infoI in camInfo)
            {

                if (infoI.profileName == profile && infoI.webcam == webcam)
                {

                    //if (property == "webcam") return infoI.webcam;
                    if (property == "friendlyName") return infoI.friendlyName;
                    if (property == "areaDetection") return infoI.areaDetection;
                    if (property == "areaDetectionWithin") return infoI.areaDetectionWithin;
                    if (property == "areaOffAtMotion") return infoI.areaOffAtMotion;
                    if (property == "rectX") return infoI.rectX;
                    if (property == "rectY") return infoI.rectY;
                    if (property == "rectWidth") return infoI.rectWidth;
                    if (property == "rectHeight") return infoI.rectHeight;
                    if (property == "movementVal") return infoI.movementVal;
                    if (property == "alarmActive") return infoI.alarmActive;
                    if (property == "publishActive") return infoI.publishActive;
                }

            }

            return null;
        }


        public static Camera getCam(string webcam)
        {

            foreach (rigItem item in CameraRig.rig)
            {

                if (item.cameraName == webcam) return item.cam;

            }

            return null;

        }

        public static Camera getCam(int cam)
        {

            return CameraRig.rig[cam].cam;
        }

        public static void addCamera(rigItem i_cam)
        {
            rigItem r_item = new rigItem();
            r_item = i_cam;

            rig.Add(r_item);
        }

        public static bool camerasAttached()
        {

            return rig.Count >= 1;

        }

        public static bool cameraExists(int id)
        {

            //return rig.Count >= id + 1;

            foreach (rigItem item in rig)
            {

                if (item.cam.cam == id) return true;

            }

            return false;

        }


        public static int cameraCount()
        {

            return rig.Count;

        }


        public static void alert(bool alt)
        {
            foreach (rigItem rigI in rig)
            {
                rigI.cam.alert = alt;
            }
        }


        public static bool camerasAlreadySelected(string name)
        {

            if (!camerasAttached()) return false;

            foreach (rigItem rigI in rig)
            {
                if (rigI.cameraName == name)
                {
                    return true;
                }
            }

            return false;

        }



        public static void AreaOffAtMotionTrigger(int camId)
        {
            if (camerasAttached()) rig[camId].cam.MotionDetector.areaOffAtMotionTriggered = true;
        }

        public static bool AreaOffAtMotionIsTriggeredCam(int camId)
        {
            if (camerasAttached())
            {
                return rig[camId].cam.MotionDetector.areaOffAtMotionTriggered;
            }
            else
            {
                return false;
            }
        }


        public static bool Calibrating
        {
            get { return rig[activeCam].cam.MotionDetector.calibrating; }
            set
            {
                if (camerasAttached()) rig[activeCam].cam.MotionDetector.calibrating = value;
            }
        }

        public static bool AreaOffAtMotionTriggered
        {
            get { return rig[activeCam].cam.MotionDetector.areaOffAtMotionTriggered; }
            set
            {
                if (camerasAttached()) rig[activeCam].cam.MotionDetector.areaOffAtMotionTriggered = value;
            }
        }

        public static bool AreaOffAtMotionReset
        {
            get { return rig[activeCam].cam.MotionDetector.areaOffAtMotionReset; }
            set
            {
                if (camerasAttached()) rig[activeCam].cam.MotionDetector.areaOffAtMotionReset = value;
            }
        }

        public static bool AreaDetection
        {
            get { return rig[drawCam].cam.MotionDetector.areaDetection; }
            set
            {
                if (camerasAttached()) rig[drawCam].cam.MotionDetector.areaDetection = value;
            }
        }

        public static bool AreaDetectionWithin
        {
            get { return rig[drawCam].cam.MotionDetector.areaDetectionWithin; }
            set
            {
                if (camerasAttached())
                    rig[drawCam].cam.MotionDetector.areaDetectionWithin = value;
            }
        }

        public static bool ExposeArea
        {
            get { return rig[drawCam].cam.MotionDetector.exposeArea; }
            set
            {
                if (camerasAttached()) rig[drawCam].cam.MotionDetector.exposeArea = value;
            }
        }



    }






}

