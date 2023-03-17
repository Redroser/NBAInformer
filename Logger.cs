using System;
using System.IO;
using System.Threading;

namespace NBAInformer
{
    public class Logger
    {
        private readonly ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();

        private string LogDirectory { get; set; }

        public Logger()
        {
            LogDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/";

            if (!Directory.Exists(LogDirectory))
                Directory.CreateDirectory(LogDirectory);
        }

        public void Event(string _message)
        {
            lock_.EnterWriteLock();
            try
            {
                string filePath = LogDirectory + DateTime.Now.ToString("dd-MM-yy") + "_events.txt";
                using (StreamWriter writetext = new StreamWriter(filePath, append: true))
                {
                    writetext.WriteLine(_message);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }

        }

        public void Error(string _message)
        {
            lock_.EnterWriteLock();
            try
            {
                string filePath = LogDirectory + DateTime.Now.ToString("dd-MM-yy") + "_errors.txt";
                using (StreamWriter writetext = new StreamWriter(filePath, append: true))
                {
                    writetext.WriteLine(_message);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }

        }
    }
}
