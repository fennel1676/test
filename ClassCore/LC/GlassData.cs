using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class GlassData
	{
		public string HPanelID = "";
		public string EPanelID = "";
		public string SlotID = "";
		public string ProcessID = "";
		public string ProductID = "";
		public string StepID = "";
		public string BatchID = "";
		public string ProdType = "";
		public string ProdKind = "";
		public string PPID = "";
		public string FlowID = "";
		public List<int> PanelSize = new List<int>();
		public int Thickness = 0;
		public int CompCount = 0;
		public string DBRRecipe = "";
        public string FlowGroupName = "";

		public List<FlowGroupData> FlowGroups = new List<FlowGroupData>();
		public PanelOtherProp1Data PanelOtherProp1 = new PanelOtherProp1Data();
		public PanelOtherProp2Data PanelOtherProp2 = new PanelOtherProp2Data();
		public PanelPairPropData PanelPairProp = new PanelPairPropData();
		public PanelCellPropData PanelCellProp = new PanelCellPropData();

		public string Refer = "";
		public int ContactPoint1 = 0;
		public int ContactPoint2 = 0;
		public int FromEqNo = 0;
		public int ToEqNo = 0;
        //public int[] PANEL_SIZE = new int[2];
    }

	public class PanelOtherProp1Data
	{
		public ePanelState PanelState = ePanelState.Processing;
		public string ReadingFlag = "";
		public string InsFlag = "";
		public string PanelPosition = "";
		public string Judgement = "OK";
		public string Code = "";
		public List<short> FlowHistorys = new List<short>();
		public List<short> UniqueID = new List<short>();
        //public short[] FLOW_HISTORY = new short[28];
        //public short[] UNIQUEID = new short[4];



	}

	public class PanelOtherProp2Data
	{
        public string Count1 = "";
		public string Count2 = "";
		public string Grade = "";
		public string MultiUse = "";
		public string BitSignal = "";

        public string FlagName = "";
        public bool   FlagValue = false;

	}

	public class PanelPairPropData
	{
		public string PairHPanelID = "";
		public string PairEPanelID = "";
		public string PairProductID = "";
		public string PairGrade = "";
	}

	public class PanelCellPropData
	{
		public string SubPanelID = "";
		public string SubJudgement = "";
		public string SubCode = "";
	}
}
