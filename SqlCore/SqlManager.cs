using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using ClassCore;

namespace SqlCore
{
    public partial class SqlManager : Component
    {
        //변수
        private DataRetriever retriever;
        //생성자
        public SqlManager()
        {
            InitializeComponent();
        }
        public SqlManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        //파싱부분
        private bool BoolParse(string str)
        {
            bool result = false;

            try
            {
                string upper = str.Trim().ToUpper();
                if (upper == "T" || upper == "TRUE" || upper == "1" || upper == "255") result = true;
            }
            catch { }

            return result;
        }
        private short ShortParse(string str)
        {
            short result;

            try
            {
                result = short.Parse(str);
            }
            catch
            {
                result = -1;
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
                foreach (FlowGroupData m in list)
                {
                    result += m.Decimal.ToString() + " ";
                }
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }
        //접속 및 해제
        public bool ConnectDB(string connectionString)
        {
            retriever = new DataRetriever(connectionString);
            if (retriever.State != ConnectionState.Open) return false;

            return true;
        }
        public bool Disconnect()
        {
            return retriever.Disconnect();
        }
        //Get DB Query
        public string GetCCSType()
        {
            string ccsType = "";
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	ccs_type " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                ccsType = reader.GetString(0);

                reader.Close();
            }

            return ccsType;
        }
        public string GetLogPath()
        {
            string logPath = "";
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	log_path " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                logPath = reader.GetString(0);

                reader.Close();
            }

            return logPath;
        }
        public string GetAlarmLogPath()
        {
            string logPath = "";
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	alarmlog_path " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                logPath = reader.GetString(0);

                reader.Close();
            }

