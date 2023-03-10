using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;

namespace ClassCore
{
	public class LCData
	{
		//전역변수
		public static string CCSType = "";
        public static string LogPath = "";
        public static string AlarmLogPath = "";
        public static int JobStart = 0;
        public static int GlassStart = 0;
        public static List<string> Version = null;
        public static List<string> Operation = null;
        public static string Password = "";

        public static eMCMD OnlineHostState = eMCMD.OFFLINE;
        public static eEIPCMD OnlinePLCState = eEIPCMD.OFFLINE;

        public static int ModuleLayer = 0;
        
		public static List<ModuleData> Modules = null;
		public static List<AlarmData> Alarms = null;
		public static List<EqOnlineParamData> EqOnlineParams = null;
        public static List<ParameterChangeData> LoadRejectParams = null;
		public static List<EqConstantData> EqConstants = null;
        public static List<WIPQTYData> WIPQTYs = null;    
		public static List<FlowGroupData> FlowGroups = null;
		public static List<FlowRecipeData> FlowRecipes = null;
		public static List<AlarmData> AlarmInfos = null;
		public static List<MappingData> Mappings = null;
		public static List<string> EqStatePriority = null;
		public static List<string> ProcStatePriority = null;
		public static List<StateRuleData> StateRules = null;
		public static int StandardTact = -1;
		public static eFlowRecipeMode ModifyFlowRecipeMode;
		public static FlowRecipeData ModifyFlowRecipe = null;
        public static ParameterData Parameter = null;
        public static HistorySetData HistoryPeriodSet = null;
        public static LogColorData LogColorDataSet = null;

		public static eByWho ChangeEqOnlineParamByWho;
        public static eByWho ChangeLoadRejectParamsByWho;

		public static List<EqOnlineParamData> ChangeEqOnlineParams = new List<EqOnlineParamData>();
        public static List<BatchManager> BatchManagers = new List<BatchManager>();
  
		public static int logCount = 0;
		public static string logDateTime = "";
        public static int batchlogCount = 0;
        public static string batchlogDateTime = "";
        public static int glasslogCount = 0;
        public static string glasslogDateTime = "";
        public static int alarmlogCount = 0;
        public static string alarmlogDateTime = "";
        public static int messagelogCount = 0;
        public static string messagelogDateTime = "";

        public static LogHistoryData logHistoryDatas = null;
        public static BatchHistoryData batchHistoryDatas = null;
        public static InterlockData interlockDatas = null;

        public static List<LogColorData> logColors = new List<LogColorData>();
        public static List<AlarmHistoryData> alarmHistoryDatas = new List<AlarmHistoryData>();
		public static List<R6GlassControlReport> GlassEvents = new List<R6GlassControlReport>();

        public static List<LogInfoData> logInfoDatas = new List<LogInfoData>();

		//전역변수 접근함수      
		public static ModuleData FindModule(string moduleID)
		{
			if (moduleID.Length == 4)
			{
				foreach (ModuleData module in LCData.Modules)
				{
					if (module.ID.Substring(module.ID.Length - 4, 4) == moduleID) return module;
				}
			}
			else
			{
				foreach (ModuleData module in LCData.Modules)
				{
					if (module.ID == moduleID) return module;
				}
			}

			return null;
		}     


		public static ModuleData FindModule(string eqID, string unitID)
		{
			foreach (ModuleData module in LCData.Modules)
			{
				if (module.EqID == eqID && module.UnitID == unitID) return module;
			}

			return null;
		}
   
