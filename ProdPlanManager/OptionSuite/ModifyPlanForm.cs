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
    public partial class ModifyPlanForm : Form
    {
        private eLINE _line = 0;
        private int _order = 0;

        public ModifyPlanForm(eLINE LineNo)
        {
            InitializeComponent();
            _line = LineNo;            
        }
        public int SelectOrder
        {
            get { return _order; }
            set { _order = value;}
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
            fpSpread1_Sheet1.ColumnCount = 1;

            //width
            fpSpread1_Sheet1.Columns[0].Width = 230.0f;

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
            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                fpSpread1_Sheet1.Cells[i, 0].CellType = textType1;
            }
            
            fpSpread1_Sheet1.RowHeader.Cells[0, 0].Text = "투입계획";
            fpSpread1_Sheet1.RowHeader.Cells[1, 0].Text = "PROD_KIND";
            fpSpread1_Sheet1.RowHeader.Cells[2, 0].Text = "PROD_TYPE";
            fpSpread1_Sheet1.RowHeader.Cells[3, 0].Text = "PROCESSID";
            fpSpread1_Sheet1.RowHeader.Cells[4, 0].Text = "PRODUCTID";
            fpSpread1_Sheet1.RowHeader.Cells[5, 0].Text = "STEPID";
            fpSpread1_Sheet1.RowHeader.Cells[6, 0].Text = "PPID";
            fpSpread1_Sheet1.RowHeader.Cells[7, 0].Text = "BATCHID";
            fpSpread1_Sheet1.RowHeader.Cells[8, 0].Text = "SIZE";
            fpSpread1_Sheet1.RowHeader.Cells[9, 0].Text = "P MAKER";
            fpSpread1_Sheet1.RowHeader.Cells[10, 0].Text = "THICKNESS";
            fpSpread1_Sheet1.RowHeader.Cells[11, 0].Text = "F_PANELID";
            fpSpread1_Sheet1.RowHeader.Cells[12, 0].Text = "COMP_SIZE";

            fpSpread1_Sheet1.Cells[0, 0].BackColor = Color.LightYellow;
            fpSpread1_Sheet1.Cells[8, 0].BackColor = Color.LightYellow;

            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                fpSpread1_Sheet1.Cells[i, 0].Locked = true;

            fpSpread1_Sheet1.Cells[8, 0].Locked = false;            
        }
        private void ModifyPlanForm_Load(object sender, EventArgs e)
        {
            InitControl();
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            BatchManager BatchMng = LCData.FindBatch(_line);
            if (BatchMng != null)
            {
                for (int i = 1; i < BatchMng.BatchDatas.Count + 1; i++)
                {
                    comboBox1.Items.Add(i.ToString());
                }
                comboBox1.SelectedIndex = 0;
            }
        }         
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;

            BatchManager BatchMng = LCData.FindBatch(_line);
            if (BatchMng != null)
            {
                SelectOrder = int.Parse(comboBox1.Text);
                fpSpread1_Sheet1.Cells[0, 0].Text = "Order" + BatchMng.BatchDatas[SelectOrder - 1].ORDER_NO;
                fpSpread1_Sheet1.Cells[1, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].PROD_KIND;
                fpSpread1_Sheet1.Cells[2, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].PROD_TYPE;
                fpSpread1_Sheet1.Cells[3, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].PROCESSID;
                fpSpread1_Sheet1.Cells[4, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].PRODUCTID;
                fpSpread1_Sheet1.Cells[5, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].STEPID;
                fpSpread1_Sheet1.Cells[6, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].PPID;
                fpSpread1_Sheet1.Cells[7, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].BATCHID;
                fpSpread1_Sheet1.Cells[8, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].BATCH_SIZE.ToString();
                fpSpread1_Sheet1.Cells[9, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].P_MAKER;
                fpSpread1_Sheet1.Cells[10, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].P_THICKNESS.ToString();
                fpSpread1_Sheet1.Cells[11, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].F_PANELID;
                fpSpread1_Sheet1.Cells[12, 0].Text = BatchMng.BatchDatas[SelectOrder - 1].C_QTY.ToString();
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            ReConfirmForm reconfirmForm = new ReConfirmForm("선택된 투입 계획을 변경하시겠습니까?");
            DialogResult rusult = reconfirmForm.ShowDialog();

            if (rusult == DialogResult.OK)
            {
               BatchManager BatchMng = LCData.FindBatch(_line);
               if (BatchMng != null)
               {
                   if (!LCData.CheckNumber(fpSpread1_Sheet1.GetText(8, 0)))
                   {
                       MessageBox.Show("BATCH_SIZE 값이 유효하지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   }
                   else if (BatchMng.BatchDatas[0].O_QTY == int.Parse(fpSpread1_Sheet1.GetText(8, 0)))
                   {
                       MessageBox.Show("BATCH_SIZE 투입된 수량과 같습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   }
                   else if (BatchMng.BatchDatas[0].O_QTY > int.Parse(fpSpread1_Sheet1.GetText(8, 0)))
                   {
                       MessageBox.Show("BATCH_SIZE 투입된 수량 보다 작습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   }
                   else
                   {
                       BatchMng.BatchDatas[0].BATCH_SIZE = int.Parse(fpSpread1_Sheet1.GetText(8, 0));
                       BatchMng.BatchDatas[0].END_PANELID = LCData.GetCreatePanelID(BatchMng.BatchDatas[0].BATCH_SIZE - 1, BatchMng.BatchDatas[0].BATCHID, BatchMng.BatchDatas[0].F_PANELID);

                       //LCData.SavePlanInfoINI(OldPlan.ModuleLine, OldPlan.ORDER_NO);
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