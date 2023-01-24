using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public class HostData
	{
		public eHostType HostType;
		public string IP = "127.0.0.1";
		public int Port = 7000;
		public bool Active = false;
		public int T1 = 1000;
		public int T2 = 10000;
		public int T3 = 45000;
		public int T4 = 10000;
		public int T5 = 10000;
		public int T6 = 45000;
		public int T7 = 45000;
		public int T8 = 120000;
		public int LinkInterval = 30000;
		public string LogPath = "";
	}

	public enum eHostType
	{
		Host = 0,
		Monitor = 1,
        PMS = 2,

	}

	public enum eHostEventType
	{
		Connect,
		Disconnect,

		TimeOut,

		S1F1AreYouThere,
		S1F2OnLineData,
		S1F3SelectedEqStateRequest,
		S1F4SelectedEqStateData,
		S1F5FormattedStateRequest,

		S1F6EqOnlineParameter,			//SFCD = 1
		S1F6PortStates,					//SFCD = 2
		S1F6GlassTracking,				//SFCD = 3
		S1F6ModuleStates,				//SFCD = 4 
		S1F6CassetteTracking,			//SFCD = 5 
		S1F6IndexParameterReply,		//SFCD = 6 
		S1F6EqStandardTactRequest,		//SFCD = 7 
		S1F6EqCurrentInterlockRequest,	//SFCD = 8 
		S1F6FlowControlTableRequest,	//SFCD = 9 
		S1F6GlassStockInfo,				//SFCD = 16
		S1F6ProductionPlanInfo,			//SFCD = 22
		S1F6MaterialBatchInfo,			//SFCD = 23

		S1F17RequestOnLine,
		S1F18OnLineAck,

		S2F15NewEqConstantSend,
		S2F16NewEqConstantAck,
		S2F23TraceInitializeSend,
		S2F24TraceInitializeAck,
		S2F29EqConstantNamelistRequest,
		S2F30EqConstantNamelist,
		S2F31DateTimeSetRequest,
		S2F32DateTimeSetAck,
		S2F203GetAttrDataDownload,
		S2F204GetAttrDataDownloadReply,

        S2F41HostCommand,
		S2F41ProcessCommand,
		S2F41PortCommand,
		S2F41EqCommand,
		S2F41SortCommand,
		S2F41MaterialCommand,
		S2F41JobChangeCommand,
		S2F41JudgementCommand,
		S2F41PairProcessCommand,

		S2F42ProcessCommandReply,
		S2F42PortCommandReply,
		S2F42EqCommandReply,
		S2F42SortCommandReply,
		S2F42MaterialCommandReply,
		S2F42JobChangeCommandReply,
		S2F42JudgementCommandReply,
		S2F42PairProcessCommandReply,

		S2F103EqOnlineParameterChange,
		S2F104EqOnlineParameterAck,
		S2F201ParameterRelatedCommand,
		S2F202ParameterRelatedReply,

		S3F1MaterialStateRequest,
		S3F2MaterialStateData,
		S3F101CassetteInfo,
		S3F102CassetteInforeply,
		S3F103ProductionPlanInfoSend,
		S3F104ProductionPlanInfoSendReply,
		S3F105MaterialInfoSend,
		S3F106MaterialInfoSendReply,
		S3F107FPOInfoSend,
		S3F108FPOInfoSendReply,
		S3F109GlassSizeInfo,
		S3F110GlassSizeInfoReply,
		S3F111MaterialCodeInfoSend,
		S3F112MaterialInfoSendReply,
		S3F203GetAttrDataDownLoad,
		S3F204GetAttrDataDownloadReply,

		S5F1AlarmReportSend,
		S5F2AckAlarmReport,
		S5F101WaitingResetAlarmsList,
		S5F102WaitingResetAlarmsListAck,
		S5F103SelectAlarmForcedResetRequest,
		S5F104SelectAlarmForcedResetAck,
		S5F105CurrentEqAlarmlistReport,

		S6F1TraceDataSend,

		S6F11JOBProcessEvent,
		S6F11PanelProcessEvent,
		S6F11PortEvent,
		S6F11PortParameterEvent,
		S6F11EqEvent,
		S6F11EqParameterEvent,
		S6F11EqSpecificControlEvent,
		S6F11MaterialEvent,
		S6F11MaterialQtyReportEvent,
		S6F11PanelIDValidationEvent,
		S6F11EqStandardDataEvent,
		S6F11ProductionPlanEvent,
		S6F11PortEvent2,
		S6F11MaterialEvent2,
		S6F11LabelPrintingEvent,
		S6F11BatchComponentRequestProcessEvent,

		S6F12EventReportAck,

		S6F13CassetteDataCollection,
		S6F13GlassDataCollectionNormalEq,
		S6F13GlassDataCollectionEqFileServer,

		S6F14AnnotatedEventReportAck,
		S6F65RawDataInfo,

		S7F1ProcessProgramLoadInquire,
		S7F2ProcessProgramLoadGrant,
		S7F9RelatedMaterialIDRequestSpecialPPID,
		S7F10RelatedMaterialIDDataSpecialPPID,
		S7F23FormattedProcessProgramSend,
		S7F24FormattedProcessProgramAck,
		S7F25FormattedProcessProgramRequest,
		S7F26FormattedProcessProgramData,
		S7F33ProcessProgramAvailableRequest,
		S7F34ProcessProgramAvailabilityData,
		S7F101CurrentEqPPIDListRequest,
		S7F102CurrentEqPPIDData,
		S7F103PPIDExistenceCheck,
		S7F104PPIDExistenceCheckAck,
		S7F105PPIDSoftrevCheck,
		S7F106PPIDSoftrevCheckAck,
		S7F107PPIDCreateDeleteModify,
		S7F108PPIDCreateDeleteModifyReport,
		S7F109CurrentRunningEqPPIDRequest,
		S7F110CurrentRunningEqPPIDData,
		S7F111TactTimeRelatedPPIDRequest,
		S7F112SettingTactTimeSend,

		S9F1UnrecognizedDeviceID,
		S9F3UnrecognizedStreamType,
		S9F5UnrecognizedFunctionType,
		S9F7IllegalData,
		S9F9TransactionTimerTimeOut,
		S9F11DataTooLong,

		S10F3TerminalDisplaySingle,
		S10F9Broadcast,
		S10F101TerminalDisplayMultiBlock,
		S10F102TerminalDisplayMultiBlockAck,

		S14F1GetAttrRequest,
		S14F2GetAttrData,
		S14F3SamplingInformationRequest,
		S14F4SamplingInformationReply,

		S64F1AutoFeedbackCommand,
		S64F2AutoFeedbackCommandReply,
		S64F5FeedbackResultSend,

		S100F1GlassTrackingEvent,
		S100F2GlassTrackingEventReply,

		S110F1PIOChangeEvent,
		S110F2PIOChangeEventReply,

		S125F1ParameterChangedEvent,
		S125F1ParameterChangedEventReply,
	}

	public class HostEventArgs : EventArgs
	{
		public eHostEventType EventType;
		public eHostType HostType;
		public object HsmsMsg;

		public HostEventArgs(eHostEventType eventType, eHostType hostType, object hsmsMsg)
		{
			this.EventType = eventType;
			this.HostType = hostType;
			this.HsmsMsg = hsmsMsg;
		}
	}

}
