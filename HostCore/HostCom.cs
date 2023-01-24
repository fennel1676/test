using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassCore;

namespace HostCore
{
	public partial class HostCom : HostCore.XGateForm
	{
		//변수
		private eHostType HostType = eHostType.Host;
        private int items, items1, items2, items3, items4, items5, items6, items7;
		private bool connected = false;
		public bool Connected
		{
			get { return connected; }
		}

		//이벤트
		public delegate void HostReceivedEvent(object sender, HostEventArgs e);
		public event HostReceivedEvent OnHostReceived = null;



		//생성자 및 기본구문
		public HostCom()
		{
			InitializeComponent();
			this.OnSelected += new HostCore.XGateForm.SelectedEvent(this.HostCom_OnSelected);
			this.OnDisconnected += new HostCore.XGateForm.DisconnectedEvent(this.HostCom_OnDisconnected);
			this.OnRecvSecsMsg += new HostCore.XGateForm.RecvSecsMsgEvent(this.HostCom_OnRecvSecsMsg);
		}
		public void Init(HostData hostData)
		{
			this.HostType = hostData.HostType;
			this.RemoteAddress = hostData.IP;
			this.ListenPortNo = hostData.Port;
			this.ConnectPortNo = hostData.Port;
			
			this.SecsType = XGateSecsType.Hsms;
			if (hostData.Active) this.HsmsMode = XGateHsmsMode.Active;
			else this.HsmsMode = XGateHsmsMode.Passive;

			this.T1TimeOut = hostData.T1;
			this.T2TimeOut = hostData.T2;
			this.T3TimeOut = hostData.T3;
			this.T4TimeOut = hostData.T4;
			this.T5TimeOut = hostData.T5;
			this.T6TimeOut = hostData.T6;
			this.T7TimeOut = hostData.T7;
			this.T8TimeOut = hostData.T8;
			this.LinkTestCycleTime = hostData.LinkInterval;

			this.Secs1Log = XGateLogMode.Enabled;
			this.Secs2Log = XGateLogMode.Enabled;
            this.LogFilePath = hostData.LogPath;

            logManager.LogNameType = "yyyyMMdd_HH";
            logManager.LogFileType = ".log";
            logManager.LogDeleteDay = LCData.HistoryPeriodSet.LogHistoryPeriod;
            //logManager.LogFilePath = hostData.LogPath + "\\" + "SECS-II LOG" + "\\" + "X-Gate_SECS-II_";
            logManager.LogFilePath = hostData.LogPath + "\\" + "SECS-II LOG" + "\\";
		}
		public int Start()
		{
            return this.StartXGate();
		}
		public int Stop()
		{
			return this.StopXGate();
		}
		private void SendMessage()
		{
			//logManager.WriteLog("[SEND] " + this.GetSendMsg());
			this.SendSecsMsg(this.GetSendMsg());
		}

