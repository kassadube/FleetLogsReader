using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolkit.Serialization;

namespace FleetLogs.Model
{
    [TDataSerialize]
    public class LogItem
    {
       // public ObjectId Id { get; set; }
        public int Index { get; set; }
        public string LogServer { get; set; }
        public string SiteId { get; set; }
        public int? AccountId { get; set; }
        public int? UserId { get; set; }
        public DateTime InsertDate { get; set; }
        public string Message { get; set; }
        [TDataSerialize(SqlDbType = System.Data.SqlDbType.NVarChar)]
        public LOGTYPE LogType { get; set; }
        public string Url { get; set; }
        public string Referrer { get; set; }
        public string Trace { get; set; }
        //[TDataSerialize(Ignore=true)]
        public string UserAgent { get; set; }
        [TDataSerialize(Ignore = true)]
        public bool AddMissingItems { get; set; }
        [TDataSerialize(Ignore = true)]
        public bool WriteToDefault { get; set; }

        
    }

    [TDataSerialize]
    public class LogItemRequest
    {
        public string LogServer { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public LOGTYPE? logType { get; set; }
        public string SiteId { get; set; }
        public int? AccountId { get; set; }

    }

    public enum LOGTYPE
    {
        Info = 1,
        Debug = 2,
        Warn = 3,
        Trace = 4,
        Error = 5,
        Fatal = 6,
        JSError = 7,
        DBTrace = 8,
        Test = 9,
        Report = 10,
        Cache = 11
    }

    public class ResultLogItem
    {
        public LogItem Log { get; set; }
        public string ErrorMessage { get; set; }
    }
}
