using FleetLogs.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Toolkit.Extensions;
using System.Linq;
using System.Globalization;

namespace LogReader
{

    public class LogFileDirectoryManager
    {
        
        public static List<FileInfo> GetLogFiles(string logDirectoryName)
        {
            string supportedExtensions = "trace,warn,dbtrace,jstrace,fatal,error";
            DirectoryInfo dir = new DirectoryInfo(logDirectoryName);
            if (!dir.Exists) return null;
            List<FileInfo> files = dir.GetFiles("*.Log",SearchOption.AllDirectories).Where(f => supportedExtensions.Contains(f.Name.ToLower().Split('_')[0])).ToList();
            return files;// new List<FileInfo>(dir.GetFiles("*.Log"));
        }

        public static List<FileInfo> GetLogFiles(string logDirectoryName, SearchOption options)
        {
            string supportedExtensions = "trace,warn,dbtrace,jstrace,fatal,error";
            DirectoryInfo dir = new DirectoryInfo(logDirectoryName);
            if (!dir.Exists) return null;
            List<FileInfo> files = dir.GetFiles("*.Log", options).Where(f => supportedExtensions.Contains(f.Name.ToLower().Split('_')[0])).ToList();
            return files;// new List<FileInfo>(dir.GetFiles("*.Log"));
        }

        public static int CopyLogFiles(string copyFrom, string CopyTo)
        {
            List<FileInfo> files = GetLogFiles(copyFrom);
            foreach (var item in files)
            {
                item.CopyTo(Path.Combine(CopyTo,item.Name),false);
            }
            return files.Count;
        }

        public static int CopyLogFiles(string copyFrom, string CopyTo, DateTime start, int days)
        {
            List<FileInfo> files = GetLogFiles(copyFrom, start, days);
            DirectoryInfo dir = new DirectoryInfo(CopyTo);
            if (!dir.Exists)
                dir.Create();
            foreach (var item in files)
            {
                
                item.CopyTo(Path.Combine(CopyTo, item.Name), true);
            }
            return files.Count;
        }

        public static int CopyLogFiles(string copyFrom, string CopyTo, DateTime start, int days,SearchOption options)
        {
            List<FileInfo> files = GetLogFiles(copyFrom, start, days,options);
            DirectoryInfo dir = new DirectoryInfo(CopyTo);
            if (!dir.Exists)
                dir.Create();
            foreach (var item in files)
            {

                item.CopyTo(Path.Combine(CopyTo, item.Name), true);
            }
            return files.Count;
        }

        public static List<FileInfo> GetLogFiles(string logDirectoryName, DateTime start, int days)
        {
            List<FileInfo> files = GetLogFiles(logDirectoryName);
            List<FileInfo> filesInDate = new List<FileInfo>();
            DateTime endDate = start.AddDays(days * -1);
            foreach (var item in files)
            {
                DateTime? dt = GetLogDate(Path.GetFileName(item.Name));
                if (dt.HasValue && dt.Value > endDate && dt.Value < start)
                    filesInDate.Add(item);
            }
            return filesInDate;

        }

        public static List<FileInfo> GetLogFiles(string logDirectoryName, DateTime start, int days,SearchOption options)
        {
            List<FileInfo> files = GetLogFiles(logDirectoryName,options);
            List<FileInfo>filesInDate = new List<FileInfo>();
            DateTime endDate = start.AddDays(days * -1);
            foreach (var item in files)
            {
                DateTime? dt = GetLogDate(Path.GetFileName(item.Name));
                if (dt.HasValue && dt.Value > endDate && dt.Value < start)
                    filesInDate.Add(item);
            }
            return filesInDate;

        }
        public static DateTime? GetLogDate(string fileName)
        {
            string format = "yyyyMMdd";
            CultureInfo provider = CultureInfo.InvariantCulture;
            int index = fileName.LastIndexOf('_');
            string dStr = fileName.Substring(index + 1, 8);
            DateTime d = DateTime.ParseExact(dStr, format, provider);
            //DateTime d = System.Convert.ToDateTime(dStr,, format);
            return d;// DateTime.Parse(dStr, null, DateTimeStyles.AssumeUniversal);

        }
    }
}