		//이벤트처리
		private void HostCom_OnSelected(object sender, EventArgs e)
		{
			if (OnHostReceived != null)
			{
				HostEventArgs args = new HostEventArgs(eHostEventType.Connect, HostType, null);
				OnHostReceived(sender, args);
			}
			connected = true;
		}
		private void HostCom_OnDisconnected(object sender, EventArgs e)
		{
			if (OnHostReceived != null)
			{
				HostEventArgs args = new HostEventArgs(eHostEventType.Disconnect, HostType, null);
				OnHostReceived(sender, args);
			}
			connected = false;
		}
		private void HostCom_OnSecsTimeOut(object sender, AxXGateLib._DXProPlusEvents_OnSecsTimeOutEvent e)
		{
			if (OnHostReceived != null)
			{
				HostEventArgs args = new HostEventArgs(eHostEventType.TimeOut, HostType, null);
				OnHostReceived(sender, args);
			}
		}
		private void HostCom_OnRecvSecsMsg(object sender, AxXGateLib._DXProPlusEvents_OnSecsMsgEvent e)
		{
			if (e.nFunction == 0) return;
			if (OnHostReceived != null)
			{
				HostEventArgs args = null;

				bool unrecognizedStream = false;
				bool unrecognizedFunction = false;
				bool illegalData = false;
				
				try
				{
					switch (e.nStream)
					{
						case 1:
                            switch (e.nFunction)
                            {
                                case 0:
                                    break;
                                case 1:
                                    args = new HostEventArgs(eHostEventType.S1F1AreYouThere, HostType, ParseS1F1AreYouThere());
                                    break;
                                case 2:
                                    args = new HostEventArgs(eHostEventType.S1F2OnLineData, HostType, ParseS1F2OnLineData());
                                    break;
                                case 5:
                                    args = new HostEventArgs(eHostEventType.S1F5FormattedStateRequest, HostType, ParseS1F5FormattedStateRequest());
                                    break;
                                case 17:
                                    args = new HostEventArgs(eHostEventType.S1F17RequestOnLine, HostType, ParseS1F17RequestOnLine());
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
                            }
							break;

						case 2:
							switch (e.nFunction)
							{
                                case 0:
                                    break;
                                case 31:
                                    args = new HostEventArgs(eHostEventType.S2F31DateTimeSetRequest, HostType, ParseS2F31DateTimeSetRequest());
                                    break;
                                case 41:
                                    args = new HostEventArgs(eHostEventType.S2F41HostCommand, HostType, ParseS2F41HostCommand());
                                    break;
                                case 103:
                                    args = new HostEventArgs(eHostEventType.S2F103EqOnlineParameterChange, HostType, ParseS2F103EqOnlineParameterChange());
                                    break;
                                case 201:
                                    args = new HostEventArgs(eHostEventType.S2F201ParameterRelatedCommand, HostType, ParseS2F201ParameterRealatedCommand());
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;

						case 3:
							switch (e.nFunction)
							{
                                case 101:
                                    args = new HostEventArgs(eHostEventType.S3F101CassetteInfo, HostType, ParseS3F101CassetteInfo());
                                    break;
                                case 103:
                                    args = new HostEventArgs(eHostEventType.S3F103ProductionPlanInfoSend, HostType, ParseS3F103ProductionPlanInfoSend());
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;

						case 5:
							switch (e.nFunction)
							{
                                case 0:
                                    break;
                                case 2:
                                    args = new HostEventArgs(eHostEventType.S5F2AckAlarmReport, HostType, ParseS5F2AckAlarmReport());
                                    break;
                                case 101:
                                    args = new HostEventArgs(eHostEventType.S5F101WaitingResetAlarmsList, HostType, ParseS5F101WaitingResetAlarmsList());
                                    break;
                                case 103:
                                    args = new HostEventArgs(eHostEventType.S5F103SelectAlarmForcedResetRequest, HostType, ParseS5F103SelectAlarmForcedResetRequest());
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;

						case 6:
							switch (e.nFunction)
							{
                                case 0:
                                    break;
                                case 12:
                                    args = new HostEventArgs(eHostEventType.S6F12EventReportAck, HostType, ParseS6F12EventReportAck());
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;						
						case 9:
							switch (e.nFunction)
							{
                                case 0:
                                    break;
                                case 1:
                                    args = new HostEventArgs(eHostEventType.S9F1UnrecognizedDeviceID, HostType, ParseS9UnrecognizedData());
                                    break;
                                case 3:
                                    args = new HostEventArgs(eHostEventType.S9F3UnrecognizedStreamType, HostType, ParseS9UnrecognizedData());
                                    break;
                                case 5:
                                    args = new HostEventArgs(eHostEventType.S9F5UnrecognizedFunctionType, HostType, ParseS9UnrecognizedData());
                                    break;
                                case 7:
                                    args = new HostEventArgs(eHostEventType.S9F7IllegalData, HostType, ParseS9UnrecognizedData());
                                    break;
                                case 9:
                                    args = new HostEventArgs(eHostEventType.S9F9TransactionTimerTimeOut, HostType, ParseS9UnrecognizedData());
                                    break;
                                case 11:
                                    args = new HostEventArgs(eHostEventType.S9F11DataTooLong, HostType, ParseS9UnrecognizedData());
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;

						case 10:
							switch (e.nFunction)
							{
                                case 0:
                                    break;
                                case 3:
                                    args = new HostEventArgs(eHostEventType.S10F3TerminalDisplaySingle, HostType, ParseS10F3TerminalDisplaySingle());
                                    break;
                                case 9:
                                    args = new HostEventArgs(eHostEventType.S10F9Broadcast, HostType, ParseS10F9Broadcast());
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;

						case 100:
							switch (e.nFunction)
							{
                                case 2:
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;

						case 110:
							switch (e.nFunction)
							{
                                case 2:
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;

						case 125:
							switch (e.nFunction)
							{
                                case 2:
                                    break;
                                default:
                                    unrecognizedFunction = true;
                                    break;
							}
							break;

						default:
							unrecognizedStream = true;
							break;

					}
				}
				catch
				{
					illegalData = true;
				}

				if (unrecognizedStream)
				{
					SendS9UnrecognizedData(eHostEventType.S9F3UnrecognizedStreamType, e.strSECS1);
				}
				else if (unrecognizedFunction)
				{
					SendS9UnrecognizedData(eHostEventType.S9F5UnrecognizedFunctionType, e.strSECS1);
				}
				else if (illegalData)
				{
					SendS9UnrecognizedData(eHostEventType.S9F7IllegalData, e.strSECS1);
				}
				else
				{
					//logManager.WriteLog("[RECV] " + e.strCompleteMsg + "\r\n");
					OnHostReceived(sender, args);
				}
			}
		}

		//Parse Hsms메세지
		private S1F1AreYouThere ParseS1F1AreYouThere()
		{
			S1F1AreYouThere msg = new S1F1AreYouThere();

			items1 = this.List;
			{
				msg.ModuleID = this.Ascii.Trim();
			}
			
			return msg;
		}
		private S1F2OnLineData ParseS1F2OnLineData()
		{
			S1F2OnLineData msg = new S1F2OnLineData();

			items1 = this.List;
            {                
                msg.ModuleID = this.Ascii.Trim();
                string Mode = this.Ascii.Trim();

                if ("REMOTE" == Mode)
                    msg.OnlineMode = eMCMD.REMOTE;
                else if("LOCAL" == Mode)
                    msg.OnlineMode = eMCMD.LOCAL;
                else
                    msg.OnlineMode = eMCMD.OFFLINE;
            }


			return msg;
		}
		private S1F5FormattedStateRequest ParseS1F5FormattedStateRequest()
		{
			S1F5FormattedStateRequest msg = new S1F5FormattedStateRequest();

			items1 = this.List;
			{
				msg.ModuleID = this.Ascii.Trim();
				msg.SFCD = (eSFCD)this.U1;
			}

			return msg;
		}
		private S1F17RequestOnLine ParseS1F17RequestOnLine()
		{
			S1F17RequestOnLine msg = new S1F17RequestOnLine();
			
			items1 = this.List;
			{
				msg.ModuleID = this.Ascii.Trim();
				msg.OnlineMode = (eMCMD)this.U1;
			}

			return msg;
		}
        //private S2F15NewEqConstantSend ParseS2F15NewEqConstantSend()
        //{
        //    S2F15NewEqConstantSend msg = new S2F15NewEqConstantSend();

        //    items1 = this.List;
        //    {
        //        msg.ModuleID = this.Ascii.Trim();
        //        items2 = this.List;
        //        for (int i = 0; i < items2; i++)
        //        {
        //            items3 = this.List;
        //            {
        //                EqConstantData eqConstant = new EqConstantData();
        //                eqConstant.ECID = this.U2;
        //                eqConstant.ECNAME = this.Ascii.Trim();
        //                eqConstant.ECDEF = this.Ascii.Trim();
        //                eqConstant.ECSLL = this.Ascii.Trim();
        //                eqConstant.ECSUL = this.Ascii.Trim();
        //                eqConstant.ECWLL = this.Ascii.Trim();
        //                eqConstant.ECWUL = this.Ascii.Trim();
        //                msg.EqConstants.Add(eqConstant);
        //            }
        //        }
        //    }

        //    return msg;
        //}
        //private S2F29EqConstantNamelistRequest ParseS2F29EqConstantNamelistRequest()
        //{
        //    S2F29EqConstantNamelistRequest msg = new S2F29EqConstantNamelistRequest();

        //    items1 = this.List;
        //    {
        //        msg.ModuleID = this.Ascii.Trim();
        //        items2 = this.List;
        //        for (int i = 0; i < items2; i++)
        //        {
        //            msg.ECIDs.Add(this.U2);
        //        }
        //    }

        //    return msg;
        //}
		private S2F31DateTimeSetRequest ParseS2F31DateTimeSetRequest()
		{
			S2F31DateTimeSetRequest msg = new S2F31DateTimeSetRequest();

			msg.Time = this.Ascii.Trim();

			return msg;
		}


        private S2F41HostCommand ParseS2F41HostCommand()
        {          
            items1 = this.List;
            {
                eRCMD RCMD = (eRCMD)this.U1;

                switch (RCMD)
                {
                    case eRCMD.JobProcessStart:
                    case eRCMD.JobProcessCancel:
                    case eRCMD.JobProcessAbort:
                        {
                            S2F41ProcessCommand msg = new S2F41ProcessCommand();

                            msg.RCMD = RCMD;

                            items2 = this.List;
                            for (int i = 0; i < items2; i++)
                            {
                                items3 = this.List;
                                {
                                    string value = this.Ascii.Trim().ToUpper();
                                    if (value == "IPID") msg.IPID = this.Ascii.Trim();
                                    else if (value == "ICID") msg.ICID = this.Ascii.Trim();
                                    else if (value == "OPID") msg.OCID = this.Ascii.Trim();
                                    else if (value == "OCID") msg.OCID = this.Ascii.Trim();
                                    else if (value == "STIF") msg.STIF = this.Ascii.Trim();
                                    else if (value == "ORDER")
                                    {
                                        items4 = this.List;
                                        msg.SLOTIDs = new string[items4];

                                        for (int j = 0; j < items4; j++)
                                        {
                                            msg.SLOTIDs[j] = this.Ascii.Trim();
                                        }
                                    }
                                    else value = this.Ascii;
                                }
                            }
                            return msg;
                        }
                    case eRCMD.ReloadCassette:
                        {
                            S2F41PortCommand msg = new S2F41PortCommand();
                            msg.RCMD = RCMD;

                            items2 = this.List;
                            for (int i = 0; i < items2; i++)
                            {
                                items3 = this.List;
                                {
                                    string value = this.Ascii.Trim().ToUpper();
                                    if (value == "PTID")
                                    {
                                        msg.PTIDs = new string[1];
                                        msg.PTIDs[0] = this.Ascii.Trim();
                                    }
                                    else value = this.Ascii;
                                }
                            }
                            return msg;
                        }
                    default:
                        return null;
                  
                }                
                
            }

        }

        #region S2F41EqCommand
        //private S2F41EqCommand ParseS2F41EqCommand()
        //{
        //    S2F41EqCommand msg = new S2F41EqCommand();

        //    items1 = this.List;
        //    {
        //        msg.RCMD = (eRCMD)this.U1;
        //        items2 = this.List;
        //        for (int i = 0; i < items2; i++)
        //        {
        //            EqModuleData eqModule = new EqModuleData();
        //            items3 = this.List;
        //            for (int j = 0; j < items3; j++)
        //            {
        //                items4 = this.List;
        //                {
        //                    string value = this.Ascii.Trim().ToUpper();
        //                    if (value == "MODULEID") eqModule.ModuleID = this.Ascii.Trim();
        //                    else if (value == "RCODE") eqModule.RCode = this.Ascii.Trim();
        //                    else value = this.Ascii;
        //                }
        //            }
        //            msg.EqModules.Add(eqModule);
        //        }
        //    }

        //   
        //}
        #endregion

        private S2F103EqOnlineParameterChange ParseS2F103EqOnlineParameterChange()
		{
			S2F103EqOnlineParameterChange msg = new S2F103EqOnlineParameterChange();

			items1 = this.List;
			{
				msg.ModuleID = this.Ascii.Trim();
				items2 = this.List;
				for (int i = 0; i < items2; i++)
				{
					items3 = this.List;
					{
						EqOnlineParamData eo = new EqOnlineParamData();
						eo.EOID = this.U2;
						items4 = this.List;
						for (int j = 0; j < items4; j++)
						{
							items5 = this.List;
							{
								EqOnlineParamMode mode = new EqOnlineParamMode();
								mode.EOMD = this.Ascii.Trim();
								mode.EOV = this.U1;
								eo.Modes.Add(mode);
							}
						}
						msg.EqOnlineParams.Add(eo);
					}
				}
			}

			return msg;
		}
        //2008.10.04 dhlee 추가 
        private S2F201ParameterRelatedCommand ParseS2F201ParameterRealatedCommand()
		{
            S2F201ParameterRelatedCommand msg = new S2F201ParameterRelatedCommand();

			items1 = this.List;
			{
				msg.ModuleID = this.Ascii.Trim();
                msg.PCMD = this.U1;

                ParameterChangeData Param = new ParameterChangeData();

				items2 = this.List;
				for (int i = 0; i < items2; i++)
				{
                    ParameterChangeMode mode = new ParameterChangeMode();

					items3 = this.List;
					{						
						mode.PORTID = this.Ascii.Trim();
						mode.RejectMode = this.U1;
                        Param.Modes.Add(mode);
                    }
                }
                msg.LoadRejectParams.Add(Param);
			}
			return msg;
		}

        private S3F101CassetteInfo ParseS3F101CassetteInfo()
        {
            S3F101CassetteInfo info = new S3F101CassetteInfo();

            items = this.List;
            {
                info.Cassette.HotDevice = this.U1;

                items1 = this.List;
                {           
                    //Port Info
                    items2 = this.List;
                    {
                        info.Port.PortID = this.Ascii.Trim();
                        info.Port.PortNo = short.Parse(info.Port.PortID.Substring(info.Port.PortID.Length - 1));
                        info.Port.EqState = (eEqState)this.U1;
                        info.Port.PortState = (ePortState)this.U1;
                        info.Port.PortType = (ePortType)this.U1;
                        info.Port.PortMode = this.Ascii.Trim();
                        info.Port.CstDemand = (eCstDemand)this.U1;
                    }
                    //Cassette Info
                    items2 = this.List;
                    {
                        info.Cassette.CstID = this.Ascii.Trim();
                        info.Cassette.CstType = this.Ascii.Trim();
                        info.Cassette.MapStif = this.Ascii.Trim();
                        info.Cassette.CurStif = this.Ascii.Trim();
                        info.Cassette.BatchOrder = (eBatchOrder)this.U1;
                    }
                    //slot Info?
                    items2 = this.List;
                    {
                        info.Cassette.AvailStif = this.Ascii.Trim();
                    }

                    items2 = this.List;
                    GlassData[] GlassData = new GlassData[items2];
                    for (int i = 0; i < items2; i++)
                    {
                        GlassData[i] = new GlassData();
                        items3 = this.List;
                        {
                            GlassData[i].HPanelID = this.Ascii.Trim();
                            GlassData[i].EPanelID = this.Ascii.Trim();
                            GlassData[i].SlotID = this.Ascii.Trim();
                            GlassData[i].ProcessID = this.Ascii.Trim();
                            GlassData[i].ProductID = this.Ascii.Trim();
                            GlassData[i].StepID = this.Ascii.Trim();
                            GlassData[i].BatchID = this.Ascii.Trim();
                            GlassData[i].ProdType = this.Ascii.Trim();
                            GlassData[i].ProdKind = this.Ascii.Trim();
                            GlassData[i].PPID = this.Ascii.Trim();
                            GlassData[i].FlowID = this.Ascii.Trim();
                            GlassData[i].PanelSize = this.U2s;
                            GlassData[i].Thickness = this.U2;
                            GlassData[i].CompCount = this.U2;
                            GlassData[i].DBRRecipe = this.Ascii.Trim();

                            items4 = this.List;
                            for (int j = 0; j < items4; j++)
                            {
                                items5 = this.List;
                                for (int m = 0; m < items5; m++)
                                {
                                    FlowGroupData FlowGroup = new FlowGroupData();
                                    FlowGroup.FlowList = this.Bools;
                                    FlowGroup.Binary = FlowGroup.StringList;
 
                                    GlassData[i].FlowGroups.Add(FlowGroup);                                    
                                }
                            }

                            items4 = this.List;
                            for (int j = 0; j < items4; j++)
                            {
                                items5 = this.List;
                                {
                                    GlassData[i].PanelOtherProp1.PanelState = (ePanelState)this.U2;
                                    GlassData[i].PanelOtherProp1.ReadingFlag = this.Ascii.Trim();
                                    GlassData[i].PanelOtherProp1.InsFlag = this.Ascii.Trim();
                                    GlassData[i].PanelOtherProp1.PanelPosition = this.Ascii.Trim();
                                    GlassData[i].PanelOtherProp1.Judgement = this.Ascii.Trim();
                                    GlassData[i].PanelOtherProp1.Code = this.Ascii.Trim();
                                    GlassData[i].PanelOtherProp1.FlowHistorys = this.U1s;
                                    GlassData[i].PanelOtherProp1.UniqueID = this.U1s;
                                }
                            }

                            items4 = this.List;
                            for (int j = 0; j < items4; j++)
                            {
                                items5 = this.List;
                                {
                                    GlassData[i].PanelOtherProp2.Count1 = this.Ascii.Trim();
                                    GlassData[i].PanelOtherProp2.Count2 = this.Ascii.Trim();
                                    GlassData[i].PanelOtherProp2.Grade = this.Ascii.Trim();
                                    GlassData[i].PanelOtherProp2.MultiUse = this.Ascii.Trim();


                                    items6 = (short)this.List;
                                    for (int k = 0; k < items6; k++)
                                    {
                                        items7 = this.List;
                                        {
                                            GlassData[i].PanelOtherProp2.FlagName = this.Ascii.Trim();
                                            GlassData[i].PanelOtherProp2.FlagValue = this.Bool;
                                        }
                                    }
                                }
                            }

                            items4 = this.List;
                            for (int j = 0; j < items4; j++)
                            {
                                items5 = this.List;
                                {
                                    GlassData[i].PanelPairProp.PairHPanelID = this.Ascii.Trim();
                                    GlassData[i].PanelPairProp.PairEPanelID = this.Ascii.Trim();
                                    GlassData[i].PanelPairProp.PairProductID = this.Ascii.Trim();
                                    GlassData[i].PanelPairProp.PairGrade = this.Ascii.Trim();

                                }
                            }

                            items4 = this.List;
                            for (int j = 0; j < items4; j++)
                            {
                                items5 = this.List;
                                {
                                    GlassData[i].PanelCellProp.SubPanelID = this.Ascii.Trim();
                                    GlassData[i].PanelCellProp.SubJudgement = this.Ascii.Trim();
                                    GlassData[i].PanelCellProp.SubCode = this.Ascii.Trim();
                                }
                            }
                        }

                        info.Cassette.GlassDatas.Add(GlassData[i]);
                    }
                }
            }

            return info;
        }

        private S3F103ProductionPlanInfo ParseS3F103ProductionPlanInfoSend()
        {
            S3F103ProductionPlanInfo info = new S3F103ProductionPlanInfo();

            items = this.List;
            {
                info.ModuleID = this.Ascii.Trim();
                info.PLCD = (ePLCD)this.U1;

                items1 = this.List;
                for(int i=0; i < items1; i++)
                {                   
                    items2= this.List;
                    BatchObject BatchObj = new BatchObject();
                    BatchObj.ORDER_NO = this.U2;
                    BatchObj.PRIORITY = this.U1;
                    BatchObj.PROD_KIND = this.Ascii.Trim();
                    BatchObj.PROD_TYPE = this.Ascii.Trim();
                    BatchObj.PROCESSID = this.Ascii.Trim();
                    BatchObj.PRODUCTID = this.Ascii.Trim();
                    BatchObj.STEPID = this.Ascii.Trim();
                    BatchObj.PPID = this.Ascii.Trim();
                    BatchObj.FLOWID = this.Ascii.Trim();
                    BatchObj.BATCHID = this.Ascii.Trim();
                    BatchObj.BATCH_STATE = (eBatchtState)this.U1;
                    BatchObj.BATCH_SIZE = this.U2;
                    BatchObj.P_MAKER = this.Ascii.Trim();
                    BatchObj.P_THICKNESS = this.U2;
                    BatchObj.F_PANELID = this.Ascii.Trim();
                    BatchObj.C_PANELID = this.Ascii.Trim();
                    BatchObj.INPUT_LINE = this.Ascii.Trim();
                    BatchObj.VALID_FLAG = this.U1;
                    BatchObj.C_QTY = this.U2;
                    BatchObj.O_QTY = this.U2;
                    BatchObj.R_QTY = this.U2;
                    BatchObj.N_QTY = this.U2;

                    items3 = this.List;
                    for (int j = 0; j < items3; j++)
                    {
                        items4 = this.List;
                        for (int k = 0; k < items4; k++)
                        {
                            FlowGroupData FlowGroup = new FlowGroupData();
                            FlowGroup.FlowList = this.Bools;
                            BatchObj.FlowGroups.Add(FlowGroup);
                        }
                    }

                    info.BatchDatas.Add(BatchObj);
                }
            }
            return info;
        }       
        
		private S5F2AckAlarmReport ParseS5F2AckAlarmReport()
		{
			S5F2AckAlarmReport msg = new S5F2AckAlarmReport();

			msg.TMACK = (eTMACK)this.U1;

			return msg;
		}
		private S5F101WaitingResetAlarmsList ParseS5F101WaitingResetAlarmsList()
		{
			S5F101WaitingResetAlarmsList msg = new S5F101WaitingResetAlarmsList();

			msg.ModuleID = this.Ascii.Trim();

			return msg;
		}
		private S5F103SelectAlarmForcedResetRequest ParseS5F103SelectAlarmForcedResetRequest()
		{
			S5F103SelectAlarmForcedResetRequest msg = new S5F103SelectAlarmForcedResetRequest();

			items1 = this.List;
			{
				msg.ModuleID = this.Ascii.Trim();

				items2 = this.List;
				for (int i = 0; i < items2; i++)
				{
					items3 = this.List;
					{
						AlarmData alarm = new AlarmData();
						alarm.ID = this.U4;
						alarm.ModuleID = this.Ascii.Trim();
						msg.Alarms.Add(alarm);
					}
				}
			}

			return msg;
		}
		private S6F12EventReportAck ParseS6F12EventReportAck()
		{
			S6F12EventReportAck msg = new S6F12EventReportAck();

			msg.TMACK = (eTMACK)this.U1;

			return msg;
		}
		
		private S9UnrecognizedData ParseS9UnrecognizedData()
		{
			S9UnrecognizedData msg = new S9UnrecognizedData();

			msg.MHEAD = this.U1s;

			return msg;
		}
		private S10F3TerminalDisplaySingle ParseS10F3TerminalDisplaySingle()
		{
			S10F3TerminalDisplaySingle msg = new S10F3TerminalDisplaySingle();

			items1 = this.List;
			{
				msg.TerminalID = this.U1;
				msg.Text = this.Ascii.Trim();
				msg.ModuleID = this.Ascii.Trim();
			}

			return msg;
		}
		private S10F9Broadcast ParseS10F9Broadcast()
		{
			S10F9Broadcast msg = new S10F9Broadcast();

			msg.Text = this.Ascii.Trim();

			return msg;
		}



		//Send Hsms메세지
		private void SetEqState(ModuleData module)
		{
			this.List = 3;
			{
				this.Ascii = module.ID.PadRight(27);
				this.U1 = (short)module.EqState;
				if (module.Childs != null)// && module.Layer < LCData.ModuleLayer - 1)
				{
					this.List = module.Childs.Count;
					foreach (ModuleData m in module.Childs)
					{
						SetEqState(m);
					}
				}
				else
				{
					this.List = 0;					
				}
			}
		}
		private void SetProcState(ModuleData module)
		{
			this.List = 3;
			{
				this.Ascii = module.ID.PadRight(27);
				this.U1 = (short)module.ProcState;
				if (module.Childs != null)// && module.Layer < LCData.ModuleLayer - 1)
				{
					this.List = module.Childs.Count;
					foreach (ModuleData m in module.Childs)
					{
						SetProcState(m);
					}
				}
				else
				{
					this.List = 0;
				}
			}
		}
		private void SetModuleState(ModuleData module)
		{
			this.List = 4;
			{
				this.Ascii = module.ID.PadRight(27);
				this.U1 = (short)module.EqState;
				this.U1 = (short)module.ProcState;
				if (module.Childs != null)// && module.Layer < LCData.ModuleLayer - 1)
				{
					this.List = module.Childs.Count;
					foreach (ModuleData m in module.Childs)
					{
						SetModuleState(m);
					}
				}
				else
				{
					this.List = 0;
				}
			}
		}
		private void SetGlass(GlassData glass)
		{
			this.List = 20;
			{
				this.Ascii = glass.HPanelID.PadRight(12);
				this.Ascii = glass.EPanelID.PadRight(12);

				//if (glass.PanelOtherProp1.UniqueID.Count > 2 && glass.PanelOtherProp1.UniqueID[2] < 100)
				//	this.Ascii = glass.PanelOtherProp1.UniqueID[2].ToString().PadRight(2);
				//else
				this.Ascii = glass.SlotID.PadRight(2);

				this.Ascii = glass.ProcessID.PadRight(20);
				this.Ascii = glass.ProductID.PadRight(20);
				this.Ascii = glass.StepID.PadRight(12);
				this.Ascii = glass.BatchID.PadRight(12);
				this.Ascii = glass.ProdType.PadRight(2);
				this.Ascii = glass.ProdKind.PadRight(2);
				this.Ascii = glass.PPID.PadRight(16);
				this.Ascii = glass.FlowID.PadRight(4);
				this.U2s = glass.PanelSize;
				this.U2 = glass.Thickness;
				this.U2 = glass.CompCount;
				this.Ascii = glass.DBRRecipe.PadRight(4);

				if (glass.FlowGroups.Count == 10)
				{
					this.List = 1;
					{
						this.List = 10;
						foreach (FlowGroupData flowGroup in glass.FlowGroups)
						{
							this.Bools = flowGroup.BoolList;
						}
					}
				}
				else
				{
					this.List = 0;
				}

				if (glass.PanelOtherProp1 != null)
				{
					this.List = 1;
					{
						this.List = 8;
						{
							this.U2 = (int)glass.PanelOtherProp1.PanelState;
							this.Ascii = glass.PanelOtherProp1.ReadingFlag.PadRight(2);
							this.Ascii = glass.PanelOtherProp1.InsFlag.PadRight(2);
							this.Ascii = glass.PanelOtherProp1.PanelPosition.PadRight(2);
							this.Ascii = glass.PanelOtherProp1.Judgement.PadRight(4);
							this.Ascii = glass.PanelOtherProp1.Code.PadRight(4);
							this.U1s = glass.PanelOtherProp1.FlowHistorys;
							this.U1s = glass.PanelOtherProp1.UniqueID;
						}
					}
				}
				else
				{
					this.List = 0;
				}

				if (glass.PanelOtherProp2 != null)
				{
					this.List = 1;
					{
						this.List = 5;
						{
							this.Ascii = glass.PanelOtherProp2.Count1.PadRight(2);
							this.Ascii = glass.PanelOtherProp2.Count2.PadRight(2);
							//f (glass.CompCount < 64)
							//{
                                //glass.PanelOtherProp2.Grade == "" ? glass.PanelOtherProp2.Grade.PadLeft(64, '0') : glass.PanelOtherProp2.Grade;
							//	this.Ascii = glass.PanelOtherProp2.Grade.Substring(0, glass.CompCount).PadRight(64);
							//}
							//else
							//{
								this.Ascii = glass.PanelOtherProp2.Grade.PadRight(64);
							//}
							this.Ascii = glass.PanelOtherProp2.MultiUse.PadRight(20);

							this.List = 0;
							{
                                //this.List = 2;
                                //{
                                //    this.Ascii = eFlagName.JOB_START.ToString().PadRight(16);
                                //    if (glass.PanelOtherProp2.BitSignal.Length > 3 &&
                                //        glass.PanelOtherProp2.BitSignal.Substring(3, 1) == "1")
                                //    {
                                //        this.Bool = true;
                                //    }
                                //    else
                                //    {
                                //        this.Bool = false;
                                //    }
                                //}
                                //this.List = 2;
                                //{
                                //    this.Ascii = eFlagName.JOB_END.ToString().PadRight(16);
                                //    if (glass.PanelOtherProp2.BitSignal.Length > 4 &&
                                //        glass.PanelOtherProp2.BitSignal.Substring(4, 1) == "1")
                                //    {
                                //        this.Bool = true;
                                //    }
                                //    else
                                //    {
                                //        this.Bool = false;
                                //    }
                                //}
							}
						}
					}
				}
                if (glass.PanelPairProp != null)
                {
                    this.List = 1;
                    {
                        this.List = 4;
                        {
                            this.Ascii = glass.PanelPairProp.PairHPanelID.PadRight(12);
                            this.Ascii = glass.PanelPairProp.PairEPanelID.PadRight(12);
                            this.Ascii = glass.PanelPairProp.PairProductID.PadRight(20);
                            this.Ascii = glass.PanelPairProp.PairGrade.PadRight(64);                         
                        }
                    }
                }
                else
                {
                    this.List = 0;
                }

				this.List = 0;
				//this.List = 0;
			}
		}

		public void SendS1F1AreYouThere(S1F1AreYouThere msg)
		{
			this.MakeSecsMsg(1, 1);
			this.List = 1;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
			}
			SendMessage();
		}
		public void SendS1F2OnLineData(S1F2OnLineData msg)
		{
			this.MakeSecsMsg(1, 2);
			this.List = 2;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.Ascii = msg.OnlineMode.ToString().PadRight(6);
			}
			SendMessage();
		}
		public void SendS1F6EqOnlineParameter(S1F6EqOnlineParameter msg)
		{
			this.MakeSecsMsg(1, 6);
			this.List = 4;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.U1 = (short)msg.SFCD;
				this.U1 = (short)msg.TMACK;
				this.List = msg.EqOnlineParams.Count;
				foreach (EqOnlineParamData eo in msg.EqOnlineParams)
				{
					this.List = 2;
					{
						this.U2 = eo.EOID;
						this.List = eo.Modes.Count;
						foreach (EqOnlineParamMode mode in eo.Modes)
						{
							this.List = 2;
							{
								this.Ascii = mode.EOMD.PadRight(4);
								this.U1 = mode.EOV;
							}
						}
					}
				}
			}
			SendMessage();
		}
        public void SendS1F6PortState(S1F6PortState msg)
        {
            string map = "";
            string cur = "";
            this.MakeSecsMsg(1, 6);
            this.List = 4;
            {
                this.Ascii = msg.ModuleID.PadRight(27);
                this.U1 = (short)msg.SFCD;
                this.U1 = (short)msg.TMACK;
                this.List = msg.PortObjects.Count;

                foreach (PortObject Port in msg.PortObjects)
                {
                    this.List = 2;
                    {
                        this.List = 6;
                        {
                            this.Ascii = Port.PortID.PadRight(4);
                            this.U1 = (short)Port.EqState;
                            this.U1 = (short)Port.PortState;
                            this.U1 = (short)Port.PortType;
                            this.Ascii = Port.PortMode.PadRight(2);
                            this.U1 = (short)Port.CstDemand;
                        }
                        this.List = 5;
                        {
                            this.Ascii = Port.CstID.PadRight(16);
                            map = LCData.GetHostMapping(Port.MapStif);
                            cur = LCData.GetHostMapping(Port.CurStif);
                            this.Ascii = Port.CstType.PadRight(4);
                            this.Ascii = map.PadRight(80);
                            this.Ascii = cur.PadRight(80);
                            this.U1 = (short)Port.BatchOrder;
                        }

                    }
                }
            }
            SendMessage();
        }
        
		public void SendS1F6GlassTracking(S1F6GlassTracking msg)
		{
            
            this.MakeSecsMsg(1, 6, HostType);
            this.List = 2;
			{
				this.U1 = (short)msg.SFCD;               

                if ((msg.IsPort != true) && (msg.TMACK != eTMACK.ACK || msg.IsUnit || HostType == eHostType.Monitor))
				{
					this.List = msg.Modules.Count;
					foreach (ModuleData module in msg.Modules)
					{
						this.List = 3;
						{
							this.Ascii = module.ID.PadRight(27);
							this.U1 = (short)msg.TMACK;
							if (module.Glass != null)
							{
								this.List = 1;
								{
									SetGlass(module.Glass);
								}
							}
							else
							{
								this.List = 0;
							}
						}
					}
				}               
				else
				{
                    this.List = msg.Modules.Count;
                    int EqMapStif = 0;
                    int EqCurStif = 0;

                    foreach (ModuleData module in msg.Modules)
                    {
                        EqMapStif = 0;
                        EqCurStif = 0;
                        this.List = 3;
                        {
                            this.Ascii = module.ID.PadRight(27);
                            this.U1 = (short)msg.TMACK;

                            BatchManager BatchInfo = LCData.FindBatch(module.ID, module.UnitID, true);
                            if ((BatchInfo != null) && (module.Glass != null))
                            {
                                int selectPort = (int.Parse(module.UnitID.Substring(6, 1)) - 1) % 2;

                                EqMapStif = int.Parse(BatchInfo.PortDatas[selectPort].Port.MapStif) > 20 ? 20 : int.Parse(BatchInfo.PortDatas[selectPort].Port.MapStif);
                                EqCurStif = int.Parse(BatchInfo.PortDatas[selectPort].Port.CurStif) > 20 ? 20 : int.Parse(BatchInfo.PortDatas[selectPort].Port.CurStif);
                            }

                            this.List = EqCurStif;

                            for (int i = 0; i < EqCurStif; i++)
                            {
                                module.Glass.SlotID = LCData.GetSlotID(EqMapStif, EqCurStif, i);
                                SetGlass(module.Glass);
                            }
                        }
                    }
                    #region ccs section 처리

                    ////Section 구하기
                    ////List<string> moduleIDList = new List<string>();
                    //foreach (ModuleData module in msg.Modules)
                    //{
                    //   // ModuleData parentModule = LCData.FindParentModule(module, LCData.ModuleLayer - 1);

                    //    //if (parentModule != null)
                    //    {
                    //        bool isModuleID = false;
                    //        foreach (string moduleID in moduleIDList)
                    //        {
                    //            if (parentModule.ID == moduleID)
                    //            {
                    //                isModuleID = true;
                    //                break;
                    //            }
                    //        }
                    //        if (!isModuleID)
                    //            moduleIDList.Add(parentModule.ID);
                    //    }
                    //}

                    //this.List = moduleIDList.Count;
                    //foreach (string moduleID in moduleIDList)
                    //{
                    //    int glassCount = 0;
                    //    foreach (ModuleData module in msg.Modules)
                    //    {
                    //        //if (module.Layer == LCData.ModuleLayer)
                    //        {
                    //            if (module.ID.Contains(moduleID) && module.Glass != null)
                    //            {
                    //                glassCount++;
                    //            }
                    //        }
                    //    }

                    //    this.List = 3;
                    //    {
                    //        this.Ascii = moduleID.PadRight(27);
                    //        this.U1 = (short)msg.TMACK;
                    //        this.List = glassCount;

                    //        if (glassCount > 0)
                    //        {
                    //            foreach (ModuleData module in msg.Modules)
                    //            {
                    //                if (module.ID.Contains(moduleID) && module.Glass != null)
                    //                    SetGlass(module.Glass);
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                }
			}
            if (HostType == eHostType.Monitor)
            {
                this.IgnoreReply = true;
                SendMessage();
                this.IgnoreReply = false;
            }
            else
            {
                SendMessage();
            }
		}
        
		public void SendS1F6ModuleStates(S1F6ModuleStates msg)
		{
			this.MakeSecsMsg(1, 6);
			this.List = 3;
			{
				this.U1 = (short)msg.SFCD;
				this.U1 = (short)msg.TMACK;

				this.List = msg.Modules.Count;
				if (msg.Modules.Count > 0)
				{
					SetModuleState(msg.Modules[0]);
				}
			}
			SendMessage();
		}
        //public void SendS1F6EqStandardTactRequest(S1F6EqStandardTactRequest msg)
        //{
        //    this.MakeSecsMsg(1, 6);
        //    this.List = 4;
        //    {
        //        this.Ascii = msg.ModuleID.PadRight(27);
        //        this.U1 = (short)msg.SFCD;
        //        this.U1 = (short)msg.TMACK;
        //        if (msg.TMACK == eTMACK.ACK)
        //        {
        //            this.List = 1;
        //            {
        //                this.List = 5;
        //                {
        //                    this.Ascii = msg.ModuleID.PadRight(27);
        //                    this.U1 = (short)msg.EqState;
        //                    this.U1 = (short)msg.ProcState;
        //                    this.U1 = (short)msg.MCMD;
        //                    this.U2 = msg.StandardTact;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            this.List = 0;
        //        }
        //    }
        //    SendMessage();
        //}
        //public void SendS1F6EqCurrentInterlockRequest(S1F6EqCurrentInterlockRequest msg)
        //{
        //    this.MakeSecsMsg(1, 6);
        //    this.List = 4;
        //    {
        //        this.Ascii = msg.ModuleID.PadRight(27);
        //        this.U1 = (short)msg.SFCD;
        //        this.U1 = (short)msg.TMACK;
        //        this.List = 1;
        //        {
        //            this.List = 4;
        //            {
        //                this.Ascii = msg.ModuleID.PadRight(27);
        //                this.U1 = (short)msg.EqState;
        //                this.U1 = (short)msg.ProcState;
        //                this.List = msg.EqInterlocks.Count;
        //                foreach (EqInterlockData eqInterlock in msg.EqInterlocks)
        //                {
        //                    this.List = 2;
        //                    {
        //                        this.Ascii = eqInterlock.ModuleID.PadRight(27);
								
        //                        if (LCData.CCSType != eCCSType.EDS)
        //                        {
        //                            this.List = 4;
        //                        }
        //                        else
        //                        {
        //                            this.List = 3;
        //                        }

        //                        this.List = 2;
        //                        {
        //                            this.Ascii = "IMMEDIATELY PAUSE".PadRight(20);
        //                            this.Ascii = eqInterlock.ImmediatelyPause.PadRight(4);
        //                        }

        //                        if (LCData.CCSType != eCCSType.EDS)
        //                        {
        //                            this.List = 2;
        //                            {
        //                                this.Ascii = "TRANSFER STOP".PadRight(20);
        //                                this.Ascii = eqInterlock.TransferStop.PadRight(4);
        //                            }
        //                        }

        //                        this.List = 2;
        //                        {
        //                            this.Ascii = "LOADING STOP".PadRight(20);
        //                            this.Ascii = eqInterlock.LoadingStop.PadRight(4);
        //                        }
        //                        this.List = 2;
        //                        {
        //                            this.Ascii = "GLASS REFUSE".PadRight(20);
        //                            this.Ascii = eqInterlock.GlassRefuse.PadRight(4);
        //                        }

        //                    }
        //                }
        //            }
        //        }
        //    }
        //    SendMessage();
        //}
		public void SendS1F6FlowControlTableRequest(S1F6FlowControlTableRequest msg)
		{
			this.MakeSecsMsg(1, 6);
			this.List = 4;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.U1 = (short)msg.SFCD;
				this.U1 = (short)msg.TMACK;
				this.List = 1;
				{
					this.List = 5;
					{
						this.Ascii = msg.ModuleID.PadRight(27);
						this.U1 = (short)msg.EqState;
						this.U1 = (short)msg.ProcState;
						this.U1 = (short)msg.MCMD;
						this.List = msg.FlowControls.Count;
						foreach (FlowControlTable flowControl in msg.FlowControls)
						{
							this.List = 3;
							{
								this.Bools = flowControl.WorkerIDs;
								this.Ascii = flowControl.EqpType.PadRight(22);
								this.List = flowControl.WorkGroupTables.Count;
								foreach (WorkGroupTable workGroup in flowControl.WorkGroupTables)
								{
									this.List = 2;
									{
										this.Bools = workGroup.WorkerGroup;
										this.List = 8;
										{
											this.Ascii = workGroup.Worker1.PadRight(27);
											this.Ascii = workGroup.Worker2.PadRight(27);
											this.Ascii = workGroup.Worker3.PadRight(27);
											this.Ascii = workGroup.Worker4.PadRight(27);
											this.Ascii = workGroup.Worker5.PadRight(27);
											this.Ascii = workGroup.Worker6.PadRight(27);
											this.Ascii = workGroup.Worker7.PadRight(27);
											this.Ascii = workGroup.Worker8.PadRight(27);
										}
									}
								}
							}
						}
					}
				}
			}
			SendMessage();
		}

        public void SendS1F6LoadRejectParameter(S1F6LoadRejectParameter msg)
		{
			this.MakeSecsMsg(1, 6);
			this.List = 4;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.U1 = (short)msg.SFCD;
				this.U1 = (short)msg.TMACK;

                this.List = 1;
                {
                    this.List = 2;
                    {
                        this.U1 = 100;//RPTID = 100 (fixed)
                        this.List = msg.LoadRejectParams.Count;

                        foreach (ParameterChangeData Param in msg.LoadRejectParams)
                        {
                            this.List = 2;
                            foreach (ParameterChangeMode mode in Param.Modes)
                            {
                                this.Ascii = mode.PORTID.PadRight(4);
                                this.U1 = mode.RejectMode;
                            }
                        }
                    }
                }               
			}
			SendMessage();
		}    

		public void SendS1F18OnLineAck(S1F18OnLineAck msg)
		{
			this.MakeSecsMsg(1, 18);
			this.List = 2;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.U1 = (short)msg.TMACK;
			}
			SendMessage();
		}
        //public void SendS2F16NewEqConstantAck(S2F16NewEqConstantAck msg)
        //{
        //    this.MakeSecsMsg(2, 16);
        //    this.List = 3;
        //    {
        //        this.Ascii = msg.ModuleID.PadRight(27);
        //        this.U1 = (short)msg.TMACK;
        //        this.List = msg.EqConstants.Count;
        //        foreach (EqConstantData eqConstant in msg.EqConstants)
        //        {
        //            this.List = 7;
        //            {
        //                this.List = 2;
        //                {
        //                    this.U2 = eqConstant.ECID;
        //                    this.U1 = (short)eqConstant.ECID_PMACK;
        //                }
        //                this.List = 2;
        //                {
        //                    this.Ascii = eqConstant.ECNAME.PadRight(40);
        //                    this.U1 = (short)eqConstant.ECNAME_PMACK;
        //                }
        //                this.List = 2;
        //                {
        //                    this.Ascii = eqConstant.ECDEF.PadRight(20);
        //                    this.U1 = (short)eqConstant.ECDEF_PMACK;
        //                }
        //                this.List = 2;
        //                {
        //                    this.Ascii = eqConstant.ECSLL.PadRight(20);
        //                    this.U1 = (short)eqConstant.ECSLL_PMACK;
        //                }
        //                this.List = 2;
        //                {
        //                    this.Ascii = eqConstant.ECSUL.PadRight(20);
        //                    this.U1 = (short)eqConstant.ECSUL_PMACK;
        //                }
        //                this.List = 2;
        //                {
        //                    this.Ascii = eqConstant.ECWLL.PadRight(20);
        //                    this.U1 = (short)eqConstant.ECWLL_PMACK;
        //                }
        //                this.List = 2;
        //                {
        //                    this.Ascii = eqConstant.ECWUL.PadRight(20);
        //                    this.U1 = (short)eqConstant.ECWUL_PMACK;
        //                }
        //            }
        //        }
        //    }
        //    SendMessage();
        //}
        //public void SendS2F30EqConstantNamelist(S2F30EqConstantNamelist msg)
        //{
        //    this.MakeSecsMsg(2, 30);
        //    this.List = 3;
        //    {
        //        this.Ascii = msg.ModuleID.PadRight(27);
        //        this.U1 = (short)msg.TMACK;
        //        this.List = msg.EqConstants.Count;
        //        foreach (EqConstantData eqConstant in msg.EqConstants)
        //        {
        //            this.List = 7;
        //            {
        //                this.U2 = eqConstant.ECID;
        //                this.Ascii = eqConstant.ECNAME.PadRight(40);
        //                this.Ascii = eqConstant.ECDEF.PadRight(20);
        //                this.Ascii = eqConstant.ECSLL.PadRight(20);
        //                this.Ascii = eqConstant.ECSUL.PadRight(20);
        //                this.Ascii = eqConstant.ECWLL.PadRight(20);
        //                this.Ascii = eqConstant.ECWUL.PadRight(20);
        //            }
        //        }
        //    }
        //    SendMessage();
        //}
		public void SendS2F32DateTimeSetAck(S2F32DateTimeSetAck msg)
		{
			this.MakeSecsMsg(2, 32);
			this.U1 = (short)msg.TMACK;
			SendMessage();
		}
        public void SendS2F42EqCommandReply(S2F42EqCommandReply msg)
        {
            this.MakeSecsMsg(2, 42);
            this.List = 3;
            {
                this.U1 = (short)msg.RCMD;
                this.U1 = (short)msg.TMACK;
                this.List = msg.EqModules.Count;
                foreach (EqModuleData eqModule in msg.EqModules)
                {
                    this.List = 2;
                    {
                        this.List = 3;
                        {
                            this.Ascii = "MODULEID";
                            this.Ascii = eqModule.ModuleID.PadRight(27);
                            this.U1 = (short)eqModule.ModuleID_PMACK;
                        }
                        this.List = 3;
                        {
                            this.Ascii = "RCODE   ";
                            this.Ascii = eqModule.RCode.PadRight(4);
                            this.U1 = (short)eqModule.RCode_PMACK;
                        }
                    }
                }
            }
            SendMessage();
        }

        public void SendS2F42ProcessCmdReply(S2F42ProcessCommandReply msg)
        {
            this.MakeSecsMsg(2, 42);
            this.List = 3;
            {
                this.U1 = (short)msg.RCMD;
                this.U1 = (short)msg.TMACK;
                this.List = 6;
                {
                    this.List = 3;
                    {
                        this.Ascii  = "IPID    ";
                        this.Ascii  = msg.IPID.PadRight(4);
                        this.U1 = (short)msg.PMACK;                      
                    }

                    this.List = 3;
                    {
                        this.Ascii = "ICID    ";
                        this.Ascii = msg.ICID.PadRight(16);
                        this.U1 = (short)msg.PMACK;
                    }

                    this.List = 3;
                    {
                        this.Ascii = "OPID    ";
                        this.Ascii = msg.OPID.PadRight(4);
                        this.U1 = msg.PMACK;
                    }

                    this.List = 3;
                    {
                        this.Ascii = "OCID    ";
                        this.Ascii = msg.OCID.PadRight(16);
                        this.U1 = (short)msg.PMACK;
                    }

                    this.List = 3;
                    {
                        this.Ascii = "STIF    ";
                        this.Ascii = msg.STIF.PadRight(16);
                        this.U1 = (short)msg.PMACK;
                    }

                    this.List = 3;
                    {
                        this.Ascii = "ORDER   ";


                        //if (msg.RCMD == eRCMD.JobProcessStart)
                        //{
                        this.List = msg.SLOTIDs.Length;
                        {
                            for (int i = 0; i < msg.SLOTIDs.Length; i++)
                            {
                                this.Ascii = msg.SLOTIDs[i].PadRight(2);
                            }
                        }
                        //}
                        //else
                        //{
                        //    this.List = 0;
                        //}
                        this.U1 = (short)msg.PMACK;
                    }           
                }
            }
            SendMessage();
        }

        public void SendS2F42PortCmdReply(S2F42PortCommandReply msg)
        {
            this.MakeSecsMsg(2, 42);
            this.List = 3;
            {
                this.U1 = (short)msg.RCMD;
                this.U1 = (short)msg.TMACK;

                this.List = msg.Ports.Length;
                {
                    for (int i = 0; i < msg.Ports.Length; i++)
                    {
                        this.List = 3;
                        {
                            this.Ascii = "PTID    ";
                            this.Ascii = msg.Ports[i].PortID.PadRight(4);
                            this.U1 = (short)msg.Ports[i].CPACK;
                        }
                    }
                }
            }
            SendMessage();
        }


		public void SendS2F104EqOnlineParameterAck(S2F104EqOnlineParameterAck msg)
		{
			this.MakeSecsMsg(2, 104);
			this.List = 3;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.U1 = (short)msg.TMACK;
				this.List = msg.EqOnlineParams.Count;
				foreach (EqOnlineParamData eo in msg.EqOnlineParams)
				{
					this.List = 2;
					{
						this.U2 = eo.EOID;
						this.List = eo.Modes.Count;
						foreach (EqOnlineParamMode mode in eo.Modes)
						{
							this.List = 2;
							{
								this.Ascii = mode.EOMD.PadRight(4);
								this.U1 = (short)mode.PMACK;
							}
						}
					}
				}
			}
			SendMessage();
		}


        public void SendS2F202ParameterRelatedReply(S2F202ParameterRelatedReply msg)
        {
            this.MakeSecsMsg(2, 104);

            this.List = 4;
            {
                this.Ascii = msg.ModuleID.PadRight(27);
                this.U1 = msg.PCMD;
                this.U1 = (short)msg.TMACK;
                this.List = msg.LoadRejectParams.Count;
                foreach (ParameterChangeData Param in msg.LoadRejectParams)
                {
                    this.List = Param.Modes.Count;
                    foreach (ParameterChangeMode mode in Param.Modes)
                    {
                        this.List = 2;
                        {
                            this.Ascii = mode.PORTID.PadRight(4);
                            this.U1 = mode.RejectMode;
                        }
                    }
                }
            }
            SendMessage();
        }




        public void SendS3F102CassetteInfoReply(S3F102CassetteInfoReply msg)
        {
            this.MakeSecsMsg(3, 102);
            this.U1 = (short)msg.TMACK;               
            SendMessage();
        }



        public void SendS3F104ProdPlanInfoReply(S3F104ProductionPlanInfoReply msg)
        {
            this.MakeSecsMsg(3, 104);
            this.List = 3;
            {
                this.Ascii = msg.ModuleID.PadRight(27);
                this.U1 = (short)msg.PLCD;
                this.U1 = (short)msg.TMACK;
            }
            SendMessage();
        }		
		public void SendS5F1AlarmReportSend(S5F1AlarmReportSend msg)
		{
			this.MakeSecsMsg(5, 1);
			this.List = 5;
			{
				this.B1 = msg.Alarm.Code;
				this.U4 = msg.Alarm.ID;
				this.Ascii = msg.Alarm.Text.PadRight(80);
				this.Ascii = msg.Alarm.Time.PadRight(14);
				this.Ascii = msg.Alarm.ModuleID.PadRight(27);
			}
			SendMessage();
		}
		public void SendS5F102WaitingResetAlarmsListAck(S5F102WaitingResetAlarmsListAck msg)
		{
			this.MakeSecsMsg(5, 102);
			this.List = 3;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.U1 = (short)msg.TMACK;
				this.List = msg.Alarms.Count;
				foreach (AlarmData alarm in msg.Alarms)
				{
					this.List = 5;
					{
						this.B1 = alarm.Code;
						this.U4 = alarm.ID;
						this.Ascii = alarm.Text.PadRight(80);
						this.Ascii = alarm.Time.PadRight(14);
						this.Ascii = alarm.ModuleID.PadRight(27);
					}
				}
			}
			SendMessage();
		}
        public void SendS5F102WaitingResetAlarmsListAck(S5F102WaitingResetAlarmsListAck msg, eHostType eType)
        {
            this.MakeSecsMsg(5, 101, eType);
            this.List = 3;
            {
                this.Ascii = msg.ModuleID.PadRight(27);
                this.U1 = (short)msg.TMACK;
                this.List = msg.Alarms.Count;
                foreach (AlarmData alarm in msg.Alarms)
                {
                    this.List = 5;
                    {
                        this.B1 = alarm.Code;
                        this.U4 = alarm.ID;
                        this.Ascii = alarm.Text.PadRight(80);
                        this.Ascii = alarm.Time.PadRight(14);
                        this.Ascii = alarm.ModuleID.PadRight(27);
                    }
                }
            }
            SendMessage();
        }
		public void SendS5F104SelectAlarmForcedResetAck(S5F104SelectAlarmForcedResetAck msg)
		{
			this.MakeSecsMsg(5, 104);
			this.List = 3;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.U1 = (short)msg.TMACK;
				this.List = msg.Alarms.Count;
				foreach (AlarmData alarm in msg.Alarms)
				{
					this.List = 3;
					{
						this.U4 = alarm.ID;
						this.Ascii = alarm.ModuleID.PadRight(27);
						this.U1 = (short)alarm.PMACK;
					}
				}
			}
			SendMessage();
		}
		public void SendS5F105CurrentEqAlarmlistReport(S5F105CurrentEqAlarmlistReport msg)
		{
			this.MakeSecsMsg(5, 105);
			this.List = 2;
			{
				this.Ascii = msg.ModuleID.PadRight(27);
				this.List = msg.Alarms.Count;
				foreach (AlarmData alarm in msg.Alarms)
				{
					this.List = 5;
					{
						this.B1 = alarm.Code;
						this.U4 = alarm.ID;
						this.Ascii = alarm.Text.PadRight(80);
						this.Ascii = alarm.Time.PadRight(14);
						this.Ascii = alarm.ModuleID.PadRight(27);
					}
				}
			}
			SendMessage();
		}
		public void SendS6F11PanelProcessEvent(S6F11PanelProcessEvent msg)
		{
            
            this.MakeSecsMsg(6, 11, HostType);
			this.List = 3;
			{
				this.U1 = msg.DataID;
				this.U2 = (int)msg.CEID;
				this.List = 3;
				{
					this.List = 2;
					{
						this.U1 = 0;
						this.List = 6;
						{
							this.Ascii = msg.ModuleID.PadRight(27);
							this.U1 = (short)msg.MCMD;
							this.U1 = (short)msg.EqState;
							this.U1 = (short)msg.ProcState;
							this.U1 = (short)msg.ByWho;
							this.Ascii = msg.OperID.PadRight(16);
						}
					}

					this.List = 2;
					{
						this.U1 = 20;
						this.List = 2;
						{
							this.Ascii = msg.FromModuleID.PadRight(27);
							this.Ascii = msg.ToModuleID.PadRight(27);
						}
					}

					this.List = 2;
					{
						this.U1 = 3;
						this.List = msg.Glasses.Count;
						foreach (GlassData glass in msg.Glasses)
						{
							SetGlass(glass);
						}
					}

				}
			}
			SendMessage();
		}
        
