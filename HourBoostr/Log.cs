using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;

namespace HourBoostr
{
    class Log
    {
        /// <summary>
        /// Queue of messages
        /// </summary>
        private List<string> mLogQueue;


        /// <summary>
        /// Size of queue before we flush to file
        /// </summary>
        private int mLogQueueSize;


        /// <summary>
        /// Path to the log file
        /// </summary>
        private string mLogPath;


        /// <summary>
        /// Name of the log file
        /// </summary>
        public string mLogName;


        /// <summary>
        /// LogLevel to specify type of log call
        /// </summary>
        public enum LogLevel
        {
            Debug,
            Info,
            Success,
            Warn,
            Text,
            Error
        }


        /// <summary>
        /// Class constructor
        /// Initializes the log file
        /// </summary>
        /// <param name="logName">Log name to easier recognize which log is speaking</param>
        /// <param name="logPath">Path to log file</param>
        /// <param name="queueSize">How many log entries we keep before flushing file</param>
        public Log(string logName, string logPath, int queueSize)
        {
            mLogName = logName;
            mLogPath = logPath;
            mLogQueueSize = queueSize;
            mLogQueue = new List<string>();

            if (!File.Exists(logPath))
            {
                File.Create(logPath).Close();
                Console.WriteLine($"Log file '{mLogName}' created for path '{mLogPath}");
                Thread.Sleep(250);
            }
        }


        /// <summary>
        /// Returns a datetime timestmap
        /// </summary>
        /// <returns>Returns timestamp string</returns>
        private string GetTimestamp()
        {
            return DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
        }


        /// <summary>
        /// Writes a log message
        /// </summary>
        /// <param name="level">Level of message</param>
        /// <param name="str">String to write</param>
        /// <param name="logToFile">If we should write message to log file</param>
        public void Write(LogLevel level, string str, bool logToFile = true, bool writeToConsole = true, bool rawMessage = false)
        {
            switch (level)
            {
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogLevel.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Text:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }

            string formattedMessage = $"[{GetTimestamp()}] {level}: {str}";

            if (writeToConsole)
                Console.WriteLine($"{mLogName} {formattedMessage}");

            if (logToFile)
            {
                if (rawMessage)
                    mLogQueue.Add(str);
                else
                    mLogQueue.Add(formattedMessage);
            }


            Console.ForegroundColor = ConsoleColor.White;
            FlushLog();
        }


        /// <summary>
        /// Flushes the log to file
        /// </summary>
        private void FlushLog()
        {
            if (mLogQueue.Count < mLogQueueSize)
                return;

            if (!File.Exists(mLogPath))
                File.Create(mLogPath);

            try
            {
                var queueList = mLogQueue.ToList();
                using (FileStream fs = File.Open(mLogPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var str in queueList)
                            sw.WriteLine(str);

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