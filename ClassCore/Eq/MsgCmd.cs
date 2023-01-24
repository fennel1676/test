using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class C1DateTimeSetCmd
	{
		public TargetData Target = new TargetData();

		public string DataTime = "";
	}

	public class C2EquipmentCmd
	{
		public TargetData Target = new TargetData();

		public eRCMD Command;
		public string Code = "";
		public eByWho ByWho;
	}    

	public class C3FlowRecipeCmd
	{
		public TargetData Target = new TargetData();

		public int Command = 0;
		public FlowRecipeData FlowRecipe = new FlowRecipeData();
	}

	public class C4FlowGroupCmd
	{
		public TargetData Target = new TargetData();

		public int Command = 0;
		public List<FlowGroupData> FlowGroups = new List<FlowGroupData>();
	}

	public class C7EqOnlineParameterCmd
	{
		public TargetData Target = new TargetData();

		public int Command = 0;
		public short Judgement = 0;
		public short No = 0;
		public short VCR = 0;
		public short Wait = 0;
		public short Mode = 0;
		public eByWho ByWho;
	}

	public class C10EqConstantCmd
	{
		public TargetData Target = new TargetData();

		public int Command = 0;
        public eByWho ByWho;
		public List<EqConstantData> EqConstants = new List<EqConstantData>();
	}

	public class C11MessageCmd
	{
		public TargetData Target = new TargetData();

		public short Num = 0;
		public string Terminal = "";
		public string OpCall = "";
	}
    public class C14ProcessPortCmd
    {
        public TargetData Target = new TargetData();

        public int PortNo = 0;
        public eRCMD Command;

        public string CstID = "";
        public string MapStif = "";
        public string StartStif = "";
        public eByWho ByWho;
    }
    public class C21ProcessPortCmdTest
    {
        public TargetData Target = new TargetData();

        public int PortNo = 0;
        public int Command = 0;

        public string CstID = "";
        public string MapStif = "";
        public string StartStif = "";
        public int ByWho = 0;
    }
    public class C15CassetteInfoCmd
    {
        public TargetData Target = new TargetData();

        public string PortNo = "";
        public string ProcessID = "";
        public string ProductID = "";
        public string StepID = "";
        public string BatchID = "";
        public string ProdType = "";
        public string ProdKind = "";
        public string PPID = "";
        public string FlowID = "";
        public string PanelSize = "";
        public int    Thickness = 0;
        public int    CompCount = 0;
        public string PanelState = "";
        public string ReadingFlg = "";
        public string InsFlg = "";
        public string PanelPosition = "";
        public string Judgement = "";
        public string Code = "";
        public string FlowHistory = "";
        public string Count1 = "";
        public string Count2 = "";
        public string Grade = "";
        public string MultiUse = "";
        public string GlassDataSignal = "";
        public string PairHPanelID = "";
        public string PairEPanelID = "";
        public string PairProductiD = "";
        public string PairGrade = "";
        public string FlowGroup = "";
        public string DBRRecipe = "";
        public string ReferData = "";

    }
    public class C16PanelInfoCmd
    {
        public TargetData Target = new TargetData();

        public string PortNo = "";
        public string HPanelID = "";
        public string UniqueID = "";
    }

    public class C17WIPQTYInfoCmd
    {
        public TargetData Target = new TargetData();

        public string WIPQTY1 = "";
        public string WIPQTY2 = "";
    }

    
}
