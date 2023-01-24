using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
    public class BatchObject
    {
        public int ORDER_NO;
        public short PRIORITY;
        public string PROD_KIND = "";
        public string PROD_TYPE = "";
        public string PROCESSID = "";
        public string PRODUCTID = "";
        public string STEPID = "";
        public string PPID = "";
        public string FLOWID = "";
        public string BATCHID = "";
        public eBatchtState BATCH_STATE;
        public int BATCH_SIZE;
        public string P_MAKER = "";
        public int P_THICKNESS;
        public string F_PANELID = "";
        public string C_PANELID = "";
        public string INPUT_LINE = "";
        public short VALID_FLAG;
        public int C_QTY;
        public int O_QTY;
        public int R_QTY;
        public int N_QTY;
        public List<FlowGroupData> FlowGroups = new List<FlowGroupData>();
        public List<string> GlassIDLists = new List<string>();
        public string END_PANELID = "";
        public string StartTime = "";
    }
}
