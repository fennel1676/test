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
    public partial class LogViewForm : Form
    {
        public event EventHandler LogViewEvent;

        public delegate void LogColorDataChangeEventHandler(ClassCore.LogColorData logColorData);
        public event LogColorDataChangeEventHandler LogColorDataChangeSetEvent;

        private string _fromDate = "";
        private string _toDate = "";
        private string _serial = "";
        private string _nackWord = "";
        private string _keyWord = "";
        private int _page = 0;

        private System.Windows.Forms.Button[] btnColors;
        private FarPoint.Win.Spread.FpSpread[] fpSpread1s;
        private BackgroundWorker[] workers;

        public string FROM_DATE
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }
        public string TO_DATE
        {
            get { return _toDate; }
            set { _toDate = value; }
        }
        public string SERIAL_WORD
        {
            get { return _serial; }
            set { _serial = value; }
        }
        public string NACK_WORD
        {
            get { return _nackWord; }
            set { _nackWord = value; }
        }
        public string KEY_WORD
        {
            get { return _keyWord; }
            set { _keyWord = value; }
        }
        public int SELECT_PAGE
        {
            get { return _page; }
            set { _page = value; }
        }
        public LogViewForm()
        {
            InitializeComponent();
            InitControl();
        }
        public void InitControl()
        {
            int vSize = 0;

            string[] strArray1 = new string[12] { "  ----------- 전 체 보 기 -----------", "투입 계획 NACK", "CST 정보 NACK", 
                "JOB START NACK","JOB CANCEL NACK", "통신", "HOST COMMAND", "OPERATOR COMMAND", "CMD RELPY(NACK)",
                "PLC EVENT", "PC COMMAND", "PC EVENT" };

            string[] strArray2 = new string[15] { "  ----------- 전 체 보 기 -----------", "Batch Process Reply Pass(Start)",
                "Batch Process Reply Pass(End)", "Comp Start Reply Pass", "Car Valid Check Reply Pass",
                "Car Valid Check Reply Fail","Cassette Process Start","Cassette Process End", "Cassette Process Cancel",
                "Cassette Load Request","Cassette Load Reply Pass","Cassette Unload Request", "Cassette Unload Reply Pass",
                "Cassette Load Complete","Cassette Unload Complete"};

            for (int i = 0; i < 12; i++)
            {
                cbSerial1.Items.Add(strArray1[i]);
            }

            for (int i = 0; i < 15; i++)
            {
                cbSerial2.Items.Add(strArray2[i]);
            }

            //foreach (LogInfoData logInfo in LCData.logInfoDatas)
            //{
            //    cbSerial.Items.Add(logInfo.SerialNo.ToString());
            //}        
            cbSerial1.SelectedIndex = 0;
            cbSerial2.SelectedIndex = 0;

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            

            fpSpread1s = new FarPoint.Win.Spread.FpSpread[3];
            btnColors = new System.Windows.Forms.Button[7];
            workers = new BackgroundWorker[2];           

            for (int i = 0; i < 3; i++)
            {
                this.fpSpread1s[i] = new FarPoint.Win.Spread.FpSpread();
                FarPoint.Win.Spread.SheetView fpSpread1s_Sheet1 = new FarPoint.Win.Spread.SheetView();
                

                this.fpSpread1s[i].Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] { fpSpread1s_Sheet1 });

                this.fpSpread1s[i].Location = new System.Drawing.Point(3, i < 2 ? 6 + vSize : 6);
                this.fpSpread1s[i].Size = new System.Drawing.Size(970, i < 2 ? 251 : 430);

                this.fpSpread1s[i].Sheets[0].Reset();
                this.fpSpread1s[i].Sheets[0].SheetName = "Sheet1";

                // OperationMode
                fpSpread1s_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;

                //ActiveSkin
                FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(this.fpSpread1s[i]);

                //Split 설정
                this.fpSpread1s[i].ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
                this.fpSpread1s[i].RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

                //스크롤바 설정
                this.fpSpread1s[i].HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                this.fpSpread1s[i].VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

                //TrackPolicy
                this.fpSpread1s[i].ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

                //TextTipPolicy
                this.fpSpread1s[i].TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

                //커서 설정
                this.fpSpread1s[i].SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
                this.fpSpread1s[i].SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

                //BlockOption
                this.fpSpread1s[i].SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Cells;

                //Sizeble
                this.fpSpread1s[i].Sheets[0].Rows.Default.Resizable = false;

                //HeaderCount
                this.fpSpread1s[i].Sheets[0].RowHeader.ColumnCount = 0;
                this.fpSpread1s[i].Sheets[0].ColumnHeader.RowCount = 1;

                if (i == 2)
                {
                    //BodyCount
                    this.fpSpread1s[i].Sheets[0].RowCount = 0;
                    this.fpSpread1s[i].Sheets[0].ColumnCount = 3;
                }
                else
                {
                    //BodyCount
                    this.fpSpread1s[i].Sheets[0].RowCount = 0;
                    this.fpSpread1s[i].Sheets[0].ColumnCount = 4;
                }                

                this.fpSpread1s[i].Font = new Font("Verdana", 8.25f);
                for (int j = 0; j < this.fpSpread1s[i].Sheets[0].RowHeader.ColumnCount; j++)
                    this.fpSpread1s[i].Sheets[0].RowHeader.Columns[j].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                for (int j = 0; j < this.fpSpread1s[i].Sheets[0].ColumnHeader.RowCount; j++)
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Rows[j].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

                if (i == 2)
                {
                    //Alignment
                    this.fpSpread1s[i].Sheets[0].Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    this.fpSpread1s[i].Sheets[0].Columns[2].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }
                else
                {
                    //Alignment
                    this.fpSpread1s[i].Sheets[0].Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[2].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    this.fpSpread1s[i].Sheets[0].Columns[3].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }

                if (i == 2)
                {
                    //Width
                    this.fpSpread1s[i].Sheets[0].Columns[0].Width = 50.0f;
                    this.fpSpread1s[i].Sheets[0].Columns[1].Width = 160.0f;
                    this.fpSpread1s[i].Sheets[0].Columns[2].Width = 785.0f;
                }
                else
                {
                    //Width
                    this.fpSpread1s[i].Sheets[0].Columns[0].Width = 50.0f;
                    this.fpSpread1s[i].Sheets[0].Columns[1].Width = 160.0f;
                    this.fpSpread1s[i].Sheets[0].Columns[2].Width = 80.0f;
                    this.fpSpread1s[i].Sheets[0].Columns[3].Width = 705.0f;
                }

                FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
                for (int j = 0; j < this.fpSpread1s[i].Sheets[0].ColumnCount; j++)
                {
                    this.fpSpread1s[i].Sheets[0].Columns[j].CellType = textType;
                }

                if (i == 2)
                {
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 0].Text = "NO.";
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 1].Text = "DateTime";
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 2].Text = "Comment";
                }
                else
                {
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 0].Text = "NO.";
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 1].Text = "DateTime";
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 2].Text = "Serial No";
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 3].Text = "Comment";
                }
                if (i != 2)
                {
                    this.fpSpread1s[i].CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(SpreadSelect_Click);
                }
                vSize += 257;          
            }

            this.tabControl1.TabPages[0].Text = string.Format("{0, 50}","투입 현황 로그").PadRight(100,' ');
            this.tabControl1.TabPages[1].Text = string.Format("{0, 50}","HOST MESSAGE").PadRight(100, ' ');

            this.tabControl1.TabPages[0].Controls.Add(this.fpSpread1s[0]);
            this.tabControl1.TabPages[0].Controls.Add(this.fpSpread1s[1]);
            this.tabControl1.TabPages[1].Controls.Add(this.fpSpread1s[2]);

            this.Controls.Add(this.tabControl1);

            vSize = 10;
            string[] strArray = new string[7] { "통신", "HOST COMMAND", "OPERATOR COMMAND", "CMD RELPY", "PLC EVENT", "PC COMMAND", "PC EVENT" };
            
            for (int i = 0; i < 7; i++)
            {
               
                this.btnColors[i] = new System.Windows.Forms.Button();
                this.btnColors[i].Name = i.ToString();
                this.btnColors[i].Location = new System.Drawing.Point(vSize, 75);
                this.btnColors[i].Size = new System.Drawing.Size(120, 24);
                this.btnColors[i].BackColor = Color.Transparent;
                this.btnColors[i].Text = strArray[i];
                this.btnColors[i].Click += new EventHandler(btnSelect_Click);
                this.Controls.Add(this.btnColors[i]);
                vSize += 120;
            }           
            this.workers[0] = new BackgroundWorker();
            this.workers[0].WorkerSupportsCancellation = true;
            this.workers[0].DoWork += new DoWorkEventHandler(workers1_DoWork);
            this.workers[0].RunWorkerCompleted  +=new RunWorkerCompletedEventHandler(RunWorker1Completed);
            this.workers[0].WorkerReportsProgress = true;

            this.workers[1] = new BackgroundWorker();
            this.workers[1].WorkerSupportsCancellation = true;
            this.workers[1].DoWork += new DoWorkEventHandler(workers2_DoWork);
            this.workers[1].RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorker2Completed);
            this.workers[1].WorkerReportsProgress = true;

            for (int i = 0; i < 7; i++)
            {
                LogColorData ColorData = LCData.FindLogColor(i);
                btnColors[i].ForeColor = Color.FromArgb(ColorData.ColorA, ColorData.ColorR, ColorData.ColorG, ColorData.ColorB);
            }
        }
        private void workers1_DoWork(object sender, DoWorkEventArgs e)
        {
            int[] rowCount = new int[2];           

            foreach (LogData LogData in LCData.logHistoryDatas.LogHistorys)
            {
                fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 0].Text = Convert.ToString(rowCount[LogData.line - 1]+1);
                fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 1].Text = LogData.Time.Substring(0, 14).Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/");
                fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 2].Text = Convert.ToString(LogData.log_type);
                fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 3].Text = LogData.Text;

                if (1000 <=  LogData.log_type &&  1999 >=  LogData.log_type)
                    fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 3].ForeColor = btnColors[0].ForeColor;
                else if (2000 <=  LogData.log_type &&  2999 >=  LogData.log_type)
                    fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 3].ForeColor = btnColors[1].ForeColor;
                else if (3000 <=  LogData.log_type &&  3999 >=  LogData.log_type)
                    fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 3].ForeColor = btnColors[2].ForeColor;
                else if (4000 <=  LogData.log_type &&  4999 >=  LogData.log_type)
                    fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 3].ForeColor = btnColors[3].ForeColor;
                else if (5000 <=  LogData.log_type &&  5999 >=  LogData.log_type)
                    fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 3].ForeColor = btnColors[4].ForeColor;
                else if (6000 <=  LogData.log_type &&  6999 >=  LogData.log_type)
                    fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 3].ForeColor = btnColors[5].ForeColor;
                else if (7000 <=  LogData.log_type &&  7999 >=  LogData.log_type)
                    fpSpread1s[LogData.line - 1].Sheets[0].Cells[rowCount[LogData.line - 1], 3].ForeColor = btnColors[6].ForeColor;
             
                rowCount[LogData.line - 1]++;

                System.Threading.Thread.Sleep(1);
                
            }               
            
        }
        private void workers2_DoWork(object sender, DoWorkEventArgs e)
        {
            
            int rowCount = 0;
            foreach (LogData LogData in LCData.logHistoryDatas.LogHistorys)
            {
                fpSpread1s[2].Sheets[0].SetText(rowCount, 0, Convert.ToString(rowCount + 1));
                fpSpread1s[2].Sheets[0].SetText(rowCount, 1, LogData.Time.Substring(0, 14).Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/"));
                fpSpread1s[2].Sheets[0].SetText(rowCount, 2, " " + LogData.Text);
                rowCount++;                
            }
            System.Threading.Thread.Sleep(1);
            
        }

        private void RunWorker1Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            cbSerial1.Enabled = true;
            cbSerial2.Enabled = true;
            tabControl1.Enabled = true;

            foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread1s)
            {
                fp.Enabled = true;
            }
            lbComment.Text = "전체 " + (LCData.logHistoryDatas.L1Count + LCData.logHistoryDatas.L2Count) + " 건이 검색되었습니다.";
        }

        private void RunWorker2Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            cbSerial1.Enabled = true;
            cbSerial2.Enabled = true;
            tabControl1.Enabled = true;
            foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread1s)
            {
                fp.Enabled = true;
            }
            lbComment.Text = "전체 " + (LCData.logHistoryDatas.L1Count + LCData.logHistoryDatas.L2Count) + " 건이 검색되었습니다.";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TimeSpan span = dateTimePicker2.Value - dateTimePicker1.Value;
            if (span.Days >= 3)
            {
                MessageBox.Show("3일 이상의 Log를 검색할 수 없습니다.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                KEY_WORD = "";
                NACK_WORD = "";
                SERIAL_WORD = "";

                FROM_DATE = dateTimePicker1.Value.ToString("yyyyMMddHH010100");
                TO_DATE = dateTimePicker2.Value.ToString("yyyyMMddHH595999");
                
                cbSerial1.Enabled = false;
                cbSerial2.Enabled = false;
                btnSearch.Enabled = false;
                tabControl1.Enabled = false;
                foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread1s)
                {
                    fp.Enabled = false;
                }
                lbComment.Text = "Log 검색 중 . . . .";

                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        {
                            switch (cbSerial1.SelectedIndex)
                            {
                                case 0:
                                    SERIAL_WORD = "";
                                    break;
                                case 1:
                                    NACK_WORD = "투입계획다운로드 NACK";
                                    break;
                                case 2:
                                    NACK_WORD = "CST INFOR NACK";
                                    break;
                                case 3:
                                    NACK_WORD = "JOB START NACK";
                                    break;
                                case 4:
                                    NACK_WORD = "JOB CANCEL NACK";
                                    break;
                                case 5:
                                    SERIAL_WORD = "1000";
                                    break;
                                case 6:
                                    SERIAL_WORD = "2000";
                                    break;
                                case 7:
                                    SERIAL_WORD = "3000";
                                    break;
                                case 8:
                                    SERIAL_WORD = "4000";
                                    break;
                                case 9:
                                    SERIAL_WORD = "5000";
                                    break;
                                case 10:
                                    SERIAL_WORD = "6000";
                                    break;
                                case 11:
                                    SERIAL_WORD = "7000";
                                    break;
                            }
                            
                            KEY_WORD += tbSearch.Text.Trim();

                            LogViewEvent(this, null);

                            fpSpread1s[0].ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                            fpSpread1s[1].ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);

                            fpSpread1s[0].Sheets[0].RowCount = LCData.logHistoryDatas.L1Count;
                            fpSpread1s[1].Sheets[0].RowCount = LCData.logHistoryDatas.L2Count;
                            
                            workers[0].RunWorkerAsync();
                        }
                        break;
                    case 1:
                        {
                            switch (cbSerial2.SelectedIndex)
                            {
                                case 0:
                                    KEY_WORD = "";
                                    break;
                                case 1:
                                    KEY_WORD = "START] Batch Process Reply Pass!!  ";
                                    break;
                                case 2:
                                    KEY_WORD = "END] Batch Process Reply Pass!!  ";
                                    break;
                                case 3:
                                    KEY_WORD = "Comp Start Reply Pass!! ";
                                    break;
                                case 4:
                                    KEY_WORD = "Car Valid Check Reply Pass!! ";
                                    break;
                                case 5:
                                    KEY_WORD = "Car Valid Check Reply Fail ";
                                    break;
                                case 6:
                                    KEY_WORD = "Cassette Process Start!! ";
                                    break;
                                case 7:
                                    KEY_WORD = "Cassette Process End!! ";
                                    break;
                                case 8:
                                    KEY_WORD = "Cassette Process Cancel!! ";
                                    break;
                                case 9:
                                    KEY_WORD = "Cassette Load Request!! ";
                                    break;
                                case 10:
                                    KEY_WORD = "Cassette Load Reply Pass!! ";
                                    break;
                                case 11:
                                    KEY_WORD = "Cassette Unload Request!! ";
                                    break;
                                case 12:
                                    KEY_WORD = "Cassette Unload Reply Pass!! ";
                                    break;
                                case 13:
                                    KEY_WORD = "Cassette  Load Complete!! ";
                                    break;
                                case 14:
                                    KEY_WORD = "Cassette Unload Complete!! ";
                                    break;
                            }                            

                            KEY_WORD += tbSearch.Text.Trim();

                            LogViewEvent(this, null);

                            fpSpread1s[2].ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                            fpSpread1s[2].Sheets[0].RowCount = LCData.logHistoryDatas.L1Count;
                            
                            workers[1].RunWorkerAsync();
                        }
                        break;
                }              
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ClassCore.LogColorData logColorData = new ClassCore.LogColorData();
            logColorData.Serial = 0;

            ColorDialog SelectColor = new ColorDialog();

            if (SelectColor.ShowDialog() == DialogResult.OK)
            {
                btn.ForeColor = SelectColor.Color;
                if (btn.Text == "통신")
                {
                    logColorData.Serial = 0;
                }
                if (btn.Text == "HOST COMMAND")
                {
                    logColorData.Serial = 1;
                }
                if (btn.Text == "OPERATOR COMMAND")
                {
                    logColorData.Serial = 2;
                }
                if (btn.Text == "CMD RELPY")
                {
                    logColorData.Serial = 3;
                }
                if (btn.Text == "PLC EVENT")
                {
                    logColorData.Serial = 4;
                }
                if (btn.Text == "PC COMMAND")
                {
                    logColorData.Serial = 5;
                }
                if (btn.Text == "PC EVENT")
                {
                    logColorData.Serial = 6;
                }
                logColorData.ColorA = btn.ForeColor.A;
                logColorData.ColorR = btn.ForeColor.R;
                logColorData.ColorG = btn.ForeColor.G;
                logColorData.ColorB = btn.ForeColor.B;
                LogColorDataChangeSetEvent(logColorData);
            }
        }      
        private void btnClose_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 6; i++)
            //{
            //    LogColorData ColorData = LCData.FindLogColor(i);
            //    if (ColorData != null)
            //    {
            //        ColorData.ColorA = btnColors[i].ForeColor.A;
            //        ColorData.ColorR = btnColors[i].ForeColor.R;
            //        ColorData.ColorG = btnColors[i].ForeColor.G;
            //        ColorData.ColorB = btnColors[i].ForeColor.B;
            //    }
            //}
            this.Hide();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        cbSerial1.Enabled = true;
                        cbSerial1.Visible = true;
                        cbSerial2.Enabled = false;
                        cbSerial2.Visible = false;
                        break;
                    }
                case 1:
                    {
                        cbSerial1.Enabled = false;
                        cbSerial1.Visible = false;
                        cbSerial2.Enabled = true;
                        cbSerial2.Visible = true;
                        break;
                    }
            }
            SELECT_PAGE = tabControl1.SelectedIndex;
        }
        private void SpreadSelect_Click(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int nRow = e.Row;
            int nCol = e.Column;
            int nRowCount = 0;

            int nNewRow = 0;
            string strSerial = "";

            if (btnSearch.Enabled == true)
            {

                if (e.RowHeader != true && e.ColumnHeader != true)
                {
                    if (nRow >= 0 && nCol == 2)
                    {
                        FarPoint.Win.Spread.FpSpread fpSpread1 = sender as FarPoint.Win.Spread.FpSpread;
                        fpSpread1.ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                        nRowCount = fpSpread1.Sheets[0].RowCount;
                        strSerial = fpSpread1.Sheets[0].Cells[nRow, nCol].Text;

                        for (int i = 0; i < nRowCount; i++)
                        {
                            if (strSerial == fpSpread1.Sheets[0].Cells[i, 2].Text)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    if (j == 0)
                                    {
                                        fpSpread1.Sheets[0].Cells[nNewRow, j].Text = Convert.ToString(nNewRow + 1);
                                    }
                                    else
                                    {
                                        fpSpread1.Sheets[0].Cells[nNewRow, j].Text = fpSpread1.Sheets[0].Cells[i, j].Text;
                                        fpSpread1.Sheets[0].Cells[nNewRow, j].ForeColor = fpSpread1.Sheets[0].Cells[i, j].ForeColor;
                                    }
                                    
                                }
                                nNewRow++;
                            }
                        }
                        fpSpread1.Sheets[0].RowCount = nNewRow;
                    }
                }
            }
        }        
    }
}