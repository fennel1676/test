using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
    public class ParameterChangeData
    {
        public int PCMD = 0;
        public List<ParameterChangeMode> Modes = new List<ParameterChangeMode>();
    }
  
    public class ParameterChangeMode
	{
		public string PORTID = "";
		public short RejectMode = 0;
		public ePMACK PMACK;
		public bool IsChange = false;

		public ParameterChangeMode()
		{
            this.PORTID = "";
            this.RejectMode = 1;
		}
		public ParameterChangeMode(string PortID, short Reject)
		{
            this.PORTID = PortID;
            this.RejectMode = Reject;
		}
        public ParameterChangeMode(string PortID, short Reject, bool change)
		{
            this.PORTID = PortID;
            this.RejectMode = Reject;
			this.IsChange = change;
		}
	}
}
