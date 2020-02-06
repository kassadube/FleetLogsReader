using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FleetLogs.Model;
using System.Configuration;

namespace LogReader
{
    public static class ModelHelper
    {

        public static bool isCharStartsNewLogLine(this char ch)
        {
            if (ch == ' ') return false;
            if (ch < 47 || ch > 58) return false;
            return true;
        }

        
    }
}
