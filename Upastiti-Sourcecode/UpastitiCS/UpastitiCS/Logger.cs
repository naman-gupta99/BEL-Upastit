using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UpastitiCS
{
    static class Logger
    {
        private static StreamWriter file;
        public static void open()
        {
            try
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\IndriyaLog"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\IndriyaLog");
                }
                string sTimeStamp = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute;
                file = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\IndriyaLog\Log" + sTimeStamp + ".txt");
                file.AutoFlush = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception(LogOpen):" + ex.Message);
            }
        }
        public static void close()
        {
            try
            {
                if (file != null)
                {
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.log("Exception(LogClose):" + ex.Message);
            }
        }
        public static void log(string s)
        {
            try
            {
                if (file != null && file.BaseStream!=null)
                {
                    lock (file)
                    {
                        file.WriteLine("[{0}] {1}\n", DateTime.Now.ToString(), s);

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception(Log):" + ex.Message);
            }
        }
    }
}
