using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using ClassCore;
using HostCore;
using EqCore;

/*========================================================================================
	NameSpqce : ProdPlanManager
	DESCRIPT : Main Form이 속한 영역
	UPDATE	 : 2009.03.10
	ARGUMENT : 
========================================================================================*/
namespace ProdPlanManager
{
    public partial class MainForm : Form
    {
        //변수       
        public List<HostCom> hostComs = null;
        public List<EqCom> eqComs = null;
        private DisconnectHostForm disconnectHostForm = null;
        private DisconnectPLCForm disconnectPLCForm = null;
        private PortInputForm portInputForm = null;

        private BatchNACKForm[] batchNackForms;
        private CassetteNACKForm[] cstNACKForms;
        private JobStartNACKForm[] jobStartNACKForms;

        public int m_nCount = 1;

        public MainForm()
        {
            InitializeComponent();
            InitializeSystem();
        }
        private void InitializeSystem()
        {
            InitDB();
            InitLCData();
            InitUI();          
            InitForm();
            InitEq();          
            InitHost();
            LCData.LoadAll();//이전 Data 값 Loading

            foreach (BatchManager data in LCData.BatchManagers)
            {
                if (data.TARGET_LINE != eLINE.LINE1)
                {
                    portDataControl1.UpdateDisplay(data.PortDatas[0].Port.PortNo);
                    portDataControl1.UpdateDisplay(data.PortDatas[1].Port.PortNo);
                    portSlotControl1.UpdateDisplay(data.PortDatas[0].Port.PortNo, data.PortDatas[0].Port.CurStif);
                    portSlotControl1.UpdateDisplay(data.PortDatas[1].Port.PortNo, data.PortDatas[1].Port.CurStif);
                    batchDataControl1.UpdateDisplay(data.TARGET_LINE);
                }
                else
                {
                    portDataControl1.UpdateDisplay(data.PortDatas[0].Port.PortNo);
                    portDataControl1.UpdateDisplay(data.PortDatas[1].Port.PortNo);
                    portSlotControl1.UpdateDisplay(data.PortDatas[0].Port.PortNo, data.PortDatas[0].Port.CurStif);
                    portSlotControl1.UpdateDisplay(data.PortDatas[1].Port.PortNo, data.PortDatas[1].Port.CurStif);
                    batchDataControl1.UpdateDisplay(data.TARGET_LINE);
                }

            }

            if (LCData.OnlineHostState == eMCMD.OFFLINE)
            {
                foreach (HostCom hostCom in hostComs)
                {
                    this.Focus();
                    hostCom.Start();
                    this.Focus();
                }
            }
        }

