using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace UpastitiCS
{
    public class MsSQL
    {
        private string hostName = null;
        //private string port = null;
        private string username = null;
        private string password = null;
        private string dbname = null;
        private SqlConnection conn = null;
        private readonly object _locker = new object();
        public string sqlException = null;
        public MsSQL()
        {
            hostName = @"TESTINGMMF\SQLEXPRESS";
           // port = "3306";
            username = "sa";
            password = "";
            dbname = "UPASTITI";
        }
        public void initMsSQL(string host, string dbName, string uname, string pwd)
        {
            try
            {
                hostName = host;
                dbname = dbName;
                username = uname;
                password = pwd;                
            }
            catch (Exception ex)
            {
                sqlException = ex.Message;
                Logger.log("Exception(InitMsSQL)"+ex.Message);
            }
        }
        public bool connect()
        {
            try
            {
                lock (_locker)
                {
                    conn = new SqlConnection(string.Format("server={0};user={1};database={2};password={3};", hostName, username, dbname,password));
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                sqlException = ex.Message;
                Logger.log("Exception(MsSQLConnect)" + ex.Message);
            }
            return false;
        }
        public bool isConnected()
        {
            if (conn != null && conn.State==System.Data.ConnectionState.Open)
            {
                return true;
            }
            return false;
        }
        public int executeNonQuery(string s)
        {
            try
            {
                lock (_locker)
                {
                    SqlCommand cmd = new SqlCommand(s, conn);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                sqlException = ex.Message;
                Logger.log("Exception(ExecuteQuery:)" + ex.Message);
            }
            return -1;
        }
        public bool isDuplicateFound(string sql)
        {
            try
            {
                lock (_locker)
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        rdr.Close();
                        return true;
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                sqlException = ex.Message;
                Logger.log("Exception(isDuplicate):" + ex.Message);
            }
            return false;
        }

        public SqlConnection getConnection()
        {
            return conn;
        }
        public bool close()
        {
            try
            {
                lock (_locker)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                sqlException = ex.Message;
                Logger.log("Exception(MsSQLClose):" + ex.Message);
            }
            return false;
        }

    }
}
