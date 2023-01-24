using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class E1FlowRecipeEvent
	{
		public TargetData Target = new TargetData();

		public int EventID = 0;
		public FlowRecipeData FlowRecipe = new FlowRecipeData();
	}

	public class E2FlowGroupEvent
	{
		public TargetData Target = new TargetData();

		public int EventID = 0;
		public List<FlowGroupData> FlowGroups = new List<FlowGroupData>();
	}

    //public class E8EqConstantEvent
    //{
    //    public TargetData Target = new TargetData();

    //    public List<EqConstantData> EqConstants = new List<EqConstantData>();
    //}

    //public class E10InputModeEvent
    //{
    //    public TargetData Target = new TargetData();

    //    public string InputMode = "";
    //}

    //public class E11ProprietyQuantityEvent
    //{
    //    public TargetData Target = new TargetData();

    //    public List<short> ProprietyQty = new List<short>();
    //}

    public class E12PortEvent
    {
        public TargetData Target = new TargetData();
        public PortObject Port = new PortObject();      
    }

    public class E12JobStartEvent : E12PortEvent 
    {
        
    }
    public class E12JobCancelEvent : E12PortEvent
    {

    }
    public class E12JobAbortEvent : E12PortEvent
    {

    }
    public class E12JobEndEvent : E12PortEvent
    {

    }
    public class E12LoadRequestEvent : E12PortEvent
    {
       
    }
    public class E12PreloadEvent : E12PortEvent
    {

    }
    public class E12ClampOnEvent : E12PortEvent
    {

    }
    public class E12LoadCompleteEvent : E12PortEvent
    {

    }
    public class E12UnLoadRequestEvent : E12PortEvent
    {

    }
    public class E12UnLoadCompleteEvent : E12PortEvent
    {

    }
    public class E12LoadRejectEvent : E12PortEvent
    {

    } 
    public class E12BatchPauseEvent : E12PortEvent
    {

    }
    public class E12BatchResumeEvent : E12PortEvent
    {

    } 


    public class E13PanelIDReqEvent
    {
        public TargetData Target = new TargetData();
        public short PortNo;
    }
    public class E14WIPQTYEvent
    {
        public TargetData Target = new TargetData();

        public int WIPQTY1P1 = 0;
        public int WIPQTY1P2 = 0;
        public int WIPQTY2P1 = 0;
        public int WIPQTY2P2 = 0;        
    }

    public class E15BatchPauseEvent
    {
        public TargetData Target = new TargetData();

        public short PortNo;
    }

    public class E16BatchResumeEvent
    {
        public TargetData Target = new TargetData();

        public short PortNo;
    }

    public class E17InitialSynchEvent
    {
        public TargetData Target = new TargetData();

        public short PortNo;
    }

    public class E18DuplicationEvent
    {
        public TargetData Target = new TargetData();

        public short PortNo;
        public string HPanelID = "";
        public string UniqueID = "";
        public short ResultHPanelID = 0;
        public short ResultUniqueID = 0;
        public short ResultBatchID = 0;        
    }
    public class E19OnlineStateEvent
    {
        public TargetData Target = new TargetData();

        public short ConnectionState;
    }
    public class E20PLCSignalEvent
    {
        public TargetData Target = new TargetData();

        public short PortNo;
        public short SigID;
        public short Result;
    }

    //public class BatchStartEvent
    //{
    //    public short line;
    //}

    //public class BatchEndEvent
    //{
    //    public short line;
    //}
}
