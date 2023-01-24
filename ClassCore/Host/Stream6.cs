using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class S6F11PanelProcessEvent
	{
		public short DataID = 0;
		public eCEID CEID;

		public string ModuleID = "";
		public eMCMD MCMD;
		public eEqState EqState;
		public eProcState ProcState;
		public eByWho ByWho;
		public string OperID = "";

		public string FromModuleID = "";
		public string ToModuleID = "";

		public List<GlassData> Glasses = new List<GlassData>();
	}

	public class S6F11EqEvent
	{
		public short DataID = 0;
		public eCEID CEID;

		public string ModuleID = "";
		public eMCMD MCMD;
		public eByWho ByWho;
		public string OperID = "";

		public string ChangeEqStateModuleID = "";
		public string ChangeProcStateModuleID = "";
		public eEqState ChangeEqState;
		public eProcState ChangeProcState;
		public List<ModuleData> Modules = new List<ModuleData>();

		public string LimitTime = "";
		public string RCode = "";

		public List<AlarmData> Alarms = new List<AlarmData>();
	}

	public class S6F11EqParameterEvent
	{
		public short DataID = 0;
		public eCEID CEID;

		public string ModuleID = "";
		public eMCMD MCMD;
		public eEqState EqState;
		public eProcState ProcState;
		public eByWho ByWho;
		public string OperID = "";

		public List<EqOnlineParamData> EqOnlineParams = new List<EqOnlineParamData>();
		public List<EqConstantData> EqConstants = new List<EqConstantData>();
	}

    //public class S6F11EqSpecificControlEvent
    //{
    //    public short DataID = 0;
    //    public eCEID CEID;

    //    public string ModuleID = "";
    //    public eMCMD MCMD;
    //    public eEqState EqState;
    //    public eProcState ProcState;
    //    public eByWho ByWho;
    //    public string OperID = "";

    //    public string ItemName = "";
    //    public string ItemValue = "";
    //}

    //public class S6F11RelatedPanelIDValidationEvent
    //{
    //    public short DataID = 0;
    //    public eCEID CEID;

    //    public string ModuleID = "";
    //    public eMCMD MCMD;
    //    public eEqState EqState;
    //    public eProcState ProcState;
    //    public eByWho ByWho;
    //    public string OperID = "";
		
    //    public string HPanelID = "";
    //    public string BatchID = "";
    //    public string EPanelID = "";
    //    public string PortID = "";
    //    public string CstID = "";
    //    public string SlotID = "";
    //    public List<int> PanelSize = new List<int>();
    //}

    //public class S6F11RelatedEquipmentStandardDataEvent
    //{
    //    public short DataID = 0;
    //    public eCEID CEID;

    //    public string ModuleID = "";
    //    public eMCMD MCMD;
    //    public eEqState EqState;
    //    public eProcState ProcState;
    //    public eByWho ByWho;
    //    public string OperID = "";

    //    public string ProcessID = "";
    //    public string ProductID = "";
    //    public string PPID = "";
    //    public int StandardTact = 0;
    //}

    public class S6F11PortLoaderEvent
    {
        public short DataID;
        public string ModuleID = "";
        public eMCMD MCMD;
        public eEqState EqState;
        public eProcState ProcState;
        public string OperID = "";


        public PortObject Port = new PortObject();
        public CassetteObject Cassette = new CassetteObject();       
    }

    public class S6F11JobProcessEvent
    {
        public short DataID;
        public string ModuleID = "";
        public eMCMD MCMD;
        public eEqState EqState;
        public eProcState ProcState;
        public string OperID = "";

        public PortObject Port = new PortObject();
        public CassetteObject Cassette = new CassetteObject();       
    } 
    public class S6F11BatchProcessEvent
    {
        public short DataID;
        public eCEID CEID;
        public string ModuleID = "";
        public eMCMD MCMD;
        public eEqState EqState;
        public eProcState ProcState;
        public eByWho ByWho;
        public string OperID = "";

        public PortObject Port = new PortObject();
        public BatchObject Batch = new BatchObject();
    }   
    public class S6F11ProdPlanRequstEvent
    {
        public short DataID = 0;
        public eCEID CEID;
        public string ModuleID = "";
        public eMCMD MCMD;
        public eEqState EqState;
        public eProcState ProcState;
        public eByWho ByWho;
        public string OperID = "";

        public string ItemName = "";       
        public string ItemValue = "";
        public string RelatedModuleID = "";
    }
    public class S6F11LoadRejectParamChangeEvent
    {
        public short DataID = 0;
        public eCEID CEID;
        public string ModuleID = "";
        public List<ParameterChangeData> LoadRejectParams = new List<ParameterChangeData>();
    }

	public class S6F12EventReportAck
	{
		public eTMACK TMACK;
	}


    

    
}
