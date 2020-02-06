using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using FleetLogs.Model;
using FleetLogs.Data;

namespace UnitTestLogReader
{
    [TestClass]
    public class UnitTestLogReader
    {
        [TestMethod]
        public void TEST_TEMP()
        {
            string fileName = "Error_fleet_20151109.log";
            fileName = TestDataHelper.GetFullName(fileName);
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<string> newLins = LogReader.LogFileReader.UnifiedLogLines(file);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(newLins.ToArray(), LOGTYPE.Warn);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items);
            Assert.IsTrue(res != null);

        }


        [TestMethod]
        public void TESTReadFileToStringList()
        {
            string fileName = "DBTrace_fleet_20151102.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            Assert.IsTrue(file.Count > 4);

        }

        [TestMethod]
        public void TEST_ReadFileToStringListIndex()
        {
            string fileName = "DBTrace_fleet_20151102.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            Assert.IsTrue(file.Count > 4);

        }

        /// <summary>
        /// read DBTrace file into logItem object
        /// </summary>
        [TestMethod]
        public void TEST_ExtractLogItem()
        {
            string fileName = "DBTrace_fleet_20151102.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            LogItem log = LogReader.LogFileReader.ExtractLogItem(file[19], 1, LOGTYPE.DBTrace);
            Assert.IsTrue(log!= null);

        }

        /// <summary>
        /// read trace file into logItem object
        /// </summary>
        [TestMethod]
        public void TEST_ExtractTraceLogItem()
        {
            string fileName = "Trace_fleet_20151102.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            LogItem log = LogReader.LogFileReader.ExtractLogItem(file[0], 1, LOGTYPE.Trace);
            Assert.IsTrue(log != null);

        }

        /// <summary>
        /// extract jsError file into logItem object
        /// </summary>
        [TestMethod]
        public void TEST_ExtractJSERRORLogItem()
        {
            string fileName = "JSTrace_fleet_20151103.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            LogItem log = LogReader.LogFileReader.ExtractLogItem(file[0], 1, LOGTYPE.JSError);
            Assert.IsTrue(log != null);

        }

        /// <summary>
        /// extract Warn file into logItem object
        /// </summary>
        [TestMethod]
        public void TEST_ExtractWarnLogItem()
        {
            string fileName = "Warn_fleet_20151103.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            LogItem log = LogReader.LogFileReader.ExtractLogItem(file[0], 1, LOGTYPE.Warn);
            Assert.IsTrue(log != null);

        }

        /// <summary>
        /// when log item is more then one line in the file unifed the lines into one line
        /// this happans in fatal,error log files
        /// </summary>
        [TestMethod]
        public void TEST_UnifiedFatalLogItem()
        {
            string fileName = "Fatal_fleet_20151103.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<string> newLins = LogReader.LogFileReader.UnifiedLogLines(file);
            Assert.IsTrue(file.Count>newLins.Count);

        }
        /// <summary>
        /// extract Fatal file into logItem object
        /// </summary>
        [TestMethod]
        public void TEST_ExtractFatalLogItem()
        {
            //string fileName = "Fatal_fleet_20151103.log";
            string fileName = "Fatal_fleet_20151109.log";
            fileName = TestDataHelper.GetFullName(fileName);
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<string> newLins = LogReader.LogFileReader.UnifiedLogLines(file);
            LogItem log = LogReader.LogFileReader.ExtractLogItem(newLins[0], 1, LOGTYPE.Fatal);
            Assert.IsTrue(log != null);

        }

        /// <summary>
        /// extract Error file into logItem object
        /// </summary>
        [TestMethod]
        public void TEST_ExtractErrorLogItem()
        {
            //string fileName = "Fatal_fleet_20151103.log";
            string fileName = "Error_fleet_20161211.log";
            fileName = TestDataHelper.GetFullName(fileName);
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<string> newLins = LogReader.LogFileReader.UnifiedLogLines(file);
            LogItem log = LogReader.LogFileReader.ExtractLogItem(newLins[0], 1, LOGTYPE.Error);
            Assert.IsTrue(log != null);

        }

        /// <summary>
        /// extract Trace file into logItem object
        /// </summary>
        [TestMethod]
        public void TESTExtractTraceLogItemList()
        {
            string fileName = "Trace_fleet_20151102.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), LOGTYPE.Trace);
            Assert.IsTrue(file.Count == items.Count);

        }

