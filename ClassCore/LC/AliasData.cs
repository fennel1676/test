using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class AliasData
	{
		public eAliasType Type;
		public int WorkID = 0;
		public int WorkerID = 0;
		public string FlowID = "";
		public string Alias = "";
	}

	public enum eAliasType
	{
		WorkAlias = 0,
		WorkerAlias = 1,
		FlowAlias = 2,
	}
}
