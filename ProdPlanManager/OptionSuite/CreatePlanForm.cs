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
    public partial class CreatePlanForm : Form
    {
        private eLINE _line;
        private BatchObject CreateBatch = null;

      //  public delegate BatchObject HistoryBatchEventHandler(eLINE line);
      //  public event HistoryBatchEventHandler HistoryBatchEvent;

        public CreatePlanForm(eLINE LineNo)
        {
            InitializeComponent();
            _line = LineNo;
        }        

        public BatchObject BatchInfo
        {
            get { return CreateBatch; }
            set
            {
                if (CreateBatch != null)
                     CreateBatch = null;
                CreateBatch = value;                
            }
        }
       
        public void InitControl()
        {
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread1);

            //Split 설정
            fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //TrackPolicy
            fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BlockOption
            fpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            //ReadOnly
            //fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread1_Sheet1.Columns.Default.Resizable = false;
            fpSpread1_Sheet1.Rows.Default.Resizable = false;

            //HeaderCount
            fpSpread1_Sheet1.RowHeader.ColumnCount = 1;
            fpSpread1_Sheet1.ColumnHeader.RowCount = 0;

            //BodyCount         
            fpSpread1_Sheet1.RowCount = 13;
            fpSpread1_Sheet1.ColumnCount = 2;

            //Header width
            fpSpread1_Sheet1.RowHeader.Columns[0].Width = 120.0f;

            //width
            fpSpread1_Sheet1.Columns[0].Width = 140.0f;
            fpSpread1_Sheet1.Columns[1].Width = 90.0f;

            //Font
            fpSpread1.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
            {
                fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
                fpSpread1_Sheet1.RowHeader.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            }

            //Alignment
            for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            FarPoint.Win.Spread.CellType.TextCellType textType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            textType1.MaxLength = 2;

            FarPoint.Win.Spread.CellType.TextCellType textType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            textType3.MaxLength = 12;

            FarPoint.Win.Spread.CellType.TextCellType textType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            textType4.MaxLength = 16;

            FarPoint.Win.Spread.CellType.TextCellType textType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            textType5.MaxLength = 20;

            FarPoint.Win.Spread.CellType.TextCellType textType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            textType6.MaxLength = 26;

            fpSpread1_Sheet1.Cells[1, 0].CellType = textType1;
            fpSpread1_Sheet1.Cells[2, 0].CellType = textType1;
            fpSpread1_Sheet1.Cells[8, 0].CellType = textType1;//숫자타입            
            fpSpread1_Sheet1.Cells[10, 0].CellType = textType1;//숫자타입
            fpSpread1_Sheet1.Cells[12, 0].CellType = textType1;//숫자타입
            //Length = 12;
            fpSpread1_Sheet1.Cells[5, 0].CellType = textType3;
            fpSpread1_Sheet1.Cells[6, 0].CellType = textType3;
            fpSpread1_Sheet1.Cells[11, 0].CellType = textType3;
            //Length = 16;
            fpSpread1_Sheet1.Cells[7, 0].CellType = textType4;
            //Length = 20;
            fpSpread1_Sheet1.Cells[3, 0].CellType = textType5;
            fpSpread1_Sheet1.Cells[4, 0].CellType = textType5;
            fpSpread1_Sheet1.Cells[5, 0].CellType = textType5;
            //Length = 50;
            fpSpread1_Sheet1.Cells[9, 0].CellType = textType6; 
      
            fpSpread1_Sheet1.RowHeader.Cells[0, 0].Text = "투입계획";
            fpSpread1_Sheet1.RowHeader.Cells[1, 0].Text = "PROD_KIND";
            fpSpread1_Sheet1.RowHeader.Cells[2, 0].Text = "PROD_TYPE";
            fpSpread1_Sheet1.RowHeader.Cells[3, 0].Text = "PROCESSID";
            fpSpread1_Sheet1.RowHeader.Cells[4, 0].Text = "PRODUCTID";
            fpSpread1_Sheet1.RowHeader.Cells[5, 0].Text = "STEPID";
            fpSpread1_Sheet1.RowHeader.Cells[6, 0].Text = "PPID";
            fpSpread1_Sheet1.RowHeader.Cells[7, 0].Text = "BATCHID";
            fpSpread1_Sheet1.RowHeader.Cells[8, 0].Text = "SIZE";
            fpSpread1_Sheet1.RowHeader.Cells[9, 0].Text = "P_MAKER";
            fpSpread1_Sheet1.RowHeader.Cells[10, 0].Text = "THICKNESS";
            fpSpread1_Sheet1.RowHeader.Cells[11, 0].Text = "F_PANELID";
            fpSpread1_Sheet1.RowHeader.Cells[12, 0].Text = "COMP_SIZE";

            fpSpread1_Sheet1.Cells[0, 0].Text = "Order1";
            fpSpread1_Sheet1.Cells[1, 1].Text = "문자 2Byte";
            fpSpread1_Sheet1.Cells[2, 1].Text = "문자 2Byte";
            fpSpread1_Sheet1.Cells[3, 1].Text = "문자 20Byte";
            fpSpread1_Sheet1.Cells[4, 1].Text = "문자 20Byte";
            fpSpread1_Sheet1.Cells[5, 1].Text = "문자 20Byte";
            fpSpread1_Sheet1.Cells[6, 1].Text = "문자 12Byte";
            fpSpread1_Sheet1.Cells[7, 1].Text = "문자 16Byte";
            fpSpread1_Sheet1.Cells[8, 1].Text = "숫자 Type";
            fpSpread1_Sheet1.Cells[9, 1].Text = "문자 50Byte";
            fpSpread1_Sheet1.Cells[10, 1].Text = "숫자 Type";
            fpSpread1_Sheet1.Cells[11, 1].Text = "문자 12Byte";
            fpSpread1_Sheet1.Cells[12, 1].Text = "숫자 Type";


            fpSpread1_Sheet1.Cells[0,0].Locked = true;
            fpSpread1_Sheet1.Cells[0,0].BackColor = Color.Yellow;

            fpSpread1_Sheet1.Columns[1].Locked = true;
            fpSpread1_Sheet1.Columns[1].BackColor = Color.WhiteSmoke;

            fpSpread1_Sheet1.Cells[0, 0].ColumnSpan = 2;
        }
        private void CreatePlanForm_Load(object sender, EventArgs e)
        {
            InitControl();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            BatchManager BatchMng = LCData.FindBatch(_line);
            if (BatchMng != null && BatchMng.BatchDatas.Count > 0)
            {
                fpSpread1_Sheet1.SetText(0, 0, "Order" + (BatchMng.BatchDatas.Count + 1).ToString());
                fpSpread1_Sheet1.SetText(1, 0, BatchMng.BatchDatas[0].PROD_KIND);// || //PROD_KIND
                fpSpread1_Sheet1.SetText(2, 0, BatchMng.BatchDatas[0].PROD_TYPE);// || //PROD_TYPE 
                fpSpread1_Sheet1.SetText(3, 0, BatchMng.BatchDatas[0].PROCESSID);// || //PROCESSID
                fpSpread1_Sheet1.SetText(4, 0, BatchMng.BatchDatas[0].PRODUCTID);// || //PRODUCTID
                fpSpread1_Sheet1.SetText(5, 0, BatchMng.BatchDatas[0].STEPID);// || //STEPID 
                fpSpread1_Sheet1.SetText(6, 0, BatchMng.BatchDatas[0].PPID);// || //PPID 
                fpSpread1_Sheet1.SetText(7, 0, BatchMng.BatchDatas[0].BATCHID);// || //BATCHID 
                fpSpread1_Sheet1.SetText(8, 0, BatchMng.BatchDatas[0].BATCH_SIZE.ToString());// || //BATCH_SIZE 
                fpSpread1_Sheet1.SetText(9, 0, BatchMng.BatchDatas[0].P_MAKER);// || //P_MAKER 
                fpSpread1_Sheet1.SetText(10, 0, BatchMng.BatchDatas[0].P_THICKNESS.ToString());// || //P_THICKNESS 
                fpSpread1_Sheet1.SetText(11, 0, BatchMng.BatchDatas[0].F_PANELID);//F_PANELID 
                fpSpread1_Sheet1.SetText(12, 0, BatchMng.BatchDatas[0].C_QTY.ToString());//F_PANELID
            }
            else
            {              
                BatchObject BatchObj = LCData.LoadBatch(_line);
                if (BatchObj != null)
                {
                    fpSpread1_Sheet1.SetText(0, 0, "Order" + BatchObj.ORDER_NO.ToString());
                    fpSpread1_Sheet1.SetText(1, 0, BatchObj.PROD_KIND);// || //PROD_KIND
                    fpSpread1_Sheet1.SetText(2, 0, BatchObj.PROD_TYPE);// || //PROD_TYPE 
                    fpSpread1_Sheet1.SetText(3, 0, BatchObj.PROCESSID);// || //PROCESSID
                    fpSpread1_Sheet1.SetText(4, 0, BatchObj.PRODUCTID);// || //PRODUCTID
                    fpSpread1_Sheet1.SetText(5, 0, BatchObj.STEPID);// || //STEPID 
                    fpSpread1_Sheet1.SetText(6, 0, BatchObj.PPID);// || //PPID 
                    fpSpread1_Sheet1.SetText(7, 0, BatchObj.BATCHID);// || //BATCHID 
                    fpSpread1_Sheet1.SetText(8, 0, BatchObj.BATCH_SIZE.ToString());// || //BATCH_SIZE 
                    fpSpread1_Sheet1.SetText(9, 0, BatchObj.P_MAKER);// || //P_MAKER 
                    fpSpread1_Sheet1.SetText(10, 0, BatchObj.P_THICKNESS.ToString());// || //P_THICKNESS 
                    fpSpread1_Sheet1.SetText(11, 0, BatchObj.F_PANELID);//F_PANELID 
                    fpSpread1_Sheet1.SetText(12, 0, BatchObj.C_QTY.ToString());//F_PANELID
                }
            }            
        }

        private void CreatePlanForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void btnCrate_Click(object sender, EventArgs e)
        {
            ReConfirmForm reconfirmForm = new ReConfirmForm("선택된 계획을 생성하시겠습니까?");
            DialogResult rusult = reconfirmForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {     
                if (fpSpread1_Sheet1.GetText(1, 0) == "" || //PROD_KIND
                    fpSpread1_Sheet1.GetText(2, 0) == "" || //PROD_TYPE 
                    fpSpread1_Sheet1.GetText(3, 0) == "" || //PROCESSID
                    fpSpread1_Sheet1.GetText(4, 0) == "" || //PRODUCTID
                    fpSpread1_Sheet1.GetText(5, 0) == "" || //STEPID 
                    fpSpread1_Sheet1.GetText(6, 0) == "" || //PPID 
                    fpSpread1_Sheet1.GetText(7, 0) == "" || //BATCHID 
                    fpSpread1_Sheet1.GetText(8, 0) == "" || //BATCH_SIZE 
                    fpSpread1_Sheet1.GetText(9, 0) == "" || //P_MAKER 
                    fpSpread1_Sheet1.GetText(10, 0) == "" || //P_THICKNESS 
                    fpSpread1_Sheet1.GetText(11, 0) == "")   //F_PANELID 
                    MessageBox.Show("생산 정보중 누락된 값이 존재합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (fpSpread1_Sheet1.GetText(7, 0).Length < 6)
                    MessageBox.Show("BATCHID 길이가 최소 6글자 이상 입력하여 주십시요! ", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (fpSpread1_Sheet1.GetText(11, 0).Length < 8)
                    MessageBox.Show("F_PANELID 길이가 최소 8글자 이상 입력하여 주십시요! ", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!LCData.CheckNumber(fpSpread1_Sheet1.GetText(8, 0)))
                    MessageBox.Show("BATCH_SIZE 값이 유효하지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!LCData.CheckNumber(fpSpread1_Sheet1.GetText(10, 0)))
                    MessageBox.Show("P_THICKNESS 값이 유효하지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!LCData.CheckNumber(fpSpread1_Sheet1.GetText(12, 0)))
                    MessageBox.Show("COMP_SIZE 값이 유효하지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (fpSpread1_Sheet1.GetText(8, 0).Trim() == "0")
                    MessageBox.Show("BATCH_SIZE 값이 1이상의 값을 입력하셔야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else 
                {
                    CreateBatch = new BatchObject();
                    CreateBatch.ORDER_NO = int.Parse(fpSpread1_Sheet1.GetText(0, 0).Substring(5, 1).Trim());
                    CreateBatch.PROD_KIND = fpSpread1_Sheet1.GetText(1, 0).Trim();
                    CreateBatch.PROD_TYPE = fpSpread1_Sheet1.GetText(2, 0).Trim();
                    CreateBatch.PROCESSID = fpSpread1_Sheet1.GetText(3, 0).Trim();
                    CreateBatch.PRODUCTID = fpSpread1_Sheet1.GetText(4, 0).Trim();
                    CreateBatch.STEPID = fpSpread1_Sheet1.GetText(5, 0).Trim();
                    CreateBatch.PPID = fpSpread1_Sheet1.GetText(6, 0).Trim();
                    CreateBatch.BATCHID = fpSpread1_Sheet1.GetText(7, 0).Trim();
                    CreateBatch.BATCH_SIZE = int.Parse(fpSpread1_Sheet1.GetText(8, 0).Trim());
                    CreateBatch.P_MAKER = fpSpread1_Sheet1.GetText(9, 0).Trim();
                    CreateBatch.P_THICKNESS = int.Parse(fpSpread1_Sheet1.GetText(10, 0).Trim());
                    CreateBatch.F_PANELID = fpSpread1_Sheet1.GetText(11, 0).Trim();
                    CreateBatch.C_QTY = int.Parse(fpSpread1_Sheet1.GetText(12, 0).Trim());
                    CreateBatch.END_PANELID = LCData.GetCreatePanelID(CreateBatch.BATCH_SIZE - 1, CreateBatch.BATCHID, CreateBatch.F_PANELID);

                    for (int j = 0; j < 10; j++)
                    {
                        FlowGroupData FlowGroup = new FlowGroupData();
                        FlowGroup.FlowList = FlowGroup.BoolList;
                        CreateBatch.FlowGroups.Add(FlowGroup);
                    }

                    BatchInfo = CreateBatch;
                   
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