        /// <summary>
        /// read trace file and insert one item to data base
        /// </summary>
        [TestMethod]
        public void TEST_InsertLOG_TO_DB()
        {
            string fileName = "Trace_fleet_20151102.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), LOGTYPE.Trace);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res =  repository.InsertLogItem(items[0]);
            Assert.IsTrue(res != null); 

        }

        /// <summary>
        /// ERROR When inserting duplicate key to DB
        /// </summary>
        [TestMethod]
        public void TEST_InsertAndGETErrorLOG_TO_DB()
        {
            string fileName = "Trace_fleet_20151101.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), LOGTYPE.Trace);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items);
            Assert.IsTrue(res != null);

        }

        
        /// <summary>
        /// read JSERROR file and insert one item to data base
        /// </summary>
        [TestMethod]
        public void TEST_Insert_JSERROR_LOG_TO_DB()
        {
            string fileName = "JSTrace_fleet_20151103.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), LOGTYPE.JSError);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items[0]);
            Assert.IsTrue(res != null);

        }

        /// <summary>
        /// read WARN file and insert one item to data base
        /// </summary>
        [TestMethod]
        public void TEST_Insert_WARN_LOG_TO_DB()
        {
            string fileName = "Warn_fleet_20151103.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), LOGTYPE.Warn);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items[0]);
            Assert.IsTrue(res != null);

        }

        /// <summary>
        /// read DBTrace file into logItem object
        /// </summary>
        [TestMethod]
        public void TEST_Insert_DBTrace_LIST_LOG_TO_DB()
        {
            string fileName = "DBTrace_fleet_20151102.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<string> newLins = LogReader.LogFileReader.UnifiedLogLines(file);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(newLins.ToArray(), LOGTYPE.DBTrace);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items);
            Assert.IsTrue(res != null);

        }

        /// <summary>
        /// read JSERROR file and insert list of item sto data base
        /// </summary>
        [TestMethod]
        public void TEST_Insert_JSERROR_LIST_LOG_TO_DB()
        {
            string fileName = "JSTrace_fleet_20151103.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), LOGTYPE.JSError);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items);
            Assert.IsTrue(res != null);

        }
        /// <summary>
        /// read WARN file and insert list items to database
        /// </summary>
        [TestMethod]
        public void TEST_Insert_WARN_LOG_LIST_TO_DB()
        {
            string fileName = "Warn_fleet_20151103.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(file.ToArray(), LOGTYPE.Warn);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items);
            Assert.IsTrue(res != null);
        }

        /// <summary>
        /// read FATAL file and insert list items to database
        /// </summary>
        [TestMethod]
        public void TEST_Insert_FATAL_LOG_LIST_TO_DB()
        {
            string fileName = "Fatal_fleet_20161211.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<string> newLins = LogReader.LogFileReader.UnifiedLogLines(file);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(newLins.ToArray(), LOGTYPE.Fatal);            
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items);
            Assert.IsTrue(res != null);
        }


        /// <summary>
        /// read FATAL file and insert list items to database
        /// </summary>
        [TestMethod]
        public void TEST_Insert_ERROR_LOG_LIST_TO_DB()
        {
            string fileName = "Error_fleet_20161211.log";
            List<string> file = LogReader.LogFileReader.ReadFile(fileName);
            List<string> newLins = LogReader.LogFileReader.UnifiedLogLines(file);
            List<LogItem> items = LogReader.LogFileReader.LinesToLogs(newLins.ToArray(), LOGTYPE.Error);
            LogItemRepository repository = new LogItemRepository();
            BaseResultInfo res = repository.InsertLogItem(items);
            Assert.IsTrue(res != null);
        }

        [TestMethod]
        public void TEST_Insert_ALL_LOG_LIST_TO_DB()
        {
            TestDataHelper.FileToDB("Trace_fleet_20151102.log", LOGTYPE.Trace, true);
            TestDataHelper.FileToDB("DBTrace_fleet_20151102.log", LOGTYPE.DBTrace, true);
             TestDataHelper.FileToDB("Warn_fleet_20151103.log", LOGTYPE.Warn, false);
           TestDataHelper.FileToDB("JSTrace_fleet_20151103.log", LOGTYPE.JSError, false);
             BaseResultInfo res = TestDataHelper.FileToDB("Fatal_fleet_20151103.log", LOGTYPE.Fatal, true);
            Assert.IsTrue(res != null);
        }

        /// <summary>
        /// GET the last item in db
        /// </summary>
        [TestMethod]
        public void TEST_GET_LAST_ITEM()
        {

            BaseResultInfo res = TestDataHelper.GetLastItem(LOGTYPE.DBTrace,null);
            Assert.IsTrue(res != null);
        }
        
    }
}
