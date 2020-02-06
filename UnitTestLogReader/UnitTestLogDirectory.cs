using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using FleetLogs.Model;
using FleetLogs.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;
//using ;

namespace UnitTestLogReader
{
    [TestClass]
    public class UnitTestLogDirectory
    {
        
        /// <summary>
        /// Get log files from data directory from app.config
        /// </summary>
        [TestMethod]
        public void TEST_ReadDirctory()
        {
            string directoryName = ConfigurationManager.AppSettings["DIR"];
            List<FileInfo> files = LogReader.LogFileDirectoryManager.GetLogFiles(directoryName);
            Assert.IsTrue(files != null);
        }

        /// <summary>
        /// Get log files from data directory from app.config BY Date
        /// </summary>
        [TestMethod]
        public void TEST_ReadDirctory_By_Date()
        {
            DateTime start = DateTime.Now;
            int daysBack = 5;
            string directoryName = ConfigurationManager.AppSettings["DIR"];
            List<FileInfo> files = LogReader.LogFileDirectoryManager.GetLogFiles(directoryName, start,daysBack);
            Assert.IsTrue(files != null);
        }

        /// <summary>
        /// Get log files from data directory from app.config
        /// </summary>
        [TestMethod]
        public void TEST_Copy_QA_Files()
        {
            string QADir = @"\\10.169.1.20\c$\inetpub\wwwroot\Fleet\Logs";
            string destDir = ConfigurationManager.AppSettings["DIR"];
            LogReader.LogFileDirectoryManager.CopyLogFiles(QADir, destDir);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Get log files from data directory from app.config
        /// </summary>
        [TestMethod]
        public void TEST_Copy_QA_Files_By_Date()
        {
            DateTime start = DateTime.Now;
            int daysBack = 2;
            string QADir = @"\\10.169.1.20\c$\inetpub\wwwroot\Fleet\Logs";
            string destDir = ConfigurationManager.AppSettings["DIR"];
            LogReader.LogFileDirectoryManager.CopyLogFiles(QADir, destDir,start, daysBack);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Get log files from data directory from app.config
        /// </summary>
        [TestMethod]
        public void TEST_Get_Logtype_From_FileName()
        {
            List<FileInfo> files = TestDataHelper.GetLogFiles();
            LOGTYPE? logType = TestDataHelper.GetLogTypeFromLogFileName(files[0].Name);
            Assert.IsTrue(logType.HasValue);
        }
        /// <summary>
        /// Get log files from data directory from app.config
        /// </summary>
        [TestMethod]
        public void TEST_AllLogFilesToDB()
        {
            CultureInfo cur_culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = cur_culture.DateTimeFormat;
            Thread.CurrentThread.CurrentCulture = cur_culture;
            BaseResultInfo res= TestDataHelper.AllLogFilesToDB();
            Assert.IsTrue(res != null);
        }

        /// <summary>
        /// Get log files from data directory from app.config
        /// </summary>
        [TestMethod]
        public void TEST_AllLogFilesNEWToDB()
        {
            CultureInfo cur_culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = cur_culture.DateTimeFormat;
            Thread.CurrentThread.CurrentCulture = cur_culture;
            BaseResultInfo res = TestDataHelper.AllNewLogFilesToDB();
            Assert.IsTrue(res != null);
        }
    }
}
