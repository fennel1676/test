using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassCore;

namespace ProdPlanManager
{
    public partial class MaintenaceSetForm : Form
    {
        private int _select = 0;
        private int vSize = 0;

        public delegate void ParamChangeEventHandler(ParameterData paramData);
        public event ParamChangeEventHandler ParameterChangeSetEvent;

        public event EventHandler InterlockChangeSetEvent;

        public delegate void PeriodChangeEventHandler(HistorySetData periodData);
        public event PeriodChangeEventHandler PeriodChangeSetEvent;

        private System.Windows.Forms.Button[] btnL1Interlocks;
        private System.Windows.Forms.Button[] btnL2Interlocks;


        public MaintenaceSetForm()
        {
            InitializeComponent();
            InitControl();
        }

        public void InitControl()
        {
            
            btnSet1_Click(this.btnSet1, null);

            btnL1Interlocks = new System.Windows.Forms.Button[12];
            btnL2Interlocks = new System.Windows.Forms.Button[12];

            int x1 = 269 , y1 = 66, x2 = 270, y2 = 310;
            for (int i = 0; i < 12; i++)
            {
                this.btnL1Interlocks[i] = new System.Windows.Forms.Button();
                this.btnL1Interlocks[i].Location = new System.Drawing.Point(i < 9 ? x1 : x2, i < 9 ? y1  : y2 );
                this.btnL1Interlocks[i].Size = new System.Drawing.Size(80, 20);
                this.btnL1Interlocks[i].BackColor = Color.Red;
                this.btnL1Interlocks[i].Text = "미사용";
                this.btnL1Interlocks[i].Click += new EventHandler(btnL1Interlocks_Click);
                this.grpL1Box.Controls.Add(this.btnL1Interlocks[i]);

                this.btnL2Interlocks[i] = new System.Windows.Forms.Button();
                this.btnL2Interlocks[i].Location = new System.Drawing.Point(i < 9 ? x1 : x2, i < 9 ? y1  : y2 );
                this.btnL2Interlocks[i].Size = new System.Drawing.Size(80, 20);
                this.btnL2Interlocks[i].BackColor = Color.Red;
                this.btnL2Interlocks[i].Text = "미사용";
                this.btnL2Interlocks[i].Click += new EventHandler(btnL2Interlocks_Click);
                this.grpL2Box.Controls.Add(this.btnL2Interlocks[i]);

                if (i < 9)
                    y1 += 19;
                else
                    y2 += 19;
            }
        }

