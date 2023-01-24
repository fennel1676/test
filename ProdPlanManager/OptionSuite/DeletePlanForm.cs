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
    public partial class DeletePlanForm : Form
    {
        private eLINE _line = 0;
        private CheckBox[] chkOrders;
        private TextBox[] txtStates;
        private TextBox[] txtComments;

        public DeletePlanForm(eLINE LineNo)
        {
            InitializeComponent();
            _line = LineNo;
        }

        private void DeletePlanForm_Load(object sender, EventArgs e)
        {
            this.chkOrders = new CheckBox[4];
            this.txtStates = new TextBox[4];
            this.txtComments = new TextBox[4];

            int col = 9;
            for (int i = 0; i < 4; i++)
            {
                this.chkOrders[i] = new CheckBox();
                this.chkOrders[i].Name = "chkOrder" + i.ToString();
                this.chkOrders[i].Location = new System.Drawing.Point(12, col + 4);
                this.chkOrders[i].Size = new System.Drawing.Size(15, 14);
                this.chkOrders[i].BackColor = Color.White;
                this.panel1.Controls.Add(this.chkOrders[i]);
               
                this.txtStates[i] = new TextBox();
                this.txtStates[i].Name = "txtState" + i.ToString();
                this.txtStates[i].Location = new System.Drawing.Point(130, col);
                this.txtStates[i].Size = new System.Drawing.Size(80, 21);
                this.txtStates[i].BackColor = Color.LightYellow;
                this.txtStates[i].TextAlign = HorizontalAlignment.Center;
                this.panel1.Controls.Add(this.txtStates[i]);

                this.txtComments[i] = new TextBox();
                this.txtComments[i].Name = "txtComment" + i.ToString();
                this.txtComments[i].Location = new System.Drawing.Point(225, col);
                this.txtComments[i].Size = new System.Drawing.Size(100, 21);
                this.txtComments[i].BackColor = Color.LightYellow;
                this.txtComments[i].TextAlign = HorizontalAlignment.Center;
                this.panel1.Controls.Add(this.txtComments[i]);
                col += 30;
            }
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            BatchManager BatchMng = LCData.FindBatch(_line);
            if (BatchMng != null)
            { 
                for (int i = 0; i < 4; i++)
                {
                    if (BatchMng.BatchDatas.Count > i )
                    {
                        this.txtStates[i].Text = BatchMng.BatchDatas[i].BATCH_STATE.ToString();
                        if (BatchMng.BatchDatas[i].BATCH_STATE == eBatchtState.Busy)
                        {
                            this.chkOrders[i].Enabled = false;
                            this.txtComments[i].Text = "삭제 불가능";
                        }
                        else
                        {
                            this.chkOrders[i].Enabled = true;
                            this.txtComments[i].Text = "삭제 가능";
                        }
                    }
                    else
                    {
                        this.chkOrders[i].Enabled = false;
                        this.txtStates[i].Text = "";
                        this.txtComments[i].Text = "";
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ReConfirmForm reconfirmForm = new ReConfirmForm("선택된 계획을 삭제하시겠습니까?");
            DialogResult rusult = reconfirmForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                BatchManager BatchMng = LCData.FindBatch(_line);
                if (BatchMng != null)
                {
                    for (int i = 3; i >= 0; --i)
                    {
                        if (this.chkOrders[i].Checked) BatchMng.BatchDatas.RemoveAt(i);
                    }

                    int j = 0;
                    foreach (BatchObject BatchObj in BatchMng.BatchDatas)
                    {
                        BatchObj.ORDER_NO = ++j;
                        if (BatchObj.ORDER_NO == 1) 
                            LCData.SaveBatCh(BatchMng.TARGET_LINE, BatchObj);
                    }

                    this.DialogResult = DialogResult.OK;

                    
                }                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }       
    }
}