		public void SendS6F11EqEvent(S6F11EqEvent msg)
		{
			this.MakeSecsMsg(6, 11);
			this.List = 3;
			{
				this.U1 = msg.DataID;
				this.U2 = (int)msg.CEID;
				this.List = 3;
				{
					this.List = 3;
					{
						this.List = 4;
						{
							this.Ascii = msg.ModuleID.PadRight(27);
							this.U1 = (short)msg.MCMD;
							this.U1 = (short)msg.ByWho;
							this.Ascii = msg.OperID.PadRight(16);
						}

						if (!string.IsNullOrEmpty(msg.ChangeEqStateModuleID))
						{
							this.List = 1;
							{
								this.List = 3;
								{
									this.Ascii = msg.ChangeEqStateModuleID.PadRight(27);
									this.U1 = (short)msg.ChangeEqState;
									SetEqState(msg.Modules[0]);
								}
							}
						}
						else
						{
							this.List = 0;
						}

						if (!string.IsNullOrEmpty(msg.ChangeProcStateModuleID))
						{
							this.List = 1;
							{
								this.List = 3;
								{
									this.Ascii = msg.ChangeProcStateModuleID.PadRight(27);
									this.U1 = (short)msg.ChangeProcState;
									SetProcState(msg.Modules[0]);
								}
							}
						}
						else
						{
							this.List = 0;
						}

						this.List = 2;
						{
							this.Ascii = msg.LimitTime.PadRight(6);
							this.Ascii = msg.RCode.PadRight(4);
						}

						this.List = 2;
						{
							this.U1 = 11;
							if (msg.Alarms == null)
							{
								this.List = 0;
							}
							else
							{
								this.List = msg.Alarms.Count;
								foreach (AlarmData alarm in msg.Alarms)
								{
									this.List = 5;
									{
										this.B1 = alarm.Code;
										this.U4 = alarm.ID;
										this.Ascii = alarm.Text.PadRight(80);
										this.Ascii = alarm.Time.PadRight(14);
										this.Ascii = alarm.ModuleID.PadRight(27);
									}
								}
							}
						}

					}
				}
			}
			SendMessage();
		}
		public void SendS6F11EqParameterEvent(S6F11EqParameterEvent msg)
		{
			this.MakeSecsMsg(6, 11);
			this.List = 3;
			{
				this.U1 = msg.DataID;
				this.U2 = (int)msg.CEID;
				this.List = 3;
				{
					this.List = 2;
					{
						this.U1 = 0;
						this.List = 6;
						{
							this.Ascii = msg.ModuleID.PadRight(27);
							this.U1 = (short)msg.MCMD;
							this.U1 = (short)msg.EqState;
							this.U1 = (short)msg.ProcState;
							this.U1 = (short)msg.ByWho;
							this.Ascii = msg.OperID.PadRight(16);
						}
					}

					this.List = 2;
					{
						this.U1 = 5;
						this.List = msg.EqOnlineParams.Count;

						foreach (EqOnlineParamData eo in msg.EqOnlineParams)
						{
							this.List = 2;
							{
								this.U2 = eo.EOID;
								this.List = eo.Modes.Count;

								foreach (EqOnlineParamMode eoMode in eo.Modes)
								{
									this.List = 2;
									{
										this.Ascii = eoMode.EOMD.PadRight(4);
										this.U1 = eoMode.EOV;
									}
								}
							}
						}
					}

					this.List = 2;
					{
						this.U1 = 6;
						this.List = msg.EqConstants.Count;

						foreach (EqConstantData ec in msg.EqConstants)
						{
							this.List = 7;
							{
								this.U2 = ec.ECID;
								this.Ascii = ec.ECNAME.PadRight(40);
								this.Ascii = ec.ECDEF.PadRight(20);
								this.Ascii = ec.ECSLL.PadRight(20);
								this.Ascii = ec.ECSUL.PadRight(20);
								this.Ascii = ec.ECWLL.PadRight(20);
								this.Ascii = ec.ECWUL.PadRight(20);
							}
						}
					}

				}
			}
			SendMessage();
		}
        //public void SendS6F11EqSpecificControlEvent(S6F11EqSpecificControlEvent msg)
        //{
        //    this.MakeSecsMsg(6, 11);
        //    this.List = 3;
        //    {
        //        this.U1 = msg.DataID;
        //        this.U2 = (int)msg.CEID;
        //        this.List = 2;
        //        {
        //            this.List = 2;
        //            {
        //                this.U1 = 0;
        //                this.List = 6;
        //                {
        //                    this.Ascii = msg.ModuleID.PadRight(27);
        //                    this.U1 = (short)msg.MCMD;
        //                    this.U1 = (short)msg.EqState;
        //                    this.U1 = (short)msg.ProcState;
        //                    this.U1 = (short)msg.ByWho;
        //                    this.Ascii = msg.OperID.PadRight(16);
        //                }
        //            }

