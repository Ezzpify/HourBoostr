using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;
using SingleBoostr.Core.Enums;

namespace SingleBoostr.Core.Misc
{
    public class Log
    {
        public string mLogName;
        private string mLogPath;
        private List<string> mLogQueue;

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

        private void Write(string str)
        {
            mLogQueue.Add(str);
            FlushLog();
        }

        public void Write(LogLevel level, string str) => Write($"[{mLogName} {Utils.GetTimestamp()}] {level}: {str}");
        
        public void Write(LogLevel level, string str, bool writeToConsole = true)
        {
            if (writeToConsole)
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

                Console.WriteLine($"{mLogName} {Utils.GetTimestamp()} {level}: {str}");
            }
             
            Write(level, str);
            if (writeToConsole) Console.ForegroundColor = ConsoleColor.White;
        }

        private void FlushLog()
        {
            if (!File.Exists(mLogPath)) File.Create(mLogPath);

            try
            {
                var queueList = mLogQueue.ToList();
                using FileStream fs = File.Open(mLogPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                using StreamWriter sw = new StreamWriter(fs);
                queueList.ForEach(o => sw.WriteLine(o));
                mLogQueue.Clear();
            }
            catch (Exception ex)
            {
                Write(LogLevel.Error, $"Unable to flush log - {ex.Message}");
            }
        }
    }
}