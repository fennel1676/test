using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class R1TransferGlassDataReport
	{
		public TargetData Target = new TargetData();

		public eCEID EventID;
		public GlassData Glass = new GlassData();
	}

	public class R2SetAlarmReport
	{
		public TargetData Target = new TargetData();

		public eAlarmSection AlarmSection;
		public int AlarmID = 0;
		public string AlarmText = "";
	}

	public class R3ResetAlarmReport
	{
		public TargetData Target = new TargetData();

		public eAlarmSection AlarmSection;
		public int AlarmID = 0;
		public string AlarmText = "";
	}

	public class R4UnitStateReport
	{
		public TargetData Target = new TargetData();

		public string PMCode = "";
		public string PauseCode = "";
		public eEqState EqState;
		public eProcState ProcState;
		public eByWho EqByWho;
		public eByWho ProcByWho;
	}

	public class R5InitializeUnitStateReport
	{
		public TargetData Target = new TargetData();

		public List<R4UnitStateReport> Units = new List<R4UnitStateReport>();
	}

	public class R6GlassControlReport
	{
		public TargetData Target = new TargetData();

		public eCEID EventID;
		public string HPanelID = "";
		public string BrokenCode = "";

		public int Count = 0;
	}

	public class R7SignalBitsReport
	{
		public TargetData Target = new TargetData();

		public eCEID Signal;
		public string Refuse = "";
	}

	public class R8InitializeAlarmReport
	{
		public TargetData Target = new TargetData();

		public List<R2SetAlarmReport> Alarms = new List<R2SetAlarmReport>();
	}

	public class R9TactTimeReport
	{
		public TargetData Target = new TargetData();

		public string PPID = "";
		public int SetTact = 0;
		public int CurrentTact = 0;
	}
}

