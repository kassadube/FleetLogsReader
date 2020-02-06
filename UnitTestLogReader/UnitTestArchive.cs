using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using FleetLogs.Model;
using FleetLogs.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;
using FleetLogs.Archive;
using SharpCompress.Common;
//using ;

namespace UnitTestLogReader
{
    [TestClass]
    public class UnitTestArchive
    {
        
        /// <summary>
        /// Get log files from data directory from app.config
        /// </summary>
        [TestMethod]
        public void TEST_ArchiveDirctory()
        {
            BaseArchiveWriter writer = new BaseArchiveWriter(ArchiveType.Zip);
            writer.Write(CompressionType.BZip2, "Test.rar");
            Assert.IsTrue(true);
                //Write(CompressionType.BZip2, "Tar.noEmptyDirs.tar.bz2", "Tar.noEmptyDirs.tar.bz2");

        }

        /// <summary>
        /// Get log files from data directory from app.config
        /// </summary>
        [TestMethod]
        public void TEST_ArchiveFiles()
        {
            string directoryName = ConfigurationManager.AppSettings["DIR"];
            List<FileInfo> files = LogReader.LogFileDirectoryManager.GetLogFiles(directoryName);

            BaseArchiveWriter writer = new BaseArchiveWriter(ArchiveType.Zip);


            writer.WriteFiles(CompressionType.BZip2, "Test.rar", files);
            Assert.IsTrue(true);
            //Write(CompressionType.BZip2, "Tar.noEmptyDirs.tar.bz2", "Tar.noEmptyDirs.tar.bz2");

        }

        
    }
}
