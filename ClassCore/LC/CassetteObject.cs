using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
    public class CassetteObject
    {
        public short HotDevice = 0;
        //public eEqState EqState = eEqState.NORMAL;
        //public string PortID = "";
        //public ePortState PortState;
        //public ePortType PortType = ePortType.InputPort;
        //public string PortMode = "OK";
        //public eCstDemand CstDemand = eCstDemand.NormalCst;

        public string CstID = "";
        public string CstType = "";
        public string MapStif = "";
        public string CurStif = "";
        public string AvailStif = "";
        public eBatchOrder BatchOrder = eBatchOrder.Normal;

        public List<GlassData> GlassDatas = new List<GlassData>();
    }
}
