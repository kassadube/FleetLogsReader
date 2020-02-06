using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FleetLogs.Model;
using FleetLogs.Data;
using System.Configuration;
namespace UnitTestLogReader
{
    public class TestDataHelper
    {

        public static BaseResultInfo FileToDB(string fileName, LOGTYPE logType, bool isUnified)
        {
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            if (isUnified)
                file = LogReader.LogFileReader.UnifiedLogLines(file);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), logType);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items);
            return res;
        }

        public static BaseResultInfo FileToNewDB(string fileName, LOGTYPE logType, bool isUnified)
        {
            SiteLogger.ILogger logger = SiteLogger.LoggingFactory.GetLogger;
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            if (isUnified)
                file = LogReader.LogFileReader.UnifiedLogLines(file);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), logType);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.GetLastLogItem(logType.ToString(), null);
            LogItem last = res.GetResult<LogItem>();
            int itemsSentToDB = items.Count;
            LogItem lastFound = last ==null? null: items.FirstOrDefault(l => l.InsertDate == last.InsertDate);
            if(lastFound == null)
                res = repository.InsertLogItem(items);
            else
            {
                List<LogItem> itemsToSend = items.FindAll(l=>l.Index>lastFound.Index);
                itemsSentToDB = itemsToSend.Count;
                res = repository.InsertLogItem(itemsToSend);
            }
            logger.Debug(string.Format("FILE NAME = {0} , TOTAL ITEMS  = {1} , ITEM TRY INSERT = {2}, TOTAL SUCCESS = {3}, TOTAL FAILD = {4}", fileName, items.Count, itemsSentToDB,res.ReturnValue, itemsSentToDB - res.ReturnValue));
            return res;
        }
        public static BaseResultInfo GetLastItem(LOGTYPE logType,string server)
        {
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.GetLastLogItem(logType.ToString(), server);
            return res;

        }
        public static List<FileInfo> GetLogFiles()
        {
            string directoryName = ConfigurationManager.AppSettings["DIR"];
            List<FileInfo> files = LogReader.LogFileDirectoryManager.GetLogFiles(directoryName);
            return files;
        }


        public static string GetFullName(string fileName)
        {
            string directoryName = Path.Combine(ConfigurationManager.AppSettings["DIR"],fileName);
            return directoryName;

        }

        public static BaseResultInfo AllLogFilesToDB()
        {
            BaseResultInfo res;
            List<FileInfo> files = GetLogFiles();
            foreach (var item in files)
            {
                LOGTYPE? logType = GetLogTypeFromLogFileName(item.Name);
                bool isUnified = IsUnified(logType.Value);
                 res = FileToDB(item.FullName, logType.Value, isUnified);
            }
            return new BaseResultInfo();
        }

        public static BaseResultInfo AllNewLogFilesToDB()
        {
            BaseResultInfo res;
            List<FileInfo> files = GetLogFiles();
            foreach (var item in files)
            {
                LOGTYPE? logType = GetLogTypeFromLogFileName(item.Name);
                bool isUnified = IsUnified(logType.Value);
                res = FileToNewDB(item.FullName, logType.Value, isUnified);
            }
            return new BaseResultInfo();
        }


        public static LOGTYPE? GetLogTypeFromLogFileName(string logFileName)
        {
           // string supportedExtensions = "trace,warn,dbtrace,jstrace,fatal,error";
            string preName = logFileName.Split('_')[0].ToLower();
            switch (preName)
            {
                case "trace":
                    return LOGTYPE.Trace;
                case "warn":
                    return LOGTYPE.Warn;
                case "dbtrace":
                    return LOGTYPE.DBTrace;
                case "jstrace":
                    return LOGTYPE.JSError;
                case "fatal":
                    return LOGTYPE.Fatal;
                case "error":
                    return LOGTYPE.Error;
                default:
                    return null;
            }


        }
        
        public static bool IsUnified(LOGTYPE logType)
        {
            switch (logType)
            {
                case LOGTYPE.Trace:
                case LOGTYPE.DBTrace:
                case LOGTYPE.Error:
                case LOGTYPE.Fatal:
                    return true;
                case LOGTYPE.Info:
                case LOGTYPE.Debug:
                case LOGTYPE.Warn:
                case LOGTYPE.JSError:
                case LOGTYPE.Test:
                case LOGTYPE.Report:
                case LOGTYPE.Cache:
                    return false;
                default:
                    return true;
            }
        }

        public static BaseResultInfo GetLogins(DateTime start, DateTime? end)
        {
            LogItemRepository repository = new LogItemRepository();
            return repository.GetUniqLogins(start, end);
        }

        public static BaseResultInfo GetLoginsLength(DateTime start, DateTime? end)
        {
            LogItemRepository repository = new LogItemRepository();
            return repository.GetLoginsLength(start, end);
        }
    }
}
