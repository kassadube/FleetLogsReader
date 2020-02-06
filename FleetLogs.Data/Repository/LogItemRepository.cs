using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetLogs.Data;
using Toolkit.Serialization;
using FleetLogs.Model;

namespace FleetLogs.Data
{
    public class LogItemRepository: BaseRepository
    {
        private const string SQL_ADD_LOG_ITEM = "[dbo].[AddLogItem]";
        private const string SQL_GET_LAST_LOG_ITEM = "[dbo].[GetLastLogItem]";
        private const string SQL_GET_LOGINS = "[dbo].[GetLogins]";
        private const string SQL_GET_LOGINS_LENGTH = "[dbo].[GetLoginsLength]";

        public LogItemRepository()
        {

        }

        public BaseResultInfo InsertLogItem(LogItem item)
        {
            BaseResultInfo result = new BaseResultInfo();

            SqlParameterList commandParams = SqlSerializer.Serialize(item);
           

            try
            {
                using (SqlConnection conn = new SqlConnection(base.ConnectionString))
                {
                    conn.Open();
                    SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SQL_ADD_LOG_ITEM, commandParams.ToArray());
                    result.ReturnValue = commandParams.GetReturnValue();

                    if (result.ReturnValue < 0)
                    {
                        throw new Exception("SQL_ADD_LOG_ITEM");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (result.Error == null)
                    result.Error = new BaseErrorInfo();

                result.Error.BuildException(ex);
            }
            return result;
        }

        public BaseResultInfo InsertLogItem(List<LogItem> items)
        {
            SiteLogger.ILogger logger = SiteLogger.LoggingFactory.GetLogger;
            BaseResultInfo result = new BaseResultInfo();
            
            List<ResultLogItem> errorData = new List<ResultLogItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection(base.ConnectionString))
                {
                    
                    conn.Open();
                    SqlParameterList commandParams = new SqlParameterList();
                    int successCount = 0;
                    foreach (var item in items)
                    {
                        
                        try
                        {
                            commandParams = SqlSerializer.Serialize(item);
                            int res = SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SQL_ADD_LOG_ITEM, commandParams.ToArray());
                            successCount++;
                        }
                        catch(Exception ex)
                        {
                            logger.Error(string.Format("INDEX = {0}, DATETIME = {1}, LOG_TYPE = {2}, MESSAGE = {3}", item.Index, item.InsertDate, item.LogType, ex.Message));
                            errorData.Add(new ResultLogItem() { Log = item, ErrorMessage = ex.Message });
                        }
                    }
                    result.ReturnValue = successCount; commandParams.GetReturnValue();
                    result.ResultObject = errorData;
                    conn.Close();
                    if (result.ReturnValue < 0)
                    {
                        throw new Exception("SQL_ADD_LOG_ITEM");
                    }

                }
            }
            catch (Exception ex)
            {
                if (result.Error == null)
                    result.Error = new BaseErrorInfo();

                result.Error.BuildException(ex);
            }
            return result;
        }

        public BaseResultInfo GetLogItems()
        {
            BaseResultInfo res = new BaseResultInfo() { ResultObject = new List<LogItem>() };
            return res;
        }

        public BaseResultInfo GetLastLogItem(string logType,string server)
        {
            BaseResultInfo result = new BaseResultInfo();

            SqlParameterList commandParams = new SqlParameterList();

            commandParams.Add("@LogType", SqlDbType.NVarChar, logType);
            commandParams.Add("@LogServer", SqlDbType.NVarChar, server);

            try
            {
                using (SqlConnection conn = new SqlConnection(base.ConnectionString))
                {
                    using (SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, SQL_GET_LAST_LOG_ITEM, commandParams.ToArray()))
                    {
                        while (dr.Read())
                        {
                            LogItem a = Serializer.DeSerialize<LogItem>(dr);
                            result.ResultObject = a;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (result.Error == null)
                    result.Error = new BaseErrorInfo();

                result.Error.BuildException(ex);
            }
            return result;
        }

        public BaseResultInfo GetUniqLogins(DateTime start, DateTime? end)
        {
            BaseResultInfo result = new BaseResultInfo() ;

            SqlParameterList commandParams = new SqlParameterList();

            commandParams.Add("@StartDate", SqlDbType.DateTime, start);
            commandParams.Add("@EndDate", SqlDbType.DateTime, end);
            List<LogItem> items = new List<LogItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection(base.ConnectionString))
                {
                    using (SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, SQL_GET_LOGINS, commandParams.ToArray()))
                    {
                        while (dr.Read())
                        {
                            LogItem a = Serializer.DeSerialize<LogItem>(dr);
                            items.Add(a);
                            
                        }
                        result.ResultObject = items;
                    }

                }
            }
            catch (Exception ex)
            {
                if (result.Error == null)
                    result.Error = new BaseErrorInfo();

                result.Error.BuildException(ex);
            }
            return result;
        }

        public BaseResultInfo GetLoginsLength(DateTime start, DateTime? end)
        {
            BaseResultInfo result = new BaseResultInfo();

            SqlParameterList commandParams = new SqlParameterList();

            commandParams.Add("@StartDate", SqlDbType.DateTime, start);
            commandParams.Add("@EndDate", SqlDbType.DateTime, end);
            List<LoginLengthInfo> items = new List<LoginLengthInfo>();
            try
            {
                using (SqlConnection conn = new SqlConnection(base.ConnectionString))
                {
                    using (SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, SQL_GET_LOGINS_LENGTH, commandParams.ToArray()))
                    {
                        while (dr.Read())
                        {
                            LoginLengthInfo a = Serializer.DeSerialize<LoginLengthInfo>(dr);
                            items.Add(a);

                        }
                        result.ResultObject = items;
                    }

                }
            }
            catch (Exception ex)
            {
                if (result.Error == null)
                    result.Error = new BaseErrorInfo();

                result.Error.BuildException(ex);
            }
            return result;
        }

        public BaseResultInfo SearchItems(LogItemRequest request)
        {
            BaseResultInfo result = new BaseResultInfo();

            SqlParameterList commandParams = new SqlParameterList();
            string select = " select * from LogTBL where InsertDate > @StartDate and InsertDate < @EndDate";
            commandParams.Add("@StartDate", SqlDbType.DateTime, request.StartDate);
            commandParams.Add("@EndDate", SqlDbType.DateTime, request.EndDate);
            if (request.logType.HasValue)
            {
                select += " and LogType = @LogType";
                commandParams.Add("@LogType", SqlDbType.NVarChar, request.logType.ToString());
            }
            if (!string.IsNullOrEmpty(request.SiteId))
            {
                select += " and SiteId = @SiteId";
                commandParams.Add("@SiteId", SqlDbType.NVarChar, request.SiteId);
            }

            if (request.AccountId.HasValue)
            {
                select += " and AccountId = @AccountId";
                commandParams.Add("@AccountId", SqlDbType.Int, request.AccountId);
            }

            List<LogItem> items = new List<LogItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection(base.ConnectionString))
                {
                    using (SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, select, commandParams.ToArray()))
                    {
                        while (dr.Read())
                        {
                            LogItem a = Serializer.DeSerialize<LogItem>(dr);
                            items.Add(a);

                        }
                        result.ResultObject = items;
                    }

                }
            }
            catch (Exception ex)
            {
                if (result.Error == null)
                    result.Error = new BaseErrorInfo();

                result.Error.BuildException(ex);
            }
            return result;
        }
    }
}
