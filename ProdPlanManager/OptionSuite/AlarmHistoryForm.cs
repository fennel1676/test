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
    public partial class AlarmHistoryForm : Form
    {
        public event EventHandler DisplayAlarmHistoryEvent;
        public AlarmHistoryForm()
        {
            InitializeComponent();
            InitControl();
        }

        private string _fromDate = "";
        private string _toDate = "";
        private string _keyWord = "";
        private int _page = 0;
        private short _alarmOn = 0;

        private System.Windows.Forms.Panel pnView; 
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private BackgroundWorker worker;

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
        public short ALARM_ON
        {
            get { return _alarmOn; }
            set { _alarmOn = value; }
        }

        public void InitControl()
        {
            cbAlarmOn.Items.Add("전체");
            cbAlarmOn.Items.Add("ON");
            cbAlarmOn.Items.Add("OFF");
            cbAlarmOn.SelectedIndex = 0;

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);

            this.pnView = new System.Windows.Forms.Panel();
            this.pnView.Location = new System.Drawing.Point(13, 70);
            this.pnView.BorderStyle = BorderStyle.Fixed3D;
            this.pnView.Size = new System.Drawing.Size(984, 467);
            this.pnView.Visible = true;

            fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            FarPoint.Win.Spread.SheetView fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();

            this.fpSpread1.Name = "fsSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] { fpSpread1_Sheet1 });

            this.fpSpread1.Location = new System.Drawing.Point(14,15);
            this.fpSpread1.Size = new System.Drawing.Size(955, 441);

            this.fpSpread1.Sheets[0].Reset();
            this.fpSpread1.Sheets[0].SheetName = "Sheet1";

            //ActiveSkin
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(this.fpSpread1);

            //Split 설정
            this.fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            //TrackPolicy
            this.fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            this.fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            this.fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            this.fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BlockOption
            this.fpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Cells;
            //ReadOnly
            this.fpSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly; //| FarPoint.Win.Spread.OperationMode.RowMode;// | FarPoint.Win.Spread.OperationMode.Normal;
            //this.fpSpread1.Sheets[0].SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            this.fpSpread1.Sheets[0].Columns.Default.Resizable = false;
            this.fpSpread1.Sheets[0].Rows.Default.Resizable = false;

            //HeaderCount
            this.fpSpread1.Sheets[0].RowHeader.ColumnCount = 0;
            this.fpSpread1.Sheets[0].ColumnHeader.RowCount = 1;

            //BodyCount
            this.fpSpread1.Sheets[0].RowCount = 0;
            this.fpSpread1.Sheets[0].ColumnCount = 7;

            //Font
            this.fpSpread1.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < this.fpSpread1.Sheets[0].RowHeader.ColumnCount; i++)
                this.fpSpread1.Sheets[0].RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            for (int i = 0; i < this.fpSpread1.Sheets[0].ColumnHeader.RowCount; i++)
                this.fpSpread1.Sheets[0].ColumnHeader.Rows[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < this.fpSpread1.Sheets[0].ColumnCount; i++)
            {
                this.fpSpread1.Sheets[0].Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                this.fpSpread1.Sheets[0].Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            this.fpSpread1.Sheets[0].Columns[fpSpread1_Sheet1.ColumnCount - 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

            //Width
            this.fpSpread1.Sheets[0].Columns[0].Width = 50.0f;
            this.fpSpread1.Sheets[0].Columns[1].Width = 150.0f;
            this.fpSpread1.Sheets[0].Columns[2].Width = 60.0f;
            this.fpSpread1.Sheets[0].Columns[3].Width = 140.0f;
            this.fpSpread1.Sheets[0].Columns[4].Width = 60.0f;
            this.fpSpread1.Sheets[0].Columns[5].Width = 60.0f;
            this.fpSpread1.Sheets[0].Columns[6].Width = 460.0f;


            //HeaderText
            this.fpSpread1.Sheets[0].ColumnHeader.Cells[0, 0].Text = "NO.";
            this.fpSpread1.Sheets[0].ColumnHeader.Cells[0, 1].Text = "Time";
            this.fpSpread1.Sheets[0].ColumnHeader.Cells[0, 2].Text = "ON/OFF";
            this.fpSpread1.Sheets[0].ColumnHeader.Cells[0, 3].Text = "ModuleID";
            this.fpSpread1.Sheets[0].ColumnHeader.Cells[0, 4].Text = "UnitID";
            this.fpSpread1.Sheets[0].ColumnHeader.Cells[0, 5].Text = "AlarmID";
            this.fpSpread1.Sheets[0].ColumnHeader.Cells[0, 6].Text = "AlarmText";

            //CellType
            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();

            for (int i = 0; i < this.fpSpread1.Sheets[0].ColumnCount; i++)
            {
                this.fpSpread1.Sheets[0].Columns[i].CellType = textType;
            }         

            this.pnView.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.pnView);
    
            worker = new BackgroundWorker();
            this.worker = new BackgroundWorker();
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            this.worker.WorkerReportsProgress = true;
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
                TO_DATE = dateTimePicker2.Value.ToString("yyyyMMddHH595999");
                KEY_WORD = tbSearch.Text.Trim();
                ALARM_ON = cbAlarmOn.Text == "ON" ? (short)1 : cbAlarmOn.Text == "OFF" ? (short)0 : (short)2;
                DisplayAlarmHistoryEvent(this, EventArgs.Empty);

                btnSearch.Enabled = false;
                fpSpread1.Enabled = false;

                fpSpread1.ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);

                fpSpread1.Sheets[0].RowCount = LCData.alarmHistoryDatas.Count;
                lbComment.Text = "Log 검색 중 . . . .";
                worker.RunWorkerAsync();
            }
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {           
            int rowCount = 0;

            foreach (AlarmHistoryData AlarmData in LCData.alarmHistoryDatas)
            {
                fpSpread1.Sheets[0].SetText(rowCount, 0, Convert.ToString(rowCount + 1));
                fpSpread1.Sheets[0].SetText(rowCount, 1, AlarmData.Time.Substring(0, 14).Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/"));
                fpSpread1.Sheets[0].SetText(rowCount, 2, AlarmData.Alarm_On == 1 ? "ON" : "OFF");
                fpSpread1.Sheets[0].SetText(rowCount, 3, AlarmData.Moduleid);
                fpSpread1.Sheets[0].SetText(rowCount, 4, AlarmData.Unit_id);
                fpSpread1.Sheets[0].SetText(rowCount, 5, AlarmData.Alarm_id);
                fpSpread1.Sheets[0].SetText(rowCount, 6, AlarmData.Alarm_text);   

                rowCount++;

                System.Threading.Thread.Sleep(10);
            }
        }
        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            fpSpread1.Enabled = true;
            lbComment.Text = "전체 " + (LCData.alarmHistoryDatas.Count) + " 건이 검색되었습니다.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}