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
    public partial class WIPQTYSetForm : Form
    {
        public WIPQTYSetForm()
        {
            InitializeComponent();
        }

        private void WIPQTYSetForm_Load(object sender, EventArgs e)
        {
            InitControl();
            UpdateDisplay();
        }

        public void InitControl()
        {
            //ActiveSkin
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread1);

            //Split 설정
            fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            //TrackPolicy
            fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BackColor
            fpSpread1_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

            //BlockOption
            fpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            //ReadOnly
            //fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread1_Sheet1.Columns.Default.Resizable = false;
            fpSpread1_Sheet1.Rows.Default.Resizable = false;

            //HeaderCount
            fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
            fpSpread1_Sheet1.ColumnHeader.RowCount = 1;

             //BodyCount
            fpSpread1_Sheet1.RowCount = 2;
            fpSpread1_Sheet1.ColumnCount = 2;

            //Font
            fpSpread1.Font = new Font("Verdana", 12.0f);
            for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 12.0f, FontStyle.Bold);
            for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 12.0f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            fpSpread1_Sheet1.Columns[0].Width = 140.0f;
            fpSpread1_Sheet1.Columns[1].Width = 140.0f;
          
            fpSpread1_Sheet1.Rows[0].Height = 30.0f;
            fpSpread1_Sheet1.Rows[1].Height = 30.0f;

            //HeaderText
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "라인";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "한계재공";

            fpSpread1_Sheet1.Cells[0, 0].Text = "Line 1";
            fpSpread1_Sheet1.Cells[1, 0].Text = "Line 2";

            //Lock
            fpSpread1_Sheet1.Columns[0].Locked = true;
            fpSpread1_Sheet1.Columns[0].BackColor = Color.WhiteSmoke;            
        }
        public void UpdateDisplay()
        {
            foreach (WIPQTYData Qty in LCData.WIPQTYs)
            {
                if (Qty.line == 1)
                    fpSpread1_Sheet1.SetText(0, 1, Qty.WipQty.ToString());
                if (Qty.line == 2)
                    fpSpread1_Sheet1.SetText(1, 1, Qty.WipQty.ToString());
            }
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (LCData.OnlinePLCState != eEIPCMD.ONLINE)
            {
                MessageBox.Show("현재 PLC와 연결되어 있지 않습니다.\r\n 연결후 입력하여 주십시요", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!LCData.CheckNumber(fpSpread1_Sheet1.GetText(0, 1)))
            {
                MessageBox.Show("1라인 한계재공 설정값이 유효하지 않습니다.\r\n 재 입력하여 주십시요", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!LCData.CheckNumber(fpSpread1_Sheet1.GetText(1, 1)))
            {
                MessageBox.Show("2라인 한계재공 설정값이 유효하지 않습니다.\r\n 재 입력하여 주십시요", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (WIPQTYData Qty in LCData.WIPQTYs)
                {
                    if (Qty.line == 1)
                        Qty.WipQty = int.Parse(fpSpread1_Sheet1.GetText(0, 1).Trim());

                    if (Qty.line == 2)
                        Qty.WipQty = int.Parse(fpSpread1_Sheet1.GetText(1, 1).Trim());
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }       
    }
}