        //PortNo 값으로 해당 Batch 정보를 가져옴.
        public static BatchManager FindBatch(int PortNo)
        {
            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                foreach (PortData PortInfo in BatchInfo.PortDatas)
                {
                    if (PortInfo.Port.PortNo == PortNo) return BatchInfo;
                }
            }
            return null;
        }
        //Line 값으로 해당 Batch 정보를 가져옴.
        public static BatchManager FindBatch(eLINE Line)
        {
            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                if (BatchInfo.TARGET_LINE == Line) return BatchInfo;
            }
            return null;
        }
        //ModuleID 값으로 해당 Batch 정보를 가져옴.
        public static BatchManager FindBatch(string ModuleID)
        {
            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                if (BatchInfo.TARGET_MODULEID == ModuleID) return BatchInfo;
            }
            return null;
        }
        //EQID와 UnitID 값으로 해당 Batch 정보를 가져옴.
        public static BatchManager FindBatch(string EqID, string UnitID)
        {
            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                foreach (PortData PortInfo in BatchInfo.PortDatas)
                {
                    if (PortInfo.EqID == EqID && PortInfo.UnitID == UnitID) return BatchInfo;
                }
            }
            return null;
        }

        public static BatchManager FindBatch(string ModuleID, string UnitID, bool check)
        {
            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                foreach (PortData PortInfo in BatchInfo.PortDatas)
                {
                    if (PortInfo.ModuleID == ModuleID && PortInfo.UnitID == UnitID) return BatchInfo;
                }
            }
            return null;
        }     

        public static int FindParamTime1()
        {
            return (LCData.Parameter.ReqTime1 * 60) * 1000;//분 단위
        }
        public static int FindParamTime2()
        {
            return LCData.Parameter.ReqTime2 * 1000;//초 단위
        }
        public static int FindParamLine()
        {
            return LCData.Parameter.LimitLineCount;
        }   
        public static string FindParamTarget(eLINE eLine)
        {
            return eLine == eLINE.LINE1 ? LCData.Parameter.L1ModuleID : LCData.Parameter.L2ModuleID;
        }

        public static bool FindParamTypeCheck()
        {
            return LCData.Parameter.GlassTypeCheck == 1 ? true : false;
        }
        public static bool FindParamBatchRun()
        {
            return LCData.Parameter.BatchRunMode == 1 ? true : false;
        }
        public static int FindParamCancelTime()
        {
            return LCData.Parameter.Cancel_Time * 1000;//초 단위
        }    
       
		public static ModuleData FindParentModule(ModuleData module, int layer)
		{
			if (module != null)
			{
				if(module.Layer == layer) return module;
				else if(module.Parent != null)
				{
					if(module.Parent.Layer == layer) return module.Parent;
					else if (module.Parent.Parent != null)
					{
						if (module.Parent.Parent.Layer == layer) return module.Parent.Parent;
					}
				}
			}
			return null;
		}
		public static ModuleData FindGlass(string hPanelID)
		{
			foreach (ModuleData module in LCData.Modules)
			{
				if (module.Glass != null)
				{
					if (module.Glass.HPanelID == hPanelID)
					{
						return module;
					}
				}
			}
			return null;
		}
     
		public static ModuleData RemoveGlass(string hPanelID)
		{
			foreach (ModuleData module in LCData.Modules)
			{
				if (module.Glass != null)
				{
					if (module.Glass.HPanelID == hPanelID)
					{
						module.Glass = null;
						return module;
					}
				}
			}
			return null;
		}       



		public static int GetContainModule(string moduleID)
		{
			int result = 0;
			foreach (ModuleData module in LCData.Modules)
			{
				if (module.Layer == LCData.ModuleLayer && module.ID.Contains(moduleID)) result++;
			}
			return result;
		}

		public static bool IsTraceStart(ModuleData oldModule, ModuleData nowModule)
		{
			int layer = GetEqOnlineParam(1, "1") - 1;

			ModuleData old = FindParentModule(oldModule, layer);
			ModuleData now = FindParentModule(nowModule, layer);

			if (old == null || now == null) return true;
			else if (old.ID != now.ID) return true;

			return false;
		}
		public static bool IsTraceEnd(ModuleData nowModule, ModuleData preModule)
		{
			int layer = GetEqOnlineParam(1, "2") - 1;

			ModuleData now = FindParentModule(nowModule, layer);
			ModuleData pre = FindParentModule(preModule, layer);

			if (now == null || pre == null) return true;
			else if (now.ID != pre.ID) return true;

			return false;
		}

		public static bool IsState(string moduleID, string state)
		{
			foreach (StateRuleData stateRule in LCData.StateRules)
			{
				if (stateRule.ModuleID == moduleID && stateRule.State == state)
				{
					string stateResult = LCData.GetState(stateRule.Postfix, stateRule.State);
					if (stateResult == "1")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			return true;
		}

        public static string GetState(string postFix, string state)
        {
            if (string.IsNullOrEmpty(postFix)) return null;

            string[] splits = postFix.Split(' ');

            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i] != "&" && splits[i] != "|")
                {
                    ModuleData module = LCData.FindModule(splits[i]);
                    if (module != null)
                    {
                        if (state == module.EqState.ToString()) splits[i] = "1";
                        else if (state == module.ProcState.ToString()) splits[i] = "1";
                        else splits[i] = "0";
                    }
                }
            }

            return Notation.CalculatePostFix(splits);
        }

		public static short GetEqOnlineParam(int eoid, string eomd)
		{
			short result = 0;
			foreach(EqOnlineParamData eo in LCData.EqOnlineParams)
			{
				if (eo.EOID == eoid)
				{
					foreach (EqOnlineParamMode mode in eo.Modes)
					{
						if (mode.EOMD == eomd) return mode.EOV;
					}
				}
			}
			return result;
		}

		public static void SetEqOnlineParam(int eoid, string eomd, short eov)
		{
			bool findEOID = false;
			bool findEOMD = false;

			foreach (EqOnlineParamData eo in LCData.EqOnlineParams)
			{
				if (eo.EOID == eoid)
				{
					findEOID = true;
					foreach (EqOnlineParamMode mode in eo.Modes)
					{
						if (mode.EOMD == eomd)
						{
							findEOMD = true;
							if (mode.EOV != eov)
							{
								mode.EOV = eov;
								mode.IsChange = true;
							}
							break;
						}
					}

					//EOMD가 없을때 처리
					if (!findEOMD)
					{
						eo.Modes.Add(new EqOnlineParamMode(eomd, eov, true));
						break;
					}
				}
			}

			//EOID가 없을때 처리
			if (!findEOID)
			{
				EqOnlineParamData eqOnlineParam = new EqOnlineParamData();
				eqOnlineParam.EOID = eoid;
				eqOnlineParam.Modes.Add(new EqOnlineParamMode(eomd, eov, true));
				LCData.EqOnlineParams.Add(eqOnlineParam);
			}
		}
        public static short GetLoadRejectParam(int pcmd, string portid)
        {
            short result = 0;
            foreach (ParameterChangeData Param in LCData.LoadRejectParams)
            {
                if (Param.PCMD == pcmd)
                {
                    foreach (ParameterChangeMode mode in Param.Modes)
                    {
                        if (mode.PORTID == portid) return mode.RejectMode;
                    }
                }
            }
            return result;
        }

        public static void SetLoadRejectParam(int pcmd, string portid, short rejectmode)
        {
            bool findPCMD = false;
            bool findPORTID = false;

            foreach (ParameterChangeData Param in LCData.LoadRejectParams)
            {
                if (Param.PCMD == pcmd)
                {
                    findPCMD = true;
                    foreach (ParameterChangeMode mode in Param.Modes)
                    {
                        if (mode.PORTID == portid)
                        {
                            findPORTID = true;
                            if (mode.RejectMode != rejectmode)
                            {
                                mode.RejectMode = rejectmode;
                                mode.IsChange = true;
                            }
                            break;
                        }
                    }

                    //PORTID가 없을때 처리
                    if (!findPORTID)
                    {
                        Param.Modes.Add(new ParameterChangeMode(portid, rejectmode, true));
                        break;
                    }
                }
            }

            //PCMD가 없을때 처리
            if (!findPCMD)
            {
                ParameterChangeData eqLoadRejectParam = new ParameterChangeData();
                eqLoadRejectParam.PCMD = pcmd;
                eqLoadRejectParam.Modes.Add(new ParameterChangeMode(portid, rejectmode, true));
                LCData.LoadRejectParams.Add(eqLoadRejectParam);
            }
        }


		public static string GetMapping(eMappingType type, string id)
		{
			string result = " ";

			if (type == eMappingType.WorkID)
			{
				foreach (MappingData mapping in LCData.Mappings)
				{
					if (mapping.Type == eMappingType.WorkID && mapping.WorkID == id)
					{
						return mapping.Text;
					}
				}
			}
			else if (type == eMappingType.FlowID)
			{
				foreach (MappingData mapping in LCData.Mappings)
				{
					if (mapping.Type == eMappingType.FlowID && mapping.FlowID == id)
					{
						return mapping.Text;
					}
				}
			}

			return result;
		}

        public static string GetMappingWorkID(eMappingType type, string txtData)
        {
            string result = " ";

            if (type == eMappingType.WorkID)
            {
                foreach (MappingData mapping in LCData.Mappings)
                {
                    if (mapping.Type == eMappingType.WorkID && mapping.Text == txtData)
                    {
                        return mapping.WorkID;
                    }
                }
            }         
            return result;
        }


		public static string GetMapping(eMappingType type, int ecid)
		{
			string result = " ";

			if (type == eMappingType.ECID)
			{
				foreach (MappingData mapping in LCData.Mappings)
				{
					if (mapping.Type == eMappingType.ECID && mapping.ECID == ecid)
					{
						return mapping.Text;
					}
				}
			}

			return result;
		}
		public static string GetMapping(eMappingType type, string workID, int workerID)
		{
			string result = " ";

			if (type == eMappingType.WorkerID)
			{
				foreach (MappingData mapping in LCData.Mappings)
				{
					if (mapping.Type == eMappingType.WorkerID && mapping.WorkID == workID && mapping.WorkerID == workerID)
					{
						return mapping.Text;
					}
				}
			}

			return result;
		}
		public static string GetMapping2(eMappingType type, string workID)
		{
			string result = " ";

			if (type == eMappingType.WorkID)
			{
				foreach (MappingData mapping in LCData.Mappings)
				{
					if (mapping.Type == eMappingType.WorkID && mapping.WorkID == workID)
					{
						return mapping.Text2;
					}
				}
			}

			return result;
		}
		public static void SetMapping(eMappingType type, int ecid, string mappingText)
		{
			bool find = false;

			foreach (MappingData mapping in LCData.Mappings)
			{
				if (mapping.Type == type && mapping.ECID == ecid)
				{
					mapping.Text = mappingText;
					find = true;
					break;
				}
            }
			if (!find)
			{
				if (type == eMappingType.ECID)
				{
					MappingData mapping = new MappingData();
					mapping.Type = type;
					mapping.ECID = ecid;
					mapping.Text = mappingText;
					LCData.Mappings.Add(mapping);
				}
			}
		}
		public static void SetMapping(eMappingType type, string workID, int workerID, string mappingText)
		{
			bool find = false;

			foreach (MappingData mapping in LCData.Mappings)
			{
				if (mapping.Type == type && mapping.WorkID == workID && mapping.WorkerID == workerID)
				{
					mapping.Text = mappingText;
					find = true;
					break;
				}
			}

			if (!find)
			{
				if (type == eMappingType.WorkerID)
				{
					MappingData mapping = new MappingData();
					mapping.Type = type;
					mapping.WorkID = workID;
					mapping.WorkerID = workerID;
					mapping.Text = mappingText;
					LCData.Mappings.Add(mapping);
				}
			}
		}
		public static void SetMapping(eMappingType type, string id, string mappingText)
		{
			bool find = false;

			foreach (MappingData mapping in LCData.Mappings)
			{
				if ((mapping.Type == type && mapping.WorkID == id) ||
					(mapping.Type == type && mapping.FlowID == id))
				{
					mapping.Text = mappingText;
					find = true;
					break;
				}
            }
			if (!find)
			{
				if (type == eMappingType.WorkID)
				{
					MappingData mapping = new MappingData();
					mapping.Type = type;
					mapping.WorkID = id;
					mapping.Text = mappingText;
					LCData.Mappings.Add(mapping);
				}
				else if (type == eMappingType.FlowID)
				{
					MappingData mapping = new MappingData();
					mapping.Type = type;
					mapping.FlowID = id;
					mapping.Text = mappingText;
					LCData.Mappings.Add(mapping);
				}
			}
		}

		public static AlarmData GetAlarmInfo(eAlarmSection section, string eqID, int alarmID)
		{
			foreach (AlarmData alarmInfo in LCData.AlarmInfos)
			{
				if (alarmInfo.Section == section && alarmInfo.EqID == eqID && alarmInfo.ID == alarmID)
				{
					return alarmInfo;
				}
			}
			
			return null;
		}
		public static AlarmData GetAlarm(eAlarmSection section, string eqID, int alarmID)
		{
			foreach (AlarmData alarm in LCData.Alarms)
			{
				if (alarm.Section == section && alarm.EqID == eqID && alarm.ID == alarmID)
				{
					return alarm;
				}
			}

			return null;
		}
		public static AlarmData GetAlarm(string eqID, string unitID, int alarmID)
		{
			foreach (AlarmData alarm in LCData.Alarms)
			{
				if (alarm.EqID == eqID && alarm.UnitID == unitID && alarm.ID == alarmID)
				{
					return alarm;
				}
			}

			return null;
		}
		public static AlarmData GetAlarm(string moduleID, int alarmID)
		{
			foreach (AlarmData alarm in LCData.Alarms)
			{
				if (alarm.ModuleID == moduleID && alarm.ID == alarmID)
				{
					return alarm;
				}
			}
			return null;
		}
        //09.21
        public static EqConstantData GetEqConstant(int ecid)
        {
            foreach (EqConstantData eqConstant in LCData.EqConstants)
            {
                if (eqConstant.ECID == ecid) return eqConstant;
            }
            return null;
        }

        public static WIPQTYData GetWIPQTY(int line)
        {
            foreach (WIPQTYData eqWIPQTY in LCData.WIPQTYs)
            {
                if (eqWIPQTY.line == line) return eqWIPQTY;
            }
            return null;
        }     
        
        public static List<FlowGroupData> GetFlowGroup(string workID)
        {
            List<FlowGroupData> flowGroups = new List<FlowGroupData>();
            foreach (FlowGroupData flowGroup in FlowGroups)
            {
                if (flowGroup.WorkID == workID)
                {
                    flowGroups.Add(flowGroup);
                }
            }
            return flowGroups;
        }



        public static bool IsFlowGroupInterlock(eLINE line, string FlowID, List<FlowGroupData> Groups)
        {
            bool result = false;

            switch(line)
            {
                case eLINE.LINE1:
                {
                    foreach (FlowGroupInterlock interlock in LCData.interlockDatas.L1Interlocks)
                    {
                        if (interlock.FlowID == FlowID && interlock.Used == 1 &&
                            System.Convert.ToInt32(Groups[0].Worker, 2) ==  interlock.CF_Type && 
                            System.Convert.ToInt32(Groups[1].Worker, 2) ==  interlock.ITO_Type)
                        {
                            result = true;
                            break;
                        }
                    }
                }
                break;
                case eLINE.LINE2:
                {
                    foreach (FlowGroupInterlock interlock in LCData.interlockDatas.L2Interlocks)
                    {
                        if (interlock.FlowID == FlowID && interlock.Used == 1 &&
                            System.Convert.ToInt32(Groups[0].Worker, 2) ==  interlock.CF_Type && 
                            System.Convert.ToInt32(Groups[1].Worker, 2) ==  interlock.ITO_Type)
                        {
                            result = true;
                            break;
                        }
                    }
                }
                break;
            }
            return result;
        }       
		public static FlowRecipeData GetFlowRecipe(int flowNo)
		{
			foreach (FlowRecipeData flowRecipe in LCData.FlowRecipes)
			{
				if (flowRecipe.FlowNo == flowNo) return flowRecipe;
			}
			return null;
		}

		public static FlowRecipeData GetFlowRecipe(string flowID)
		{
			foreach (FlowRecipeData flowRecipe in LCData.FlowRecipes)
			{
				if (flowRecipe.FlowID == flowID) return flowRecipe;
			}
			return null;
		}

		public static void SetFlowRecipe(FlowRecipeData flowRecipe)
		{
			foreach (FlowRecipeData fr in LCData.FlowRecipes)
			{
				if (fr.FlowNo == flowRecipe.FlowNo)
				{
					fr.FlowID = flowRecipe.FlowID;
					fr.Revision = flowRecipe.Revision;
					fr.UpdateTime = flowRecipe.UpdateTime;
					fr.FlowDatas = flowRecipe.FlowDatas;
					return;
				}
			}
			LCData.FlowRecipes.Add(flowRecipe);
		}       

        public static string GetCreatePanelID(int Index, string BatchID, string FPanelID)  //size 1 이면 현재 자신것, size 2이면 다음것
        {
            int batchIDIndex1 = 0;
            int batchIDIndex2 = 0;

            char[] batchIDChars = new char[]
		    {
			    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			    'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
		    };

            for (int i = 0; i < 36; i++)
            {
                if (FPanelID[FPanelID.Length - 2] == batchIDChars[i])
                    batchIDIndex1 = i;
                if (FPanelID[FPanelID.Length - 1] == batchIDChars[i])
                    batchIDIndex2 = i;
            }


            batchIDIndex2 += Index;
            while (batchIDIndex2 >= 36)
            {
                batchIDIndex1++;
                if (batchIDIndex1 >= 36)
                    batchIDIndex1 = 0;
                batchIDIndex2 -= 36;
            }
            return string.Format("{0}{1}{2}", BatchID.Remove(BatchID.Length - 2, 2), batchIDChars[batchIDIndex1].ToString(), batchIDChars[batchIDIndex2].ToString());
        }

        public static List<string> GetGlassIDList(string BatchID, string FPanelID, int Size)
        {
            List<string> GlassList = new List<string>();

            int batchIDIndex1 = 0;
            int batchIDIndex2 = 0;

            if (BatchID.Length > 5 && FPanelID.Length > 7)
            {

                GlassList.Add(FPanelID);
                for (int j = 1; j < Size; j++)
                {
                    char[] batchIDChars = new char[]
		            {
			            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
		            };


                    string Serial = "";
                    Serial = FPanelID.Substring(6, 2);


                    for (int i = 0; i < 36; i++)
                    {
                        if (Serial[0] == batchIDChars[i]) batchIDIndex1 = i;
                        if (Serial[1] == batchIDChars[i]) batchIDIndex2 = i;
                    }


                    batchIDIndex2++;
                    if (batchIDIndex2 >= 36)
                    {
                        batchIDIndex2 = 0;
                        batchIDIndex1++;
                        if (batchIDIndex1 >= 36)
                        {
                            batchIDIndex1 = 0;
                        }
                    }

                    FPanelID = BatchID.Substring(0, 6) + batchIDChars[batchIDIndex1].ToString() + batchIDChars[batchIDIndex2].ToString();
                    GlassList.Add(FPanelID);
                }
                return GlassList;
            }           
            return null;
        }



        //public static List<BatchGlassData> BatchGlassIDsInfo(string BatchID, string FPanelID, int Size)
        //{
        //    List<BatchGlassData> glassList = new List<BatchGlassData>();


        //    int batchIDIndex1 = 0;
        //    int batchIDIndex2 = 0;

        //    if (BatchID.Length > 5 && FPanelID.Length > 7)
        //    {
        //        BatchGlassData glassid2 = new BatchGlassData();
        //        glassid2.GlassID = FPanelID;
        //        glassList.Add(glassid2);

        //        // glassList.Add(FPanelID);
        //        for (int j = 1; j < Size; j++)
        //        {
        //            BatchGlassData glassid = new BatchGlassData();

        //            char[] batchIDChars = new char[]
        //            {
        //                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
        //                'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        //            };


        //            string Serial = "";
        //            Serial = FPanelID.Substring(6, 2);


        //            for (int i = 0; i < 36; i++)
        //            {
        //                if (Serial[0] == batchIDChars[i]) batchIDIndex1 = i;
        //                if (Serial[1] == batchIDChars[i]) batchIDIndex2 = i;
        //            }


        //            batchIDIndex2++;
        //            if (batchIDIndex2 >= 36)
        //            {
        //                batchIDIndex2 = 0;
        //                batchIDIndex1++;
        //                if (batchIDIndex1 >= 36)
        //                {
        //                    batchIDIndex1 = 0;
        //                }
        //            }

        //            FPanelID = BatchID.Substring(0, 6) + batchIDChars[batchIDIndex1].ToString() + batchIDChars[batchIDIndex2].ToString();
        //            glassid.GlassID = FPanelID;

        //            glassList.Add(glassid);
        //        }
        //        return glassList;
        //    }
        //    return null;
        //}



        public static string ReverseString(string str)
        {
            string Result = "";
            char[] CharStr = str.ToCharArray();

            for (int i = CharStr.Length - 1; i >= 0; i--)
            {
                Result += CharStr[i].ToString();
            }

            return Result;
        }

        //Host에 보고시에는 binary 형태로 ....
         public static string GetHostMapping(string SlotCount)
        {
            string result = "";

            for (int i = 0; i < int.Parse(SlotCount); i++)
            {
                result += "1";
            }
            return int.Parse(SlotCount) > 20 ? result.PadLeft(30, '0') : result.PadLeft(20, '0');
        }


        public static string GetHostMapping(string SlotCount, int descCnt)
        {
            string result = "";


            if (int.Parse(SlotCount) > 0)
                SlotCount = (int.Parse(SlotCount) - descCnt).ToString() ;

            for (int i = 0; i < int.Parse(SlotCount); i++)
            {
                result += "1";
            }
            return int.Parse(SlotCount) > 20 ? result.PadLeft(30, '0') : result.PadLeft(20, '0');
        }

        //Equipment에 보고시에는 Decimal 형태로 ....
        public static int GetEqMapping(string SlotCount)
        {
            string temp = "";
            string result = temp.PadLeft(int.Parse(SlotCount), '1');

            string binary = ReverseString(result.PadLeft(20, '0'));
            return System.Convert.ToInt32(binary, 2);
        }

        //binary 타입의 데이터를 해당 Slot 개수 만큼 Counting 처리.
        public static int GetMappingCount(string SlotCount)
        {
            char[] token = { '1' };

            string[] count = SlotCount.Split(token);

            return count.Length - 1;
        }

        public static int GetIndexSlot(string SlotCount)
        {
            int result = -1;

            if (SlotCount == "30") SlotCount = "20";

            short [] Chars = new short []
		    {
			    20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1
		    };

            for (int i = 0; i < 20; i++)
            {
                if (Chars[i] == int.Parse(SlotCount))
                {
                    result = i + 1;
                    break;
                }
            }
            return result;
        }       


        // "15" -> "00000111111111111111" (flg  = true 이면, minus 1)
        // 문자열이 공백이면 0, 
        // 숫자 타입의 문자열을 숫자로 컨버팅하여 바이너리 타입의 문자열로 변환.
        // 설비에서 받은 수량에 대한 Count 처리.
        // flg가 true이면, 원래의 수량에서 1을 뺀다.
        public static string GetToBinary(string str, bool flg)
        {
            int count = 0;
            string result = "";

            if (str == "") str = "0";

            if (str == "30") str = "20";

            count = (flg ? int.Parse(str) - 1 : int.Parse(str));
                
            for (int i = 0; i < count; i++)
            {
                result += "1";
            }
          
            return result.PadLeft(20, '0');
        }

        // "00000111111111111111"  - > "15" 
        // 문자열이 공백이면 0, 
        // 바이너리 타입의 문자열을 오른쪽부터 체크하여 1인경우에 Count증가.
        // Host에서 받은 수량에 대한 Count 처리.
        public static int GetToString(string str)
        {
            int count = 0;

            if (str != "")
            {
                for (int i = 0; i < 20; i++)
                {
                    if (str.Substring(i, 1) == "1")
                        count += 1;
                }
            }
            return count;
        }     

     
      
        // 문자열이 숫자타입이면 true , 문자타입이면 false
        public static bool CheckNumber(string str)
        {

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                    continue;
                else
                    return false;     

            }
            return true;          
        }

        //private static string HexToDec(string s)
        //{
        //    string HexToDec = "";
        //    try
        //    {
        //        HexToDec = Convert.ToInt64(s, 16).ToString();
        //    }

        //    catch (Exception ex)
        //    {
        //        HexToDec = ex.Message.ToString();
        //    }

        //    return HexToDec;

        //}

        //private static string DecToHex(string s)
        //{
        //    string DecToHex = "";

        //    try
        //    {
        //        //decimal decs = Decimal.Parse(s);
        //        long decs = Int64.Parse(s);
        //        DecToHex = Convert.ToString(decs, 16);
        //    }

        //    catch (Exception ex)
        //    {
        //        DecToHex = ex.Message.ToString();
        //    }

        //    return DecToHex;
        //}
        

        public static int GetGlassCount()
        {
            return LCData.GlassStart;
        }
        public static void SetGlassCount()
        {
            if (LCData.GlassStart >= 255 || LCData.GlassStart == 0)
                LCData.GlassStart = 1;
            else
                LCData.GlassStart++;
            
        }
        public static int GetJobCount()
        {
            return LCData.JobStart;
        }
        public static void SetJobCount()
        {
            if (LCData.JobStart >= 255 || LCData.JobStart == 0)
                LCData.JobStart = 1;
            else
                LCData.JobStart++;
        }

        public static string GetSlotID(int Start, int End, int Inc)
        {
            int result = (20 - End) + (Inc + 1);
            return result.ToString().PadLeft(2, '0');
        }

        public static LogColorData FindLogColor(int SerialNo)
        {
            foreach (LogColorData ColorData in LCData.logColors)
            {
                if (ColorData.Serial == SerialNo)
                {
                    return ColorData;
                }
            }
            return null;
        }

        public static int FindWIPQTY(int line)
        {
            foreach (WIPQTYData data in LCData.WIPQTYs)
            {
                if (data.line == line)
                    return data.WipQty;
            }
            return 0;
        }


        public static void SaveAll()
        {
            XmlAttributeOverrides a = new XmlAttributeOverrides();
            XmlAttributes attr = new XmlAttributes();
            attr.XmlIgnore = true;

            XmlSerializer mySerializer = new XmlSerializer(typeof(List<BatchManager>), a);


            //Serialize
            Stream stream = new FileStream("ini.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            mySerializer.Serialize(stream, LCData.BatchManagers);
            stream.Close();          

        }


        public static void LoadAll()
        {
            try
            {
                if (File.Exists("ini.xml"))
                {
                    StreamReader sr = new StreamReader("ini.xml");
                    XmlSerializer xs = new XmlSerializer(typeof(List<BatchManager>));

                    LCData.BatchManagers = (List<BatchManager>)xs.Deserialize(sr);
                    sr.Close();
                }
            }
            catch (Exception)
            {
              
            }
        }

        public static void SaveBatCh(eLINE line, BatchObject obj)
        {
            XmlAttributeOverrides a = new XmlAttributeOverrides();
            XmlAttributes attr = new XmlAttributes();
            attr.XmlIgnore = true;

            XmlSerializer mySerializer = new XmlSerializer(typeof(BatchObject), a);


            //Serialize
            Stream stream = new FileStream(line.ToString() + ".xml", FileMode.Create, FileAccess.Write, FileShare.None);
            mySerializer.Serialize(stream, obj);
            stream.Close();

        }

        public static BatchObject LoadBatch(eLINE line)
        {
            try
            {
                if (File.Exists(line.ToString() + ".xml"))
                {
                    BatchObject obj = new BatchObject();
                    StreamReader sr = new StreamReader(line.ToString() + ".xml");
                    XmlSerializer xs = new XmlSerializer(typeof(BatchObject));

                    obj = (BatchObject)xs.Deserialize(sr);
                    sr.Close();

                    return obj;
                }
            }
            catch (Exception)
            {
                
            }
            return null;
        }

        public static List<FlowGroupInterlock> FindInterlock(eLINE line, string flowID)
        {
            List<FlowGroupInterlock> interlocks = new List<FlowGroupInterlock>();
            switch (line)
            {
                case eLINE.LINE1:
                    {
                        foreach (FlowGroupInterlock interlock in LCData.interlockDatas.L1Interlocks)
                        {
                            if (interlock.lineNo == eLINE.LINE1 && interlock.FlowID == flowID)
                            {
                                interlocks.Add(interlock);
                            }
                        }
                    }
                    break;
                case eLINE.LINE2:
                    {
                        foreach (FlowGroupInterlock interlock in LCData.interlockDatas.L2Interlocks)
                        {
                            if (interlock.lineNo == eLINE.LINE2 && interlock.FlowID == flowID)
                            {
                                interlocks.Add(interlock);
                            }
                        }
                    }
                    break;
            }
            return interlocks;
        }

        public static LogInfoData FindLogInfo(short serial)
        {
            foreach (LogInfoData logInfo in LCData.logInfoDatas)
            {
                if (logInfo.SerialNo ==  serial)
                    return logInfo;
            }
            return null;
        }

        public static LogInfoData FindLogInfo(short serial, short code)
        {
            foreach (LogInfoData logInfo in LCData.logInfoDatas)
            {
                if (logInfo.SerialNo >= serial && logInfo.NACKCode == code)
                    return logInfo;
            }
            return null;
        }

        public static void SetBatchGlass(string glassid)
        {
            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                foreach (BatchGlassData batchGlass in BatchInfo.BatchGlassIDs)
                {
                    if (batchGlass.GlassID == glassid)
                    {
                        batchGlass.Check = true;
                        break;
                    }
                }
            }
        }


        public static BatchManager GetBatchGlass(string glassid, ref int idx)
        {
            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                idx = 0;
                foreach (BatchGlassData batchGlass in BatchInfo.BatchGlassIDs)
                {

                    if (batchGlass.GlassID == glassid)
                    {
                        return BatchInfo;
                    }
                    idx++;
                }
            }
            return null;
        }
    }
}
