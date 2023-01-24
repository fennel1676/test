using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class S5F1AlarmReportSend
	{
		public AlarmData Alarm = new AlarmData();
	}

	public class S5F2AckAlarmReport
	{
		public eTMACK TMACK;
	}

	public class S5F101WaitingResetAlarmsList
	{
		public string ModuleID = "";
	}

	public class S5F102WaitingResetAlarmsListAck
	{
		public string ModuleID = "";
		public eTMACK TMACK;
		public List<AlarmData> Alarms = new List<AlarmData>();
	}

	public class S5F103SelectAlarmForcedResetRequest
	{
		public string ModuleID = "";
		public List<AlarmData> Alarms = new List<AlarmData>();
	}

	public class S5F104SelectAlarmForcedResetAck
	{
		public string ModuleID = "";
		public eTMACK TMACK;
		public List<AlarmData> Alarms = new List<AlarmData>();
	}

	public class S5F105CurrentEqAlarmlistReport
	{
		public string ModuleID = "";
		public List<AlarmData> Alarms = new List<AlarmData>();
	}

}
