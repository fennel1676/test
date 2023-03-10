using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClassCore;

namespace ProdPlanManager
{
    public partial class SubOperationControl : UserControl
    {
        //public delegate void FlowSetViewEventHandler();
        //public event FlowSetViewEventHandler FlowSetView;

        public delegate void WIPQTYSetViewEventHandler();
        public event WIPQTYSetViewEventHandler WIPQTYSetView;

        public delegate void BatchHistoryViewEventHandler(string fromDate, string toDate, string key, int sel);
        public event BatchHistoryViewEventHandler BatchHistoryView;
        public delegate void AlarmHistoryViewEventHandler(string fromDate, string toDate, string key, int on);
        public event AlarmHistoryViewEventHandler AlarmHistoryView;
        public delegate void UpdateSetEventHandler();

        public event UpdateSetEventHandler UpdateParameterSet;
        public event UpdateSetEventHandler UpdateInterlockSet;
        public event UpdateSetEventHandler UpdatePeriodSet;
        public event UpdateSetEventHandler UpdateLogcolorSet;
        public delegate void LogHistoryViewEventHandler(string fromDate, string toDate, string serial,string nak, string key, int sel);
        public event LogHistoryViewEventHandler LogHistoryView;
        public event UpdateSetEventHandler UpdateECIDSet;


        BatchHistoryForm batchHistoryFrm = null;
        AlarmHistoryForm alarmHistoryFrm = null;
        MaintenaceSetForm maintenaceSetFrm = null;
        LogViewForm logHistoryFrm = null;
        ECIDSetForm ecidSetFrm = null;

        public SubOperationControl()
        {
            InitializeComponent();
        }

        public void InitControl()
        {
            batchHistoryFrm = new BatchHistoryForm();
            alarmHistoryFrm = new AlarmHistoryForm();
            maintenaceSetFrm = new MaintenaceSetForm();
            logHistoryFrm = new LogViewForm();
            ecidSetFrm = new ECIDSetForm();

            batchHistoryFrm.DisplayBatchHistoryEvent += new EventHandler(batchHistoryFrm_Display);
            alarmHistoryFrm.DisplayAlarmHistoryEvent += new EventHandler(alarmHistoryFrm_Display);
            maintenaceSetFrm.ParameterChangeSetEvent += new MaintenaceSetForm.ParamChangeEventHandler(maintenaceSetFrm_ParameterChangeSetEvent);
            maintenaceSetFrm.InterlockChangeSetEvent += new EventHandler(maintenaceSetFrm_InterlockChangeSetEvent);

            maintenaceSetFrm.PeriodChangeSetEvent += new MaintenaceSetForm.PeriodChangeEventHandler(maintenaceSetFrm_PeriodChangeSetEvent);
            logHistoryFrm.LogColorDataChangeSetEvent += new LogViewForm.LogColorDataChangeEventHandler(logViewFrm_LogColorChangeSetEvent);
            logHistoryFrm.LogViewEvent += new EventHandler(logHistoryFrm_Display);
            ecidSetFrm.ECIDSetEvent += new EventHandler(ecidSetFrm_ECIDSetEvent);

            
        }

