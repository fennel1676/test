using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassCore;

namespace HostCore
{
	public partial class XGateForm : Form
	{
		//OCX컨트롤변수
		protected string BalloonTip
		{
			get { return this.xGateOCX.BalloonTip; }
			set { this.xGateOCX.BalloonTip = value; }
		}
		protected int ConnectPortNo
		{
			get { return this.xGateOCX.ConnectPortNo; }
			set { this.xGateOCX.ConnectPortNo = value; }
		}
		protected int DeviceID
		{
			get { return this.xGateOCX.DeviceID; }
			set { this.xGateOCX.DeviceID = value; }
		}
		protected XGateHostType Host
		{
			get { return (XGateHostType)this.xGateOCX.Host; }
			set { this.xGateOCX.Host = (int)value; }
		}
		protected XGateHsmsMode HsmsMode
		{
			get { return (XGateHsmsMode)this.xGateOCX.HsmsMode; }
			set { this.xGateOCX.HsmsMode = (int)value; }
		}
		protected int LinkTestCycleTime
		{
			get { return this.xGateOCX.LinkTestCycleTime; }
			set { this.xGateOCX.LinkTestCycleTime = value; }
		}
		protected int ListenPortNo
		{
			get { return this.xGateOCX.ListenPortNo; }
			set { this.xGateOCX.ListenPortNo = value; }
		}
		protected short LogFileDateLimit
		{
			get { return this.xGateOCX.LogFileDateLimit; }
			set { this.xGateOCX.LogFileDateLimit = value; }
		}
		protected string LogFilePath
		{
			get { return this.xGateOCX.LogFilePath; }
			set { this.xGateOCX.LogFilePath = value; }
		}
        //protected int LogFileSize
        //{
        //    get { return this.xGateOCX.LogFileSize; }
        //    set { this.xGateOCX.LogFileSize = value; }
        //}
		protected string RemoteAddress
		{
			get { return this.xGateOCX.RemoteAddress; }
			set { this.xGateOCX.RemoteAddress = value; }
		}
		protected int RetryLimit
		{
			get { return this.xGateOCX.RetryLimit; }
			set { this.xGateOCX.RetryLimit = value; }
		}
		protected XGateLogMode Secs1Log
		{
			get { return (XGateLogMode)this.xGateOCX.Secs1Log; }
			set { this.xGateOCX.Secs1Log = (short)value; }
		}
		protected XGateLogMode Secs2Log
		{
			get { return (XGateLogMode)this.xGateOCX.Secs2Log; }
			set { this.xGateOCX.Secs2Log = (short)value; }
		}
		protected string SecsConfigFile
		{
			get { return this.xGateOCX.SecsConfigFile; }
			set { this.xGateOCX.SecsConfigFile = value; }
		}
		protected XGateSecsType SecsType
		{
			get { return (XGateSecsType)this.xGateOCX.SecsType; }
			set { this.xGateOCX.SecsType = (int)value; }
		}
		protected int SerialPortBaudRate
		{
			get { return this.xGateOCX.SerialPortBaudRate; }
			set { this.xGateOCX.SerialPortBaudRate = value; }
		}
		protected int SerialPortNo
		{
			get { return this.xGateOCX.SerialPortNo; }
			set { this.xGateOCX.SerialPortNo = value; }
		}
		protected int T1TimeOut
		{
			get { return this.xGateOCX.T1TimeOut; }
			set { this.xGateOCX.T1TimeOut = value; }
		}
		protected int T2TimeOut
		{
			get { return this.xGateOCX.T2TimeOut; }
			set { this.xGateOCX.T2TimeOut = value; }
		}
		protected int T3TimeOut
		{
			get { return this.xGateOCX.T3TimeOut; }
			set { this.xGateOCX.T3TimeOut = value; }
		}
		protected int T4TimeOut
		{
			get { return this.xGateOCX.T4TimeOut; }
			set { this.xGateOCX.T4TimeOut = value; }
		}
		protected int T5TimeOut
		{
			get { return this.xGateOCX.T5TimeOut; }
			set { this.xGateOCX.T5TimeOut = value; }
		}
		protected int T6TimeOut
		{
			get { return this.xGateOCX.T6TimeOut; }
			set { this.xGateOCX.T6TimeOut = value; }
		}
		protected int T7TimeOut
		{
			get { return this.xGateOCX.T7TimeOut; }
			set { this.xGateOCX.T7TimeOut = value; }
		}
		protected int T8TimeOut
		{
			get { return this.xGateOCX.T8TimeOut; }
			set { this.xGateOCX.T8TimeOut = value; }
		}
        protected bool IgnoreReply
        {
            get { return this.xGateOCX.IgnoreReply; }
            set { this.xGateOCX.IgnoreReply = value; }
        }