            return logPath;
        }
        public string GetTerminalLogPath()
        {
            string logPath = "";
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	terminallog_path " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                logPath = reader.GetString(0);

                reader.Close();
            }

            return logPath;
        }
        public List<string> GetEqStatePriority()
        {
            List<string> eqStatePriority = new List<string>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	eq_state_priority " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                string[] eqStates = reader.GetString(0).Split('/');
                foreach (string eqState in eqStates)
                {
                    eqStatePriority.Add(eqState);
                }
                reader.Close();
            }

            return eqStatePriority;
        }
        public List<string> GetProcStatePriority()
        {
            List<string> procStatePriority = new List<string>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	proc_state_priority " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                string[] procStates = reader.GetString(0).Split('/');
                foreach (string procState in procStates)
                {
                    procStatePriority.Add(procState);
                }
                reader.Close();
            }

            return procStatePriority;
        }
        public string GetAlarmlogPath()
        {
            string logPath = "";
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	alarmlog_path " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                logPath = reader.GetString(0);

                reader.Close();
            }

            return logPath;
        }
        public int GetStartJobNumber()
        {
            int jobNo = -1;
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	start_job_number " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                jobNo = reader.GetInt32(0);

                reader.Close();
            }

            return jobNo;
        }
        public int GetStartGlassNumber()
        {
            int glassNo = -1;
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	start_glass_number " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                glassNo = reader.GetInt32(0);

                reader.Close();
            }

            return glassNo;
        }
        public int GetOnlineMode()
        {
            int onLine = -1;
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	online_mode " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                onLine = reader.GetInt32(0);

                reader.Close();
            }

            return onLine;
        }
        public List<string> GetProcessVerion()
        {
            List<string> procVersion = new List<string>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	version " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                string[] procStates = reader.GetString(0).Split('/');
                foreach (string procState in procStates)
                {
                    procVersion.Add(procState);
                }
                reader.Close();
            }

            return procVersion;
        }
        public List<string> GetOperationInfo()
        {
            List<string> Opers = new List<string>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	operation " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                string[] procStates = reader.GetString(0).Split('/');
                foreach (string procState in procStates)
                {
                    Opers.Add(procState);
                }
                reader.Close();
            }

            return Opers;
        }
        public string GetPassword()
        {
            string logPath = "";
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	password " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                logPath = reader.GetString(0);

                reader.Close();
            }

            return logPath;
        }
        public int GetStandardTact()
        {
            int standardTact = -1;
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	standard_tact " +
                "FROM	ccs_info "
                ));

            if (reader != null && reader.Read())
            {
                standardTact = reader.GetInt32(0);

                reader.Close();
            }

            return standardTact;
        }
        public int GetModuleLayer()
        {
            int layer = 0;
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT	max(module_layer) " +
                "FROM	module_info "
                ));

            if (reader != null && reader.Read())
            {
                layer = reader.GetInt32(0);
                reader.Close();
            }
            return layer;
        }
        public List<ModuleData> GetModules()
        {
            List<ModuleData> modules = new List<ModuleData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		module_id, parent_module_id, module_layer, eq_id, unit_id, from_module_id, to_module_id " +
                "FROM		module_info " +
                "ORDER BY	module_layer, right(unit_id,2), left(module_id, len(module_id)-5), right(module_id,3) "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    ModuleData module = new ModuleData();
                    module.ID = reader.GetString(0);
                    module.ParentID = reader.GetString(1);
                    module.Layer = reader.GetInt32(2);
                    module.EqID = reader.GetString(3);
                    module.UnitID = reader.GetString(4);
                    module.FromModuleID = reader.GetString(5);
                    module.ToModuleID = reader.GetString(6);
                    modules.Add(module);
                }
                reader.Close();
            }

            foreach (ModuleData m in modules)
            {
                //Parent Module 설정
                foreach (ModuleData p in modules)
                {
                    if (p.ID == m.ParentID)
                    {
                        m.Parent = p;
                        break;
                    }
                }

                //Child Module 설정
                if (m.Parent != null)
                {
                    if (m.Parent.Childs == null) m.Parent.Childs = new List<ModuleData>();
                    m.Parent.Childs.Add(m);
                }
            }
            return modules;
        }
        //public List<PortInfoData> GetPorts()
        //{
        //    List<PortInfoData> PortInfos = new List<PortInfoData>();

        //    SqlDataReader reader = retriever.ExecuteReader(
        //        string.Format(
        //        "SELECT		port_no,  port_id, module_id, line, unit_id, eq_id " +
        //        "FROM		port_info ")
        //        );

        //    if (reader != null)
        //    {
        //        while (reader.Read())
        //        {
        //            PortInfoData PortInfo = new PortInfoData();
        //            PortInfo.Port_No = reader.GetInt32(0);
        //            PortInfo.PortID = reader.GetString(1);
        //            PortInfo.ModuleID = reader.GetString(2);
        //            PortInfo.line = (eLINE)reader.GetInt32(3);
        //            PortInfo.UnitID = reader.GetString(4);
        //            PortInfo.EqID = reader.GetString(5);

        //            PortInfos.Add(PortInfo);
        //        }
        //        reader.Close();
        //    }

        //    return PortInfos;
        //}


        public BatchManager GetL1Batchs()
        {
            BatchManager L1Batch = new BatchManager();

            SqlDataReader reader = retriever.ExecuteReader(
                string.Format(
                "SELECT		port_no,  port_id, module_id, line, unit_id, eq_id " +
                "FROM		port_info " + 
                "WHERE		line = 1 ")
                );

            if (reader != null)
            {
                L1Batch.TARGET_LINE = eLINE.LINE1;
                L1Batch.TARGET_MODULEID = LCData.FindParamTarget(eLINE.LINE1);


                while (reader.Read())
                {
                    PortData PortParam = new PortData();

                    PortParam.Port.PortNo = reader.GetInt32(0);
                    PortParam.Port.PortID = reader.GetString(1);
                    PortParam.ModuleID = reader.GetString(2);
                    PortParam.TargetLine = (eLINE)reader.GetInt32(3);
                    PortParam.UnitID = reader.GetString(4);
                    PortParam.EqID = reader.GetString(5);

                    L1Batch.PortDatas.Add(PortParam);
                }
                reader.Close();
            }

            return L1Batch;
        }
        public BatchManager GetL2Batchs()
        {
            BatchManager L2Batch = new BatchManager();

            SqlDataReader reader = retriever.ExecuteReader(
                string.Format(
                "SELECT		port_no,  port_id, module_id, line, unit_id, eq_id " +
                "FROM		port_info " +
                "WHERE		line = 2 ")
                );

            if (reader != null)
            {
                L2Batch.TARGET_LINE = eLINE.LINE2;
                L2Batch.TARGET_MODULEID = LCData.FindParamTarget(eLINE.LINE2);
                while (reader.Read())
                {
                    PortData PortParam = new PortData();
                    PortParam.Port.PortNo = reader.GetInt32(0);
                    PortParam.Port.PortID = reader.GetString(1);
                    PortParam.ModuleID = reader.GetString(2);
                    PortParam.TargetLine = (eLINE)reader.GetInt32(3);
                    PortParam.UnitID = reader.GetString(4);
                    PortParam.EqID = reader.GetString(5);

                    L2Batch.PortDatas.Add(PortParam);
                }
                reader.Close();
            }
            return L2Batch;
        }          
        public List<HostData> GetHosts()
        {
            List<HostData> hosts = new List<HostData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		type, ip, port, active, t1, t2, t3, t4, t5, t6, t7, t8, link_interval, log_path " +
                "FROM		host_info " +
                "ORDER BY	type "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    HostData host = new HostData();

                    host.HostType = (eHostType)reader.GetInt32(0);
                    host.IP = reader.GetString(1);
                    host.Port = reader.GetInt32(2);
                    host.Active = BoolParse(reader.GetString(3));
                    host.T1 = reader.GetInt32(4);
                    host.T2 = reader.GetInt32(5);
                    host.T3 = reader.GetInt32(6);
                    host.T4 = reader.GetInt32(7);
                    host.T5 = reader.GetInt32(8);
                    host.T6 = reader.GetInt32(9);
                    host.T7 = reader.GetInt32(10);
                    host.T8 = reader.GetInt32(11);
                    host.LinkInterval = reader.GetInt32(12);
                    host.LogPath = reader.GetString(13);
                    hosts.Add(host);
                }
                reader.Close();
            }

            return hosts;
        }
        public List<EqData> GetEqs()
        {
            List<EqData> eqs = new List<EqData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		type, ip, port, active, log_path, app_path " +
                "FROM		eq_info "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    EqData eq = new EqData();

                    eq.EqType = (eEqType)reader.GetInt32(0);
                    eq.IP = reader.GetString(1);
                    eq.Port = reader.GetInt32(2);
                    eq.Active = BoolParse(reader.GetString(3));
                    eq.LogPath = reader.GetString(4);
                    eq.AppPath = reader.GetString(5);
                    eqs.Add(eq);
                }
                reader.Close();
            }

            return eqs;
        }
        public List<EqOnlineParamData> GetEqOnlineParams()
        {
            List<EqOnlineParamData> eqOnlineParams = new List<EqOnlineParamData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		eoid, eomd, eov " +
                "FROM		eo_info " +
                "ORDER BY	eoid, eomd, eov "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    int eoid = reader.GetInt32(0);
                    string eomd = reader.GetString(1);
                    short eov = reader.GetInt16(2);

                    bool findEOID = false;
                    bool findEOMD = false;

                    foreach (EqOnlineParamData eo in eqOnlineParams)
                    {
                        if (eo.EOID == eoid)
                        {
                            findEOID = true;
                            foreach (EqOnlineParamMode mode in eo.Modes)
                            {
                                if (mode.EOMD == eomd)
                                {
                                    findEOMD = true;
                                    mode.EOV = eov;
                                    break;
                                }
                            }

                            //EOMD가 없을때 처리
                            if (!findEOMD)
                            {
                                eo.Modes.Add(new EqOnlineParamMode(eomd, eov));
                                break;
                            }
                        }
                    }

                    //EOID가 없을때 처리
                    if (!findEOID)
                    {
                        EqOnlineParamData eqOnlineParam = new EqOnlineParamData();
                        eqOnlineParam.EOID = eoid;
                        eqOnlineParam.Modes.Add(new EqOnlineParamMode(eomd, eov));
                        eqOnlineParams.Add(eqOnlineParam);
                    }

                }
                reader.Close();
            }

            return eqOnlineParams;
        }
        public List<EqConstantData> GetEqConstants()
        {
            List<EqConstantData> eqConstants = new List<EqConstantData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		ecid, ecdef " +
                "FROM		ec_info " +
                "ORDER BY	ecid "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    EqConstantData ec = new EqConstantData();
                    ec.ECID = reader.GetInt32(0);
                    ec.ECDEF = reader.GetString(1);
                    eqConstants.Add(ec);
                }
                reader.Close();
            }
            return eqConstants;
        }        
        public List<WIPQTYData> GetWIPQTYs()
        {
            List<WIPQTYData> eqQTYs = new List<WIPQTYData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		line, wipqty " +
                "FROM		wipqty_info " +
                "ORDER BY	line "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    WIPQTYData qty = new WIPQTYData();
                    qty.line = reader.GetInt32(0);
                    qty.WipQty = reader.GetInt32(1);

                    eqQTYs.Add(qty);
                }
                reader.Close();
            }
            return eqQTYs;
        }        
        public ParameterData GetParameter()
        {
            ParameterData eqParameter = new ParameterData();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		no, req_time1, req_time2, line_count, moduleid1, moduleid2, glass_type_chk, batch_run_mode, cancel_time " +
                "FROM param_info ORDER BY no "));

            if (reader != null)
            {
                while (reader.Read())
                {
                    eqParameter.no = reader.GetInt32(0);
                    eqParameter.ReqTime1 = reader.GetInt32(1);
                    eqParameter.ReqTime2 = reader.GetInt32(2);
                    eqParameter.LimitLineCount = reader.GetInt32(3);
                    eqParameter.L1ModuleID = reader.GetString(4);
                    eqParameter.L2ModuleID = reader.GetString(5);
                    eqParameter.GlassTypeCheck = reader.GetInt32(6);
                    eqParameter.BatchRunMode = reader.GetInt32(7);
                    eqParameter.Cancel_Time = reader.GetInt32(8);
                }
                reader.Close();
            }

            return eqParameter;
        }       
        public List<MappingData> GetMappings()
        {
            List<MappingData> mappings = new List<MappingData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		mapping_type, work_id, worker_id, flow_id, ec_id, mapping_text, mapping_text2 " +
                "FROM		mapping_info " +
                "ORDER BY	mapping_type, work_id, worker_id, flow_id, ec_id "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    MappingData mapping = new MappingData();
                    mapping.Type = (eMappingType)reader.GetInt32(0);
                    mapping.WorkID = reader.GetString(1);
                    mapping.WorkerID = reader.GetInt32(2);
                    mapping.FlowID = reader.GetString(3);
                    mapping.ECID = reader.GetInt32(4);
                    mapping.Text = reader.GetString(5);
                    mapping.Text2 = reader.GetString(6);
                    mappings.Add(mapping);
                }
                reader.Close();
            }

            return mappings;
        }
        public List<FlowGroupData> GetFlowGroups()
        {
            List<FlowGroupData> flowGroups = new List<FlowGroupData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		work_id, work_group, reserve, worker " +
                "FROM		flowgroup_info " +
                "ORDER BY	work_id, work_group "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    FlowGroupData flowGroup = new FlowGroupData();
                    flowGroup.WorkID = reader.GetString(0);
                    flowGroup.WorkGroup = reader.GetString(1);
                    flowGroup.Reserve = reader.GetString(2);
                    flowGroup.Worker = reader.GetString(3);
                    flowGroups.Add(flowGroup);
                }
                reader.Close();
            }

            return flowGroups;
        }
        public List<FlowRecipeData> GetFlowRecipes()
        {
            List<FlowRecipeData> flowRecipes = new List<FlowRecipeData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		flow_no, flow_id, revision, update_time, raw_data " +
                "FROM		flowrecipe_info " +
                "ORDER BY	flow_no "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    FlowRecipeData flowRecipe = new FlowRecipeData();
                    flowRecipe.FlowNo = reader.GetInt32(0);
                    flowRecipe.FlowID = reader.GetString(1);
                    flowRecipe.Revision = reader.GetString(2);
                    flowRecipe.UpdateTime = reader.GetString(3);
                    string[] rawDatas = reader.GetString(4).Split('/');
                    foreach (string rawData in rawDatas)
                    {
                        FlowBodyData flowData = new FlowBodyData();
                        flowData.Binary = rawData;
                        flowRecipe.FlowDatas.Add(flowData);
                    }
                    flowRecipes.Add(flowRecipe);
                }
                reader.Close();
            }

            return flowRecipes;
        }              
        public List<AlarmData> GetAlarmInfos()
        {
            List<AlarmData> alarmInfos = new List<AlarmData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		section, eq_id, unit_id, alarm_id, alarm_code, alarm_text " +
                "FROM		alarm_info " +
                "ORDER BY	eq_id, alarm_id "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    AlarmData alarmInfo = new AlarmData();

                    string section = reader.GetString(0);
                    if (section == eAlarmSection.MASTER.ToString()) alarmInfo.Section = eAlarmSection.MASTER;
                    else if (section == eAlarmSection.PIO.ToString()) alarmInfo.Section = eAlarmSection.PIO;
                    else alarmInfo.Section = eAlarmSection.UNIT;

                    alarmInfo.EqID = reader.GetString(1);
                    alarmInfo.UnitID = reader.GetString(2);
                    alarmInfo.ID = reader.GetInt32(3);
                    alarmInfo.Code = reader.GetInt16(4);
                    alarmInfo.Text = reader.GetString(5);
                    alarmInfos.Add(alarmInfo);
                }
                reader.Close();
            }

            return alarmInfos;
        }
        public List<StateRuleData> GetStateRules()
        {
            List<StateRuleData> stateRules = new List<StateRuleData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		prior_id, module_id, state, query, postfix " +
                "FROM		state_rule_info " +
                "ORDER BY	prior_id "
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    StateRuleData stateRule = new StateRuleData();
                    stateRule.PriorID = reader.GetInt32(0);
                    stateRule.ModuleID = reader.GetString(1);
                    stateRule.State = reader.GetString(2);
                    stateRule.Query = reader.GetString(3);
                    stateRule.Postfix = reader.GetString(4);
                    stateRules.Add(stateRule);
                }
                reader.Close();
            }

            return stateRules;
        }                  
        public string GetFlowIDCurrent()
        {
            string flowID = "";
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT TOP 1	flow_id " +
                "FROM			glass_history " +
                "ORDER BY		enter_time	DESC "
                ));

            if (reader != null && reader.Read())
            {
                flowID = reader.GetString(0);

                reader.Close();
            }

            return flowID;
        }

        public InterlockData GetInterlockDatas()
        {
            InterlockData Interlocks = new InterlockData();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		no, line, flowid, cf, ito, used " +
                "FROM		flowgroup_interlock_info " +
                "ORDER BY	no"
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    FlowGroupInterlock Interlock = new FlowGroupInterlock();
                    Interlock.No = reader.GetInt32(0);
                    Interlock.lineNo = (eLINE)reader.GetInt32(1);                    
                    Interlock.FlowID = reader.GetString(2);
                    Interlock.CF_Type = reader.GetInt32(3);
                    Interlock.ITO_Type = reader.GetInt32(4);
                    Interlock.Used = reader.GetInt32(5);

                    switch (Interlock.lineNo)
                    {
                        case eLINE.LINE1: Interlocks.L1Interlocks.Add(Interlock); break;
                        case eLINE.LINE2: Interlocks.L2Interlocks.Add(Interlock); break;
                    }
                }
                reader.Close();
            }

            return Interlocks;
        }

        public List<LogInfoData> GetLogInfoDatas()
        {
            List<LogInfoData> LogInfos = new List<LogInfoData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		no, serial_no, nack_code, comment " +
                "FROM		log_info " +
                "ORDER BY	no"
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    LogInfoData LogInfo = new LogInfoData();
                    LogInfo.No = reader.GetInt32(0);
                    LogInfo.SerialNo = reader.GetInt16(1);
                    LogInfo.NACKCode = reader.GetInt16(2);
                    LogInfo.Comment =  reader.GetString(3);
                    LogInfos.Add(LogInfo);
                }
                reader.Close();
            }
            return LogInfos;
        }      

        public HistorySetData GetHistoryPeriod()
        {
            HistorySetData eqHistoryPeriod = new HistorySetData();

            string query = string.Format("SELECT no, plan_history, plan_range, glass_history, glass_range, alarm_history, log_history " +
            "FROM history_period_info ORDER BY	no ");
            SqlDataReader reader = retriever.ExecuteReader(query);

            if (reader != null)
            {
                while (reader.Read())
                {
                    eqHistoryPeriod.No = reader.GetInt32(0);
                    eqHistoryPeriod.PlanHistoryPeriod   = reader.GetInt32(1);
                    eqHistoryPeriod.PlanHistoryRange    = reader.GetInt32(2);
                    eqHistoryPeriod.GlassHistoryPeriod  = reader.GetInt32(3);
                    eqHistoryPeriod.GlassHistoryRange   = reader.GetInt32(4);
                    eqHistoryPeriod.AlarmHistoryPeriod  = reader.GetInt32(5);
                    eqHistoryPeriod.LogHistoryPeriod    = reader.GetInt32(6);                   
                }
                reader.Close();
            }

            return eqHistoryPeriod;
        }
        public List<LogColorData> GetLogColors()
        {
            List<LogColorData> SerialColors = new List<LogColorData>();
            SqlDataReader reader = retriever.ExecuteReader(string.Format(
                "SELECT		serial, color_a, color_r, color_g, color_b  " +
                "FROM		log_color_info " +
                "ORDER BY	serial"
                ));

            if (reader != null)
            {
                while (reader.Read())
                {
                    LogColorData SerialColor = new LogColorData();
                    SerialColor.Serial = reader.GetInt32(0);
                    SerialColor.ColorA = reader.GetInt32(1);
                    SerialColor.ColorR = reader.GetInt32(2);
                    SerialColor.ColorG = reader.GetInt32(3);
                    SerialColor.ColorB = reader.GetInt32(4);
                    SerialColors.Add(SerialColor);
                }
                reader.Close();
            }

            return SerialColors;
        }       
        //Set DB Query
        public int SetStartJobNumber(int jobNo)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "UPDATE ccs_info " +
                "SET start_job_number = '{0}' ",
                jobNo));

        }
        public int SetStartGlassNumber(int glassNo)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "UPDATE ccs_info " +
                "SET start_glass_number = '{0}' ",
                glassNo));

        }
        public int SetOnlineMode(int mode)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "UPDATE ccs_info " +
                "SET online_mode = '{0}' ",
                mode));

        }
        public int SetEqOnlineParams(List<EqOnlineParamData> eqOnlineParams)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM eo_info "));

            if (result > -1)
            {
                foreach (EqOnlineParamData eo in eqOnlineParams)
                {
                    foreach (EqOnlineParamMode mode in eo.Modes)
                    {
                        result = retriever.ExecuteNonQuery(string.Format(
                            "INSERT INTO eo_info " +
                            "(eoid, eomd, eov) " +
                            "VALUES ({0}, '{1}', {2}) ",
                            eo.EOID, mode.EOMD, mode.EOV));
                    }
                }
            }

            return result;
        }
        public int SetEqConstant(List<EqConstantData> eqConstants)
        {
            int result = 0;

            foreach (EqConstantData ecid in eqConstants)
            {
                result = retriever.ExecuteNonQuery(string.Format(
                    "UPDATE ec_info " +
                    "SET ecdef = '{0}' " +
                    "WHERE ecid = '{1}' ",
                    ecid.ECDEF,
                    ecid.ECID));
            }
            return result;
        }
        public int SetParameterInfo(ParameterData eqParam)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM param_info "));

            if (result > -1)
            {
                string query = string.Format(
                        "INSERT INTO param_info " +
                        "(no, req_time1, req_time2, line_count, moduleid1, moduleid2, glass_type_chk, batch_run_mode, cancel_time) " +
                        "VALUES ({0}, {1}, {2}, {3}, '{4}', '{5}', {6}, {7}, {8}) ",
                        eqParam.no, eqParam.ReqTime1, eqParam.ReqTime2, eqParam.LimitLineCount, eqParam.L1ModuleID, eqParam.L2ModuleID, eqParam.GlassTypeCheck, eqParam.BatchRunMode, eqParam.Cancel_Time );
                result = retriever.ExecuteNonQuery(query);

            }
            return result;
        }        


        public int SetInterlockInfo(InterlockData Interlocks)
		{
			int result = 0;

            foreach (FlowGroupInterlock interlock in Interlocks.L1Interlocks)
			{
				result |= retriever.ExecuteNonQuery(string.Format(
                    "UPDATE flowgroup_interlock_info " +
					"SET used = '{0}' " +
					"WHERE no = '{1}' ",
                    interlock.Used,
                    interlock.No));
			}

             foreach (FlowGroupInterlock interlock in Interlocks.L2Interlocks)
			{
				result |= retriever.ExecuteNonQuery(string.Format(
                    "UPDATE flowgroup_interlock_info " +
					"SET used = '{0}' " +
					"WHERE no = '{1}' ",
                    interlock.Used,
                    interlock.No));
			}
			return result ;
		}
      //  public int SetInterlockInfo2(List<FlowGroupInterlock> Interlocks)
        //{
        //    int result = 0;

        //    foreach (FlowGroupInterlock interlock in Interlocks)
        //    {
        //        result = retriever.ExecuteNonQuery(string.Format(
        //            "UPDATE flowgroup_interlock_info " +
        //            "SET used = '{0}' " +
        //            "WHERE no = '{1}' ",
        //            interlock.Used,
        //            interlock.No));
        //    }
        //    return result;
        //}
        public int SetHistoryPeriodInfo(HistorySetData eqPeriod)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM history_holding_info "));

            if (result > -1)
            {
                string query = string.Format(
                        "INSERT INTO history_holding_info " +
                        "(no, plan_history, plan_range, glass_history, glass_range, alarm_history, log_history ) " +
                        "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}') ",
                        eqPeriod.No, eqPeriod.PlanHistoryPeriod, eqPeriod.PlanHistoryRange, eqPeriod.GlassHistoryPeriod, eqPeriod.GlassHistoryRange, eqPeriod.AlarmHistoryPeriod, eqPeriod.LogHistoryPeriod);
                result = retriever.ExecuteNonQuery(query);

            }
            return result;
        }
        public int SetWIPQTYInfo()
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM wipqty_info "));
            if (result > -1)
            {
                foreach (WIPQTYData ec in LCData.WIPQTYs)
                {
                    result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO wipqty_info " +
                        "(line, wipqty) " +
                        "VALUES ({0}, '{1}') ",
                        ec.line, ec.WipQty));
                }
            }       
            return result;
        }
        public int SetEqConstants(List<EqConstantData> eqConstants)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM ec_info "));

            if (result > -1)
            {
                foreach (EqConstantData ec in eqConstants)
                {
                    result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO ec_info " +
                        "(ecid, ecdef, ecsll, ecsul, ecwll, ecwul) " +
                        "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}') ",
                        ec.ECID, ec.ECDEF, ec.ECSLL, ec.ECSUL, ec.ECWLL, ec.ECWUL));
                }
            }

            return result;
        }
        public int SetMapping(MappingData mapping)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "UPDATE mapping_info " +
                "SET mapping_text = '{0}', mapping_text2 = '{1}' " +
                "WHERE mapping_type = {2} AND work_id = '{3}' AND worker_id = {4} AND flow_id = '{5}' AND ec_id = {6} ",
                mapping.Text, mapping.Text2, (int)mapping.Type, mapping.WorkID, mapping.WorkerID, mapping.FlowID, mapping.ECID));

            if (result < 1)
            {
                result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO mapping_info " +
                        "(mapping_type, work_id, worker_id, flow_id, ec_id, mapping_text, mapping_text2) " +
                        "VALUES ({0}, '{1}', {2}, '{3}', {4}, '{5}', '{6}') ",
                        (int)mapping.Type, mapping.WorkID, mapping.WorkerID, mapping.FlowID, mapping.ECID, mapping.Text, mapping.Text2));
            }

            return result;
        }
        public int SetMappings(List<MappingData> mappings)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM mapping_info "));

            if (result > -1)
            {
                foreach (MappingData mapping in mappings)
                {
                    result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO mapping_info " +
                        "(mapping_type, work_id, worker_id, flow_id, ec_id, mapping_text, mapping_text2) " +
                        "VALUES ({0}, '{1}', {2}, '{3}', {4}, '{5}', '{6}') ",
                        (int)mapping.Type, mapping.WorkID, mapping.WorkerID, mapping.FlowID, mapping.ECID, mapping.Text, mapping.Text2));
                }
            }

            return result;
        }
        public int SetFlowGroups(List<FlowGroupData> flowGroups)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM flowgroup_info "));

            if (result > -1)
            {
                foreach (FlowGroupData flowGroup in flowGroups)
                {
                    result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO flowgroup_info " +
                        "(work_id, work_group, reserve, worker) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}') ",
                        flowGroup.WorkID, flowGroup.WorkGroup, flowGroup.Reserve, flowGroup.Worker));
                }
            }

            return result;
        }
        public int SetFlowRecipe(FlowRecipeData flowRecipe)
        {
            string rawData = "";
            foreach (FlowBodyData flowBody in flowRecipe.FlowDatas)
            {
                rawData = rawData + flowBody.Binary + "/";
            }
            rawData = rawData.Substring(0, rawData.Length - 1);

            int result = retriever.ExecuteNonQuery(string.Format(
                "UPDATE flowrecipe_info " +
                "SET flow_id = '{0}', revision = '{1}', update_time = '{2}', raw_data = '{3}' " +
                "WHERE flow_no = {4} ",
                flowRecipe.FlowID, flowRecipe.Revision, flowRecipe.UpdateTime, rawData, flowRecipe.FlowNo));

            if (result < 1)
            {
                result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO flowrecipe_info " +
                        "(flow_no, flow_id, revision, update_time, raw_data) " +
                        "VALUES ({0}, '{1}', '{2}', '{3}', '{4}') ",
                        flowRecipe.FlowNo, flowRecipe.FlowID, flowRecipe.Revision, flowRecipe.UpdateTime, rawData));
            }

            return result;
        }
        public int SetFlowRecipes(List<FlowRecipeData> flowRecipes)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM flowrecipe_info "));

            if (result > -1)
            {
                foreach (FlowRecipeData flowRecipe in flowRecipes)
                {
                    string rawData = "";
                    foreach (FlowBodyData flowBody in flowRecipe.FlowDatas)
                    {
                        rawData = rawData + flowBody.Binary + "/";
                    }
                    rawData = rawData.Substring(0, rawData.Length - 1);

                    result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO flowrecipe_info " +
                        "(flow_no, flow_id, revision, update_time, raw_data) " +
                        "VALUES ({0}, '{1}', '{2}', '{3}', '{4}') ",
                        flowRecipe.FlowNo, flowRecipe.FlowID, flowRecipe.Revision, flowRecipe.UpdateTime, rawData));
                }
            }

            return result;
        }
        public int SetFromToModules(List<ModuleData> modules)
        {
            int result = 0;

            foreach (ModuleData module in modules)
            {
                result = retriever.ExecuteNonQuery(string.Format(
                    "UPDATE module_info " +
                    "SET from_module_id = '{0}', to_module_id = '{1}' " +
                    "WHERE module_id = '{2}' ",
                    module.FromModuleID,
                    module.ToModuleID,
                    module.ID));
            }

            return result;
        }
        public int SetAlarmInfos(DataTable dataTable, string table)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM alarm_info "));

            if (result > -1)
            {
                return retriever.BulkCopy(dataTable, table);
            }

            return result;
        }
        public int SetEqStatePriority(List<string> eqStatePriority)
        {
            string listString = "";
            if (eqStatePriority.Count > 0)
            {
                foreach (string eqState in eqStatePriority)
                {
                    listString += eqState + "/";
                }
                listString = listString.Substring(0, listString.Length - 1);
            }

            return retriever.ExecuteNonQuery(string.Format(
                "UPDATE ccs_info " +
                "SET eq_state_priority = '{0}' ",
                listString));
        }
        public int SetProcStatePriority(List<string> procStatePriority)
        {
            string listString = "";
            if (procStatePriority.Count > 0)
            {
                foreach (string procState in procStatePriority)
                {
                    listString += procState + "/";
                }
                listString = listString.Substring(0, listString.Length - 1);
            }

            return retriever.ExecuteNonQuery(string.Format(
                "UPDATE ccs_info " +
                "SET proc_state_priority = '{0}' ",
                listString));
        }
        public int SetStateRules(List<StateRuleData> stateRules)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM state_rule_info "));

            if (result > -1)
            {
                foreach (StateRuleData stateRule in stateRules)
                {
                    result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO state_rule_info " +
                        "(prior_id, module_id, state, query, postfix) " +
                        "VALUES ({0}, '{1}', '{2}', '{3}', '{4}') ",
                        stateRule.PriorID, stateRule.ModuleID, stateRule.State,
                        stateRule.Query, stateRule.Postfix));
                }
            }

            return result;
        }     
        public int SetStandardTact(int standardTact)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "UPDATE ccs_info " +
                "SET standard_tact = {0} ",
                standardTact));
        }                
         //Log DB Query
        public LogHistoryData GetLogHistorys(string fromDateTime, string toDateTime, string serial,string nackoption, string searchOption)
        {
            LogHistoryData logs = new LogHistoryData();
            string query = "SELECT	log_time, log_text, log_line, log_type " +
                        "FROM	log_history " +
                        "WHERE	(log_time > " + fromDateTime + " AND log_time < " + toDateTime + ") ";
                       

            char[] separator = { ' ' };
            string[] options = searchOption.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] nacks = nackoption.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (options.Length > 0)
            {
                foreach (string option in options)
                {
                    query = query + "AND log_text LIKE '%" + option + "%' ";
                }
            }
            if (nacks.Length > 0)
            {
                foreach (string nack in nacks)
                {
                    query = query + "AND log_text LIKE '%" + nack + "%' ";
                }
            }

            if (serial.Length > 0)
            {
                query = query + "AND log_type >= '" + short.Parse(serial) + "' AND log_type < '" + (short.Parse(serial)+1000) +"'";
            }

            query = query + " ORDER BY log_time desc";

            SqlDataReader reader = retriever.ExecuteReader(query);
            if (reader != null)
            {
                while (reader.Read())
                {
                    LogData log = new LogData();
                    log.Time = reader.GetString(0);
                    log.Text = reader.GetString(1);
                    log.line = reader.GetInt16(2);
                    log.log_type = reader.GetInt16(3);

                    switch (log.line)
                    {
                        case 1: logs.L1Count++; break;
                        case 2: logs.L2Count++; break;
                    }
                    logs.LogHistorys.Add(log);

                }
                reader.Close();
            }

            return logs;
        }

        //Log DB Query
        public LogHistoryData GetLogHistorys(int LogCount)
        {
            LogHistoryData logs = new LogHistoryData();
            string query = "SELECT	TOP (" + LogCount.ToString() + ") log_time, log_text, log_line FROM log_history ORDER BY log_time DESC ";            

            SqlDataReader reader = retriever.ExecuteReader(query);
            if (reader != null)
            {
                while (reader.Read())
                {
                    LogData log = new LogData();
                    log.Time = reader.GetString(0);
                    log.Text = reader.GetString(1);
                    log.line = reader.GetInt16(2);

                    switch (log.line)
                    {
                        case 1: logs.L1Count++; break;
                        case 2: logs.L2Count++; break;
                    }
                    logs.LogHistorys.Add(log);

                }
                reader.Close();
            }
            return logs;
        }



        public LogHistoryData GetTerminalHistorys(string fromDateTime, string toDateTime, string searchOption)
        {
            LogHistoryData logs = new LogHistoryData();
            string query = "SELECT	time, message " +
                        "FROM	terminal_history " +
                        "WHERE	(time > " + fromDateTime + " AND time < " + toDateTime + ") ";

            char[] separator = { ' ' };
            string[] options = searchOption.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (options.Length > 0)
            {
                foreach (string option in options)
                {
                    if (option == "Load")
                    {
                        query = query + "AND message LIKE '%" + " " + option + "%' ";

                    }
                    else
                    {
                        query = query + "AND message LIKE '%" + option + "%' ";
                    }
                    
                }
            }

            query = query + " ORDER BY time desc";

            SqlDataReader reader = retriever.ExecuteReader(query);
            if (reader != null)
            {
                while (reader.Read())
                {
                    LogData log = new LogData();
                    log.Time = reader.GetString(0);
                    log.Text = reader.GetString(1);

                    logs.L1Count++;
                    logs.LogHistorys.Add(log);
                }
                reader.Close();
            }

            return logs;
        }
        public List<AlarmHistoryData> GetAlarmHistorys(string fromDateTime, string toDateTime, string searchOption, int alarmOn)
        {
            List<AlarmHistoryData> logs = new List<AlarmHistoryData>();
            string query = "SELECT	time, alarm_on, module_id, section, plc, unit_id, alarm_id, type, reason, alarm_text " +
                        "FROM	alarm_history " +
                        "WHERE	(time > " + fromDateTime + " AND time < " + toDateTime + ")"; 

            if (alarmOn != 2)
            {
                query = query + " AND (alarm_on =" + alarmOn + ") ";
            }

            char[] separator = { ' ' };
            string[] options = searchOption.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (options.Length > 0)
            {
                foreach (string option in options)
                {
                    query = query + "AND alarm_text LIKE '%" + option + "%' ";
                }
            }

            query = query + " ORDER BY time desc";

            SqlDataReader reader = retriever.ExecuteReader(query);
            if (reader != null)
            {
                while (reader.Read())
                {
                    AlarmHistoryData log = new AlarmHistoryData();
                    log.Time = reader.GetString(0);
                    log.Alarm_On = reader.GetInt16(1);
                    log.Moduleid = reader.GetString(2);
                    log.Section = reader.GetString(3);
                    log.Plc = reader.GetString(4);
                    log.Unit_id = reader.GetString(5);
                    log.Alarm_id = reader.GetString(6);
                    log.Type = reader.GetString(7);
                    log.Reason = reader.GetString(8);
                    log.Alarm_text = reader.GetString(9);

                    logs.Add(log);
                }
                reader.Close();
            }
            return logs;
        }
        public BatchHistoryData GetBatchHistorys(string fromDateTime, string toDateTime, string Keyword)
        {
            BatchHistoryData BatchLogs = new BatchHistoryData();
            string query = "SELECT	update_time, moduleid, order_no, priority, prod_kind, prod_type, processid, productid, stepid, ppid, flowid, " +
                           "batchid, batch_state, batch_size, p_maker, p_thincness, f_panelid, c_panelid, input_line, valid_flag, " +
                           "c_qty, o_qty, r_qty, n_qty, flowgroup, start_time, end_glassid, line " +
                            "FROM	batch_history " +
                           "WHERE	(update_time > " + fromDateTime + " AND update_time < " + toDateTime + ") ";

            char[] separator = { ' ' };
            string[] options = Keyword.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (options.Length > 0)
            {
                foreach (string option in options)
                {
                    query = query + "AND f_panelid LIKE '%" + option + "%' ";
                }
            }

            query = query + " ORDER BY update_time desc";

            SqlDataReader reader = retriever.ExecuteReader(query);
            if (reader != null)
            {
                while (reader.Read())
                {
                    BatchLogData BatchLog = new BatchLogData();

                    BatchLog.Update_Time = reader.GetString(0);
                    BatchLog.ModuleID = reader.GetString(1);
                    BatchLog.OrderNo = reader.GetString(2);
                    BatchLog.Priority = reader.GetString(3);
                    BatchLog.Prod_Kind = reader.GetString(4);
                    BatchLog.Prod_Type = reader.GetString(4);
                    BatchLog.ProcessID = reader.GetString(6);
                    BatchLog.ProductID = reader.GetString(7);
                    BatchLog.StepID = reader.GetString(8);
                    BatchLog.PPID = reader.GetString(9);
                    BatchLog.FlowID = reader.GetString(10);
                    BatchLog.BatchID = reader.GetString(11);
                    BatchLog.Batch_State = reader.GetString(12);
                    BatchLog.Batch_Size = reader.GetString(13);
                    BatchLog.P_Maker = reader.GetString(14);
                    BatchLog.P_Thickness = reader.GetString(15);
                    BatchLog.F_PanelID = reader.GetString(16);
                    BatchLog.C_PanelID = reader.GetString(17);
                    BatchLog.Input_Line = reader.GetString(18);
                    BatchLog.Valid_Flag = reader.GetString(19);
                    BatchLog.C_QTY = reader.GetString(20);
                    BatchLog.O_QTY = reader.GetString(21);
                    BatchLog.R_QTY = reader.GetString(22);
                    BatchLog.N_QTY = reader.GetString(23);
                    BatchLog.FlowGroupList = reader.GetString(24);
                    BatchLog.StartTime = reader.GetString(25);
                    BatchLog.END_PANELID = reader.GetString(26);
                    BatchLog.line = reader.GetInt16(27);

                    switch (BatchLog.line)
                    {
                        case 1: BatchLogs.L1Count++; break;
                        case 2: BatchLogs.L2Count++; break;
                    }

                    BatchLogs.BatchLogHistorys.Add(BatchLog);
                }
                reader.Close();
            }

            return BatchLogs;
        }
        public BatchHistoryData GetGlassHistorys(string fromDateTime, string toDateTime, string Keyword)
        {
            BatchHistoryData GlassLogs = new BatchHistoryData();
            string query = "SELECT	issue_time, issue_batchid, issue_fpanelid, issue_glassid, issue_uniqueid, line " +
                           "FROM	issue_history " +
                           "WHERE	(issue_time > " + fromDateTime + " AND issue_time < " + toDateTime + ") ";
                           
            char[] separator = { ' ' };
            string[] options = Keyword.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (options.Length > 0)
            {
                foreach (string option in options)
                {
                    query = query + "AND f_panelid LIKE '%" + option + "%' ";
                }
            }

            query = query + " ORDER BY issue_time desc";

            SqlDataReader reader = retriever.ExecuteReader(query);
            if (reader != null)
            {
                while (reader.Read())
                {
                    BatchLogData GlassLog = new BatchLogData();

                    GlassLog.Update_Time = reader.GetString(0);
                    GlassLog.BatchID = reader.GetString(1);
                    GlassLog.F_PanelID = reader.GetString(2);
                    GlassLog.C_PanelID = reader.GetString(3);
                    GlassLog.UniqueID = reader.GetString(4);
                    GlassLog.line = reader.GetInt16(5);

                    switch (GlassLog.line)
                    {
                        case 1: GlassLogs.L1Count++; break;
                        case 2: GlassLogs.L2Count++; break;
                    }
                    GlassLogs.BatchLogHistorys.Add(GlassLog);
                }
                reader.Close();
            }

            return GlassLogs;
        }
        


        //public int SetAlarm(string dateTime, short alarmOn, string Moduleid, string section, string plc, string unit_id, string alarmid, string type, string reason, string logText)
        public int SetAlarm(string dateTime, AlarmData alarmInfo)
        {
            string query = string.Format("INSERT INTO alarm_history " +
                 "(time, alarm_on, module_id, section, plc, unit_id, alarm_id, type, reason, alarm_text) " +
                 "VALUES ('{0}', '{1}', '{2}' , '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}') ",
                 dateTime, (short)alarmInfo.AlarmSet, alarmInfo.ModuleID, (short)alarmInfo.Section, alarmInfo.EqID, alarmInfo.UnitID, alarmInfo.ID.ToString(), (short)alarmInfo.AlarmType, (short)alarmInfo.AlarmReason, alarmInfo.Text);

            return retriever.ExecuteNonQuery(query);
        }
	    public int SetLog(string dateTime, string log, short line, short serial)
        {
            string query = string.Format(
                "INSERT INTO log_history " +
                "(log_time, log_text, log_line, log_type) " +
                "VALUES ('{0}', '{1}', {2}, {3} ) ",
                dateTime, log, line, serial);
            return retriever.ExecuteNonQuery(query);
        }
        public int SetTerminalLog(string dateTime, string logText)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "INSERT INTO terminal_history " +
                "(time, message) " +
                "VALUES ('{0}', '{1}' ) ",
                dateTime, logText));
        }
        public int SetPlanHistorys(string dateTime, BatchObject PlanData, string TargetModuleID, short Targetline)
        {
            string temp = "";
            string strSql = "";
            int result = retriever.ExecuteNonQuery(strSql = string.Format(
                        "INSERT INTO Batch_history " +
                        "(update_time, moduleid, order_no, priority, prod_kind, prod_type,processid,productid,stepid,ppid,flowid,batchid,batch_state, " +
                        "batch_size, p_maker, p_thincness, f_panelid, c_panelid, input_line, valid_flag, c_qty, o_qty, r_qty, n_qty, flowgroup, start_time, end_glassid, line) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', " +
                        "'{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}' ) ",
                        dateTime, TargetModuleID, PlanData.ORDER_NO,
                PlanData.PRIORITY, PlanData.PROD_KIND, PlanData.PROD_TYPE, PlanData.PROCESSID, PlanData.PRODUCTID, PlanData.STEPID, PlanData.PPID,
                PlanData.FLOWID, PlanData.BATCHID, PlanData.BATCH_STATE, PlanData.BATCH_SIZE, PlanData.P_MAKER, PlanData.P_THICKNESS,
                PlanData.F_PANELID, PlanData.C_PANELID, PlanData.INPUT_LINE, PlanData.VALID_FLAG, PlanData.C_QTY, PlanData.O_QTY,
                PlanData.R_QTY, PlanData.N_QTY, temp, PlanData.StartTime, PlanData.END_PANELID, Targetline));

            return result;
        }
        public int SetGlassIDHistory(string dateTime, string BatchID, string FPanelID, string GlassID, string UniqueID, short line)
        {
            //string tem = string.Format(
            //    "INSERT INTO issue_history " +
            //    "(issue_time,issue_batchid, issue_fpanelid, issue_glassid, issue_uniqueid, line) " +
            //    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') ",
            //    dateTime, BatchID, FPanelID, GlassID, UniqueID, line);

            return retriever.ExecuteNonQuery(string.Format(
                "INSERT INTO issue_history " +
                "(issue_time,issue_batchid, issue_fpanelid, issue_glassid, issue_uniqueid, line) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') ",
                dateTime, BatchID, FPanelID, GlassID, UniqueID, line));
        }
        


        public int DeleteLog(string dateTime)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM log_history WHERE log_time < " + dateTime));
        }
        public int DeleteMessage(string dateTime)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM terminal_history WHERE time < " + dateTime));
        }
        public int DeleteAlarmLog(string dateTime)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM alarm_history WHERE time < " + dateTime));
        }
        public int DeleteBatchHistorys(string dateTime)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM batch_history WHERE update_time < " + dateTime));
        }
        public int DeleteGlassID(string dateTime)
        {
            return retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM issue_history WHERE issue_time < " + dateTime));
        }
        


        //생산계획정보 Last History DB Query
        public BatchObject GetLastBatch(string searchOption)
        {
            BatchObject BatchObj = new BatchObject();

            string query = "SELECT	TOP (1) prod_kind, prod_type, processid, productid, stepid, ppid, batchid, batch_size, p_maker, p_thincness, f_panelid, c_qty " +
                           "FROM	plan_history " +
                           "WHERE	moduleid LIKE '%" + searchOption + "%'" +
                           "ORDER BY update_time desc";

            SqlDataReader reader = retriever.ExecuteReader(query);
            if (reader != null)
            {
                if (reader.Read())
                {
                    BatchObj.PROD_KIND = reader.GetString(0);
                    BatchObj.PROD_TYPE = reader.GetString(1);
                    BatchObj.PROCESSID = reader.GetString(2);
                    BatchObj.PRODUCTID = reader.GetString(3);
                    BatchObj.STEPID = reader.GetString(4);
                    BatchObj.PPID = reader.GetString(5);
                    BatchObj.BATCHID = reader.GetString(6);
                    BatchObj.BATCH_SIZE = int.Parse(reader.GetString(7));
                    BatchObj.P_MAKER = reader.GetString(8);
                    BatchObj.P_THICKNESS = int.Parse(reader.GetString(9));
                    BatchObj.F_PANELID = reader.GetString(10);
                    BatchObj.C_QTY = int.Parse(reader.GetString(11));
                }
                reader.Close();
            }

            return BatchObj;
        }
        public int SetLogColorSetInfo(LogColorData newColor)
        {
            return retriever.ExecuteNonQuery(string.Format("UPDATE log_color_info SET color_a = '{0}',color_r = '{1}',color_g = '{2}', color_b = '{3}' where serial = '{4}'", newColor.ColorA, newColor.ColorR, newColor.ColorG, newColor.ColorB, newColor.Serial));
        }
        
        public int SetLogColorInfo(List<LogColorData> eqColors)
        {
            int result = retriever.ExecuteNonQuery(string.Format(
                "DELETE FROM log_serialcolor_info "));

            if (result > -1)
            {
                foreach (LogColorData eqColor in eqColors)
                {
                    result = retriever.ExecuteNonQuery(string.Format(
                        "INSERT INTO log_serialcolor_info " +
                        "(serial, color_a, color_r, color_g, color_b ) " +
                        "VALUES ({0}, {1}, {2}, {3}, {4}) ",
                        eqColor.Serial, eqColor.ColorA, eqColor.ColorR, eqColor.ColorG, eqColor.ColorB));
                }             
            }
            return result;
        }
        //중복되면 true, 비중복이면 false return
        public bool IsDuplicateGlassID(string F_PANELID, int range)
        {			
			bool result = false;

			SqlDataReader reader = retriever.ExecuteReader(
				"SELECT		TOP(" + range.ToString() + ") issue_glassid " +
				"FROM		issue_history " +
				"ORDER BY	issue_time	DESC ");

			if (reader != null)
			{
				while (reader.Read())
				{
					if (F_PANELID == reader.GetString(0))
					{
						result = true;
						break;
					}
				}
				reader.Close();
			}

			return result;
        }
        //중복되면 true, 비중복이면 false return
        public bool IsDuplicateBatch(string F_PANELID, int range)
        {	
			bool result = false;

			SqlDataReader reader = retriever.ExecuteReader(
				"SELECT		TOP(" + range.ToString() + ") f_panelid " +
				"FROM		batch_history " +
				"ORDER BY	update_time	DESC ");

			if (reader != null)
			{
				while (reader.Read())
				{
					if (F_PANELID == reader.GetString(0))
					{
						result = true;
						break;
					}
				}
				reader.Close();
			}

			return result;
        }
    }
}
