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
    public partial class PortInputForm : Form
    {
        public delegate void PortEventHandler(int PortNo);
        public event PortEventHandler PortEvent;

        public delegate void CstInfoHandler(PortData PortInfo);
        public event CstInfoHandler CstInfoEvent;

        public delegate void JobStartEventHandler(PortData PortInfo, eByWho bywho, eLogType logtype);
        public event JobStartEventHandler JobStartEvent;

        public delegate void JobAbortEventHandler(PortData PortInfo, eByWho bywho, eLogType logtype);
        public event JobAbortEventHandler JobAbortEvent;

        public delegate void JobCancelEventHandler(PortData PortInfo, eByWho bywho, eLogType logtype);
        public event JobCancelEventHandler JobCancelEvent;

        public delegate void JobReloadEventHandler(PortData PortInfo, eByWho bywho, eLogType logtype);
        public event JobReloadEventHandler JobReloadEvent;

        public delegate void SetMessageEventHandler(short serialNo, string logtext, eLINE line);
        public event SetMessageEventHandler SetMessage;

        private System.Windows.Forms.Panel[]  pnViews;
        private System.Windows.Forms.Button[] btnSelectP1s;
        private System.Windows.Forms.Button[] btnSelectP2s;
        private System.Windows.Forms.Button[] btnSelectP3s;
        private System.Windows.Forms.Button[] btnSelectP4s;

        private System.Windows.Forms.Button[] btnJobStarts;
        private System.Windows.Forms.Button[] btnJobAborts;
        private System.Windows.Forms.Button[] btnJobCancels;
        private System.Windows.Forms.Button[] btnJobReloads;

        private System.Windows.Forms.Label[] lbCstIDTitles;
        private System.Windows.Forms.Label[] lbMapStifTitles;
        private System.Windows.Forms.Label[] lbCurStifTitles;
        private System.Windows.Forms.Label[] lbPortIDTitles;
        private System.Windows.Forms.Label[] lbPortStateTitles;

        private System.Windows.Forms.Label[] lbCstIDs;
        private System.Windows.Forms.Label[] lbMapStifs;
        private System.Windows.Forms.Label[] lbCurStifs;
        private System.Windows.Forms.Label[] lbPortIDs;
        private System.Windows.Forms.Label[] lbPortStates;
        private FarPoint.Win.Spread.FpSpread[] fpSpreads;        
              
        public PortInputForm()
        {
            InitializeComponent();            
        }
        public void InitControl()
        {
            pnViews      = new System.Windows.Forms.Panel[4];
            btnSelectP1s = new System.Windows.Forms.Button[4];
            btnSelectP2s = new System.Windows.Forms.Button[4];
            btnSelectP3s = new System.Windows.Forms.Button[4];
            btnSelectP4s = new System.Windows.Forms.Button[4];

            btnJobStarts = new System.Windows.Forms.Button[4];
            btnJobAborts = new System.Windows.Forms.Button[4];
            btnJobCancels = new System.Windows.Forms.Button[4];
            btnJobReloads = new System.Windows.Forms.Button[4];

            lbCstIDTitles = new System.Windows.Forms.Label[4];
            lbMapStifTitles = new System.Windows.Forms.Label[4];
            lbCurStifTitles = new System.Windows.Forms.Label[4];
            lbPortIDTitles = new System.Windows.Forms.Label[4];
            lbPortStateTitles = new System.Windows.Forms.Label[4];

            lbCstIDs =new System.Windows.Forms.Label[4];
            lbMapStifs = new System.Windows.Forms.Label[4];
            lbCurStifs = new System.Windows.Forms.Label[4];
            lbPortIDs = new System.Windows.Forms.Label[4];
            lbPortStates = new System.Windows.Forms.Label[4];
            fpSpreads = new FarPoint.Win.Spread.FpSpread[4];
           
            for (int i = 0; i < 4; i++)
            {                
                this.pnViews[i] = new System.Windows.Forms.Panel();
                this.pnViews[i].Tag = (int)i;
                this.pnViews[i].Location = new System.Drawing.Point(4, 4);
                this.pnViews[i].BorderStyle = BorderStyle.Fixed3D;
                this.pnViews[i].Size = new System.Drawing.Size(1006, 556);
                this.pnViews[i].Visible = true;

                this.btnSelectP1s[i] = new System.Windows.Forms.Button();
                this.btnSelectP1s[i].Tag = (int)0;
                this.btnSelectP1s[i].Location = new System.Drawing.Point(10, 9);
                this.btnSelectP1s[i].Size = new System.Drawing.Size(80, 45);
                this.btnSelectP1s[i].BackColor = Color.Transparent;
                this.btnSelectP1s[i].Text = "PORT1";
                this.btnSelectP1s[i].Click += new EventHandler(btnSelectP1_Click);
                this.pnViews[i].Controls.Add(this.btnSelectP1s[i]);

                this.btnSelectP2s[i] = new System.Windows.Forms.Button();
                this.btnSelectP2s[i].Tag = (int)1;
                this.btnSelectP2s[i].Location = new System.Drawing.Point(90, 9);
                this.btnSelectP2s[i].Size = new System.Drawing.Size(80, 45);
                this.btnSelectP2s[i].BackColor = Color.Transparent;
                this.btnSelectP2s[i].Text = "PORT2";
                this.btnSelectP2s[i].Click += new EventHandler(btnSelectP2_Click);
                this.pnViews[i].Controls.Add(this.btnSelectP2s[i]);

                this.btnSelectP3s[i] = new System.Windows.Forms.Button();
                this.btnSelectP3s[i].Tag = (int)2;
                this.btnSelectP3s[i].Location = new System.Drawing.Point(170, 9);
                this.btnSelectP3s[i].Size = new System.Drawing.Size(80, 45);
                this.btnSelectP3s[i].BackColor = Color.Transparent;
                this.btnSelectP3s[i].Text = "PORT3";
                this.btnSelectP3s[i].Click += new EventHandler(btnSelectP3_Click);
                this.pnViews[i].Controls.Add(this.btnSelectP3s[i]);

                this.btnSelectP4s[i] = new System.Windows.Forms.Button();
                this.btnSelectP4s[i].Tag = (int)3;
                this.btnSelectP4s[i].Location = new System.Drawing.Point(250, 9);
                this.btnSelectP4s[i].Size = new System.Drawing.Size(80, 45);
                this.btnSelectP4s[i].BackColor = Color.Transparent;
                this.btnSelectP4s[i].Text = "PORT4";
                this.btnSelectP4s[i].Click += new EventHandler(btnSelectP4_Click);
                this.pnViews[i].Controls.Add(this.btnSelectP4s[i]);

                this.btnJobStarts[i] = new System.Windows.Forms.Button();
                this.btnJobStarts[i].Tag = (int)i;
                //this.btnJobStarts[i].Name = "START" + i.ToString();
                this.btnJobStarts[i].Location = new System.Drawing.Point(8, 509);
                this.btnJobStarts[i].Size = new System.Drawing.Size(178, 35);
                this.btnJobStarts[i].BackColor = Color.Transparent;
                this.btnJobStarts[i].Text = "JOB START";
                this.btnJobStarts[i].Enabled = false;
                this.btnJobStarts[i].Click += new EventHandler(btnJobStart_Click);
                this.pnViews[i].Controls.Add(this.btnJobStarts[i]);


                this.btnJobCancels[i] = new System.Windows.Forms.Button();
                this.btnJobCancels[i].Tag = (int)i;
                //this.btnJobCancels[i].Name = "CANCEL" + i.ToString();
                this.btnJobCancels[i].Location = new System.Drawing.Point(185, 509);
                this.btnJobCancels[i].Size = new System.Drawing.Size(178, 35);
                this.btnJobCancels[i].BackColor = Color.Transparent;
                this.btnJobCancels[i].Text = "JOB CANCEL";
                this.btnJobCancels[i].Enabled = false;
                this.btnJobCancels[i].Click += new EventHandler(btnJobCancel_Click);
                this.pnViews[i].Controls.Add(this.btnJobCancels[i]);


                this.btnJobAborts[i] = new System.Windows.Forms.Button();
                this.btnJobAborts[i].Tag = (int)i;
                //this.btnJobStarts[i].Name = "ABORT" + i.ToString();
                this.btnJobAborts[i].Location = new System.Drawing.Point(362, 509);
                this.btnJobAborts[i].Size = new System.Drawing.Size(178, 35);
                this.btnJobAborts[i].BackColor = Color.Transparent;
                this.btnJobAborts[i].Text = "JOB ABORT";
                this.btnJobAborts[i].Enabled = false;
                this.btnJobAborts[i].Click += new EventHandler(btnJobAbort_Click);
                this.pnViews[i].Controls.Add(this.btnJobAborts[i]);                

                this.btnJobReloads[i] = new System.Windows.Forms.Button();
                this.btnJobReloads[i].Tag = (int)i;
                //this.btnJobStarts[i].Name = "RELOAD" + i.ToString();
                this.btnJobReloads[i].Location = new System.Drawing.Point(539, 509);
                this.btnJobReloads[i].Size = new System.Drawing.Size(178, 35);
                this.btnJobReloads[i].BackColor = Color.Transparent;
                this.btnJobReloads[i].Text = "JOB RELOAD";
                this.btnJobReloads[i].Enabled = false;
                this.btnJobReloads[i].Click += new EventHandler(btnJobReload_Click);
                this.pnViews[i].Controls.Add(this.btnJobReloads[i]);

                this.lbCstIDTitles[i] = new System.Windows.Forms.Label();
                this.lbCstIDTitles[i].Location = new System.Drawing.Point(330,10);
                this.lbCstIDTitles[i].Size = new System.Drawing.Size(150, 20);
                this.lbCstIDTitles[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbCstIDTitles[i].BackColor = Color.Yellow;
                this.lbCstIDTitles[i].Text = "CSTID";
                this.lbCstIDTitles[i].TextAlign = ContentAlignment.MiddleCenter;
                this.pnViews[i].Controls.Add(this.lbCstIDTitles[i]);

                this.lbCstIDs[i] = new System.Windows.Forms.Label();
                this.lbCstIDs[i].Tag = (int)1;
                this.lbCstIDs[i].Location = new System.Drawing.Point(330, 29);
                this.lbCstIDs[i].Size = new System.Drawing.Size(150, 23);
                this.lbCstIDs[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbCstIDs[i].BackColor = Color.White;
                this.lbCstIDs[i].TextAlign = ContentAlignment.MiddleCenter;                
                this.pnViews[i].Controls.Add(this.lbCstIDs[i]);

                this.lbMapStifTitles[i] = new System.Windows.Forms.Label();
                this.lbMapStifTitles[i].Location = new System.Drawing.Point(480, 10);
                this.lbMapStifTitles[i].Size = new System.Drawing.Size(120, 20);
                this.lbMapStifTitles[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbMapStifTitles[i].BackColor = Color.Yellow;
                this.lbMapStifTitles[i].Text = "MAP STIF";
                this.lbMapStifTitles[i].TextAlign = ContentAlignment.MiddleCenter;
                this.pnViews[i].Controls.Add(this.lbMapStifTitles[i]);

                this.lbMapStifs[i] = new System.Windows.Forms.Label();
                this.lbMapStifs[i].Tag = (int)2;
                this.lbMapStifs[i].Location = new System.Drawing.Point(480, 29);
                this.lbMapStifs[i].Size = new System.Drawing.Size(120, 23);
                this.lbMapStifs[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbMapStifs[i].BackColor = Color.White;
                this.lbMapStifs[i].TextAlign = ContentAlignment.MiddleCenter;              
                this.pnViews[i].Controls.Add(this.lbMapStifs[i]);

                this.lbCurStifTitles[i] = new System.Windows.Forms.Label();
                this.lbCurStifTitles[i].Location = new System.Drawing.Point(600, 10);
                this.lbCurStifTitles[i].Size = new System.Drawing.Size(120, 20);
                this.lbCurStifTitles[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbCurStifTitles[i].Text = "CUR STIF";
                this.lbCurStifTitles[i].BackColor = Color.Yellow;
                this.lbCurStifTitles[i].TextAlign = ContentAlignment.MiddleCenter; 
                this.pnViews[i].Controls.Add(this.lbCurStifTitles[i]);

                this.lbCurStifs[i] = new System.Windows.Forms.Label();
                this.lbCurStifs[i].Tag = (int)3;
                this.lbCurStifs[i].Location = new System.Drawing.Point(600, 29);
                this.lbCurStifs[i].Size = new System.Drawing.Size(120, 23);
                this.lbCurStifs[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbCurStifs[i].BackColor = Color.White;
                this.lbCurStifs[i].TextAlign = ContentAlignment.MiddleCenter; 
                this.pnViews[i].Controls.Add(this.lbCurStifs[i]);

                this.lbPortIDTitles[i] = new System.Windows.Forms.Label();
                this.lbPortIDTitles[i].Location = new System.Drawing.Point(720, 10);
                this.lbPortIDTitles[i].Size = new System.Drawing.Size(120, 20);
                this.lbPortIDTitles[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbPortIDTitles[i].Text = "PORT ID";
                this.lbPortIDTitles[i].BackColor = Color.Yellow;
                this.lbPortIDTitles[i].TextAlign = ContentAlignment.MiddleCenter; 
                this.pnViews[i].Controls.Add(this.lbPortIDTitles[i]);

                this.lbPortIDs[i] = new System.Windows.Forms.Label();
                this.lbPortIDs[i].Tag = (int)4;
                this.lbPortIDs[i].Location = new System.Drawing.Point(720,29);
                this.lbPortIDs[i].Size = new System.Drawing.Size(120, 23);
                this.lbPortIDs[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbPortIDs[i].BackColor = Color.White;
                this.lbPortIDs[i].TextAlign = ContentAlignment.MiddleCenter; 
                this.pnViews[i].Controls.Add(this.lbPortIDs[i]);

                this.lbPortStateTitles[i] = new System.Windows.Forms.Label();
                this.lbPortStateTitles[i].Location = new System.Drawing.Point(840, 10);
                this.lbPortStateTitles[i].Size = new System.Drawing.Size(150, 20);
                this.lbPortStateTitles[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbPortStateTitles[i].BackColor = Color.Yellow;
                this.lbPortStateTitles[i].Text = "PORT STATE";
                this.lbPortStateTitles[i].TextAlign = ContentAlignment.MiddleCenter; 
                this.pnViews[i].Controls.Add(this.lbPortStateTitles[i]);

                this.lbPortStates[i] = new System.Windows.Forms.Label();
                this.lbPortStates[i].Tag = (int)5;
                this.lbPortStates[i].Location = new System.Drawing.Point(840,29);
                this.lbPortStates[i].Size = new System.Drawing.Size(150, 23);
                this.lbPortStates[i].BorderStyle = BorderStyle.FixedSingle;
                this.lbPortStates[i].BackColor = Color.White;
                this.lbPortStates[i].TextAlign = ContentAlignment.MiddleCenter; 
                this.pnViews[i].Controls.Add(this.lbPortStates[i]);

                this.fpSpreads[i] = new FarPoint.Win.Spread.FpSpread();
                FarPoint.Win.Spread.SheetView fpSpreads_Sheet1 = new FarPoint.Win.Spread.SheetView();

                this.fpSpreads[i].Name = i.ToString();
                this.fpSpreads[i].Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] { fpSpreads_Sheet1 });            

                this.fpSpreads[i].Location = new System.Drawing.Point(6, 62);
                this.fpSpreads[i].Size = new System.Drawing.Size(986, 441);
                this.fpSpreads[i].CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fsSpreads_CellDoubleClick);

                this.fpSpreads[i].Sheets[0].Reset();
                this.fpSpreads[i].Sheets[0].SheetName = "Sheet1";

                //ActiveSkin
                FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(this.fpSpreads[i]);

                //Split 설정
                this.fpSpreads[i].ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
                this.fpSpreads[i].RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

                //스크롤바 설정
                this.fpSpreads[i].HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                this.fpSpreads[i].VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

                //TrackPolicy
                this.fpSpreads[i].ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

                //TextTipPolicy
                this.fpSpreads[i].TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

                //커서 설정
                this.fpSpreads[i].SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
                this.fpSpreads[i].SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

                //BackColor
               // fpSpreads[i].Sheets[0].GrayAreaBackColor = SystemColors.ControlLight;

                //BlockOption
                this.fpSpreads[i].SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
                //ReadOnly
                //fpsp.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
                //this.fpSpreads[i].Sheet1SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
                //Sizeble
                int n = this.fpSpreads[i].Sheets.Count;
                //this.fpSpreads[i].Sheets.Count Columns.Default.Resizable = false;
                this.fpSpreads[i].Sheets[0].Rows.Default.Resizable = false;

                //HeaderCount
                this.fpSpreads[i].Sheets[0].RowHeader.ColumnCount = 1;
                this.fpSpreads[i].Sheets[0].ColumnHeader.RowCount = 1;

                //BodyCount
                this.fpSpreads[i].Sheets[0].RowCount = 20;
                this.fpSpreads[i].Sheets[0].ColumnCount = 30;

                this.fpSpreads[i].Font = new Font("Verdana", 8.25f);
                for (int j = 0; j < this.fpSpreads[i].Sheets[0].RowHeader.ColumnCount; j++)
                    this.fpSpreads[i].Sheets[0].RowHeader.Columns[j].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                for (int j = 0; j < this.fpSpreads[i].Sheets[0].ColumnHeader.RowCount; j++)
                    this.fpSpreads[i].Sheets[0].ColumnHeader.Rows[j].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

                //Alignment
                for (int j = 0; j < this.fpSpreads[i].Sheets[0].ColumnCount; j++)
                {
                    this.fpSpreads[i].Sheets[0].Columns[j].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.fpSpreads[i].Sheets[0].Columns[j].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }

                //HeaderWidth
                this.fpSpreads[i].Sheets[0].RowHeader.Columns[0].Width = 30.0f;

                //Width
                this.fpSpreads[i].Sheets[0].Columns[0].Width = 30.0f;
                for (int j = 1; j < this.fpSpreads[i].Sheets[0].ColumnCount; j++)
                {
                    this.fpSpreads[i].Sheets[0].Columns[j].Width = 150.0f;
                }

                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 0].Text = "SEL";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 1].Text = "H_PANLEID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 2].Text = "FLOWID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 3].Text = "FLOWGROUP";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 4].Text = "PAIR_PRODUCTID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 5].Text = "PAIR_H_PANELID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 6].Text = "E_PANELID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 7].Text = "PROD_TYPE";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 8].Text = "PROD_KIND";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 9].Text = "PPID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 10].Text = "PROCESSID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 11].Text = "PANEL_SIZE";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 12].Text = "THICKNESS";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 13].Text = "COMP_COUNT";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 14].Text = "DBR_RECIPE";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 15].Text = "PRODUCTID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 16].Text = "PANEL_STATE";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 17].Text = "READING_FLAG";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 18].Text = "INS_FLAG";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 19].Text = "PANEL_POSITION";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 20].Text = "JUDGEMENT";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 21].Text = "CODE";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 22].Text = "FLOW_HISTORY";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 23].Text = "UNIQUEID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 24].Text = "COUNT1";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 25].Text = "COUNT2";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 26].Text = "GRADE";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 27].Text = "MULTI_USE";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 28].Text = "STEPID";
                this.fpSpreads[i].Sheets[0].ColumnHeader.Cells[0, 29].Text = "PAIR_GRADE";


                int slot = 20;
                for (int j = 0; j < 20; j++)
                {
                    this.fpSpreads[i].Sheets[0].RowHeader.Cells[j, 0].Text = (slot- j).ToString();
                }

                //CellType
                FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
                FarPoint.Win.Spread.CellType.TextCellType textType2 = new FarPoint.Win.Spread.CellType.TextCellType();

                for (int j = 1; j < 30; j++)
                {
                    this.fpSpreads[i].Sheets[0].Columns[j].CellType = textType;
                }
                textType2.MaxLength = 20;
                this.fpSpreads[i].Sheets[0].Columns[4].CellType = textType2;

                //Lock
                for (int j = 0; j < this.fpSpreads[i].Sheets[0].ColumnCount; j++)
                {
                    this.fpSpreads[i].Sheets[0].Columns[j].Locked = true;
                    this.fpSpreads[i].Sheets[0].Columns[j].BackColor = Color.DarkGray;
                }
                this.pnViews[i].Controls.Add(this.fpSpreads[i]);

                this.Controls.Add(this.pnViews[i]);
            }

            this.btnSelectP1s[0].BackColor = Color.Yellow;
            this.btnSelectP2s[1].BackColor = Color.Yellow;
            this.btnSelectP3s[2].BackColor = Color.Yellow;
            this.btnSelectP4s[3].BackColor = Color.Yellow;
        }
        private void fsSpreads_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fsSpread = sender as FarPoint.Win.Spread.FpSpread;

            BatchManager BatchInfo = LCData.FindBatch(int.Parse(fsSpread.Name) + 1);
            if (BatchInfo != null)
            {
                int index = int.Parse(fsSpread.Name) % 2;

                if (LCData.OnlineHostState != eMCMD.LOCAL || BatchInfo.PortDatas[index].Port.PortState != ePortState.Wait)
                    return;
                
                switch (e.Column)
                {
                    case 2:                       
                        {
                            FlowIDSetForm flowIDForm = new FlowIDSetForm(fsSpread.Sheets[0].GetText(e.Row, e.Column));
                            DialogResult rusult = flowIDForm.ShowDialog();

                            if (rusult == DialogResult.OK)
                            {
                                if (int.Parse(BatchInfo.PortDatas[index].Port.CurStif) != 0 && flowIDForm.FLOWID.Trim() != "")
                                {
                                    MakeCassetteInfo(index, ref BatchInfo);
                                    BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowID = flowIDForm.FLOWID.Trim();

                                    for (int i = 0; i < 20; i++)
                                    {
                                        if (fsSpread.Sheets[0].GetText(i, e.Column) != "" || BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowID != fsSpread.Sheets[0].GetText(i, e.Column))
                                        {
                                            fsSpread.Sheets[0].SetText(i, e.Column + 1, "");
                                            BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroupName = "";

                                            BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups.Clear();
                                            for (int k = 0; k < 10; k++)
                                            {
                                                FlowGroupData FlowGroup = new FlowGroupData();
                                                List<bool> list = new List<bool>();

                                                for (int l = 0; l < 10; l++)
                                                    list.Add(false);

                                                FlowGroup.FlowList = list;
                                                FlowGroup.Binary = FlowGroup.StringList;

                                                BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups.Add(FlowGroup);
                                            }
                                        }
                                        fsSpread.Sheets[0].SetText(i, e.Column, "");
                                        if ((BatchInfo.PortDatas[index].Port.CurStif == "30" ? 20 : int.Parse(BatchInfo.PortDatas[index].Port.CurStif)) > i)
                                            fsSpread.Sheets[0].SetText(i, e.Column, BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowID);
                                    }
                                    PortEvent(int.Parse(fsSpread.Name) + 1);
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            FlowRecipeData flowRecipe = LCData.GetFlowRecipe(fsSpread.Sheets[0].GetText(e.Row, e.Column - 1));
                            if (flowRecipe == null)
                            {
                                MessageBox.Show("유효하지 않는 FlowID이거나, FlowID가 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                FlowGroupSetForm flowGroupForm = new FlowGroupSetForm(BatchInfo.TARGET_LINE, int.Parse(fsSpread.Name) + 1, flowRecipe.FlowID);
                                DialogResult result = flowGroupForm.ShowDialog();

                                if (result == DialogResult.OK)
                                {
                                    if (int.Parse(BatchInfo.PortDatas[index].Port.CurStif) != 0)
                                    {
                                        MakeCassetteInfo(index, ref BatchInfo);
                                        if (BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups != null)
                                            BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups = null;

                                        BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups = flowGroupForm.FLOWGROUP;

                                        BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroupName = "";
                                        foreach (FlowGroupData grp in BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups)
                                        {
                                            BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroupName += grp.WORKID_NAME + grp.WORKER_NAME;
                                            BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroupName += " ";
                                        }
                                        BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroupName = BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroupName.Trim();

                                        for (int i = 0; i < 20; i++)
                                        {
                                            fsSpread.Sheets[0].SetText(i, e.Column, "");
                                            if ((BatchInfo.PortDatas[index].Port.CurStif == "30" ? 20 : int.Parse(BatchInfo.PortDatas[index].Port.CurStif)) > i)
                                                fsSpread.Sheets[0].SetText(i, e.Column, BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroupName);
                                        }
                                        PortEvent(int.Parse(fsSpread.Name) + 1);
                                    }
                                }
                                
                            }                            
                        }
                        break;
                    case 4:
                        {
                            PairProductIDInputForm pairProductIDForm = new PairProductIDInputForm(int.Parse(fsSpread.Name), fsSpread.Sheets[0].GetText(e.Row, e.Column));
                            DialogResult rusult = pairProductIDForm.ShowDialog();

                            if (rusult == DialogResult.OK)
                            {
                                if (int.Parse(BatchInfo.PortDatas[index].Port.CurStif) != 0)
                                {
                                    MakeCassetteInfo(index, ref BatchInfo);
                                    BatchInfo.PortDatas[index].Cassette.GlassDatas[0].PanelPairProp.PairProductID = pairProductIDForm.SELECT_PAIR_PRODUCTID.Trim();

                                    for (int i = 0; i < 20; i++)
                                    {
                                        fsSpread.Sheets[0].SetText(i, e.Column, "");
                                        if ((BatchInfo.PortDatas[index].Port.CurStif == "30" ? 20 : int.Parse(BatchInfo.PortDatas[index].Port.CurStif)) > i)
                                            fsSpread.Sheets[0].SetText(i, e.Column, BatchInfo.PortDatas[index].Cassette.GlassDatas[0].PanelPairProp.PairProductID);
                                    }
                                    PortEvent(int.Parse(fsSpread.Name) + 1);
                                }
                            }
                            
                        }
                        break;
                }
            }
        }
        private void MakeCassetteInfo(int index, ref BatchManager BatchInfo)
        {
            int nMapStif = 0;
            int nCurStif = 0;
            int nAvailStif = 0;

            if (BatchInfo.PortDatas[index].Cassette == null ||
                BatchInfo.PortDatas[index].Cassette.GlassDatas.Count < 1)
            {
                if (BatchInfo.PortDatas[index].Cassette != null)
                    BatchInfo.PortDatas[index].Cassette = null;

                CassetteObject Cassette = new CassetteObject();
                
                nMapStif = Convert.ToInt32(BatchInfo.PortDatas[index].Port.MapStif);
                nCurStif = Convert.ToInt32(BatchInfo.PortDatas[index].Port.CurStif);

                Cassette.MapStif = LCData.GetHostMapping(BatchInfo.PortDatas[index].Port.MapStif);
                Cassette.CurStif = LCData.GetHostMapping(BatchInfo.PortDatas[index].Port.CurStif);
                Cassette.AvailStif = LCData.GetHostMapping(BatchInfo.PortDatas[index].Port.CurStif);
                Cassette.CstType = "1120";


                GlassData glass = new GlassData();                    

                for (int k = 0; k < 10; k++)
                {
                    FlowGroupData FlowGroup = new FlowGroupData();
                    List<bool> list = new List<bool>();
                    for (int l = 0; l < 16; l++)
                        list.Add(false);
                    FlowGroup.FlowList = list;
                    FlowGroup.Binary = FlowGroup.StringList;
                    glass.FlowGroups.Add(FlowGroup);
                }

                glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                //glass.SlotID = BatchInfo.BatchDatas.Count > 0 ? LCData.GetSlotID(nMapStif ,nCurStif, i): "";
                glass.ProcessID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROCESSID : "";
                glass.ProductID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PRODUCTID : "";
                glass.StepID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].STEPID : "";
                glass.BatchID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].BATCHID : "";
                glass.ProdType = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_TYPE : "";
                glass.ProdKind = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PROD_KIND : "";
                glass.PPID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].PPID : "";

                
                if(BatchInfo.BatchDatas.Count > 0)
                {
                    glass.PanelSize.Add(25000);
                    glass.PanelSize.Add(22000);

                }
                else
                {
                    for(int j = 0; j < 2; j++)
                    {
                        glass.PanelSize.Add(0);
                    }
                }
                
                glass.Thickness = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_THICKNESS : 0;
                glass.CompCount = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].C_QTY : 0;
                glass.PanelPairProp.PairHPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].P_MAKER : "";
                glass.PanelPairProp.PairEPanelID = BatchInfo.BatchDatas.Count > 0 ? BatchInfo.BatchDatas[0].F_PANELID : "";
                
                for (int j = 0; j < 28; j++)
                {
                    glass.PanelOtherProp1.FlowHistorys.Add(0);
                }

                for (int j = 0; j < 4; j++)
                {
                    glass.PanelOtherProp1.UniqueID.Add(0);
                }

                Cassette.GlassDatas.Add(glass);
                
                Cassette.CstID = BatchInfo.PortDatas[index].Port.CstID;

                BatchInfo.PortDatas[index].Cassette = Cassette;
            }
        }

        private void btnSelectP1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                pnViews[(int)btn.Tag].Visible = true;
                for (int i = 0; i < 4; i++)
                {
                    if ((int)btn.Tag == i) continue;
                    pnViews[i].Visible = false;
                }
            }          
        }
        private void btnSelectP2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                pnViews[(int)btn.Tag].Visible = true;
                for (int i = 0; i < 4; i++)
                {
                    if ((int)btn.Tag == i) continue;
                    pnViews[i].Visible = false;
                }
            }
        }
        private void btnSelectP3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                pnViews[(int)btn.Tag].Visible = true;
                for (int i = 0; i < 4; i++)
                {
                    if ((int)btn.Tag == i) continue;
                    pnViews[i].Visible = false;
                }
            }
        }
        private void btnSelectP4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                pnViews[(int)btn.Tag].Visible = true;
                for (int i = 0; i < 4; i++)
                {
                    if ((int)btn.Tag == i) continue;
                    pnViews[i].Visible = false;
                }
            }
        }
        private void btnJobStart_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE || LCData.OnlinePLCState == eEIPCMD.OFFLINE)
            {
                MessageBox.Show("Host 또는 설비간에 통신 상태를 확인 하여 주십시요!");
                return;
            }
            Button btn = sender as Button;
            if (btn != null)
            {
                BatchManager BatchInfo = LCData.FindBatch((int)btn.Tag + 1);
                if (BatchInfo != null)
                {
                    short NackCode = 0;
                    LogInfoData logInfo = null;

                    int index = ((int)btn.Tag) % 2;
                    logInfo = LCData.FindLogInfo((short)eLogType.OPER_START_CMD);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[index].Port.PortID, BatchInfo.PortDatas[index].Port.CstID), BatchInfo.TARGET_LINE);
                    }


                    if (BatchInfo.BatchDatas.Count < 1)
                    {
                        NackCode = (short)eNACK.BatchPlanNotExist;
                    }
                    else if (BatchInfo.PortDatas[index].Cassette == null || BatchInfo.PortDatas[index].Cassette.GlassDatas == null)
                        NackCode = (short)eNACK.NoExistGlass;
                    else if (BatchInfo.PortDatas[index].Cassette.GlassDatas.Count == 0)
                    {
                        NackCode = (short)eNACK.NoExistGlass;
                    }
                    else if (BatchInfo.BatchDatas[0].BATCHID != BatchInfo.PortDatas[index].Cassette.GlassDatas[0].BatchID)
                    {
                        NackCode = (short)eNACK.BatchIDFail;
                    }
                    else if (BatchInfo.PortDatas[index].Port.PortState != ePortState.Wait)
                        NackCode = (short)eNACK.NotWaitState;
                    else if (null == LCData.GetFlowRecipe(BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowID))
                    {
                        NackCode = (short)eNACK.FlowIDMismatch;
                    }
                    else if (!LCData.IsFlowGroupInterlock(BatchInfo.TARGET_LINE, BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowID, BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups))
                    {
                        NackCode = (short)eNACK.FlowGroupMismatch;
                    }
                    else if (LCData.FindParamTypeCheck())
                    {
                        if (BatchInfo.PortDatas[index].Cassette.GlassDatas[0].PanelPairProp.PairProductID.Length > 5 &&
                            BatchInfo.BatchDatas[0].P_MAKER.Contains(BatchInfo.PortDatas[index].Cassette.GlassDatas[0].PanelPairProp.PairProductID.Substring(0, 6)))
                            NackCode = (short)eNACK.ACK;
                        else
                            NackCode = (short)eNACK.PMakerMismatch;
                    }

                    logInfo = LCData.FindLogInfo((short)eLogType.START_CMD_ACK, NackCode);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[index].Port.PortID, BatchInfo.PortDatas[index].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    if (NackCode == 0)
                    {
                        JobStartEvent(BatchInfo.PortDatas[index], eByWho.ByOperator, eLogType.PC_START_NORMAL);
                        CstInfoEvent(BatchInfo.PortDatas[index]);
                        MessageBox.Show(BatchInfo.PortDatas[index].Port.PortNo + "번 PORT가 정상적으로 JOB START 처리 되었습니다.", "수동 조작", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(BatchInfo.PortDatas[index].Port.PortNo + "번 PORT가 JOB START 중 NACK 발생 되었습니다.", "수동 조작", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnJobAbort_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE || LCData.OnlinePLCState == eEIPCMD.OFFLINE)
            {
                MessageBox.Show("Host 또는 설비간에 통신 상태를 확인 하여 주십시요!");
                return;
            }
            Button btn = sender as Button;
            if (btn != null)
            {
                BatchManager BatchInfo = LCData.FindBatch((int)btn.Tag + 1);
                if (BatchInfo != null)
                {
                    short NackCode = 0;
                    LogInfoData logInfo = null;

                    int index = ((int)btn.Tag) % 2;
                    logInfo = LCData.FindLogInfo((short)eLogType.OPER_ABORT_CMD);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[index].Port.PortID, BatchInfo.PortDatas[index].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    if (BatchInfo.PortDatas[index].Port.PortState != ePortState.Busy)
                        NackCode = (short)eNACK.NotPortState;                

                    logInfo = LCData.FindLogInfo((short)eLogType.ABORT_CMD_ACK, NackCode);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[index].Port.PortID, BatchInfo.PortDatas[index].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    if (NackCode == 0)
                    {
                        JobAbortEvent(BatchInfo.PortDatas[index], eByWho.ByOperator, eLogType.PC_ABORT_NORMAL);
                        MessageBox.Show(BatchInfo.PortDatas[index].Port.PortNo + "번 PORT가 정상적으로 JOB ABORT 처리 되었습니다.", "수동 조작", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(BatchInfo.PortDatas[index].Port.PortNo + "번 PORT가 JOB ABORT 중 NACK 발생 되었습니다.", "수동 조작", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnJobCancel_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE || LCData.OnlinePLCState == eEIPCMD.OFFLINE)
            {
                MessageBox.Show("Host 또는 설비간에 통신 상태를 확인 하여 주십시요!");
                return;
            }
            Button btn = sender as Button;
            if (btn != null)
            {
                BatchManager BatchInfo = LCData.FindBatch((int)btn.Tag + 1);
                if (BatchInfo != null)
                {
                    short NackCode = 0;
                    LogInfoData logInfo = null;

                    int index = ((int)btn.Tag) % 2;
                    logInfo = LCData.FindLogInfo((short)eLogType.OPER_CANCEL_CMD);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[index].Port.PortID, BatchInfo.PortDatas[index].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    if (BatchInfo.PortDatas[index].Port.PortState != ePortState.Wait && BatchInfo.PortDatas[index].Port.PortState != ePortState.Idle &&
                         BatchInfo.PortDatas[index].Port.PortState != ePortState.Ready && BatchInfo.PortDatas[index].Port.PortState != ePortState.Reserve)
                        NackCode = (short)eNACK.NotPortState;

                    logInfo = LCData.FindLogInfo((short)eLogType.CANCEL_CMD_ACK, NackCode);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[index].Port.PortID, BatchInfo.PortDatas[index].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    if (NackCode == 0)
                    {
                        JobCancelEvent(BatchInfo.PortDatas[index], eByWho.ByOperator, eLogType.PC_CANCEL_NORMAL);
                        MessageBox.Show(BatchInfo.PortDatas[index].Port.PortNo + "번 PORT가 정상적으로 JOB CANCEL 처리 되었습니다.", "수동 조작", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(BatchInfo.PortDatas[index].Port.PortNo + "번 PORT가 JOB CANCEL 중 NACK 발생 되었습니다.", "수동 조작", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnJobReload_Click(object sender, EventArgs e)
        {
            if (LCData.OnlineHostState == eMCMD.OFFLINE || LCData.OnlinePLCState == eEIPCMD.OFFLINE)
            {
                MessageBox.Show("Host 또는 설비간에 통신 상태를 확인 하여 주십시요!");
                return;
            }
            Button btn = sender as Button;
            if (btn != null)
            {
                BatchManager BatchInfo = LCData.FindBatch((int)btn.Tag + 1);
                if (BatchInfo != null)
                {
                    short NackCode = 0;
                    LogInfoData logInfo = null;

                    int index = ((int)btn.Tag) % 2;
                    logInfo = LCData.FindLogInfo((short)eLogType.OPER_RELOAD_CMD);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[index].Port.PortID, BatchInfo.PortDatas[index].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    if (BatchInfo.PortDatas[index].Port.PortState != ePortState.Complete &&
                        BatchInfo.PortDatas[index].Port.PortState != ePortState.Abort &&
                        BatchInfo.PortDatas[index].Port.PortState != ePortState.Cancel)
                        NackCode = (short)eNACK.NotPortState;

                    logInfo = LCData.FindLogInfo((short)eLogType.RELOAD_CMD_ACK, NackCode);
                    if (logInfo != null)
                    {
                        SetMessage(logInfo.SerialNo, string.Format(logInfo.Comment, BatchInfo.PortDatas[index].Port.PortID, BatchInfo.PortDatas[index].Port.CstID), BatchInfo.TARGET_LINE);
                    }

                    if (NackCode == 0)
                    {
                        JobReloadEvent(BatchInfo.PortDatas[index], eByWho.ByOperator, eLogType.PC_RELOAD_NORMAL);
                        MessageBox.Show(BatchInfo.PortDatas[index].Port.PortNo + "번 PORT가 정상적으로 CST RELOAD 처리 되었습니다.", "수동 조작", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(BatchInfo.PortDatas[index].Port.PortNo + "번 PORT가 CST RELOAD 중 NACK 발생 되었습니다.", "수동 조작", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void UpdateOnlineMode(int portNo)
        {
            BatchManager BatchInfo = LCData.FindBatch(portNo);
            if (BatchInfo != null)
            {
                int selectPort = ((portNo -= 1) % 2);

                for (int j = 2; j < 5; j++)
                {
                    if (BatchInfo.PortDatas[selectPort].Port.PortState == ePortState.Wait && LCData.OnlineHostState == eMCMD.LOCAL)
                    {

                        fpSpreads[portNo].Sheets[0].Columns[j].Locked = false;
                        fpSpreads[portNo].Sheets[0].Columns[j].BackColor = Color.White;
                    }
                    else
                    {
                        fpSpreads[portNo].Sheets[0].Columns[j].Locked = true;
                        fpSpreads[portNo].Sheets[0].Columns[j].BackColor = Color.DarkGray;
                    }
                }

                switch (BatchInfo.PortDatas[selectPort].Port.PortState)
                {
                    case ePortState.Empty:
                    case ePortState.Pause:
                    case ePortState.Disable:
                        {
                            btnJobStarts[portNo].Enabled = false;
                            btnJobCancels[portNo].Enabled = false;
                            btnJobAborts[portNo].Enabled = false;
                            btnJobReloads[portNo].Enabled = false;
                        }
                        break;
                    case ePortState.Idle:
                    case ePortState.Ready:
                    case ePortState.Reserve:
                        {
                            btnJobStarts[portNo].Enabled = false;
                            btnJobCancels[portNo].Enabled = true;
                            btnJobAborts[portNo].Enabled = false;
                            btnJobReloads[portNo].Enabled = false;
                        }
                        break;
                    case ePortState.Complete:
                    case ePortState.Abort:
                        {
                            btnJobStarts[portNo].Enabled = false;
                            btnJobCancels[portNo].Enabled = false;
                            btnJobAborts[portNo].Enabled = false;
                            btnJobReloads[portNo].Enabled = true;
                        }
                        break;
                    case ePortState.Cancel:
                        {
                            btnJobStarts[portNo].Enabled = false;
                            btnJobCancels[portNo].Enabled = false;
                            btnJobAborts[portNo].Enabled = false;
                            btnJobReloads[portNo].Enabled = true;
                        }
                        break;
                    case ePortState.Wait:
                        {
                            btnJobStarts[portNo].Enabled = true;
                            btnJobCancels[portNo].Enabled = true;
                            btnJobAborts[portNo].Enabled = false;
                            btnJobReloads[portNo].Enabled = false;
                        }
                        break;
                    case ePortState.Busy:
                        {
                            btnJobStarts[portNo].Enabled = false;
                            btnJobCancels[portNo].Enabled = false;
                            btnJobAborts[portNo].Enabled = true;
                            btnJobReloads[portNo].Enabled = false;
                        }
                        break;
                }
            }          
        }

        public void DisplayView(int PortNo)
        {
            BatchManager BatchMng = LCData.FindBatch(PortNo);
            if (BatchMng != null)
            {
                UpdateOnlineMode(PortNo);

                int selectPort = ((PortNo -= 1) % 2);
                foreach (Control ctl in this.pnViews[PortNo].Controls)
                {
                    Label lbData = ctl as Label;
                    if (lbData != null && lbData.Tag != null)
                    {
                        switch ((int)lbData.Tag)
                        {
                            case 1: lbData.Text = BatchMng.PortDatas[selectPort].Port.CstID; break;
                            case 2: lbData.Text = BatchMng.PortDatas[selectPort].Port.MapStif; break;
                            case 3: lbData.Text = BatchMng.PortDatas[selectPort].Port.CurStif; break;
                            case 4: lbData.Text = BatchMng.PortDatas[selectPort].Port.PortID; break;
                            case 5: lbData.Text = BatchMng.PortDatas[selectPort].Port.PortState.ToString(); break;
                        }                     
                    }
                    else
                    {
                        FarPoint.Win.Spread.FpSpread spread = ctl as FarPoint.Win.Spread.FpSpread;
                        if (spread != null)
                        {
                            for (int i = 0; i < 20; i++)
                            {
                                if ((BatchMng.PortDatas[selectPort].Port.CurStif == "30" ? 20 : int.Parse(BatchMng.PortDatas[selectPort].Port.CurStif)) > i)
                                {
                                    spread.Sheets[0].Cells[i, 0].BackColor = Color.Yellow;

                                    if (BatchMng.PortDatas[selectPort].Cassette != null && BatchMng.PortDatas[selectPort].Cassette.GlassDatas.Count > 0)
                                    {
                                        spread.Sheets[0].Cells[i, 2].Text = BatchMng.PortDatas[selectPort].Cassette.GlassDatas[0].FlowID;
                                        spread.Sheets[0].Cells[i, 3].Text = BatchMng.PortDatas[selectPort].Cassette.GlassDatas[0].FlowGroupName;
                                        spread.Sheets[0].Cells[i, 4].Text = BatchMng.PortDatas[selectPort].Cassette.GlassDatas[0].PanelPairProp.PairProductID;
                                    }
                                    else
                                    {
                                        spread.Sheets[0].Cells[i, 2].Text = "";
                                        spread.Sheets[0].Cells[i, 3].Text = "";
                                        spread.Sheets[0].Cells[i, 4].Text = "";
                                    }

                                    spread.Sheets[0].Cells[i, 5].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].P_MAKER : "";
                                    spread.Sheets[0].Cells[i, 7].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].PROD_TYPE : "";
                                    spread.Sheets[0].Cells[i, 8].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].PROD_KIND : "";
                                    spread.Sheets[0].Cells[i, 9].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].PPID : "";
                                    spread.Sheets[0].Cells[i, 10].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].PROCESSID : "";
                                    spread.Sheets[0].Cells[i, 11].Text = BatchMng.BatchDatas.Count > 0 ? "25000 22000" : "";
                                    spread.Sheets[0].Cells[i, 12].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].P_THICKNESS.ToString() : "";
                                    spread.Sheets[0].Cells[i, 13].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].C_QTY.ToString() : "";
                                    spread.Sheets[0].Cells[i, 15].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].PRODUCTID : "";
                                    spread.Sheets[0].Cells[i, 16].Text = BatchMng.BatchDatas.Count > 0 ? "3" : "";
                                    spread.Sheets[0].Cells[i, 20].Text = BatchMng.BatchDatas.Count > 0 ? "OK" : "";
                                    spread.Sheets[0].Cells[i, 29].Text = BatchMng.BatchDatas.Count > 0 ? BatchMng.BatchDatas[0].STEPID : "";
                                }
                                else
                                {
                                    spread.Sheets[0].Cells[i, 0].BackColor = Color.DarkGray;
                                    for (int j = 0; j < 30; j++)
                                        spread.Sheets[0].Cells[i, j].Text = "";
                                }
                            }
                        }
                    }
                }                
            }        
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void UpdateDisplay(int PortNo)
        {
            PortNo -= 1;
            switch (PortNo)
            {
                case 0: btnSelectP1_Click(btnSelectP1s[PortNo], null); break;
                case 1: btnSelectP2_Click(btnSelectP2s[PortNo], null); break;
                case 2: btnSelectP3_Click(btnSelectP3s[PortNo], null); break;
                case 3: btnSelectP4_Click(btnSelectP4s[PortNo], null); break;
            }
        }

        private void flowGroupForm_FlowGroupChangeSetEvent(int portNo, List<FlowGroupData> datas)
        {
            BatchManager BatchInfo = LCData.FindBatch(portNo);
            if (BatchInfo != null)
            {
                int index = (portNo -= 1) % 2;

                if (BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups != null)
                    BatchInfo.PortDatas[index].Cassette.GlassDatas[0].FlowGroups = datas;
            }           
        }

    }
}