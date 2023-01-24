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
    public partial class ManualBatchEndForm : Form
    {
        private short _line = 0;
        private CheckBox[] chkOrders;
        private TextBox[] txtStates;
        private TextBox[] txtComments;

        public ManualBatchEndForm(short lineNo)
        {
            InitializeComponent();
            _line = lineNo;
        }

        private void ManualBatchEndForm_Load(object sender, EventArgs e)
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
                this.chkOrders[i].Enabled = false;
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
            BatchManager BatchMng = LCData.FindBatch((eLINE)_line);
            if (BatchMng != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (BatchMng.BatchDatas.Count > i)
                    {
                        this.txtStates[i].Text = BatchMng.BatchDatas[i].BATCH_STATE.ToString();
                        if (BatchMng.BatchDatas[i].BATCH_STATE == eBatchtState.Busy)
                        {
                            this.chkOrders[i].Checked = true;
                            this.txtComments[i].Text = "종료 가능";
                        }
                        else
                        {
                            this.chkOrders[i].Checked = false;
                            this.txtComments[i].Text = "종료 불가능";
                        }
                    }
                    else
                    {
                        this.chkOrders[i].Checked = false;
                        this.txtStates[i].Text = "";
                        this.txtComments[i].Text = "";
                    }
                }
            }
        }        

        private void btnBatchEnd_Click(object sender, EventArgs e)
        {
            ReConfirmForm reconfirmForm = new ReConfirmForm("선택된 계획을 강제종료하시겠습니까?");
            DialogResult rusult = reconfirmForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
                for (int i = 3; i >= 0; --i)
                {
                    if (this.chkOrders[i].Checked)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}