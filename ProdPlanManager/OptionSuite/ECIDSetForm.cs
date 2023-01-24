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
    public partial class ECIDSetForm : Form
    {
        public event EventHandler ECIDSetEvent;

        private Button[] btnECID1s = null;
        private Button[] btnECID2s = null;
        private GroupBox[] grpViews = null;
        private Label[] lbECID1s = null;
        private Label[] lbECID2s = null;

        public ECIDSetForm()
        {
            InitializeComponent();
            InitControl();
            InitExample1Spread();
            InitExample2Spread();
        }
        public void InitControl()
        {
            grpViews = new GroupBox[2];
            btnECID1s = new Button[3];
            btnECID2s = new Button[2];
            lbECID1s = new Label[3];
            lbECID2s = new Label[2];

            string[] strArray1 = new string[2] { "INPUT MODE", "ERROR CONTROL MODE" };
            string[] strArray2 = new string[3] { "STK & HOST", "HOST", "EQ SENSOR" };
            string[] strArray3 = new string[2] { "투입", "CANCEL" };

            int x0 = 11;
            int y0 = 38;
            for (int i = 0; i < 2; i++)
            {
                this.grpViews[i] = new GroupBox();
                this.grpViews[i].Location = new System.Drawing.Point(x0, y0);
                this.grpViews[i].Text = strArray1[i];
                this.grpViews[i].Size = new System.Drawing.Size(396, 59);
                this.grpViews[i].Visible = true;
                x0 += 395;
            }

            int x1 = 10;
            int y1 = 17;
            for (int i = 0; i < 3; i++)
            {
                this.btnECID1s[i] = new Button();
                this.btnECID1s[i].Name = i.ToString();
                this.btnECID1s[i].BackColor = Color.Transparent;
                this.btnECID1s[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnECID1s[i].Font = new System.Drawing.Font("verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.btnECID1s[i].Location = new System.Drawing.Point(x1, y1);
                this.btnECID1s[i].Size = new System.Drawing.Size(126, 36);
                this.btnECID1s[i].Text = strArray2[i];
                this.btnECID1s[i].Click += new EventHandler(BtnECID1s_Click);
                x1 += 125;
                this.grpViews[0].Controls.Add(btnECID1s[i]);               
            }
            this.Controls.Add(grpViews[0]);

            int x2 = 7;
            int y2 = 17;
            for (int i = 0; i < 2; i++)
            {
                btnECID2s[i] = new Button();
                btnECID2s[i].Name = i.ToString();
                btnECID2s[i].BackColor = Color.Transparent;
                btnECID2s[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnECID2s[i].Font = new System.Drawing.Font("verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                btnECID2s[i].Location = new System.Drawing.Point(x2, y2);
                btnECID2s[i].Size = new System.Drawing.Size(190, 36);
                btnECID2s[i].Text = strArray3[i];
                btnECID2s[i].Click += new EventHandler(BtnECID2s_Click);
                x2 += 190;
                this.grpViews[1].Controls.Add(btnECID2s[i]);
            }            
            this.Controls.Add(grpViews[1]);           


            this.lbECID1s[0] = new System.Windows.Forms.Label();
            this.lbECID1s[0].Location = new System.Drawing.Point(341, 52);
            this.lbECID1s[0].Size = new System.Drawing.Size(433, 46);
            this.lbECID1s[0].BorderStyle = BorderStyle.FixedSingle;
            this.lbECID1s[0].BackColor = Color.White;
            this.lbECID1s[0].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            this.lbECID1s[0].Text = "a. STK와 HOST 수량이 다를 경우 CST INFOR NAK(Code: 102)처리 함.     (REMOTE: Host에서 Cancel | LOCAL: 작업자가 처리함)                     b. 투입 중 Mapping과 실물 위치가 다를 경우 자동 Abort함";
            this.groupBox1.Controls.Add(this.lbECID1s[0]);

            this.lbECID1s[1] = new System.Windows.Forms.Label();
            this.lbECID1s[1].Location = new System.Drawing.Point(341, 97);
            this.lbECID1s[1].Size = new System.Drawing.Size(433, 34);
            this.lbECID1s[1].BorderStyle = BorderStyle.FixedSingle;
            this.lbECID1s[1].BackColor = Color.White;
            this.lbECID1s[1].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            this.lbECID1s[1].Text = "a. STK 수량은 무시하고, HOST로부터 받은 수량으로 CST Mapping함.b. 투입 중 Mapping과 실물 위치가 다를 경우 자동 Abort함";
            this.groupBox1.Controls.Add(this.lbECID1s[1]);

            this.lbECID1s[2] = new System.Windows.Forms.Label();
            this.lbECID1s[2].Location = new System.Drawing.Point(341, 130);
            this.lbECID1s[2].Size = new System.Drawing.Size(433, 50);
            this.lbECID1s[2].BorderStyle = BorderStyle.FixedSingle;
            this.lbECID1s[2].BackColor = Color.White;
            this.lbECID1s[2].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            this.lbECID1s[2].Text = "a. STK, HOST 수량 무시하고, 무조건 20 매 CST Mapping함.             b. 투입 중 다음 Slot이 비어 있다 하더라도, Abort하지 않고 Skip 하여        강제 투입함.";
            this.groupBox1.Controls.Add(this.lbECID1s[2]);

            this.lbECID2s[0] = new System.Windows.Forms.Label();
            this.lbECID2s[0].Location = new System.Drawing.Point(341, 194);
            this.lbECID2s[0].Size = new System.Drawing.Size(433, 22);
            this.lbECID2s[0].BorderStyle = BorderStyle.FixedSingle;
            this.lbECID2s[0].BackColor = Color.White;
            this.lbECID2s[0].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            this.lbECID2s[0].Text = "ECID 1번의 Setting대로 처리함";
            this.groupBox1.Controls.Add(this.lbECID2s[0]);

            this.lbECID2s[1] = new System.Windows.Forms.Label();
            this.lbECID2s[1].Location = new System.Drawing.Point(341, 215);
            this.lbECID2s[1].Size = new System.Drawing.Size(433, 46);
            this.lbECID2s[1].BorderStyle = BorderStyle.FixedSingle;
            this.lbECID2s[1].BackColor = Color.White;
            this.lbECID2s[1].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            this.lbECID2s[1].Text = "a. Load Complete 때까지 정상 Report: Mapping 수량 30으로 처리   b. CST INFOR NAK 처리(Code: 102)";
            this.groupBox1.Controls.Add(this.lbECID2s[1]);


            foreach (EqConstantData data in LCData.EqConstants)
            {
                if (data.ECID == 1)
                {
                    btnECID1s[int.Parse(data.ECDEF) - 1].BackColor = Color.Lime;
                    lbECID1s[int.Parse(data.ECDEF) - 1].BackColor = Color.Lime;
                }
                if (data.ECID == 2)
                {
                    btnECID2s[int.Parse(data.ECDEF) - 1].BackColor = Color.Lime;
                    lbECID2s[int.Parse(data.ECDEF) - 1].BackColor = Color.Lime;
                }
            }

        }
        void BtnECID1s_Click(object sender, EventArgs e)
        {
            if (LCData.OnlinePLCState != eEIPCMD.ONLINE)
            {
                MessageBox.Show("현재 PLC와 연결되어 있지 않습니다.", "변경 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool bRunning = false;
            foreach (BatchManager batchInfo in LCData.BatchManagers)
            {

                if (batchInfo.PortDatas[0].Port.PortState == ePortState.Busy || batchInfo.PortDatas[0].Port.PortState == ePortState.Reserve ||
                    batchInfo.PortDatas[1].Port.PortState == ePortState.Busy || batchInfo.PortDatas[1].Port.PortState == ePortState.Reserve)
                    bRunning = true;
            }

            if (bRunning)
            {
                MessageBox.Show("현재 운전중인 PORT로 인하여 INPUT 모드를 변경 할 수 없습니다.", "변경 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }          

            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Lime;
                lbECID1s[int.Parse(btn.Name)].BackColor = Color.Lime;

                for (int i = 0; i < 3; i++)
                {
                    if (btn.Name ==  i.ToString()) continue;
                    btnECID1s[i].BackColor = Color.Transparent;
                    lbECID1s[i].BackColor = Color.White;                    
                }
                EqConstantData ECIDData = LCData.GetEqConstant(1);
                if (ECIDData != null)
                    ECIDData.ECDEF = (int.Parse(btn.Name) + 1).ToString();

                ECIDSetEvent(this, EventArgs.Empty);

            }
        }
        void BtnECID2s_Click(object sender, EventArgs e)
        {
            if (LCData.OnlinePLCState != eEIPCMD.ONLINE)
            {
                MessageBox.Show("현재 PLC와 연결되어 있지 않습니다.", "변경 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool bRunning = false;
            foreach (BatchManager batchInfo in LCData.BatchManagers)
            {

                if (batchInfo.PortDatas[0].Port.PortState == ePortState.Busy || batchInfo.PortDatas[0].Port.PortState == ePortState.Reserve ||
                    batchInfo.PortDatas[1].Port.PortState == ePortState.Busy || batchInfo.PortDatas[1].Port.PortState == ePortState.Reserve)
                    bRunning = true;
            }

            if (bRunning)
            {
                MessageBox.Show("현재 운전중인 PORT로 인하여 ERROR CONTROL 모드를 변경 할 수 없습니다.", "변경 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }              

            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Lime;
                lbECID2s[int.Parse(btn.Name)].BackColor = Color.Lime;

                for (int i = 0; i < 2; i++)
                {
                    if (btn.Name == i.ToString()) continue;
                    btnECID2s[i].BackColor = Color.Transparent;
                    lbECID2s[i].BackColor = Color.White;
                }
                EqConstantData ECIDData = LCData.GetEqConstant(2);
                if (ECIDData != null)
                    ECIDData.ECDEF = (int.Parse(btn.Name) + 1).ToString();

                ECIDSetEvent(this, EventArgs.Empty);
            }
        }      
        public void InitExample1Spread()
        {
            ////Text Cell Type
            fpSpread3_Sheet1.DefaultStyle.CellType = new FarPoint.Win.Spread.CellType.TextCellType();

            //ActiveSkin
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread3);

            //Split 설정
            fpSpread3.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread3.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            fpSpread3.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            fpSpread3.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            //TrackPolicy
            fpSpread3.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            fpSpread3.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            fpSpread3.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            fpSpread3.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BlockOption
            fpSpread3.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            //ReadOnly
            fpSpread3_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread3_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread3_Sheet1.Columns.Default.Resizable = false;
            fpSpread3_Sheet1.Rows.Default.Resizable = false;

            fpSpread3_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

            //HeaderCount
            fpSpread3_Sheet1.RowHeader.ColumnCount = 0;
            fpSpread3_Sheet1.ColumnHeader.RowCount = 2;

            //BodyCount
            fpSpread3_Sheet1.RowCount = 5;
            fpSpread3_Sheet1.ColumnCount = 7;

            //Font
            fpSpread3.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < fpSpread3_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread3_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            for (int i = 0; i < fpSpread3_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread3_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < fpSpread3_Sheet1.ColumnCount; i++)
            {
                fpSpread3_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                fpSpread3_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            fpSpread3_Sheet1.Columns[0].Width = 45.0f;
            fpSpread3_Sheet1.Columns[1].Width = 45.0f;
            fpSpread3_Sheet1.Columns[2].Width = 45.0f;
            fpSpread3_Sheet1.Columns[3].Width = 45.0f;  //180
            fpSpread3_Sheet1.Columns[4].Width = 250.0f;
            fpSpread3_Sheet1.Columns[5].Width = 170.0f;
            fpSpread3_Sheet1.Columns[6].Width = 176.0f;

            //Height
            fpSpread3_Sheet1.Rows[0].Height = 20;
            fpSpread3_Sheet1.Rows[1].Height = 20;
            fpSpread3_Sheet1.Rows[2].Height = 20;
            fpSpread3_Sheet1.Rows[3].Height = 20;
            fpSpread3_Sheet1.Rows[4].Height = 20;

            //Span            
            fpSpread3_Sheet1.ColumnHeader.Cells[0, 0].ColumnSpan = 2;
            fpSpread3_Sheet1.ColumnHeader.Cells[0, 2].ColumnSpan = 2;
            fpSpread3_Sheet1.ColumnHeader.Cells[0, 4].ColumnSpan = 3;

            fpSpread3_Sheet1.Cells[0, 0].RowSpan = 3;
            fpSpread3_Sheet1.Cells[0, 1].RowSpan = 3;
            fpSpread3_Sheet1.Cells[0, 2].RowSpan = 3;

            fpSpread3_Sheet1.Cells[3, 0].RowSpan = 2;
            fpSpread3_Sheet1.Cells[3, 1].RowSpan = 2;
            fpSpread3_Sheet1.Cells[3, 2].RowSpan = 2;

            //HeaderText
            fpSpread3_Sheet1.ColumnHeader.Cells[0, 0].Text = "CST";
            fpSpread3_Sheet1.ColumnHeader.Cells[0, 2].Text = "ECID";
            fpSpread3_Sheet1.ColumnHeader.Cells[1, 0].Text = "STK";
            fpSpread3_Sheet1.ColumnHeader.Cells[1, 1].Text = "HOST";
            fpSpread3_Sheet1.ColumnHeader.Cells[1, 2].Text = "ECID";
            fpSpread3_Sheet1.ColumnHeader.Cells[1, 3].Text = "DEF";
            fpSpread3_Sheet1.ColumnHeader.Cells[1, 4].Text = "CST수량 처리 기준";
            fpSpread3_Sheet1.ColumnHeader.Cells[1, 5].Text = "CST INFO SEND RESULT";
            fpSpread3_Sheet1.ColumnHeader.Cells[1, 6].Text = "CST Remapping 수량";

            // Content

            // STK
            fpSpread3_Sheet1.Cells[0, 0].Text = "10";
            fpSpread3_Sheet1.Cells[3, 0].Text = "20";

            // HOST
            fpSpread3_Sheet1.Cells[0, 1].Text = "20";
            fpSpread3_Sheet1.Cells[3, 1].Text = "20";

            // ECID
            fpSpread3_Sheet1.Cells[0, 2].Text = "1";
            fpSpread3_Sheet1.Cells[3, 2].Text = "2";

            // DEF
            fpSpread3_Sheet1.Cells[0, 3].Text = "1";
            fpSpread3_Sheet1.Cells[1, 3].Text = "2";
            fpSpread3_Sheet1.Cells[2, 3].Text = "3";
            fpSpread3_Sheet1.Cells[3, 3].Text = "1";
            fpSpread3_Sheet1.Cells[4, 3].Text = "2";

            // CST 수량 처리 기준
            fpSpread3_Sheet1.Columns[4].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            fpSpread3_Sheet1.Cells[0, 4].Text = " HOST <-> STK";
            fpSpread3_Sheet1.Cells[1, 4].Text = " HOST";
            fpSpread3_Sheet1.Cells[2, 4].Text = " 강제 20 매 CST Mapping";
            fpSpread3_Sheet1.Cells[3, 4].Text = " ECID '1' 기준으로 처리";
            fpSpread3_Sheet1.Cells[4, 4].Text = " 무조건 CST INFOR NAK 처리 (Code: 102)";

            // CST INFO SEND RESULT
            fpSpread3_Sheet1.Columns[5].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            fpSpread3_Sheet1.Cells[0, 5].Text = " NAK(Code: 102)";
            fpSpread3_Sheet1.Cells[1, 5].Text = " ACK";
            fpSpread3_Sheet1.Cells[2, 5].Text = " ACK";
            fpSpread3_Sheet1.Cells[3, 5].Text = " -";
            fpSpread3_Sheet1.Cells[4, 5].Text = " NAK(Code: 102)";

            // CST Remapping 수량
            fpSpread3_Sheet1.Columns[6].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            fpSpread3_Sheet1.Cells[0, 6].Text = " HOST/STK 수량";
            fpSpread3_Sheet1.Cells[1, 6].Text = " HOST 수량";
            fpSpread3_Sheet1.Cells[2, 6].Text = " 20";
            fpSpread3_Sheet1.Cells[3, 6].Text = " ECID 1 의 처리 결과";
            fpSpread3_Sheet1.Cells[4, 6].Text = " -";

            for (int i = 0; i < 7; i++)
                fpSpread3_Sheet1.Columns[i].Locked = true;
        }
        public void InitExample2Spread()
        {
            ////Text Cell Type
            fpSpread3_Sheet1.DefaultStyle.CellType = new FarPoint.Win.Spread.CellType.TextCellType();

            //ActiveSkin
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread4);

            //Split 설정
            fpSpread4.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread4.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            fpSpread4.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            fpSpread4.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            //TrackPolicy
            fpSpread4.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            fpSpread4.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            fpSpread4.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            fpSpread4.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BlockOption
            fpSpread4.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            //ReadOnly
            fpSpread4_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread4_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread4_Sheet1.Columns.Default.Resizable = false;
            fpSpread4_Sheet1.Rows.Default.Resizable = false;

            fpSpread4_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

            //HeaderCount
            fpSpread4_Sheet1.RowHeader.ColumnCount = 0;
            fpSpread4_Sheet1.ColumnHeader.RowCount = 2;

            //BodyCount
            fpSpread4_Sheet1.RowCount = 5;
            fpSpread4_Sheet1.ColumnCount = 7;

            //Font
            fpSpread4.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < fpSpread4_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread4_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            for (int i = 0; i < fpSpread4_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread4_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < fpSpread4_Sheet1.ColumnCount; i++)
            {
                fpSpread4_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                fpSpread4_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            fpSpread4_Sheet1.Columns[0].Width = 45.0f;
            fpSpread4_Sheet1.Columns[1].Width = 45.0f;
            fpSpread4_Sheet1.Columns[2].Width = 45.0f;
            fpSpread4_Sheet1.Columns[3].Width = 45.0f;  //160
            fpSpread4_Sheet1.Columns[4].Width = 170.0f;
            fpSpread4_Sheet1.Columns[5].Width = 170.0f;
            fpSpread4_Sheet1.Columns[6].Width = 256.0f;

            //Height
            fpSpread4_Sheet1.Rows[0].Height = 20;
            fpSpread4_Sheet1.Rows[1].Height = 20;
            fpSpread4_Sheet1.Rows[2].Height = 20;
            fpSpread4_Sheet1.Rows[3].Height = 20;
            fpSpread4_Sheet1.Rows[4].Height = 20;

            //Span            
            fpSpread4_Sheet1.ColumnHeader.Cells[0, 0].ColumnSpan = 2;
            fpSpread4_Sheet1.ColumnHeader.Cells[0, 2].ColumnSpan = 2;
            fpSpread4_Sheet1.ColumnHeader.Cells[0, 4].ColumnSpan = 3;

            fpSpread4_Sheet1.Cells[0, 0].RowSpan = 3;
            fpSpread4_Sheet1.Cells[0, 1].RowSpan = 3;
            fpSpread4_Sheet1.Cells[0, 2].RowSpan = 3;

            fpSpread4_Sheet1.Cells[3, 0].RowSpan = 2;
            fpSpread4_Sheet1.Cells[3, 1].RowSpan = 2;
            fpSpread4_Sheet1.Cells[3, 2].RowSpan = 2;

            //HeaderText
            fpSpread4_Sheet1.ColumnHeader.Cells[0, 0].Text = "CST";
            fpSpread4_Sheet1.ColumnHeader.Cells[0, 2].Text = "ECID";
            fpSpread4_Sheet1.ColumnHeader.Cells[1, 0].Text = "STK";
            fpSpread4_Sheet1.ColumnHeader.Cells[1, 1].Text = "HOST";
            fpSpread4_Sheet1.ColumnHeader.Cells[1, 2].Text = "ECID";
            fpSpread4_Sheet1.ColumnHeader.Cells[1, 3].Text = "DEF";
            fpSpread4_Sheet1.ColumnHeader.Cells[1, 4].Text = "PC 화면 표시 Mapping Slot";
            fpSpread4_Sheet1.ColumnHeader.Cells[1, 5].Text = "Start 時 CST Mapping Slot";
            fpSpread4_Sheet1.ColumnHeader.Cells[1, 6].Text = "Comment";

            // Content

            // STK
            fpSpread4_Sheet1.Cells[0, 0].Text = "10";
            fpSpread4_Sheet1.Cells[3, 0].Text = "30";

            // HOST
            fpSpread4_Sheet1.Cells[0, 1].Text = "20";
            fpSpread4_Sheet1.Cells[3, 1].Text = "20";

            // ECID
            fpSpread4_Sheet1.Cells[0, 2].Text = "1";
            fpSpread4_Sheet1.Cells[3, 2].Text = "2";

            // DEF
            fpSpread4_Sheet1.Cells[0, 3].Text = "1";
            fpSpread4_Sheet1.Cells[1, 3].Text = "2";
            fpSpread4_Sheet1.Cells[2, 3].Text = "3";
            fpSpread4_Sheet1.Cells[3, 3].Text = "1";
            fpSpread4_Sheet1.Cells[4, 3].Text = "2";

            // PC 화면 표시 Mapping Slot
            fpSpread4_Sheet1.Columns[4].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            fpSpread4_Sheet1.Cells[0, 4].Text = " STK 수량";
            fpSpread4_Sheet1.Cells[1, 4].Text = " STK 수량";
            fpSpread4_Sheet1.Cells[2, 4].Text = " STK 수량";
            fpSpread4_Sheet1.Cells[3, 4].Text = " 20 매";
            fpSpread4_Sheet1.Cells[4, 4].Text = " 20 매";

            // Start시 CST Mapping Slot
            fpSpread4_Sheet1.Columns[5].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            fpSpread4_Sheet1.Cells[0, 5].Text = " STK 수량";
            fpSpread4_Sheet1.Cells[1, 5].Text = " STK 수량";
            fpSpread4_Sheet1.Cells[2, 5].Text = " 20 매";
            fpSpread4_Sheet1.Cells[3, 5].Text = " 20 매";
            fpSpread4_Sheet1.Cells[4, 5].Text = " 20 매";

            // Comment
            fpSpread4_Sheet1.Columns[6].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            fpSpread4_Sheet1.Cells[3, 6].Text = " Slot Mismatch는 ECID '1' 기준으로 처리";
            fpSpread4_Sheet1.Cells[4, 6].Text = " Slot Mismatch는 ECID '1' 기준으로 처리";

            for (int i = 0; i < 7; i++)
                fpSpread4_Sheet1.Columns[i].Locked = true;
        }
        public void UpdateDisplay()
        {
            int row = 0;
            //int nCount = 0;
            //// Border
            //FarPoint.Win.LineBorder border = new FarPoint.Win.LineBorder(Color.Yellow, 1, false, false, false, true);
            //foreach (EqConstantData eqConstant in LCData.EqConstants)
            //{
            //    fpSpread1_Sheet1.SetText(row, 0, eqConstant.ECID.ToString());
            //    fpSpread1_Sheet1.SetText(row, 1, eqConstant.ECDEF);
            //    if (nCount == 0)
            //    {
            //        nOldIndex1 = Convert.ToInt16(eqConstant.ECDEF);
            //    }
            //    else
            //    {
            //        nOldIndex2 = Convert.ToInt16(eqConstant.ECDEF);
            //    }
            //    nCount++;
            //    row++;
            //}
            //if (nOldIndex1 == 1)
            //{
            //    fpSpread2_Sheet1.Cells[1, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[1, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[1, 4].BackColor = Color.Yellow;
            //    //fpSpread2_Sheet1.Cells[1, 2].Border = border;
            //    //fpSpread2_Sheet1.Cells[1, 3].Border = border;
            //    fpSpread2_Sheet1.Cells[1, 4].Border = border;
            //    fpSpread2_Sheet1.Cells[2, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[2, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[2, 4].BackColor = Color.Yellow;
            //    //fpSpread2_Sheet1.Cells[2, 2].Border = border;
            //    //fpSpread2_Sheet1.Cells[2, 3].Border = border;
            //    fpSpread2_Sheet1.Cells[2, 4].Border = border;
            //    fpSpread2_Sheet1.Cells[3, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[3, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[3, 4].BackColor = Color.Yellow;
            //}
            //if (nOldIndex1 == 2)
            //{
            //    fpSpread2_Sheet1.Cells[4, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[4, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[4, 4].BackColor = Color.Yellow;
            //    //fpSpread2_Sheet1.Cells[4, 2].Border = border;
            //    //fpSpread2_Sheet1.Cells[4, 3].Border = border;
            //    fpSpread2_Sheet1.Cells[4, 4].Border = border;
            //    fpSpread2_Sheet1.Cells[5, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[5, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[5, 4].BackColor = Color.Yellow;
            //}
            //if (nOldIndex1 == 3)
            //{
            //    fpSpread2_Sheet1.Cells[6, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[6, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[6, 4].BackColor = Color.Yellow;
            //    //fpSpread2_Sheet1.Cells[6, 2].Border = border;
            //    //fpSpread2_Sheet1.Cells[6, 3].Border = border;
            //    fpSpread2_Sheet1.Cells[6, 4].Border = border;
            //    fpSpread2_Sheet1.Cells[7, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[7, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[7, 4].BackColor = Color.Yellow;
            //}
            //if (nOldIndex2 == 1)
            //{
            //    fpSpread2_Sheet1.Cells[9, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[9, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[9, 4].BackColor = Color.Yellow;
            //}
            //if (nOldIndex2 == 2)
            //{
            //    fpSpread2_Sheet1.Cells[10, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[10, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[10, 4].BackColor = Color.Yellow;
            //    //fpSpread2_Sheet1.Cells[10, 2].Border = border;
            //    //fpSpread2_Sheet1.Cells[10, 3].Border = border;
            //    fpSpread2_Sheet1.Cells[10, 4].Border = border;
            //    fpSpread2_Sheet1.Cells[11, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[11, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[11, 4].BackColor = Color.Yellow;
            //    //fpSpread2_Sheet1.Cells[11, 2].Border = border;
            //    //fpSpread2_Sheet1.Cells[11, 3].Border = border;
            //    fpSpread2_Sheet1.Cells[11, 4].Border = border;
            //    fpSpread2_Sheet1.Cells[12, 2].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[12, 3].BackColor = Color.Yellow;
            //    fpSpread2_Sheet1.Cells[12, 4].BackColor = Color.Yellow;
            //}
        }        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }        
    }
}