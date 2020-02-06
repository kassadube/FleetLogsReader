using FleetLogs.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Toolkit.Extensions;

namespace LogReader
{
    
    public class LogFileReader
    {
        public static List<string> ReadFile_old(string fileName)
        {
            List<string> lines = new List<string>();
            string line;
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    // Read the stream to a string, and write the string to the console.
                    while ((line = sr.ReadLine()) != null)
                    {
                       string[] s = line.Split('¡');
                        lines.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return lines;
        }


        public static List<string> ReadFile(string fileName)
        {
            List<string> lines = new List<string>();
            string line;
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    // Read the stream to a string, and write the string to the console.
                    while ((line = sr.ReadLine()) != null)
                    {
                        //string[] s = SplitLine(line);
                        lines.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return lines;
        }

        public static List<string> UnifiedLogLines(List<string> lines)
        {
            List<string> newLines = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
                StringBuilder str = new StringBuilder(lines[i]);
                for (int j = i + 1; j < lines.Count && !lines[j][0].isCharStartsNewLogLine(); j++)
                {
                    str.Append(lines[j]);
                    i = j;
                }
                newLines.Add(str.ToString());
            }
            return newLines;
        }
        
        private static string[] SplitLine(string line)
        {
            string[] s = line.Split('¡');
            return s;

        }

        public static List<LogItem> LinesToLogs(string[] lines, LOGTYPE logType)
        {
            List<LogItem> items = new List<LogItem>();
            for (int i = 0; i < lines.Length; i++)
            {
                var item = lines[i];
                LogItem logItem = ExtractLogItem(item, i, logType);
                if(logItem!=null)
                    items.Add(logItem);                
            }
            return items;

        }

        public static LogItem ExtractLogItem(string line, int index, LOGTYPE logType)
        {
            string[] lineSplited = line.Split('¡');
            LogItem i = new LogItem();
            switch (logType)
            {
                case LOGTYPE.Info:
                    break;
                case LOGTYPE.Debug:
                    break;
                case LOGTYPE.Warn:
                    return ExtractLogItemWarn(lineSplited, index);
                case LOGTYPE.Trace:
                    return ExtractLogItemTrace(lineSplited, index);
                case LOGTYPE.Error:
                    return ExtractLogItemError(lineSplited, index);
                case LOGTYPE.Fatal:
                    return ExtractLogItemFatal(lineSplited, index);
                case LOGTYPE.JSError:
                    return ExtractLogItemJSTrace(lineSplited, index);
                case LOGTYPE.DBTrace:
                    return ExtractLogItemDBTrace(lineSplited, index);
                case LOGTYPE.Test:
                    break;
                case LOGTYPE.Report:
                    break;
                case LOGTYPE.Cache:
                    break;
                default:
                    break;
            }
            return i;
        }

        private static LogItem ExtractLogItemDBTrace(string[] line, int index)
        {
            LogItem i = new LogItem();
            i.LogType = LOGTYPE.DBTrace;
            i.Index = index;
            i.InsertDate = DateTime.Parse(line[0].Substring(0,line[0].Length-2));
            i.LogServer = GetValue(line[1]);
            i.Url = GetValue(line[2]);
            i.AccountId = GetValue(line[3]).StringToInt();
            i.SiteId = GetValue(line[4]);
            i.Message = GetValue(line[6]);
            i.Trace = GetValue(line[7]);

            return i;
        }

        private static LogItem ExtractLogItemTrace(string[] line, int index)
        {
            LogItem i = new LogItem();
            i.LogType = LOGTYPE.Trace;
            i.Index = index;
            i.InsertDate = DateTime.Parse(line[0].Substring(0, line[0].Length - 2));
            i.LogServer = GetValue(line[1]);
            i.Url = GetValue(line[2]);
            i.AccountId = GetValue(line[3]).StringToInt();
            i.SiteId = GetValue(line[4]);
            i.Message = GetValueBySplitter(line[6],':');
            i.Trace = GetValue(line[7]);
            return i;
        }
        
        private static LogItem ExtractLogItemJSTrace(string[] line, int index)
        {
            LogItem i = new LogItem();
            i.LogType = LOGTYPE.JSError;
            i.Index = index;
            i.InsertDate = DateTime.Parse(line[0].Substring(0, line[0].Length - 2));
            i.LogServer = GetValue(line[1]);
            i.Url = GetValue(line[2]);
            i.AccountId = GetValue(line[3]).StringToInt();
            i.SiteId = GetValue(line[4]);
            i.UserAgent = GetValue(line[5]);
            i.Message = GetValue(line[6]);
            i.Trace = GetValue(line[7]);
            return i;
        }
        
        private static LogItem ExtractLogItemWarn(string[] line, int index)
        {
            LogItem i = new LogItem();
            i.LogType = LOGTYPE.Warn;
            i.Index = index;
            i.InsertDate = DateTime.Parse(line[0].Substring(0, line[0].Length - 2));
            i.LogServer = GetValue(line[1]);
            i.Url = GetValue(line[2]);
            i.AccountId = GetValue(line[3]).StringToInt();
            i.SiteId = GetValue(line[4]);
            i.UserAgent = GetValue(line[5]);
            i.Message = GetValue(line[6]);
            i.Trace = GetValue(line[7]);
            return i;
        }

        private static LogItem ExtractLogItemFatal(string[] line, int index)
        {
            if (line.Length == 1) 
                return ExtractLogItemFatal(line[0], index);
            LogItem i = new LogItem();
            i.LogType = LOGTYPE.Fatal;
            i.Index = index;
            i.InsertDate = DateTime.Parse(line[0].Substring(0, line[0].Length - 2));
            i.LogServer = GetValue(line[1]);
            i.Url = GetValue(line[2]);
            i.AccountId = GetValue(line[3]).StringToInt();
            i.SiteId = GetValue(line[4]);
            i.UserAgent = GetValue(line[5]);
            i.Message = GetValue(line[6]);
            i.Trace = GetValue(line[7]);
            return i;
        }

        // WHEN LINE IS NOT FORMATTED
        private static LogItem ExtractLogItemFatal(string line, int index)
        {
            LogItem i = new LogItem();
            i.LogType = LOGTYPE.Fatal;
            i.Index = index;
            int indexdt = line.IndexOf(':') + 6;
            if (indexdt > 5 && indexdt < 40)
            {
                i.InsertDate = DateTime.Parse(line.Substring(0, indexdt));
                i.Message = line.Substring(indexdt);
            }
            else
                i.Message = line;
            return i;
        }

        private static LogItem ExtractLogItemError(string[] line, int index)
        {
            var s="sdfsdf";
            if (line.Length == 1)
            {
                if (line[0].Contains("3155407"))
                    s = "dfgdfG";
                return null;
            }
            LogItem i = new LogItem();
            i.LogType = LOGTYPE.Error;
            i.Index = index;
            i.InsertDate = DateTime.Parse(line[0].Substring(0, line[0].Length - 2));
            i.LogServer = GetValue(line[1]);
            i.Url = GetValue(line[2]);
            i.AccountId = GetValue(line[3]).StringToInt();
            i.SiteId = GetValue(line[4]);
            i.UserAgent = GetValue(line[5]);
            i.Message = GetValue(line[6]);
            i.Trace = GetValue(line[7]);
            return i;
        }

        private static string GetValue(string pair)
        {
            int index = pair.IndexOf('=');
            string s = pair.Substring(index+1).Trim();
            return s;

        }
        
        private static string GetValueBySplitter(string pair,char splitter)
        {
            int index = pair.IndexOf(splitter);
            string s = pair.Substring(index + 1).Trim();
            return s;

        }

        private static string[] GetPair(string keyValue)
        {
            int index = keyValue.IndexOf('=');
            string[] s = new string[2];
            s[0] = keyValue.Substring(0, index - 1);
            s[1] = keyValue.Substring(index);
            return s;
        }

    }
}
