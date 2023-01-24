using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public enum eAlarmSet
	{
		Reset = 0,
		Set = 1,
	}

	public enum eAlarmType
	{
		Warning = 0,
		Fault = 1,
	}

	public enum eAlarmReason
	{
		OtherEQ = 1,
		Parameter = 2,
		Panel = 4,
		Material = 8,
		EQ = 16,
		Safety = 32,
	}

	public enum eAlarmSection
	{
		MASTER,
		PIO,
		UNIT,
	}

	public class AlarmData
	{
		public int ID = 0;
		public string Text = "";
		public string Time = "";
		public string ModuleID = "";

		public eAlarmSection Section;
		public string EqID = "";
		public string UnitID = "";

		public eAlarmReason AlarmReason;
		public eAlarmSet AlarmSet;
		public eAlarmType AlarmType;

		public ePMACK PMACK;

		public short Code
		{
			get
			{
				short code = (short)AlarmReason;
				if (AlarmSet == eAlarmSet.Set) code |= 128;
				if (AlarmType == eAlarmType.Fault) code |= 64;
				return code;
			}
			set
			{
				if ((value & 128) > 0) AlarmSet = eAlarmSet.Set;
				else AlarmSet = eAlarmSet.Reset;

				if ((value & 64) > 0) AlarmType = eAlarmType.Fault;
				else AlarmType = eAlarmType.Warning;

				if ((value & (short)eAlarmReason.Safety) > 0) AlarmReason = eAlarmReason.Safety;
				else if ((value & (short)eAlarmReason.Parameter) > 0) AlarmReason = eAlarmReason.Parameter;
				else if ((value & (short)eAlarmReason.EQ) > 0) AlarmReason = eAlarmReason.EQ;
				else if ((value & (short)eAlarmReason.Material) > 0) AlarmReason = eAlarmReason.Material;
				else if ((value & (short)eAlarmReason.Panel) > 0) AlarmReason = eAlarmReason.Panel;
				else AlarmReason = eAlarmReason.OtherEQ;
			}
		}

	}
}
