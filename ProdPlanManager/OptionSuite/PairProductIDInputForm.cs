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
    public partial class PairProductIDInputForm : Form
    {
        int selectPortNo;
        private string _pairProductID = "";

        public PairProductIDInputForm(int portNo, string inputData)
        {
            InitializeComponent();
            selectPortNo = portNo;
            SELECT_PAIR_PRODUCTID = inputData;  
        }
        public string SELECT_PAIR_PRODUCTID
        {
            get { return _pairProductID; }
            set { _pairProductID = value; }
        }
        private void PairProductIDInputForm_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (SELECT_PAIR_PRODUCTID == "")
            {
                BatchManager BatchInfo = LCData.FindBatch(selectPortNo + 1);
                if (BatchInfo != null)
                {
                    if (BatchInfo.BatchDatas.Count > 0)
                    {
                        //int index = selectPortNo % 2;

                        string[] tokenArray = BatchInfo.BatchDatas[0].P_MAKER.Split(',');
                        textBox1.Text = tokenArray[0];
                    }
                }
            }
            else
            {
                textBox1.Text = SELECT_PAIR_PRODUCTID;
            }
        }
 
        private void btnApply_Click(object sender, EventArgs e)
        {
            SELECT_PAIR_PRODUCTID = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }      
    }
}