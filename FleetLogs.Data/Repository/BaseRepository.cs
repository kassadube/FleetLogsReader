using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetLogs.Data;
using System.Configuration;

namespace FleetLogs.Data
{
    public class BaseRepository
    {



        ApplicationContextMode _mode;
        private string _connectionString;
        private string _readConnectionString;
        private string _safetyConnectionString;
        public BaseRepository()
        {

            _mode = System.Web.HttpContext.Current == null ? ApplicationContextMode.CONSOLE : ApplicationContextMode.WEB;
        }
        protected string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_connectionString)) return _connectionString;                
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                return _connectionString;
            }
        }

        


    }
    public enum ApplicationContextMode
    {
        WEB, CONSOLE
    }
}