        //            this.List = 2;
        //            {
        //                this.U1 = 7;
        //                this.List = 1;
        //                {
        //                    this.List = 2;
        //                    {
        //                        this.Ascii = msg.ItemName.PadRight(40);
        //                        this.Ascii = msg.ItemValue.PadRight(40);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    SendMessage();
        //}
        //public void SendS6F11RelatedPanelIDValidationEvent(S6F11RelatedPanelIDValidationEvent msg)
        //{
        //    this.MakeSecsMsg(6, 11);
        //    this.List = 3;
        //    {
        //        this.U1 = msg.DataID;
        //        this.U2 = (int)msg.CEID;
        //        this.List = 2;
        //        {
        //            this.List = 2;
        //            {
        //                this.U1 = 0;
        //                this.List = 6;
        //                {
        //                    this.Ascii = msg.ModuleID.PadRight(27);
        //                    this.U1 = (short)msg.MCMD;
        //                    this.U1 = (short)msg.EqState;
        //                    this.U1 = (short)msg.ProcState;
        //                    this.U1 = (short)msg.ByWho;
        //                    this.Ascii = msg.OperID.PadRight(16);
        //                }
        //            }
        //            this.List = 2;
        //            {
        //                this.U1 = 9;
        //                this.List = 8;
        //                {
        //                    this.Ascii = msg.BatchID.PadRight(12);
        //                    this.Ascii = msg.EPanelID.PadRight(12);
        //                    this.Ascii = msg.PortID.PadRight(4);
        //                    this.Ascii = msg.CstID.PadRight(16);
        //                    this.Ascii = msg.SlotID.PadRight(2);
        //                    this.U2s = msg.PanelSize;
        //                    this.List = 1;
        //                    {
        //                        this.List = 2;
        //                        {
        //                            this.Ascii = msg.HPanelID.PadRight(12);
        //                            this.Ascii = msg.SlotID.PadRight(2);
        //                        }
        //                    }
        //                    this.List = 0;
        //                }
        //            }
        //        }
        //    }
        //    SendMessage();
        //}
        //public void SendS6F11RelatedEquipmentStandardDataEvent(S6F11RelatedEquipmentStandardDataEvent msg)
        //{
        //    this.MakeSecsMsg(6, 11);
        //    this.List = 3;
        //    {
        //        this.U1 = msg.DataID;
        //        this.U2 = (int)msg.CEID;
        //        this.List = 2;
        //        {
        //            this.List = 2;
        //            {
        //                this.U1 = 0;
        //                this.List = 6;
        //                {
        //                    this.Ascii = msg.ModuleID.PadRight(27);
        //                    this.U1 = (short)msg.MCMD;
        //                    this.U1 = (short)msg.EqState;
        //                    this.U1 = (short)msg.ProcState;
        //                    this.U1 = (short)msg.ByWho;
        //                    this.Ascii = msg.OperID.PadRight(16);
        //                }
        //            }
        //            this.List = 2;
        //            {
        //                this.U1 = 26;
        //                this.List = 4;
        //                {
        //                    this.Ascii = msg.ProcessID.PadRight(20);
        //                    this.Ascii = msg.ProductID.PadRight(20);
        //                    this.Ascii = msg.PPID.PadRight(16);
        //                    this.U2 = msg.StandardTact;
        //                }
        //            }
        //        }
        //    }
        //    SendMessage();
        //}

