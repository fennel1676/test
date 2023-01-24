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
    public partial class AlarmControl : UserControl
    {
        public AlarmControl()
        {
            InitializeComponent();
        }

        public void InitControl()
		{
            //this.Dock = DockStyle.Fill;

            //Docking
            fpSpread1.Dock = DockStyle.Fill;

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

            ////커서 설정
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BlockOption
            fpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            //ReadOnly
            fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread1_Sheet1.Columns.Default.Resizable = false;
            fpSpread1_Sheet1.Rows.Default.Resizable = false;
            //Araa Color
            fpSpread1_Sheet1.GrayAreaBackColor = Color.White;
			//HeaderCount
			fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread1_Sheet1.ColumnHeader.RowCount = 1;
			//BodyCount
			fpSpread1_Sheet1.RowCount = 0;
			fpSpread1_Sheet1.ColumnCount = 5;

			//Font
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

            fpSpread1_Sheet1.Columns[4].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            fpSpread1_Sheet1.Columns[4].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            //Width
            fpSpread1_Sheet1.Columns[0].Width = 150.0f;
            fpSpread1_Sheet1.Columns[1].Width = 135.0f;
            fpSpread1_Sheet1.Columns[2].Width = 60.0f;
            fpSpread1_Sheet1.Columns[3].Width = 60.0f;
            fpSpread1_Sheet1.Columns[4].Width = 335.0f;


            //HeaderText
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "Time";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "ModuleID";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "UnitID";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "AlarmID";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = "AlarmText";

			//CellType
			FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
			fpSpread1_Sheet1.Columns[0].CellType = textType;
            fpSpread1_Sheet1.Columns[1].CellType = textType;
            fpSpread1_Sheet1.Columns[2].CellType = textType;
            fpSpread1_Sheet1.Columns[3].CellType = textType;
            fpSpread1_Sheet1.Columns[4].CellType = textType;

            //Back color
            fpSpread1_Sheet1.Columns[0].BackColor = Color.Red;
            fpSpread1_Sheet1.Columns[1].BackColor = Color.Red;
            fpSpread1_Sheet1.Columns[2].BackColor = Color.Red;
            fpSpread1_Sheet1.Columns[3].BackColor = Color.Red;
            fpSpread1_Sheet1.Columns[4].BackColor = Color.Red;

            //font color
            fpSpread1_Sheet1.Columns[0].ForeColor = Color.White;
            fpSpread1_Sheet1.Columns[1].ForeColor = Color.White;
            fpSpread1_Sheet1.Columns[2].ForeColor = Color.White;
            fpSpread1_Sheet1.Columns[3].ForeColor = Color.White;
            fpSpread1_Sheet1.Columns[4].ForeColor = Color.White;


            fpSpread1_Sheet1.Columns[0].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            fpSpread1_Sheet1.Columns[1].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            fpSpread1_Sheet1.Columns[2].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            fpSpread1_Sheet1.Columns[3].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            fpSpread1_Sheet1.Columns[4].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            fpSpread1_Sheet1.Columns[0].Locked = true;
            fpSpread1_Sheet1.Columns[1].Locked = true;
            fpSpread1_Sheet1.Columns[2].Locked = true;
            fpSpread1_Sheet1.Columns[3].Locked = true;
            fpSpread1_Sheet1.Columns[4].Locked = true;

        }
        public void UpdateDisplay()
        {

            //if (fpSpread1_Sheet1.GetText(0, 0) == "") fpSpread1_Sheet1.RowCount = 0;
            int rowCount = 0;
            foreach (AlarmData alarm in LCData.Alarms)
            {
                if (fpSpread1_Sheet1.RowCount - 1 < rowCount) fpSpread1_Sheet1.RowCount++;

                string time = alarm.Time.Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/");
                fpSpread1_Sheet1.SetText(rowCount, 0, time);
                fpSpread1_Sheet1.SetText(rowCount, 1, alarm.ModuleID);
                fpSpread1_Sheet1.SetText(rowCount, 2, alarm.UnitID);
                fpSpread1_Sheet1.SetText(rowCount, 3, alarm.ID.ToString());
                fpSpread1_Sheet1.SetText(rowCount, 4, alarm.Text);
                rowCount++;
            }
            fpSpread1_Sheet1.RowCount = rowCount;
        }
    }
}
