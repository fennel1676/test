using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public enum eOperation
	{
		END = 0,
		AND = 1,
		OR = 2,
		BOTH = 3,
	}

	public enum eOptional
	{
		OFF = 0,
		ON = 1,
	}

	public enum eFlowRecipeMode
	{
		Create = 1,
		Delete = 2,
		Modify = 3,
	}

	public class FlowGroupData
	{
		public string WorkID = "0000";
		public string Reserve = "00";
		public string WorkGroup = "00";
		public string Worker = "00000000";
        public string GroupString = "";

        public string WorkIDName = "";
        public string WorkerName = "";

        public List<bool> FlowList = new List<bool>();

        public string Binary
		{
			get
			{
				return WorkID + Reserve + WorkGroup + Worker;
			}
			set
			{
				string bin = value.PadLeft(16, '0');
				this.WorkID = bin.Substring(0, 4);
				this.Reserve = bin.Substring(4, 2);
				this.WorkGroup = bin.Substring(6, 2);
				this.Worker = bin.Substring(8, 8);
			}
		}
		public int Decimal
		{
			get
			{
				return Convert.ToInt32(Binary, 2);
			}
			set
			{
				this.Binary = Convert.ToString(value, 2).PadLeft(16, '0');
			}
		}
		public List<bool> BoolList
		{
			get
			{
                List<bool> list = new List<bool>();
                char[] chars = this.Binary.ToCharArray();
                Array.Reverse(chars);

                foreach (char ch in chars)
                {
                    if (ch == '1') list.Add(true);
                    else list.Add(false);
                }

                return list;
			}

		}

        public string StringList
        {
            get
            {
                string temp = "";
                foreach (bool Lists in this.FlowList)
                {
                    temp += (Lists ? "1" : "0");
                }
                return LCData.ReverseString(temp);
            }

        }
       
		public List<bool> BoolListWorkID
		{
			get
			{
				List<bool> list = new List<bool>();
				char[] chars = this.WorkID.ToCharArray();
				Array.Reverse(chars);

				foreach (char ch in chars)
				{
					if (ch == '1') list.Add(true);
					else list.Add(false);
				}

				return list;
			}
		}
		public List<bool> BoolListWorkGroup
		{
			get
			{
				List<bool> list = new List<bool>();
				char[] chars = this.WorkGroup.ToCharArray();
				Array.Reverse(chars);

				foreach (char ch in chars)
				{
					if (ch == '1') list.Add(true);
					else list.Add(false);
				}

				return list;
			}
		}


        public string WORKID_NAME
        {
            get
            {
                switch(Convert.ToInt32(this.WorkID, 2))
                {
                    case 1: WorkIDName = "초기";break;
                    case 2: WorkIDName = "ITO"; break;
                }
                return WorkIDName;
            }
        }

        public string WORKER_NAME
        {
            get
            {
                switch (Convert.ToInt32(this.Worker, 2))
                {
                    case 1: WorkerName = "1"; break;
                    case 2: WorkerName = "2"; break;
                    case 3: WorkerName = "1,2"; break;
                }
                return WorkerName;
            }
        }

		//15~12:WorkID   11~10:Reserve   9~8:WorkGroup   7~0:Worker
	}

	public class FlowBodyData
	{
		public string WorkID = "0000";
		public string Reserve = "000000000";
		public eOptional Optional;
		public eOperation Operation;

		public string Binary
		{
			get
			{
				string opt = Convert.ToString((int)Optional, 2).PadLeft(1, '0');
				string oper = Convert.ToString((int)Operation, 2).PadLeft(2, '0');
				return WorkID + Reserve + opt + oper;
			}
			set
			{
				string bin = value.PadLeft(16, '0');
				this.WorkID = bin.Substring(0, 4);
				this.Reserve = bin.Substring(4, 9);
				this.Optional = (eOptional)Convert.ToInt32(bin.Substring(13, 1), 2);
				this.Operation = (eOperation)Convert.ToInt32(bin.Substring(14, 2), 2);
			}
		}
		public int Decimal
		{
			get
			{
				return Convert.ToInt32(Binary, 2);
			}
			set
			{
				this.Binary = Convert.ToString(value, 2).PadLeft(16, '0');
			}
		}

		//15~12:WorkID   11~3:Reserve   2:Opt   1:Or   0:And
	}

	public class FlowRecipeData
	{
		public int FlowNo = 0;
		public string FlowID = "";
		public string Revision = "";
		public string UpdateTime = "";

		public List<FlowBodyData> FlowDatas = new List<FlowBodyData>();
	}

    //public class FlowGroupSet
    //{
    //    public bool[] flowgroup_1 = new bool[16];
    //    public bool[] flowgroup_2 = new bool[16];
    //    public bool[] flowgroup_3 = new bool[16];
    //    public bool[] flowgroup_4 = new bool[16];
    //    public bool[] flowgroup_5 = new bool[16];
    //    public bool[] flowgroup_6 = new bool[16];
    //    public bool[] flowgroup_7 = new bool[16];
    //    public bool[] flowgroup_8 = new bool[16];
    //    public bool[] flowgroup_9 = new bool[16];
    //    public bool[] flowgroup_10 = new bool[16];

    //}
}
