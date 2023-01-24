﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class LogData
	{
        public short line = 0;
        public short log_type = 0;
		public string Time = "";
		public string Text = "";       
    }

    public enum eLogType
    {
        NONE = 0,
        PC_BOOT_START = 1000,
        PC_BOOT_END =   1001,
        HOST_CONNECT = 1100,
        HOST_DISCONNECT = 1101,
        PLC_CONNECT = 1200,
        PLC_DISCONNECT = 1201,

        HOST_START_CMD = 2000,
        HOST_CANCEL_CMD = 2001,
        HOST_ABORT_CMD = 2002,
        HOST_RELOAD_CMD = 2003,

        OPER_START_CMD= 3000,
        OPER_CANCEL_CMD = 3001,
        OPER_ABORT_CMD = 3002,
        OPER_RELOAD_CMD = 3003,

        START_CMD_ACK = 4000,
        START_CMD_NACK201 = 4001,
        START_CMD_NACK203 = 4002,
        START_CMD_NACK205 = 4003,
        START_CMD_NACK207 = 4004,
        START_CMD_NACK208 = 4005,
        START_CMD_NACK209 = 4006,
        START_CMD_NACK210 = 4007,
        START_CMD_NACK211 = 4008,

        CANCEL_CMD_ACK = 4100,
        CANCEL_CMD_NACK201 = 4101,
        CANCEL_CMD_NACK207 = 4102,
        CANCEL_CMD_NACK212 = 4103,

        ABORT_CMD_ACK = 4200,
        ABORT_CMD_NACK201 = 4201,
        ABORT_CMD_NACK207 = 4202,
        ABORT_CMD_NACK212 = 4203,

        RELOAD_CMD_ACK = 4300,
        RELOAD_CMD_NACK14 = 4301,
        RELOAD_CMD_NACK3 = 4302,

        BATCH_DOWNLOAD_ACK = 4400,
        BATCH_DELETE_ACK  = 4401,
        BATCH_DOWNLOAD_NACK1 = 4402,
        BATCH_DOWNLOAD_NACK2 = 4403,
        BATCH_DOWNLOAD_NACK3 = 4404,
        BATCH_DOWNLOAD_NACK4 = 4405,
        BATCH_DOWNLOAD_NACK7 = 4406,
        BATCH_DOWNLOAD_NACK8 = 4407,
        BATCH_DOWNLOAD_NACK9 = 4408,
        BATCH_DOWNLOAD_NACK10 = 4409,
        BATCH_DOWNLOAD_NACK11 = 4410,

        CST_DOWNLOAD_ACK = 4500,
        CST_DOWNLOAD_NACK101 = 4501, //portstate
        CST_DOWNLOAD_NACK102 = 4502, //cassette slot fail
        CST_DOWNLOAD_NACK104 = 4503, //glass type
        CST_DOWNLOAD_NACK105 = 4504, //flowid
        CST_DOWNLOAD_NACK106 = 4505, //port empty
        CST_DOWNLOAD_NACK107 = 4506, //cstid
        CST_DOWNLOAD_NACK108 = 4507, //portid
        CST_DOWNLOAD_NACK109 = 4508, //portstate
        CST_DOWNLOAD_NACK111 = 4509, //batchid
        CST_DOWNLOAD_NACK112 = 4510, //flowgroup
        CST_DOWNLOAD_NACK110 = 4511, //plan not exist

        PRELOAD_EVENT_ACK = 5000,
        CLAMPON_EVENT_ACK = 5001,
        LCOMPLETE_EVENT_ACK = 5002,
        ULCOMPLETE_EVENT_ACK = 5003,
        LREQUEST_EVENT_ACK = 5004,
        ULREQUEST_EVENT_ACK = 5005,
        START_EVENT_ACK = 5006,
        CANCEL_EVENT_ACK = 5007,
        ABORT_EVENT_ACK = 5008,
        END_EVENT_ACK = 5009,
        RESUME_EVENT_ACK = 5010,
        PAUSE_EVENT_ACK = 5011,
        INIT_EVENT_ACK = 5012,
        PROCESSCMD_EVENT_ACK = 5013,
        PANELIDINFO_EVENT_ACK = 5014,
        EQUIPMENTCMD_EVENT_ACK = 5015,
        DATETIMESETCMD_EVENT_ACK = 5016,
        TERMINALMSGCMD_EVENT_ACK = 5017,
        OPCALLMSGCMD_EVENT_ACK = 5018,

        START_EVENT_NACK = 5100,
        CANCEL_EVENT_NACK = 5101,
        ABORT_EVENT_NACK = 5102,
        END_EVENT_NACK = 5103,
        RELOAD_EVENT_NACK = 5104,
        RESUME_EVENT_NACK = 5105,
        PAUSE_EVENT_NACK = 5106,

        PC_START_NORMAL = 6000,
        PC_CANCEL_NORMAL = 6001,
        PC_ABORT_NORMAL = 6002,
        PC_RELOAD_NORMAL = 6003,
        PC_RESUME_NORMAL = 6004,
        PC_PAUSE_NORMAL = 6005,

        PC_CANCEL_ABNORMAL1 = 6100,
        PC_CANCEL_ABNORMAL2 = 6101,
        PC_CANCEL_ABNORMAL3 = 6102,
        PC_END_ABNORMAL1 = 6103,
        PC_END_ABNORMAL2 = 6104,
        PC_RELOAD_ABNORMAL1 = 6105,
        PC_RESUME_ABNORMAL1 = 6106,
        PC_PAUSE_ABNORMAL1 = 6107,

        BATCH_START_EVENT = 7000,
        GLASS_START_EVENT = 7001,
        BATCH_END_EVENT = 7002,
        BATCH_REQ_OPER_EVENT = 7003,
        BATCH_REQ_TIMER_EVENT = 7004,
        BATCH_REQ_AUTO_EVENT = 7005,
        GLASSID_DUPLICATION_EVENT = 7006,
        GLASSID_EMPTY_EVENT = 7007,
        BATCH_END_OPER_EVENT = 7008,
    }  
   
}
