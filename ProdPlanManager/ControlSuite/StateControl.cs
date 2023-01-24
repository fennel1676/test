using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClassCore;

namespace ProdPlanManager
{
    public partial class StateControl : UserControl
    {
        public delegate void OnlineChangeEventHandler(eMCMD Mode);
        public event OnlineChangeEventHandler OnlineChangeEvent;

        public StateControl()
        {
            InitializeComponent();
        }
        public void InitControl()
        {
            lbEqpID.BackColor = Color.Lime;
            lbEqState.BackColor = Color.Lime;
            lbProcState.BackColor = Color.Lime;

            btnDisconnect.BackColor = Color.Red;
            btnOffline.BackColor = Color.Red;
            lbEqpID.Text = LCData.Modules[0].ID;



            lbMaker.Text = LCData.Operation[0];
            lbOperator1.Text = LCData.Operation[1];
            lbOperator2.Text = LCData.Operation[2];


            UpdateDisplay();
        }
        public void UpdateDisplay()
        {
            switch (LCData.Modules[0].EqState)
            {
                case eEqState.NORMAL:
                case eEqState.PM:lbEqState.BackColor = Color.Lime;break;
                case eEqState.FAULT:lbEqState.BackColor = Color.Red;break;
            }

            switch (LCData.Modules[0].ProcState)
            {
                case eProcState.INIT:
                case eProcState.PAUSE:lbProcState.BackColor = Color.Red;break;
                case eProcState.IDLE:
                case eProcState.READY: 
                case eProcState.EXECUTE: 
                case eProcState.SETUP: lbProcState.BackColor = Color.Lime;break;
            }

            lbEqState.Text = LCData.Modules[0].EqState.ToString();
            lbProcState.Text = LCData.Modules[0].ProcState.ToString();
            btnDisconnect.BackColor = LCData.OnlinePLCState == eEIPCMD.OFFLINE ? Color.Red : Color.Transparent;
            btnConnect.BackColor = LCData.OnlinePLCState == eEIPCMD.ONLINE ? Color.Lime : Color.Transparent;
            btnRemote.BackColor = LCData.OnlineHostState == eMCMD.REMOTE ? Color.Lime : Color.Transparent;
            btnLocal.BackColor = LCData.OnlineHostState == eMCMD.LOCAL ? Color.Lime : Color.Transparent;
            btnOffline.BackColor = LCData.OnlineHostState == eMCMD.OFFLINE ? Color.Red : Color.Transparent;
        }
        private void btnLocal_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE)
            {
                MessageBox.Show("Host와 연결되어 있지 않습니다.", "온라인 모드 변경 오류", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            ReConfirmForm reconfirmForm = new ReConfirmForm("Local 모드로 변환 하시겠습니까?");
            DialogResult rusult = reconfirmForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                if (LCData.OnlineHostState == eMCMD.REMOTE)
                {
                    OnlineChangeEvent(eMCMD.LOCAL);
                }
            }
        }
        private void btnRemote_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE)
            {
                MessageBox.Show("Host와 연결되어 있지 않습니다.", "온라인 모드 변경 오류", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            ReConfirmForm reconfirmForm = new ReConfirmForm("REMOTE 모드로 변환 하시겠습니까?");
            DialogResult rusult = reconfirmForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                if (LCData.OnlineHostState == eMCMD.LOCAL)
                {
                    OnlineChangeEvent(eMCMD.REMOTE);
                }
            }
        }
   }
}
