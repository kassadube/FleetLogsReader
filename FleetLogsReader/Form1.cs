using FleetLogs.Archive;
using FleetLogs.Model;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toolkit.Extensions;
using Toolkit.Web;



namespace FleetLogsReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dtStart.Format = DateTimePickerFormat.Custom;
            dtStart.CustomFormat = "yyyy MM dd  HH mm ss";
            dtStart.Value = DateTime.Now.AddHours(-DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute);
            dtEnd.Format = DateTimePickerFormat.Custom;
            dtEnd.CustomFormat = "yyyy MM dd  HH mm ss";

            dtStartSession.Format = DateTimePickerFormat.Custom;
            dtStartSession.CustomFormat = "yyyy MM dd  HH mm ss";
            //dtStart.Value = DateTime.Now.AddHours(-DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute);
            dtEndSession.Format = DateTimePickerFormat.Custom;
            dtEndSession.CustomFormat = "yyyy MM dd  HH mm ss";
        }

        private void btnCopyFiles_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            int daysBack = ConfigurationManager.AppSettings["DAYS"].StringToInt();
            List<string> QADir = ConfigurationManager.AppSettings["SITE_LOG_DIR"].Split(';').ToList();
            string destDir = ConfigurationManager.AppSettings["DIR"];
            int count = 0;
            for (int i = 0; i < QADir.Count; i++)
			{
                var item = QADir[i];
                var dest = Path.Combine(destDir, "0" + i.ToString());
                int tCount = LogReader.LogFileDirectoryManager.CopyLogFiles(item, dest, start, daysBack,SearchOption.TopDirectoryOnly);
                count += tCount;
			}
            
            
            MessageBox.Show(string.Format("{0} Files copied", count), "", MessageBoxButtons.OK);
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            string directoryName = ConfigurationManager.AppSettings["DIR"];
            List<FileInfo> files = LogReader.LogFileDirectoryManager.GetLogFiles(directoryName,DateTime.Now,2);
            BaseArchiveWriter writer = new BaseArchiveWriter(ArchiveType.Zip);

            //writer.Write(CompressionType.BZip2, "Test.rar");
            writer.WriteFiles(CompressionType.BZip2, "Test.rar", files);
            MessageBox.Show("Done!", "", MessageBoxButtons.OK);
        }

        private void AddToDBBTN_Click(object sender, EventArgs e)
        {

            CultureInfo cur_culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = cur_culture.DateTimeFormat;
            Thread.CurrentThread.CurrentCulture = cur_culture;
            BaseResultInfo res = DataHelper.AllNewLogFilesToDB();
        }

        private void btnDeleteLogfiles_Click(object sender, EventArgs e)
        {
            bool res = DataHelper.DeleteFiles(true);
            MessageBox.Show(res.ToString(), "", MessageBoxButtons.OK);
        }

        private void btnMoveRar_Click(object sender, EventArgs e)
        {
            BaseArchive b = new BaseArchive();
            DirectoryInfo dir = new DirectoryInfo(BaseArchive.ORIGINAL_FILES_PATH);
            DirectoryInfo SiteDir = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings["SITE_DIR"]);
            FileInfo[] files = dir.GetFiles();
            if(files.Length >0)
            {
                string fileName = Path.Combine(SiteDir.FullName, DateTime.Now.Ticks.ToString()+".rar");
                files[0].MoveTo(fileName);
                bool res =Toolkit.Web.Mailer.Send("noams@pointer.com", "log Was created", fileName, "PointerFleet@pointer.com", true);
                MessageBox.Show(string.Format("FILE {0} has transfer and was sent {1}",fileName,res), "", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("NO FILE", "", MessageBoxButtons.OK);
            
        }

        private void btnGetUniq_Click(object sender, EventArgs e)
        {
            DateTime start = dtStart.Value;
            DateTime end = dtEnd.Value;
            BaseResultInfo res = DataHelper.GetLogins(start, end);
            List<LogItem> items = res.GetResult<List<LogItem>>();
            BaseResultInfo resLength = DataHelper.GetLoginsLength(start, end);
            List<LoginLengthInfo> itemsLength = resLength.GetResult<List<LoginLengthInfo>>();
            if(items != null)
            {
                var clearItems = (from a in items
                                 where a.AccountId != -23
                                 orderby a.AccountId
                                 select  new LoginGridData { InsertDate = a.InsertDate, AccountId = a.AccountId, SiteId = a.SiteId, Message = a.Message }).ToList();
                lblResult.Text = "NUMBER OF ITEMS {0}".StringFormat(clearItems.Count);
               
                
                dgGrid.DataSource = clearItems;
                dgGrid.Update();
               
                 
            }
           
        }

        private void btnLoginLength_Click(object sender, EventArgs e)
        {
            DateTime start = dtStart.Value;
            DateTime end = dtEnd.Value;
            BaseResultInfo res = DataHelper.GetLogins(start, end);
            List<LogItem> items = res.GetResult<List<LogItem>>();
            BaseResultInfo resLength = DataHelper.GetLoginsLength(start, end);
            List<LoginLengthInfo> itemsLength = resLength.GetResult<List<LoginLengthInfo>>();
            if (items != null)
            {


                var clearItems = (from a in items
                                 join b in itemsLength on a.SiteId equals b.SiteId
                                 where a.AccountId != -23
                                  select new LoginLengthGridData() { SiteId = a.SiteId,AccountId= a.AccountId,Message = a.Message, StartDate = b.StartDate, EndDate= b.EndDate, Length = b.Length }).ToList();

                double dbl = clearItems.Average(x => TimeSpan.Parse(x.Length).Ticks);
                lblResult.Text = "NUMBER OF ITEMS {0} AVERAGE {1}".StringFormat(clearItems.Count, new TimeSpan((long) dbl));

                dgGrid.DataSource = clearItems;
                dgGrid.Update();
            }
        }
        
        private void btnSearchMsg_Click(object sender, EventArgs e)
        {
            var s = dgGrid.DataSource as List<LoginLengthGridData>;
            string crit = txSearchMessage.Text;

            dgGrid.DataSource = (from a in s
                                 where a.Message != null && a.Message.Contains(crit)
                                 select a).ToList();
            dgGrid.Update();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LogItemRequest request = new LogItemRequest();
            request.StartDate = dtStart.Value;
            request.EndDate = dtEnd.Value;
            
            if(!string.IsNullOrEmpty(cbLogType.Text))
                request.logType =(LOGTYPE?) Enum.Parse(typeof(LOGTYPE), cbLogType.Text);

            if (!string.IsNullOrEmpty(txtSiteId.Text))
                request.SiteId = txtSiteId.Text;

            if (!string.IsNullOrEmpty(txtAccountId.Text))
                request.AccountId = int.Parse(txtAccountId.Text);

            BaseResultInfo res = DataHelper.SearchItems(request);
            List<LogItem> items = res.GetResult<List<LogItem>>();
            lblResult.Text = "NUMBER OF ITEMS {0}".StringFormat(items.Count);
            dgGrid.DataSource = items;
            dgGrid.Update();


        }

        List<LogItem> itemsBeforeSort;
        private void btnSort_Click(object sender, EventArgs e)
        {
            itemsBeforeSort = dgGrid.DataSource as List<LogItem>;
            var items = dgGrid.DataSource as List<LogItem>;

            string sortItem = cbSort.Text;

            switch (sortItem)
            {
                case "InsertDate":
                    dgGrid.DataSource = items.OrderBy(x => x.InsertDate).ToList();
                    break;
                case "Trace":
                    dgGrid.DataSource = items.OrderBy(x => x.Trace).ToList();
                    break;
                case "Message":
                    dgGrid.DataSource = items.OrderBy(x => x.Message).ToList();
                    break;
                default:
                    break;
            }

            dgGrid.Update();
        }

        

        
        
        
    }
}
