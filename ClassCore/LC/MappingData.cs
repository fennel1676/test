using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class MappingData
	{
		public eMappingType Type;
		public string WorkID = "";
		public int WorkerID = 0;
		public string FlowID = "";
		public int ECID = 0;
		public string Text = "";
		public string Text2 = "";
	}

	public enum eMappingType
	{
		WorkID = 0,
		WorkerID = 1,
		FlowID = 2,
		ECID = 3,
	}
}