        public void SendS6F11PortLoaderEvent(S6F11PortLoaderEvent msg)
        {
            this.MakeSecsMsg(6, 11);
            this.List = 3;
            {
                this.U1 = msg.DataID;
                this.U2 = (int)msg.Port.PortEvent;
                this.List = 3;
                {
                    this.List = 2;
                    {
                        this.U1 = 0;
                        this.List = 6;
                        {
                            this.Ascii = msg.ModuleID.PadRight(27);
                            this.U1 = (short)msg.MCMD;
                            this.U1 = (short)msg.EqState;
                            this.U1 = (short)msg.ProcState;
                            this.U1 = (short)msg.Port.ByWho;
                            this.Ascii = msg.OperID.PadRight(16);
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 1;
                        this.List = 6;
                        {
                            this.Ascii = msg.Port.PortID.PadRight(4);
                            this.U1 = (short)msg.Port.EqState;
                            this.U1 = (short)msg.Port.PortState;
                            this.U1 = (short)msg.Port.PortType;
                            this.Ascii = msg.Port.PortMode.PadRight(2);
                            this.U1 = (short)msg.Port.CstDemand;
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 2;
                        this.List = 5;
                        {
                            this.Ascii = msg.Port.CstID.PadRight(16);
                            this.Ascii = msg.Port.CstType.PadRight(4);
                            this.Ascii = LCData.GetHostMapping(msg.Port.MapStif).PadRight(80);
                            this.Ascii = LCData.GetHostMapping(msg.Port.CurStif).PadRight(80);
                            this.U1 = (short)msg.Port.BatchOrder;
                        }                      
                    }

                }
            }
            SendMessage();
        }
        public void SendS6F11JobProcessEvent(S6F11JobProcessEvent msg)
        {
                
            this.MakeSecsMsg(6, 11, HostType);  
            this.List = 3;
            {
                this.U1 = msg.DataID;
                this.U2 = (int)msg.Port.PortEvent;
                this.List = 4;
                {
                    this.List = 2;
                    {
                        this.U1 = 0;
                        this.List = 6;
                        {
                            this.Ascii = msg.ModuleID.PadRight(27);
                            this.U1 = (short)msg.MCMD;
                            this.U1 = (short)msg.EqState;
                            this.U1 = (short)msg.ProcState;
                            this.U1 = (short)msg.Port.ByWho;
                            this.Ascii = msg.OperID.PadRight(16);
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 1;
                        this.List = 6;
                        {
                            this.Ascii = msg.Port.PortID.PadRight(4);
                            this.U1 = (short)msg.Port.EqState;
                            this.U1 = (short)msg.Port.PortState;
                            this.U1 = (short)msg.Port.PortType;
                            this.Ascii = msg.Port.PortMode.PadRight(2);
                            this.U1 = (short)msg.Port.CstDemand;
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 2;
                        this.List = 5;
                        {
                            this.Ascii = msg.Port.CstID.PadRight(16);
                            this.Ascii = msg.Port.CstType.PadRight(4);
                            this.Ascii = LCData.GetHostMapping(msg.Port.MapStif).PadRight(80);
                            this.Ascii = LCData.GetHostMapping(msg.Port.CurStif).PadRight(80);
                            this.U1 = (short)msg.Port.BatchOrder;
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 3;

                        if (msg.Cassette != null)
                        {
                            this.List = msg.Cassette.GlassDatas.Count;
                            {
                                foreach (GlassData glass in msg.Cassette.GlassDatas)
                                {
                                    SetGlass(glass);
                                }
                            }
                        }
                    }
                }
            }
            SendMessage();
        }
        
        public void SendS6F11BatchProcessEvent(S6F11BatchProcessEvent msg)
        {
            this.MakeSecsMsg(6, 11);
            this.List = 3;
            {
                this.U1 = msg.DataID;
                this.U2 = (int)msg.CEID;
                this.List = 4;
                {
                    this.List = 2;
                    {
                        this.U1 = 0;
                        this.List = 6;
                        {
                            this.Ascii = msg.ModuleID.PadRight(27);
                            this.U1 = (short)msg.MCMD;
                            this.U1 = (short)msg.EqState;
                            this.U1 = (short)msg.ProcState;
                            this.U1 = (short)msg.ByWho;
                            this.Ascii = msg.OperID.PadRight(16);
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 1;
                        this.List = 6;
                        {
                            this.Ascii = msg.Port.PortID.PadRight(4);
                            this.U1 = (short)msg.Port.EqState;
                            this.U1 = (short)msg.Port.PortState;
                            this.U1 = (short)msg.Port.PortType;
                            this.Ascii = msg.Port.PortMode.PadRight(2);
                            this.U1 = (short)msg.Port.CstDemand;
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 2;
                        this.List = 5;
                        {
                            this.Ascii = msg.Port.CstID.PadRight(16);
                            this.Ascii = msg.Port.CstType.PadRight(4);
                            this.Ascii = msg.Port.MapStif.PadRight(80);
                            this.Ascii = msg.Port.CurStif.PadRight(80);
                            this.U1 = (short)msg.Port.BatchOrder;
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 1;
                        this.List = 23;
                        {
                            this.U2 = msg.Batch.ORDER_NO;
                            this.U1 = msg.Batch.PRIORITY;
                            this.Ascii = msg.Batch.PROD_KIND.PadRight(2);
                            this.Ascii = msg.Batch.PROD_TYPE.PadRight(2);
                            this.Ascii = msg.Batch.PROCESSID.PadRight(20);
                            this.Ascii = msg.Batch.PRODUCTID.PadRight(20);

                            this.Ascii = msg.Batch.STEPID.PadRight(12);
                            this.Ascii = msg.Batch.PPID.PadRight(16);
                            this.Ascii = msg.Batch.FLOWID.PadRight(4);
                            this.Ascii = msg.Batch.BATCHID.PadRight(12);

                            this.U1 = (short)msg.Batch.BATCH_STATE;
                            this.U2 = msg.Batch.BATCH_SIZE;
                            this.Ascii = msg.Batch.P_MAKER.PadRight(50);

                            this.U2 = msg.Batch.P_THICKNESS;
                            this.Ascii = msg.Batch.F_PANELID.PadRight(12);
                            this.Ascii = msg.Batch.C_PANELID.PadRight(12);
                            this.Ascii = msg.Batch.INPUT_LINE.PadRight(2);
                            this.U1 = msg.Batch.VALID_FLAG;

                            this.U2 = msg.Batch.C_QTY;
                            this.U2 = msg.Batch.O_QTY;
                            this.U2 = msg.Batch.R_QTY;
                            this.U2 = msg.Batch.N_QTY;
                            
                            this.List = 1;
                            {
                                this.List = 10;
                                foreach (FlowGroupData flowGroup in msg.Batch.FlowGroups)
                                {
                                    this.Bools = flowGroup.BoolList;
                                }
                            }
                        }
                    }
                }
            }
            SendMessage();
        }       

        public void SendS6F11ProdPlanRequstEvent(S6F11ProdPlanRequstEvent msg)
        {
            this.MakeSecsMsg(6, 11);
            this.List = 3;
            {
                this.U1 = msg.DataID;
                this.U2 = (int)msg.CEID;
                this.List = 2;
                {
                    this.List = 2;
                    {
                        this.U1 = 0;
                        this.List = 6;
                        {
                            this.Ascii = msg.ModuleID.PadRight(27);
                            this.U1 = (short)msg.MCMD;
                            this.U1 = (short)msg.EqState;
                            this.U1 = (short)msg.ProcState;
                            this.U1 = (short)msg.ByWho;
                            this.Ascii = msg.OperID.PadRight(16);
                        }
                    }

                    this.List = 2;
                    {
                        this.U1 = 7;
                        this.List = 1;
                        {
                            this.List = 3;
                            {
                                this.Ascii = msg.ItemName.PadRight(40);
                                this.Ascii = msg.ItemValue.PadRight(40);
                                this.Ascii = msg.RelatedModuleID.PadRight(40);
                            }                           
                        }
                    }
                }
            }
            SendMessage();
        }

        //public void SendS6F11LoadRejectParamChangeEvent(S6F11LoadRejectParamChangeEvent msg)
        //{
        //    this.MakeSecsMsg(6, 11);
        //    this.List = 4;
        //    {
        //        this.U1 = msg.DataID;
        //        this.U2 = (int)msg.CEID;
        //        this.Ascii = msg.ModuleID.PadRight(27);
        //        this.List = 1;
        //        {
        //            this.List = 2;
        //            {
        //                this.U1 = 1;//RPTID = 1 (fixed)
        //                this.List = msg.LoadRejectParams.Count;

        //                foreach (ParameterChangeData Param in msg.LoadRejectParams)
        //                {
        //                    this.List = 2;
        //                    foreach (ParameterChangeMode mode in Param.Modes)
        //                    {
        //                        this.Ascii = mode.PORTID.PadRight(4);
        //                        this.U1 = mode.RejectMode;
        //                    }
        //                }
        //            }                 
        //        }
        //    }
        //    SendMessage();
        //}  
        public void SendS9UnrecognizedData(eHostEventType hostEventType, string secs1)
		{
			if (hostEventType == eHostEventType.S9F3UnrecognizedStreamType) this.MakeSecsMsg(9, 3);
			else if (hostEventType == eHostEventType.S9F5UnrecognizedFunctionType) this.MakeSecsMsg(9, 5);
			else if (hostEventType == eHostEventType.S9F7IllegalData) this.MakeSecsMsg(9, 7);

			List<short> header = new List<short>();
			for (int i = 0; i < 30; i += 3)
				header.Add(Convert.ToInt16(secs1.Substring(i, 2), 16));
			this.B1s = header;

			SendMessage();
		}
        public void SendS10F3TerminalDisplaySinglea(S10F3TerminalDisplaySingle msg)
        {
            this.MakeSecsMsg(10, 3, HostType);
            this.List = 3;
            {
                this.U1 = msg.TerminalID;
                this.Ascii = msg.Text.PadRight(80);
                this.Ascii = msg.ModuleID.PadRight(27);
            }
            SendMessage();
        }
        //public void SendS3F101CassetteInfo(S3F101CassetteInfo msg)
        //{
        //    this.MakeSecsMsg(103, 101);
        //    this.List = 2;
        //    {
        //        this.U1 = msg.Cassette.HotDevice;
        //        this.List = 4;
        //        {
        //            this.List = 6;
        //            {
        //                this.Ascii = msg.Port.PortID.PadRight(4);
        //                this.U1 = (short)msg.Port.EqState;
        //                this.U1 = (short)msg.Port.PortState;
        //                this.U1 = (short)msg.Port.PortType;
        //                this.Ascii = msg.Port.PortMode.PadRight(2);
        //                this.U1 = (short)msg.Port.CstDemand;
        //            }
        //            this.List = 5;
        //            {
        //                this.Ascii = msg.Cassette.CstID.PadRight(16);
        //                this.Ascii = msg.Cassette.CstType.PadRight(4);
        //                this.Ascii = msg.Cassette.MapStif.PadRight(80);
        //                this.Ascii = msg.Cassette.CurStif.PadRight(80);
        //                this.U1 = (short)msg.Cassette.BatchOrder;
        //            }
        //            this.List = 1;
        //            {
        //                this.Ascii = msg.Cassette.AvailStif.PadRight(80);
        //            }
        //            this.List = LCData.GetMappingCount(msg.Cassette.CurStif);
        //            {
        //                for (int i = 0; i < LCData.GetMappingCount(msg.Cassette.CurStif); i++)
        //                {
        //                    this.List = 20;
        //                    {
        //                        this.Ascii = msg.Cassette.GlassDatas[i].HPanelID.PadRight(12);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].EPanelID.PadRight(12);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].SlotID.PadRight(2);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].ProcessID.PadRight(20);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].ProductID.PadRight(20);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].StepID.PadRight(12);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].BatchID.PadRight(12);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].ProdType.PadRight(2);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].ProdKind.PadRight(2);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].PPID.PadRight(16);
        //                        this.Ascii = msg.Cassette.GlassDatas[i].FlowID.PadRight(4);
        //                        this.U2s = msg.Cassette.GlassDatas[i].PanelSize;
        //                        this.U2 = msg.Cassette.GlassDatas[i].Thickness;
        //                        this.U2 = msg.Cassette.GlassDatas[i].CompCount;
        //                        this.Ascii = msg.Cassette.GlassDatas[i].DBRRecipe.PadRight(4);
        //                        this.List = 1;
        //                        {
        //                            this.List = 10;
        //                            {
        //                                for (int j = 0; j < 10; j++)
        //                                {
        //                                    this.Bools = msg.Cassette.GlassDatas[i].FlowGroups[j].BoolList;
        //                                }
        //                            }
        //                        }
        //                        this.List = 1;
        //                        {
        //                            this.List = 8;
        //                            {
        //                                this.U2 = (int)msg.Cassette.GlassDatas[i].PanelOtherProp1.PanelState;
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp1.ReadingFlag.PadRight(2);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp1.InsFlag.PadRight(2);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp1.PanelPosition.PadRight(2);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp1.Judgement.PadRight(4);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp1.Code.PadRight(4);
        //                                this.U1s = msg.Cassette.GlassDatas[i].PanelOtherProp1.FlowHistorys;
        //                                this.U1s = msg.Cassette.GlassDatas[i].PanelOtherProp1.UniqueID;
        //                            }
        //                        }
        //                        this.List = 1;
        //                        {
        //                            this.List = 5;
        //                            {
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp2.Count1.PadRight(2);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp2.Count2.PadRight(2);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp2.Grade.PadRight(64);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp2.MultiUse.PadRight(20);
        //                                this.List = 1;
        //                                {
        //                                    this.List = 2;
        //                                    {
        //                                        this.Ascii = msg.Cassette.GlassDatas[i].PanelOtherProp2.FlagName.PadRight(16);
        //                                        this.Bool = msg.Cassette.GlassDatas[i].PanelOtherProp2.FlagValue;
        //                                    }

        //                                }
        //                            }

        //                        }
        //                        this.List = 1;
        //                        {
        //                            this.List = 4;
        //                            {
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelPairProp.PairHPanelID.PadRight(12);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelPairProp.PairEPanelID.PadRight(12);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelPairProp.PairProductID.PadRight(20);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelPairProp.PairGrade.PadRight(64);
        //                            }
        //                        }
        //                        this.List = 1;
        //                        {
        //                            this.List = 3;
        //                            {
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelCellProp.SubPanelID.PadRight(12);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelCellProp.SubJudgement.PadRight(4);
        //                                this.Ascii = msg.Cassette.GlassDatas[i].PanelCellProp.SubCode.PadRight(4);
        //                            }
        //                        }
        //                    }

        //                }

        //            }
        //        }

        //    }
        //    SendMessage();
        //}
        public void SendS3F101CassetteInfo(S3F101CassetteInfo msg)
        {
            this.MakeSecsMsg(103, 101, HostType);
            this.List = 2;
            {
                this.U1 = msg.Cassette.HotDevice;
                this.List = 4;
                {
                    this.List = 6;
                    {
                        this.Ascii = msg.Port.PortID.PadRight(4);
                        this.U1 = (short)msg.Port.EqState;
                        this.U1 = (short)msg.Port.PortState;
                        this.U1 = (short)msg.Port.PortType;
                        this.Ascii = msg.Port.PortMode.PadRight(2);
                        this.U1 = (short)msg.Port.CstDemand;
                    }
                    this.List = 5;
                    {
                        this.Ascii = msg.Cassette.CstID.PadRight(16);
                        this.Ascii = msg.Cassette.CstType.PadRight(4);
                        this.Ascii = msg.Cassette.MapStif.PadRight(80);
                        this.Ascii = msg.Cassette.CurStif.PadRight(80);
                        this.U1 = (short)msg.Cassette.BatchOrder;
                    }
                    this.List = 1;
                    {
                        this.Ascii = msg.Cassette.AvailStif.PadRight(80);
                    }
                    this.List = LCData.GetMappingCount(msg.Cassette.CurStif);
                    {
                        for (int i = 0; i < LCData.GetMappingCount(msg.Cassette.CurStif); i++)
                        {
                            this.List = 20;
                            {
                                this.Ascii = msg.Cassette.GlassDatas[0].HPanelID.PadRight(12);
                                this.Ascii = msg.Cassette.GlassDatas[0].EPanelID.PadRight(12);
                                this.Ascii = LCData.GetSlotID(LCData.GetMappingCount(msg.Cassette.MapStif), LCData.GetMappingCount(msg.Cassette.CurStif),i).PadRight(2);
                                this.Ascii = msg.Cassette.GlassDatas[0].ProcessID.PadRight(20);
                                this.Ascii = msg.Cassette.GlassDatas[0].ProductID.PadRight(20);
                                this.Ascii = msg.Cassette.GlassDatas[0].StepID.PadRight(12);
                                this.Ascii = msg.Cassette.GlassDatas[0].BatchID.PadRight(12);
                                this.Ascii = msg.Cassette.GlassDatas[0].ProdType.PadRight(2);
                                this.Ascii = msg.Cassette.GlassDatas[0].ProdKind.PadRight(2);
                                this.Ascii = msg.Cassette.GlassDatas[0].PPID.PadRight(16);
                                this.Ascii = msg.Cassette.GlassDatas[0].FlowID.PadRight(4);
                                this.U2s = msg.Cassette.GlassDatas[0].PanelSize;
                                this.U2 = msg.Cassette.GlassDatas[0].Thickness;
                                this.U2 = msg.Cassette.GlassDatas[0].CompCount;
                                this.Ascii = msg.Cassette.GlassDatas[0].DBRRecipe.PadRight(4);
                                this.List = 1;
                                {
                                    this.List = 10;
                                    {
                                        for (int j = 0; j < 10; j++)
                                        {
                                            this.Bools = msg.Cassette.GlassDatas[0].FlowGroups[j].BoolList;
                                        }
                                    }
                                }
                                this.List = 1;
                                {
                                    this.List = 8;
                                    {
                                        this.U2 = (int)msg.Cassette.GlassDatas[0].PanelOtherProp1.PanelState;
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp1.ReadingFlag.PadRight(2);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp1.InsFlag.PadRight(2);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp1.PanelPosition.PadRight(2);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp1.Judgement.PadRight(4);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp1.Code.PadRight(4);
                                        this.U1s = msg.Cassette.GlassDatas[0].PanelOtherProp1.FlowHistorys;
                                        this.U1s = msg.Cassette.GlassDatas[0].PanelOtherProp1.UniqueID;
                                    }
                                }
                                this.List = 1;
                                {
                                    this.List = 5;
                                    {
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp2.Count1.PadRight(2);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp2.Count2.PadRight(2);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp2.Grade.PadRight(64);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp2.MultiUse.PadRight(20);
                                        this.List = 1;
                                        {
                                            this.List = 2;
                                            {
                                                this.Ascii = msg.Cassette.GlassDatas[0].PanelOtherProp2.FlagName.PadRight(16);
                                                this.Bool = msg.Cassette.GlassDatas[0].PanelOtherProp2.FlagValue;
                                            }

                                        }
                                    }

                                }
                                this.List = 1;
                                {
                                    this.List = 4;
                                    {
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelPairProp.PairHPanelID.PadRight(12);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelPairProp.PairEPanelID.PadRight(12);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelPairProp.PairProductID.PadRight(20);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelPairProp.PairGrade.PadRight(64);
                                    }
                                }
                                this.List = 1;
                                {
                                    this.List = 3;
                                    {
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelCellProp.SubPanelID.PadRight(12);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelCellProp.SubJudgement.PadRight(4);
                                        this.Ascii = msg.Cassette.GlassDatas[0].PanelCellProp.SubCode.PadRight(4);
                                    }
                                }
                            }

                        }

                    }
                }

            }
            SendMessage();
        }
	}

}

