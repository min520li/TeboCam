using System;
using System.Collections.Generic;
using System.Text;

namespace teboweb
{
    class CommandLine
    {

        public static string replaceSpacesWithCode(string val)
        {

            string tmpStr = val;
            return tmpStr.Replace(" ", "##~SpRepl~##");

        }

        public static string replaceCodeWithSpaces(string val)
        {

            string tmpStr = val;
            return tmpStr.Replace("##~SpRepl~##", " ");

        }

    }
}