        private void btnL1Interlocks_Click(object sender, EventArgs e)
        {
            Button btnL1 = sender as Button;
            if (btnL1 != null)
            {
                if (btnL1.BackColor == Color.Lime)
                {
                    btnL1.Text = "미사용";
                    btnL1.BackColor = Color.Red;
                }
                else
                {
                    btnL1.Text = "사용";
                    btnL1.BackColor = Color.Lime;
                }
            }
        }
        private void btnL2Interlocks_Click(object sender, EventArgs e)
        {
            Button btnL2 = sender as Button;
            if (btnL2 != null)
            {
                if (btnL2.BackColor == Color.Lime)
                {
                    btnL2.Text = "미사용";
                    btnL2.BackColor = Color.Red;
                }
                else
                {
                    btnL2.Text = "사용";
                    btnL2.BackColor = Color.Lime;
                }
            }
        }
        public void UpdateDisplay()
        {
            foreach (Control ctl in this.Controls)
            {
                if (null != ctl as Panel)
                {
                    if (ctl.Visible)
                    {
                        switch(int.Parse(ctl.Name.Substring(5,1)))
                        {
                            case 1:
                                {
                                    numericUpDown1.Value = LCData.Parameter.ReqTime1;
                                    numericUpDown2.Value = LCData.Parameter.ReqTime2;
                                    textBox1.Text = LCData.Parameter.L1ModuleID;
                                    textBox2.Text = LCData.Parameter.L2ModuleID;
                                    numericUpDown4.Value = LCData.Parameter.LimitLineCount;
                                    numericUpDown3.Value = LCData.Parameter.Cancel_Time;

                                    if (LCData.Parameter.GlassTypeCheck == 1)
                                    {
                                        btnGlassTypeYes.BackColor = Color.Lime;
                                        btnGlassTypeNo.BackColor = Color.Gray;
                                    }
                                    else
                                    {
                                        btnGlassTypeYes.BackColor = Color.Gray;
                                        btnGlassTypeNo.BackColor = Color.Red;
                                    }

                                    if (LCData.Parameter.BatchRunMode == 1)
                                    {
                                        btnGlassStart.BackColor = Color.Lime;
                                        btnGlassStop.BackColor = Color.Gray;
                                    }
                                    else
                                    {
                                        btnGlassStart.BackColor = Color.Gray;
                                        btnGlassStop.BackColor = Color.Red;
                                    }

                                }
                                break;
                            case 2:
                                {
                                    int i = 0, j = 0;
                                    foreach (FlowGroupInterlock interlock in LCData.interlockDatas.L1Interlocks)
                                    {
                                        if (interlock.Used == 1)
                                        {

                                            btnL1Interlocks[i].Text = "사용";
                                            btnL1Interlocks[i].BackColor = Color.Lime;
                                        }
                                        else
                                        {
                                            btnL1Interlocks[i].Text = "미사용";
                                            btnL1Interlocks[i].BackColor = Color.Red;
                                        }
                                        i++;

                                    }

                                    foreach (FlowGroupInterlock interlock in LCData.interlockDatas.L2Interlocks)
                                    {
                                        if (interlock.Used == 1)
                                        {
                                            btnL2Interlocks[j].Text = "사용";
                                            btnL2Interlocks[j].BackColor = Color.Lime;
                                        }
                                        else
                                        {
                                            btnL2Interlocks[j].Text = "미사용";
                                            btnL2Interlocks[j].BackColor = Color.Red;
                                        }
                                        j++;
                                    }
                                }
                                break;
                            case 3:
                                {
                                    numericUpDown10.Value = LCData.HistoryPeriodSet.PlanHistoryPeriod;
                                    numericUpDown9.Value = LCData.HistoryPeriodSet.PlanHistoryRange;
                                    numericUpDown8.Value = LCData.HistoryPeriodSet.AlarmHistoryPeriod;
                                    numericUpDown6.Value = LCData.HistoryPeriodSet.GlassHistoryPeriod;
                                    numericUpDown5.Value = LCData.HistoryPeriodSet.GlassHistoryRange;
                                    numericUpDown7.Value = LCData.HistoryPeriodSet.LogHistoryPeriod;
                                }
                                break;
                        }
                    }
                }             
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnGlassTypeYes_Click(object sender, EventArgs e)
        {
            btnGlassTypeYes.BackColor = Color.Lime;
            btnGlassTypeNo.BackColor = Color.Gray;
        }

        private void btnGlassTypeNo_Click(object sender, EventArgs e)
        {
            btnGlassTypeYes.BackColor = Color.Gray;
            btnGlassTypeNo.BackColor = Color.Red;
        }

        private void btnGlassStart_Click(object sender, EventArgs e)
        {
            btnGlassStart.BackColor = Color.Lime;
            btnGlassStop.BackColor = Color.Gray;
        }

        private void btnGlassStop_Click(object sender, EventArgs e)
        {
            btnGlassStart.BackColor = Color.Gray;
            btnGlassStop.BackColor = Color.Red;
        }

        private void MaintenaceSetForm_Shown(object sender, EventArgs e)
        {
           UpdateDisplay();
        }

        private void btnSet1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Yellow;

            foreach (Control ctl in this.Controls)
            {
                if (null != ctl as Panel)
                {
                    if (ctl.Name == "panel1")
                        ctl.Visible = true;
                    else
                        ctl.Visible = false;
                }
                else if (null != ctl as Button)
                {
                    if (ctl.Name == "btnSet2" || ctl.Name == "btnSet3")
                        ctl.BackColor = Color.Transparent;
                }
            }
            UpdateDisplay();
        }
        private void btnSet2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Yellow;

            foreach (Control ctl in this.Controls)
            {
                if (null != ctl as Panel)
                {
                    if (ctl.Name == "panel2")
                        ctl.Visible = true;
                    else
                        ctl.Visible = false;
                }
                else if (null != ctl as Button)
                {
                    if (ctl.Name == "btnSet1" || ctl.Name == "btnSet3")
                        ctl.BackColor = Color.Transparent;
                }
            }
            UpdateDisplay();
        }
        private void btnSet3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Yellow;

