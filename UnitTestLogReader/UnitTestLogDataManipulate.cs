using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using FleetLogs.Model;
using FleetLogs.Data;
using System.Linq;

namespace UnitTestLogReader
{
    [TestClass]
    public class UnitTestLogDataManipulate
    {

        [TestMethod]
        public void TEST_TEMP()
        {
            string time ="02:28:13";
            TimeSpan tt = TimeSpan.Parse(time);
            DateTime t = System.Convert.ToDateTime(time);
            Assert.IsTrue(tt != null);

        }
        [TestMethod]
        public void TEST_GET_UNIQ_LOGINS()
        {
            DateTime start = DateTime.Now.AddHours(-DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute); ;
            DateTime end = DateTime.Now;
            BaseResultInfo res = TestDataHelper.GetLogins(start, end);
            List<LogItem> items = res.GetResult<List<LogItem>>();
            Assert.IsTrue(res != null);

        }

[TestMethod]
        public void TEST_JOIN_LOGINS_WITH_LENGTH()
        {
            DateTime start = DateTime.Now.AddHours(-DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute); ;
            DateTime end = DateTime.Now;
            BaseResultInfo res = TestDataHelper.GetLogins(start, end);
            List<LogItem> items = res.GetResult<List<LogItem>>();
            BaseResultInfo resLength = TestDataHelper.GetLoginsLength(start, end);
            List<LoginLengthInfo> itemsLength = resLength.GetResult<List<LoginLengthInfo>>();

            var list = from a in items
                       join b in itemsLength on a.SiteId equals b.SiteId
                       where a.AccountId != -23
                       select new {a.SiteId, a.AccountId, a.Message,b.StartDate, b.EndDate,b.Length };
            int v = list.Count();
            Assert.IsTrue(res != null);

        }
        
    }
}

 