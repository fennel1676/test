using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
    public enum ePORTID
    {
        //NONE = 0,
        IP01 = 1,
        IP02 = 2,
        IP03 = 3,
        IP04 = 4,
    }

    public enum eLINE
    {
        NOLINE  =  0,
        LINE1 = 1,
        LINE2 = 2,
      //  EQLINE = 3,
    }

    public enum eORDER
    {
        NONE   = 0,
        ORDER1 = 1,
        ORDER2 = 2,
        ORDER3 = 3,
        ORDER4 = 4,
    }

    public enum eActState
    {
        NONE = 0,
        JOBEND = 1,
        JOBCANCEL = 2,
    }

    public enum eHPanelIDState
    {
        NONE = 0,
        HPANELID_EMPTY = 1,
        HPANELID_DUPLICATE = 2,
    }

    public enum eUniqueIDState
    {
        NONE = 0,
        UNIQUEID_EMPTY = 1,
        UNIQUEID_DUPLICATE = 2,
    }

    public enum eBatchIDState
    {
        NONE = 0,
        BATCHID_EMPTY = 1,
    }

    public enum eLineState
    {
        NONE = 0,
        PAUSE = 1,
        RESUME = 2,        
    }
    public enum eEIPCMD
    {
        OFFLINE = 0,
        ONLINE = 1,
    }
	public enum eMCMD
	{
        NONE = 0,
		OFFLINE = 1,
		LOCAL = 2,
		REMOTE = 3,
	}

	public enum eEqState
	{
		NORMAL = 1,
		FAULT = 2,
		PM = 3,
		NotManage = 255,
	}

	public enum eProcState
	{
		INIT = 1,
		IDLE = 2,
		SETUP = 3,
		READY = 4,
		EXECUTE = 5,
		PAUSE = 6,
		NotManage = 255,
	}

	public enum eByWho
	{
        ByNone = 0,
		ByHost = 1,
		ByOperator = 2,
		ByEquipment = 3,
		ByIndexer = 4,
	}

    public enum eReply
    {
        ACK = 0,
        NAK_START = 1,
        NAK_CANCEL = 2 ,
        NAK_ABORT = 3,
        NAK_RELOAD = 36,
        NAK_PAUSE = 95,
        NAK_RESUME = 96,
        NAK_END = 99,
        NAK_COMMAND_ID = 100,
    }

    public enum ePortState
	{
		Empty = 0,
		Idle = 1,
		Ready = 2,
		Wait = 3,
		Reserve = 4,
		Busy = 5,
		Complete = 6,
		Abort = 7,
		Cancel = 8,
		Pause = 9,
		Disable = 10,
	}

    public enum eBatchtState
    {

        Wait = 0,
        Busy = 1,
        Complete = 2,
    }   

	public enum ePortType
	{
        NONE = 0,
		BothPort = 1,
		InputPort = 2,
		OutputPort = 3,
		SGSBuffer = 4,
	}

    public enum ePortMode
    {
        NONE = 0,
        OK = 1,
        NG = 2,
    }

	public enum eCstDemand
	{
        NONE = 0,
		NormalCst = 1,
		EmptyCst = 2,
	}

    public enum eClassNo
    {
        NONE = 0,
        T_Module = 1,
        C_Module = 2,
        Any  = 3,
    }

	public enum eFUP
	{
		OldBatch = 1,
		GlassQty = 2,
		WaitCnt = 3,
		WaitTime = 4,
	}

	public enum eSortType
	{
        NONE = 0,
		GlassQuantityinCst = 1,
		ReverseFill = 2,
		Reverse = 3,
		GlassSizeThickness = 4,
		ProcessIDwithStepID = 5,
		ProductIDwithStepID = 6,
		BatchIDwithStepID = 7,
		ProcessID = 8,
		ProductID = 9,
		BatchID = 10,
	}

	public enum eBatchOrder
	{
        NONE = 0,
		Start = 1,
		Normal = 2,
		End = 3,
	}

    public enum eCstType
    {
        NONE = 0,
        Normal = 1,
        Wire = 2,
        Cell_15x1 = 3,
        Cell_15x2 = 4,
        Cell_15x3 = 5,

        Cell_24x2 = 7,
        Cell_24x3 = 8,
    }


	public enum eProdType
	{
        //None = 0,
		NR,	//Normal
		DM,	//PMDT
	}

	public enum eProdKind
	{
        //None = 0,
		TF,	//TFT
		CF,	//ColorFilter
		PD,
	}

	public enum ePanelState
	{
        None = 0,
		Idle = 1,
		SelectedToProcess = 2,
		Processing = 3,
		Done = 4,
		Aborting = 5,
		Aborted = 6,
		Canceled = 7,
	}

	public enum eReadingFlag
	{
		RD,	//Reading
		KN,	//KeyInput
		SK,	//Skip
	}

	public enum eFlagName
	{
		WORK_SKIP,
		BATCH_START,
		BATCH_END,
		JOB_START,
		JOB_END,
		HOTFLOW_FLAG,
		PHYSICAL_FLAG,
		M_START_FLAG,
		ALIGN_FLAG,
	}

	public enum eMType
	{
		MASK,
		PI,
		APR,
		ROLL,
		TAPE,
		SEALANT,
		SPACER,
		FIBER,
		PANEL,
	}

	public enum eMValid
	{
		OK,
		NG,
	}

	public enum eMPState
	{
		EMPTY = 1,
		STANDBY = 2,
		BUSY = 3,
		DOWN = 4,
	}

	public enum eMState
	{
		IDLE = 1,
		USABLE = 2,
		UNUSABLE = 3,
	}

	public enum eMSubloc
	{
		LIBRARY,	//Material Slot
		PPC,		//Particle Measuring
		BUFF,		//Preload Stage
		STAGE,		//Onstage
		PREALIGN,	//Pre Align
	}

	public enum eEqInterLockItem
	{
		IMMEDIATELY_PAUSE,
		TRANSFER_STOP,
		LOADING_STOP,
		SPECIFIC_INTERLOCK,
		GLASS_REFUSE,
	}

	public enum eEqInterLockValue
	{
		ON,
		OFF,
		DO,
		WD,
		RT,
	}	

	public enum eMCarrierID
	{
		MaterialCarrier = 6,
		HorizontalTray = 7,
		VerticalTray = 8,
	}

	public enum eMKind
	{
		Mask = 1,
		ProbeCard = 2,
		Target = 3,
		PR = 4,
		PI = 5,
		APR = 6,
		RubbingRoll = 7,
		RubbingCloth = 8,
		LiquidCrystal = 9,
		Sealant = 10,
		POL = 11,
		ZIG = 12,
		TABIC = 13,
		PCB = 14,
		BL = 15,
		TC = 16,
		ACF = 17,
		ACFPrebondingSheet = 18,
		ACFBonding = 19,
		TerminalWipe = 20,
		TermianlMaterial = 21,
		AssemblyLabel = 22,
		AssemblyLabelPaper = 23,
		Cushion = 24,
		PACKingPallet = 25,
	}

	public enum eMBType
	{
		DurableMaterial = 1,
		CalculationConsumableMaterial = 2,
		MeasuringConsumableMaterial = 3,
	}

	public enum eMBState
	{
		IDLE = 1,
		ENABLE = 2,
		RUN = 3,
		HOLD = 4,
		DISABLE = 5,
	}

	public enum eMBStep
	{
		Gate,
		Source,
		TFT,
		CF,
	}

	public enum eLKind
	{
		GTUnloaderLabel = 1,
		ACUnloaderLabel = 2,
		AssyCustomerLabel = 3,
		FTCustomerLabel = 4,
		CushionLabel = 5,
		SmallBoxLabel = 6,
		LargeBoxLabel = 7,
	}



	public enum eSFCD
	{
		EquipmentOnlineParameter = 1,
		PortStates = 2,
		GlassTracking = 3,
		ModuleStates = 4,
		CassetteStates = 5,
		PortParameterRequest = 6,
		EqStandardTactRequest = 7,
		EqCurrentInterlockRequest = 8,
		FlowControlTableRequest = 9,
		GlassStockInfo = 16,
		ProductionPlanInfomation = 22,
		MaterialBatchInformation = 23,
        LoadRejectParameter = 54,
	}

    public enum ePLCD
    {
        ProductPlanCreate = 1,
        ProductPlanDelete = 2,
        ProductPlanChange = 3,
        ProductPlanPullInfoSend = 4,
        ProductPlanStartPermissionOK = 5,
        ProductPlanStartPermissionNG = 6,
    }

	public enum eRCMD
	{
		//Process
		JobProcessStart = 1,
		JobProcessCancel = 2,
		JobProcessAbort = 3,
		ManualJobProcessStart = 5,

		//Material
		MaterialValidationResult = 31,
		MaskCleanStart = 32,

		//Port
		ReloadCassette = 36,

		//Equipment
		EquipmentProcessStatePause = 51,
		EqProcessStateResume = 52,
		EqStateChangeToPM= 53,
		EqStateChangeToNormal= 54,
		RequestOfSpoolProcessEndEvent= 55,
		EqCycleStopRequest = 57,

		//JobChange
		JobChangeCommand = 56,

		//Judgement
		JudgementCommand = 61,
		ManualCellProcessStartCommand = 62,
		ManualCellProcessCancelCommand = 63,

		//Sort
		SortingJobProcessStart = 231,
		SortingJobProcessCancel = 232,
		SortingJobProcessAbort = 233,
		SortingJobProcessEnd = 234,
		ScanJobProcessStart = 235,
		ScanJobProcessEnd = 236,
		WireScanJobProcessStart = 237,
		WireScanJobProcessEnd = 238,
		SortingJobProcessUpdate = 245,
		AllGlassJobProcessStart = 246,

		//PairProcess
		PairJobProcessStart = 101,
		PairJobProcessCancel = 102,
		PairJobProcessAbort = 103,

        //투입 및 중지
        BatchPauseStart = 95,
        BatchResumeStart = 96,
        BatchEndStart = 99,

	}

	public enum eCEID
	{
		//Receive from EQPLC
		GlassInitial = 0,
		//Related Job Process
		JobProcessStart = 1,
		JobProcessCancel = 2,
		JobProcessAbort = 3,
		JobProcessEnd = 4,
		SpooledProcessEnd = 5,
		PanelProcessStartForIndexer = 6,
		PanelProcessEndForIndexer = 7,
        PlanBatchPause = 25,
        PlanBatchResume = 26,
        //Related Port
        CassettePreLoad = 31,
        CassetteClampOn = 32,
        CassetteLoadComplete = 33,
        CassetteUnloadRequest = 34,
        CassetteUnloadComplete = 35,
        CassetteLoadRequest = 36,
        CassetteLoadRejected = 37,
        CassetteInformRequest = 39,
		SortingJobStart = 231,
		SortingJobCancel = 232,
		SortingJobAbort = 233,
		SortingJobEnd = 234,
		ScanJobStart = 235,
		ScanJobEnd = 236,
		WireScanJobStart = 237,
		WireScanJobEnd = 238,
		CarrierUpdateRequest = 239,
		//Related Panel Process
		ProcessResultEvent = 11,
		GlassIsCancelled = 12,
		GlassIsAborted = 13,
		GlassBroken = 14,
		GlassUnbroken = 15,
		PanelProcessStartForModule = 16,
		PanelProcessEndForModule = 17,
		SortKeyValueMismatch = 18,
		GlassMoveOut = 19,
		GlassMoveIn = 20,
		CrackGlassDetect = 141,
		CrackGlassRelease = 142,
		CrackGlassConfirm = 143,
		CanNotFindStackData = 61,
		FileFormatIsDifferent = 66,
		BreakEvent = 121,
		AssemblyEvent = 122,
		PairlessEvent = 123,
		CuttingEvent = 124,
		MatchingEvent = 125,
		PairGlassRequest = 126,
		PanelidRead = 241,
		SortingGlassWaitIn = 242,
		SortingGlassWaitOut = 243,
		SortingDestRequest = 244,
		SortingJobUpdate = 245,
		LastGlassLossEvent = 261,
		LastGlassAssignmentEvent = 262,
		//Related Equipment Standard Data
		StandardTactTimeChanged = 56,
		
		SGSFull = 40,
		NGCassetteFull = 41,
		ConveyorBufferFull = 42,
		BufferCassetteFull = 43,
		CassetteMoveIn = 44,
		CassetteMoveOut = 45,
		//Related Port Parameter
		PortParameterIsChanged = 46,
		//Related Equipment
		EqProcessStateChanged = 51,
		EqProcessStateTimeOver = 52,
		EqStateChanged = 53,
		JobChangeStart = 54,
		JobChangeEnd = 55,
		ChangeToOnLineLocalMode = 72,
		ChangeToOnLineRemoteMode = 73,
		//Related Equipment Parameter
		ParameterChangedEOID = 101,
		ParameterChangedECID = 102,
		//Related Material Event
		MaterialStockIn = 201,
		MaterialStockOut = 202,
		MaterialDockIn = 203,
		MaterialDockOut = 204,
		MaterialExchangeRequest = 206,
		MaterialConsumeStart = 207,
		MaterialConsumeEnd = 208,
		MaterialCleanStart = 210,
		MaterialCleanEnd = 211,
		MaterialStateUpdate = 212,
		MaterialPreparationRequest = 219,
		MaterialQTYReportEvent = 251,
		//Related PanelID Validation
		PanelidReadFail = 111,
		HPanelIDSearchFail = 112,
		PanelIDMismatch = 113,
		KeyInTimeOut = 114,
		//Related Production Plan
		ProductPlanBatchStart = 21,
		ProductPlanBatchCancel = 22,
		ProductPlanBatchAbort = 23,
		ProductPlanBatchEnd = 24,
		ProductPlanBatchPause = 25,
		ProductPlanBatchResume = 26,
		ProductPlanBatchCheckRequest = 27,
		PrebatchAvailableCheckRequest = 28,
		BatchAvailableCheckRequest = 29,
		ProductPlanCreate = 80,
		ProductPlanDelete = 81,
		ProductPlanChange = 82,
		ProductPullInfoRequest = 83,
		ProductBatchPlanRegisterRequestEvent = 84,
		CurrentProductPlanRegisterEvent = 85,
		ProductBatchLowProduceResultEvent = 86,
		JobChangeBeforehandInformEvent = 87,
		//Equipment Specific Control
		ProductPlanInfoRequest = 91,
		CrateMaterialMismatch = 92,
		MaterialInfoRequest = 93,
		SemiBatchCreateRequest = 94,
		FPOCreateRequest = 95,
		SpecificationGlassIndexEvent = 96,
		CycleStopRequestEvent = 97,
		InformationDisplayRequestEvent = 98,
		BackupGlassRequest = 120,
		UserLogin = 161,
		UserLogout = 162,
		NetworkServerNotConnected = 172,
		EquipmentCurrentPPIDChangeEvent = 401,
		GlassHandShakeTimeOutEvent = 402,
		ImmediatelyPauseHappenEvent = 403,
		GlassTransferStopHappenEvent = 407,
		GlassLoadingStopHappenEvent = 408,
		SpecificInterlockOnEvent = 409,
		EquipmentPPIDAvailabilityCheck = 410,
		HSValidCheckFail = 413,
		SubToolOfflineChangeEvent = 421,
		SubToolOnlineLocalChangeEvent = 422,
		SubToolOnlineRemoteChangeEvent = 423,
        LoadRejectParameterChangeEvent = 804,
        NoneEvent = 999,
	}

	public enum eTMACK
	{
		ACK = 0,
		ACKwillLater = 1,
		CanNotPerformNow = 2,
		AlreadyRequiredState = 4,
		ModeNotSupport = 5,
		ContentsIsNotUnderstood = 6,
		ParameterNotExist = 7,
		ConstantNotExist = 8,
		ValueOutofRange = 9,
		ConditionNotMatch = 10,
		PartialyPerform = 11,
		FlowIDNotExist = 12,
		FlowIDOutofRange = 13,
		DeviceIDOutofRange = 14,
		EOIDiNotExist = 21,
		ECIDiNotExist = 22,
		SVIDiNotExist = 23,
		SFCDNotSupported = 24,
		CommandNotSupported = 25,
		PPIDNotExist = 26,
		PPIDTypeNotExist = 27,
		TIDNotExist = 28,
		PLCDNotExist = 29,
		PPIDNotAvailable = 30,
		ModuleIDNotExist = 31,
		ObjectIDNotExist = 32,
		CassetteNotExist = 33,
		UnknownMCMD = 34,
		CanNotManageStandardTactTime = 35,
		CassetteIDMismatch = 51,
		PortIDMismatch = 52,
		PortStateNotWaiting = 53,
		ProductIDMismatch = 54,
		GlassSizeNotRecognized = 55,
		CellSizeNotRecognized = 56,
		TargetEqDown = 71,
		TargetEqOffline = 72,
		InformationNotTransferred = 73,
		AlreadyReceived = 74,
		TimeOutHappened = 75,
		LengthError = 76,
		MatrixOverflow = 77,
		OperatorConfirm = 78,
	}

	public enum ePMACK
	{
		ACK = 0,
		ParameterNameNotExist = 1,
		IllegalFormat = 2,
		IllegalValue = 3,
		ObjectNotExist = 4,
		StateError = 5,
		TooManySlotSelected = 6,
		ContentsHasSomeProblem = 7,
		CanNotPerform = 8,
		PortModeNotSet = 16,
		PortModeHasNoMatter = 17,
		STIFNotExist = 18,
		AlreadyRecvSameJobRequest = 19,
		GlassSizeMismatch = 21,
		StepIDMismatch = 22,
		PortIDMismatch = 23,
		CarSizeMismatch = 24,
		OutputSlotOccupied = 25,
		InputSlotEmpty = 26,
		WireSlotNotSelected = 27,
		OutputNGCassette = 28,
		CassetteDemandNotMatched = 29,
	}

	public enum eOBJCAK
	{
		Success = 0,
		Error = 1,
	}
	
    public enum eHCACK
    {
        OK = 0,
        CommandNotExist = 1,
        CannotPerformNow = 2,
        ParameterInvalid = 3,
        CommandPerformLater = 4,
        AlreadyInCondition = 5,
        ObjectNotExist = 6,
        ControlStateNotRemote = 7,
        RawDataNotFound = 8,
        RawDataNotRead = 9,
        PPIDNotExist = 10,

        OtherJobReserved = 12,
        CstInfoNotReceived = 13,
        PortAlreadyFull = 14,
        PPIDNotAvailable = 15,
    }
    public enum eCPACK
    {
        OK = 0,
        ParamNameNotExist = 1,
        IllegalValue = 2,
        IllegalFormat = 3,
        NoCstInPort = 4,
        NoCstOutPort = 5,
        CstIDNotMatchInPort = 6,
        CstIDNotMatchOutPut = 7,
        StateErrorInPort = 8,
        StateErrorOutPort = 9,
        TooManySlot = 10,
        NoGlass = 11,
        GlassAlreadyExist = 12,
        GlassStateError = 13,
        ModuleStateError = 14,
        ToolStateError = 15,
        UnitStateError = 16,

        GlassSizeMismathcInPort = 21,
        GlassSizeMismatchOutPort = 22,
        PartIDMismatchInPort = 23,
        CarSizeMismatch = 24,
        OutSlotOccupied = 25,
        InSlotEmpty = 26,
        WireSlotNotSelected = 27,
        OutputNGCst = 28,
        CstDemandMismatch = 29,
    }

    
    public enum eNACK
    {
        ACK = 0,

        BatchInfoACK = 80,
        JobStartACK = 90,
        CSTInfoACK = 70,

        //S3F104 (Production Plan Reply)
        ItemNotExist = 1,
        DuplicateGlassID = 2,//glassID 중복
        DuplicateOrderNo = 3,
        DuplicateFPanelID = 4,
        DeletePlanError = 5,
        MissmatchCount = 6,
        PLCDNotExist = 7,
        ModuleIDNotExist = 8,
        DiffrentPlanInfo = 9,//다른 fpanelid
        DuplicatePlanInfo = 10,//투입계획 중복
        NotUpdatePlanInfo = 11,
        //S3F102 (CST Information Reply)
        PortStateReservedOrBusy = 101,
        CassetteSlotInfoFail = 102,
        SlotIDNotEqual = 103,
        PairProductIDFail = 104,
        FlowIDFail = 105,
        PortEmpty = 106,
        CstIDFail = 107,
        PortNumFail = 108,
        PortStateFail = 109,
        BatchIDFail = 110,
        FlowGroupFail = 111,
        BatchPlanNotExist = 112,

        //S2F42(Job Command Reply)
        PortIDFail = 201,
        //PortStateEmpty = 202,
        NotWaitState = 203,
        //StifMismatch = 204,
        NoExistGlass = 205,
        //EQPassiveMode = 206,
        NotRemote = 207,
        PMakerMismatch = 208,
        FlowIDMismatch = 209,
        FlowGroupMismatch = 210,
        //ProductPlanNotExist = 211,
        NotPortState = 212,



    }


    public enum ePROC
    {
        ACK = 0,

        BatchInfoACK = 80,
        JobStartACK = 90,
        CSTInfoACK = 70,

        //S3F104 (Production Plan Reply)
        ItemNotExist = 1,
        DuplicateGlassID = 2,
        DuplicateOrderNo = 3,
        DuplicateFPanelID = 4,
        DeletePlanError = 5,
        MissmatchCount = 6,
        PLCDNotExist = 7,
        ModuleIDNotExist = 8,
        DiffrentPlanInfo = 9,
        DuplicatePlanInfo = 10,
        NotUpdatePlanInfo = 11,
        //S3F102 (CST Information Reply)
        PortStateReservedOrBusy = 101,
        CassetteSlotInfoFail = 102,
        SlotIDNotEqual = 103,
        PairProductIDFail = 104,
        FlowIDFail = 105,
        PortEmpty = 106,
        CstIDFail = 107,
        PortNumFail = 108,
        PortStateFail = 109,
        BatchIDFail = 110,
        FlowGroupFail = 111,
        BatchPlanNotExist = 112,

        //S2F42(Job Command Reply)
        PortIDFail = 201,
        //PortStateEmpty = 202,
        NotWaitState = 203,
        //StifMismatch = 204,
        NoExistGlass = 205,
        //EQPassiveMode = 206,
        NotRemote = 207,
        PMakerMismatch = 208,
        FlowIDMismatch = 209,
        FlowGroupMismatch = 210,
        //ProductPlanNotExist = 211,
        NotPortState = 212,



    }

    public enum eERRCODE
    {
        NoError = 0,
        InvalidPortID = 1,
        BatchPlanNotExist = 2,
        CassetteInfoNotExist = 3,
        InvalidBatchID = 4,

        ReloadCassette = 5,
        CancelCassette = 6,

        //CancelNoBatchExit  =7,
        //CancelBatchid
    }
}