            foreach (Control ctl in this.Controls)
            {
                if (null != ctl as Panel)
                {
                    if (ctl.Name == "panel3")
                        ctl.Visible = true;
                    else
                        ctl.Visible = false;
                }
                else if (null != ctl as Button)
                {
                    if (ctl.Name == "btnSet1" || ctl.Name == "btnSet2")
                        ctl.BackColor = Color.Transparent;
                }
            }
            UpdateDisplay();
        }

        private void btnApplyInterlock_Click(object sender, EventArgs e)
        {
            PasswordInputForm passwordInputForm = new PasswordInputForm();
            DialogResult passwordResult = passwordInputForm.ShowDialog();
            if (passwordResult == DialogResult.OK)
            {
                int i = 0, j = 0;
                foreach (FlowGroupInterlock data in LCData.interlockDatas.L1Interlocks)
                {
                    data.Used = btnL1Interlocks[i].BackColor == Color.Lime ? 1 : 0;
                    i++;
                }

                foreach (FlowGroupInterlock data in LCData.interlockDatas.L2Interlocks)
                {
                    data.Used = btnL2Interlocks[j].BackColor == Color.Lime ? 1 : 0;
                    j++;
                }

                InterlockChangeSetEvent(null, null);
                MessageBox.Show("정상 적용 되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                UpdateDisplay();
            }
        }

        private void btnPeriodApply_Click(object sender, EventArgs e)
        {
            PasswordInputForm passwordInputForm = new PasswordInputForm();
            DialogResult passwordResult = passwordInputForm.ShowDialog();
            if (passwordResult == DialogResult.OK)
            {
                HistorySetData periodSet = new HistorySetData();
                periodSet.PlanHistoryPeriod = (int)numericUpDown10.Value;
                periodSet.PlanHistoryRange = (int)numericUpDown9.Value;
                periodSet.GlassHistoryPeriod = (int)numericUpDown6.Value;
                periodSet.GlassHistoryRange = (int)numericUpDown5.Value;
                periodSet.AlarmHistoryPeriod = (int)numericUpDown8.Value;
                periodSet.LogHistoryPeriod = (int)numericUpDown7.Value;               

                PeriodChangeSetEvent(periodSet);
                MessageBox.Show("정상 적용 되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                UpdateDisplay();
            }
        }

        private void btnApplyParam_Click(object sender, EventArgs e)
        {
            PasswordInputForm passwordInputForm = new PasswordInputForm();
            DialogResult passwordResult = passwordInputForm.ShowDialog();
            if (passwordResult == DialogResult.OK)
            {
                ParameterData paramData = new ParameterData();

                paramData.ReqTime1 = (int)numericUpDown1.Value;
                paramData.ReqTime2 = (int)numericUpDown2.Value;
                paramData.L1ModuleID = textBox1.Text;
                paramData.L2ModuleID = textBox2.Text;
                paramData.LimitLineCount = (int)numericUpDown4.Value;

                paramData.GlassTypeCheck = btnGlassTypeYes.BackColor == Color.Gray ? 0 : 1;
                paramData.BatchRunMode = btnGlassStart.BackColor == Color.Gray ? 0 : 1;
                paramData.Cancel_Time = (int)numericUpDown3.Value;

                ParameterChangeSetEvent(paramData);
                MessageBox.Show("정상 적용 되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                UpdateDisplay();
            }
        }        
    }
}