        private void btnFlowSet_Click(object sender, EventArgs e)
        {
            FlowControlForm FlowControlForm = new FlowControlForm();
            DialogResult rusult = FlowControlForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                //FlowSetView();
            }            
        }
        private void btnInputSet_Click(object sender, EventArgs e)
        {
            WIPQTYSetForm ParamForm = new WIPQTYSetForm();
            DialogResult rusult = ParamForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                WIPQTYSetView();
            }           
        }
        private void btnBatchHistoryView_Click(object sender, EventArgs e)
        {
            batchHistoryFrm.ShowDialog();
        }
        private void batchHistoryFrm_Display(object sender, EventArgs e)
        {
            BatchHistoryView(batchHistoryFrm.FROM_DATE, batchHistoryFrm.TO_DATE, batchHistoryFrm.KEY_WORD,batchHistoryFrm.SELECT_PAGE );
        }
        private void btnAlarmHistoryView_Click(object sender, EventArgs e)
        {
            alarmHistoryFrm.ShowDialog();     
        }
        private void alarmHistoryFrm_Display(object sender, EventArgs e)
        {
            AlarmHistoryView(alarmHistoryFrm.FROM_DATE, alarmHistoryFrm.TO_DATE, alarmHistoryFrm.KEY_WORD, alarmHistoryFrm.ALARM_ON);
        }
        private void btnMaintenanceSet_Click(object sender, EventArgs e)
        {
            maintenaceSetFrm.ShowDialog();
        }

        private void maintenaceSetFrm_ParameterChangeSetEvent(ParameterData newData)
        {
            if (LCData.Parameter.ReqTime1 != newData.ReqTime1 || LCData.Parameter.ReqTime2 != newData.ReqTime2 ||
                LCData.Parameter.L1ModuleID != newData.L1ModuleID || LCData.Parameter.L1ModuleID != newData.L1ModuleID ||
                LCData.Parameter.LimitLineCount != newData.LimitLineCount || LCData.Parameter.GlassTypeCheck != newData.GlassTypeCheck ||
                LCData.Parameter.BatchRunMode != newData.BatchRunMode || LCData.Parameter.Cancel_Time != newData.Cancel_Time)
            {
                LCData.Parameter = null;
                LCData.Parameter = newData;

                UpdateParameterSet();
            }              
        }
        private void maintenaceSetFrm_InterlockChangeSetEvent(object sender, EventArgs e)
        {
            UpdateInterlockSet();
        }
        private void maintenaceSetFrm_PeriodChangeSetEvent(HistorySetData newData)
        {
            if (LCData.HistoryPeriodSet.PlanHistoryPeriod != newData.PlanHistoryPeriod ||
                LCData.HistoryPeriodSet.PlanHistoryRange != newData.PlanHistoryRange ||
                LCData.HistoryPeriodSet.GlassHistoryPeriod != newData.GlassHistoryPeriod ||
                LCData.HistoryPeriodSet.GlassHistoryRange != newData.GlassHistoryRange ||
                LCData.HistoryPeriodSet.AlarmHistoryPeriod != newData.AlarmHistoryPeriod ||
                LCData.HistoryPeriodSet.LogHistoryPeriod != newData.LogHistoryPeriod)
            {
                LCData.HistoryPeriodSet = null;
                LCData.HistoryPeriodSet = newData;

                UpdatePeriodSet();
            }              
        }
        private void logViewFrm_LogColorChangeSetEvent(ClassCore.LogColorData newData)
        {
            LCData.LogColorDataSet = null;
            LCData.LogColorDataSet = newData;

            UpdateLogcolorSet();
        }
        private void btnLogView_Click(object sender, EventArgs e)
        {
            logHistoryFrm.ShowDialog();
        }
        private void logHistoryFrm_Display(object sender, EventArgs e)
        {
            LogHistoryView(logHistoryFrm.FROM_DATE, logHistoryFrm.TO_DATE, logHistoryFrm.SERIAL_WORD, logHistoryFrm.NACK_WORD, logHistoryFrm.KEY_WORD, logHistoryFrm.SELECT_PAGE);
        }


        private void btnECIDSet_Click(object sender, EventArgs e)
        {
            ecidSetFrm.ShowDialog();
        }

        private void ecidSetFrm_ECIDSetEvent(object sender, EventArgs e)
        {
            UpdateECIDSet();
        }
        

        private void btnHelpView_Click(object sender, EventArgs e)
        {
            if (File.Exists("help.chm"))
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("help.chm");
                startInfo.CreateNoWindow = true;
                System.Diagnostics.Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show("Help 파일이 해당경로에 존재하지 않습니다!");
            }
            
        }

        private void SubOperationControl_RegionChanged(object sender, EventArgs e)
        {
            Button applybtn = sender as Button;

            if (applybtn != null)
            {
                
            }

        }
    }
}
