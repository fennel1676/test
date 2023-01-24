using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class ModuleData
	{
		public string ID = "";
		public string ParentID = "";
		public ModuleData Parent = null;
		public List<ModuleData> Childs = null;
		public int Layer = 0;
		public string EqID = "";
		public string UnitID = "";

		public eEqState EqState = eEqState.NORMAL;
		public eProcState ProcState = eProcState.IDLE;

		public int Row = 0;
		public int Column = 0;

		public int KeepTime = 0;

		public string FromModuleID = "";
		public string ToModuleID = "";

		public GlassData Glass = null;

	}

}
