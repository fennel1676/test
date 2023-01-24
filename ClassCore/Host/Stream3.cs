using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
    public class S3F101CassetteInfo
    {
        public PortObject Port = new PortObject();
        public CassetteObject Cassette = new CassetteObject();

        //public PortData CstInfo = new PortData();
        //public string ModuleID = "";
        //public string ObjType = "";
        //public short HotDevice = 0;

        //public CassetteInfoData CstInfo = new CassetteInfoData();

        //public CassetteInfoData CstInfo = new CassetteInfoData();
        //public PortData CstInfo = new CassetteInfoData();
    }

    public class S3F102CassetteInfoReply
    {
        public string ModuleID = "";
        public eNACK TMACK;
        public eLogType _logType;


        public short NACK_TYPE
        {
            get { return (short)_logType; }
            set
            {
                switch ((eNACK)value)
                {
                    case eNACK.ACK: _logType = eLogType.CST_DOWNLOAD_ACK; break;
                    case eNACK.PortNumFail: _logType = eLogType.CST_DOWNLOAD_NACK108; break;
                    case eNACK.PortStateReservedOrBusy: _logType = eLogType.CST_DOWNLOAD_NACK101; break;
                    case eNACK.PortEmpty: _logType = eLogType.CST_DOWNLOAD_NACK106; break;
                    case eNACK.PortStateFail: _logType = eLogType.CST_DOWNLOAD_NACK109; break;
                    case eNACK.CstIDFail: _logType = eLogType.CST_DOWNLOAD_NACK107; break;
                    case eNACK.CassetteSlotInfoFail: _logType = eLogType.CST_DOWNLOAD_NACK102; break;
                    case eNACK.BatchPlanNotExist: _logType = eLogType.CST_DOWNLOAD_NACK110; break;
                    case eNACK.BatchIDFail: _logType = eLogType.CST_DOWNLOAD_NACK111; break;
                    case eNACK.PairProductIDFail: _logType = eLogType.CST_DOWNLOAD_NACK104; break;
                    case eNACK.FlowIDFail: _logType = eLogType.CST_DOWNLOAD_NACK105; break;
                    case eNACK.FlowGroupFail: _logType = eLogType.CST_DOWNLOAD_NACK112; break;
                }
            }
        }
    }

    public class S3F103ProductionPlanInfo
    {
        public string ModuleID = "";
        public ePLCD PLCD;
        public eLINE LINE;
        public List<BatchObject> BatchDatas = new List<BatchObject>();
    }

    public class S3F104ProductionPlanInfoReply
    {
        public string ModuleID = "";
        public ePLCD PLCD;
        public eNACK TMACK;
    }
}
