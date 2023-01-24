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
    public partial class FlowGroupSetForm : Form
    {
        private int _portNo = 0;
        private eLINE _line = 0;
        private string _flowID = "";
        private List<FlowGroupData> _flowGroup = null;

        private System.Windows.Forms.Panel[] pnViews;
        private System.Windows.Forms.Label[] lbFlowIDs;
        private System.Windows.Forms.Label[] lbCFsNR01;
        private System.Windows.Forms.Label[] lbITOsNR01;
        private System.Windows.Forms.Label[] lbCFsBM01;
        private System.Windows.Forms.Label[] lbITOsBM01;
        private System.Windows.Forms.Button[] btnSelectNR01;        
        private System.Windows.Forms.Button[] btnSelectBM01;

        public FlowGroupSetForm(eLINE line, int portNo, string flowID)
        {          
            InitializeComponent();           

            PORT = portNo;
            LINE = line;
            FLOWID = flowID;
            InitControl();

            
        }

        public int PORT
        {
            get { return _portNo; }
            set { _portNo = value;}
        }
        public eLINE LINE
        {
            get { return _line; }
            set { _line = value; }
        }
        public string FLOWID
        {
            get { return _flowID; }
            set { _flowID = value; }
        }
        public List<FlowGroupData> FLOWGROUP
        {
            get { return _flowGroup; }
            set { _flowGroup = value; }
        }

        public void InitControl()
        {
            this.pnViews      = new System.Windows.Forms.Panel[2];
            this.lbFlowIDs = new System.Windows.Forms.Label[2];

            this.lbCFsNR01 = new System.Windows.Forms.Label[3];
            this.lbCFsBM01 = new System.Windows.Forms.Label[3];

            this.lbITOsNR01 = new System.Windows.Forms.Label[9];
            this.lbITOsBM01 = new System.Windows.Forms.Label[1];

            this.btnSelectNR01 = new System.Windows.Forms.Button[9];
            this.btnSelectBM01 = new System.Windows.Forms.Button[3];

            string[] idArray = new string[2] { "NR01", "BM01"};
            string[] eqArray = new string[3] { "1호기", "2호기", "1,2호기" };
            string[] typeArray1 = new string[9] { "11", "12", "13", "21", "22", "23", "31", "32", "33"};
            string[] typeArray2 = new string[3] { "10", "20", "30"};

            //PANEL & FLOWID LABEL Create
            for(int i = 0 ; i < 2; i++)
            {             
                this.pnViews[i] = new System.Windows.Forms.Panel();
                this.pnViews[i].Name = idArray[i];
                //this.pnViews[i].Tag = (int)i;
                this.pnViews[i].Location = new System.Drawing.Point(12, 66);
                this.pnViews[i].BorderStyle = BorderStyle.Fixed3D;
                this.pnViews[i].Size = new System.Drawing.Size(397, 240);
                this.pnViews[i].Visible = true;
                
                this.lbFlowIDs[i] = new System.Windows.Forms.Label();
                this.lbFlowIDs[i].Location = new System.Drawing.Point(0, 0);
                this.lbFlowIDs[i].Size = new System.Drawing.Size(98, i > 0 ? 79 : 235);
                this.lbFlowIDs[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbFlowIDs[i].BackColor = Color.WhiteSmoke;
                this.lbFlowIDs[i].TextAlign = ContentAlignment.MiddleCenter;
                this.lbFlowIDs[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.lbFlowIDs[i].Text = idArray[i];
                this.pnViews[i].Controls.Add(this.lbFlowIDs[i]);
            }

            
            int x1 = 97, y1 = 0, x2 = 97, y2 = 0;
            for (int i = 0; i < 3; i++)
            { 
                this.lbCFsNR01[i] = new System.Windows.Forms.Label();
                this.lbCFsNR01[i].Location = new System.Drawing.Point(x1, y1);
                this.lbCFsNR01[i].Size = new System.Drawing.Size(99, 79);
                this.lbCFsNR01[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbCFsNR01[i].BackColor = Color.WhiteSmoke;
                this.lbCFsNR01[i].TextAlign = ContentAlignment.MiddleCenter;
                this.lbCFsNR01[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.lbCFsNR01[i].Text = eqArray[i];
                this.pnViews[0].Controls.Add(this.lbCFsNR01[i]);
                y1 += 78;

                this.lbCFsBM01[i] = new System.Windows.Forms.Label();
                this.lbCFsBM01[i].Location = new System.Drawing.Point(x2, y2);
                this.lbCFsBM01[i].Size = new System.Drawing.Size(99, 27);
                this.lbCFsBM01[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbCFsBM01[i].BackColor = Color.WhiteSmoke;
                this.lbCFsBM01[i].TextAlign = ContentAlignment.MiddleCenter;
                this.lbCFsBM01[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.lbCFsBM01[i].Text = eqArray[i];
                this.pnViews[1].Controls.Add(this.lbCFsBM01[i]);
                y2 += 26;
            }

            int x3 = 196 , y3 = 0, x4 = 295, y4 = 1;
            for (int i = 0; i < 9; i++)
            {
                this.lbITOsNR01[i] = new System.Windows.Forms.Label();
                this.lbITOsNR01[i].Location = new System.Drawing.Point(x3, y3);
                this.lbITOsNR01[i].Size = new System.Drawing.Size(100, 27);
                this.lbITOsNR01[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbITOsNR01[i].BackColor = Color.WhiteSmoke;
                this.lbITOsNR01[i].TextAlign = ContentAlignment.MiddleCenter;
                this.lbITOsNR01[i].Text = eqArray[i % 3];
                this.lbITOsNR01[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.pnViews[0].Controls.Add(this.lbITOsNR01[i]);
                y3 += 26;

                this.btnSelectNR01[i] = new System.Windows.Forms.Button();
                this.btnSelectNR01[i].Name = typeArray1[i];
                this.btnSelectNR01[i].Location = new System.Drawing.Point(x4, y4);
                this.btnSelectNR01[i].Size = new System.Drawing.Size(97, 25);
                this.btnSelectNR01[i].BackColor = Color.Red;
                this.btnSelectNR01[i].Text = "미사용";
                this.btnSelectNR01[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.btnSelectNR01[i].Click += new EventHandler(btnSelectNR01_Click);
                this.pnViews[0].Controls.Add(this.btnSelectNR01[i]);
                y4 += 26;
            }

            this.lbITOsBM01[0] = new System.Windows.Forms.Label();
            this.lbITOsBM01[0].Location = new System.Drawing.Point(196, 0);
            this.lbITOsBM01[0].Size = new System.Drawing.Size(99, 79);
            this.lbITOsBM01[0].BorderStyle = BorderStyle.FixedSingle;
            this.lbITOsBM01[0].BackColor = Color.WhiteSmoke;
            this.lbITOsBM01[0].TextAlign = ContentAlignment.MiddleCenter;
            this.lbITOsBM01[0].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            this.pnViews[1].Controls.Add(this.lbITOsBM01[0]);

            int x5 = 295, y5 = 1;
            for (int i = 0; i < 3; i++)
            {
                this.btnSelectBM01[i] = new System.Windows.Forms.Button();
                this.btnSelectBM01[i].Name = typeArray2[i];
                this.btnSelectBM01[i].Location = new System.Drawing.Point(x5, y5);
                this.btnSelectBM01[i].Size = new System.Drawing.Size(97, 25);
                this.btnSelectBM01[i].BackColor = Color.Red;
                this.btnSelectBM01[i].Text = "미사용";
                this.btnSelectBM01[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                this.btnSelectBM01[i].Click += new EventHandler(btnSelectBM01_Click);
                this.pnViews[1].Controls.Add(this.btnSelectBM01[i]);
                y5 += 26;
            }

            this.Controls.Add(this.pnViews[0]);
            this.Controls.Add(this.pnViews[1]);

            UpdateDisplay(LINE, PORT, FLOWID);
        }       
        public List<bool> BoolList(string bin)
        {
            List<bool> list = new List<bool>();
            char[] chars = bin.ToCharArray();
            Array.Reverse(chars);

            foreach (char ch in chars)
            {
                if (ch == '1') list.Add(true);
                else list.Add(false);
            }
            return list;
        }

        private void btnSelectNR01_Click(object sender, EventArgs e)
        {
            Button btnSelect = sender as Button;
            if (btnSelect != null && btnSelect.Enabled != false)
            {
                if (btnSelect.Text == "사용")
                {
                    btnSelect.Text = "미사용";
                    btnSelect.BackColor = Color.Red;
                    return;
                }

                btnSelect.Text = "사용";
                btnSelect.BackColor = Color.Lime;

                foreach (Control ctlPanel in this.Controls)
                {
                    Panel pnView = ctlPanel as Panel;
                    if (pnView != null && pnView.Visible)
                    {
                        foreach (Control ctl in pnView.Controls)
                        {
                            Button btn = ctl as Button;
                            if (btn != null)
                            {
                                if (btn.Equals(btnSelect) || btn.Enabled != true) continue;

                                btn.Text = "미사용";
                                btn.BackColor = Color.Red;
                            }
                        }
                    }
                }        
            }                    
        }
        private void btnSelectBM01_Click(object sender, EventArgs e)
        {
            Button btnSelect = sender as Button;
            if (btnSelect != null && btnSelect.Enabled != false)
            {
                if (btnSelect.Text == "사용")
                {
                    btnSelect.Text = "미사용";
                    btnSelect.BackColor = Color.Red;
                    return;
                }

                btnSelect.Text = "사용";
                btnSelect.BackColor = Color.Lime;


                foreach (Control ctlPanel in this.Controls)
                {
                    Panel pnView = ctlPanel as Panel;
                    if (pnView != null && pnView.Visible)
                    {
                        foreach (Control ctl in pnView.Controls)
                        {
                            Button btn = ctl as Button;
                            if (btn != null)
                            {
                                if (btn.Equals(btnSelect) || btn.Enabled != true) continue;

                                btn.Text = "미사용";
                                btn.BackColor = Color.Red;
                            }
                        }
                    }
                }             
            }           
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            int value = -1;
            List<FlowGroupData> flowGroups = new List<FlowGroupData>();

            foreach (Control ctlPanel in this.Controls)
            {
                Panel pnView = ctlPanel as Panel;
                if (pnView != null)
                {
                    if (pnView.Visible)
                    {
                        foreach (Control ctl in pnView.Controls)
                        {
                            Button btnSelect = ctl as Button;
                            if (btnSelect != null && btnSelect.Text == "사용")
                            {
                                value = int.Parse(btnSelect.Name);
                                break;
                            }
                        }
                    }
                }
            }            

            switch (value)
            {
                case 11:
                case 12:
                case 13:
                    {
                        value -= 11;
                        for (int k = 0; k < 2; k++)
                        {
                            FlowGroupData FlowGroup = new FlowGroupData();

                            FlowGroup.FlowList = BoolList(Convert.ToString(k + 1, 2).PadLeft(4, '0') + "0000" +
                                Convert.ToString(((value - (value - 1) - k) + ((value + 1) * k)), 2).PadLeft(8, '0'));
                            FlowGroup.Binary = FlowGroup.StringList;

                            flowGroups.Add(FlowGroup);
                        }
                    }
                    break;
                case 21:
                case 22:
                case 23:
                    {
                        value -= 18;
                        for (int k = 0; k < 2; k++)
                        {
                            FlowGroupData FlowGroup = new FlowGroupData();

                            FlowGroup.FlowList = BoolList(Convert.ToString(k + 1, 2).PadLeft(4, '0') + "0000" +
                                Convert.ToString(((value - (value - 2) - k) + ((value - 3) * k)), 2).PadLeft(8, '0'));
                            FlowGroup.Binary = FlowGroup.StringList;

                            flowGroups.Add(FlowGroup);
                        }
                    }
                    break;
                case 31:
                case 32:
                case 33:
                    {
                        value -= 25;
                        for (int k = 0; k < 2; k++)
                        {
                            FlowGroupData FlowGroup = new FlowGroupData();

                            FlowGroup.FlowList = BoolList(Convert.ToString(k + 1, 2).PadLeft(4, '0') + "0000" +
                                Convert.ToString(((value - (value - 3) - k) + ((value - 7) * k)), 2).PadLeft(8, '0'));
                            FlowGroup.Binary = FlowGroup.StringList;

                            flowGroups.Add(FlowGroup);
                        }
                    }
                    break;
                case 10:
                case 20:
                case 30:
                    {
                        value /= 10;
                        for (int k = 0; k < 1; k++)
                        {
                            FlowGroupData FlowGroup = new FlowGroupData();

                            FlowGroup.FlowList = BoolList(Convert.ToString(1, 2).PadLeft(4, '0') + "0000" +
                                       Convert.ToString(value ,2).PadLeft(8, '0'));
                            FlowGroup.Binary = FlowGroup.StringList;

                            flowGroups.Add(FlowGroup);
                        }
                    }
                    break;
            }

            int cnt = flowGroups.Count;
            for (int k = 0; k < 10 - cnt; k++)
            {
                FlowGroupData FlowGroup = new FlowGroupData();

                FlowGroup.FlowList = BoolList("0".PadLeft(16, '0'));
                FlowGroup.Binary = FlowGroup.StringList;

                flowGroups.Add(FlowGroup);
            }

            FLOWGROUP = flowGroups;
            this.DialogResult = DialogResult.OK;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void UpdateDisplay(eLINE line, int portNo, string flowID)
        {
            BatchManager BatchInfo = LCData.FindBatch(portNo);

            if (BatchInfo != null)
            {
                int index = (portNo -= 1) % 2;

                lbTitle.Text = flowID;
                foreach (Control ctlPanel in this.Controls)
                {
                    Panel pnView = ctlPanel as Panel;
                    if (pnView != null && pnView.Name == flowID)
                    {
                        pnView.Visible = true;
                        List<FlowGroupInterlock> Interlocks = LCData.FindInterlock(line, flowID);
                        if (Interlocks != null)
                        {
                            int i = 0;
                            foreach (Control ctl in pnView.Controls)
                            {
                                Button btnSelect = ctl as Button;
                                if (btnSelect != null)
                                {                                   
                                    if (BatchInfo.PortDatas[index].Cassette != null && BatchInfo.PortDatas[index].Cassette.GlassDatas.Count > 0)
                                    {
                                        if (int.Parse(btnSelect.Name.Substring(0, 1)) == System.Convert.ToInt32(BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups[0].Worker, 2) &&
                                            int.Parse(btnSelect.Name.Substring(1, 1)) == System.Convert.ToInt32(BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups[1].Worker, 2))
                                        {
                                            btnSelect.Text = "사용";
                                            btnSelect.BackColor = Color.Lime;
                                        }
                                        else
                                        {
                                            btnSelect.Text = "미사용";
                                            btnSelect.BackColor = Color.Red;
                                        }
                                    }

                                    if (Interlocks[i].Used != 1)
                                    {
                                        btnSelect.Enabled = false;
                                        btnSelect.BackColor = Color.Gray;
                                    }
                                    i++;
                                }
                            }
                        }
                    }
                    else if (pnView != null)
                    {
                        pnView.Visible = false;
                    }                    
                }
            }
        } 
    }
}