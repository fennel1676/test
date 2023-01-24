using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LogCore
{
	public partial class LogManager : Component
	{
		private string logFilePath = "";
		private int logDeleteDay = 60;
        private string logNameType = "yyyyMMdd_HH";
        private string logFileType = ".txt";

		public string LogFilePath
		{
			get { return logFilePath; }
			set { logFilePath = value; }
		}
		public int LogDeleteDay
		{
			get { return logDeleteDay; }
			set { logDeleteDay = value; }
		}

        public string LogNameType
        {
            get { return logNameType; }
            set { logNameType = value; }
        }

        public string LogFileType
        {
            get { return logFileType; }
            set { logFileType = value; }
        }


		public delegate void LogWriteEvent(object sender, LogEventArgs args);
		public event LogWriteEvent OnLogWriteEvent = null;


		public LogManager()
		{
			InitializeComponent();
		}
		public LogManager(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

        //일반 로그 파일
        public eLogResult WriteLog(string logText)
        {
            eLogResult result = eLogResult.OK;
            LogInfo logInfo = new LogInfo(logText);

            if (logFilePath.Trim() != "")
            {
                string pathName = logFilePath.TrimEnd('\\');
                string fileName = pathName + "\\" + logInfo.LogTime.ToString(logNameType) + logFileType;
                if (!Directory.Exists(pathName)) Directory.CreateDirectory(pathName);

                if (Directory.Exists(pathName))
                {
                    try
                    {
                        using (StreamWriter sw = File.AppendText(fileName))
                        {
                            sw.WriteLine(logInfo.LogTime.ToString("[HH:mm:ss]") + logInfo.LogText);
                        }
                    }
                    catch
                    {
                        result = eLogResult.NotAccessFile;
                    }
                }
                else
                {
                    result = eLogResult.NotFoundDirectory;
                }
            }
            else
            {
                result = eLogResult.NotFilePath;
            }

            //Event
            if (OnLogWriteEvent != null)
            {
                LogEventArgs args = new LogEventArgs(logInfo);
                OnLogWriteEvent(this, args);
            }

            return result;
        }
        //Main Log 
		public eLogResult WriteLog(short line, short serial, string logText)
		{
			eLogResult result = eLogResult.OK;
			LogInfo logInfo = new LogInfo(logText);

			if (logFilePath.Trim() != "")
			{
				string pathName = logFilePath.TrimEnd('\\');
                string fileName = pathName + "\\" + logInfo.LogTime.ToString(logNameType) + logFileType;
				if (!Directory.Exists(pathName)) Directory.CreateDirectory(pathName);

				if (Directory.Exists(pathName))
				{
					try
					{
                        File.AppendAllText(fileName, logInfo.LogTime.ToString("[HH:mm:ss]") + "," + line.ToString() + "," + serial.ToString() + "," + logInfo.LogText + "\r\n", Encoding.Default);
					}
					catch
					{
						result = eLogResult.NotAccessFile;
					}
				}
				else
				{
					result = eLogResult.NotFoundDirectory;
				}
			}
			else
			{
				result = eLogResult.NotFilePath;
			}

			//Event
			if (OnLogWriteEvent != null)
			{
				LogEventArgs args = new LogEventArgs(logInfo);
				OnLogWriteEvent(this, args);
			}

			return result;
		}
        //Alarm Log 
        public eLogResult WriteLog(string time, string alarmSet, string unit, string ID, string logText)
        {
            eLogResult result = eLogResult.OK;
            LogInfo logInfo = new LogInfo(logText);

            if (logFilePath.Trim() != "")
            {
                string pathName = logFilePath.TrimEnd('\\');
                string fileName = pathName + "\\" + DateTime.Now.ToString(logNameType) + logFileType;
                if (!Directory.Exists(pathName)) Directory.CreateDirectory(pathName);

                if (Directory.Exists(pathName))
                {
                    try
                    {
                        File.AppendAllText(fileName, DateTime.Now.ToString("[HH:mm:ss]") + "," + alarmSet + "," + unit + "," + ID + "," + logText + "\r\n", Encoding.Default);
                    }
                    catch
                    {
                        result = eLogResult.NotAccessFile;
                    }
                }
                else
                {
                    result = eLogResult.NotFoundDirectory;
                }
            }
            else
            {
                result = eLogResult.NotFilePath;
            }

            //Event
            if (OnLogWriteEvent != null)
            {
                LogEventArgs args = new LogEventArgs(logInfo);
                OnLogWriteEvent(this, args);
            }

            return result;
        }
		private void deleteTimer_Tick(object sender, EventArgs e)
		{           
            DirectoryInfo files = new DirectoryInfo(logFilePath);
            if (files.Exists == true)
            {
                foreach (FileInfo fileInfo in files.GetFiles())
                {
                    if (fileInfo.Extension != logFileType) continue;

                    if (fileInfo.CreationTime <= DateTime.Now.AddDays(-logDeleteDay))
                    {
                        try
                        {
                            fileInfo.Delete();
                        }
                        catch { }
                    }
                }
            }
		}
	}
}
