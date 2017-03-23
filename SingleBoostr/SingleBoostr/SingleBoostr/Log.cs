using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;

namespace SingleBoostr
{
    class Log
    {
        public string mLogName;
        private string mLogPath;
        private List<string> mLogQueue;

        public enum LogLevel
        {
            Info, Warn, Error
        }

        public Log(string logPath)
        {
            Directory.CreateDirectory("Logs");

            mLogQueue = new List<string>();
            mLogPath = Path.Combine("Logs", logPath);
            mLogName = Path.GetFileNameWithoutExtension(logPath);

            if (!File.Exists(mLogPath))
            {
                File.Create(mLogPath).Close();
                Console.WriteLine($"Log file '{mLogName}' created for path '{mLogPath}");
                Thread.Sleep(250);
            }
        }

        public void Write(LogLevel level, string str)
        {
            string logString = logString = $"[{mLogName} {Utils.GetTimestamp()}] {level}: {str}";
            mLogQueue.Add(logString);
            FlushLog();
        }

        private void FlushLog()
        {
            if (!File.Exists(mLogPath))
                File.Create(mLogPath);

            try
            {
                var queueList = mLogQueue.ToList();
                using (FileStream fs = File.Open(mLogPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        queueList.ForEach(o => sw.WriteLine(o));
                        mLogQueue.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Write(LogLevel.Error, $"Unable to flush log - {ex.Message}");
            }
        }
    }
}
