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
    public partial class PortSlotControl : UserControl
    {
        public PortSlotControl()
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
            fpSpread1_Sheet1.RowHeader.ColumnCount = 2;
            fpSpread1_Sheet1.ColumnHeader.RowCount = 0;

            //BodyCount
            fpSpread1_Sheet1.RowCount = 3;
            fpSpread1_Sheet1.ColumnCount = 40;


            //Font
            fpSpread1.Font = new Font("Verdana", 8.0f);
            for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.0f, FontStyle.Bold);
            for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 8.0f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            fpSpread1_Sheet1.RowHeader.Columns[0].Width = 20.0f;
            fpSpread1_Sheet1.RowHeader.Columns[1].Width = 164.0f;

            //span
            fpSpread1_Sheet1.Cells[0, 0].ColumnSpan = 10;
            fpSpread1_Sheet1.Cells[0, 10].ColumnSpan = 10;
            fpSpread1_Sheet1.Cells[0, 20].ColumnSpan = 10;
            fpSpread1_Sheet1.Cells[0, 30].ColumnSpan = 10;

            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();

            for (int i = 0; i < 40; i++)
            {
                fpSpread1_Sheet1.Columns[i].CellType = textType;
            }

            for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                fpSpread1_Sheet1.Columns[i].Width = 27.0f;
            }

            //Merge
            fpSpread1_Sheet1.RowHeader.Cells[0, 0].ColumnSpan = 3;
            fpSpread1_Sheet1.RowHeader.Cells[1, 0].RowSpan = 2;

            //HeaderText
            fpSpread1_Sheet1.RowHeader.Cells[0, 0].Text = "SLOT";
            fpSpread1_Sheet1.RowHeader.Cells[1, 1].Text = "HIGH";
            fpSpread1_Sheet1.RowHeader.Cells[1, 1].ForeColor = Color.White;
            fpSpread1_Sheet1.RowHeader.Cells[2, 1].Text = "LOW";
            fpSpread1_Sheet1.RowHeader.Cells[2, 1].ForeColor = Color.White;

            //
            fpSpread1_Sheet1.RowHeader.Cells[1, 1].BackColor = Color.Gray;
            fpSpread1_Sheet1.RowHeader.Cells[2, 1].BackColor = Color.Gray;

            for (int i = 0; i < 40; i += 10)
            {
                for (int j = 0; j < 10; j++)
                {
                    fpSpread1_Sheet1.SetText(1, (i + 9 - j), (j + 11).ToString());
                    fpSpread1_Sheet1.SetText(2, (i + 9 - j), (j + 1).ToString());
                }
            }


            //Border
            FarPoint.Win.LineBorder border = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 3, false, false, true, false);
            fpSpread1_Sheet1.Cells[0, 10].Border = border;
            fpSpread1_Sheet1.Cells[1, 19].Border = border;
            fpSpread1_Sheet1.Cells[2, 19].Border = border;

            for (int i = 0; i < 40; i++)
            {
                fpSpread1_Sheet1.Columns[i].Locked = true;
            }
        }

        public void UpdateDisplay(int Port_No, string CurStif)
        {
            int Index = Port_No - 1;

            Index *= 10;
            fpSpread1_Sheet1.Cells[0, Index].Text = CurStif;

            int Count = int.Parse(CurStif) > 20 ? 20 : int.Parse(CurStif);// 에러 코드 "30" 땜시..

            for (int i = 0; i < 20; i++)
            {
                if (Count > i && i < 10)
                    fpSpread1_Sheet1.Cells[1, (i + Index)].BackColor = Color.LawnGreen;
                else if (Count > i && i >= 10)
                    fpSpread1_Sheet1.Cells[2, (i + Index) - 10].BackColor = Color.LawnGreen;
                else if (Count <= i && i < 10)
                    fpSpread1_Sheet1.Cells[1, (i + Index)].BackColor = Color.White;
                else if (Count <= i && i >= 10)
                    fpSpread1_Sheet1.Cells[2, (i + Index) - 10].BackColor = Color.White;
            }
        }      

    }            
}
