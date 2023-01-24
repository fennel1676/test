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
    public partial class OperationControl : UserControl
    {
        public delegate void BatchViewEventHandler(eLINE line);
        public event BatchViewEventHandler UpdateBatchEvent;        

        public delegate bool CheckEventHandler(string panelid);
        public event CheckEventHandler CheckBatchInfoEvent;
        public event CheckEventHandler CheckFPanelIDEvent;        

        public delegate void BatchEndEventHandler(eLINE line, eByWho byWho);
        public event BatchEndEventHandler BatchEndEvent;

        public delegate void BatchRequestEventHandler(eLINE line);
        public event BatchRequestEventHandler BatchRequestEvent;

        public delegate void ResumeEventHandler(eLINE line, eByWho bywho, eLogType logtype);
        public event ResumeEventHandler ResumeEvent;

        public delegate void PauseEventHandler(eLINE line, eByWho bywho, eLogType logtype);
        public event PauseEventHandler PauseEvent;

        public OperationControl()
        {
            InitializeComponent();
        }

        public CreatePlanForm CreateForm = null;

        private System.Windows.Forms.Button[] btnEqStarts;
        private System.Windows.Forms.Button[] btnEqStops;
        private System.Windows.Forms.Label[] lbComments;
              
        public void InitControl()
        {
            btnEqStarts  = new System.Windows.Forms.Button[2];
            btnEqStops   = new System.Windows.Forms.Button[2];
            lbComments = new System.Windows.Forms.Label[2];

            int x1=185, y1=32, x2= 289, y2 = 32, x3 =393 , y3 = 32;
            for (int i = 0; i < 2; i++)
            {
                this.btnEqStarts[i] = new System.Windows.Forms.Button();
                this.btnEqStarts[i].Tag = i;
                this.btnEqStarts[i].Location = new System.Drawing.Point(x1, y1);
                this.btnEqStarts[i].Size = new System.Drawing.Size(105, 33);
                this.btnEqStarts[i].FlatStyle = FlatStyle.Flat;
                this.btnEqStarts[i].BackColor = Color.Transparent;
                this.btnEqStarts[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.btnEqStarts[i].Text = "투입";
                this.btnEqStarts[i].Click += new EventHandler(btnEqStarts_Click);
                this.Controls.Add(this.btnEqStarts[i]);
                x1 += 538;

                this.btnEqStops[i] = new System.Windows.Forms.Button();
                this.btnEqStops[i].Tag = i;
                this.btnEqStops[i].Location = new System.Drawing.Point(x2, y2);
                this.btnEqStops[i].Size = new System.Drawing.Size(105, 33);
                this.btnEqStops[i].FlatStyle = FlatStyle.Flat;
                this.btnEqStops[i].BackColor = Color.Transparent;
                this.btnEqStops[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.btnEqStops[i].Text = "중지";
                this.btnEqStops[i].Click += new EventHandler(btnEqStops_Click);
                this.Controls.Add(this.btnEqStops[i]);
                x2 += 538;

                this.lbComments[i] = new System.Windows.Forms.Label();
                this.lbComments[i].Tag = i;
                this.lbComments[i].Location = new System.Drawing.Point(x3, y3);
                this.lbComments[i].Size = new System.Drawing.Size(313, 33);
                this.lbComments[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.lbComments[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbComments[i].BackColor = Color.Transparent;
                this.lbComments[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(this.lbComments[i]);
                x3 += 538;

            }
            UpdateDisplay();
        }

        private void btnEqStarts_Click(object sender, EventArgs e)
        {
            Button btnStart = sender as Button;

            if (btnStart != null)
            {
                if (LCData.OnlinePLCState != eEIPCMD.ONLINE)
                {
                    MessageBox.Show("PLC와 연결이 되지 않았습니다.", "PLC 통신 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BatchManager BatchMng = LCData.FindBatch((eLINE)btnStart.Tag + 1);
                if (BatchMng != null)
                {
                    if ((BatchMng.PortDatas[0].PAUSE_STATE & BatchMng.PortDatas[1].PAUSE_STATE) == 0)
                    {
                        MessageBox.Show("현재 투입 중입니다.", "투입 요청 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ReConfirmForm reconfirmForm = new ReConfirmForm(string.Format("현재 {0}라인 투입하시겠습니까?", (int)btnStart.Tag + 1));
                        DialogResult rusult = reconfirmForm.ShowDialog();
                        if (rusult == DialogResult.OK)
                        {
                            ResumeReqTimer((eLINE)btnStart.Tag + 1);
                            ResumeEvent((eLINE)btnStart.Tag + 1, eByWho.ByOperator, eLogType.PC_RESUME_ABNORMAL1);
                        }
                    }
                }
            }
        }
        private void btnEqStops_Click(object sender, EventArgs e)
        {
            Button btnEqStop = sender as Button;

            if (btnEqStop != null)
            {
                if (LCData.OnlinePLCState != eEIPCMD.ONLINE)
                {
                    MessageBox.Show("PLC와 연결이 되지 않았습니다.", "PLC 통신 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BatchManager BatchMng = LCData.FindBatch((eLINE)btnEqStop.Tag + 1);
                if (BatchMng != null)
                {
                    if ((BatchMng.PortDatas[0].PAUSE_STATE & BatchMng.PortDatas[1].PAUSE_STATE) == 1)
                    {
                        MessageBox.Show("현재 투입중지 중입니다.", "투입 중지 요청 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ReConfirmForm reconfirmForm = new ReConfirmForm(string.Format("현재 {0}라인 투입 중지하시겠습니까?", (int)btnEqStop.Tag + 1));
                        DialogResult rusult = reconfirmForm.ShowDialog();
                        if (rusult == DialogResult.OK)
                        {
                            PauseReqTimer((eLINE)btnEqStop.Tag + 1);
                            PauseEvent((eLINE)btnEqStop.Tag + 1, eByWho.ByOperator, eLogType.PC_PAUSE_ABNORMAL1);
                        }
                    }
                }
            }
        }

        public void UpdateDisplay()
        {
            int index = 0;
            foreach (BatchManager BatchInfo in LCData.BatchManagers)
            {
                if ((BatchInfo.PortDatas[0].PAUSE_STATE & BatchInfo.PortDatas[1].PAUSE_STATE) == 0)
                {
                    btnEqStarts[index].BackColor = Color.Lime;
                    btnEqStops[index].BackColor = Color.Transparent;
                }
                else if ((BatchInfo.PortDatas[0].PAUSE_STATE & BatchInfo.PortDatas[1].PAUSE_STATE) == 1)
                {
                    btnEqStarts[index].BackColor = Color.Transparent;
                    btnEqStops[index].BackColor = Color.Red;
                }
                index++;
            }
        }
        private void btnCreateL1_Click(object sender, EventArgs e)
        {
            BatchManager BatchMng = LCData.FindBatch(eLINE.LINE1);
            if (BatchMng != null)
            {
                if (!(BatchMng.BatchDatas.Count >= 4))
                {
                    CreateForm = new CreatePlanForm(eLINE.LINE1);                   
                    DialogResult rusult = CreateForm.ShowDialog();

                    if (rusult == DialogResult.OK)
                    {
                        if (CheckBatchInfoEvent(CreateForm.BatchInfo.F_PANELID))
                        {
                            MessageBox.Show("이전에 투입된 생산계획정보입니다.", "생성 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (CheckFPanelIDEvent(CreateForm.BatchInfo.F_PANELID))
                        {
                            MessageBox.Show("이전에 발행된 F_PANELID입니다.", "생성 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            foreach (BatchObject BatchObj in BatchMng.BatchDatas)
                            {
                                if (BatchObj.F_PANELID == CreateForm.BatchInfo.F_PANELID)
                                {
                                    MessageBox.Show("현재 생산계획정보중에 동일한 F_PANELID가 있습니다.", "생성 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            BatchMng.BatchDatas.Add(CreateForm.BatchInfo);
                            //order 1순위는 상시 최근 데이터 유지.
                            if (CreateForm.BatchInfo.ORDER_NO == 1) LCData.SaveBatCh(eLINE.LINE1, CreateForm.BatchInfo);

                            UpdateBatchEvent(eLINE.LINE1);
                            MessageBox.Show("정상적으로 생성되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("현재 1라인 생산계획 정보를 더이상 생성 할 수 없습니다.");
                    return;
                }
            }
        }
        private void btnCreateL2_Click(object sender, EventArgs e)
        {
            BatchManager BatchMng = LCData.FindBatch(eLINE.LINE2);
            if (BatchMng != null)
            {
                if (!(BatchMng.BatchDatas.Count >= 4))
                {
                    CreateForm = new CreatePlanForm(eLINE.LINE2);
                    DialogResult rusult = CreateForm.ShowDialog();

                    if (rusult == DialogResult.OK)
                    {
                        if (CheckBatchInfoEvent(CreateForm.BatchInfo.F_PANELID))
                        {
                            MessageBox.Show("이전에 투입된 생산계획정보입니다.", "생성 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (CheckFPanelIDEvent(CreateForm.BatchInfo.F_PANELID))
                        {
                            MessageBox.Show("이전에 발행된 F_PANELID입니다.", "생성 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            foreach (BatchObject BatchObj in BatchMng.BatchDatas)
                            {
                                if (BatchObj.F_PANELID == CreateForm.BatchInfo.F_PANELID)
                                {
                                    MessageBox.Show("현재 생산계획정보중에 동일한 F_PANELID가 있습니다.", "생성 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            BatchMng.BatchDatas.Add(CreateForm.BatchInfo);
                            //order 1순위는 상시 최근 데이터 유지.
                            if (CreateForm.BatchInfo.ORDER_NO == 1) LCData.SaveBatCh(eLINE.LINE2, CreateForm.BatchInfo);

                            UpdateBatchEvent(eLINE.LINE2);
                            MessageBox.Show("정상적으로 생성되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("현재 2라인 생산계획 정보를 더이상 생성 할 수 없습니다.");
                    return;
                }
            }
        }
        private void btnDeleteL1_Click(object sender, EventArgs e)
        {
            BatchManager BatchMng = LCData.FindBatch(eLINE.LINE1);
            if (BatchMng != null)
            {
                if (BatchMng.BatchDatas.Count != 0)
                {
                    DeletePlanForm DeleteForm = new DeletePlanForm(eLINE.LINE1);
                    DialogResult rusult = DeleteForm.ShowDialog();

                    if (rusult == DialogResult.OK)
                    {
                        UpdateBatchEvent(eLINE.LINE1);
                        MessageBox.Show("정상적으로 처리되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else
                {
                    MessageBox.Show("현재 1라인 생산계획정보 삭제대상이 존재하지 않습니다.");
                }
            }            
        }
        private void btnDeleteL2_Click(object sender, EventArgs e)
        {
            BatchManager BatchMng = LCData.FindBatch(eLINE.LINE2);
            if (BatchMng != null)
            {
                if (BatchMng.BatchDatas.Count != 0)
                {
                    DeletePlanForm DeleteForm = new DeletePlanForm(eLINE.LINE2);
                    DialogResult rusult = DeleteForm.ShowDialog();

                    if (rusult == DialogResult.OK)
                    {
                        UpdateBatchEvent(eLINE.LINE2);
                        MessageBox.Show("정상적으로 처리되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else
                {
                    MessageBox.Show("현재 2라인 생산계획정보 삭제대상이 존재하지 않습니다.");
                }
            }  
        }
        private void btnModifyL1_Click(object sender, EventArgs e)
        {
            BatchManager BatchMng = LCData.FindBatch(eLINE.LINE1);
            if (BatchMng != null && BatchMng.BatchDatas.Count < 1)
            {
                MessageBox.Show("현재 1라인 생산계획정보 변경대상이 존재하지 않습니다.");
                return;
            }

            ModifyPlanForm ModifyForm = new ModifyPlanForm(eLINE.LINE1);
            DialogResult rusult = ModifyForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                UpdateBatchEvent(eLINE.LINE1);
                MessageBox.Show("정상적으로 처리되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void btnModifyL2_Click(object sender, EventArgs e)
        {
            BatchManager BatchMng = LCData.FindBatch(eLINE.LINE2);
            if (BatchMng != null && BatchMng.BatchDatas.Count < 1)
            {
                MessageBox.Show("현재 2라인 생산계획정보 변경대상이 존재하지 않습니다.");
                return;
            }

            ModifyPlanForm ModifyForm = new ModifyPlanForm(eLINE.LINE2);
            DialogResult rusult = ModifyForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                UpdateBatchEvent(eLINE.LINE2);
                MessageBox.Show("정상적으로 처리되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void btnEndL1_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE)
            {
                MessageBox.Show("HOST와 연결되지 않았습니다.", "요청 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BatchManager BatchMng = LCData.FindBatch(eLINE.LINE1);
            if (BatchMng != null && BatchMng.BatchDatas.Count < 1)
            {
                MessageBox.Show("현재 1라인 생산계획정보 변경대상이 존재하지 않습니다.");
                return;
            }

            ManualBatchEndForm BatchEndForm = new ManualBatchEndForm(1);
            DialogResult rusult = BatchEndForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                BatchEndEvent(eLINE.LINE1, eByWho.ByOperator);
                MessageBox.Show("정상적으로 처리되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void btnEndL2_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE)
            {
                MessageBox.Show("HOST와 연결되지 않았습니다.", "요청 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BatchManager BatchMng = LCData.FindBatch(eLINE.LINE2);
            if (BatchMng != null && BatchMng.BatchDatas.Count < 1)
            {
                MessageBox.Show("현재 2라인 생산계획정보 변경대상이 존재하지 않습니다.");
                return;
            }

            ManualBatchEndForm BatchEndForm = new ManualBatchEndForm(2);
            DialogResult rusult = BatchEndForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                BatchEndEvent(eLINE.LINE2, eByWho.ByOperator);
                MessageBox.Show("정상적으로 처리되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void btnBatchReqL1_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE)
            {
                MessageBox.Show("HOST와 연결되지 않았습니다.", "요청 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfirmForm confirmForm = new ConfirmForm("line 1 생산 계획 요청 되었습니다.\n 투입현황창을 확인해 주세요(1초후 자동종료)");
            DialogResult rusult = confirmForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                BatchRequestEvent(eLINE.LINE1);
                MessageBox.Show("정상적으로 처리되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void btnBatchReqL2_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE)
            {
                MessageBox.Show("HOST와 연결되지 않았습니다.", "요청 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfirmForm confirmForm = new ConfirmForm("line 2 생산 계획 요청 되었습니다.\n 투입현황창을 확인해 주세요(1초후 자동종료)");
            DialogResult rusult = confirmForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                BatchRequestEvent(eLINE.LINE2);
                MessageBox.Show("정상적으로 처리되었습니다.", "결과 확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
       
        private void ResumeReqTimer(eLINE line)
        {
            Timer Resumetimer = new Timer();
            Resumetimer.Interval = 500;
            Resumetimer.Tag = (short)line;
            Resumetimer.Tick += new EventHandler(Resumetimer_Tick);
            Resumetimer.Start();
        }
        private void Resumetimer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            flashWindow(lbComments[(short)timer.Tag - 1], "투입 중입니다");

            if (LCData.OnlinePLCState != eEIPCMD.ONLINE)
               timer.Stop();

            BatchManager BatchInfo = LCData.FindBatch((eLINE)((short)timer.Tag));
            if (BatchInfo != null)
            {
                if ((BatchInfo.PortDatas[0].PAUSE_STATE & BatchInfo.PortDatas[1].PAUSE_STATE) == 0)
                {
                    timer.Stop();
                    lbComments[(short)timer.Tag - 1].BackColor = Color.Transparent;
                    lbComments[(short)timer.Tag - 1].Text = null;
                   // UpdateDisplay();
                }
            }           
        }
        private void PauseReqTimer(eLINE line)
        {
            Timer Pausetimer = new Timer();
            Pausetimer.Interval = 500;
            Pausetimer.Tag = (short)line;
            Pausetimer.Tick += new EventHandler(Pausetimer_Tick);
            Pausetimer.Start();
        }
        private void Pausetimer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            flashWindow(lbComments[(short)timer.Tag - 1], "투입중지 중입니다");

            if (LCData.OnlinePLCState != eEIPCMD.ONLINE)
                timer.Stop();

            BatchManager BatchInfo = LCData.FindBatch((eLINE)((short)timer.Tag));
            if (BatchInfo != null)
            {
                if ((BatchInfo.PortDatas[0].PAUSE_STATE & BatchInfo.PortDatas[1].PAUSE_STATE) == 1)
                {
                    timer.Stop();
                    lbComments[(short)timer.Tag - 1].BackColor = Color.Transparent;
                    lbComments[(short)timer.Tag - 1].Text = null;
                }
            }
        }

        private void flashWindow(System.Windows.Forms.Label lb, string Msg)
        {
            if (lb.BackColor == Color.Transparent && LCData.OnlinePLCState != eEIPCMD.OFFLINE)
            {
                lb.Text = Msg;
                lb.BackColor = Color.Yellow;
            }
            else
            {
                lb.Text = "";
                lb.BackColor = Color.Transparent;
            }
        }

    }
}
