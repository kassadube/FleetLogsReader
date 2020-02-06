using SharpCompress.Common;
using SharpCompress.Reader;
using SharpCompress.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetLogs.Archive
{
    public class BaseArchiveWriter:BaseArchive
    {
        private ArchiveType type;
        public BaseArchiveWriter(ArchiveType type)
        {
            this.type = type;
        }

        public void Write(CompressionType compressionType, string archive)
        {
           // ResetScratch();
            using (Stream stream = File.OpenWrite(Path.Combine(ORIGINAL_FILES_PATH, archive)))
            using (var writer = WriterFactory.Open(stream, type, compressionType))
            {
               writer.WriteAll(LOG_FILES_PATH, "*", SearchOption.AllDirectories);
                
            }
            

          //  using (Stream stream = File.OpenRead(Path.Combine(SCRATCH2_FILES_PATH, archive)))
         //   using (var reader = ReaderFactory.Open(stream))
         //   {
          //     reader.WriteAllToDirectory(SCRATCH_FILES_PATH, ExtractOptions.ExtractFullPath);
         //   }
           // VerifyFiles();
        }

        public void WriteFiles(CompressionType compressionType, string archive, List<string>files)
        {
            // ResetScratch();
            using (Stream stream = File.OpenWrite(Path.Combine(ORIGINAL_FILES_PATH, archive)))
            using (var writer = WriterFactory.Open(stream, type, compressionType))
            {
                foreach (var item in files)
                {
                    FileInfo f = new FileInfo(item);
                    writer.Write(f.Name, f);
                }
                writer.WriteAll(LOG_FILES_PATH, "*", SearchOption.AllDirectories);

            }
        }

        public void WriteFiles(CompressionType compressionType, string archive, List<FileInfo> files)
        {
            // ResetScratch();
            using (Stream stream = File.OpenWrite(Path.Combine(ORIGINAL_FILES_PATH, archive)))
            using (var writer = WriterFactory.Open(stream, type, compressionType))
            {
                foreach (var item in files)
                {
                    writer.Write(Path.Combine(item.Directory.Name, item.Name), item);
                }
            }
        }
    }
}
