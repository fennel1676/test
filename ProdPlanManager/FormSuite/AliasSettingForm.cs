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
	public partial class AliasSettingForm : Form
	{
		public AliasSettingForm()
		{
			InitializeComponent();
		}
		private void AliasSettingForm_Load(object sender, EventArgs e)
		{
			//Docking
			this.fpSpread1.Dock = DockStyle.Fill;
			this.fpSpread2.Dock = DockStyle.Fill;
			this.fpSpread3.Dock = DockStyle.Fill;

			//ActiveSkin
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread1);
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread2);
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread3);

			//Split 설정
			fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread2.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread2.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread3.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread3.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

			//스크롤바 설정
			fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			fpSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			fpSpread3.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

			//TrackPolicy
			fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
			fpSpread2.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
			fpSpread3.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

			//커서 설정
			fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);
			fpSpread2.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread2.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);
			fpSpread3.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread3.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

			//HeaderCount
			fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread1_Sheet1.ColumnHeader.RowCount = 1;
			fpSpread2_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread2_Sheet1.ColumnHeader.RowCount = 1;
			fpSpread3_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread3_Sheet1.ColumnHeader.RowCount = 1;

			//BodyCount
			fpSpread1_Sheet1.RowCount = 1;
			fpSpread1_Sheet1.ColumnCount = 2;
			fpSpread2_Sheet1.RowCount = 1;
			fpSpread2_Sheet1.ColumnCount = 3;
			fpSpread3_Sheet1.RowCount = 1;
			fpSpread3_Sheet1.ColumnCount = 2;

			//Font
			fpSpread1.Font = new Font("Arial", 8.25f);
			for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
				fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
				fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			fpSpread2.Font = new Font("Arial", 8.25f);
			for (int i = 0; i < fpSpread2_Sheet1.RowHeader.ColumnCount; i++)
				fpSpread2_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			for (int i = 0; i < fpSpread2_Sheet1.ColumnHeader.RowCount; i++)
				fpSpread2_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			fpSpread3.Font = new Font("Arial", 8.25f);
			for (int i = 0; i < fpSpread3_Sheet1.RowHeader.ColumnCount; i++)
				fpSpread3_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			for (int i = 0; i < fpSpread3_Sheet1.ColumnHeader.RowCount; i++)
				fpSpread3_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

			//Alignment
			for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
			{
				fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
				fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			}
			for (int i = 0; i < fpSpread2_Sheet1.ColumnCount; i++)
			{
				fpSpread2_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
				fpSpread2_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			}
			for (int i = 0; i < fpSpread3_Sheet1.ColumnCount; i++)
			{
				fpSpread3_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
				fpSpread3_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			}

			//Width
			fpSpread1_Sheet1.Columns[0].Width = 130.0f;
			fpSpread1_Sheet1.Columns[1].Width = 130.0f;
			fpSpread2_Sheet1.Columns[0].Width = 130.0f;
			fpSpread2_Sheet1.Columns[1].Width = 130.0f;
			fpSpread2_Sheet1.Columns[2].Width = 130.0f;
			fpSpread3_Sheet1.Columns[0].Width = 130.0f;
			fpSpread3_Sheet1.Columns[1].Width = 130.0f;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "WorkID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "Alias";
			fpSpread2_Sheet1.ColumnHeader.Cells[0, 0].Text = "WorkID";
			fpSpread2_Sheet1.ColumnHeader.Cells[0, 1].Text = "WorkerID";
			fpSpread2_Sheet1.ColumnHeader.Cells[0, 2].Text = "Alias";
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 0].Text = "FlowID";
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 1].Text = "Alias";

			//Body
			foreach (AliasData alias in LCData.Aliases)
			{
				if (alias.Type == eAliasType.WorkAlias)
				{
					fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 0, alias.WorkID.ToString());
					fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 1, alias.Alias);
					fpSpread1_Sheet1.RowCount++;
				}
				else if (alias.Type == eAliasType.WorkerAlias)
				{
					fpSpread2_Sheet1.SetText(fpSpread2_Sheet1.RowCount - 1, 0, alias.WorkID.ToString());
					fpSpread2_Sheet1.SetText(fpSpread2_Sheet1.RowCount - 1, 1, alias.WorkerID.ToString());
					fpSpread2_Sheet1.SetText(fpSpread2_Sheet1.RowCount - 1, 2, alias.Alias);
					fpSpread2_Sheet1.RowCount++;
				}
				else if (alias.Type == eAliasType.FlowAlias)
				{
					fpSpread3_Sheet1.SetText(fpSpread3_Sheet1.RowCount - 1, 0, alias.FlowID);
					fpSpread3_Sheet1.SetText(fpSpread3_Sheet1.RowCount - 1, 1, alias.Alias);
					fpSpread3_Sheet1.RowCount++;
				}
			}
		}

		private int IntParse(string str)
		{
			int result;

			try
			{
				result = int.Parse(str);
			}
			catch
			{
				result = -1;
			}

			return result;
		}

		private void fpSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
		{
			if (fpSpread1_Sheet1.RowCount - 1 > e.Row &&
				fpSpread1_Sheet1.GetText(e.Row, 0).Trim() == "" &&
				fpSpread1_Sheet1.GetText(e.Row, 1).Trim() == "")
				fpSpread1_Sheet1.Rows[e.Row].Remove();
			else if (fpSpread1_Sheet1.RowCount - 1 <= e.Row &&
				(fpSpread1_Sheet1.GetText(e.Row, 0).Trim() != "" ||
				fpSpread1_Sheet1.GetText(e.Row, 1).Trim() != ""))
				fpSpread1_Sheet1.RowCount++;
		}
		private void fpSpread2_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
		{
			if (fpSpread2_Sheet1.RowCount - 1 > e.Row &&
				fpSpread2_Sheet1.GetText(e.Row, 0).Trim() == "" &&
				fpSpread2_Sheet1.GetText(e.Row, 1).Trim() == "" &&
				fpSpread2_Sheet1.GetText(e.Row, 2).Trim() == "")
				fpSpread2_Sheet1.Rows[e.Row].Remove();
			else if (fpSpread2_Sheet1.RowCount - 1 <= e.Row &&
				(fpSpread2_Sheet1.GetText(e.Row, 0).Trim() != "" ||
				fpSpread2_Sheet1.GetText(e.Row, 1).Trim() != "" ||
				fpSpread2_Sheet1.GetText(e.Row, 2).Trim() != ""))
				fpSpread2_Sheet1.RowCount++;
		}
		private void fpSpread3_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
		{
			if (fpSpread3_Sheet1.RowCount - 1 > e.Row &&
				fpSpread3_Sheet1.GetText(e.Row, 0).Trim() == "" &&
				fpSpread3_Sheet1.GetText(e.Row, 1).Trim() == "")
				fpSpread3_Sheet1.Rows[e.Row].Remove();
			else if (fpSpread3_Sheet1.RowCount - 1 <= e.Row &&
				(fpSpread3_Sheet1.GetText(e.Row, 0).Trim() != "" ||
				fpSpread3_Sheet1.GetText(e.Row, 1).Trim() != ""))
				fpSpread3_Sheet1.RowCount++;
		}
		private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				fpSpread1_Sheet1.ActiveCell.Text = "";
				if (fpSpread1_Sheet1.RowCount > (fpSpread1_Sheet1.ActiveCell.Row.Index + 1))
				{
					fpSpread1_Change(sender, new FarPoint.Win.Spread.ChangeEventArgs(null,
						fpSpread1_Sheet1.ActiveCell.Row.Index, fpSpread1_Sheet1.ActiveCell.Column.Index));
				}
			}
		}
		private void fpSpread2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				fpSpread2_Sheet1.ActiveCell.Text = "";
				if (fpSpread2_Sheet1.RowCount > (fpSpread2_Sheet1.ActiveCell.Row.Index + 1))
				{
					fpSpread2_Change(sender, new FarPoint.Win.Spread.ChangeEventArgs(null,
						fpSpread2_Sheet1.ActiveCell.Row.Index, fpSpread2_Sheet1.ActiveCell.Column.Index));
				}
			}
		}
		private void fpSpread3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				fpSpread3_Sheet1.ActiveCell.Text = "";
				if (fpSpread3_Sheet1.RowCount > (fpSpread3_Sheet1.ActiveCell.Row.Index + 1))
				{
					fpSpread3_Change(sender, new FarPoint.Win.Spread.ChangeEventArgs(null,
						fpSpread3_Sheet1.ActiveCell.Row.Index, fpSpread3_Sheet1.ActiveCell.Column.Index));
				}
			}
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			List<AliasData> aliases = new List<AliasData>();

			for (int i = 0; i < (fpSpread1_Sheet1.Rows.Count - 1); i++)
			{
				AliasData alias = new AliasData();
				alias.Type = eAliasType.WorkAlias;
				alias.WorkID = IntParse(fpSpread1_Sheet1.Cells[i, 0].Text);
				alias.Alias = fpSpread1_Sheet1.Cells[i, 1].Text;
				aliases.Add(alias);

				if (alias.WorkID < 0)
				{
					tabControl1.SelectTab(0);
					fpSpread1_Sheet1.SetActiveCell(i, 0);
					MessageBox.Show("WorkID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (alias.Alias.Trim().Length > 22)
				{
					tabControl1.SelectTab(0);
					fpSpread1_Sheet1.SetActiveCell(i, 1);
					MessageBox.Show("Alias 값을 22자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			for (int i = 0; i < (fpSpread2_Sheet1.Rows.Count - 1); i++)
			{
				AliasData alias = new AliasData();
				alias.Type = eAliasType.WorkerAlias;
				alias.WorkID = IntParse(fpSpread2_Sheet1.Cells[i, 0].Text);
				alias.WorkerID = IntParse(fpSpread2_Sheet1.Cells[i, 1].Text);
				alias.Alias = fpSpread2_Sheet1.Cells[i, 2].Text;
				aliases.Add(alias);

				if (alias.WorkID < 0)
				{
					tabControl1.SelectTab(1);
					fpSpread2_Sheet1.SetActiveCell(i, 0);
					MessageBox.Show("WorkID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (alias.WorkerID < 0)
				{
					tabControl1.SelectTab(1);
					fpSpread2_Sheet1.SetActiveCell(i, 1);
					MessageBox.Show("WorkerID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (alias.Alias.Trim().Length > 27)
				{
					tabControl1.SelectTab(1);
					fpSpread2_Sheet1.SetActiveCell(i, 2);
					MessageBox.Show("Alias 값을 27자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			for (int i = 0; i < (fpSpread3_Sheet1.Rows.Count - 1); i++)
			{
				AliasData alias = new AliasData();
				alias.Type = eAliasType.FlowAlias;
				alias.FlowID = fpSpread3_Sheet1.Cells[i, 0].Text;
				alias.Alias = fpSpread3_Sheet1.Cells[i, 1].Text;
				aliases.Add(alias);

				if (alias.FlowID.Trim().Length > 12)
				{
					tabControl1.SelectTab(2);
					fpSpread3_Sheet1.SetActiveCell(i, 0);
					MessageBox.Show("FlowID 값을 12자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (alias.Alias.Trim().Length > 20)
				{
					tabControl1.SelectTab(2);
					fpSpread3_Sheet1.SetActiveCell(i, 1);
					MessageBox.Show("Alias 값을 20자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			LCData.Aliases.Clear();
			LCData.Aliases = aliases;
			this.DialogResult = DialogResult.OK;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}