using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassCore;

namespace T8_1_CCS
{
	public partial class AlarmListForm : Form
	{
		public AlarmListForm()
		{
			InitializeComponent();
		}
		private void AlarmListForm_Load(object sender, EventArgs e)
		{
			//ActiveSkin
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread1);

			//Split 설정
			fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

			//스크롤바 설정
			fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

			//TrackPolicy
			fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

			//TextTipPolicy
			fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

			//커서 설정
			fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

			//ReadOnly
			fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;

			//HeaderCount
			fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread1_Sheet1.ColumnHeader.RowCount = 1;

			//BodyCount
			fpSpread1_Sheet1.RowCount = 0;
			fpSpread1_Sheet1.ColumnCount = 9;

			//Font
			fpSpread1.Font = new Font("Arial", 8.25f);
			for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
				fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
				fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

			//Alignment
			for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
			{
				fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
				fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			}

			//Width
			fpSpread1_Sheet1.Columns[0].Width = 120.0f;
			fpSpread1_Sheet1.Columns[1].Width = 160.0f;
			fpSpread1_Sheet1.Columns[2].Width = 60.0f;
			fpSpread1_Sheet1.Columns[3].Width = 60.0f;
			fpSpread1_Sheet1.Columns[4].Width = 60.0f;
			fpSpread1_Sheet1.Columns[5].Width = 60.0f;
			fpSpread1_Sheet1.Columns[6].Width = 60.0f;
			fpSpread1_Sheet1.Columns[7].Width = 60.0f;
			fpSpread1_Sheet1.Columns[8].Width = 300.0f;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "Time";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "ModuleID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "Section";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "PLC";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = "UnitID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 5].Text = "AlarmID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 6].Text = "Type";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 7].Text = "Reason";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 8].Text = "AlarmText";

			//CellType
			FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
			fpSpread1_Sheet1.Columns[0].CellType = textType;

			//Caption
			if (LCData.CCSType == eCCSType.DEPO) this.Text += " / ITO DEPO";
			else if (LCData.CCSType == eCCSType.ETCH1) this.Text += " / ITO ETCH1";
			else if (LCData.CCSType == eCCSType.ETCH2) this.Text += " / ITO ETCH2";
			else if (LCData.CCSType == eCCSType.OC) this.Text += " / OC";
			else if (LCData.CCSType == eCCSType.PIXEL1) this.Text += " / PIXEL ETCH 투입";
			else if (LCData.CCSType == eCCSType.PIXEL2) this.Text += " / PIXEL ETCH 배출";
			else if (LCData.CCSType == eCCSType.EDS) this.Text += " / EDS REPAIR";
		}

		public void UpdateDisplay()
		{
			int rowCount = 0;
			foreach (AlarmData alarm in LCData.Alarms)
			{
				if (fpSpread1_Sheet1.RowCount - 1 < rowCount) fpSpread1_Sheet1.RowCount++;
				
				string time = alarm.Time.Insert(12,":").Insert(10,":").Insert(8," ").Insert(6, "/").Insert(4,"/");
				fpSpread1_Sheet1.SetText(rowCount, 0, time);
				fpSpread1_Sheet1.SetText(rowCount, 1, alarm.ModuleID);
				fpSpread1_Sheet1.SetText(rowCount, 2, alarm.Section.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 3, alarm.EqID);
				fpSpread1_Sheet1.SetText(rowCount, 4, alarm.UnitID);
				fpSpread1_Sheet1.SetText(rowCount, 5, alarm.ID.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 6, alarm.AlarmType.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 7, alarm.AlarmReason.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 8, alarm.Text);
				rowCount++;
			}
			fpSpread1_Sheet1.RowCount = rowCount;
		}

		private void AlarmListForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
		private void AlarmListForm_Activated(object sender, EventArgs e)
		{
			this.TopMost = true;
		}
		private void AlarmListForm_Deactivate(object sender, EventArgs e)
		{
			this.TopMost = false;
		}
	}
}