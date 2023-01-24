using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClassCore;

namespace ProdPlanManager
{
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();
        }
        public void InitControl()
        {
            //ActiveSkin
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

            //BackColor
            fpSpread1_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

            //BlockOption
            fpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;

            //ReadOnly
            fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread1_Sheet1.Columns.Default.Resizable = false;
            fpSpread1_Sheet1.Rows.Default.Resizable = false;

            //HeaderCount
            fpSpread1_Sheet1.RowHeader.ColumnCount = 1;
            fpSpread1_Sheet1.ColumnHeader.RowCount = 1;

            //Cursor
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);

            //BodyCount
            fpSpread1_Sheet1.RowCount = 1;
            fpSpread1_Sheet1.ColumnCount = 8;

            //Font4
            fpSpread1.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            ////Width
            fpSpread1_Sheet1.RowHeader.Columns[0].Width = 184.0f;
            fpSpread1_Sheet1.Columns[0].Width = 135.0f;
            fpSpread1_Sheet1.Columns[1].Width = 135.0f;
            fpSpread1_Sheet1.Columns[2].Width = 135.0f;
            fpSpread1_Sheet1.Columns[3].Width = 135.0f;
            fpSpread1_Sheet1.Columns[4].Width = 135.0f;
            fpSpread1_Sheet1.Columns[5].Width = 135.0f;
            fpSpread1_Sheet1.Columns[6].Width = 135.0f;
            fpSpread1_Sheet1.Columns[7].Width = 135.0f;

            //HeaderText

            fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "현재공(로더)";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "현재공(CV)";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "한계재공";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "재공상태";

            fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = "현재공(로더)";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 5].Text = "현재공(CV)";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 6].Text = "한계재공";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 7].Text = "재공상태";

            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
            for (int i = 0; i < 8; i++)
            {
                fpSpread1_Sheet1.Columns[i].CellType = textType;
            }

            // Border
            FarPoint.Win.LineBorder border = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 3, false, false, true, false);
            fpSpread1_Sheet1.ColumnHeader.Columns[3].Border = border;
            fpSpread1_Sheet1.Columns[3].Border = border;
            fpSpread1_Sheet1.RowHeader.Cells[0, 0].Text = "투입제어";

            UpdateDisplay();

        }
        public void UpdateDisplay()
        {
            foreach (WIPQTYData Info in LCData.WIPQTYs)
            {
                switch(Info.line)
                {
                    case 1:
                        {
                            fpSpread1_Sheet1.SetText(0, 0, Info.SET_PLC1QTY.ToString());
                            fpSpread1_Sheet1.SetText(0, 1, Info.SET_PLC2QTY.ToString());
                            fpSpread1_Sheet1.SetText(0, 2, Info.WipQty.ToString());
                            fpSpread1_Sheet1.SetText(0, 3, Info.BOOL_WIPQTY ? "정상" : "과다");
                            fpSpread1_Sheet1.Cells[0, 3].BackColor = Info.BOOL_WIPQTY ? Color.White : Color.Red;
                        }
                        break;
                    case 2:
                        {
                            fpSpread1_Sheet1.SetText(0, 4, Info.SET_PLC1QTY.ToString());
                            fpSpread1_Sheet1.SetText(0, 5, Info.SET_PLC2QTY.ToString());
                            fpSpread1_Sheet1.SetText(0, 6, Info.WipQty.ToString());
                            fpSpread1_Sheet1.SetText(0, 7, Info.BOOL_WIPQTY ? "정상" : "과다");
                            fpSpread1_Sheet1.Cells[0, 7].BackColor = Info.BOOL_WIPQTY ? Color.White : Color.Red;
                        }
                        break;
                } 
            }
        }
    }
}