		//이벤트
		protected delegate void SelectedEvent(object sender, EventArgs e);
		protected event SelectedEvent OnSelected = null;
		protected delegate void DisconnectedEvent(object sender, EventArgs e);
		protected event DisconnectedEvent OnDisconnected = null;
		protected delegate void RecvSecsMsgEvent(object sender, AxXGateLib._DXProPlusEvents_OnSecsMsgEvent e);
		protected event RecvSecsMsgEvent OnRecvSecsMsg = null;
		protected delegate void SecsTimeOutEvent(object sender, AxXGateLib._DXProPlusEvents_OnSecsTimeOutEvent e);
		protected event SecsTimeOutEvent OnSecsTimeOut = null;


		//생성자 및 이벤트처리
		public XGateForm()
		{
			InitializeComponent();

			this.xGateOCX.ConnectPortNo = 7000;//
			this.xGateOCX.DeviceID = 1;//
			this.xGateOCX.Host = (int)XGateHostType.Equip;
			this.xGateOCX.HsmsMode = (int)XGateHsmsMode.Active;
			this.xGateOCX.LinkTestCycleTime = 6000;//
			this.xGateOCX.ListenPortNo = 7000;//
            this.xGateOCX.LogFileDateLimit = (short)LCData.HistoryPeriodSet.LogHistoryPeriod;//
			this.xGateOCX.LogFilePath = "";
            //this.xGateOCX.LogFileType = 0;
			//this.xGateOCX.LogFileSize = 1000000;//
			this.xGateOCX.RemoteAddress = "127.0.0.1";//
			this.xGateOCX.RetryLimit = 3;//
			this.xGateOCX.Secs1Log = (int)XGateLogMode.Enabled;
			this.xGateOCX.Secs2Log = (int)XGateLogMode.Enabled;
			this.xGateOCX.SecsConfigFile = "";//
			this.xGateOCX.SecsType = (int)XGateSecsType.Hsms;
			this.xGateOCX.SerialPortBaudRate = 9600;//
			this.xGateOCX.SerialPortNo = 5;//
			this.xGateOCX.T1TimeOut = 1000;
			this.xGateOCX.T2TimeOut = 10000;
			this.xGateOCX.T3TimeOut = 45000;
			this.xGateOCX.T4TimeOut = 45000;
			this.xGateOCX.T5TimeOut = 10000;
			this.xGateOCX.T6TimeOut = 5000;
			this.xGateOCX.T7TimeOut = 10000;
			this.xGateOCX.T8TimeOut = 10000;
		}
		private void xGateOCX_OnDisconnected(object sender, EventArgs e)
		{
			if (OnDisconnected != null) OnDisconnected(sender, e);
		}
		private void xGateOCX_OnSecsMsg(object sender, AxXGateLib._DXProPlusEvents_OnSecsMsgEvent e)
		{
			recvCount = 0;
			if (OnRecvSecsMsg != null) OnRecvSecsMsg(sender, e);
		}
		private void xGateOCX_OnSecsTimeOut(object sender, AxXGateLib._DXProPlusEvents_OnSecsTimeOutEvent e)
		{
			if (OnSecsTimeOut != null) OnSecsTimeOut(sender, e);
		}
		private void xGateOCX_OnSelected(object sender, EventArgs e)
		{
			if (OnSelected != null) OnSelected(sender, e);
		}


		//기본함수
		protected int StartXGate()
		{
			return this.xGateOCX.StartXPro();
		}
		protected int StopXGate()
		{
			return this.xGateOCX.StopXPro();
		}
		protected int SendSecsMsg(string strSML)
		{
			try
			{
				return this.xGateOCX.SendSecsMsg(strSML.Replace("　", ""));
			}
			catch
			{
				return -1;
			}
		}
		protected string GetRecvMsg()
		{
			return this.xGateOCX.GetCompleteMsg();
		}
		protected string GetSendMsg()
		{
			return this.sendMsg;
		}
		protected string GetOneMsg(short index)
		{
			return this.xGateOCX.GetOneMsg(index, 0, 0);
		}


