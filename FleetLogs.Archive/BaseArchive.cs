using SharpCompress.Common;
using SharpCompress.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetLogs.Archive
{
    public class BaseArchive
    {
        public static string SOLUTION_BASE_PATH = null;
        public static string TEST_ARCHIVES_PATH;
        public static string ORIGINAL_FILES_PATH;
        protected static string MISC_TEST_FILES_PATH;
        protected static string SCRATCH_FILES_PATH;
        protected static string LOG_FILES_PATH;

        public BaseArchive()
        {
            LOG_FILES_PATH = System.Configuration.ConfigurationManager.AppSettings["LOG_DIR"];
            ORIGINAL_FILES_PATH = System.Configuration.ConfigurationManager.AppSettings["ARCHIVE_DIR"];
        }
        protected static IEnumerable<string> GetRarArchives()
        {
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Rar.none.rar");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Rar.rar");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Rar.solid.rar");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Rar.multi.part01.rar");
        }
        protected static IEnumerable<string> GetZipArchives()
        {
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.bzip2.dd.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.bzip2.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.deflate.dd-.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.deflate.dd.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.deflate.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.lzma.dd.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.lzma.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.none.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.ppmd.dd.zip");
            yield return Path.Combine(TEST_ARCHIVES_PATH, "Zip.ppmd.zip");
        }
        

       
        protected bool UseExtensionInsteadOfNameToVerify { get; set; }

        private static readonly object testLock = new object();

       
       
    }
}