        /// <summary>
        /// From 화면 초기화 합니다.
        /// </summary>
        private void InitForm()
        {            
            portInputForm = new PortInputForm();
            portInputForm.InitControl();

            batchNackForms = new BatchNACKForm[2];
            cstNACKForms = new CassetteNACKForm[2];
            jobStartNACKForms = new JobStartNACKForm[2];
            for (int i = 0; i < 2; i++)
            {
                batchNackForms[i] = new BatchNACKForm();
                cstNACKForms[i] = new CassetteNACKForm();
                jobStartNACKForms[i] = new JobStartNACKForm();

                batchNackForms[i].Hide();
                cstNACKForms[i].Hide();
                jobStartNACKForms[i].Hide();
            }                     

            disconnectHostForm = new DisconnectHostForm();
            disconnectPLCForm = new DisconnectPLCForm();

            operationControl1.UpdateBatchEvent += new OperationControl.BatchViewEventHandler(batchDataControl1.UpdateDisplay);
            operationControl1.CheckBatchInfoEvent += new OperationControl.CheckEventHandler(IsDuplicateBatch);
            operationControl1.CheckFPanelIDEvent += new OperationControl.CheckEventHandler(IsDuplicateGlassID);
            operationControl1.BatchEndEvent += new OperationControl.BatchEndEventHandler(ProcessBatchEndEvent);
            operationControl1.BatchRequestEvent += new OperationControl.BatchRequestEventHandler(ProcessBatchRequestEvent);
            operationControl1.ResumeEvent += new OperationControl.ResumeEventHandler(ProcessResumeCommand);
            operationControl1.PauseEvent += new OperationControl.PauseEventHandler(ProcessPauseCommand);            
            stateControl1.OnlineChangeEvent += new StateControl.OnlineChangeEventHandler(ProcessOnlineChangeEvent);
            portInputForm.PortEvent +=new PortInputForm.PortEventHandler(portDataControl1.UpdateDisplay);
            portInputForm.CstInfoEvent += new PortInputForm.CstInfoHandler(SendCstInfo);
            portInputForm.JobStartEvent += new PortInputForm.JobStartEventHandler(ProcessJobStartCommand);
            portInputForm.JobAbortEvent += new PortInputForm.JobAbortEventHandler(ProcessJobAbortCommand);
            portInputForm.JobCancelEvent += new PortInputForm.JobCancelEventHandler(ProcessJobCancelCommand);
            portInputForm.JobReloadEvent += new PortInputForm.JobReloadEventHandler(ProcessReloadCommand);
            portInputForm.SetMessage += new PortInputForm.SetMessageEventHandler(SetMessage);
            subOperationControl1.WIPQTYSetView += new SubOperationControl.WIPQTYSetViewEventHandler(ProcessC17WIPQTYInfoCommand);
            subOperationControl1.BatchHistoryView += new SubOperationControl.BatchHistoryViewEventHandler(GetBatchHistorys);
            subOperationControl1.AlarmHistoryView += new SubOperationControl.AlarmHistoryViewEventHandler(GetAlarmHistorys);
            subOperationControl1.UpdateParameterSet += new SubOperationControl.UpdateSetEventHandler(SetParameterInfo);
            subOperationControl1.UpdateInterlockSet += new SubOperationControl.UpdateSetEventHandler(SetFlowGroupInterlockInfo);
            subOperationControl1.UpdatePeriodSet += new SubOperationControl.UpdateSetEventHandler(SetHistoryPeriodInfo);
            subOperationControl1.UpdateLogcolorSet += new SubOperationControl.UpdateSetEventHandler(SetLogColorSetInfo);
            subOperationControl1.LogHistoryView += new SubOperationControl.LogHistoryViewEventHandler(GetLogHistorys);
            subOperationControl1.UpdateECIDSet += new SubOperationControl.UpdateSetEventHandler(ProcessC10EqConstantCommand);
            portDataControl1.SelectPortEvent += new PortDataControl.SelectPortEventHandler(portDataControl1_SelectPortEvent);

            
        }
        private void InitDB()
        {
            //#region 라인용
            //string dataSource = "CCS_CF_IX";
            //string catalog = "CCS_T8_2_Ph1_CF_IX";// data base 명
            //string userID = "sa";
            //string password = "xkdwjd";
            //string security = "FALSE";
            //#endregion
            #region 사무실용
            string dataSource = "(local)";
            string catalog = "CCS_T8_2_Ph1_CF_IX";// data base 명
            string userID = "";
            string password = "";
            string security = "TRUE";
            #endregion
            string connectString = "Data Source=" + dataSource + ";Initial Catalog=" + catalog
                                    + ";User ID=" + userID + ";Password=" + password + ";";
            if (dataSource != null && Network.IsIP(dataSource))
            {
                connectString = connectString.Replace(";Initial", ",1433;Network Library=DBMSSOCN;Initial");
            }
            if (security != null && security.ToUpper() == "TRUE")
            {
                connectString += "Integrated Security=True;";
            }

            bool result = sqlManager.ConnectDB(connectString);
            if (!result)
            {
                MessageBox.Show("Database에 접속할 수 없습니다.", "DB접속오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            else
            {
                NowTimer.Enabled = true;
            }
          
        }
        private void InitLCData()
        {
            LCData.CCSType = sqlManager.GetCCSType();
            LCData.EqStatePriority = sqlManager.GetEqStatePriority();
            LCData.ProcStatePriority = sqlManager.GetProcStatePriority();
            LCData.JobStart = sqlManager.GetStartJobNumber();
            LCData.GlassStart = sqlManager.GetStartGlassNumber();
            LCData.Version = sqlManager.GetProcessVerion();
            LCData.Operation = sqlManager.GetOperationInfo();
            LCData.Password = sqlManager.GetPassword();       
            LCData.OnlineHostState  = eMCMD.OFFLINE;
            LCData.OnlinePLCState   = eEIPCMD.OFFLINE;
            LCData.Modules          = sqlManager.GetModules();
            LCData.ModuleLayer      = sqlManager.GetModuleLayer();            
            LCData.Alarms           = new List<AlarmData>();    
            LCData.EqOnlineParams   = sqlManager.GetEqOnlineParams();
            LCData.EqConstants      = sqlManager.GetEqConstants();
            LCData.WIPQTYs          = sqlManager.GetWIPQTYs();
            LCData.Parameter        = sqlManager.GetParameter();
            LCData.FlowGroups       = sqlManager.GetFlowGroups();
            LCData.FlowRecipes      = sqlManager.GetFlowRecipes();
            LCData.Mappings         = sqlManager.GetMappings();
            LCData.AlarmInfos       = sqlManager.GetAlarmInfos();            
            LCData.StateRules       = sqlManager.GetStateRules();
            LCData.StandardTact     = sqlManager.GetStandardTact();
            LCData.interlockDatas   = sqlManager.GetInterlockDatas();
            LCData.HistoryPeriodSet = sqlManager.GetHistoryPeriod();
            LCData.logColors         = sqlManager.GetLogColors();
            LCData.logInfoDatas     = sqlManager.GetLogInfoDatas();
            LCData.BatchManagers.Add(sqlManager.GetL1Batchs());
            LCData.BatchManagers.Add(sqlManager.GetL2Batchs());

            logManager.LogNameType = "yyyyMMdd_HH";
            logManager.LogFileType = ".csv";
            logManager.LogDeleteDay = LCData.HistoryPeriodSet.LogHistoryPeriod;
            logManager.LogFilePath = sqlManager.GetLogPath() + "\\";

            alarmlogManager.LogNameType = "yyyyMMdd";
            alarmlogManager.LogFileType = ".csv";
            alarmlogManager.LogDeleteDay = LCData.HistoryPeriodSet.AlarmHistoryPeriod;
            alarmlogManager.LogFilePath = sqlManager.GetAlarmLogPath() + "\\";

            terminallogManager.LogNameType = "yyyyMMdd_HH";
            terminallogManager.LogFileType = ".csv";
            terminallogManager.LogDeleteDay = LCData.HistoryPeriodSet.LogHistoryPeriod;
            terminallogManager.LogFilePath = sqlManager.GetTerminalLogPath() + "\\";


        }
        private void InitUI()
        {      
            alarmControl1.InitControl();
            msgControl1.InitControl();
            portDataControl1.InitControl();
            portSlotControl1.InitControl();
            batchDataControl1.InitControl();
            inputControl1.InitControl();
            stateControl1.InitControl();
            subOperationControl1.InitControl();
            operationControl1.InitControl();

            //--- 프로그램 최초 실행시, 이전 로그 표시
            LCData.logHistoryDatas = sqlManager.GetLogHistorys(LCData.Parameter.LimitLineCount);
            int count = LCData.logHistoryDatas.L1Count + LCData.logHistoryDatas.L2Count;
            for (int i = count - 1; i >= 0; --i)
            {
                logControl1.UpdateDisplay((eLINE)LCData.logHistoryDatas.LogHistorys[i].line, LCData.logHistoryDatas.LogHistorys[i].Text);
            }            
        }
        private void InitEq()
        {
            List<EqData> eqDatas = sqlManager.GetEqs();
            eqComs = new List<EqCom>();
            foreach (EqData eqData in eqDatas)
            {
                EqCom eqCom = new EqCom();
                eqCom.OnEqReceived += new EqCom.EqReceivedEvent(OnEqReceived);

                eqCom.Init(eqData);
                eqCom.Start();
                eqComs.Add(eqCom);
            }
        }
        private void InitHost()
        {
            List<HostData> hostDatas = sqlManager.GetHosts();
            hostComs = new List<HostCom>();
            foreach (HostData hostData in hostDatas)
            {
                HostCom hostCom = new HostCom();
                hostCom.OnHostReceived += new HostCom.HostReceivedEvent(OnHostReceived);

                hostCom.Init(hostData);
                hostComs.Add(hostCom);
            }
        }
        /*========================================================================================
            FUNCTION : OnHostReceived
            DESCRIPT : Host Message 이벤트 핸들러
        ========================================================================================*/
        private void OnHostReceived(object sender, HostEventArgs e)
        {
            if (e.HostType == eHostType.Host)
            {
                switch (e.EventType)
                {
                    case eHostEventType.Connect: ProcessHostConnect(e); break;
                    case eHostEventType.Disconnect: ProcessHostDisconnect(e); break;
                    case eHostEventType.S1F1AreYouThere: ProcessS1F1AreYouThere(e); break;
                    case eHostEventType.S1F2OnLineData: ProcessS1F2OnLineData(e); break;
                    case eHostEventType.S1F5FormattedStateRequest: ProcessS1F5FormattedStateRequest(e); break;
                    case eHostEventType.S1F17RequestOnLine: ProcessS1F17RequestOnLine(e); break;
                    case eHostEventType.S2F41HostCommand:
                        {
                            S2F41HostCommand cmd = (S2F41HostCommand)e.HsmsMsg;
                            switch ((eRCMD)cmd.RCMD)
                            {
                                case eRCMD.JobProcessStart: ProcessS2F41JobStartCommand(e); break;
                                case eRCMD.JobProcessCancel: ProcessS2F41JobCancelCommand(e); break;
                                case eRCMD.JobProcessAbort: ProcessS2F41JobAbortCommand(e); break;
                                case eRCMD.ReloadCassette: ProcessS2F41PortCommand(e); break;
                            }
                        }
                        break;
                    case eHostEventType.S2F41EqCommand: ProcessS2F41EqCommand(e); break;
                    case eHostEventType.S2F31DateTimeSetRequest: ProcessS2F31DateTimeSetRequest(e); break;
                    case eHostEventType.S2F103EqOnlineParameterChange: ProcessS2F103EqOnlineParameterChange(e); break;
                    case eHostEventType.S3F101CassetteInfo: ProcessS3F101CassetteInfo(e); break;
                    case eHostEventType.S3F103ProductionPlanInfoSend: ProcessS3F103ProdPlanInfo(e); break;
                    case eHostEventType.S5F101WaitingResetAlarmsList: ProcessS5F101WaitingResetAlarmsList(e); break;
                    case eHostEventType.S5F103SelectAlarmForcedResetRequest: ProcessS5F103SelectAlarmForcedResetRequest(e); break;
                    case eHostEventType.S10F3TerminalDisplaySingle: ProcessS10F3TerminalDisplaySingle(e); break;
                    case eHostEventType.S10F9Broadcast: ProcessS10F9Broadcast(e); break;
                    default: break;
                }
            }
        }
        /*========================================================================================
            FUNCTION : OnEqReceived
            DESCRIPT : EQPLC Message 이벤트 핸들러
        ========================================================================================*/
        private void OnEqReceived(object sender, EqEventArgs e)
        {
            switch (e.EventType)
            {
                case eEqEventType.Connect:ProcessEqConnect(e);break;
                case eEqEventType.Disconnect:ProcessEqDisconnect(e);break;
                case eEqEventType.R1TransferGlassDataReport:ProcessR1TransferGlassDataReport(e);break;
                case eEqEventType.R2SetAlarmReport:ProcessR2SetAlarmReport(e);break;
                case eEqEventType.R3ResetAlarmReport:ProcessR3ResetAlarmReport(e);break;
                case eEqEventType.R4UnitStateReport:ProcessR4UnitStateReport(e);break;
                case eEqEventType.R5InitializeUnitStateReport:ProcessR5InitializeUnitStateReport(e);break;
                case eEqEventType.R6GlassControlReport:ProcessR6GlassControlReport(e);break;
                case eEqEventType.R8InitializeAlarmReport:ProcessR8InitializeAlarmReport(e);break;
                case eEqEventType.E12PortEvent:
                    {
                        E12PortEvent Evt = (E12PortEvent)e.XmlMsg;
                        switch (Evt.Port.PortEvent)
                        {
                            case eCEID.JobProcessStart:ProcessE12JobStartEvent(e);break;
                            case eCEID.JobProcessCancel:ProcessE12JobCancelEvent(e);break;
                            case eCEID.JobProcessAbort: ProcessE12JobAbortEvent(e);break;
                            case eCEID.JobProcessEnd: ProcessE12JobEndEvent(e);break;
                            case eCEID.CassetteLoadRequest:ProcessE12LoadRequestEvent(e);break;
                            case eCEID.CassettePreLoad:ProcessE12PreLoadEvent(e);break;
                            case eCEID.CassetteClampOn:ProcessE12ClampOnEvent(e);break;
                            case eCEID.CassetteLoadComplete: ProcessE12LoadCompleteEvent(e);break;
                            case eCEID.CassetteUnloadRequest:ProcessE12UnLoadRequestEvent(e);break;
                            case eCEID.CassetteUnloadComplete:ProcessE12UnLoadCompleteEvent(e);break;
                            case eCEID.PlanBatchPause:ProcessE12BatchPauseEvent(e);break;
                            case eCEID.PlanBatchResume:ProcessE12BatchResumeEvent(e);break;
                            default:
                                break;
                        }                        
                    }
                    break;
                case eEqEventType.E13PanelIDReqEvent:ProcessE13PanelIDReqEvent(e);break;
                case eEqEventType.E18DuplicationEvent:ProcessE18DuplicationEvent(e);break;
                case eEqEventType.E14WIPQTYEvent:ProcessE14WIPQTYEvent(e);break;
                case eEqEventType.E15BatchPauseEvent:ProcessE15BatchPauseEvent(e);break;
                case eEqEventType.E16BatchResumeEvent:ProcessE16BatchResumeEvent(e);break;
                case eEqEventType.E17InitialSynchEvent:ProcessE17InitialSynchEvent(e);break;
                case eEqEventType.E19OnlineStateEvent:
                    {
                        E19OnlineStateEvent recv = (E19OnlineStateEvent)e.XmlMsg;
                        switch (recv.ConnectionState)
                        {
                            case 0: ProcessEqDisconnect(); break;
                            case 1: ProcessEqConnect(); break;
                        }
                    }
                    break;
                case eEqEventType.E20PLCSignalEvent: ProcessE20PLCSignalEvent(e); break;
                default:
                    break;
            }
        }
        /*========================================================================================
            FUNCTION : ProcessHostConnect
            DESCRIPT : Host 통신 연결 발생에 따른 처리 로직
        ========================================================================================*/
        private void ProcessHostConnect(HostEventArgs e)
        {
            if (e.HostType == eHostType.Host)
            {
                disconnectHostForm.Hide();
                LCData.OnlineHostState = (eMCMD)sqlManager.GetOnlineMode();  //REMOTE, LOCAL에 대한 상태값을 재 설정.              

                S1F1AreYouThere send    = new S1F1AreYouThere();                
                send.ModuleID           = LCData.Modules[0].ID;         
                hostComs[(int)eHostType.Host].SendS1F1AreYouThere(send);
                
                //설비 가동
                if (LCData.OnlinePLCState != eEIPCMD.OFFLINE)
                {
                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.HOST_CONNECT);               

                    foreach (BatchManager BatchInfo in LCData.BatchManagers)
                    {                       
                        if ((BatchInfo.PortDatas[0].PAUSE_STATE & BatchInfo.PortDatas[1].PAUSE_STATE) == 1)
                            ProcessResumeCommand(BatchInfo.TARGET_LINE, eByWho.ByEquipment, eLogType.PC_RESUME_NORMAL);                       
                        
                        foreach (PortData PortInfo in BatchInfo.PortDatas)
                        {
                            portInputForm.UpdateOnlineMode(PortInfo.Port.PortNo);
                        }

                        if (logInfo != null)
                            SetMessage(logInfo.SerialNo, logInfo.Comment, BatchInfo.TARGET_LINE);
                    }
                }

                stateControl1.UpdateDisplay();                

                timerL1BatchReq.Interval = 100;
                timerL1BatchReq.Enabled = true;
            }
        }
        /*========================================================================================
            FUNCTION : ProcessHostDisconnect
            DESCRIPT : Host 통신 연결 해제 발생에 따른 처리 로직
        ========================================================================================*/
        private void ProcessHostDisconnect(HostEventArgs e)
        {
            if (e.HostType == eHostType.Host)
            {
                disconnectHostForm.Show();
                sqlManager.SetOnlineMode((int)LCData.OnlineHostState);

                LCData.OnlineHostState = eMCMD.OFFLINE;

                //설비 중지
                if (LCData.OnlinePLCState != eEIPCMD.OFFLINE)
                {
                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.HOST_DISCONNECT);

                    foreach (BatchManager BatchInfo in LCData.BatchManagers)
                    {
                        if (!LCData.FindParamBatchRun())//1이면 그냥 투입.
                        {
                            if ((BatchInfo.PortDatas[0].PAUSE_STATE & BatchInfo.PortDatas[1].PAUSE_STATE) == 0)
                                ProcessPauseCommand(BatchInfo.TARGET_LINE, eByWho.ByEquipment, eLogType.PC_PAUSE_NORMAL);
                        }

                        foreach (PortData PortInfo in BatchInfo.PortDatas)
                        {
                            portInputForm.UpdateOnlineMode(PortInfo.Port.PortNo);
                        }

                        if (logInfo != null)
                            SetMessage(logInfo.SerialNo, logInfo.Comment, BatchInfo.TARGET_LINE);
                    }
                }              
                stateControl1.UpdateDisplay();               

                timerL1BatchReq.Enabled = false;
                timerL2BatchReq.Enabled = false;
            }
        }
        //Host Message
        private void ProcessS1F1AreYouThere(HostEventArgs e)
        {
            S1F1AreYouThere recv = (S1F1AreYouThere)e.HsmsMsg;
            S1F2OnLineData send = new S1F2OnLineData();

            send.ModuleID = LCData.Modules[0].ID;
            send.OnlineMode = LCData.OnlineHostState;

            hostComs[(int)e.HostType].SendS1F2OnLineData(send);
        }
        private void ProcessS1F2OnLineData(HostEventArgs e)
        {
            S1F2OnLineData recv = (S1F2OnLineData)e.HsmsMsg;

            if (e.HostType == eHostType.Host)
            {
                S6F11EqEvent send = new S6F11EqEvent();
                send.DataID = 0;
                send.CEID = eCEID.ChangeToOnLineRemoteMode;

                switch (LCData.OnlineHostState)
                {
                    case eMCMD.REMOTE: send.CEID = eCEID.ChangeToOnLineRemoteMode; break;
                    case eMCMD.LOCAL: send.CEID = eCEID.ChangeToOnLineLocalMode; break;
                }

                send.ModuleID = LCData.Modules[0].ID;
                send.MCMD = LCData.OnlineHostState;
                send.ByWho = eByWho.ByEquipment;
                send.OperID = LCData.Modules[0].ID;
                send.ChangeEqStateModuleID = "";
                send.ChangeProcStateModuleID = "";
                send.LimitTime = "";
                send.RCode = "";

                hostComs[(int)eHostType.Host].SendS6F11EqEvent(send);
            }
        }
        private void ProcessS1F5FormattedStateRequest(HostEventArgs e)
        {
            S1F5FormattedStateRequest recv = (S1F5FormattedStateRequest)e.HsmsMsg;

            bool notSupport = false;
            switch (recv.SFCD)
            {
                case eSFCD.EquipmentOnlineParameter://SFCD = 1, EQUIPMENT ONLINE PARAMETER
                    {
                        S1F6EqOnlineParameter send = new S1F6EqOnlineParameter();
                        send.ModuleID = recv.ModuleID;
                        send.SFCD = recv.SFCD;

                        if (send.ModuleID != LCData.Modules[0].ID)
                        {
                            send.TMACK = eTMACK.ModuleIDNotExist;
                        }
                        else
                        {
                            send.TMACK = eTMACK.ACK;
                            send.EqOnlineParams = LCData.EqOnlineParams;
                        }
                        hostComs[(int)e.HostType].SendS1F6EqOnlineParameter(send);
                    }
                    break;
                case eSFCD.PortStates: //SFCD = 2, PORT STATES
                    {

                        S1F6PortState send = new S1F6PortState();
                        send.ModuleID = recv.ModuleID;
                        send.SFCD = recv.SFCD;


                        ModuleData findModule = LCData.FindModule(recv.ModuleID);
                        if (findModule == null)
                        {
                            send.TMACK = eTMACK.ModuleIDNotExist;
                        }
                        else
                        {
                            send.TMACK = eTMACK.ACK;

                            foreach (BatchManager batchInfo in LCData.BatchManagers)
                            {
                                send.PortObjects.Add(batchInfo.PortDatas[0].Port);
                                send.PortObjects.Add(batchInfo.PortDatas[1].Port);      
                            }                            
                        }
                        hostComs[(int)e.HostType].SendS1F6PortState(send);
                    }
                    break;
                case eSFCD.GlassTracking://SFCD = 3, GLASS TRACKING
                    {
                        S1F6GlassTracking send = new S1F6GlassTracking();
                        send.SFCD = recv.SFCD;

                        ModuleData findModule = LCData.FindModule(recv.ModuleID);
                        if (findModule == null)
                        {
                            ModuleData module = new ModuleData();
                            module.ID = recv.ModuleID;
                            send.Modules.Add(module);
                            send.TMACK = eTMACK.ModuleIDNotExist;
                        }
                        else
                        {
                            if (findModule.Layer == LCData.ModuleLayer) 
                                send.IsUnit = true;
                            foreach (ModuleData module in LCData.Modules)
                            {
                                if (module.ID.Contains(recv.ModuleID) && (module.Layer == LCData.ModuleLayer))
                                {
                                    BatchManager BatchInfo = LCData.FindBatch(module.ID, module.UnitID, true);
                                    if (BatchInfo != null)
                                    {
                                        send.IsPort = true;

                                        int selectPort = (int.Parse(module.UnitID.Substring(6, 1)) - 1) % 2;

                                        GlassData GlassData = new GlassData();
                                        //GlassData.HPanelID = "";
                                        //GlassData.EPanelID = "";
                                        //GlassData.SlotID = "";
                                        GlassData.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                                        GlassData.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                                        GlassData.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                                        GlassData.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                                        GlassData.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                                        GlassData.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                                        GlassData.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                                        GlassData.FlowID = (BatchInfo.PortDatas[selectPort].Cassette != null && BatchInfo.PortDatas[selectPort].Cassette.GlassDatas.Count > 0) ? BatchInfo.PortDatas[selectPort].Cassette.GlassDatas[0].FlowID : "";
                                        GlassData.PanelSize.Add(25000);
                                        GlassData.PanelSize.Add(22000);
                                        GlassData.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                                        GlassData.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                                        GlassData.PanelOtherProp1.PanelState = ePanelState.Processing;//fixed
                                        //GlassData.PanelOtherProp1.ReadingFlag = "";
                                        //GlassData.PanelOtherProp1.InsFlag = "";
                                        //GlassData.PanelOtherProp1.PanelPosition = "";
                                        GlassData.PanelOtherProp1.Judgement = "OK";//fixed
                                        //GlassData.PanelOtherProp1.Code = "";

                                        for (int j = 0; j < 28; j++)
                                            GlassData.PanelOtherProp1.FlowHistorys.Add(0);

                                        for (int j = 0; j < 4; j++)
                                            GlassData.PanelOtherProp1.UniqueID.Add(0);

                                        //GlassData.PanelOtherProp2.Count1 = "";
                                        //GlassData.PanelOtherProp2.Count2 = "";
                                        GlassData.PanelOtherProp2.Grade = "0".PadLeft(64, '0');
                                        //GlassData.PanelOtherProp2.MultiUse = "";
                                        GlassData.PanelOtherProp2.BitSignal = "0".PadLeft(32, '0');
                                        GlassData.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                                        GlassData.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";
                                        GlassData.PanelPairProp.PairProductID = (BatchInfo.PortDatas[selectPort].Cassette != null && BatchInfo.PortDatas[selectPort].Cassette.GlassDatas.Count > 0) ? BatchInfo.PortDatas[selectPort].Cassette.GlassDatas[0].PanelPairProp.PairProductID : "";
                                        GlassData.PanelPairProp.PairGrade = "0".PadLeft(64, '0');

                                        if (BatchInfo.PortDatas[selectPort].Cassette != null && BatchInfo.PortDatas[selectPort].Cassette.GlassDatas.Count > 0)
                                        {
                                            GlassData.FlowGroups = BatchInfo.PortDatas[selectPort].Cassette.GlassDatas[0].FlowGroups;
                                        }
                                        else
                                        {
                                            for (int i = 0; i < 10; i++)
                                            {
                                                FlowGroupData flowgrps = new FlowGroupData();
                                                for (int j = 0; j < 16; j++)
                                                    flowgrps.FlowList.Add(false);

                                                flowgrps.Binary = flowgrps.StringList;
                                                GlassData.FlowGroups.Add(flowgrps);
                                            }
                                        }
                                        GlassData.DBRRecipe = "0";
                                        GlassData.Refer = "0";

                                        module.Glass = GlassData;
                                    }
                                    send.Modules.Add(module);
                                }
                            }
                            send.TMACK = eTMACK.ACK;
                        }
                        hostComs[(int)e.HostType].SendS1F6GlassTracking(send);
                        hostComs[(int)eHostType.Monitor].SendS1F6GlassTracking(send);
                    }
                    break;

                case eSFCD.ModuleStates://SFCD = 4, MODULE STATES
                    {
                        S1F6ModuleStates send = new S1F6ModuleStates();
                        send.ModuleID = recv.ModuleID;
                        send.SFCD = recv.SFCD;
                        send.TMACK = eTMACK.ACK;

                        if (LCData.FindModule(send.ModuleID) == null)
                        {
                            send.TMACK = eTMACK.ModuleIDNotExist;
                        }
                        else
                        {
                            send.Modules.Add(LCData.FindModule(send.ModuleID));
                        }

                        hostComs[(int)e.HostType].SendS1F6ModuleStates(send);
                    }
                    break;

                case eSFCD.FlowControlTableRequest://SFCD = 9, FLOW CONTROL TABLE REQUEST
                    {
                        S1F6FlowControlTableRequest send = new S1F6FlowControlTableRequest();
                        send.ModuleID = recv.ModuleID;
                        send.SFCD = recv.SFCD;
                        send.TMACK = eTMACK.ACK;
                        send.EqState = LCData.Modules[0].EqState;
                        send.ProcState = LCData.Modules[0].ProcState;
                        send.MCMD = LCData.OnlineHostState;

                        if (send.ModuleID != LCData.Modules[0].ID)
                        {
                            send.TMACK = eTMACK.ModuleIDNotExist;
                        }
                        else
                        {
                            for (int workID = 0; workID < 16; workID++)
                            {
                                FlowControlTable flowControlTable = new FlowControlTable();
                                for (int workGroup = 0; workGroup < 4; workGroup++)
                                {
                                    foreach (FlowGroupData flowGroup in LCData.FlowGroups)
                                    {
                                        if (Convert.ToInt32(flowGroup.WorkID, 2) == workID &&
                                            Convert.ToInt32(flowGroup.WorkGroup, 2) == workGroup)
                                        {
                                            string binWorkID = Convert.ToString(workID, 2).PadLeft(4, '0');

                                            flowControlTable.WorkerIDs = flowGroup.BoolListWorkID;
                                            flowControlTable.EqpType = LCData.GetMapping2(eMappingType.WorkID, binWorkID);

                                            WorkGroupTable workGroupTable = new WorkGroupTable();
                                            workGroupTable.WorkerGroup = flowGroup.BoolListWorkGroup;
                                            workGroupTable.Worker1 = LCData.GetMapping(eMappingType.WorkerID, binWorkID, (workGroup * 8) + 1);
                                            workGroupTable.Worker2 = LCData.GetMapping(eMappingType.WorkerID, binWorkID, (workGroup * 8) + 2);
                                            workGroupTable.Worker3 = LCData.GetMapping(eMappingType.WorkerID, binWorkID, (workGroup * 8) + 3);
                                            workGroupTable.Worker4 = LCData.GetMapping(eMappingType.WorkerID, binWorkID, (workGroup * 8) + 4);
                                            workGroupTable.Worker5 = LCData.GetMapping(eMappingType.WorkerID, binWorkID, (workGroup * 8) + 5);
                                            workGroupTable.Worker6 = LCData.GetMapping(eMappingType.WorkerID, binWorkID, (workGroup * 8) + 6);
                                            workGroupTable.Worker7 = LCData.GetMapping(eMappingType.WorkerID, binWorkID, (workGroup * 8) + 7);
                                            workGroupTable.Worker8 = LCData.GetMapping(eMappingType.WorkerID, binWorkID, (workGroup * 8) + 8);
                                            flowControlTable.WorkGroupTables.Add(workGroupTable);
                                            break;
                                        }
                                    }
                                }
                                if (flowControlTable.WorkGroupTables.Count > 0)
                                {
                                    send.FlowControls.Add(flowControlTable);
                                }
                            }

                            hostComs[(int)e.HostType].SendS1F6FlowControlTableRequest(send);
                        }
                    }
                    break;

                case eSFCD.LoadRejectParameter://SFCD = 54, LOAD REJECT PARAMETER
                    {
                        S1F6LoadRejectParameter send = new S1F6LoadRejectParameter();
                        send.ModuleID = recv.ModuleID;
                        send.SFCD = recv.SFCD;

                        if (LCData.FindModule(send.ModuleID) == null)
                        {
                            send.TMACK = eTMACK.ModuleIDNotExist;
                        }
                        else
                        {
                            send.TMACK = eTMACK.ACK;
                            send.LoadRejectParams = LCData.LoadRejectParams;
                        }

                        hostComs[(int)e.HostType].SendS1F6LoadRejectParameter(send);
                    }
                    break;

                default:
                    {
                        notSupport = true;
                    }
                    break;
            }

            if (notSupport)
            {
                S1F6EqOnlineParameter send = new S1F6EqOnlineParameter();
                send.ModuleID = recv.ModuleID;
                send.SFCD = recv.SFCD;
                send.TMACK = eTMACK.SFCDNotSupported;

                hostComs[(int)e.HostType].SendS1F6EqOnlineParameter(send);
            }
        }
        private void ProcessS1F17RequestOnLine(HostEventArgs e)
        {
            S1F17RequestOnLine recv = (S1F17RequestOnLine)e.HsmsMsg;
            S1F18OnLineAck send = new S1F18OnLineAck();

            send.ModuleID = recv.ModuleID;
            send.TMACK = eTMACK.ACK;

            if (e.HostType != eHostType.Host)
            {
                send.TMACK = eTMACK.CommandNotSupported;
            }
            else if (send.ModuleID != LCData.Modules[0].ID)
            {
                send.TMACK = eTMACK.ModuleIDNotExist;
            }
            else
            {
                if (recv.OnlineMode != eMCMD.REMOTE && recv.OnlineMode != eMCMD.LOCAL)
                {
                    send.TMACK = eTMACK.ModeNotSupport;
                }
                else
                {
                    if (LCData.OnlineHostState == recv.OnlineMode)
                    {
                        send.TMACK = eTMACK.AlreadyRequiredState;
                    }                    
                }
            }

            hostComs[(int)e.HostType].SendS1F18OnLineAck(send);

            if (send.TMACK == eTMACK.ACK)
            {
                S6F11EqEvent send2 = new S6F11EqEvent();
                send2.DataID = 0;
                LCData.OnlineHostState = recv.OnlineMode;//추가

                switch (LCData.OnlineHostState)
                {
                    case eMCMD.REMOTE: send2.CEID = eCEID.ChangeToOnLineRemoteMode; break;
                    case eMCMD.LOCAL: send2.CEID = eCEID.ChangeToOnLineLocalMode; break;
                }

                send2.ModuleID = LCData.Modules[0].ID;
                send2.MCMD = LCData.OnlineHostState;
                send2.ByWho = eByWho.ByHost;
                send2.OperID = "";
                send2.ChangeEqStateModuleID = "";
                send2.ChangeProcStateModuleID = "";
                send2.LimitTime = "";
                send2.RCode = "";

                hostComs[(int)e.HostType].SendS6F11EqEvent(send2);
                stateControl1.UpdateDisplay();

                foreach (BatchManager BatchInfo in LCData.BatchManagers)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        portInputForm.UpdateOnlineMode(BatchInfo.PortDatas[i].Port.PortNo);
                    }
                }
            }
        }
        private void ProcessS2F31DateTimeSetRequest(HostEventArgs e)
        {
            S2F31DateTimeSetRequest recv = (S2F31DateTimeSetRequest)e.HsmsMsg;
            S2F32DateTimeSetAck send = new S2F32DateTimeSetAck();

            if (e.HostType != eHostType.Host)
            {
                send.TMACK = eTMACK.CommandNotSupported;
            }
            else
            {
                send.TMACK = eTMACK.ACK;
                try
                {
                    bool result = TimeManager.SetTime(short.Parse(recv.Time.Substring(0, 4)),
                                                    short.Parse(recv.Time.Substring(4, 2)),
                                                    short.Parse(recv.Time.Substring(6, 2)),
                                                    short.Parse(recv.Time.Substring(8, 2)),
                                                    short.Parse(recv.Time.Substring(10, 2)),
                                                    short.Parse(recv.Time.Substring(12, 2)));
                    if (!result) send.TMACK = eTMACK.ContentsIsNotUnderstood;
                }
                catch
                {
                    send.TMACK = eTMACK.ContentsIsNotUnderstood;
                }
            }

            hostComs[(int)e.HostType].SendS2F32DateTimeSetAck(send);

            if (send.TMACK == eTMACK.ACK)
            {
                //EqPlc로 전송부분
                C1DateTimeSetCmd cmd = new C1DateTimeSetCmd();
                cmd.Target.SrcEq = "LC";
                cmd.Target.SrcUnit = "N/A";
                cmd.Target.DesEq = "PLC1";
                cmd.Target.DesUnit = "N/A";
                cmd.DataTime = recv.Time;

                eqComs[(int)eEqType.EQPLC1].SendC1DateTimeSetCmd(cmd);

           }
        }
        private void ProcessS2F41JobStartCommand(HostEventArgs e)
        {     
            S2F41ProcessCommand recv = (S2F41ProcessCommand)e.HsmsMsg;
            S2F42ProcessCommandReply send = new S2F42ProcessCommandReply();

            send.RCMD = recv.RCMD;
            send.TMACK = (short)eNACK.ACK;

            send.IPID = recv.IPID;
            send.IPID_CPACK = (short)ePMACK.ACK;
            send.ICID = recv.ICID;
            send.ICID_CPACK = (short)ePMACK.ACK;
            send.OCID = recv.OCID;
            send.OCID_CPACK = (short)ePMACK.ACK;
            send.STIF = recv.STIF;
            send.STIF_CPACK = (short)ePMACK.ACK;
            send.ORDER = "ORDER";
            LogInfoData logInfo = null;

            int PortNo = int.Parse(recv.IPID.Substring(recv.IPID.Length - 1, 1));
            BatchManager BatchInfo = LCData.FindBatch(PortNo);
            if (BatchInfo != null)
            {
                logInfo = LCData.FindLogInfo((short)eLogType.HOST_START_CMD);
                if (logInfo != null)
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, recv.IPID, recv.ICID), BatchInfo.TARGET_LINE);

                BatchInfo.EVENT_PORT = PortNo;

                jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].Init((short)BatchInfo.TARGET_LINE);//NACK 발생 창 초기화

                if (send.TMACK == (short)eNACK.ACK)
                {
                    //온라인 모드가 Remote 모드인지..
                    if (LCData.OnlineHostState != eMCMD.REMOTE)
                        send.TMACK = (short)eNACK.NotRemote;
                }  

                //Port State가 Wait 상태인지..
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Wait)
                    send.TMACK = (short)eNACK.NotWaitState;
                             
                if (send.TMACK == (short)eNACK.ACK)
                {
                    //현재 Port 에 Cassette 가 존재 하는지, 
                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                    {
                        // 진행하려는 CassetteID가 Port내 CassetteID와 동일하고, Cassette 안에 Glass들에 대한 정보가 존재하는지..(하나 이상) 
                        if ((BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.CstID == recv.ICID) && (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas.Count > 0))
                        {
                            send.TMACK = (short)eNACK.ACK;
                        }
                        else
                        {
                            send.ICID_CPACK = (short)ePMACK.IllegalValue;
                            send.TMACK = (short)eNACK.NoExistGlass;                            
                        }
                    }
                    else
                    {
                        send.ICID_CPACK = (short)ePMACK.IllegalValue;
                        send.TMACK = (short)eNACK.NoExistGlass;
                    }
                }                         

                if (send.TMACK == (short)eNACK.ACK)
                {
                    //투입계획이 존재 하는지..
                    if (BatchInfo.BatchDatas.Count > 0)
                    {
                        //투입계획 order 1번의 BatchID 와 Cassette Glass 정보의 BatchID와 동일한지..
                        if (BatchInfo.BatchDatas[0].BATCHID != BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].BatchID)
                        {
                            send.TMACK = (short)eNACK.BatchIDFail;
                            jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.BatchIDFail, true);
                            jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
                        }
                        else
                        {
                            send.TMACK = (short)eNACK.ACK;
                            jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.BatchIDFail, false);
                        }
                    }
                    else
                    {
                        send.TMACK = (short)eNACK.BatchIDFail;
                        jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.BatchIDFail, true);
                        jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
                    }
                }

                if (send.TMACK == (short)eNACK.ACK)
                {
                    //Glass Type 체크 여부..
                    if (LCData.FindParamTypeCheck())
                    {
                        //Glass 정보의 PairProductID의 길이가 5이상 되고, Glass 정보의 PairProductID의 앞에서 6자리가 투입계획 Order1번의 P_Maker에 속하는지..
                        if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].PanelPairProp.PairProductID.Length > 5 &&
                            BatchInfo.BatchDatas[0].P_MAKER.Contains(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].PanelPairProp.PairProductID.Substring(0, 6)))
                        {
                            send.TMACK = (short)eNACK.ACK;
                            jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.PMakerMismatch, false);
                        }
                        else
                        {
                            send.TMACK = (short)eNACK.PMakerMismatch;
                            jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.PMakerMismatch, true);
                            jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
                        }
                    }
                }

                if (send.TMACK == (short)eNACK.ACK)
                {
                    if (null == LCData.GetFlowRecipe(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowID))
                    {
                        send.TMACK = (short)eNACK.FlowIDMismatch;
                        jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.FlowIDMismatch, true);
                        jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
                    }
                    else
                    {
                        jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.FlowIDMismatch, false);
                    }
                }

                if (send.TMACK == (short)eNACK.ACK)
                {
                    if (!LCData.IsFlowGroupInterlock(BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowGroups))
                    {
                        send.TMACK = (short)eNACK.FlowGroupMismatch;
                        jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.FlowGroupMismatch, true);
                        jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
                    }
                    else
                    {
                        jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.FlowGroupMismatch, false);
                    }
                }
            }
            else
            {
                send.IPID_CPACK = (short)ePMACK.IllegalValue;
                send.TMACK = (short)eNACK.PortIDFail;
            }
            hostComs[(int)e.HostType].SendS2F42ProcessCmdReply(send);//Host로부터 수신된 Job Start Command에 대한 Reply

            logInfo = LCData.FindLogInfo((short)eLogType.START_CMD_ACK, send.TMACK);
            if (logInfo != null)
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, recv.IPID, recv.ICID), BatchInfo.TARGET_LINE);
          
            //PLC에 전달
            if (send.TMACK ==  (short)eNACK.ACK)
            {                
                ProcessJobStartCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByHost, eLogType.PC_START_NORMAL);
                jobStartNACKForms[(short)BatchInfo.TARGET_LINE - 1].Hide();
            }
        }
        private void ProcessS2F41JobCancelCommand(HostEventArgs e)
        {
            S2F41ProcessCommand recv = (S2F41ProcessCommand)e.HsmsMsg;
            S2F42ProcessCommandReply send = new S2F42ProcessCommandReply();

            send.RCMD = recv.RCMD;
            send.TMACK = (short)eNACK.ACK;
            send.IPID = recv.IPID;
            send.IPID_CPACK = (short)ePMACK.ACK;
            send.ICID = recv.ICID;
            send.ICID_CPACK = (short)ePMACK.ACK;
            send.OCID = recv.OCID;
            send.OCID_CPACK = (short)ePMACK.ACK;
            send.STIF = recv.STIF;
            send.STIF_CPACK = (short)ePMACK.ACK;
            send.ORDER = "ORDER";
            LogInfoData logInfo = null;

            int PortNo = int.Parse(recv.IPID.Substring(recv.IPID.Length - 1, 1));
            BatchManager BatchInfo= LCData.FindBatch(PortNo);
            if (BatchInfo != null)
            {
                logInfo = LCData.FindLogInfo((short)eLogType.HOST_CANCEL_CMD);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, recv.IPID, recv.ICID), BatchInfo.TARGET_LINE);
                }
                BatchInfo.EVENT_PORT = PortNo;
                if (send.TMACK == (short)eNACK.ACK)
                {
                    if (LCData.OnlineHostState != eMCMD.REMOTE)
                        send.TMACK = (short)eNACK.NotRemote;
                }

                if (send.TMACK == (short)eNACK.ACK)
                {
                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Wait && BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Idle &&
                        BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Ready && BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Reserve)
                        send.TMACK = (short)eNACK.NotPortState;
                }
            }
            else
            {
                send.IPID_CPACK = (short)ePMACK.IllegalValue;
                send.TMACK = (short)eNACK.PortIDFail;
            }
            hostComs[(int)e.HostType].SendS2F42ProcessCmdReply(send);

            logInfo = LCData.FindLogInfo((short)eLogType.CANCEL_CMD_ACK, send.TMACK);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, recv.IPID, recv.ICID), BatchInfo.TARGET_LINE);
            }

            if (send.TMACK == (short)eNACK.ACK)
            {
                ProcessJobCancelCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByHost, eLogType.PC_CANCEL_NORMAL);
            }
        }
        private void ProcessS2F41JobAbortCommand(HostEventArgs e)
        {
            S2F41ProcessCommand recv = (S2F41ProcessCommand)e.HsmsMsg;
            S2F42ProcessCommandReply send = new S2F42ProcessCommandReply();

            send.RCMD = recv.RCMD;
            send.TMACK = (short)eNACK.ACK;
            send.IPID = recv.IPID;
            send.IPID_CPACK = (short)ePMACK.ACK;
            send.ICID = recv.ICID;
            send.ICID_CPACK = (short)ePMACK.ACK;
            send.OCID = recv.OCID;
            send.OCID_CPACK = (short)ePMACK.ACK;
            send.STIF = recv.STIF;
            send.STIF_CPACK = (short)ePMACK.ACK;
            send.ORDER = "ORDER";
            LogInfoData logInfo = null;

            int PortNo = int.Parse(recv.IPID.Substring(recv.IPID.Length - 1, 1));
            BatchManager BatchInfo= LCData.FindBatch(PortNo);
            if (BatchInfo != null)
            {
                logInfo = LCData.FindLogInfo((short)eLogType.HOST_ABORT_CMD);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, recv.IPID, recv.ICID), BatchInfo.TARGET_LINE);
                }

                BatchInfo.EVENT_PORT = PortNo;
                if (send.TMACK == (short)eNACK.ACK)
                {
                    if (LCData.OnlineHostState != eMCMD.REMOTE)
                        send.TMACK = (short)eNACK.NotRemote;
                }

                if (send.TMACK == (short)eNACK.ACK)
                {
                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Busy)
                        send.TMACK = (short)eNACK.NotPortState;
                }
            }
            else
            {
                send.IPID_CPACK = (short)ePMACK.IllegalValue;
                send.TMACK = (short)eNACK.PortIDFail;
            }           
            hostComs[(int)e.HostType].SendS2F42ProcessCmdReply(send);

            logInfo = LCData.FindLogInfo((short)eLogType.ABORT_CMD_ACK, send.TMACK);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, recv.IPID, recv.ICID), BatchInfo.TARGET_LINE);
            }

            if (send.TMACK == (short)eNACK.ACK)
                ProcessJobAbortCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByHost, eLogType.PC_ABORT_NORMAL);
        }
        private void ProcessS2F41PortCommand(HostEventArgs e)
        {
            S2F41PortCommand recv = (S2F41PortCommand)e.HsmsMsg;
            S2F42PortCommandReply send = new S2F42PortCommandReply();

            send.RCMD = recv.RCMD;
            send.TMACK = (short)eTMACK.ACK;

            if (LCData.OnlineHostState != eMCMD.REMOTE)
            {
                send.TMACK = (short)eNACK.NotRemote;
            }

            int j = 0, PortNo = 0;
            send.Ports = new S2F42PortCommandReply.PortReply[recv.PTIDs.Length];

            for (int i = 0; i < recv.PTIDs.Length; i++)
            {
                send.Ports[i] = new S2F42PortCommandReply.PortReply();

                PortNo = int.Parse(recv.PTIDs[i].Substring(recv.PTIDs[i].Length - 1, 1));
                BatchManager BatchInfo = LCData.FindBatch(PortNo);
                if (BatchInfo != null)
                {
                    BatchInfo.EVENT_PORT = PortNo;

                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Complete &&
                        BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Abort &&
                        BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Cancel)
                    {
                        send.Ports[j].PortID = recv.PTIDs[i];
                        send.Ports[j].CPACK = (short)ePMACK.StateError;

                        if (send.TMACK == (short)eNACK.ACK)
                        {
                            send.TMACK = (short)eNACK.NotPortState;
                        }
                        j++;
                    }
                    else
                    {
                        send.Ports[j].PortID = recv.PTIDs[i];
                        send.Ports[j].CPACK = (short)ePMACK.ACK;
                        j++;
                    }
                }
                else
                {
                    send.Ports[j].PortID = recv.PTIDs[i];
                    send.Ports[j].CPACK = (short)ePMACK.IllegalValue;
                    if (send.TMACK == (short)eNACK.ACK)
                    {
                        send.TMACK = (short)eNACK.PortIDFail;
                    }
                }

                if (send.TMACK == (short)eTMACK.ACK)
                {
                    for (int k = 0; k < send.Ports.Length; k++)
                    {
                        PortNo = int.Parse(send.Ports[k].PortID.Substring(send.Ports[k].PortID.Length - 1, 1));
                        BatchManager BatchInfoPC = LCData.FindBatch(PortNo);
                        if (BatchInfo != null)
                        {
                            BatchInfoPC.EVENT_PORT = PortNo;
                            ProcessReloadCommand(BatchInfoPC.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByHost, eLogType.PC_RELOAD_NORMAL);
                        }
                    }
                }
            }
            hostComs[(int)e.HostType].SendS2F42PortCmdReply(send);
        }
        private void ProcessS2F41EqCommand(HostEventArgs e)
        {
            S2F41EqCommand recv = (S2F41EqCommand)e.HsmsMsg;
            S2F42EqCommandReply send = new S2F42EqCommandReply();

            send.RCMD = recv.RCMD;
            send.TMACK = eTMACK.ACK;
            send.EqModules = recv.EqModules;
            foreach (EqModuleData eqModule in send.EqModules)
            {
                ModuleData module = LCData.FindModule(eqModule.ModuleID);
                if (e.HostType != eHostType.Host)
                {
                    send.TMACK = eTMACK.CommandNotSupported;
                }
                else if (module == null || module.ID != LCData.Modules[0].ID)
                {
                    eqModule.ModuleID_PMACK = ePMACK.IllegalValue;
                    send.TMACK = eTMACK.ModuleIDNotExist;
                }               
                else
                {
                    if (send.RCMD == eRCMD.EquipmentProcessStatePause)/*51*/
                    {
                        eqModule.RCode_PMACK = ePMACK.ACK;
                        if (module.ProcState == eProcState.PAUSE)
                        {
                            eqModule.ModuleID_PMACK = ePMACK.IllegalValue;
                            send.TMACK = eTMACK.ParameterNotExist;
                        }
                        else
                        {
                            eqModule.ModuleID_PMACK = ePMACK.ACK;
                            //SetMessage("Host에서 " + eqModule.ModuleID + "의 ProcessState값을 Pause상태로 변경하였습니다.", true);
                        }
                    }
                    else if (send.RCMD == eRCMD.EqProcessStateResume)/*52*/
                    {
                        eqModule.RCode_PMACK = ePMACK.ACK;
                        if (module.ProcState != eProcState.PAUSE)
                        {
                            eqModule.ModuleID_PMACK = ePMACK.IllegalValue;
                            send.TMACK = eTMACK.ParameterNotExist;
                        }
                        else
                        {
                            eqModule.ModuleID_PMACK = ePMACK.ACK;
                            //SetMessage("Host에서 " + eqModule.ModuleID + "의 ProcessState값을 Resume상태로 변경하였습니다.", true);
                        }
                    }
                    else if (send.RCMD == eRCMD.EqStateChangeToPM)/*53*/
                    {
                        eqModule.RCode_PMACK = ePMACK.ACK;
                        if (module.EqState == eEqState.PM)
                        {
                            eqModule.ModuleID_PMACK = ePMACK.IllegalValue;
                            send.TMACK = eTMACK.ParameterNotExist;
                        }
                        else
                        {
                            eqModule.ModuleID_PMACK = ePMACK.ACK;
                            //SetMessage("Host에서 " + eqModule.ModuleID + "의 EqState값을 PM상태로 변경하였습니다.", true);
                        }
                    }
                    else if (send.RCMD == eRCMD.EqStateChangeToNormal)/*54*/
                    {
                        eqModule.RCode_PMACK = ePMACK.ACK;
                        if (module.EqState == eEqState.NORMAL)
                        {
                            eqModule.ModuleID_PMACK = ePMACK.IllegalValue;
                            send.TMACK = eTMACK.ParameterNotExist;
                        }
                        else
                        {
                            eqModule.ModuleID_PMACK = ePMACK.ACK;
                            //SetMessage("Host에서 " + eqModule.ModuleID + "의 EqState값을 Normal상태로 변경하였습니다.", true);
                        }
                    }
                    else
                    {
                        eqModule.ModuleID_PMACK = ePMACK.IllegalValue;
                        eqModule.RCode_PMACK = ePMACK.IllegalValue;
                        send.TMACK = eTMACK.CommandNotSupported;
                    }
                }
            }
            hostComs[(int)e.HostType].SendS2F42EqCommandReply(send);

            if (send.TMACK == eTMACK.ACK)
            {
                foreach (EqModuleData eqModule in send.EqModules)
                {
                    //EqPLC전송부분
                    C2EquipmentCmd cmd = new C2EquipmentCmd();
                    cmd.Target.SrcEq = "LC";
                    cmd.Target.SrcUnit = "N/A";
                    cmd.Target.DesEq = "PLC1";
                    cmd.Target.DesUnit = "N/A";

                    cmd.Command = send.RCMD;
                    cmd.Code = eqModule.RCode;
                    cmd.ByWho = eByWho.ByHost;

                    eqComs[(int)eEqType.EQPLC1].SendC2EquipmentCmd(cmd);
                }
            }

        }
        private void ProcessS2F103EqOnlineParameterChange(HostEventArgs e)
        {
            S2F103EqOnlineParameterChange recv = (S2F103EqOnlineParameterChange)e.HsmsMsg;
            S2F104EqOnlineParameterAck send = new S2F104EqOnlineParameterAck();

            send.ModuleID = recv.ModuleID;
            send.TMACK = eTMACK.ACK;
            send.EqOnlineParams = recv.EqOnlineParams;

            if (e.HostType != eHostType.Host)
            {
                send.TMACK = eTMACK.CommandNotSupported;
            }
            else if (send.ModuleID != LCData.Modules[0].ID)
            {
                send.TMACK = eTMACK.ModuleIDNotExist;
            }
            else
            {
                foreach (EqOnlineParamData eo in send.EqOnlineParams)
                {
                    foreach (EqOnlineParamMode mode in eo.Modes)
                    {
                        //동일값 체크
                        if (LCData.GetEqOnlineParam(eo.EOID, mode.EOMD) == mode.EOV)
                        {
                            mode.PMACK = ePMACK.IllegalValue;
                            send.TMACK = eTMACK.AlreadyRequiredState;
                        }
                        //EOID=1   EOMD=1
                        else if (eo.EOID == 1 && mode.EOMD == "1")
                        {
                            if (1 > mode.EOV || mode.EOV > 2)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=1   EOMD=2
                        else if (eo.EOID == 1 && mode.EOMD == "2")
                        {
                            if (1 > mode.EOV || mode.EOV > 2)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=2   EOMD=0
                        else if (eo.EOID == 2 && mode.EOMD == "0")
                        {
                            if (0 > mode.EOV || mode.EOV > 2)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=3   EOMD=0
                        else if (eo.EOID == 3 && mode.EOMD == "0")
                        {
                            if (0 > mode.EOV || mode.EOV > 2)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=4   EOMD=1
                        else if (eo.EOID == 4 && mode.EOMD == "1")
                        {
                            if (0 > mode.EOV || mode.EOV > 99)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=4   EOMD=2
                        else if (eo.EOID == 4 && mode.EOMD == "2")
                        {
                            if (0 > mode.EOV || mode.EOV > 99)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=4   EOMD=3
                        else if (eo.EOID == 4 && mode.EOMD == "3")
                        {
                            if (0 > mode.EOV || mode.EOV > 99)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=4   EOMD=4
                        else if (eo.EOID == 4 && mode.EOMD == "4")
                        {
                            if (0 > mode.EOV || mode.EOV > 99)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=4   EOMD=5
                        else if (eo.EOID == 4 && mode.EOMD == "5")
                        {
                            if (0 > mode.EOV || mode.EOV > 99)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }
                        //EOID=4   EOMD=6
                        else if (eo.EOID == 4 && mode.EOMD == "6")
                        {
                            if (0 > mode.EOV || mode.EOV > 99)
                            {
                                mode.PMACK = ePMACK.IllegalValue;
                                send.TMACK = eTMACK.ValueOutofRange;
                            }
                            else
                            {
                                mode.PMACK = ePMACK.ACK;
                            }
                        }

                        #region EOID = 15,16 사용 안함.
                        ////EOID=15   EOMD=1
                        //else if (eo.EOID == 15 && mode.EOMD == "1")
                        //{
                        //    if (LCData.CCSType == eCCSType.PIXEL1 || LCData.CCSType == eCCSType.DEPO || LCData.CCSType == eCCSType.ETCH1 || LCData.CCSType == eCCSType.ETCH2)
                        //    {
                        //        if (0 > mode.EOV || mode.EOV > 2)
                        //        {
                        //            mode.PMACK = ePMACK.IllegalValue;
                        //            send.TMACK = eTMACK.ValueOutofRange;
                        //        }
                        //        else
                        //        {
                        //            mode.PMACK = ePMACK.ACK;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mode.PMACK = ePMACK.IllegalValue;
                        //        send.TMACK = eTMACK.ParameterNotExist;
                        //    }
                        //}
                        ////EOID=15   EOMD=2
                        //else if (eo.EOID == 15 && mode.EOMD == "2")
                        //{
                        //    if (LCData.CCSType == eCCSType.PIXEL1 || LCData.CCSType == eCCSType.DEPO)
                        //    {
                        //        if (0 > mode.EOV || mode.EOV > 2)
                        //        {
                        //            mode.PMACK = ePMACK.IllegalValue;
                        //            send.TMACK = eTMACK.ValueOutofRange;
                        //        }
                        //        else
                        //        {
                        //            mode.PMACK = ePMACK.ACK;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mode.PMACK = ePMACK.IllegalValue;
                        //        send.TMACK = eTMACK.ParameterNotExist;
                        //    }
                        //}
                        ////EOID=15   EOMD=3
                        //else if (eo.EOID == 15 && mode.EOMD == "3")
                        //{
                        //    if (LCData.CCSType == eCCSType.PIXEL1)
                        //    {
                        //        if (0 > mode.EOV || mode.EOV > 2)
                        //        {
                        //            mode.PMACK = ePMACK.IllegalValue;
                        //            send.TMACK = eTMACK.ValueOutofRange;
                        //        }
                        //        else
                        //        {
                        //            mode.PMACK = ePMACK.ACK;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mode.PMACK = ePMACK.IllegalValue;
                        //        send.TMACK = eTMACK.ParameterNotExist;
                        //    }
                        //}
                        //////EOID=15   EOMD=4
                        ////else if (eo.EOID == 15 && mode.EOMD == "4")
                        ////{
                        ////    if (LCData.CCSType == eCCSType.DEPO)
                        ////    {
                        ////        if (0 > mode.EOV || mode.EOV > 2)
                        ////        {
                        ////            mode.PMACK = ePMACK.IllegalValue;
                        ////            send.TMACK = eTMACK.ValueOutofRange;
                        ////        }
                        ////        else
                        ////        {
                        ////            mode.PMACK = ePMACK.ACK;
                        ////        }
                        ////    }
                        ////    else
                        ////    {
                        ////        mode.PMACK = ePMACK.IllegalValue;
                        ////        send.TMACK = eTMACK.ParameterNotExist;
                        ////    }
                        ////}
                        //////EOID=15   EOMD=5
                        ////else if (eo.EOID == 15 && mode.EOMD == "5")
                        ////{
                        ////    if (LCData.CCSType == eCCSType.DEPO)
                        ////    {
                        ////        if (0 > mode.EOV || mode.EOV > 2)
                        ////        {
                        ////            mode.PMACK = ePMACK.IllegalValue;
                        ////            send.TMACK = eTMACK.ValueOutofRange;
                        ////        }
                        ////        else
                        ////        {
                        ////            mode.PMACK = ePMACK.ACK;
                        ////        }
                        ////    }
                        ////    else
                        ////    {
                        ////        mode.PMACK = ePMACK.IllegalValue;
                        ////        send.TMACK = eTMACK.ParameterNotExist;
                        ////    }
                        ////}
                        ////EOID=16   EOMD=1
                        //else if (eo.EOID == 16 && mode.EOMD == "1")
                        //{
                        //    if (LCData.CCSType == eCCSType.PIXEL1 || LCData.CCSType == eCCSType.DEPO || LCData.CCSType == eCCSType.ETCH1 || LCData.CCSType == eCCSType.ETCH2)
                        //    {
                        //        if (0 > mode.EOV || mode.EOV > 255)
                        //        {
                        //            mode.PMACK = ePMACK.IllegalValue;
                        //            send.TMACK = eTMACK.ValueOutofRange;
                        //        }
                        //        else
                        //        {
                        //            mode.PMACK = ePMACK.ACK;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mode.PMACK = ePMACK.IllegalValue;
                        //        send.TMACK = eTMACK.ParameterNotExist;
                        //    }
                        //}
                        ////EOID=16   EOMD=2
                        //else if (eo.EOID == 16 && mode.EOMD == "2")
                        //{
                        //    if (LCData.CCSType == eCCSType.PIXEL1 || LCData.CCSType == eCCSType.DEPO)
                        //    {
                        //        if (0 > mode.EOV || mode.EOV > 255)
                        //        {
                        //            mode.PMACK = ePMACK.IllegalValue;
                        //            send.TMACK = eTMACK.ValueOutofRange;
                        //        }
                        //        else
                        //        {
                        //            mode.PMACK = ePMACK.ACK;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mode.PMACK = ePMACK.IllegalValue;
                        //        send.TMACK = eTMACK.ParameterNotExist;
                        //    }
                        //}
                        ////EOID=16   EOMD=3
                        //else if (eo.EOID == 16 && mode.EOMD == "3")
                        //{
                        //    if (LCData.CCSType == eCCSType.PIXEL1)
                        //    {
                        //        if (0 > mode.EOV || mode.EOV > 255)
                        //        {
                        //            mode.PMACK = ePMACK.IllegalValue;
                        //            send.TMACK = eTMACK.ValueOutofRange;
                        //        }
                        //        else
                        //        {
                        //            mode.PMACK = ePMACK.ACK;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mode.PMACK = ePMACK.IllegalValue;
                        //        send.TMACK = eTMACK.ParameterNotExist;
                        //    }
                        //}
                        ////EOID=16   EOMD=4
                        //else if (eo.EOID == 16 && mode.EOMD == "4")
                        //{
                        //    if (LCData.CCSType == eCCSType.DEPO)
                        //    {
                        //        if (0 > mode.EOV || mode.EOV > 255)
                        //        {
                        //            mode.PMACK = ePMACK.IllegalValue;
                        //            send.TMACK = eTMACK.ValueOutofRange;
                        //        }
                        //        else
                        //        {
                        //            mode.PMACK = ePMACK.ACK;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mode.PMACK = ePMACK.IllegalValue;
                        //        send.TMACK = eTMACK.ParameterNotExist;
                        //    }
                        //}
                        ////EOID=16   EOMD=5
                        //else if (eo.EOID == 16 && mode.EOMD == "5")
                        //{
                        //    if (LCData.CCSType == eCCSType.DEPO)
                        //    {
                        //        if (0 > mode.EOV || mode.EOV > 255)
                        //        {
                        //            mode.PMACK = ePMACK.IllegalValue;
                        //            send.TMACK = eTMACK.ValueOutofRange;
                        //        }
                        //        else
                        //        {
                        //            mode.PMACK = ePMACK.ACK;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        mode.PMACK = ePMACK.IllegalValue;
                        //        send.TMACK = eTMACK.ParameterNotExist;
                        //    }
                        //}
                        #endregion
                        else
                        {
                            mode.PMACK = ePMACK.IllegalValue;
                            send.TMACK = eTMACK.ParameterNotExist;
                        }
                    }
                }
            }

            if (send.TMACK == eTMACK.ACK)
            {
                foreach (EqOnlineParamData eo in send.EqOnlineParams)
                {
                    foreach (EqOnlineParamMode mode in eo.Modes)
                    {
                        LCData.SetEqOnlineParam(eo.EOID, mode.EOMD, mode.EOV);
                    }
                }
            }
            hostComs[(int)e.HostType].SendS2F104EqOnlineParameterAck(send);

            if (send.TMACK == eTMACK.ACK)
            {
                S6F11EqParameterEvent send2 = new S6F11EqParameterEvent();
                send2.DataID = 0;
                send2.CEID = eCEID.ParameterChangedEOID;
                send2.ModuleID = LCData.Modules[0].ID;
                send2.MCMD = LCData.OnlineHostState;
                send2.EqState = LCData.Modules[0].EqState;
                send2.ProcState = LCData.Modules[0].ProcState;
                send2.ByWho = eByWho.ByHost;
                send2.OperID = LCData.Modules[0].ID;
                send2.EqOnlineParams = send.EqOnlineParams;
                hostComs[(int)e.HostType].SendS6F11EqParameterEvent(send2);

                LCData.ChangeEqOnlineParamByWho = eByWho.ByHost;
                sqlManager.SetEqOnlineParams(LCData.EqOnlineParams);
            }
        }        
        private void ProcessS3F101CassetteInfo(HostEventArgs e)
        {
            S3F101CassetteInfo recv = (S3F101CassetteInfo)e.HsmsMsg;
            S3F102CassetteInfoReply send = new S3F102CassetteInfoReply();

            hostComs[(int)eHostType.Monitor].SendS3F101CassetteInfo(recv);

            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;

                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState != ePortState.Wait)
                {
                   switch(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState)
                   {
                       case ePortState.Reserve:
                       case ePortState.Busy: send.TMACK = eNACK.PortStateReservedOrBusy; break;
                       case ePortState.Empty: send.TMACK = eNACK.PortEmpty; break;
                       default: send.TMACK = eNACK.PortStateFail;
                           break;
                   }
                }
                else if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID != recv.Cassette.CstID)
                    send.TMACK = eNACK.CstIDFail;
                else if ((30 == LCData.GetMappingCount(recv.Cassette.MapStif)) || (30 == LCData.GetMappingCount(recv.Cassette.CurStif)))
                    send.TMACK = eNACK.CassetteSlotInfoFail;
                else if ((BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.MapStif != LCData.GetMappingCount(recv.Cassette.MapStif).ToString()) ||
                         (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif != LCData.GetMappingCount(recv.Cassette.CurStif).ToString()))
                {
                   EqConstantData InputModeinfo = LCData.GetEqConstant(1);
                            
                   switch(int.Parse(InputModeinfo.ECDEF))
                   {
                       case 1: send.TMACK = eNACK.CassetteSlotInfoFail; break;
                       case 2:
                           {
                               BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.MapStif = LCData.GetMappingCount(recv.Cassette.MapStif).ToString();
                               BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif = LCData.GetMappingCount(recv.Cassette.CurStif).ToString();
                           }
                           break;
                       case 3:
                           {
                               BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.MapStif = "20";
                               BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif = "20";
                           }
                           break;
                   }           
                }
                else if (BatchInfo.BatchDatas.Count < 1)
                    send.TMACK = eNACK.BatchPlanNotExist;
                else if (BatchInfo.BatchDatas[0].BATCHID != recv.Cassette.GlassDatas[0].BatchID)
                    send.TMACK = eNACK.BatchIDFail;
                else if (LCData.FindParamTypeCheck())
                {
                    if (recv.Cassette.GlassDatas[0].PanelPairProp.PairProductID.Length > 5)
                    {
                        if (!BatchInfo.BatchDatas[0].P_MAKER.Contains(recv.Cassette.GlassDatas[0].PanelPairProp.PairProductID.Substring(0, 6)))
                            send.TMACK = eNACK.PairProductIDFail;
                    }
                    else
                    {
                        send.TMACK = eNACK.PairProductIDFail;
                    }
                }
                else if (null == LCData.GetFlowRecipe(recv.Cassette.GlassDatas[0].FlowID))
                    send.TMACK = eNACK.FlowIDFail;
                else if (!LCData.IsFlowGroupInterlock(BatchInfo.TARGET_LINE, recv.Cassette.GlassDatas[0].FlowID, recv.Cassette.GlassDatas[0].FlowGroups))
                {
                    send.TMACK = eNACK.FlowGroupFail;
                }
            }
            else
            {
                send.TMACK = eNACK.PortNumFail;
            }

            hostComs[(int)e.HostType].SendS3F102CassetteInfoReply(send);

            cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].Init((short)BatchInfo.TARGET_LINE);

            bool check = false;


            if (send.TMACK == eNACK.BatchIDFail)
            {
                check = true;
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.BatchIDFail, true);
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
            }
            else 
            {
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.BatchIDFail, false);
            }

            if (send.TMACK == eNACK.PairProductIDFail)
            {
                check = true;
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.PairProductIDFail, true);
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
            }
            else if (!check)
            {
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.PairProductIDFail, false);
            }

            if (send.TMACK == eNACK.FlowIDFail)
            {
                check = true;
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.FlowIDFail, true);
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
            }
            else if (!check)
            {
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.FlowIDFail, false);
            }

            if (send.TMACK == eNACK.FlowGroupFail)
            {
                check = true;
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.FlowGroupFail, true);
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].Show();
            }
            else if (!check)
            {
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, (short)eNACK.FlowGroupFail, false);
            }

            foreach (FlowGroupData grp in recv.Cassette.GlassDatas[0].FlowGroups)
            {
                recv.Cassette.GlassDatas[0].FlowGroupName += grp.WORKID_NAME + grp.WORKER_NAME;
                recv.Cassette.GlassDatas[0].FlowGroupName += " ";
            }
            recv.Cassette.GlassDatas[0].FlowGroupName = recv.Cassette.GlassDatas[0].FlowGroupName.Trim();

            BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = null;
            BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = recv.Cassette;

            portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
            portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);

            if (send.TMACK == eNACK.ACK)
            {
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].Init((short)BatchInfo.TARGET_LINE);
                cstNACKForms[(short)BatchInfo.TARGET_LINE - 1].Hide();

                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.CST_DOWNLOAD_ACK);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, recv.Cassette.CstID, recv.Cassette.GlassDatas[0].BatchID, recv.Cassette.GlassDatas[0].FlowID,
                        recv.Cassette.GlassDatas[0].FlowGroupName, recv.Cassette.GlassDatas[0].PanelPairProp.PairProductID), BatchInfo.TARGET_LINE);
                }
            }
            else
            {
                send.NACK_TYPE = (short)send.TMACK;
                LogInfoData logInfo = LCData.FindLogInfo(send.NACK_TYPE);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, recv.Cassette.CstID, recv.Cassette.GlassDatas[0].BatchID), BatchInfo.TARGET_LINE);
                }
            }          
        }
        private void ProcessS3F103ProdPlanInfo(HostEventArgs e)
        {
            S3F103ProductionPlanInfo recv = (S3F103ProductionPlanInfo)e.HsmsMsg;
            S3F104ProductionPlanInfoReply send = new S3F104ProductionPlanInfoReply();

            send.ModuleID = recv.ModuleID;
            send.PLCD = recv.PLCD;       
            send.TMACK = eNACK.ACK;
            LogInfoData logInfo = null;

            BatchManager BatchInfo = LCData.FindBatch(recv.ModuleID);
            if (BatchInfo != null)
            {
                batchNackForms[(short)BatchInfo.TARGET_LINE - 1].Init((short)BatchInfo.TARGET_LINE);
                if (send.TMACK == eNACK.ACK)
                {
                    if (send.PLCD != ePLCD.ProductPlanCreate)
                    {
                        send.TMACK = eNACK.PLCDNotExist;                        
                    }
                }

                if (send.TMACK == eNACK.ACK)
                {
                    foreach (BatchObject BatchObj1 in recv.BatchDatas)
                    {
                        foreach (BatchObject BatchObj2 in recv.BatchDatas)
                        {
                            if (!BatchObj1.Equals(BatchObj2) && (BatchObj1.ORDER_NO == BatchObj2.ORDER_NO))
                            {
                                send.TMACK = eNACK.DuplicateOrderNo;
                                break;
                            }

                            if (!BatchObj1.Equals(BatchObj2) && (BatchObj1.F_PANELID == BatchObj2.F_PANELID))
                            {
                                send.TMACK = eNACK.DuplicateFPanelID;
                                break;
                            }
                        }
                    }
                }
                //order1의 생산계획 정보가 틀린 경우,
                if (BatchInfo.BatchDatas.Count != 0)
                {
                    if (send.TMACK == eNACK.ACK)
                    {
                        //현재 Busy인 투입 계획과 다운로드 받은 투입계획이 F_PanelId가 다른 경우...
                        if ((BatchInfo.BatchDatas.Count > 0) && (recv.BatchDatas.Count > 0) &&
                             (BatchInfo.BatchDatas[0].BATCH_STATE == eBatchtState.Busy) &&
                             (BatchInfo.BatchDatas[0].F_PANELID != recv.BatchDatas[0].F_PANELID))
                        {
                            send.TMACK = eNACK.DiffrentPlanInfo;
                            batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DiffrentPlanInfo, true);
                            batchNackForms[(short)BatchInfo.TARGET_LINE - 1].Show();
                        }
                        else
                        {
                            batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DiffrentPlanInfo, false);
                        }
                    }
                }
                          
                //중복 Glass ID 중복 체크.단, 현재 GlassID가 현재 진행중인 FPanelID이면 중복 처리 안함.               
                if (send.TMACK == eNACK.ACK)
                {
                    foreach (BatchObject BatchObj in recv.BatchDatas)
                    {
                        if (BatchObj.F_PANELID == "" || BatchObj.PROCESSID == "" || BatchObj.PRODUCTID == "" || BatchObj.STEPID == "" ||
                            BatchObj.BATCHID == "" || BatchObj.PPID == "" || BatchObj.P_THICKNESS == 0 || BatchObj.P_MAKER == "" ||
                            BatchObj.PROD_TYPE == "" || BatchObj.PROD_KIND == "")
                        {
                            if (BatchObj.PPID == "")
                            {
                                 batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.ItemNotExist, true);
                                 batchNackForms[(short)BatchInfo.TARGET_LINE - 1].Show();                              
                            }

                            send.TMACK = eNACK.ItemNotExist;                            
                            break;
                        }
                        else 
                        {
                            batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.ItemNotExist, false);
                        }

                        if (IsDuplicateBatch(BatchObj.F_PANELID))
                        {
                            send.TMACK = eNACK.DuplicatePlanInfo;
                            batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DuplicatePlanInfo, true);
                            batchNackForms[(short)BatchInfo.TARGET_LINE - 1].Show();     
                            break;
                        }
                        else
                        {
                            batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DuplicatePlanInfo, false);
                        }
                        if (BatchInfo.BatchDatas.Count != 0)
                        {
                            if (BatchObj.ORDER_NO != 1 || BatchInfo.BatchDatas[0].BATCH_STATE != eBatchtState.Busy
                                || BatchInfo.BatchDatas[0].F_PANELID != BatchObj.F_PANELID)
                            {
                                if ((IsDuplicateGlassID(BatchObj.F_PANELID) && (!BatchObj.GlassIDLists.Contains(BatchObj.F_PANELID))))
                                {
                                    send.TMACK = eNACK.DuplicateGlassID;
                                    batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DuplicateGlassID, true);
                                    batchNackForms[(short)BatchInfo.TARGET_LINE - 1].Show();
                                    break;
                                }
                                else
                                {
                                    batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DuplicateGlassID, false);
                                }
                            }
                            else
                            {
                                batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DuplicateGlassID, false);
                            }
                        }
                        else
                        {
                            if ((IsDuplicateGlassID(BatchObj.F_PANELID) && (!BatchObj.GlassIDLists.Contains(BatchObj.F_PANELID))))
                            {
                                send.TMACK = eNACK.DuplicateGlassID;
                                batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DuplicateGlassID, true);
                                batchNackForms[(short)BatchInfo.TARGET_LINE - 1].Show();
                                break;
                            }
                            else
                            {
                                batchNackForms[(short)BatchInfo.TARGET_LINE - 1].UpdateDisplay((short)BatchInfo.TARGET_LINE, (short)eNACK.DuplicateGlassID, false);
                            }
                        }
                    }                   
                }
            }
            else
            {
                send.TMACK = eNACK.ModuleIDNotExist;                
            }

            hostComs[(int)e.HostType].SendS3F104ProdPlanInfoReply(send);

            if (send.TMACK == eNACK.ACK)
            {
                batchNackForms[(short)BatchInfo.TARGET_LINE - 1].Hide();

                int i = 0;

                if (BatchInfo.BatchDatas.Count > 0)
                {
                    if (BatchInfo.BatchDatas[0].BATCH_STATE == eBatchtState.Busy)
                    {
                        if (recv.BatchDatas.Count > 0)
                        {
                            logInfo = LCData.FindLogInfo((short)eLogType.BATCH_DOWNLOAD_ACK);

                            BatchInfo.BatchDatas.RemoveRange(1, BatchInfo.BatchDatas.Count - 1);

                            foreach (BatchObject BatchObj in recv.BatchDatas)
                            {
                                if (BatchObj.ORDER_NO == 1)
                                {
                                    ++i;
                                }
                                else
                                {
                                    BatchObj.ORDER_NO = ++i;
                                    BatchObj.END_PANELID = LCData.GetCreatePanelID(BatchObj.BATCH_SIZE - 1, BatchObj.BATCHID, BatchObj.F_PANELID);
                                    BatchInfo.BatchDatas.Add(BatchObj);
                                }

                                if (logInfo != null)
                                {
                                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchObj.ORDER_NO, BatchObj.PRODUCTID, BatchObj.BATCHID,
                                        BatchObj.F_PANELID, BatchObj.BATCH_SIZE, BatchObj.P_MAKER), BatchInfo.TARGET_LINE);
                                }
                            }
                        }
                    }
                    else  //BATCH BUSY가 아니라면
                    {
                        if (recv.BatchDatas.Count > 0)
                        {
                            logInfo = LCData.FindLogInfo((short)eLogType.BATCH_DOWNLOAD_ACK);

                            BatchInfo.BatchDatas.RemoveRange(0, BatchInfo.BatchDatas.Count);

                            foreach (BatchObject BatchObj in recv.BatchDatas)
                            {
                                BatchObj.ORDER_NO = ++i;
                                BatchObj.END_PANELID = LCData.GetCreatePanelID(BatchObj.BATCH_SIZE - 1, BatchObj.BATCHID, BatchObj.F_PANELID);
                                BatchInfo.BatchDatas.Add(BatchObj);

                                if (logInfo != null)
                                {
                                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchObj.ORDER_NO, BatchObj.PRODUCTID, BatchObj.BATCHID,
                                        BatchObj.F_PANELID, BatchObj.BATCH_SIZE, BatchObj.P_MAKER), BatchInfo.TARGET_LINE);
                                }

                                if (BatchObj.ORDER_NO == 1) LCData.SaveBatCh(BatchInfo.TARGET_LINE, BatchObj);
                            }
                        }
                        else
                        {
                            BatchInfo.BatchDatas.RemoveRange(0, BatchInfo.BatchDatas.Count);
                            logInfo = LCData.FindLogInfo((short)eLogType.BATCH_DELETE_ACK);
                            if (logInfo != null)
                            {
                                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.TARGET_MODULEID), BatchInfo.TARGET_LINE);
                            }
                        }
                    }
                }
                else
                {
                    if (recv.BatchDatas.Count > 0)
                    {
                        logInfo = LCData.FindLogInfo((short)eLogType.BATCH_DOWNLOAD_ACK);

                        foreach (BatchObject BatchObj in recv.BatchDatas)
                        {
                            BatchObj.ORDER_NO = ++i;
                            BatchObj.END_PANELID = LCData.GetCreatePanelID(BatchObj.BATCH_SIZE - 1, BatchObj.BATCHID, BatchObj.F_PANELID);
                            BatchInfo.BatchDatas.Add(BatchObj);

                            if (logInfo != null)
                            {
                                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchObj.ORDER_NO, BatchObj.PRODUCTID, BatchObj.BATCHID,
                                    BatchObj.F_PANELID, BatchObj.BATCH_SIZE, BatchObj.P_MAKER), BatchInfo.TARGET_LINE);
                            }

                            if (BatchObj.ORDER_NO == 1) LCData.SaveBatCh(BatchInfo.TARGET_LINE, BatchObj);
                        }
                    }
                    else
                    {
                        BatchInfo.BatchDatas.RemoveRange(0, BatchInfo.BatchDatas.Count);
                        logInfo = LCData.FindLogInfo((short)eLogType.BATCH_DELETE_ACK);
                        if (logInfo != null)
                        {
                            SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.TARGET_MODULEID), BatchInfo.TARGET_LINE);
                        }
                    }
                }

                for (int k = 0; k < 2; k++)
                {
                    portInputForm.DisplayView(BatchInfo.PortDatas[k].Port.PortNo);
                }
                batchDataControl1.UpdateDisplay(BatchInfo.TARGET_LINE);
            }
            else
            {
                logInfo = LCData.FindLogInfo((short)eLogType.BATCH_DOWNLOAD_ACK, (short)send.TMACK);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.TARGET_MODULEID, BatchInfo.TARGET_LINE), BatchInfo.TARGET_LINE);
                }
            }
        }
        private void ProcessS5F101WaitingResetAlarmsList(HostEventArgs e)
        {
            S5F101WaitingResetAlarmsList recv = (S5F101WaitingResetAlarmsList)e.HsmsMsg;
            S5F102WaitingResetAlarmsListAck send = new S5F102WaitingResetAlarmsListAck();

            send.ModuleID = recv.ModuleID;
            send.TMACK = eTMACK.ACK;

            if (send.ModuleID != LCData.Modules[0].ID)
            {
                send.TMACK = eTMACK.ModuleIDNotExist;
            }
            else
            {
                send.Alarms = LCData.Alarms;
            }

            hostComs[(int)e.HostType].SendS5F102WaitingResetAlarmsListAck(send);
        }
        private void ProcessS5F103SelectAlarmForcedResetRequest(HostEventArgs e)
        {
            S5F103SelectAlarmForcedResetRequest recv = (S5F103SelectAlarmForcedResetRequest)e.HsmsMsg;
            S5F104SelectAlarmForcedResetAck send = new S5F104SelectAlarmForcedResetAck();

            send.ModuleID = recv.ModuleID;
            send.TMACK = eTMACK.ACK;
            send.Alarms = recv.Alarms;

            if (e.HostType != eHostType.Host)
            {
                send.TMACK = eTMACK.CommandNotSupported;
            }
            else if (send.ModuleID != LCData.Modules[0].ID)
            {
                send.TMACK = eTMACK.ModuleIDNotExist;
            }
            else
            {
                if (send.Alarms.Count == 0) send.Alarms = LCData.Alarms;

                foreach (AlarmData alarm in send.Alarms)
                {
                    AlarmData resetAlarm = LCData.GetAlarm(alarm.ModuleID, alarm.ID);
                    if (resetAlarm == null)
                    {
                        alarm.PMACK = ePMACK.IllegalValue;
                        send.TMACK = eTMACK.PartialyPerform;
                    }
                    else
                    {
                        alarm.PMACK = ePMACK.CanNotPerform;
                        send.TMACK = eTMACK.PartialyPerform;
                    }
                }
            }
            hostComs[(int)e.HostType].SendS5F104SelectAlarmForcedResetAck(send);

            //S5F105 전송부분
            if (e.HostType == eHostType.Host)
            {
                S5F105CurrentEqAlarmlistReport send2 = new S5F105CurrentEqAlarmlistReport();
                send2.ModuleID = recv.ModuleID;
                send2.Alarms = LCData.Alarms;
                hostComs[(int)e.HostType].SendS5F105CurrentEqAlarmlistReport(send2);
                //-SetMessage("Host에서 AlarmReset 명령을 내렸습니다.", true);
            }
        }
        //private void ProcessS7F1ProcessProgramLoadInquire(HostEventArgs e)
        //{
        //    S7F2ProcessProgramLoadGrant send = new S7F2ProcessProgramLoadGrant();

        //    send.TMACK = eTMACK.CommandNotSupported;

        //    hostComs[(int)e.HostType].SendS7F2ProcessProgramLoadGrant(send);
        //}
        //private void ProcessS7F9RelatedMaterialIDRequestSpecialPPID(HostEventArgs e)
        //{
        //    S7F9RelatedMaterialIDRequestSpecialPPID recv = (S7F9RelatedMaterialIDRequestSpecialPPID)e.HsmsMsg;
        //    S7F10RelatedMaterialIDDataSpecialPPID send = new S7F10RelatedMaterialIDDataSpecialPPID();

        //    send.ModuleID = recv.ModuleID;
        //    send.TMACK = eTMACK.CommandNotSupported;

        //    hostComs[(int)e.HostType].SendS7F10RelatedMaterialIDDataSpecialPPID(send);
        //}
        private void ProcessS10F3TerminalDisplaySingle(HostEventArgs e)
        {
            if (e.HostType == eHostType.Host)
            {
                //System.Threading.Thread.Sleep(100);

                S10F3TerminalDisplaySingle recv = (S10F3TerminalDisplaySingle)e.HsmsMsg;

                C11MessageCmd cmd = new C11MessageCmd();
                cmd.Target.SrcEq = "LC";
                cmd.Target.SrcUnit = "N/A";
                cmd.Target.DesEq = "PLC1";
                cmd.Target.DesUnit = "N/A";
                cmd.Num = recv.TerminalID;
                cmd.OpCall = recv.Text;

                msgControl1.SetMessage(" " + recv.Text);

                eqComs[(int)eEqType.EQPLC1].SendC11MessageCmd(cmd);
                hostComs[(int)eHostType.Monitor].SendS10F3TerminalDisplaySinglea(recv);                          
            }
        }
        private void ProcessS10F9Broadcast(HostEventArgs e)
        {
            if (e.HostType == eHostType.Host)
            {
                S10F9Broadcast recv = (S10F9Broadcast)e.HsmsMsg;

                C11MessageCmd cmd = new C11MessageCmd();
                cmd.Target.SrcEq = "LC";
                cmd.Target.SrcUnit = "N/A";
                cmd.Target.DesEq = "PLC1";
                cmd.Target.DesUnit = "N/A";
                cmd.Terminal = recv.Text;

                eqComs[(int)eEqType.EQPLC1].SendC11MessageCmd(cmd);
                msgControl1.SetMessage(" " + recv.Text);
                SetTerminalMessage(recv.Text);
            }
        }        
        private bool SetEqState(ModuleData module, eEqState eqState, eByWho byWho, string PMCode)
        {
            eEqState oldEqState = module.EqState;
            if (module.Childs == null) module.EqState = eqState;
            else
            {
                //1:Normal   2:Fault   3:PM
                int[] states = new int[] { 0, 0, 0, 0 };
                foreach (ModuleData child in module.Childs)
                {
                    states[(int)child.EqState]++;
                }

                foreach (string state in LCData.EqStatePriority)
                {
                    if (state == eEqState.PM.ToString() && states[(int)eEqState.PM] > 0 && LCData.IsState(module.ID, state)) module.EqState = eEqState.PM;
                    else if (state == eEqState.FAULT.ToString() && states[(int)eEqState.FAULT] > 0 && LCData.IsState(module.ID, state)) module.EqState = eEqState.FAULT;
                    else if (state == eEqState.NORMAL.ToString() && states[(int)eEqState.NORMAL] > 0 && LCData.IsState(module.ID, state)) module.EqState = eEqState.NORMAL;
                    else continue;
                    break;
                }
            }
            eEqState nowEqState = module.EqState;

            if (oldEqState != nowEqState)
            {
                if (module.Parent == null)
                {
                    stateControl1.UpdateDisplay();
                }
                else
                {
                    SetEqState(module.Parent, eqState, byWho, PMCode);
                }

                int eqStateLayer = (int)LCData.GetEqOnlineParam(2, "0");
                if (module.Layer < eqStateLayer && eqState != eEqState.NotManage)
                {
                    //Host전송
                    S6F11EqEvent send = new S6F11EqEvent();
                    send.DataID = 0;
                    send.CEID = eCEID.EqStateChanged;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.ByWho = byWho;
                    send.OperID = LCData.Modules[0].ID;
                    send.ChangeEqStateModuleID = module.ID;
                    send.ChangeEqState = nowEqState;
                    send.ChangeProcStateModuleID = "";
                    send.Modules = LCData.Modules;
                    send.LimitTime = "";
                    if ((nowEqState == eEqState.PM) && (module.Layer == eqStateLayer - 1)) send.RCode = PMCode;
                    else send.RCode = "";

                    if (nowEqState == eEqState.FAULT)
                    {
                        for (int cnt = LCData.Alarms.Count - 1; cnt >= 0; cnt--)
                        {
                            if (LCData.Alarms[cnt].ModuleID.Contains(module.ID))
                            {
                                send.Alarms.Add(LCData.Alarms[cnt]);
                                break;
                            }
                        }
                    }

                    //foreach (HostCom hostCom in hostComs)
                    //{
                    //    hostCom.SendS6F11EqEvent(send);
                    //}
                    hostComs[(int)eHostType.Host].SendS6F11EqEvent(send);
                }

                return true;
            }

            return false;
        }
        private bool SetProcState(ModuleData module, eProcState procState, eByWho byWho, string PauseCode)
        {
            eProcState oldProcState = module.ProcState;
            if (module.Childs == null) module.ProcState = procState;
            else
            {
                //1:Init   2:Idle   3:Setup   4:Ready   5:Execute   6:Pause
                int[] states = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                foreach (ModuleData child in module.Childs)
                {
                    states[(int)child.ProcState]++;
                }

                foreach (string state in LCData.ProcStatePriority)
                {
                    if (state == eProcState.INIT.ToString() && states[(int)eProcState.INIT] > 0 && LCData.IsState(module.ID, state)) module.ProcState = eProcState.INIT;
                    else if (state == eProcState.IDLE.ToString() && states[(int)eProcState.IDLE] > 0 && LCData.IsState(module.ID, state)) module.ProcState = eProcState.IDLE;
                    else if (state == eProcState.SETUP.ToString() && states[(int)eProcState.SETUP] > 0 && LCData.IsState(module.ID, state)) module.ProcState = eProcState.SETUP;
                    else if (state == eProcState.READY.ToString() && states[(int)eProcState.READY] > 0 && LCData.IsState(module.ID, state)) module.ProcState = eProcState.READY;
                    else if (state == eProcState.EXECUTE.ToString() && states[(int)eProcState.EXECUTE] > 0 && LCData.IsState(module.ID, state)) module.ProcState = eProcState.EXECUTE;
                    else if (state == eProcState.PAUSE.ToString() && states[(int)eProcState.PAUSE] > 0 && LCData.IsState(module.ID, state)) module.ProcState = eProcState.PAUSE;
                    else continue;
                    break;
                }
            }
            eProcState nowProcState = module.ProcState;

            if (oldProcState != nowProcState)
            {
                if (module.Parent == null)
                {
                    module.KeepTime = 0;
                    stateControl1.UpdateDisplay();
                }
                else
                {
                    SetProcState(module.Parent, procState, byWho, PauseCode);
                }

                int procStateLayer = (int)LCData.GetEqOnlineParam(3, "0");
                if (module.Layer < procStateLayer && procState != eProcState.NotManage)
                {
                    if (nowProcState != eProcState.INIT && !(oldProcState == eProcState.SETUP && nowProcState == eProcState.READY))
                    {
                        S6F11EqEvent send = new S6F11EqEvent();
                        send.DataID = 0;
                        send.CEID = eCEID.EqProcessStateChanged;
                        send.ModuleID = LCData.Modules[0].ID;
                        send.MCMD = LCData.OnlineHostState;
                        send.ByWho = byWho;
                        send.OperID = LCData.Modules[0].ID;
                        send.ChangeEqStateModuleID = "";
                        send.ChangeProcStateModuleID = module.ID;
                        send.ChangeProcState = nowProcState;
                        send.Modules = LCData.Modules;
                        send.LimitTime = "";

                        if ((nowProcState == eProcState.PAUSE) && (module.Layer == procStateLayer - 1)) send.RCode = PauseCode;
                        else send.RCode = "";

                        //foreach (HostCom hostCom in hostComs)
                        //{
                        //    hostCom.SendS6F11EqEvent(send);
                        //}
                        hostComs[(int)eHostType.Host].SendS6F11EqEvent(send);
                    }
                }

                return true;
            }

            return false;
        }
        public void SetParameterInfo()
        {
            sqlManager.SetParameterInfo(LCData.Parameter);
        }
        public void SetFlowGroupInterlockInfo()
        {
            sqlManager.SetInterlockInfo(LCData.interlockDatas);
        }
        public void SetHistoryPeriodInfo()
        {
            sqlManager.SetHistoryPeriodInfo(LCData.HistoryPeriodSet);
        }
        public void SetLogColorSetInfo()
        {
            sqlManager.SetLogColorSetInfo(LCData.LogColorDataSet);
        }
        public int SetLogColorInfo()
        {
            return sqlManager.SetLogColorInfo(LCData.logColors);
        }
        private void ProcessEqConnect(EqEventArgs e)
        {
            lbStatus.Text = "CoreNet Connection Success";
        }
        private void ProcessEqDisconnect(EqEventArgs e)
        {
            lbStatus.Text = "CoreNet Disconnection Success";

            ProcessEqDisconnect();
        }
        private void ProcessEqConnect()
        {
            testTimer.Start();
            disconnectPLCForm.Hide();
            LCData.OnlinePLCState = eEIPCMD.ONLINE;

            //Host전송부분(자체 Alarm)
            R3ResetAlarmReport report = new R3ResetAlarmReport();
            report.Target.SrcEq = "PLC1";
            report.Target.SrcUnit = "MASTER";
            report.Target.DesEq = "LC";
            report.Target.DesUnit = "N/A";
            report.AlarmID = 400;
            report.AlarmSection = eAlarmSection.MASTER;
            ProcessR3ResetAlarmReport(new EqEventArgs(eEqEventType.R3ResetAlarmReport, eEqType.EQPLC1, report));

            ProcessC17WIPQTYInfoCommand();

            LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.PLC_CONNECT);
            if (logInfo != null)
            {
                foreach (BatchManager BatchInfo in LCData.BatchManagers)
                {
                    SetMessage(logInfo.SerialNo, logInfo.Comment, BatchInfo.TARGET_LINE);
                }
            }         
            stateControl1.UpdateDisplay();
            //초기화
            foreach (ModuleData module in LCData.Modules)
            {
                module.Glass = null;
            }
            //LCData.Alarms.Clear();
        }
        private void ProcessEqDisconnect()
        {
            testTimer.Stop();
            disconnectPLCForm.Show();
            LCData.OnlinePLCState = eEIPCMD.OFFLINE;

            //Host전송부분
            R2SetAlarmReport report = new R2SetAlarmReport();
            report.Target.SrcEq = "PLC1";
            report.Target.SrcUnit = "MASTER";
            report.Target.DesEq = "LC";
            report.Target.DesUnit = "N/A";
            report.AlarmID = 400;
            report.AlarmSection = eAlarmSection.MASTER;
            ProcessR2SetAlarmReport(new EqEventArgs(eEqEventType.R2SetAlarmReport, eEqType.EQPLC1, report));

            LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.PLC_DISCONNECT);
            if (logInfo != null)
            {
                foreach (BatchManager BatchInfo in LCData.BatchManagers)
                {
                    SetMessage(logInfo.SerialNo, logInfo.Comment, BatchInfo.TARGET_LINE);
                }
            }
            stateControl1.UpdateDisplay();            
        }
        private void ProcessR1TransferGlassDataReport(EqEventArgs e)
        {
            R1TransferGlassDataReport recv = (R1TransferGlassDataReport)e.XmlMsg;
            ModuleData module = LCData.FindModule(recv.Target.SrcEq, recv.Target.SrcUnit);
            if (module != null)
            {
                switch (recv.EventID)
                {
                    case eCEID.GlassInitial:
                        module.Glass = recv.Glass;
                        break;
                    case eCEID.GlassUnbroken:
                        {
                            LCData.RemoveGlass(recv.Glass.HPanelID);
                            module.Glass = recv.Glass;

                            int layer = LCData.GetEqOnlineParam(1, "1") - 1;
                            ModuleData parentModule = LCData.FindParentModule(module, layer);
                            S6F11PanelProcessEvent send = new S6F11PanelProcessEvent();
                            send.DataID = 0;
                            send.CEID = eCEID.GlassUnbroken;
                            send.ModuleID = parentModule.ID;
                            send.MCMD = LCData.OnlineHostState;
                            send.EqState = parentModule.EqState;
                            send.ProcState = parentModule.ProcState;
                            send.ByWho = eByWho.ByEquipment;
                            send.OperID = LCData.Modules[0].ID;
                            send.Glasses.Add(recv.Glass);
                            hostComs[(int)eHostType.Host].SendS6F11PanelProcessEvent(send);
                            hostComs[(int)eHostType.Monitor].SendS6F11PanelProcessEvent(send);
                        }
                        break;
                    case eCEID.PanelProcessStartForIndexer: 
                        {
                            module.Glass = recv.Glass;
                            BatchManager BatchInfo = LCData.FindBatch(module.EqID, module.UnitID);
                            if (BatchInfo != null)
                            {
                                BatchInfo.EVENT_PORT = int.Parse(module.UnitID.Substring(module.UnitID.Length - 1, 1));

                                if (module.Glass.HPanelID == LCData.GetCreatePanelID(BatchInfo.BatchDatas[0].O_QTY, BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID))
                                {
                                    int layer = LCData.GetEqOnlineParam(1, "1") - 1;
                                    ModuleData parentModule = LCData.FindParentModule(module, layer);

                                    if (BatchInfo.BatchDatas[0].F_PANELID == module.Glass.HPanelID ||
                                        BatchInfo.BatchDatas[0].GlassIDLists.Count == 0)                                                                           
                                    {
                                        ProcessBatchStartEvent(BatchInfo.TARGET_LINE, eByWho.ByEquipment);
                                    }      
                                    S6F11JobProcessEvent send = new S6F11JobProcessEvent();
                                    send.DataID = 0;
                                    send.ModuleID = parentModule.ID;
                                    send.MCMD = LCData.OnlineHostState;
                                    send.EqState = parentModule.EqState;
                                    send.ProcState = parentModule.ProcState;
                                    send.OperID = "";

                                    send.Port = (PortObject)BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.Clone();
                                    send.Port.PortEvent = eCEID.PanelProcessStartForIndexer;
                                    send.Port.ByWho = eByWho.ByEquipment;
                                    send.Port.CurStif = int.Parse(send.Port.CurStif) != 0 ? (int.Parse(send.Port.CurStif) - 1).ToString() : "0";
                                    send.Cassette.GlassDatas.Add(recv.Glass);

                                    hostComs[(int)eHostType.Host].SendS6F11JobProcessEvent(send);
                                    hostComs[(int)eHostType.Monitor].SendS6F11JobProcessEvent(send);

                                    
                                }
                                //if (LCData.OnlineHostState != eMCMD.OFFLINE)
                                //{
                                //    SetBatchGlass(module.Glass.HPanelID);
                                //}
                            }
                        }
                        break;
                    case eCEID.PanelProcessStartForModule: // Glass In
                        {
                            ModuleData oldModule = LCData.RemoveGlass(recv.Glass.HPanelID);
                            //Process State : Execute
                            if (module.EqState == eEqState.NORMAL && module.ProcState == eProcState.IDLE)
                            {
                                R4UnitStateReport report = new R4UnitStateReport();
                                report.Target.SrcEq = module.EqID;
                                report.Target.SrcUnit = module.UnitID;
                                report.Target.DesEq = "LC";
                                report.Target.DesUnit = "N/A";

                                report.EqByWho = eByWho.ByEquipment;
                                report.ProcByWho = eByWho.ByEquipment;
                                report.EqState = eEqState.NORMAL;
                                report.ProcState = eProcState.EXECUTE;

                                ProcessR4UnitStateReport(new EqEventArgs(eEqEventType.R4UnitStateReport, eEqType.EQPLC1, report));
                            }
                            //Idle
                            if (oldModule != null && module.ID != oldModule.ID)
                            {
                                if (oldModule.EqState == eEqState.NORMAL && oldModule.ProcState == eProcState.EXECUTE)
                                {
                                    R4UnitStateReport report = new R4UnitStateReport();
                                    report.Target.SrcEq = oldModule.EqID;
                                    report.Target.SrcUnit = oldModule.UnitID;
                                    report.Target.DesEq = "LC";
                                    report.Target.DesUnit = "N/A";

                                    report.EqByWho = eByWho.ByEquipment;
                                    report.ProcByWho = eByWho.ByEquipment;
                                    report.EqState = eEqState.NORMAL;
                                    report.ProcState = eProcState.IDLE;

                                    ProcessR4UnitStateReport(new EqEventArgs(eEqEventType.R4UnitStateReport, eEqType.EQPLC1, report));
                                }
                            }
                            //GlassIn
                            module.Glass = recv.Glass;
                            int layer = LCData.GetEqOnlineParam(1, "1") - 1;
                            ModuleData parentModule = LCData.FindParentModule(module, layer);

                            S6F11PanelProcessEvent Send = new S6F11PanelProcessEvent();
                            Send.DataID = 0;
                            Send.CEID = eCEID.PanelProcessStartForModule;
                            Send.ModuleID = parentModule.ID;
                            Send.MCMD = LCData.OnlineHostState;
                            Send.EqState = parentModule.EqState;
                            Send.ProcState = parentModule.ProcState;
                            Send.ByWho = eByWho.ByEquipment;
                            Send.OperID = "";                            

                            if (oldModule != null)
                                Send.FromModuleID = LCData.FindParentModule(oldModule, layer).ID;
                            else if (!string.IsNullOrEmpty(module.FromModuleID))
                                Send.FromModuleID = module.FromModuleID;

                            Send.Glasses.Add(recv.Glass);

                            if (LCData.IsTraceStart(oldModule, module))
                            {
                                hostComs[(int)eHostType.Host].SendS6F11PanelProcessEvent(Send);
                                hostComs[(int)eHostType.Monitor].SendS6F11PanelProcessEvent(Send);
                            }


                           // Batch Start 보고 & 이전에 보고 안된 glass & Batch End 확인 여부

                            //int index = 0;
                            //BatchManager BatchInfo2 = LCData.GetBatchGlass(module.Glass.HPanelID, ref index);
                            //if (BatchInfo2 != null)
                            //{                                
                            //    int count = 0;
                            //    foreach (BatchGlassData batchGlass in BatchInfo.BatchGlassIDs)
                            //    {
                            //        if (count <= index && batchGlass.Check == false)
                            //        {
                            //            if (count == 0)
                            //            {
                            //                //batch Start 미보고 에 대한 처리

                            //            }
                            //        }
                            //        count++;
                            //     }
                            //}


                            BatchManager BatchInfo = LCData.FindBatch(module.Glass.FromEqNo);
                            if (BatchInfo != null)
                            {                              
                                BatchInfo.BatchDatas[0].C_PANELID = module.Glass.HPanelID;
                                BatchInfo.BatchDatas[0].O_QTY++;
                                BatchInfo.BatchDatas[0].R_QTY = BatchInfo.BatchDatas[0].BATCH_SIZE - BatchInfo.BatchDatas[0].O_QTY;

                                SetGlassIDHistory(BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID, BatchInfo.BatchDatas[0].C_PANELID, module.Glass.PanelOtherProp1.UniqueID, (short)BatchInfo.TARGET_LINE);

                                BatchInfo.BatchDatas[0].GlassIDLists.Add(module.Glass.HPanelID);

                                batchDataControl1.UpdateDisplay(BatchInfo.TARGET_LINE);

                                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.GLASS_START_EVENT);
                                if (logInfo != null)
                                {                                   
                                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.BatchDatas[0].PRODUCTID, BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID, BatchInfo.BatchDatas[0].C_PANELID, BatchInfo.BatchDatas[0].O_QTY), BatchInfo.TARGET_LINE);
                                }

                                if (BatchInfo.BatchDatas[0].O_QTY >= BatchInfo.BatchDatas[0].BATCH_SIZE ||
                                    BatchInfo.BatchDatas[0].END_PANELID == module.Glass.HPanelID)
                                {
                                    ProcessBatchEndEvent(BatchInfo.TARGET_LINE, eByWho.ByEquipment);                                      
                                }                               
                            }

                            //if (LCData.OnlineHostState != eMCMD.OFFLINE)
                            //{
                            //    SetBatchGlass(module.Glass.HPanelID);
                            //}
                        }
                        break;
                }
                
            }
        }
        private void ProcessR2SetAlarmReport(EqEventArgs e)
        {
            R2SetAlarmReport recv = (R2SetAlarmReport)e.XmlMsg;
            

            ModuleData module = null;
            AlarmData alarmInfo = LCData.GetAlarmInfo(recv.AlarmSection, recv.Target.SrcEq, recv.AlarmID);

            if (recv.AlarmSection == eAlarmSection.MASTER || recv.AlarmSection == eAlarmSection.PIO)
            {
                if (alarmInfo != null) 
                    module = LCData.FindModule(alarmInfo.UnitID);
            }
            else
            {
                if (alarmInfo != null) 
                    module = LCData.FindModule(recv.Target.SrcEq, recv.Target.SrcUnit);
            }

            if (module != null)
            {
                AlarmData oldAlarm = LCData.GetAlarm(recv.Target.SrcEq, recv.Target.SrcUnit, recv.AlarmID);
                if (oldAlarm == null)
                {
                    AlarmData alarmData = new AlarmData();
                    alarmData.ModuleID = module.ID;
                    alarmData.Section = recv.AlarmSection;
                    if (module.EqID == "" || module.EqID == "-") alarmData.EqID = recv.Target.SrcEq;
                    else alarmData.EqID = module.EqID;
                    alarmData.UnitID = module.UnitID;
                    alarmData.ID = recv.AlarmID;
                    alarmData.Time = DateTime.Now.ToString("yyyyMMddHHmmss");
                    alarmData.Text = alarmInfo.Text;
                    alarmData.AlarmSet = eAlarmSet.Set;
                    alarmData.AlarmType = alarmInfo.AlarmType;
                    alarmData.AlarmReason = alarmInfo.AlarmReason;

                    LCData.Alarms.Insert(0, alarmData);

                    SetAlarmHistory(alarmData);

                    //Host전송부분
                    S5F1AlarmReportSend send = new S5F1AlarmReportSend();
                    S5F102WaitingResetAlarmsListAck sendAlarmList = new S5F102WaitingResetAlarmsListAck();
                    send.Alarm = alarmData;

                    sendAlarmList.ModuleID = module.ID;
                    sendAlarmList.TMACK = eTMACK.ACK;

                    if (sendAlarmList.ModuleID != LCData.Modules[0].ID)
                    {
                        sendAlarmList.TMACK = eTMACK.ModuleIDNotExist;
                    }
                    else
                    {
                        sendAlarmList.Alarms = LCData.Alarms;
                    }

                    //foreach (HostCom hostCom in hostComs)
                    //    hostCom.SendS5F1AlarmReportSend(send);
                    hostComs[(int)eHostType.Host].SendS5F1AlarmReportSend(send);
                    hostComs[(int)eHostType.Monitor].SendS5F102WaitingResetAlarmsListAck(sendAlarmList, eHostType.Monitor);
                }
            }
        }
        private void ProcessR3ResetAlarmReport(EqEventArgs e)
        {
           R3ResetAlarmReport recv = (R3ResetAlarmReport)e.XmlMsg;

            AlarmData alarmData = null;

            if (recv.AlarmSection == eAlarmSection.MASTER || recv.AlarmSection == eAlarmSection.PIO)
            {
                alarmData = LCData.GetAlarm(recv.AlarmSection, recv.Target.SrcEq, recv.AlarmID);
            }
            else
            {
                alarmData = LCData.GetAlarm(recv.Target.SrcEq, recv.Target.SrcUnit, recv.AlarmID);
            }

            if (alarmData != null)
            {
                alarmData.AlarmSet = eAlarmSet.Reset;
                LCData.Alarms.Remove(alarmData);
                alarmControl1.UpdateDisplay();

                SetAlarmHistory(alarmData);

                //Host전송부분
                S5F1AlarmReportSend send = new S5F1AlarmReportSend();
                S5F102WaitingResetAlarmsListAck sendAlarmList = new S5F102WaitingResetAlarmsListAck();
                send.Alarm = alarmData;
                sendAlarmList.ModuleID = alarmData.ModuleID;
                sendAlarmList.TMACK = eTMACK.ACK;

                if (sendAlarmList.ModuleID != LCData.Modules[0].ID)
                {
                    sendAlarmList.TMACK = eTMACK.ModuleIDNotExist;
                }
                else
                {
                    sendAlarmList.Alarms = LCData.Alarms;
                }

                //foreach (HostCom hostCom in hostComs)
                //    hostCom.SendS5F1AlarmReportSend(send);
                hostComs[(int)eHostType.Host].SendS5F1AlarmReportSend(send);
                hostComs[(int)eHostType.Monitor].SendS5F102WaitingResetAlarmsListAck(sendAlarmList, eHostType.Monitor);
            }                
        }
        private void ProcessR4UnitStateReport(EqEventArgs e)
        {
            R4UnitStateReport recv = (R4UnitStateReport)e.XmlMsg;

            ModuleData module = LCData.FindModule(recv.Target.SrcEq, recv.Target.SrcUnit);

            if (module != null)
            {
                bool isEqChange = SetEqState(module, recv.EqState, recv.EqByWho, recv.PMCode);
                bool isProcChange = SetProcState(module, recv.ProcState, recv.ProcByWho, recv.PauseCode);
            }
        }
        private void ProcessR5InitializeUnitStateReport(EqEventArgs e)
        {
            R5InitializeUnitStateReport recv = (R5InitializeUnitStateReport)e.XmlMsg;

            foreach (R4UnitStateReport unit in recv.Units)
            {
                ModuleData module = LCData.FindModule(recv.Target.SrcEq, unit.Target.SrcUnit);
                if (module != null)
                {
                    module.EqState = unit.EqState;
                    module.ProcState = unit.ProcState;
                }
            }

            foreach (ModuleData module in LCData.Modules)
            {
                if (module.Layer == (LCData.ModuleLayer - 1))
                {
                    SetEqState(module, eEqState.NotManage, eByWho.ByEquipment, "");
                    SetProcState(module, eProcState.NotManage, eByWho.ByEquipment, "");
                }
            }
        }
        private void ProcessR6GlassControlReport(EqEventArgs e)
        {
            R6GlassControlReport recv = (R6GlassControlReport)e.XmlMsg;

            switch (recv.EventID)
            {
                case eCEID.GlassBroken:
                    {
                        ModuleData nowModule = LCData.FindGlass(recv.HPanelID);

                        if (nowModule != null)
                        {
                            nowModule.Glass.PanelOtherProp1.Code = recv.BrokenCode;

                            //S6F11PanelProcessEvent 전송
                            int layer = LCData.GetEqOnlineParam(1, "1") - 1;
                            ModuleData parentModule = LCData.FindParentModule(nowModule, layer);

                            S6F11PanelProcessEvent send = new S6F11PanelProcessEvent();
                            send.DataID = 0;
                            send.CEID = eCEID.GlassBroken;
                            send.ModuleID = parentModule.ID;
                            send.MCMD = LCData.OnlineHostState;
                            send.EqState = parentModule.EqState;
                            send.ProcState = parentModule.ProcState;
                            send.ByWho = eByWho.ByEquipment;
                            send.OperID = LCData.Modules[0].ID;
                            send.Glasses.Add(nowModule.Glass);
                            hostComs[(int)eHostType.Host].SendS6F11PanelProcessEvent(send);
                            hostComs[(int)eHostType.Monitor].SendS6F11PanelProcessEvent(send);

                            nowModule.Glass = null;
                        }
                    }
                    break;

                case eCEID.PanelProcessEndForModule:
                    {
                        ModuleData nowModule = LCData.FindModule(recv.Target.SrcEq, recv.Target.SrcUnit);

                        if (nowModule != null && nowModule.Glass != null )//&& !string.IsNullOrEmpty(nowModule.ToModuleID))
                        {
                            //Idle
                            if (nowModule.EqState == eEqState.NORMAL && nowModule.ProcState == eProcState.EXECUTE)
                            {
                                R4UnitStateReport report = new R4UnitStateReport();
                                report.Target.SrcEq = nowModule.EqID;
                                report.Target.SrcUnit = nowModule.UnitID;
                                report.Target.DesEq = "LC";
                                report.Target.DesUnit = "N/A";

                                report.EqByWho = eByWho.ByEquipment;
                                report.ProcByWho = eByWho.ByEquipment;
                                report.EqState = eEqState.NORMAL;
                                report.ProcState = eProcState.IDLE;

                                ProcessR4UnitStateReport(new EqEventArgs(eEqEventType.R4UnitStateReport, eEqType.EQPLC1, report));
                            }

                            //S6F11PanelProcessEvent 전송
                            int layer = LCData.GetEqOnlineParam(1, "2") - 1;
                            ModuleData parentModule = LCData.FindParentModule(nowModule, layer);

                            S6F11PanelProcessEvent send = new S6F11PanelProcessEvent();
                            send.DataID = 0;
                            send.CEID = eCEID.PanelProcessEndForModule;
                            send.ModuleID = parentModule.ID;
                            send.MCMD = LCData.OnlineHostState;
                            send.EqState = parentModule.EqState;
                            send.ProcState = parentModule.ProcState;
                            send.ByWho = eByWho.ByEquipment;
                            send.OperID = LCData.Modules[0].ID;
                            send.ToModuleID = nowModule.ToModuleID;
                            send.Glasses.Add(nowModule.Glass);
                            if (parentModule.UnitID == "Unit#11" || parentModule.UnitID == "Unit#12" || parentModule.UnitID == "Unit#13")
                            {
                                hostComs[(int)eHostType.Monitor].SendS6F11PanelProcessEvent(send);
                            }
                            else
                            {
                                hostComs[(int)eHostType.Host].SendS6F11PanelProcessEvent(send);
                                hostComs[(int)eHostType.Monitor].SendS6F11PanelProcessEvent(send);
                            }                            
                            nowModule.Glass = null;
                         }
                    }
                    break;               
                default:
                    break;
            }
        }        
        private void ProcessR8InitializeAlarmReport(EqEventArgs e)
        {
            R8InitializeAlarmReport recv = (R8InitializeAlarmReport)e.XmlMsg;

            foreach (R2SetAlarmReport alarm in recv.Alarms)
            {
                ModuleData module = null;
                AlarmData alarmInfo = LCData.GetAlarmInfo(alarm.AlarmSection, recv.Target.SrcEq, alarm.AlarmID);

                if (alarm.AlarmSection == eAlarmSection.MASTER || alarm.AlarmSection == eAlarmSection.PIO)
                {
                    if (alarmInfo != null) module = LCData.FindModule(alarmInfo.UnitID);
                }
                else
                {
                    if (alarmInfo != null) module = LCData.FindModule(recv.Target.SrcEq, alarm.Target.SrcUnit);
                }

                if (module != null)
                {
                    AlarmData oldAlarm = LCData.GetAlarm(recv.Target.SrcEq, alarm.Target.SrcUnit, alarm.AlarmID);
                    if (oldAlarm == null)
                    {
                        AlarmData alarmData = new AlarmData();
                        alarmData.ModuleID = module.ID;
                        alarmData.Section = alarm.AlarmSection;
                        if (module.EqID == "" || module.EqID == "-") alarmData.EqID = recv.Target.SrcEq;
                        else alarmData.EqID = module.EqID;
                        alarmData.UnitID = module.UnitID;
                        alarmData.ID = alarm.AlarmID;
                        alarmData.Time = DateTime.Now.ToString("yyyyMMddHHmmss");
                        alarmData.Text = alarmInfo.Text;
                        alarmData.AlarmSet = eAlarmSet.Set;
                        alarmData.AlarmType = alarmInfo.AlarmType;
                        alarmData.AlarmReason = alarmInfo.AlarmReason;

                        LCData.Alarms.Insert(0, alarmData);
                    }
                }
            }
            // eqAlarmControl.UpdateDisplay();
        }       
        //EQ Event
        private void ProcessE12JobStartEvent(EqEventArgs e)
        {
            E12JobStartEvent recv = (E12JobStartEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                LogInfoData logInfo = null;
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    
                    S6F11JobProcessEvent send = new S6F11JobProcessEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.Port = recv.Port;

                    int MapStif = int.Parse(recv.Port.MapStif) > 20 ? 20 : int.Parse(recv.Port.MapStif);
                    int CurStif = int.Parse(recv.Port.CurStif) > 20 ? 20 : int.Parse(recv.Port.CurStif);
                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette == null || BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas.Count < 1)
                    {
                        for (int i = 0; i < CurStif; i++)
                        {
                            GlassData glass = new GlassData();
                            for (int k = 0; k < 10; k++)
                            {
                                FlowGroupData FlowGroup = new FlowGroupData();
                                List<bool> list = new List<bool>();
                                for (int l = 0; l < 16; l++)
                                    list.Add(false);
                                FlowGroup.FlowList = list;
                                FlowGroup.Binary = FlowGroup.StringList;
                                glass.FlowGroups.Add(FlowGroup);
                            }

                            glass.SlotID = LCData.GetSlotID(MapStif, CurStif, i);
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                            glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                            glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                            glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                            glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                            glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                            glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                            glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                            glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";
                            send.Cassette.GlassDatas.Add(glass);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < CurStif; i++)
                        {
                            GlassData glass = new GlassData();

                            glass.SlotID = LCData.GetSlotID(MapStif, CurStif, i);
                            glass.FlowID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowID;
                            glass.FlowGroups = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowGroups;
                            glass.PanelPairProp.PairProductID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].PanelPairProp.PairProductID;
                            glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                            glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                            glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                            glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                            glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                            glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                            glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                            glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                            glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";

                            send.Cassette.GlassDatas.Add(glass);
                        }
                    }
                    hostComs[(int)eHostType.Host].SendS6F11JobProcessEvent(send);
                    hostComs[(int)eHostType.Monitor].SendS6F11JobProcessEvent(send);

                    logInfo = LCData.FindLogInfo((short)eLogType.START_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }
                }
                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;

                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);

                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);

               
            }
        }
        private void ProcessE12JobCancelEvent(EqEventArgs e)
        {
            E12JobCancelEvent recv = (E12JobCancelEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11JobProcessEvent send = new S6F11JobProcessEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.Port = recv.Port;

                    int MapStif = int.Parse(recv.Port.MapStif) > 20 ? 20 : int.Parse(recv.Port.MapStif);
                    int CurStif = int.Parse(recv.Port.CurStif) > 20 ? 20 : int.Parse(recv.Port.CurStif);

                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette == null || BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas.Count < 1)
                    {
                        for (int i = 0; i < CurStif; i++)
                        {
                            GlassData glass = new GlassData();
                            for (int k = 0; k < 10; k++)
                            {
                                FlowGroupData FlowGroup = new FlowGroupData();
                                List<bool> list = new List<bool>();
                                for (int l = 0; l < 16; l++)
                                    list.Add(false);
                                FlowGroup.FlowList = list;
                                FlowGroup.Binary = FlowGroup.StringList;
                                glass.FlowGroups.Add(FlowGroup);
                            }

                            glass.SlotID = LCData.GetSlotID(MapStif, CurStif, i);
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                            glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                            glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                            glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                            glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                            glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                            glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                            glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                            glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";                           
                            send.Cassette.GlassDatas.Add(glass);                            
                        }                  
                    }
                    else
                    {
                        for (int i = 0; i < CurStif; i++)
                        {
                            GlassData glass = new GlassData();

                            glass.SlotID = LCData.GetSlotID(MapStif, CurStif, i);
                            glass.FlowID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowID;
                            glass.FlowGroups = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowGroups;
                            glass.PanelPairProp.PairProductID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].PanelPairProp.PairProductID;
                            glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                            glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                            glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                            glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                            glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                            glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                            glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                            glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                            glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";

                            send.Cassette.GlassDatas.Add(glass);
                        }
                    }
                    hostComs[(int)eHostType.Host].SendS6F11JobProcessEvent(send);
                    hostComs[(int)eHostType.Monitor].SendS6F11JobProcessEvent(send);

                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.CANCEL_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }
                }

                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;

                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);

                foreach (PortData portData in BatchInfo.PortDatas)
                {
                    switch (portData.ERROR_CODE)
                    {
                        case eERRCODE.ReloadCassette:
                            {
                                portData.ERROR_CODE = eERRCODE.NoError;
                                ProcessReloadCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByEquipment, eLogType.PC_RELOAD_ABNORMAL1);
                            }
                            break;
                        case eERRCODE.CancelCassette:
                            {
                                portData.ERROR_CODE = eERRCODE.NoError;
                                ProcessJobCancelCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByEquipment, eLogType.PC_CANCEL_ABNORMAL2);
                            }
                            break;
                    }
                }
            }                
        }
        private void ProcessE12JobAbortEvent(EqEventArgs e)
        {
            E12JobAbortEvent recv = (E12JobAbortEvent)e.XmlMsg;
            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11JobProcessEvent send = new S6F11JobProcessEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.Port = recv.Port;
                    int MapStif = int.Parse(recv.Port.MapStif) > 20 ? 20 : int.Parse(recv.Port.MapStif);
                    int CurStif = int.Parse(recv.Port.CurStif) > 20 ? 20 : int.Parse(recv.Port.CurStif);

                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette == null || BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas.Count < 1)
                    {
                        for (int i = 0; i < CurStif; i++)
                        {
                            GlassData glass = new GlassData();
                            for (int k = 0; k < 10; k++)
                            {
                                FlowGroupData FlowGroup = new FlowGroupData();
                                List<bool> list = new List<bool>();
                                for (int l = 0; l < 16; l++)
                                    list.Add(false);
                                FlowGroup.FlowList = list;
                                FlowGroup.Binary = FlowGroup.StringList;
                                glass.FlowGroups.Add(FlowGroup);
                            }

                            glass.SlotID = LCData.GetSlotID(MapStif, CurStif, i);
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                            glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                            glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                            glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                            glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                            glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                            glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                            glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                            glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";
                            send.Cassette.GlassDatas.Add(glass);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < CurStif; i++)
                        {
                            GlassData glass = new GlassData();

                            glass.SlotID = LCData.GetSlotID(MapStif, CurStif, i);
                            glass.FlowID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowID;
                            glass.FlowGroups = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowGroups;
                            glass.PanelPairProp.PairProductID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].PanelPairProp.PairProductID;
                            glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                            glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                            glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                            glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                            glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                            glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                            glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                            glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                            glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";

                            send.Cassette.GlassDatas.Add(glass);
                        }
                    }
                    hostComs[(int)eHostType.Host].SendS6F11JobProcessEvent(send);
                    hostComs[(int)eHostType.Monitor].SendS6F11JobProcessEvent(send);

                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.ABORT_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }
                }

                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;

                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);                
            }
        }
        private void ProcessE12JobEndEvent(EqEventArgs e)
        {
            E12JobEndEvent recv = (E12JobEndEvent)e.XmlMsg;
            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11JobProcessEvent send = new S6F11JobProcessEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.Port = recv.Port;
                    int MapStif = int.Parse(recv.Port.MapStif) > 20 ? 20 : int.Parse(recv.Port.MapStif);
                    int CurStif = int.Parse(recv.Port.CurStif) > 20 ? 20 : int.Parse(recv.Port.CurStif);

                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette == null || BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas.Count < 1)
                    {
                        for (int i = 0; i < CurStif; i++)
                        {
                            GlassData glass = new GlassData();
                            for (int k = 0; k < 10; k++)
                            {
                                FlowGroupData FlowGroup = new FlowGroupData();
                                List<bool> list = new List<bool>();
                                for (int l = 0; l < 16; l++)
                                    list.Add(false);
                                FlowGroup.FlowList = list;
                                FlowGroup.Binary = FlowGroup.StringList;
                                glass.FlowGroups.Add(FlowGroup);
                            }

                            glass.SlotID = LCData.GetSlotID(MapStif, CurStif, i);
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                            glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                            glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                            glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                            glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                            glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                            glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                            glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                            glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";
                            send.Cassette.GlassDatas.Add(glass);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < CurStif; i++)
                        {
                            GlassData glass = new GlassData();

                            glass.SlotID = LCData.GetSlotID(MapStif, CurStif, i);
                            glass.FlowID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowID;
                            glass.FlowGroups = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowGroups;
                            glass.PanelPairProp.PairProductID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].PanelPairProp.PairProductID;
                            glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                            glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                            glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                            glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                            glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                            glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                            glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";
                            glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                            glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                            glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER.Substring(0, BatchInfo.BatchDatas[0].P_MAKER.Length > 12 ? 12 : BatchInfo.BatchDatas[0].P_MAKER.Length) : "";
                            glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";

                            send.Cassette.GlassDatas.Add(glass);
                        }
                    }
                    hostComs[(int)eHostType.Host].SendS6F11JobProcessEvent(send);
                    hostComs[(int)eHostType.Monitor].SendS6F11JobProcessEvent(send);

                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.END_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }
                }

                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;

                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);               
               
                foreach (PortData portData in BatchInfo.PortDatas)
                {
                    switch (portData.ERROR_CODE)
                    {
                        case eERRCODE.ReloadCassette:
                            {
                                portData.ERROR_CODE = eERRCODE.NoError;
                                ProcessReloadCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByEquipment, eLogType.PC_RELOAD_ABNORMAL1);
                            }
                            break;
                        case eERRCODE.CancelCassette:
                            {
                                portData.ERROR_CODE = eERRCODE.NoError;
                                ProcessJobCancelCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByEquipment, eLogType.PC_CANCEL_ABNORMAL2);
                            }
                            break;
                    }
                }
            }            
        }
        private void ProcessE12LoadRequestEvent(EqEventArgs e)
        {
            E12LoadRequestEvent recv = (E12LoadRequestEvent)e.XmlMsg;
            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11PortLoaderEvent send = new S6F11PortLoaderEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.OperID = "";
                    send.Port = recv.Port;
                    hostComs[(int)eHostType.Host].SendS6F11PortLoaderEvent(send);
                }
                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;

                //Cassette 정보 삭제.
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                {
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = null;
                    //BatchInfo.PortDatas[1].Cassette = null;
                }

                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);

                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.LREQUEST_EVENT_ACK);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                }
            }          
        }
        private void ProcessE12PreLoadEvent(EqEventArgs e)
        {
            E12PreloadEvent recv = (E12PreloadEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11PortLoaderEvent send = new S6F11PortLoaderEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.OperID = "";
                    send.Port = recv.Port;
                    hostComs[(int)eHostType.Host].SendS6F11PortLoaderEvent(send);

                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.PRELOAD_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    //Cassette 정보 삭제.
                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                        BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = null;
                }
                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;              

                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);

                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);                               
             }          
        }
        private void ProcessE12ClampOnEvent(EqEventArgs e)
        {
            E12ClampOnEvent recv = (E12ClampOnEvent)e.XmlMsg;
            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11PortLoaderEvent send = new S6F11PortLoaderEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.OperID = "";
                    send.Port = recv.Port;
                    hostComs[(int)eHostType.Host].SendS6F11PortLoaderEvent(send);

                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.CLAMPON_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    //Cassette 정보 삭제.
                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                        BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = null;
                }
                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;    

                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);

                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                        
            }            
        }
        private void ProcessE12LoadCompleteEvent(EqEventArgs e)
        {
            E12LoadCompleteEvent recv = (E12LoadCompleteEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11PortLoaderEvent send = new S6F11PortLoaderEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.OperID = "";
                    send.Port = recv.Port;
                    hostComs[(int)eHostType.Host].SendS6F11PortLoaderEvent(send);

                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.LCOMPLETE_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    ////Cassette 정보 삭제.
                    //if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                    //    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = null;

                    if (LCData.OnlineHostState == eMCMD.REMOTE && BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState == ePortState.Wait)
                    {
                        Timer IsExistCsttimer = new Timer();
                        IsExistCsttimer.Interval = LCData.FindParamCancelTime();
                        IsExistCsttimer.Tag = (int)BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo;
                        IsExistCsttimer.Tick += new EventHandler(IsExistCsttimer_Tick);
                        IsExistCsttimer.Enabled = true;
                    }

                }
                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;     

                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);

                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                
            }         
        }
        private void ProcessE12UnLoadRequestEvent(EqEventArgs e)
        {
            E12UnLoadRequestEvent recv = (E12UnLoadRequestEvent)e.XmlMsg;
            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11PortLoaderEvent send = new S6F11PortLoaderEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.OperID = "";
                    send.Port = recv.Port;
                    hostComs[(int)eHostType.Host].SendS6F11PortLoaderEvent(send);

                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.ULREQUEST_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    ////Cassette 정보 삭제.
                    //if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                    //    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = null;
                    portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                }
                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;               

                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                //portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);

                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
            }         
        }
        private void ProcessE12UnLoadCompleteEvent(EqEventArgs e)
        {
            E12UnLoadCompleteEvent recv = (E12UnLoadCompleteEvent)e.XmlMsg;
            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    S6F11PortLoaderEvent send = new S6F11PortLoaderEvent();
                    send.DataID = 0;
                    send.ModuleID = LCData.Modules[0].ID;
                    send.MCMD = LCData.OnlineHostState;
                    send.EqState = LCData.Modules[0].EqState;
                    send.ProcState = LCData.Modules[0].ProcState;
                    send.OperID = "";
                    send.Port = recv.Port;
                    hostComs[(int)eHostType.Host].SendS6F11PortLoaderEvent(send);

                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.ULCOMPLETE_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    //Cassette 정보 삭제.
                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                        BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = null;

                }
                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;
               
                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                portInputForm.DisplayView(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                
            }
        }
        private void ProcessE12BatchPauseEvent(EqEventArgs e)
        {
            E12BatchPauseEvent recv = (E12BatchPauseEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;

                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.PAUSE_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID), BatchInfo.TARGET_LINE);
                    }
                }
                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;
               
                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].PAUSE_STATE = 1;
                operationControl1.UpdateDisplay();                
            }
        }
        private void ProcessE12BatchResumeEvent(EqEventArgs e)
        {
            E12BatchResumeEvent recv = (E12BatchResumeEvent)e.XmlMsg;
            BatchManager BatchInfo = LCData.FindBatch(recv.Port.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.Port.PortNo;

                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortEvent != recv.Port.PortEvent)
                {
                    LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.RESUME_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID), BatchInfo.TARGET_LINE);
                    }
                }


                //Port 정보 저장
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port != null)
                    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;

                portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].PAUSE_STATE = 0;
                operationControl1.UpdateDisplay();

                
            }
        }
        private void ProcessBatchEndEvent(eLINE line, eByWho ByWho)
        {
            BatchManager BatchInfo = LCData.FindBatch(line);
            if (BatchInfo != null)
            {
                int order = 0;
                S6F11BatchProcessEvent send = new S6F11BatchProcessEvent();

                send.DataID = 0;
                send.CEID = eCEID.ProductPlanBatchEnd;
                send.ModuleID = LCData.Modules[0].ID;
                send.MCMD = LCData.OnlineHostState;
                send.EqState = LCData.Modules[0].EqState;
                send.ProcState = LCData.Modules[0].ProcState;
                send.ByWho = ByWho;
                send.OperID = "";

                ModuleData module = LCData.FindModule(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].EqID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].UnitID);
                if (module != null)
                {
                    send.Port.PortID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID;
                    send.Port.EqState = module.EqState;// Port Unit에 대한 EqState
                    send.Port.PortState = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState;
                    send.Port.PortType = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortType;
                    send.Port.PortMode = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortMode;
                    send.Port.CstDemand = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstDemand;
                    send.Port.CstID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID;
                    send.Port.CstType = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstType;
                    send.Port.MapStif = LCData.GetHostMapping(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.MapStif).ToString();
                    send.Port.CurStif = LCData.GetHostMapping(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif).ToString();
                    send.Port.BatchOrder = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.BatchOrder;
                    send.Batch = BatchInfo.BatchDatas[0];
                }



                hostComs[(int)eHostType.Host].SendS6F11BatchProcessEvent(send);

                //Batch End 된 생산 계획 정보 이력 저장.
                SetBatchHistory(BatchInfo.BatchDatas[0], BatchInfo.TARGET_MODULEID, (short)BatchInfo.TARGET_LINE);

                //Log 저장
                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.BATCH_END_OPER_EVENT);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.BatchDatas[0].PRODUCTID, BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID, BatchInfo.BatchDatas[0].O_QTY), BatchInfo.TARGET_LINE);
                }
                //생산 계획 정보 Sorting
                BatchInfo.BatchDatas.RemoveAt(0);                
                foreach (BatchObject BatchObj in BatchInfo.BatchDatas)
                {
                    BatchObj.ORDER_NO = ++order;
                    if (BatchObj.ORDER_NO == 1) 
                        LCData.SaveBatCh(BatchInfo.TARGET_LINE, BatchObj);
                }
                batchDataControl1.UpdateDisplay(BatchInfo.TARGET_LINE);

                ProcessBatchEndReqEvent(BatchInfo.TARGET_LINE);               
            }            
        }
        private void ProcessBatchStartEvent(eLINE line, eByWho ByWho)
        {
            BatchManager BatchInfo = LCData.FindBatch(line);
            if (BatchInfo != null)
            {
                BatchInfo.BatchDatas[0].BATCH_STATE = eBatchtState.Busy;
                BatchInfo.BatchDatas[0].StartTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace('-', '/');

                S6F11BatchProcessEvent send = new S6F11BatchProcessEvent();

                send.DataID = 0;
                send.CEID = eCEID.ProductPlanBatchStart;
                send.ModuleID = LCData.Modules[0].ID;
                send.MCMD = LCData.OnlineHostState;
                send.EqState = LCData.Modules[0].EqState;
                send.ProcState = LCData.Modules[0].ProcState;
                send.ByWho = ByWho;
                send.OperID = "";

                ModuleData module = LCData.FindModule(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].EqID, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].UnitID);
                if (module != null)
                {
                    send.Port.PortID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID;
                    send.Port.EqState = module.EqState;// Port Unit에 대한 EqState
                    send.Port.PortState = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState;
                    send.Port.PortType = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortType;
                    send.Port.PortMode = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortMode;
                    send.Port.CstDemand = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstDemand;
                    send.Port.CstID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstID;
                    send.Port.CstType = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CstType;
                    send.Port.MapStif = LCData.GetHostMapping(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.MapStif).ToString();
                    send.Port.CurStif = LCData.GetHostMapping(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif).ToString();
                    send.Port.BatchOrder = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.BatchOrder;

                    send.Batch = BatchInfo.BatchDatas[0];
                }

                hostComs[(int)eHostType.Host].SendS6F11BatchProcessEvent(send);
                //Log 저장
                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.BATCH_START_EVENT);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.BatchDatas[0].PRODUCTID, BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID, BatchInfo.BatchDatas[0].BATCH_SIZE), BatchInfo.TARGET_LINE);
                }

                batchDataControl1.UpdateDisplay(BatchInfo.TARGET_LINE);
            }
        }
        private void ProcessBatchRequestEvent(eLINE line)
        {
            if (LCData.OnlineHostState != eMCMD.OFFLINE)
            {
                S6F11ProdPlanRequstEvent send = new S6F11ProdPlanRequstEvent();
                send.DataID = 0;
                send.CEID = eCEID.ProductPlanInfoRequest;
                send.ModuleID = LCData.Modules[0].ID;
                send.MCMD = LCData.OnlineHostState;
                send.EqState = LCData.Modules[0].EqState;
                send.ProcState = LCData.Modules[0].ProcState;
                send.ByWho = eByWho.ByOperator;
                send.OperID = "";
                send.ItemName = "LINE_NO";
                send.ItemValue = LCData.FindParamTarget(line);
                send.RelatedModuleID = send.ItemValue;
                hostComs[(int)eHostType.Host].SendS6F11ProdPlanRequstEvent(send);

                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.BATCH_REQ_OPER_EVENT);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, send.ItemValue), line);
                }
            }
        }
        private void ProcessBatchEndReqEvent(eLINE line)
        {
            Timer BatchReqtimer = new Timer();
            BatchReqtimer.Interval = 1000;
            BatchReqtimer.Tag = (short)line;
            BatchReqtimer.Tick += new EventHandler(BatchReqtimer_Tick);
            BatchReqtimer.Enabled = true;
        }
        private void BatchReqtimer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Enabled = false;
            
            if (LCData.OnlineHostState != eMCMD.OFFLINE)
            {
                short line = (short)timer.Tag;
                S6F11ProdPlanRequstEvent send = new S6F11ProdPlanRequstEvent();
                send.DataID = 0;
                send.CEID = eCEID.ProductPlanInfoRequest;
                send.ModuleID = LCData.Modules[0].ID;
                send.MCMD = LCData.OnlineHostState;
                send.EqState = LCData.Modules[0].EqState;
                send.ProcState = LCData.Modules[0].ProcState;
                send.ByWho = eByWho.ByEquipment;
                send.OperID = "";
                send.ItemName = "LINE_NO";
                send.ItemValue = LCData.FindParamTarget((eLINE)line);
                send.RelatedModuleID = send.ItemValue;
                hostComs[(int)eHostType.Host].SendS6F11ProdPlanRequstEvent(send);

                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.BATCH_REQ_AUTO_EVENT);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, send.ItemValue), (eLINE)line);
                }               
            }
        }
        //PC Command
        private void ProcessResumeCommand(eLINE line, eByWho byWho, eLogType logType)
        {
            C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();

            ProcCmd.Target.SrcEq = "LC";
            ProcCmd.Target.SrcUnit = "N/A";
            ProcCmd.Target.DesEq = "PLC1";
            ProcCmd.Target.DesUnit = "N/A";
            ProcCmd.PortNo = (line == eLINE.LINE1) ? 12 :
                             (line == eLINE.LINE2) ? 34 : 1234;
            ProcCmd.Command = eRCMD.BatchResumeStart;
            ProcCmd.ByWho = byWho;
            eqComs[(int)eEqType.EQPLC1].SendC14ProcessPortCmd(ProcCmd);

            LogInfoData logInfo = LCData.FindLogInfo((short)logType);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, line), line);
            }
        }
        private void ProcessPauseCommand(eLINE line, eByWho byWho, eLogType logType)
        {
            C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();

            ProcCmd.Target.SrcEq = "LC";
            ProcCmd.Target.SrcUnit = "N/A";
            ProcCmd.Target.DesEq = "PLC1";
            ProcCmd.Target.DesUnit = "N/A";
            ProcCmd.PortNo = (line == eLINE.LINE1) ? 12 :
                             (line == eLINE.LINE2) ? 34 : 1234;
            ProcCmd.Command = eRCMD.BatchPauseStart;
            ProcCmd.ByWho = byWho;
            eqComs[(int)eEqType.EQPLC1].SendC14ProcessPortCmd(ProcCmd);

            LogInfoData logInfo = LCData.FindLogInfo((short)logType);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, line), line);
            }
        }
        private void SendCstInfo(PortData portInfo)
        {
            S3F101CassetteInfo send = new S3F101CassetteInfo();
            send.Cassette = portInfo.Cassette;
            send.Port = portInfo.Port;
            hostComs[(int)eHostType.Monitor].SendS3F101CassetteInfo(send);
        }
        private void ProcessJobStartCommand(PortData portInfo, eByWho byWho, eLogType logType)
        {
            //Casseete 정보 Write
            ProcessCassetteCommand(portInfo.Port.PortNo);

            C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();
            ProcCmd.Target.SrcEq = "LC";
            ProcCmd.Target.SrcUnit = "N/A";
            ProcCmd.Target.DesEq = portInfo.EqID;
            ProcCmd.Target.DesUnit = portInfo.UnitID;
            ProcCmd.PortNo = portInfo.Port.PortNo;
            ProcCmd.Command = eRCMD.JobProcessStart;
            ProcCmd.CstID = portInfo.Port.CstID;
            ProcCmd.MapStif = LCData.GetEqMapping(portInfo.Port.MapStif).ToString();
            ProcCmd.StartStif = LCData.GetEqMapping(portInfo.Port.CurStif).ToString();
            ProcCmd.ByWho = byWho;
            eqComs[(int)eEqType.EQPLC1].SendC14ProcessPortCmd(ProcCmd);

            LogInfoData logInfo = LCData.FindLogInfo((short)logType);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, portInfo.Port.PortID, portInfo.Port.CstID), portInfo.TargetLine);
            }
        }
        private void ProcessJobCancelCommand(PortData portInfo, eByWho byWho, eLogType logType)
        {
            C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();
            ProcCmd.Target.SrcEq = "LC";
            ProcCmd.Target.SrcUnit = "N/A";
            ProcCmd.Target.DesEq = portInfo.EqID;
            ProcCmd.Target.DesUnit = portInfo.UnitID;
            ProcCmd.PortNo = portInfo.Port.PortNo;
            ProcCmd.Command = eRCMD.JobProcessCancel;
            ProcCmd.CstID = portInfo.Port.CstID;
            ProcCmd.MapStif = LCData.GetEqMapping(portInfo.Port.MapStif).ToString();
            ProcCmd.StartStif = LCData.GetEqMapping(portInfo.Port.CurStif).ToString();
            ProcCmd.ByWho = byWho;
            eqComs[(int)eEqType.EQPLC1].SendC14ProcessPortCmd(ProcCmd);

            LogInfoData logInfo = LCData.FindLogInfo((short)logType);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, portInfo.Port.PortID, portInfo.Port.CstID), portInfo.TargetLine);
            }
        }
        private void ProcessJobAbortCommand(PortData portInfo, eByWho byWho, eLogType logType)
        {
            C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();
            ProcCmd.Target.SrcEq = "LC";
            ProcCmd.Target.SrcUnit = "N/A";
            ProcCmd.Target.DesEq = portInfo.EqID;
            ProcCmd.Target.DesUnit = portInfo.UnitID;
            ProcCmd.PortNo = portInfo.Port.PortNo;
            ProcCmd.Command = eRCMD.JobProcessAbort;
            ProcCmd.CstID = portInfo.Port.CstID;
            ProcCmd.MapStif = LCData.GetEqMapping(portInfo.Port.MapStif).ToString();
            ProcCmd.StartStif = LCData.GetEqMapping(portInfo.Port.CurStif).ToString();
            ProcCmd.ByWho = byWho;
            eqComs[(int)eEqType.EQPLC1].SendC14ProcessPortCmd(ProcCmd);

            LogInfoData logInfo = LCData.FindLogInfo((short)logType);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, portInfo.Port.PortID, portInfo.Port.CstID), portInfo.TargetLine);
            }
        }
        private void ProcessJobEndCommand(PortData portInfo, eByWho byWho, eLogType logType)
        {
            C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();
            ProcCmd.Target.SrcEq = "LC";
            ProcCmd.Target.SrcUnit = "N/A";
            ProcCmd.Target.DesEq = portInfo.EqID;
            ProcCmd.Target.DesUnit = portInfo.UnitID;
            ProcCmd.PortNo = portInfo.Port.PortNo;
            ProcCmd.Command = eRCMD.BatchEndStart;
            ProcCmd.CstID = portInfo.Port.CstID;
            ProcCmd.MapStif = LCData.GetEqMapping(portInfo.Port.MapStif).ToString();
            ProcCmd.StartStif = LCData.GetEqMapping(portInfo.Port.CurStif).ToString();
            ProcCmd.ByWho = byWho;
            eqComs[(int)eEqType.EQPLC1].SendC14ProcessPortCmd(ProcCmd);

            LogInfoData logInfo = LCData.FindLogInfo((short)logType);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, portInfo.Port.PortID, portInfo.Port.CstID), portInfo.TargetLine);
            }
        }
        private void ProcessReloadCommand(PortData portInfo, eByWho byWho, eLogType logType)
        {
            C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();
            ProcCmd.Target.SrcEq = "LC";
            ProcCmd.Target.SrcUnit = "N/A";
            ProcCmd.Target.DesEq = portInfo.EqID;
            ProcCmd.Target.DesUnit = portInfo.UnitID;
            ProcCmd.PortNo = portInfo.Port.PortNo;
            ProcCmd.Command = eRCMD.ReloadCassette;
            ProcCmd.CstID = portInfo.Port.CstID;
            ProcCmd.MapStif = LCData.GetEqMapping(portInfo.Port.MapStif).ToString();
            ProcCmd.StartStif = LCData.GetEqMapping(portInfo.Port.CurStif).ToString();
            ProcCmd.ByWho = byWho;
            eqComs[(int)eEqType.EQPLC1].SendC14ProcessPortCmd(ProcCmd);

            LogInfoData logInfo = LCData.FindLogInfo((short)logType);
            if (logInfo != null)
            {
                SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, portInfo.Port.PortID, portInfo.Port.CstID), portInfo.TargetLine);
            }
        }
        private void ProcessCassetteCommand(int PortNo)
        {
            BatchManager BatchInfo = LCData.FindBatch(PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = PortNo;
                C15CassetteInfoCmd CstCmd = new C15CassetteInfoCmd();                

                CstCmd.Target.SrcEq = "LC";
                CstCmd.Target.SrcUnit = "N/A";
                CstCmd.Target.DesEq = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].EqID;
                CstCmd.Target.DesUnit = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].UnitID;
                CstCmd.PortNo = PortNo.ToString();
                CstCmd.ProcessID = BatchInfo.BatchDatas[0].PROCESSID;
                CstCmd.ProductID = BatchInfo.BatchDatas[0].PRODUCTID;
                CstCmd.StepID = BatchInfo.BatchDatas[0].STEPID;
                CstCmd.BatchID = BatchInfo.BatchDatas[0].BATCHID;
                CstCmd.ProdType = BatchInfo.BatchDatas[0].PROD_TYPE;
                CstCmd.ProdKind = BatchInfo.BatchDatas[0].PROD_KIND;
                CstCmd.PPID = BatchInfo.BatchDatas[0].PPID;
                CstCmd.FlowID = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowID;
                CstCmd.PanelSize = "25000 22000";//fixed
                CstCmd.Thickness = BatchInfo.BatchDatas[0].P_THICKNESS;
                CstCmd.CompCount = BatchInfo.BatchDatas[0].C_QTY;
                CstCmd.PanelState = "3";//fixed
                CstCmd.Judgement = "OK";//fixed
                CstCmd.FlowHistory = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0";//28개 fixed
                CstCmd.Grade = "0".PadLeft(64, '0');
                CstCmd.GlassDataSignal = "0".PadLeft(32, '0');
                CstCmd.PairHPanelID = BatchInfo.BatchDatas[0].P_MAKER;
                CstCmd.PairEPanelID = BatchInfo.BatchDatas[0].F_PANELID;
                CstCmd.PairProductiD = BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].PanelPairProp.PairProductID;
                CstCmd.PairGrade = "0".PadLeft(64, '0');

                string group = "";
                foreach (FlowGroupData info in BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].FlowGroups)
                {
                    group += System.Convert.ToInt32(info.StringList, 2).ToString() + " ";
                }
                CstCmd.FlowGroup = group.Trim();
                CstCmd.DBRRecipe = "0";
                CstCmd.ReferData = "0";

                eqComs[(int)eEqType.EQPLC1].SendC15CassetteInfoCmd(CstCmd);

            }
        }
        private void ProcessOnlineChangeEvent(eMCMD onlinemode)
        {
            S6F11EqEvent send = new S6F11EqEvent();
            send.DataID = 0;
            send.CEID = (onlinemode == eMCMD.REMOTE) ? eCEID.ChangeToOnLineRemoteMode : eCEID.ChangeToOnLineLocalMode;

            send.ModuleID = LCData.Modules[0].ID;

            send.MCMD = onlinemode;
            send.ByWho = eByWho.ByOperator;
            send.OperID = "";
            send.ChangeEqStateModuleID = "";
            send.ChangeProcStateModuleID = "";
            send.LimitTime = "";
            send.RCode = "";
            hostComs[(int)eHostType.Host].SendS6F11EqEvent(send);

            LCData.OnlineHostState = send.MCMD;
            stateControl1.UpdateDisplay();

            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                for (int i = 0; i < 2; i++)
                {
                    portInputForm.UpdateOnlineMode(BatchInfo.PortDatas[i].Port.PortNo);
                }
            }
        }
        private void SendMessage()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        //GlassID & UniqueID Request Event
        private void ProcessE13PanelIDReqEvent(EqEventArgs e)
        {
            E13PanelIDReqEvent recv = (E13PanelIDReqEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.PortNo;

                //투입 계획이 없거나, 카세트 정보 없을 경우 에러 처리
                if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette == null || BatchInfo.BatchDatas.Count < 1)
                {
                    //라인에 해당하는 PORT에 대해서 JOB END 또는 JOB CANCEL 처리.
                    foreach (PortData portData in BatchInfo.PortDatas)
                    {
                        switch (portData.Port.PortState)
                        {
                            case ePortState.Busy: ProcessJobEndCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT], eByWho.ByEquipment, eLogType.PC_END_ABNORMAL1);break;
                            case ePortState.Wait:
                            case ePortState.Reserve:
                                ProcessJobCancelCommand(portData, eByWho.ByEquipment, eLogType.PC_CANCEL_ABNORMAL1); break;
                        }
                    }
                }
                //BATCHID가 실물과 상이한 경우 에러 처리
                //카세트 정보를 재 수신해야 하기 때문에 Busy중인경우는, Job end 처리 한후, Reload 처리한다.
                else if (BatchInfo.BatchDatas[0].BATCHID != BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette.GlassDatas[0].BatchID)
                {
                    foreach (PortData portData in BatchInfo.PortDatas)
                    {                        
                        switch (portData.Port.PortState)
                        {
                            case ePortState.Busy: 
                                {   
                                    portData.ERROR_CODE = eERRCODE.ReloadCassette;
                                    ProcessJobEndCommand(portData, eByWho.ByEquipment, eLogType.PC_END_ABNORMAL2);
                                }break;
                            case ePortState.Wait:
                            case ePortState.Reserve:
                                {
                                    ProcessJobCancelCommand(portData, eByWho.ByEquipment, eLogType.PC_CANCEL_ABNORMAL2);
                                } break;
                        }
                    }
                }
                else
                {
                    //정상 발급 처리 프로세스
                    if (BatchInfo.BATCHID_STATE == eBatchIDState.BATCHID_EMPTY)  //plc상에 카세트 정보가 사라진 경우
                    {
                        ProcessCassetteCommand(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                    }

                    if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortState == ePortState.Reserve &&
                         BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.MapStif == BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif)
                    {
                        LCData.SetJobCount();
                        BatchInfo.PortDatas[BatchInfo.EVENT_PORT].JOB_NUMBER = LCData.GetJobCount();
                    }
                    LCData.SetGlassCount();

                    C16PanelInfoCmd PanelCmd = new C16PanelInfoCmd();
                    PanelCmd.Target.SrcEq = "LC";
                    PanelCmd.Target.SrcUnit = "N/A";
                    PanelCmd.Target.DesEq = recv.Target.SrcEq;
                    PanelCmd.Target.DesUnit = recv.Target.SrcUnit;
                    PanelCmd.PortNo = recv.PortNo.ToString();

                    if (BatchInfo.PANELID_STATE == eHPanelIDState.HPANELID_EMPTY)
                    {
                        PanelCmd.HPanelID = LCData.GetCreatePanelID(BatchInfo.BatchDatas[0].O_QTY > 0 ? BatchInfo.BatchDatas[0].O_QTY - 1 : 0, BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID);
                        BatchInfo.PANELID_STATE = eHPanelIDState.NONE;
                    }
                    else if (BatchInfo.PANELID_STATE == eHPanelIDState.HPANELID_DUPLICATE)
                    {
                        PanelCmd.HPanelID = LCData.GetCreatePanelID(++BatchInfo.BatchDatas[0].O_QTY, BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID);
                        BatchInfo.PANELID_STATE = eHPanelIDState.NONE;
                    }
                    else //다음 Glass ID 생성
                        PanelCmd.HPanelID = LCData.GetCreatePanelID(BatchInfo.BatchDatas[0].O_QTY, BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID);


                    //batch 상에 발행되고, 보고되어져야 하는 glass ID 생성.
                    //-----------------------------------------------------
                   // if (BatchInfo.BatchDatas[0].F_PANELID == PanelCmd.HPanelID || BatchInfo.BatchDatas[0].GlassIDLists.Count == 0)
                   // {
                   //     if (BatchInfo.BatchGlassIDs != null)
                   //         BatchInfo.BatchGlassIDs = null;

                   //     List<BatchGlassData> glassids = LCData.BatchGlassIDsInfo(BatchInfo.BatchDatas[0].BATCHID, PanelCmd.HPanelID, BatchInfo.BatchDatas[0].BATCH_SIZE);
                   //     if (glassids != null)
                   //     {
                   //         BatchInfo.BatchGlassIDs = glassids;
                   //     }
                   //}
                   //------------------------------------------------------
                    PanelCmd.UniqueID = string.Format("{0} {1} {2} {3}", LCData.GetGlassCount(), BatchInfo.PortDatas[BatchInfo.EVENT_PORT].JOB_NUMBER, LCData.GetIndexSlot(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif), BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);                    
                   eqComs[(int)eEqType.EQPLC1].SendC16PanelInfoCmd(PanelCmd);
                }
            }
        }
        //// 호기별 각 PLC 현재공 모니터링 
        private void ProcessE14WIPQTYEvent(EqEventArgs e)
        {
            E14WIPQTYEvent recv = (E14WIPQTYEvent)e.XmlMsg;


            WIPQTYData Info1 = LCData.GetWIPQTY(1);
            if (Info1 != null)
            {
                Info1.SET_PLC1QTY = recv.WIPQTY1P1;
                Info1.SET_PLC2QTY = recv.WIPQTY1P2;             
            }

            WIPQTYData Info2 = LCData.GetWIPQTY(2);
            if (Info2 != null)
            {
                Info2.SET_PLC1QTY = recv.WIPQTY2P1;
                Info2.SET_PLC2QTY = recv.WIPQTY2P2;
            }

            inputControl1.UpdateDisplay();       
        }
        private void ProcessE15BatchPauseEvent(EqEventArgs e)
        {
            E15BatchPauseEvent recv = (E15BatchPauseEvent)e.XmlMsg;
            BatchManager BatchInfo = LCData.FindBatch(recv.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.PortNo;
                ////Port 정보 저장
                //if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                //    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                //BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;

                //portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                //portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].PAUSE_STATE = 1;
                operationControl1.UpdateDisplay();
            }            
        }
        private void ProcessE16BatchResumeEvent(EqEventArgs e)
        {
            E16BatchResumeEvent recv = (E16BatchResumeEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.PortNo;
                ////Port 정보 저장
                //if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                //    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = null;
                //BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port = recv.Port;

                //portSlotControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.CurStif);
                //portDataControl1.UpdateDisplay(BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortNo);
                BatchInfo.PortDatas[BatchInfo.EVENT_PORT].PAUSE_STATE = 0;
                operationControl1.UpdateDisplay();
            }
        }
        private void ProcessE17InitialSynchEvent(EqEventArgs e)
        {
            E17InitialSynchEvent recv = (E17InitialSynchEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.PortNo);
            if (BatchInfo != null)
            {
                BatchInfo.EVENT_PORT = recv.PortNo;

                //if (BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette != null)
                //    BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Cassette = null;

                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.INIT_EVENT_ACK);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID), BatchInfo.TARGET_LINE);
                }     
            }
        }
        private void ProcessE18DuplicationEvent(EqEventArgs e)
        {           
            E18DuplicationEvent recv = (E18DuplicationEvent)e.XmlMsg;

            BatchManager BatchInfo = LCData.FindBatch(recv.PortNo);
            if (BatchInfo != null)
            {
                if (recv.HPanelID == LCData.GetCreatePanelID(BatchInfo.BatchDatas[0].O_QTY, BatchInfo.BatchDatas[0].BATCHID, BatchInfo.BatchDatas[0].F_PANELID))
                    BatchInfo.PANELID_STATE = (eHPanelIDState)recv.ResultHPanelID;

                BatchInfo.UNIQUEID_STATE = (eUniqueIDState)recv.ResultUniqueID;
                BatchInfo.BATCHID_STATE = (eBatchIDState)recv.ResultBatchID;             
            }
        }
        private void ProcessE20PLCSignalEvent(EqEventArgs e)
        {
            E20PLCSignalEvent recv = (E20PLCSignalEvent)e.XmlMsg;

            BatchManager BatchInfo;
            LogInfoData logInfo;
            
            switch (recv.SigID)
            {
                case 1:
                    BatchInfo = LCData.FindBatch(recv.PortNo);
                    if (BatchInfo != null)
                    {
                        BatchInfo.EVENT_PORT = recv.PortNo;
                        logInfo = LCData.FindLogInfo((short)eLogType.PROCESSCMD_EVENT_ACK);
                        if (logInfo != null)
                        {                            
                            SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID), BatchInfo.TARGET_LINE);
                        }
                    }
                    break;
                case 2:
                    BatchInfo = LCData.FindBatch(recv.PortNo);
                    if (BatchInfo != null)
                    {
                        BatchInfo.EVENT_PORT = recv.PortNo;
                        logInfo = LCData.FindLogInfo((short)eLogType.PANELIDINFO_EVENT_ACK);
                        if (logInfo != null)
                        {
                            SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[BatchInfo.EVENT_PORT].Port.PortID), BatchInfo.TARGET_LINE);
                        }
                    }
                    break;
                case 3:
                    logInfo = LCData.FindLogInfo((short)eLogType.EQUIPMENTCMD_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, logInfo.Comment, eLINE.LINE1);
                        SetMessage(logInfo.SerialNo, logInfo.Comment, eLINE.LINE2);
                    }
                    break;
                case 4:
                    logInfo = LCData.FindLogInfo((short)eLogType.DATETIMESETCMD_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, logInfo.Comment, eLINE.LINE1);
                        SetMessage(logInfo.SerialNo, logInfo.Comment, eLINE.LINE2);
                    }
                    break;
                case 5:
                    logInfo = LCData.FindLogInfo((short)eLogType.TERMINALMSGCMD_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, logInfo.Comment, eLINE.LINE1);
                        SetMessage(logInfo.SerialNo, logInfo.Comment, eLINE.LINE2);
                    }
                    break;
                case 6:
                    logInfo = LCData.FindLogInfo((short)eLogType.OPCALLMSGCMD_EVENT_ACK);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, logInfo.Comment, eLINE.LINE1);
                        SetMessage(logInfo.SerialNo, logInfo.Comment, eLINE.LINE2);
                    }
                    break;
                default:
                    break;
            }                
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (HostCom hostCom in hostComs)
            {
                hostCom.Stop();
            }
            foreach (EqCom eqCom in eqComs)
            {
                eqCom.Stop();
                eqCom.Close();
            }

            sqlManager.Disconnect();
            Application.Exit();
            Environment.Exit(0); 
        }      
        private void SetMessage(short logSerial, string logText, eLINE logLine)
        {
            if (!(5013 <= logSerial && 5018 >= logSerial))
            {
                //Display
                logControl1.UpdateDisplay(logLine, logText);
            }
            //파일 저장
            logManager.WriteLog((short)logLine, logSerial, logText);
            //Count 증가
			SetPrimaryDateTime();
            //DB 저장
            sqlManager.SetLog(LCData.logDateTime + LCData.logCount.ToString().PadLeft(2, '0'), logText, (short)logLine, logSerial);
        }
        private void SetBatchHistory(BatchObject BatchInfo, string ModuleID, short line)
        {
            //DB저장
            SetBatchLogDateTime();
            sqlManager.SetPlanHistorys(LCData.batchlogDateTime + LCData.batchlogCount.ToString().PadLeft(2, '0'), BatchInfo, ModuleID, line);
        }
        private void SetGlassIDHistory(string batchid, string fpanelid, string glassid, List<short> uniqueid, short line)
        {
            string uniqueID = "";
            foreach (short id in uniqueid)
            {
                uniqueID += id.ToString();
                uniqueID += " ";
            }

            SetGlassLogDateTime();
            sqlManager.SetGlassIDHistory(LCData.glasslogDateTime + LCData.glasslogCount.ToString().PadLeft(2, '0'), batchid, fpanelid, glassid, uniqueID.Trim(), line);
        }
        private void SetAlarmHistory(AlarmData Alarm)
        {
            //Display
            alarmControl1.UpdateDisplay();         
            //Count 증가
            SetAlarmLogDateTime();
            //AlarmDB저장
            //sqlManager.SetAlarm(LCData.alarmlogDateTime + LCData.alarmlogCount.ToString().PadLeft(2, '0'), (short)Alarm.AlarmSet, Alarm.ModuleID,
            //    Alarm.Section.ToString(), Alarm.EqID, Alarm.UnitID, Alarm.ID.ToString(), Alarm.AlarmType.ToString(), Alarm.AlarmReason.ToString(), Alarm.Text);
            ////파일 저장
            //alarmlogManager.WriteLog(LCData.alarmlogDateTime, Alarm.AlarmSet.ToString(), Alarm.Section.ToString(), Alarm.EqID, Alarm.UnitID, Alarm.ID.ToString(),
            //    Alarm.AlarmType.ToString(), Alarm.AlarmReason.ToString(), Alarm.Text);

            sqlManager.SetAlarm(LCData.alarmlogDateTime + LCData.alarmlogCount.ToString().PadLeft(2, '0'), Alarm);
            //파일 저장
            alarmlogManager.WriteLog(LCData.alarmlogDateTime, Alarm.AlarmSet.ToString(), Alarm.UnitID, Alarm.ID.ToString(), Alarm.Text);
        }
        private void SetTerminalMessage(string text)
        {
            //Count 증가
            SetTerminalLogDateTime();
            //DB 저장
            sqlManager.SetTerminalLog(LCData.messagelogDateTime + LCData.messagelogCount.ToString().PadLeft(2, '0'), text);
            terminallogManager.WriteLog(text);
        }
		private void SetPrimaryDateTime( )
		{
			string nowDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
			if (nowDateTime == LCData.logDateTime)
			{
				LCData.logCount++;
				if (LCData.logCount > 99) LCData.logCount = 0;
			}
			else
			{
				LCData.logDateTime = nowDateTime;
				LCData.logCount = 0;
			}
		}
        private void SetBatchLogDateTime()
        {
            string nowDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (nowDateTime == LCData.batchlogDateTime)
            {
                LCData.batchlogCount++;
                if (LCData.batchlogCount > 99) LCData.batchlogCount = 0;
            }
            else
            {
                LCData.batchlogDateTime = nowDateTime;
                LCData.batchlogCount = 0;
            }
        }
        private void SetGlassLogDateTime()
        {
            string nowDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (nowDateTime == LCData.glasslogDateTime)
            {
                LCData.glasslogCount++;
                if (LCData.glasslogCount > 99) LCData.glasslogCount = 0;
            }
            else
            {
                LCData.glasslogDateTime = nowDateTime;
                LCData.glasslogCount = 0;
            }
        }
        private void SetAlarmLogDateTime()
        {
            string nowDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (nowDateTime == LCData.alarmlogDateTime)
            {
                LCData.alarmlogCount++;
                if (LCData.alarmlogCount > 99) LCData.alarmlogCount = 0;
            }
            else
            {
                LCData.alarmlogDateTime = nowDateTime;
                LCData.alarmlogCount = 0;
            }
        }
        private void SetTerminalLogDateTime()
        {
            string nowDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (nowDateTime == LCData.messagelogDateTime)
            {
                LCData.messagelogCount++;
                if (LCData.messagelogCount > 99) LCData.messagelogCount = 0;
            }
            else
            {
                LCData.messagelogDateTime = nowDateTime;
                LCData.messagelogCount = 0;
            }
        }
        public bool IsDuplicateBatch(string text)
        {
            return sqlManager.IsDuplicateBatch(text, LCData.HistoryPeriodSet.PlanHistoryRange);
        }
        public bool IsDuplicateGlassID(string text)
        {
            return sqlManager.IsDuplicateGlassID(text, LCData.HistoryPeriodSet.GlassHistoryRange);
        }
        public void GetLogHistorys(string fromDateTime, string toDateTime, string searchSerial, string searNack, string searchOption, int select)
        {
            LCData.logHistoryDatas.L1Count = 0;
            LCData.logHistoryDatas.L2Count = 0;

            switch (select)
            {
                case 0: LCData.logHistoryDatas = sqlManager.GetLogHistorys(fromDateTime, toDateTime, searchSerial,searNack, searchOption); break;
                case 1: LCData.logHistoryDatas = sqlManager.GetTerminalHistorys(fromDateTime, toDateTime, searchOption); break;
            }
        }
        public void GetBatchHistorys(string fromDateTime, string toDateTime, string searchOption, int select)
        {
           // if (LCData.batchHistoryDatas == null)
           //     LCData.batchHistoryDatas = null;

            switch (select)
            {
                case 0: LCData.batchHistoryDatas = sqlManager.GetBatchHistorys(fromDateTime, toDateTime, searchOption); break;
                case 1: LCData.batchHistoryDatas = sqlManager.GetGlassHistorys(fromDateTime, toDateTime, searchOption); break;
            }
        }
        public void GetAlarmHistorys(string fromDateTime, string toDateTime, string searchOption, int alarmOn)
        {
            if (LCData.alarmHistoryDatas.Count > 0)
                LCData.alarmHistoryDatas.Clear();
            LCData.alarmHistoryDatas = sqlManager.GetAlarmHistorys(fromDateTime, toDateTime, searchOption, alarmOn);
        }
        public BatchObject CreateForm_HistoryBatchEvent(eLINE Line)
        {
            return sqlManager.GetLastBatch(LCData.FindParamTarget(Line));
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            LCData.SaveAll();
            sqlManager.SetStartJobNumber(LCData.JobStart);
            sqlManager.SetStartGlassNumber(LCData.GlassStart);
      
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }

                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.PC_BOOT_END);
                if (logInfo != null)
                {
                    foreach (BatchManager BatchInfo in LCData.BatchManagers)
                    {
                        SetMessage(logInfo.SerialNo, logInfo.Comment, BatchInfo.TARGET_LINE);
                    }
                }
            }           
        }
		private void timerDelete_Tick(object sender, EventArgs e)
        {
			sqlManager.DeleteBatchHistorys(DateTime.Now.AddDays(-LCData.HistoryPeriodSet.PlanHistoryPeriod).ToString("yyyyMMddHHmmss00"));
			sqlManager.DeleteGlassID(DateTime.Now.AddDays(-LCData.HistoryPeriodSet.GlassHistoryPeriod).ToString("yyyyMMddHHmmss00"));
            sqlManager.DeleteMessage(DateTime.Now.AddDays(-LCData.HistoryPeriodSet.LogHistoryPeriod).ToString("yyyyMMddHHmmss00"));
			sqlManager.DeleteLog(DateTime.Now.AddDays(-LCData.HistoryPeriodSet.LogHistoryPeriod).ToString("yyyyMMddHHmmss00"));
			sqlManager.DeleteAlarmLog(DateTime.Now.AddDays(-LCData.HistoryPeriodSet.LogHistoryPeriod).ToString("yyyyMMddHHmmss00"));
        }    
        private void btnPortColorState_Click(object sender, EventArgs e)
        {
            DisplayPortState StateForm = new DisplayPortState();
            DialogResult rusult = StateForm.ShowDialog();    
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.PC_BOOT_START);

            if (logInfo != null)
            {
                foreach (BatchManager BatchInfo in LCData.BatchManagers)
                {
                    SetMessage(logInfo.SerialNo, logInfo.Comment, BatchInfo.TARGET_LINE);
                }
            }
        }
        private void NowTimer_Tick(object sender, EventArgs e)
        {
            this.Text = string.Format("생산계획PC v{0}({1}){2, 160}", LCData.Version[0], LCData.Version[1], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace('-', '/'));
        }
        private void timerL1BatchReq_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerL1BatchReq.Enabled = false;
            if (LCData.OnlineHostState != eMCMD.OFFLINE)
            {
                S6F11ProdPlanRequstEvent send = new S6F11ProdPlanRequstEvent();
                send.DataID = 0;
                send.CEID = eCEID.ProductPlanInfoRequest;
                send.ModuleID = LCData.Modules[0].ID;
                send.MCMD = LCData.OnlineHostState;
                send.EqState = LCData.Modules[0].EqState;
                send.ProcState = LCData.Modules[0].ProcState;
                send.ByWho = eByWho.ByEquipment;
                send.OperID = "";
                send.ItemName = "LINE_NO";
                send.ItemValue = LCData.FindParamTarget(eLINE.LINE1);
                send.RelatedModuleID = send.ItemValue;

                hostComs[(int)eHostType.Host].SendS6F11ProdPlanRequstEvent(send);


                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.BATCH_REQ_TIMER_EVENT);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, send.ItemValue), eLINE.LINE1);
                }
            }

            timerL2BatchReq.Interval = LCData.FindParamTime2();
            timerL2BatchReq.Enabled = true;
        }
        private void timerL2BatchReq_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerL2BatchReq.Enabled = false;
            if (LCData.OnlineHostState != eMCMD.OFFLINE)
            {
                S6F11ProdPlanRequstEvent send = new S6F11ProdPlanRequstEvent();
                send.DataID = 0;
                send.CEID = eCEID.ProductPlanInfoRequest;
                send.ModuleID = LCData.Modules[0].ID;
                send.MCMD = LCData.OnlineHostState;
                send.EqState = LCData.Modules[0].EqState;
                send.ProcState = LCData.Modules[0].ProcState;
                send.ByWho = eByWho.ByOperator;
                send.OperID = "";
                send.ItemName = "LINE_NO";
                send.ItemValue = LCData.FindParamTarget(eLINE.LINE2);
                send.RelatedModuleID = send.ItemValue;

                hostComs[(int)eHostType.Host].SendS6F11ProdPlanRequstEvent(send);

                LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.BATCH_REQ_TIMER_EVENT);
                if (logInfo != null)
                {
                    SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, send.ItemValue), eLINE.LINE2);
                }
            }
            timerL1BatchReq.Interval = LCData.FindParamTime1() - LCData.FindParamTime2();
            timerL1BatchReq.Enabled = true;
        }
        private void ProcessC17WIPQTYInfoCommand()
        {
            C17WIPQTYInfoCmd Cmd = new C17WIPQTYInfoCmd();

            Cmd.Target.SrcEq = "LC";
            Cmd.Target.SrcUnit = "N/A";
            Cmd.Target.DesEq = "PLC1";
            Cmd.Target.DesUnit = "N/A";

            Cmd.WIPQTY1 = LCData.FindWIPQTY(1).ToString();
            Cmd.WIPQTY2 = LCData.FindWIPQTY(2).ToString();

            eqComs[(int)eEqType.EQPLC1].SendC17WIPQTYInfoCmd(Cmd);
            sqlManager.SetWIPQTYInfo();
            inputControl1.UpdateDisplay();
        }
        private void ProcessC10EqConstantCommand()
        {
            C10EqConstantCmd Cmd = new C10EqConstantCmd();

            Cmd.Target.SrcEq = "LC";
            Cmd.Target.SrcUnit = "N/A";
            Cmd.Target.DesEq = "PLC1";
            Cmd.Target.DesUnit = "N/A";

            Cmd.Command = 2;
            Cmd.ByWho = eByWho.ByOperator;
            Cmd.EqConstants = LCData.EqConstants;

            eqComs[(int)eEqType.EQPLC1].SendC10EqConstantCmd(Cmd);
            sqlManager.SetEqConstant(Cmd.EqConstants);
        }
        private void IsExistCsttimer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Enabled = false;

            if (LCData.OnlineHostState == eMCMD.REMOTE)
            {
                int portNo = (int)timer.Tag;
                BatchManager BatchInfo = LCData.FindBatch(portNo);
                if (BatchInfo != null)
                {
                    int selectPort = (((int)timer.Tag) - 1) % 2;

                    if (BatchInfo.PortDatas[selectPort].Cassette == null && BatchInfo.PortDatas[selectPort].Port.PortState == ePortState.Wait)
                    {
                        C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();
                        ProcCmd.Target.SrcEq = "LC";
                        ProcCmd.Target.SrcUnit = "N/A";
                        ProcCmd.Target.DesEq = BatchInfo.PortDatas[selectPort].EqID;
                        ProcCmd.Target.DesUnit = BatchInfo.PortDatas[selectPort].UnitID;
                        ProcCmd.PortNo = BatchInfo.PortDatas[selectPort].Port.PortNo;
                        ProcCmd.Command = eRCMD.JobProcessCancel;

                        ProcCmd.CstID = BatchInfo.PortDatas[selectPort].Port.CstID;
                        ProcCmd.MapStif = LCData.GetEqMapping(BatchInfo.PortDatas[selectPort].Port.MapStif).ToString();
                        ProcCmd.StartStif = LCData.GetEqMapping(BatchInfo.PortDatas[selectPort].Port.CurStif).ToString();
                        ProcCmd.ByWho = eByWho.ByEquipment;
                        eqComs[(int)eEqType.EQPLC1].SendC14ProcessPortCmd(ProcCmd);


                        LogInfoData logInfo = LCData.FindLogInfo((short)eLogType.PC_CANCEL_ABNORMAL3);
                        if (logInfo != null)
                        {
                            SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[selectPort].Port.PortID, BatchInfo.PortDatas[selectPort].Port.CstID), BatchInfo.TARGET_LINE);
                        }             
                    }
                }
            }
        }
        private void portDataControl1_SelectPortEvent(int portNo)
        {
            ////--------------------------------------테스트용
            //LCData.OnlineHostState = eMCMD.LOCAL;
            //portInputForm.UpdateOnlineMode(eMCMD.LOCAL);
            ////-----------------------------------------------
            portInputForm.UpdateDisplay(portNo);
            portInputForm.DisplayView(portNo);
            portInputForm.ShowDialog();    
 
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                DialogResult result = MessageBox.Show("프로그램 초기화 하시겠습니까?", "초기화", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        foreach (BatchManager batchInfo in LCData.BatchManagers)
                        {
                            batchInfo.PANELID_STATE = eHPanelIDState.NONE;
                            batchInfo.UNIQUEID_STATE = eUniqueIDState.NONE;
                            batchInfo.BATCHID_STATE = eBatchIDState.NONE;                     

                            if (batchInfo.BatchDatas.Count > 0)
                            {
                                batchInfo.BatchDatas.Clear();
                            }

                            foreach (PortData portInfo in batchInfo.PortDatas)
                            {
                                portInfo.PAUSE_STATE = 0;
                                portInfo.ERROR_CODE = eERRCODE.NoError;    

                                if (portInfo.Cassette != null)
                                {
                                    portInfo.Cassette = null;
                                }
                                portDataControl1.UpdateDisplay(portInfo.Port.PortNo);
                            }
                            batchDataControl1.UpdateDisplay(batchInfo.TARGET_LINE);

                            logControl1.Init(batchInfo.TARGET_LINE);
                        }

                        LCData.SaveAll();



                        MessageBox.Show("[프로그램 초기화] 정상 처리 되었습니다.", "초기화", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("[프로그램 초기화] 진행중 문제가 발생되었습니다.", "초기화", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            C21ProcessPortCmdTest ProcCmd = new C21ProcessPortCmdTest();
            int nPortNo = 0;
            string strCount = "";

            nPortNo = m_nCount % 4;
            if (nPortNo == 0)
            {
                nPortNo = 4;
            }

            strCount = m_nCount.ToString();
            strCount = strCount.PadLeft(2, '0');

            ProcCmd.Target.SrcEq = "LC";
            ProcCmd.Target.SrcUnit = "N/A";
            ProcCmd.Target.DesEq = "PLC1";
            ProcCmd.Target.DesUnit = "Unit#" + nPortNo.ToString().PadLeft(2, '0');
            ProcCmd.PortNo = nPortNo;
            ProcCmd.Command = m_nCount;
            ProcCmd.CstID = "CST" + strCount;
            ProcCmd.MapStif = strCount;
            ProcCmd.StartStif = strCount;
            ProcCmd.ByWho = m_nCount + 3;
            eqComs[(int)eEqType.EQPLC1].SendC21ProcessPortCmdTest(ProcCmd);

            if (m_nCount <= 19)
            {
                m_nCount += 1;
            }
            else
            {
                m_nCount = 1;
            }
            
            
        }       
    }
}