		//HSMS생성관련변수
		private short recvCount = 0;
		private string sendMsg = "";
		private string sendTmp = "";
		private List<int> tabs = new List<int>();
		private int sendStream = 0;
		private int sendFunction = 0;


		//기본함수
		protected int IntParse(string str)
		{
			int result = 0;

			result = int.Parse(str);

			return result;
		}
		protected short ShortParse(string str)
		{
			short result = 0;

			result = short.Parse(str);

			return result;
		}
		protected bool BoolParse(string str)
		{
			bool result = false;

			string upper = str.Trim().ToUpper();
			if (upper == "T" || upper == "TRUE" || upper == "1" || upper == "255") result = true;

			return result;
		}
		protected void WriteTab()
		{
			for (int i = 0; i < tabs.Count; i++) sendMsg = sendMsg + "　";
			sendTmp = "";
		}
		protected void CountTab()
		{
			if (tabs.Count > 0) tabs[tabs.Count - 1]--;
		}
		protected void CheckTab()
		{
			while (tabs.Count > 0)
			{
				if (tabs[tabs.Count - 1] == 0) tabs.RemoveAt(tabs.Count - 1);
				else break;
			}
		}


		//HSMS관련함수
		protected void MakeSecsMsg(int stream, int function)
		{
            this.sendStream = stream;
            this.sendFunction = function;

            if (stream == 9 || stream == 10)
            {
                sendMsg = "<S" + stream.ToString() + "F" + function.ToString() + ",E" + "\r\n";
            }
            else
            {
                sendMsg = "<S" + stream.ToString() + "F" + function.ToString() + ",E,R" + "\r\n";
            }
            sendTmp = "";
            tabs.Clear();

            tabs.Add(1);
		}

