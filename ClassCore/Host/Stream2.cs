using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	
	public class S2F31DateTimeSetRequest
	{
		public string Time = "";
	}

	public class S2F32DateTimeSetAck
	{
		public eTMACK TMACK;
	}


	public class EqModuleData
	{
		public string ModuleID = "";
		public string RCode = "";
		public ePMACK ModuleID_PMACK;
		public ePMACK RCode_PMACK;
	}

    public class S2F41HostCommand
    {
        public eRCMD RCMD;
    }

    public class S2F41ProcessCommand : S2F41HostCommand
    {
        public string IPID = "";
        public string ICID = "";
        public string OPID = "";
        public string OCID = "";
        public string STIF = "";
        public string ORDER = "";   

        public string[] SLOTIDs = new string[0];
    }

     public class S2F42ProcessCommandReply
    {
        public eRCMD RCMD;
        public short HCACK;
        public short TMACK;
        public short PMACK;

        public string IPID = "";
        public short IPID_CPACK;

        public string ICID = "";
        public short ICID_CPACK;

        public string OPID = "";
        public short OPID_CPACK;

        public string OCID = "";
        public short OCID_CPACK;

        public string STIF = "";
        public short STIF_CPACK;

        public string ORDER = "";     

        public string[] SLOTIDs = new string[0];
        public short SLOT_CPACK;

        public eLogType _logType = eLogType.CST_DOWNLOAD_ACK;       
    }

    public class S2F41PortCommand : S2F41HostCommand
    {
        public string[] PTIDs = new string[0];
    }

    public class S2F42PortCommandReply
    {
        public eRCMD RCMD;
        public short TMACK;
        public short PMACK;

        public class PortReply
        {
            public string PortID = "";
            public short CPACK;
        }
        public PortReply[] Ports = new PortReply[0];
    }   


	public class S2F41EqCommand
	{
		public eRCMD RCMD;
        public List<EqModuleData> EqModules = new List<EqModuleData>();
	}

	public class S2F42EqCommandReply 
	{
		public eRCMD RCMD;
		public eTMACK TMACK;
        public List<EqModuleData> EqModules = new List<EqModuleData>();
	}
        

	public class S2F103EqOnlineParameterChange
	{
		public string ModuleID = "";
		public List<EqOnlineParamData> EqOnlineParams = new List<EqOnlineParamData>();
	}

	public class S2F104EqOnlineParameterAck
	{
		public string ModuleID = "";
		public eTMACK TMACK;
		public List<EqOnlineParamData> EqOnlineParams = new List<EqOnlineParamData>();
	}

    public class S2F201ParameterRelatedCommand
    {
        public short PCMD = 0;
        public string ModuleID = "";
        public List<ParameterChangeData> LoadRejectParams = new List<ParameterChangeData>();
    }

    public class S2F202ParameterRelatedReply
    {
        public short PCMD = 0;
        public string ModuleID = "";
        public eTMACK TMACK;     
        public List<ParameterChangeData> LoadRejectParams = new List<ParameterChangeData>();
    }
}
