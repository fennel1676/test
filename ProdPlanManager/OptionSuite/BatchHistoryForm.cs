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
    public partial class BatchHistoryForm : Form
    {
        public event EventHandler DisplayBatchHistoryEvent;

        int vSize = 0;
        private string _fromDate = "";
        private string _toDate = "";
        private string _keyWord = "";
        private int _page = 0;

        private FarPoint.Win.Spread.FpSpread[] fpSpread1s;
        private FarPoint.Win.Spread.FpSpread[] fpSpread2s;
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
        public BatchHistoryForm()
        {
            InitializeComponent();
            InitControl();        
        }
        public void InitControl()
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);

            fpSpread1s = new FarPoint.Win.Spread.FpSpread[2];
            fpSpread2s = new FarPoint.Win.Spread.FpSpread[2];
     
            for (int i = 0; i < 2; i++)
            {
                //----------- Batch History--------------- //
                this.fpSpread1s[i] = new FarPoint.Win.Spread.FpSpread();
                FarPoint.Win.Spread.SheetView fpSpread1s_Sheet1 = new FarPoint.Win.Spread.SheetView();

                this.fpSpread1s[i].Name = "fsSpread1P" + (i + 1).ToString();
                this.fpSpread1s[i].Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] { fpSpread1s_Sheet1 });

                this.fpSpread1s[i].Location = new System.Drawing.Point(3, 6 + vSize);
                this.fpSpread1s[i].Size = new System.Drawing.Size(970, 211);

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
                this.fpSpread1s[i].HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
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

                //BodyCount
                this.fpSpread1s[i].Sheets[0].RowCount = 0;
                this.fpSpread1s[i].Sheets[0].ColumnCount = 25;

                this.fpSpread1s[i].Font = new Font("Verdana", 8.25f);
                for (int j = 0; j < this.fpSpread1s[i].Sheets[0].RowHeader.ColumnCount; j++)
                    this.fpSpread1s[i].Sheets[0].RowHeader.Columns[j].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                for (int j = 0; j < this.fpSpread1s[i].Sheets[0].ColumnHeader.RowCount; j++)
                    this.fpSpread1s[i].Sheets[0].ColumnHeader.Rows[j].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

                //Alignment
                for (int j = 0; j < this.fpSpread1s[i].Sheets[0].ColumnCount; j++)
                {
                    this.fpSpread1s[i].Sheets[0].Columns[j].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.fpSpread1s[i].Sheets[0].Columns[j].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }

                //Width
                for (int j = 0; j < this.fpSpread1s[i].Sheets[0].ColumnCount; j++)
                {
                    if (j == 0)
                    {
                        this.fpSpread1s[i].Sheets[0].Columns[j].Width = 50.0f;
                    }
                    else
                    {
                        this.fpSpread1s[i].Sheets[0].Columns[j].Width = 140.0f;
                    }                    
                }

                FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
                for (int j = 0; j < this.fpSpread1s[i].Sheets[0].ColumnCount; j++)
                {
                    this.fpSpread1s[i].Sheets[0].Columns[j].CellType = textType;
                }

                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 0].Text = "NO.";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 1].Text = "Update_Time";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 2].Text = "Batch_State";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 3].Text = "F_PanelID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 4].Text = "End_GlassID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 5].Text = "C_PanelID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 6].Text = "Batch_Size";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 7].Text = "O_QTY";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 8].Text = "ProductID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 9].Text = "BatchID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 10].Text = "P_Maker";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 11].Text = "PPID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 12].Text = "Prod_Type";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 13].Text = "Start_Time";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 14].Text = "ProcessID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 15].Text = "Prod_Kind";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 16].Text = "FlowID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 17].Text = "P_Thickness";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 18].Text = "Input_Line";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 19].Text = "Valid_Flag";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 20].Text = "StepID";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 21].Text = "C_QTY";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 22].Text = "R_QTY";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 23].Text = "N_QTY";
                this.fpSpread1s[i].Sheets[0].ColumnHeader.Cells[0, 24].Text = "FlowGroupList";

                //----------- Glass History--------------- //
                this.fpSpread2s[i] = new FarPoint.Win.Spread.FpSpread();
                FarPoint.Win.Spread.SheetView fpSpread2s_Sheet1 = new FarPoint.Win.Spread.SheetView();

                this.fpSpread2s[i].Name = "fsSpread2P" + (i + 1).ToString();
                this.fpSpread2s[i].Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] { fpSpread2s_Sheet1 });

                this.fpSpread2s[i].Location = new System.Drawing.Point(3, 6 + vSize);
                this.fpSpread2s[i].Size = new System.Drawing.Size(970, 211);
                this.fpSpread2s[i].Sheets[0].Reset();
                this.fpSpread2s[i].Sheets[0].SheetName = "Sheet1";

                // OperationMode
                fpSpread2s_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;

                //ActiveSkin
                FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(this.fpSpread2s[i]);

                //Split 설정
                this.fpSpread2s[i].ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
                this.fpSpread2s[i].RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

                //스크롤바 설정
                this.fpSpread2s[i].HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                this.fpSpread2s[i].VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

                //TrackPolicy
                this.fpSpread2s[i].ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

                //TextTipPolicy
                this.fpSpread2s[i].TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

                //커서 설정
                this.fpSpread2s[i].SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
                this.fpSpread2s[i].SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

                //BlockOption
                this.fpSpread2s[i].SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Cells;

                //Sizeble
                this.fpSpread2s[i].Sheets[0].Rows.Default.Resizable = false;

                //HeaderCount
                this.fpSpread2s[i].Sheets[0].RowHeader.ColumnCount = 0;
                this.fpSpread2s[i].Sheets[0].ColumnHeader.RowCount = 1;

                //BodyCount
                this.fpSpread2s[i].Sheets[0].RowCount = 0;
                this.fpSpread2s[i].Sheets[0].ColumnCount = 6;

                this.fpSpread2s[i].Font = new Font("Verdana", 8.25f);
                for (int j = 0; j < this.fpSpread2s[i].Sheets[0].RowHeader.ColumnCount; j++)
                    this.fpSpread2s[i].Sheets[0].RowHeader.Columns[j].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                for (int j = 0; j < this.fpSpread2s[i].Sheets[0].ColumnHeader.RowCount; j++)
                    this.fpSpread2s[i].Sheets[0].ColumnHeader.Rows[j].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

                //Alignment
                for (int j = 0; j < this.fpSpread2s[i].Sheets[0].ColumnCount; j++)
                {
                    this.fpSpread2s[i].Sheets[0].Columns[j].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.fpSpread2s[i].Sheets[0].Columns[j].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }

                //Width
                for (int j = 0; j < this.fpSpread2s[i].Sheets[0].ColumnCount; j++)
                {
                    if (j == 0)
                    {
                        this.fpSpread2s[i].Sheets[0].Columns[j].Width = 50.0f;
                    }
                    else
                    {
                        this.fpSpread2s[i].Sheets[0].Columns[j].Width = 140.0f;
                    }                    
                }

                //cell type
                for (int j = 0; j < this.fpSpread2s[i].Sheets[0].ColumnCount; j++)
                {
                    this.fpSpread2s[i].Sheets[0].Columns[j].CellType = textType;
                }

                this.fpSpread2s[i].Sheets[0].ColumnHeader.Cells[0, 0].Text = "NO.";
                this.fpSpread2s[i].Sheets[0].ColumnHeader.Cells[0, 1].Text = "발행 Time";
                this.fpSpread2s[i].Sheets[0].ColumnHeader.Cells[0, 2].Text = "BATCH ID";
                this.fpSpread2s[i].Sheets[0].ColumnHeader.Cells[0, 3].Text = "FPANEL ID";
                this.fpSpread2s[i].Sheets[0].ColumnHeader.Cells[0, 4].Text = "GLASS ID";
                this.fpSpread2s[i].Sheets[0].ColumnHeader.Cells[0, 5].Text = "UNIQUE ID";

               this.tabControl1.TabPages[0].Controls.Add(this.fpSpread1s[i]);
               this.tabControl1.TabPages[1].Controls.Add(this.fpSpread2s[i]);

                vSize += 217;

                this.tabControl1.TabPages[0].Text = string.Format("{0, 50}", "투입 계획 로그").PadRight(100, ' ');
                this.tabControl1.TabPages[1].Text = string.Format("{0, 50}", "Glass 발행 로그").PadRight(100, ' ');
            }

            this.Controls.Add(this.tabControl1);

            workers = new BackgroundWorker[2];
            this.workers[0] = new BackgroundWorker();
            this.workers[0].WorkerSupportsCancellation = true;
            this.workers[0].DoWork += new DoWorkEventHandler(workers1_DoWork);
            this.workers[0].RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorker1Completed);
            this.workers[0].WorkerReportsProgress = true;

            this.workers[1] = new BackgroundWorker();
            this.workers[1].WorkerSupportsCancellation = true;
            this.workers[1].DoWork += new DoWorkEventHandler(workers2_DoWork);
            this.workers[1].RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorker2Completed);
            this.workers[1].WorkerReportsProgress = true;

        }
        private void workers1_DoWork(object sender, DoWorkEventArgs e)
        {          
            int[] rowCount = new int[2];

            foreach (BatchLogData BatchLogData in LCData.batchHistoryDatas.BatchLogHistorys)
            {
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 0, Convert.ToString(rowCount[BatchLogData.line - 1]+1));
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 1, BatchLogData.Update_Time.Substring(0, 14).Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/"));
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 2, " " + BatchLogData.Batch_State);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 3, " " + BatchLogData.F_PanelID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 4, " " + BatchLogData.END_PANELID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 5, " " + BatchLogData.C_PanelID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 6, " " + BatchLogData.Batch_Size);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 7, " " + BatchLogData.O_QTY);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 8, " " + BatchLogData.ProductID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 9, " " + BatchLogData.BatchID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 10, " " + BatchLogData.P_Maker);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 11, " " + BatchLogData.PPID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 12, " " + BatchLogData.Prod_Type);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 13, " " + BatchLogData.StartTime);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 14, " " + BatchLogData.ProcessID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 15, " " + BatchLogData.Prod_Kind);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 16, " " + BatchLogData.FlowID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 17, " " + BatchLogData.P_Thickness);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 18, " " + BatchLogData.Input_Line);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 19, " " + BatchLogData.Valid_Flag);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 20, " " + BatchLogData.StepID);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 21, " " + BatchLogData.C_QTY);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 22, " " + BatchLogData.R_QTY);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 23, " " + BatchLogData.N_QTY);
                fpSpread1s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 24, " " + BatchLogData.FlowGroupList);

                rowCount[BatchLogData.line - 1]++;

                System.Threading.Thread.Sleep(10);
            }            
        }
        private void workers2_DoWork(object sender, DoWorkEventArgs e)
        {
            int[] rowCount = new int[2];

            foreach (BatchLogData BatchLogData in LCData.batchHistoryDatas.BatchLogHistorys)
            {
                fpSpread2s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 0, Convert.ToString(rowCount[BatchLogData.line - 1] + 1));
                fpSpread2s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 1, BatchLogData.Update_Time.Substring(0, 14).Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/"));
                fpSpread2s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 2, " " + BatchLogData.BatchID);
                fpSpread2s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 3, " " + BatchLogData.F_PanelID);
                fpSpread2s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 4, " " + BatchLogData.C_PanelID);
                fpSpread2s[BatchLogData.line - 1].Sheets[0].SetText(rowCount[BatchLogData.line - 1], 5, " " + BatchLogData.UniqueID);

                rowCount[BatchLogData.line - 1]++;

                System.Threading.Thread.Sleep(10);
            }
        }

        private void RunWorker1Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread1s)
            {
                fp.Enabled = true;
            }
            foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread2s)
            {
                fp.Enabled = true;
            }
            lbComment.Text = "전체 " + (LCData.batchHistoryDatas.L1Count + LCData.batchHistoryDatas.L2Count) + " 건이 검색되었습니다.";


        }

        private void RunWorker2Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            
            foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread2s)
            {
                fp.Enabled = true;
            }
            foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread1s)
            {
                fp.Enabled = true;
            }
            lbComment.Text = "전체 " + (LCData.batchHistoryDatas.L1Count + LCData.batchHistoryDatas.L2Count) + " 건이 검색되었습니다.";

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

                FROM_DATE = dateTimePicker1.Value.ToString("yyyyMMddHH010100");
                TO_DATE = dateTimePicker2.Value.ToString("yyyyMMddHH595900");
                KEY_WORD = tbSearch.Text.Trim();

                DisplayBatchHistoryEvent(this, EventArgs.Empty);

                btnSearch.Enabled = false;
                foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread1s)
                {
                    fp.Enabled = false;
                }
                foreach (FarPoint.Win.Spread.FpSpread fp in fpSpread2s)
                {
                    fp.Enabled = false;
                }
                lbComment.Text = "Log 검색 중 . . . .";

                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        {
                            fpSpread1s[0].ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                            fpSpread1s[1].ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);

                            fpSpread1s[0].Sheets[0].RowCount = LCData.batchHistoryDatas.L1Count;
                            fpSpread1s[1].Sheets[0].RowCount = LCData.batchHistoryDatas.L2Count;                                                       

                            workers[0].RunWorkerAsync();
                        }
                        break;
                    case 1:
                        {
                            fpSpread2s[0].ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                            fpSpread2s[1].ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);

                            fpSpread2s[0].Sheets[0].RowCount = LCData.batchHistoryDatas.L1Count;
                            fpSpread2s[1].Sheets[0].RowCount = LCData.batchHistoryDatas.L2Count;                            
                            
                            workers[1].RunWorkerAsync();
                        }
                        break;
                }                               
            }
        }
		private void btnClose_Click(object sender, EventArgs e)
		{
            this.Hide();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SELECT_PAGE = tabControl1.SelectedIndex;
        }      
    }
}