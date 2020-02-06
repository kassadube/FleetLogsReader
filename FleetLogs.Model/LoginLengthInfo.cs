using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolkit.Serialization;

namespace FleetLogs.Model
{
    [TDataSerialize]
    public class LoginLengthInfo
    {
       public string SiteId { get; set; }
        public int? AccountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Length { get; set; }
    }

    
    //a.SiteId, a.AccountId, a.Message, b.StartDate, b.EndDate, b.Length 
    public class BaseLoginGridData
    {
        public string SiteId { get; set; }
        public int? AccountId { get; set; }
        public string Message { get; set; }
        
    }

    public class LoginGridData : BaseLoginGridData
    {
        public DateTime InsertDate { get; set; }
        
    }
    public class LoginLengthGridData : BaseLoginGridData
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Length { get; set; }
    }

 }
