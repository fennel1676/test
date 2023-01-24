using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ProdPlanManager
{
    public partial class MsgControl : UserControl
    {
        public MsgControl()
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
            fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

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
            fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread1_Sheet1.Columns.Default.Resizable = false;
            fpSpread1_Sheet1.Rows.Default.Resizable = false;
            //HeaderCount
            fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
            fpSpread1_Sheet1.ColumnHeader.RowCount = 1;

            fpSpread1_Sheet1.GrayAreaBackColor = Color.White;

            //BodyCount
            fpSpread1_Sheet1.RowCount = 0;
            fpSpread1_Sheet1.ColumnCount = 1;

            //Font
            fpSpread1.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            //Width
            fpSpread1_Sheet1.Columns[0].Width = 740.0f;
            //HeaderText
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "Message";

            //CellType
            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
            fpSpread1_Sheet1.Columns[0].CellType = textType;

        }

        public void SetMessage(string text)
        {
            int nRemoveCount = ClassCore.LCData.Parameter.LimitLineCount;

            if (fpSpread1_Sheet1.RowCount >= nRemoveCount)
            {
                if (nRemoveCount == 0)
                {
                    nRemoveCount = 0;
                }
                else
                {
                    nRemoveCount = nRemoveCount - 1;
                }

                fpSpread1_Sheet1.RemoveRows(nRemoveCount, (fpSpread1_Sheet1.RowCount - nRemoveCount));
            }
            fpSpread1_Sheet1.AddRows(0, 1);
            fpSpread1_Sheet1.Cells[0, 0].ForeColor = Color.White;
            fpSpread1_Sheet1.Cells[0, 0].BackColor = Color.YellowGreen;
            fpSpread1_Sheet1.Cells[0, 0].Text = DateTime.Now.ToString("[ yy/MM/dd HH:mm:ss ] ").Replace('-', '/') + text;

            if (fpSpread1_Sheet1.RowCount > 1)
            {
                fpSpread1_Sheet1.Cells[1, 0].ForeColor = Color.Black;
                fpSpread1_Sheet1.Cells[1, 0].BackColor = Color.White;
            }
        }
    }
}
