using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassCore;
using System.Diagnostics;


namespace EqCore
{
	public partial class EqCom : Form
	{
		//변수
		private eEqType EqType = eEqType.EQPLC1;
		private Process appProcess = null;
		private string appPath = "";
		private string appArg = "";
		private bool connected = false;
		public bool Connected
		{
			get { return connected; }
		}


		//이벤트
		public delegate void EqReceivedEvent(object sender, EqEventArgs e);
		public event EqReceivedEvent OnEqReceived = null;



		//생성자 및 기본구문
		public EqCom()
		{
			InitializeComponent();
		}
		public void Init(EqData eqData)
		{
			this.EqType = eqData.EqType;
			coreNetOCX.IP = eqData.IP;
			coreNetOCX.Port = eqData.Port;
			coreNetOCX.Active = eqData.Active;
			
			coreNetOCX.LogEvent = false;
			coreNetOCX.LogMesgDetail = false;
			coreNetOCX.LogMesgSummary = false;
			coreNetOCX.LogPath = "c:\\";

			appPath = eqData.AppPath;
			appArg = eqData.AppArg;

            logManager.LogNameType = "yyyyMMdd_HH";
            logManager.LogFileType = ".txt";
            logManager.LogDeleteDay = LCData.HistoryPeriodSet.LogHistoryPeriod;
			logManager.LogFilePath = eqData.LogPath + "\\";

		}
		public int Start()
		{
			return coreNetOCX.Start();
		}
		public int Stop()
		{
			return coreNetOCX.Stop();
		}
        private void SendMessage(string str)
        {
            logManager.WriteLog("[SEND] " + str + "\r\n");
            coreNetOCX.SendString(str);
        }

