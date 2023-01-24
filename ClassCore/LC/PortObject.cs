using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
    public class PortObject : System.ICloneable
    {
        public int PortNo = 0;
        public eCEID PortEvent = eCEID.NoneEvent;
        public string PortID = "";
        public eEqState EqState = eEqState.NORMAL;
        public ePortState PortState = ePortState.Empty;
        public ePortType PortType = ePortType.InputPort;
        public string PortMode = "OK";
        public eSortType SortType = eSortType.BatchID;
        public eCstDemand CstDemand = eCstDemand.NormalCst;
        public string CstID = ""; 
        public string CstType = "";               
        public string MapStif = "0";
        public string CurStif = "0";
        public eBatchOrder BatchOrder = eBatchOrder.Normal;
        public eByWho ByWho = eByWho.ByEquipment;
        public eReply ReplyMsg = eReply.ACK;

        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}
