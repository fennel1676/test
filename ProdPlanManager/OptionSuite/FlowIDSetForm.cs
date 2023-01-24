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
    public partial class FlowIDSetForm : Form
    {
        private string _flowID = "";

        public string FLOWID
        {
            get { return _flowID; }
            set { _flowID = value; }
        }

        public FlowIDSetForm(string flowID)
        {
            InitializeComponent();
            FLOWID = flowID;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.grpFlowID.Controls)
            {
                Button btnSelect = ctl as Button;
                if (btnSelect != null && btnSelect.Text == "NR01" && btnSelect.BackColor == Color.Lime)
                {
                    FLOWID = "NR01";
                    break;
                }
                else if (btnSelect != null && btnSelect.Text == "BM01" && btnSelect.BackColor == Color.Lime)
                {
                    FLOWID = "BM01";
                    break;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnNR01_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Lime;

                foreach (Control ctl in this.grpFlowID.Controls)
                {
                    Button btnSelect = ctl as Button;
                    if (btnSelect != null && btnSelect.Name == "btnBM01")
                    {
                        btnSelect.BackColor = Color.Red;
                        break;
                    }
                }
            }
        }

        private void btnBM01_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Lime;

                foreach (Control ctl in this.grpFlowID.Controls)
                {
                    Button btnSelect = ctl as Button;
                    if (btnSelect != null && btnSelect.Name == "btnNR01")
                    {
                        btnSelect.BackColor = Color.Red;
                        break;
                    }
                }
            }
        }

        private void FlowIDSetForm_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.grpFlowID.Controls)
            {
                Button btnSelect = ctl as Button;
                if (btnSelect != null)
                {
                    if (btnSelect.Name.Substring(3, 4) == FLOWID)
                    {
                        btnSelect.BackColor = Color.Lime;
                        break;
                    }
                }
            }
        }
    }
}