		//이벤트처리
		private void coreNetOCX_OnConnection(object sender, EventArgs e)
		{
			if (OnEqReceived != null)
			{
				EqEventArgs args = new EqEventArgs(eEqEventType.Connect, EqType, null);
				OnEqReceived(sender, args);
			}
			connected = true;
		}
		private void coreNetOCX_OnClose(object sender, EventArgs e)
		{
			if (OnEqReceived != null)
			{
				EqEventArgs args = new EqEventArgs(eEqEventType.Disconnect, EqType, null);
				OnEqReceived(sender, args);
			}
			connected = false;
		}
		private void coreNetOCX_OnReceive(object sender, AxCoreNetLibLib._DCoreNetLibEvents_OnReceiveEvent e)
		{
			
			if (OnEqReceived != null)
			{
				EqEventArgs args = null;

				XMLParser msgXml = new XMLParser(coreNetOCX.GetString(e.nMsgID));
				XMLParser msgCmd = msgXml.GetElement("CMD");
				string type = msgCmd.GetText("TYPE");
				string command = msgCmd.GetText("COMMAND");

				switch (type)
				{
					case "EVENT":
						switch (command)
						{
							case "1":
								args = new EqEventArgs(eEqEventType.E1FlowRecipeEvent, EqType, ParseE1FlowRecipeEvent(msgXml));
								break;
							case "2":
								args = new EqEventArgs(eEqEventType.E2FlowGroupEvent, EqType, ParseE2FlowGroupEvent(msgXml));
								break;
                            case "12":
                                args = new EqEventArgs(eEqEventType.E12PortEvent, EqType, ParseE12PortEvent(msgXml));
                                break;
                            case "13":
                                args = new EqEventArgs(eEqEventType.E13PanelIDReqEvent, EqType, ParseE13PanelIDReqEvent(msgXml));
                                break;
                            case "14":
                                args = new EqEventArgs(eEqEventType.E14WIPQTYEvent, EqType, ParseE14WIPQTYEvent(msgXml));
                                break;
                            case "15":
                                args = new EqEventArgs(eEqEventType.E15BatchPauseEvent, EqType, ParseE15BatchPauseEvent(msgXml));
                                break;
                            case "16":
                                args = new EqEventArgs(eEqEventType.E16BatchResumeEvent, EqType, ParseE16BatchResumeEvent(msgXml));
                                break;
                            case "17":
                                args = new EqEventArgs(eEqEventType.E17InitialSynchEvent, EqType, ParseE17InitialSynchEvent(msgXml));
                                break;
                            case "18":
                                args = new EqEventArgs(eEqEventType.E18DuplicationEvent, EqType, ParseE18DuplicationEvent(msgXml));
                                break;
                            case "19":
                                args = new EqEventArgs(eEqEventType.E19OnlineStateEvent, EqType, ParseE19OnlineStateEvent(msgXml));
                                break;
                            case "20":
                                args = new EqEventArgs(eEqEventType.E20PLCSignalEvent, EqType, ParseE20PLCSignalEvent(msgXml));
                                break;
                            default:
								break;
						}
						break;

					case "REPORT":
						switch (command)
						{
							case "1":
								args = new EqEventArgs(eEqEventType.R1TransferGlassDataReport, EqType, ParseR1TransferGlassDataReport(msgXml));
								break;
							case "2":
								args = new EqEventArgs(eEqEventType.R2SetAlarmReport, EqType, ParseR2SetAlarmReport(msgXml));
								break;
							case "3":
								args = new EqEventArgs(eEqEventType.R3ResetAlarmReport, EqType, ParseR3ResetAlarmReport(msgXml));
								break;
							case "4":
								args = new EqEventArgs(eEqEventType.R4UnitStateReport, EqType, ParseR4UnitStateReport(msgXml));
								break;
							case "5":
								args = new EqEventArgs(eEqEventType.R5InitializeUnitStateReport, EqType, ParseR5InitializeUnitStateReport(msgXml));
								break;
							case "6":
								args = new EqEventArgs(eEqEventType.R6GlassControlReport, EqType, ParseR6GlassControlReport(msgXml));
								break;
							case "7":
								args = new EqEventArgs(eEqEventType.R7SignalBitsReport, EqType, ParseR7SignalBitsReport(msgXml));
								break;
							case "8":
								args = new EqEventArgs(eEqEventType.R8InitializeAlarmReport, EqType, ParseR8InitializeAlarmReport(msgXml));
								break;
							case "9":
								args = new EqEventArgs(eEqEventType.R9TactTimeReport, EqType, ParseR9TactTimeReport(msgXml));
								break;
							default:
								break;
						}
						break;

					default:
						break;
				}

				logManager.WriteLog("[RECV] " + msgXml.ToString() + "\r\n");
				OnEqReceived(sender, args);
			}
		}
		private void EqCom_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (!appProcess.CloseMainWindow())
				{
					appProcess.Kill();
				}
				appProcess.Close();
			}
			catch
			{
			}
		}

		//데이타 변환
		private TargetData GetTargetXml(XMLParser msgXml)
		{
			XMLParser msgTarget = msgXml.GetElement("TARGET");
			XMLParser msgSrc = msgTarget.GetElement("SOURCE");
			XMLParser msgDes = msgTarget.GetElement("DESTINATION");

			TargetData target = new TargetData();
			target.SrcEq = msgSrc.GetText("EQUIPMENT");
			target.SrcUnit = msgSrc.GetText("UNIT");
			target.DesEq = msgDes.GetText("EQUIPMENT");
			target.DesUnit = msgDes.GetText("UNIT");

			return target;
		}

        private E12PortEvent GetEventXml(eCEID EventID)
        {
            E12PortEvent report = null;     
            switch (EventID)
            {
                //case eCEID.CassetteLoadRequest:
                //    {
                //        E12LoadRequestEvent report = new E12LoadRequestEvent();
                //        return report;
                //    }
                //case eCEID.CassettePreLoad:
                //    {
                //        E12PreloadEvent report = new E12PreloadEvent();
                //        return report;
                //    }
                //case eCEID.CassetteClampOn:
                //    {
                //        E12ClampOnEvent report = new E12ClampOnEvent();
                //        return report;
                //    }
                //case eCEID.CassetteLoadComplete:
                //    {
                //        E12LoadCompleteEvent report = new E12LoadCompleteEvent();
                //        return report;
                //    }
                //case eCEID.CassetteUnloadRequest:
                //    {
                //        E12UnLoadRequestEvent report = new E12UnLoadRequestEvent();
                //        return report;
                //    }
                //case eCEID.CassetteUnloadComplete:
                //    {
                //        E12UnLoadCompleteEvent report = new E12UnLoadCompleteEvent();
                //        return report;
                //    }
                //case eCEID.CassetteLoadRejected:
                //    {
                //        E12LoadRejectEvent report = new E12LoadRejectEvent();
                //        return report;
                //    }
                //case eCEID.JobProcessStart:
                //    {
                //        E12JobStartEvent report = new E12JobStartEvent();
                //        return report;
                //    }
                //case eCEID.JobProcessCancel:
                //    {
                //        E12JobCancelEvent report = new E12JobCancelEvent();
                //        return report;
                //    }
                //case eCEID.JobProcessAbort:
                //    {
                //        E12JobAbortEvent report = new E12JobAbortEvent();
                //        return report;
                //    }
                //case eCEID.JobProcessEnd:
                //    {
                //        E12JobEndEvent report = new E12JobEndEvent();
                //        return report;
                //    }
                //case eCEID.PlanBatchPause:
                //    {
                //        E12BatchPauseEvent report = new E12BatchPauseEvent();
                //        return report;
                //    }
                //case eCEID.PlanBatchResume:
                //    {
                //        E12BatchResumeEvent report = new E12BatchResumeEvent();
                //        return report;
                //    }

                case eCEID.CassetteLoadRequest: report = new E12LoadRequestEvent();break;
                case eCEID.CassettePreLoad: report = new E12PreloadEvent(); break;
                case eCEID.CassetteClampOn: report = new E12ClampOnEvent(); break;
                case eCEID.CassetteLoadComplete: report = new E12LoadCompleteEvent(); break;
                case eCEID.CassetteUnloadRequest: report = new E12UnLoadRequestEvent(); break;
                case eCEID.CassetteUnloadComplete: report = new E12UnLoadCompleteEvent(); break;
                case eCEID.CassetteLoadRejected: report = new E12LoadRejectEvent(); break;
                case eCEID.JobProcessStart: report = new E12JobStartEvent(); break;
                case eCEID.JobProcessCancel: report = new E12JobCancelEvent(); break;
                case eCEID.JobProcessAbort: report = new E12JobAbortEvent(); break;
                case eCEID.JobProcessEnd: report = new E12JobEndEvent(); break;
                case eCEID.PlanBatchPause: report = new E12BatchPauseEvent(); break;
                case eCEID.PlanBatchResume: report = new E12BatchResumeEvent(); break;
            }
            return report;
        }

		private List<int> GetIntList(string str)
		{
			List<int> result = new List<int>();
			string[] splits = str.Split(' ');

			foreach (string split in splits)
			{
				int temp = 0;
				try
				{
					temp = int.Parse(split);
				}
				catch { }
				result.Add(temp);
			}
			return result;
		}
		private List<short> GetShortList(string str)
		{
			List<short> result = new List<short>();
			string[] splits = str.Split(' ');

			foreach (string split in splits)
			{
				short temp = 0;
				try
				{
					temp = short.Parse(split);
				}
				catch { }
				result.Add(temp);
			}
			return result;
		}
		private string GetListString(List<int> list)
		{
			string result = "";
			if (list.Count > 0)
			{
				foreach (int m in list)
				{
					result += m.ToString() + " ";
				}
				result = result.Substring(0, result.Length - 1);
			}
			return result;
		}
		private string GetListString(List<short> list)
		{
			string result = "";
			if (list.Count > 0)
			{
				foreach (short m in list)
				{
					result += m.ToString() + " ";
				}
				result = result.Substring(0, result.Length - 1);
			}
			return result;
		}
		private string GetListString(List<FlowGroupData> list)
		{
			string result = "";
			if (list.Count > 0)
			{
				int count = 0;
				foreach (FlowGroupData m in list)
				{
					result += m.Decimal.ToString() + " ";
					count++;
				}
				for (int i = count; i < 10; i++)
				{
					result += "0 ";
				}

				result = result.Substring(0, result.Length - 1);
			}
			return result;
		}
		private string GetListString(List<FlowBodyData> list)
		{
			string result = "";
			if (list.Count > 0)
			{
				int count = 0;
				foreach (FlowBodyData m in list)
				{
					result += m.Decimal.ToString() + " ";
					count++;
				}
				for (int i = count; i < 10; i++)
				{
					result += "0 ";
				}
				result = result.Substring(0, result.Length - 1);
			}
			return result;
		}



		//Parse Xml메세지
		private R1TransferGlassDataReport ParseR1TransferGlassDataReport(XMLParser msgXml)
		{
			R1TransferGlassDataReport report = new R1TransferGlassDataReport();
			report.Target = GetTargetXml(msgXml);

			XMLParser msgInfo = msgXml.GetElement("INFO");
			report.EventID = (eCEID)msgInfo.GetInt("EVENTID");
			report.Glass.HPanelID = msgInfo.GetText("H_PANELID");
			report.Glass.EPanelID = msgInfo.GetText("E_PANELID");
			report.Glass.ProcessID = msgInfo.GetText("PROCESSID");
			report.Glass.ProductID = msgInfo.GetText("PRODUCTID");
			report.Glass.StepID = msgInfo.GetText("STEPID");
			report.Glass.BatchID = msgInfo.GetText("BATCHID");
			report.Glass.ProdType = msgInfo.GetText("PROD_TYPE");
			report.Glass.ProdKind = msgInfo.GetText("PROD_KIND");
			report.Glass.PPID = msgInfo.GetText("PPID");
			report.Glass.FlowID = msgInfo.GetText("FLOWID");
			report.Glass.PanelSize = GetIntList(msgInfo.GetText("PANEL_SIZE"));
			report.Glass.Thickness = msgInfo.GetInt("THICKNESS");
			report.Glass.CompCount = msgInfo.GetInt("COMP_COUNT");

			report.Glass.PanelOtherProp1.PanelState = (ePanelState)msgInfo.GetInt("PANEL_STATE");
			report.Glass.PanelOtherProp1.ReadingFlag = msgInfo.GetText("READING_FLAG");
			report.Glass.PanelOtherProp1.InsFlag = msgInfo.GetText("INS_FLAG");
			report.Glass.PanelOtherProp1.PanelPosition = msgInfo.GetText("PANEL_POSITION");
			report.Glass.PanelOtherProp1.Judgement = msgInfo.GetText("JUDGEMENT");
			report.Glass.PanelOtherProp1.Code = msgInfo.GetText("CODE");
			report.Glass.PanelOtherProp1.FlowHistorys = GetShortList(msgInfo.GetText("FLOW_HISTORY"));
			report.Glass.PanelOtherProp1.UniqueID = GetShortList(msgInfo.GetText("UNIQUEID"));

			report.Glass.PanelOtherProp2.Count1 = msgInfo.GetText("COUNT1");
			report.Glass.PanelOtherProp2.Count2 = msgInfo.GetText("COUNT2");
			report.Glass.PanelOtherProp2.Grade = msgInfo.GetText("GRADE");
			report.Glass.PanelOtherProp2.MultiUse = msgInfo.GetText("MULTI_USE");
			report.Glass.PanelOtherProp2.BitSignal = msgInfo.GetText("GLASS_DATA");

            report.Glass.PanelPairProp.PairHPanelID = msgInfo.GetText("PAIR_H_PANELID");
            report.Glass.PanelPairProp.PairEPanelID = msgInfo.GetText("PAIR_E_PANELID");
            report.Glass.PanelPairProp.PairProductID = msgInfo.GetText("PAIR_PRODUCTID");
            report.Glass.PanelPairProp.PairGrade = msgInfo.GetText("PAIR_GRADE");
  
			List<int> flowGroups = GetIntList(msgInfo.GetText("FLOW_GROUP"));
			foreach (int flowGroup in flowGroups)
			{
				FlowGroupData flowData = new FlowGroupData();
				flowData.Decimal = flowGroup;
				report.Glass.FlowGroups.Add(flowData);
			}
			report.Glass.DBRRecipe = msgInfo.GetText("DBR_RECIPE");
			report.Glass.Refer = msgInfo.GetText("REFER");
            report.Glass.SlotID = msgInfo.GetText("SLOTID");
			report.Glass.FromEqNo = msgInfo.GetInt("FROM_EQNO");
			report.Glass.ToEqNo = msgInfo.GetInt("TO_EQNO");
			
			return report;
		}
		private R2SetAlarmReport ParseR2SetAlarmReport(XMLParser msgXml)
		{
            R2SetAlarmReport report = new R2SetAlarmReport();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            int value = msgInfo.GetInt("VALUE");

            if (report.Target.SrcUnit.Substring(0, 6).ToUpper() == eAlarmSection.MASTER.ToString())
            {
                if (value > 30)
                {
                    report.AlarmSection = eAlarmSection.PIO;
                }
                else
                {
                    report.AlarmSection = eAlarmSection.MASTER;
                }
                report.AlarmID = value;
            }
            else if (report.Target.SrcUnit.Substring(0, 4).ToUpper() == eAlarmSection.UNIT.ToString())
            {
                report.AlarmSection = eAlarmSection.UNIT;

                report.AlarmID = value + 200;

            }

            return report;
		}
		private R3ResetAlarmReport ParseR3ResetAlarmReport(XMLParser msgXml)
		{
            R3ResetAlarmReport report = new R3ResetAlarmReport();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            int value = msgInfo.GetInt("VALUE");

            if (report.Target.SrcUnit.Substring(0, 6).ToUpper() == eAlarmSection.MASTER.ToString())
            {
                if (value > 30)
                {
                    report.AlarmSection = eAlarmSection.PIO;
                }
                else
                {
                    report.AlarmSection = eAlarmSection.MASTER;
                }
                report.AlarmID = value;
            }
            else if (report.Target.SrcUnit.Substring(0, 4).ToUpper() == eAlarmSection.UNIT.ToString())
            {
                report.AlarmSection = eAlarmSection.UNIT;
                report.AlarmID = value + 200;
            }

            return report;
		}
		private R4UnitStateReport ParseR4UnitStateReport(XMLParser msgXml)
		{
			R4UnitStateReport report = new R4UnitStateReport();
			report.Target = GetTargetXml(msgXml);

			XMLParser msgInfo = msgXml.GetElement("INFO");
			report.PMCode = msgInfo.GetText("PM");
			report.PauseCode = msgInfo.GetText("PAUSE");
			report.EqState = (eEqState)msgInfo.GetInt("EQ_STATE");
			report.ProcState = (eProcState)msgInfo.GetInt("PROCESS_STATE");
			report.EqByWho = (eByWho)msgInfo.GetInt("EQ_BYWHO");
			report.ProcByWho = (eByWho)msgInfo.GetInt("PROCESS_BYWHO");

			return report;
		}
		private R5InitializeUnitStateReport ParseR5InitializeUnitStateReport(XMLParser msgXml)
		{
			R5InitializeUnitStateReport report = new R5InitializeUnitStateReport();
			report.Target = GetTargetXml(msgXml);

			List<XMLParser> msgInfos = msgXml.GetElements("INFO");
			foreach (XMLParser msgInfo in msgInfos)
			{
				R4UnitStateReport unit = new R4UnitStateReport();
				unit.Target.SrcUnit = msgInfo.GetText("ID");
				unit.EqState = (eEqState)msgInfo.GetInt("EQ_STATE");
				unit.ProcState = (eProcState)msgInfo.GetInt("PROCESS_STATE");
				report.Units.Add(unit);
			}

			return report;
		}
		private R6GlassControlReport ParseR6GlassControlReport(XMLParser msgXml)
		{
			R6GlassControlReport report = new R6GlassControlReport();
			report.Target = GetTargetXml(msgXml);

			XMLParser msgInfo = msgXml.GetElement("INFO");
			report.EventID = (eCEID)msgInfo.GetInt("ID");
			report.HPanelID = msgInfo.GetText("H_PANELID");
			report.BrokenCode = msgInfo.GetText("BROKEN");

			return report;
		}
		private R7SignalBitsReport ParseR7SignalBitsReport(XMLParser msgXml)
		{
			R7SignalBitsReport report = new R7SignalBitsReport();
			report.Target = GetTargetXml(msgXml);

			XMLParser msgInfo = msgXml.GetElement("INFO");
			report.Signal = (eCEID)msgInfo.GetInt("SIGNAL");
			report.Refuse = msgInfo.GetText("REFUSE");

			return report;
		}
		private R8InitializeAlarmReport ParseR8InitializeAlarmReport(XMLParser msgXml)
		{
			R8InitializeAlarmReport report = new R8InitializeAlarmReport();
			report.Target = GetTargetXml(msgXml);

			List<XMLParser> msgInfos = msgXml.GetElements("INFO");
			foreach (XMLParser msgInfo in msgInfos)
			{
				R2SetAlarmReport alarm = new R2SetAlarmReport();
				alarm.Target.SrcUnit = msgInfo.GetText("UNIT");
				int value = msgInfo.GetInt("VALUE");

				if (alarm.Target.SrcUnit.Substring(0, 6).ToUpper() == eAlarmSection.MASTER.ToString())
                {
    				alarm.AlarmSection = eAlarmSection.MASTER;
					alarm.AlarmID = value;
				}
				else if (alarm.Target.SrcUnit.Substring(0, 4).ToUpper() == eAlarmSection.UNIT.ToString())
				{
					alarm.AlarmSection = eAlarmSection.UNIT;
				    alarm.AlarmID = value + 200;
				}
				report.Alarms.Add(alarm);
			}

			return report;
		}
		private R9TactTimeReport ParseR9TactTimeReport(XMLParser msgXml)
		{
			R9TactTimeReport report = new R9TactTimeReport();
			report.Target = GetTargetXml(msgXml);

			XMLParser msgInfo = msgXml.GetElement("INFO");
			report.PPID = msgInfo.GetText("PPID");
			report.SetTact = msgInfo.GetInt("SET");
			report.CurrentTact = msgInfo.GetInt("CURRENT");

			return report;
		}

		private E1FlowRecipeEvent ParseE1FlowRecipeEvent(XMLParser msgXml)
		{
			E1FlowRecipeEvent report = new E1FlowRecipeEvent();
			report.Target = GetTargetXml(msgXml);

			XMLParser msgInfo = msgXml.GetElement("INFO");
			report.EventID = msgInfo.GetInt("ID");

			XMLParser msgFlow = msgInfo.GetElement("FLOW");
			report.FlowRecipe.FlowNo = msgFlow.GetInt("NO");
			report.FlowRecipe.FlowID = msgFlow.GetText("ID");
			report.FlowRecipe.Revision = msgFlow.GetText("REVISION").PadLeft(6, '0');
			report.FlowRecipe.UpdateTime = msgFlow.GetText("TIME");

			List<int> rawDatas = GetIntList(msgFlow.GetText("BODY"));
			foreach (int rawData in rawDatas)
			{
				if (rawData != 0)
				{
					FlowBodyData flowData = new FlowBodyData();
					flowData.Decimal = rawData;
					report.FlowRecipe.FlowDatas.Add(flowData);
				}
			}

			return report;
		}
		private E2FlowGroupEvent ParseE2FlowGroupEvent(XMLParser msgXml)
		{
			E2FlowGroupEvent report = new E2FlowGroupEvent();
			report.Target = GetTargetXml(msgXml);

			XMLParser msgInfo = msgXml.GetElement("INFO");
			report.EventID = msgInfo.GetInt("ID");

			List<int> rawDatas = GetIntList(msgInfo.GetText("BODY"));
			foreach (int rawData in rawDatas)
			{
				if (rawData != 0)
				{
					FlowGroupData flowGroup = new FlowGroupData();
					flowGroup.Decimal = rawData;
					report.FlowGroups.Add(flowGroup);
				}
			}

			return report;
		}      
        private E12PortEvent ParseE12PortEvent(XMLParser msgXml)
        {
            E12PortEvent report = GetEventXml((eCEID)msgXml.GetInt("EVENTID")); 
          
            if (report != null)
            {
                report.Target = GetTargetXml(msgXml);
                XMLParser msgInfo = msgXml.GetElement("INFO");
                report.Port.PortNo = msgInfo.GetInt("PORT");
                report.Port.PortEvent = (eCEID)msgInfo.GetShort("EVENTID");
                report.Port.PortID = msgInfo.GetText("PORTID");
                report.Port.PortState = (ePortState)msgInfo.GetShort("PORT_STATE");
                report.Port.PortType = (ePortType)msgInfo.GetShort("PORT_TYPE");
                report.Port.PortMode = msgInfo.GetText("PORT_MODE");
                report.Port.SortType = (eSortType)msgInfo.GetShort("SORT_TYPE");
                report.Port.CstDemand = (eCstDemand)msgInfo.GetShort("CST_DEMAND");
                report.Port.CstID = msgInfo.GetText("CSTID");
                report.Port.CstType = msgInfo.GetText("CST_TYPE");
                report.Port.MapStif = msgInfo.GetText("MAT_STIF", "0");
                report.Port.CurStif = msgInfo.GetText("CUR_STIF", "0");
                report.Port.BatchOrder = (eBatchOrder)msgInfo.GetShort("BATCH_ORDER");
                report.Port.ByWho = (eByWho)msgInfo.GetShort("BYWHO");
                report.Port.ReplyMsg = (eReply)msgInfo.GetShort("REPLY");                
            }
            return report;
        }
        private E13PanelIDReqEvent ParseE13PanelIDReqEvent(XMLParser msgXml)
        {
            E13PanelIDReqEvent report = new E13PanelIDReqEvent();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            report.PortNo = (short)msgInfo.GetInt("PORT");
           
            return report;
        }

        private E14WIPQTYEvent ParseE14WIPQTYEvent(XMLParser msgXml)
        {
            E14WIPQTYEvent report = new E14WIPQTYEvent();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            report.WIPQTY1P1 = msgInfo.GetInt("WIPQTY1P1");
            report.WIPQTY1P2 = msgInfo.GetInt("WIPQTY1P2");
            report.WIPQTY2P1 = msgInfo.GetInt("WIPQTY2P1");
            report.WIPQTY2P2 = msgInfo.GetInt("WIPQTY2P2");
           
            return report;
        }

        
        private E15BatchPauseEvent ParseE15BatchPauseEvent(XMLParser msgXml)
        {
            E15BatchPauseEvent report = new E15BatchPauseEvent();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            report.PortNo = (short)msgInfo.GetInt("PORT");

            return report;
        }

        private E16BatchResumeEvent ParseE16BatchResumeEvent(XMLParser msgXml)
        {
            E16BatchResumeEvent report = new E16BatchResumeEvent();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            report.PortNo = (short)msgInfo.GetInt("PORT");

            return report;
        }

        private E17InitialSynchEvent ParseE17InitialSynchEvent(XMLParser msgXml)
        {
            E17InitialSynchEvent report = new E17InitialSynchEvent();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            report.PortNo = (short)msgInfo.GetInt("PORT");

            return report;
        }

        private E18DuplicationEvent ParseE18DuplicationEvent(XMLParser msgXml)
        {
            E18DuplicationEvent report = new E18DuplicationEvent();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            report.PortNo = (short)msgInfo.GetInt("PORT");
            report.HPanelID = msgInfo.GetText("HPANELID");
            report.UniqueID = msgInfo.GetText("UNIQUEID");
            report.ResultHPanelID = (short)msgInfo.GetInt("RESULT1");
            report.ResultUniqueID = (short)msgInfo.GetInt("RESULT2");
            report.ResultBatchID = (short)msgInfo.GetInt("RESULT3"); 
            return report;
        }
        private E19OnlineStateEvent ParseE19OnlineStateEvent(XMLParser msgXml)
        {
            E19OnlineStateEvent report = new E19OnlineStateEvent();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            report.ConnectionState = (short)msgInfo.GetInt("RESULT");
            return report;
        }
        private E20PLCSignalEvent ParseE20PLCSignalEvent(XMLParser msgXml)
        {
            E20PLCSignalEvent report = new E20PLCSignalEvent();
            report.Target = GetTargetXml(msgXml);

            XMLParser msgInfo = msgXml.GetElement("INFO");
            report.PortNo = (short)msgInfo.GetInt("PORT");
            report.SigID = (short)msgInfo.GetInt("SIGNALID");
            report.Result = (short)msgInfo.GetInt("RESULT");
            return report;
        } 
		//Send Xml메세지
		private void SetTargetXml(XMLParser msgXml, TargetData target)
		{
			msgXml.SetStartElement("TARGET");
			{
				msgXml.SetStartElement("SOURCE");
				{
					msgXml.SetText("EQUIPMENT", target.SrcEq);
					msgXml.SetText("UNIT", target.SrcUnit);
				}
				msgXml.SetEndElement();
				msgXml.SetStartElement("DESTINATION");
				{
					msgXml.SetText("EQUIPMENT", target.DesEq);
					msgXml.SetText("UNIT", target.DesUnit);
				}
				msgXml.SetEndElement();
			}
			msgXml.SetEndElement();
		}
		private void SetCmdXml(XMLParser msgXml, eEqEventType eqEventType)
		{
			msgXml.SetStartElement("CMD");
			{
				switch (eqEventType)
				{
					case eEqEventType.C1DateTimeSetCmd:
						msgXml.SetText("TYPE", "COMMAND");
						msgXml.SetText("COMMAND", "1");
						break;

					case eEqEventType.C2EquipmentCmd:
						msgXml.SetText("TYPE", "COMMAND");
						msgXml.SetText("COMMAND", "2");
						break;

					case eEqEventType.C3FlowRecipeCmd:
						msgXml.SetText("TYPE", "COMMAND");
						msgXml.SetText("COMMAND", "3");
						break;

					case eEqEventType.C4FlowGroupCmd:
						msgXml.SetText("TYPE", "COMMAND");
						msgXml.SetText("COMMAND", "4");
						break;

					case eEqEventType.C6SamplingDefineCmd:
						msgXml.SetText("TYPE", "COMMAND");
						msgXml.SetText("COMMAND", "6");
						break;

					case eEqEventType.C7EqOnlineParameterCmd:
						msgXml.SetText("TYPE", "COMMAND");
						msgXml.SetText("COMMAND", "7");
						break;

					case eEqEventType.C10EqConstantCmd:
						msgXml.SetText("TYPE", "COMMAND");
						msgXml.SetText("COMMAND", "10");
						break;

					case eEqEventType.C11MessageCmd:
						msgXml.SetText("TYPE", "COMMAND");
						msgXml.SetText("COMMAND", "11");
						break;
                    case eEqEventType.C14ProcessPortCmd:
                        msgXml.SetText("TYPE", "COMMAND");
                        msgXml.SetText("COMMAND", "14");
                        break;
                    case eEqEventType.C15CassetteinfoCmd:
                        msgXml.SetText("TYPE", "COMMAND");
                        msgXml.SetText("COMMAND", "15");
                        break;
                    case eEqEventType.C16PanelInfoCmd:
                        msgXml.SetText("TYPE", "COMMAND");
                        msgXml.SetText("COMMAND", "16");
                        break;
                    case eEqEventType.C17WIPQTYInfoCmd:
                        msgXml.SetText("TYPE", "COMMAND");
                        msgXml.SetText("COMMAND", "17");
                        break;
                    case eEqEventType.C21ProcessPortCmdTest:
                        msgXml.SetText("TYPE", "COMMAND");
                        msgXml.SetText("COMMAND", "21");
                        break;

					default:
						break;
				}
			}
			msgXml.SetEndElement();
		}

		public void SendC1DateTimeSetCmd(C1DateTimeSetCmd msg)
		{
			XMLParser msgXml = new XMLParser();
			msgXml.SetStartElement("MSG");
			{
				SetTargetXml(msgXml, msg.Target);
				SetCmdXml(msgXml, eEqEventType.C1DateTimeSetCmd);

				msgXml.SetStartElement("INFO");
				{
					msgXml.SetText("DATETIME", msg.DataTime);
				}
				msgXml.SetEndElement();
			}
			msgXml.SetEndElement();

			SendMessage(msgXml.ToString());
		}
		public void SendC2EquipmentCmd(C2EquipmentCmd msg)
		{
			XMLParser msgXml = new XMLParser();
			msgXml.SetStartElement("MSG");
			{
				SetTargetXml(msgXml, msg.Target);
				SetCmdXml(msgXml, eEqEventType.C2EquipmentCmd);

				msgXml.SetStartElement("INFO");
				{
					msgXml.SetInt("COMMAND", (short)msg.Command);
					msgXml.SetText("CODE", msg.Code);
					msgXml.SetInt("BYWHO", (short)msg.ByWho);
				}
				msgXml.SetEndElement();
			}
			msgXml.SetEndElement();

			SendMessage(msgXml.ToString());
		}
		public void SendC3FlowRecipeCmd(C3FlowRecipeCmd msg)
		{
			XMLParser msgXml = new XMLParser();
			msgXml.SetStartElement("MSG");
			{
				SetTargetXml(msgXml, msg.Target);
				SetCmdXml(msgXml, eEqEventType.C3FlowRecipeCmd);

				msgXml.SetStartElement("INFO");
				{
					msgXml.SetInt("COMMAND", msg.Command);
					msgXml.SetInt("NO", msg.FlowRecipe.FlowNo);
					msgXml.SetText("ID", msg.FlowRecipe.FlowID);
					msgXml.SetText("REVISION", msg.FlowRecipe.Revision);
					msgXml.SetText("TIME", msg.FlowRecipe.UpdateTime);
					msgXml.SetText("BODY", GetListString(msg.FlowRecipe.FlowDatas));
				}
				msgXml.SetEndElement();
			}
			msgXml.SetEndElement();

			SendMessage(msgXml.ToString());
		}
		public void SendC4FlowGroupCmd(C4FlowGroupCmd msg)
		{
			XMLParser msgXml = new XMLParser();
			msgXml.SetStartElement("MSG");
			{
				SetTargetXml(msgXml, msg.Target);
				SetCmdXml(msgXml, eEqEventType.C4FlowGroupCmd);

				msgXml.SetStartElement("INFO");
				{
					msgXml.SetInt("COMMAND", msg.Command);
					msgXml.SetText("BODY", GetListString(msg.FlowGroups));
				}
				msgXml.SetEndElement();
			}
			msgXml.SetEndElement();

			SendMessage(msgXml.ToString());
		}
		
		
		public void SendC10EqConstantCmd(C10EqConstantCmd msg)
		{
			XMLParser msgXml = new XMLParser();
			msgXml.SetStartElement("MSG");
			{
				SetTargetXml(msgXml, msg.Target);
				SetCmdXml(msgXml, eEqEventType.C10EqConstantCmd);

				msgXml.SetStartElement("INFO");
				{
					msgXml.SetInt("COMMAND", msg.Command);
                    msgXml.SetInt("BYWHO", (short)msg.ByWho);

					foreach (EqConstantData eqConstant in msg.EqConstants)
					{
						msgXml.SetStartElement("DATA");
						{
							msgXml.SetInt("ECID", eqConstant.ECID);
							msgXml.SetText("ECDEF", eqConstant.ECDEF);
							msgXml.SetText("ECSLL", eqConstant.ECSLL);
							msgXml.SetText("ECSUL", eqConstant.ECSUL);
							msgXml.SetText("ECWLL", eqConstant.ECWLL);
							msgXml.SetText("ECWUL", eqConstant.ECWUL);
						}
						msgXml.SetEndElement();
					}
				}
				msgXml.SetEndElement();
			}
			msgXml.SetEndElement();

			SendMessage(msgXml.ToString());
		}
		public void SendC11MessageCmd(C11MessageCmd msg)
		{
			XMLParser msgXml = new XMLParser();
			msgXml.SetStartElement("MSG");
			{
				SetTargetXml(msgXml, msg.Target);
				SetCmdXml(msgXml, eEqEventType.C11MessageCmd);

				msgXml.SetStartElement("INFO");
				{
					msgXml.SetShort("NUM", msg.Num);
					msgXml.SetText("TERMINAL", msg.Terminal);
					msgXml.SetText("OPCALL", msg.OpCall);
				}
				msgXml.SetEndElement();
			}
			msgXml.SetEndElement();

			SendMessage(msgXml.ToString());
		}
        public void SendC14ProcessPortCmd(C14ProcessPortCmd msg)
        {
            XMLParser msgXml = new XMLParser();
            msgXml.SetStartElement("MSG");
            {
                SetTargetXml(msgXml, msg.Target);
                SetCmdXml(msgXml, eEqEventType.C14ProcessPortCmd);

                msgXml.SetStartElement("INFO");
                {
                    msgXml.SetInt("PORT", msg.PortNo);
                    msgXml.SetInt("ID", (short)msg.Command);
                    msgXml.SetText("CSTID", msg.CstID);
                    msgXml.SetText("MAT_STIF", msg.MapStif);
                    msgXml.SetText("START_STIF", msg.StartStif);
                    msgXml.SetInt("BYWHO", (short)msg.ByWho);
                }
                msgXml.SetEndElement();
            }
            msgXml.SetEndElement();

            SendMessage(msgXml.ToString());
        }
        public void SendC21ProcessPortCmdTest(C21ProcessPortCmdTest msg)
        {
            XMLParser msgXml = new XMLParser();
            msgXml.SetStartElement("MSG");
            {
                SetTargetXml(msgXml, msg.Target);
                SetCmdXml(msgXml, eEqEventType.C21ProcessPortCmdTest);

                msgXml.SetStartElement("INFO");
                {
                    msgXml.SetInt("PORT", msg.PortNo);
                    msgXml.SetInt("ID", msg.Command);
                    msgXml.SetText("CSTID", msg.CstID);
                    msgXml.SetText("MAT_STIF", msg.MapStif);
                    msgXml.SetText("START_STIF", msg.StartStif);
                    msgXml.SetInt("BYWHO", msg.ByWho);
                }
                msgXml.SetEndElement();
            }
            msgXml.SetEndElement();

            SendMessage(msgXml.ToString());
        }
        public void SendC15CassetteInfoCmd(C15CassetteInfoCmd msg)
        {
            XMLParser msgXml = new XMLParser();
            msgXml.SetStartElement("MSG");
            {
                SetTargetXml(msgXml, msg.Target);
                SetCmdXml(msgXml, eEqEventType.C15CassetteinfoCmd);

                msgXml.SetStartElement("INFO");
                {   
                    msgXml.SetText("PORT", msg.PortNo);
                    msgXml.SetText("PROCESSID", msg.ProcessID);
                    msgXml.SetText("PRODUCTID", msg.ProductID);
                    msgXml.SetText("STEPID", msg.StepID);
                    msgXml.SetText("BATCHID", msg.BatchID);
                    msgXml.SetText("PROD_TYPE", msg.ProdType);
                    msgXml.SetText("PROD_KIND", msg.ProdKind);
                    msgXml.SetText("PPID", msg.PPID);
                    msgXml.SetText("FLOWID", msg.FlowID);
                    msgXml.SetText("PANEL_SIZE", msg.PanelSize);
                    msgXml.SetInt("THICKNESS", msg.Thickness);
                    msgXml.SetInt("COMP_COUNT", msg.CompCount);
                    msgXml.SetText("PANEL_STATE", msg.PanelState);
                    msgXml.SetText("READING_FLAG", msg.ReadingFlg);
                    msgXml.SetText("INS_FLAG", msg.InsFlg);
                    msgXml.SetText("PANEL_POSITION", msg.PanelPosition);
                    msgXml.SetText("JUDGEMENT", msg.Judgement);
                    msgXml.SetText("CODE", msg.Code);
                    msgXml.SetText("FLOW_HISTORY", msg.FlowHistory);
                    msgXml.SetText("COUNT1", msg.Count1);
                    msgXml.SetText("COUNT2", msg.Count2);
                    msgXml.SetText("GRADE", msg.Grade );
                    msgXml.SetText("GLASS_DATA", msg.GlassDataSignal);
                    msgXml.SetText("PAIR_H_PANELID", msg.PairHPanelID);
                    msgXml.SetText("PAIR_E_PANELID", msg.PairEPanelID);
                    msgXml.SetText("PAIR_PRODUCTID", msg.PairProductiD);
                    msgXml.SetText("PAIR_GRADE", msg.PairGrade);
                    msgXml.SetText("FLOW_GROUP", msg.FlowGroup);
                    msgXml.SetText("DBR_RECIPE", msg.DBRRecipe);
                    msgXml.SetText("REFER", msg.ReferData);
                }
                msgXml.SetEndElement();
            }
            msgXml.SetEndElement();

            SendMessage(msgXml.ToString());
        }

        public void SendC16PanelInfoCmd(C16PanelInfoCmd msg)
        {
            XMLParser msgXml = new XMLParser();
            msgXml.SetStartElement("MSG");
            {
                SetTargetXml(msgXml, msg.Target);
                SetCmdXml(msgXml, eEqEventType.C16PanelInfoCmd);

                msgXml.SetStartElement("INFO");
                {
                    msgXml.SetText("PORT", msg.PortNo);
                    msgXml.SetText("HPANELID", msg.HPanelID);
                    msgXml.SetText("UNIQUEID", msg.UniqueID);
                }
                msgXml.SetEndElement();
            }
            msgXml.SetEndElement();

            SendMessage(msgXml.ToString());
        }

        public void SendC17WIPQTYInfoCmd(C17WIPQTYInfoCmd msg)
        {
            XMLParser msgXml = new XMLParser();
            msgXml.SetStartElement("MSG");
            {
                SetTargetXml(msgXml, msg.Target);
                SetCmdXml(msgXml, eEqEventType.C17WIPQTYInfoCmd);

                msgXml.SetStartElement("INFO");
                {
                    msgXml.SetText("LIMITWIPQTY1", msg.WIPQTY1);
                    msgXml.SetText("LIMITWIPQTY2", msg.WIPQTY2);
                }
                msgXml.SetEndElement();
            }
            msgXml.SetEndElement();

            SendMessage(msgXml.ToString());
        }

		//타이머
		private void timerSecond10_Tick(object sender, EventArgs e)
		{
			try
			{
				if (appPath != "")
				{
                    if (appProcess == null || appProcess.HasExited)
					{
    				    appProcess = System.Diagnostics.Process.Start(this.appPath,"");
					}
				}
			}
			catch
			{
			}
		}
	}
}