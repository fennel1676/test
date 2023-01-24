using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class S1F1AreYouThere
	{
		public string ModuleID = "";
	}

	public class S1F2OnLineData
	{
		public string ModuleID = "";
		public eMCMD OnlineMode;
	}

	public class S1F5FormattedStateRequest
	{
		public string ModuleID = "";
		public eSFCD SFCD;
	}

	public class S1F6EqOnlineParameter
	{
		public string ModuleID = "";
		public eSFCD SFCD;
		public eTMACK TMACK;

		public List<EqOnlineParamData> EqOnlineParams = new List<EqOnlineParamData>();
	}

    public class S1F6PortState
    {
        public string ModuleID = "";
        public eSFCD SFCD;
        public eTMACK TMACK;

        public List<PortObject> PortObjects = new List<PortObject>();
    }


	public class S1F6GlassTracking
	{
		public eSFCD SFCD;
		public eTMACK TMACK;

		public bool IsUnit = false;
        public bool IsPort = false;
		public List<ModuleData> Modules = new List<ModuleData>();
	}

	public class S1F6ModuleStates
	{
		public string ModuleID = "";
		public eSFCD SFCD;
		public eTMACK TMACK;

		public List<ModuleData> Modules = new List<ModuleData>();
	}

    //public class S1F6EqStandardTactRequest
    //{
    //    public string ModuleID = "";
    //    public eSFCD SFCD;
    //    public eTMACK TMACK;

    //    public eEqState EqState;
    //    public eProcState ProcState;
    //    public eMCMD MCMD;
    //    public int StandardTact = 0;
    //}

	public class S1F6FlowControlTableRequest
	{
		public string ModuleID = "";
		public eSFCD SFCD;
		public eTMACK TMACK;

		public eEqState EqState;
		public eProcState ProcState;
		public eMCMD MCMD;
		public List<FlowControlTable> FlowControls = new List<FlowControlTable>();
	}
	public class FlowControlTable
	{
		public List<bool> WorkerIDs = new List<bool>();
		public string EqpType = "";
		public List<WorkGroupTable> WorkGroupTables = new List<WorkGroupTable>();
	}
	public class WorkGroupTable
	{
		public List<bool> WorkerGroup = new List<bool>();
		public string Worker1 = "";
		public string Worker2 = "";
		public string Worker3 = "";
		public string Worker4 = "";
		public string Worker5 = "";
		public string Worker6 = "";
		public string Worker7 = "";
		public string Worker8 = "";
	}
    public class S1F6LoadRejectParameter
    {
        public string ModuleID = "";
        public eSFCD SFCD;
        public eTMACK TMACK;

        public List<ParameterChangeData> LoadRejectParams = new List<ParameterChangeData>();
    }


	public class S1F17RequestOnLine
	{
		public string ModuleID = "";
		public eMCMD OnlineMode;
	}

	public class S1F18OnLineAck
	{
		public string ModuleID = "";
		public eTMACK TMACK;
	}

}
