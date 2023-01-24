using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class EqData
	{
		public eEqType EqType;
		public string IP = "127.0.0.1";
		public int Port = 8000;
		public bool Active = false;
		public string LogPath = "";
		public string AppPath = "";
		public string AppArg = "";
	}

	public enum eEqType
	{
		EQPLC1 = 0,
		EQPLC2 = 1,
		EQPLC3 = 2,
		EQPLC4 = 3,
		EQPLC5 = 4,
	}

	public enum eEqEventType
	{
		Connect,
		Disconnect,
		C1DateTimeSetCmd,
		C2EquipmentCmd,
		C3FlowRecipeCmd,
		C4FlowGroupCmd,
		C5ManualDispatchCmd,
		C6SamplingDefineCmd,
		C7EqOnlineParameterCmd,
		C8JudgementFlowCmd,
		C9UnitControlCmd,
		C10EqConstantCmd,
		C11MessageCmd,
		C12AlarmResetCmd,
        C14ProcessPortCmd,
        C15CassetteinfoCmd,
        C16PanelInfoCmd,
        C17WIPQTYInfoCmd,
        C21ProcessPortCmdTest,
		E1FlowRecipeEvent,
		E2FlowGroupEvent,
		E3DBRRecipeEvent,
		E4SamplingDefineEvent,
		E5ManualDispatchEvent,
		E6JudgementFlowEvent,
		E7EqOnlineParameterEvent,
		E8EqConstantEvent,
		E9EquipmentPMEvent,
		E10InputModeEvent,
		E11ProprietyQuantityEvent,

        E12PortEvent,
        E12JobStartEvent,
        E12JobCancelEvent,
        E12JobAbortEvent,
        E12JobEndEvent,
        E12LoadRequestEvent,
        E12LoadRejectEvent,
        E12PreLoadEvent,
        E12ClampOnEvent,
        E12LoadCompleteEvent,
        E12UnLoadRequestEvent,
        E12UnLoadCompleteEvent,
        E12BatchPauseEvent,
        E12BatchResumeEvent,

        E13PanelIDReqEvent,
        E14WIPQTYEvent,
        E15BatchPauseEvent,
        E16BatchResumeEvent,
        E17InitialSynchEvent,
        E18DuplicationEvent,
        E19OnlineStateEvent,
        E20PLCSignalEvent,
		R1TransferGlassDataReport,
		R2SetAlarmReport,
		R3ResetAlarmReport,
		R4UnitStateReport,
		R5InitializeUnitStateReport,
		R6GlassControlReport,
		R7SignalBitsReport,
		R8InitializeAlarmReport,
		R9TactTimeReport,

        BatchStartEvent,
        BatchEndEvent,
	}

	public class EqEventArgs : EventArgs
	{
		public eEqEventType EventType;
		public eEqType EqType;
		public object XmlMsg;

		public EqEventArgs(eEqEventType eventType, eEqType eqType, object xmlMsg)
		{
			this.EventType = eventType;
			this.EqType = eqType;
			this.XmlMsg = xmlMsg;
		}
	}

}