        protected void MakeSecsMsg(int stream, int function, eHostType eType)
        {
            this.sendStream = stream;
            this.sendFunction = function;

            if (eHostType.Monitor == eType)
            {
                sendMsg = "<S" + stream.ToString() + "F" + function.ToString() + ",E" + "\r\n";
            }
            else
            {
                if (stream == 9 || stream == 10)
                {
                    sendMsg = "<S" + stream.ToString() + "F" + function.ToString() + ",E" + "\r\n";
                }
                else
                {
                    if (0 == (function % 2))
                    {
                        sendMsg = "<S" + stream.ToString() + "F" + function.ToString() + ",E" + "\r\n";
                    }
                    else
                    {
                        sendMsg = "<S" + stream.ToString() + "F" + function.ToString() + ",E,R" + "\r\n";
                    }
                }

            }
            sendTmp = "";
            tabs.Clear();

            tabs.Add(1);
        }
		protected int Stream
		{
			get
			{
				string result = "";
				//try
				//{
					string header = this.xGateOCX.GetOneMsg(0, 0, 0);
					int start = header.IndexOf('S');
					int end = header.IndexOf('F');
					result = header.Substring(start + 1, end - start - 1);
				//}
				//catch { }

				return IntParse(result);
			}
		}
		protected int Function
		{
			get
			{
				string result = "";
				//try
				//{
					string header = this.xGateOCX.GetOneMsg(0, 0, 0);
					int start = header.IndexOf('F');
					result = header.Substring(start + 1);
				//}
				//catch { }

				return IntParse(result);
			}
		}
		protected int List
		{
			set
			{
				WriteTab();
				sendMsg = sendMsg + "<L," + value + "\r\n";
				CountTab();
				if (value == 0) CheckTab();
				else tabs.Add(value);
			}
			get
			{
     			return IntParse(this.xGateOCX.GetOneMsg(++recvCount, 0, 0));
			}
		}
		protected string Ascii
		{
			set
			{
				string str = value;
				if (string.IsNullOrEmpty(str)) str = "";
				WriteTab();
				sendMsg = sendMsg + "<A[" + str.Length.ToString() + "]," + str + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				string result = this.xGateOCX.GetOneMsg(++recvCount, 0, 0);
				if (string.IsNullOrEmpty(result)) result = "";
				return result;
			}
		}
		protected bool Bool
		{
			set
			{
				WriteTab();
				sendMsg = sendMsg + "<BOOL[1]," + value.ToString() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				return BoolParse(this.xGateOCX.GetOneMsg(++recvCount, 0, 0));
			}
		}
		protected List<bool> Bools
		{
			set
			{
				WriteTab();
				for (int i = 0; i < value.Count; i++)
					sendTmp = sendTmp + value[i].ToString() + " ";
				sendMsg = sendMsg + "<BOOL[" + value.Count.ToString() + "]," + sendTmp.Trim() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				List<bool> rusult = new List<bool>();
				//try
				//{
					string[] splits = this.xGateOCX.GetOneMsg(++recvCount, 0, 0).Split(' ');
					foreach (string sp in splits)
					{
						rusult.Add(BoolParse(sp));
					}
				//}
				//catch { }

				return rusult;
			}
		}
		protected short B1
		{
			set
			{
				WriteTab();
				sendMsg = sendMsg + "<BIN," + Convert.ToString(value, 16).ToUpper() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				short result = 0;
				//try
				//{
					result = Convert.ToInt16(this.xGateOCX.GetOneMsg(++recvCount, 0, 0), 16);
				//}
				//catch { }
				return result;
			}
		}
		protected List<short> B1s
		{
			set
			{
				WriteTab();
				for (int i = 0; i < value.Count; i++)
					sendTmp = sendTmp + Convert.ToString(value[i], 16).ToUpper() + " ";
				sendMsg = sendMsg + "<BIN[" + value.Count.ToString() + "]," + sendTmp.Trim() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				List<short> rusult = new List<short>();
				//try
				//{
					string[] splits = this.xGateOCX.GetOneMsg(++recvCount, 0, 0).Split(' ');
					foreach (string sp in splits)
					{
						rusult.Add(Convert.ToInt16(sp, 16));
					}
				//}
				//catch { }

				return rusult;
			}
		}
		protected short U1
		{
			set
			{
				WriteTab();
				sendMsg = sendMsg + "<U1," + value.ToString() + ">\r\n";
				CountTab();

				CheckTab();
			}
			get
			{
				return ShortParse(this.xGateOCX.GetOneMsg(++recvCount, 0, 0));
			}
		}
		protected List<short> U1s
		{
			set
			{
				WriteTab();
				for (int i = 0; i < value.Count; i++)
					sendTmp = sendTmp + value[i].ToString() + " ";
				sendMsg = sendMsg + "<U1[" + value.Count.ToString() + "]," + sendTmp.Trim() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				List<short> rusult = new List<short>();
				//try
				//{
					string[] splits = this.xGateOCX.GetOneMsg(++recvCount, 0, 0).Split(' ');
					foreach (string sp in splits)
					{
						rusult.Add(ShortParse(sp));
					}
				//}
				//catch { }

				return rusult;
			}
		}
		protected int U2
		{
			set
			{
				WriteTab();
				sendMsg = sendMsg + "<U2," + value.ToString() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				return IntParse(this.xGateOCX.GetOneMsg(++recvCount, 0, 0));
			}
		}
		protected List<int> U2s
		{
			set
			{
				WriteTab();
				for (int i = 0; i < value.Count; i++)
					sendTmp = sendTmp + value[i].ToString() + " ";
				sendMsg = sendMsg + "<U2[" + value.Count.ToString() + "]," + sendTmp.Trim() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				List<int> rusult = new List<int>();
				//try
				//{
					string[] splits = this.xGateOCX.GetOneMsg(++recvCount, 0, 0).Split(' ');
					foreach (string sp in splits)
					{
						rusult.Add(IntParse(sp));
					}
				//}
				//catch { }

				return rusult;
			}
		}
		protected int U4
		{
			set
			{
				WriteTab();
				sendMsg = sendMsg + "<U4," + value.ToString() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				return IntParse(this.xGateOCX.GetOneMsg(++recvCount, 0, 0));
			}
		}
		protected List<int> U4s
		{
			set
			{
				WriteTab();
				for (int i = 0; i < value.Count; i++)
					sendTmp = sendTmp + value[i].ToString() + " ";
				sendMsg = sendMsg + "<U4[" + value.Count.ToString() + "]," + sendTmp.Trim() + ">\r\n";
				CountTab();
				CheckTab();
			}
			get
			{
				List<int> rusult = new List<int>();
				//try
				//{
					string[] splits = this.xGateOCX.GetOneMsg(++recvCount, 0, 0).Split(' ');
					foreach (string sp in splits)
					{
						rusult.Add(IntParse(sp));
					}
				//}
				//catch { }

				return rusult;
			}
		}

	}
}