using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class EqOnlineParamData
	{
		public int EOID = 0;
		public List<EqOnlineParamMode> Modes = new List<EqOnlineParamMode>();
	}

	public class EqOnlineParamMode
	{
		public string EOMD = "";
		public short EOV = 0;
		public ePMACK PMACK;
		public bool IsChange = false;

		public EqOnlineParamMode()
		{
			this.EOMD = "";
			this.EOV = 0;
		}
		public EqOnlineParamMode(string eomd, short eov)
		{
			this.EOMD = eomd;
			this.EOV = eov;
		}
		public EqOnlineParamMode(string eomd, short eov, bool change)
		{
			this.EOMD = eomd;
			this.EOV = eov;
			this.IsChange = change;
		}
	}
}
