using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace UpastitiCS
{
    class SQLite
    {
        private string connectionString;
        private SQLiteConnection conn = null;
        private readonly object _locker = new object();
        public SQLite()
        {

            connectionString = string.Format(@"Data Source={0}\Upastiti.db;", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
        }
        public void setConnString(string s)
        {
            connectionString = s;
        }
        public bool connect()
        {
            try
            {
                lock (_locker)
                {
                    conn = new SQLiteConnection(connectionString);
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.log("Exception(SQLite_connect): "+ex.Message);
            }
            return false;
        }
        public int executeNonQuery(string s)
        {
            try
            {
                lock (_locker)
                {
                    SQLiteCommand cmd = new SQLiteCommand(s, conn);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.log("Exception(SQLite_executeNonQuery): " + ex.Message);
                
            }
            return 0;
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
                Console.WriteLine(ex.Message);
                Logger.log("Exception(SQLite_close): " + ex.Message);
            }
            return false;
        }
        public SQLiteConnection getConnection()
        {
            return conn;
        }
        public int createTables()
        {
            int result = 0;
            try
            {
                lock (_locker)
                {
                    if (conn != null)
                    {
                        result = executeNonQuery("create table if not exists plant(plantname varchar(255) primary key);");
                        result += executeNonQuery("create table if not exists staff(staffno varchar(20) primary key,staffname varchar(255),plantname varchar(255) REFERENCES plant(plantname),status varchar(20),createdon datetime,lastmodifiedon datetime,finger1 varbinary(1024),finger2 varbinary(1024));");
                       // result += executeNonQuery("create table if not exists attendance(staffno varchar(20) REFERENCES staff(staffno),attendeddate date, primary key(staffno,attendeddate));");
                        result += executeNonQuery("create table if not exists movement(staffno varchar(20) REFERENCES staff(staffno),moveon datetime,shiftcode varchar(20), primary key(staffno,moveon));");
                        //result += executeNonQuery("create table if not exists todaymovement(staffno varchar(20) REFERENCES staff(staffno),moveon datetime, primary key(staffno,moveon));");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.log("Exception(SQLite_close): " + ex.Message);
            }
            return result;
        }
    }
}
