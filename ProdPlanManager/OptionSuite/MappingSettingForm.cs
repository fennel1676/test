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
	public partial class MappingSettingForm : Form
	{
		public MappingSettingForm()
		{
			InitializeComponent();
		}
		private void MappingSettingForm_Load(object sender, EventArgs e)
		{
			//Docking
			this.fpSpread1.Dock = DockStyle.Fill;
			this.fpSpread2.Dock = DockStyle.Fill;
			this.fpSpread3.Dock = DockStyle.Fill;
			this.fpSpread4.Dock = DockStyle.Fill;

			//ActiveSkin
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread1);
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread2);
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread3);
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread4);

			//Split 설정
			fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread2.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread2.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread3.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread3.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread4.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread4.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

			//스크롤바 설정
			fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			fpSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			fpSpread3.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			fpSpread4.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

			//TrackPolicy
			fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
			fpSpread2.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
			fpSpread3.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
			fpSpread4.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

			//TextTipPolicy
			fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
			fpSpread2.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
			fpSpread3.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
			fpSpread4.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

			//커서 설정
			fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);
			fpSpread2.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread2.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);
			fpSpread3.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread3.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);
			fpSpread4.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread4.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

			//HeaderCount
			fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread1_Sheet1.ColumnHeader.RowCount = 1;
			fpSpread2_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread2_Sheet1.ColumnHeader.RowCount = 1;
			fpSpread3_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread3_Sheet1.ColumnHeader.RowCount = 1;
			fpSpread4_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread4_Sheet1.ColumnHeader.RowCount = 1;

			//BodyCount
			fpSpread1_Sheet1.RowCount = 1;
			fpSpread1_Sheet1.ColumnCount = 3;
			fpSpread2_Sheet1.RowCount = 1;
			fpSpread2_Sheet1.ColumnCount = 3;
			fpSpread3_Sheet1.RowCount = 1;
			fpSpread3_Sheet1.ColumnCount = 2;
			fpSpread4_Sheet1.RowCount = 1;
			fpSpread4_Sheet1.ColumnCount = 2;

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
			fpSpread4.Font = new Font("Arial", 8.25f);
			for (int i = 0; i < fpSpread4_Sheet1.RowHeader.ColumnCount; i++)
				fpSpread4_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			for (int i = 0; i < fpSpread4_Sheet1.ColumnHeader.RowCount; i++)
				fpSpread4_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

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
			for (int i = 0; i < fpSpread4_Sheet1.ColumnCount; i++)
			{
				fpSpread4_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
				fpSpread4_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			}

			//Width
			fpSpread1_Sheet1.Columns[0].Width = 130.0f;
			fpSpread1_Sheet1.Columns[1].Width = 130.0f;
			fpSpread1_Sheet1.Columns[2].Width = 130.0f;
			fpSpread2_Sheet1.Columns[0].Width = 130.0f;
			fpSpread2_Sheet1.Columns[1].Width = 130.0f;
			fpSpread2_Sheet1.Columns[2].Width = 130.0f;
			fpSpread3_Sheet1.Columns[0].Width = 130.0f;
			fpSpread3_Sheet1.Columns[1].Width = 170.0f;
			fpSpread4_Sheet1.Columns[0].Width = 130.0f;
			fpSpread4_Sheet1.Columns[1].Width = 130.0f;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "WorkID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "WorkType";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "EqpType";
			fpSpread2_Sheet1.ColumnHeader.Cells[0, 0].Text = "WorkID";
			fpSpread2_Sheet1.ColumnHeader.Cells[0, 1].Text = "WorkerID";
			fpSpread2_Sheet1.ColumnHeader.Cells[0, 2].Text = "MappingEQ";
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 0].Text = "FlowID";
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 1].Text = "Description";
			fpSpread4_Sheet1.ColumnHeader.Cells[0, 0].Text = "ECID";
			fpSpread4_Sheet1.ColumnHeader.Cells[0, 1].Text = "ECName";

			//CellType
			FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
			fpSpread1_Sheet1.Columns[0].CellType = textType;
			fpSpread2_Sheet1.Columns[0].CellType = textType;

			//Body
			foreach (MappingData mapping in LCData.Mappings)
			{
				if (mapping.Type == eMappingType.WorkID)
				{
					fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 0, mapping.WorkID);
					fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 1, mapping.Text);
					fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 2, mapping.Text2);
					fpSpread1_Sheet1.RowCount++;
				}
				else if (mapping.Type == eMappingType.WorkerID)
				{
					fpSpread2_Sheet1.SetText(fpSpread2_Sheet1.RowCount - 1, 0, mapping.WorkID.ToString());
					fpSpread2_Sheet1.SetText(fpSpread2_Sheet1.RowCount - 1, 1, mapping.WorkerID.ToString());
					fpSpread2_Sheet1.SetText(fpSpread2_Sheet1.RowCount - 1, 2, mapping.Text);
					fpSpread2_Sheet1.RowCount++;
				}
				else if (mapping.Type == eMappingType.FlowID)
				{
					fpSpread3_Sheet1.SetText(fpSpread3_Sheet1.RowCount - 1, 0, mapping.FlowID);
					fpSpread3_Sheet1.SetText(fpSpread3_Sheet1.RowCount - 1, 1, mapping.Text);
					fpSpread3_Sheet1.RowCount++;
				}
				else if (mapping.Type == eMappingType.ECID)
				{
					fpSpread4_Sheet1.SetText(fpSpread4_Sheet1.RowCount - 1, 0, mapping.ECID.ToString());
					fpSpread4_Sheet1.SetText(fpSpread4_Sheet1.RowCount - 1, 1, mapping.Text);
					fpSpread4_Sheet1.RowCount++;
				}
			}

			//ECID Tab
			if (LCData.CCSType == eCCSType.DEPO)
			{
				tabControl1.TabPages.RemoveAt(3);
			}
		}

		private bool IsBinary(string str, int len)
		{
			if (str.Length != len)
			{
				return false;
			}
			else
			{
				char[] chs = str.ToCharArray();
				foreach (char ch in chs)
				{
					if (ch != '0' && ch != '1')
					{
						return false;
					}
				}
			}
			return true;
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
				fpSpread1_Sheet1.GetText(e.Row, 1).Trim() == "" &&
				fpSpread1_Sheet1.GetText(e.Row, 2).Trim() == "")
				fpSpread1_Sheet1.Rows[e.Row].Remove();
			else if (fpSpread1_Sheet1.RowCount - 1 <= e.Row &&
				(fpSpread1_Sheet1.GetText(e.Row, 0).Trim() != "" ||
				fpSpread1_Sheet1.GetText(e.Row, 1).Trim() != "" ||
				fpSpread1_Sheet1.GetText(e.Row, 2).Trim() != ""))
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
		private void fpSpread4_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
		{
			if (fpSpread4_Sheet1.RowCount - 1 > e.Row &&
				fpSpread4_Sheet1.GetText(e.Row, 0).Trim() == "" &&
				fpSpread4_Sheet1.GetText(e.Row, 1).Trim() == "")
				fpSpread4_Sheet1.Rows[e.Row].Remove();
			else if (fpSpread4_Sheet1.RowCount - 1 <= e.Row &&
				(fpSpread4_Sheet1.GetText(e.Row, 0).Trim() != "" ||
				fpSpread4_Sheet1.GetText(e.Row, 1).Trim() != ""))
				fpSpread4_Sheet1.RowCount++;
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
		private void fpSpread4_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				fpSpread4_Sheet1.ActiveCell.Text = "";
				if (fpSpread4_Sheet1.RowCount > (fpSpread4_Sheet1.ActiveCell.Row.Index + 1))
				{
					fpSpread4_Change(sender, new FarPoint.Win.Spread.ChangeEventArgs(null,
						fpSpread4_Sheet1.ActiveCell.Row.Index, fpSpread4_Sheet1.ActiveCell.Column.Index));
				}
			}
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			//Password입력
			PasswordInputForm passwordInputForm = new PasswordInputForm();
			DialogResult passwordResult = passwordInputForm.ShowDialog();
			if (passwordResult != DialogResult.OK) return;

			List<MappingData> mappings = new List<MappingData>();

			for (int i = 0; i < (fpSpread1_Sheet1.Rows.Count - 1); i++)
			{
				MappingData mapping = new MappingData();
				mapping.Type = eMappingType.WorkID;
				mapping.WorkID = fpSpread1_Sheet1.Cells[i, 0].Text.Trim();
				mapping.Text = fpSpread1_Sheet1.Cells[i, 1].Text.Trim();
				mapping.Text2 = fpSpread1_Sheet1.Cells[i, 2].Text.Trim();
				mappings.Add(mapping);

				if (!IsBinary(mapping.WorkID, 4))
				{
					tabControl1.SelectTab(0);
					fpSpread1_Sheet1.SetActiveCell(i, 0);
					MessageBox.Show("WorkID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (mapping.Text.Length > 22)
				{
					tabControl1.SelectTab(0);
					fpSpread1_Sheet1.SetActiveCell(i, 1);
					MessageBox.Show("WorkType 값을 22자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (mapping.Text2.Length > 27)
				{
					tabControl1.SelectTab(0);
					fpSpread1_Sheet1.SetActiveCell(i, 2);
					MessageBox.Show("EqpType 값을 27자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			for (int i = 0; i < (fpSpread2_Sheet1.Rows.Count - 1); i++)
			{
				MappingData mapping = new MappingData();
				mapping.Type = eMappingType.WorkerID;
				mapping.WorkID = fpSpread2_Sheet1.Cells[i, 0].Text.Trim();
				mapping.WorkerID = IntParse(fpSpread2_Sheet1.Cells[i, 1].Text.Trim());
				mapping.Text = fpSpread2_Sheet1.Cells[i, 2].Text.Trim();
				mappings.Add(mapping);

				if (!IsBinary(mapping.WorkID, 4))
				{
					tabControl1.SelectTab(1);
					fpSpread2_Sheet1.SetActiveCell(i, 0);
					MessageBox.Show("WorkID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (mapping.WorkerID < 0)
				{
					tabControl1.SelectTab(1);
					fpSpread2_Sheet1.SetActiveCell(i, 1);
					MessageBox.Show("WorkerID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (mapping.Text.Length > 27)
				{
					tabControl1.SelectTab(1);
					fpSpread2_Sheet1.SetActiveCell(i, 2);
					MessageBox.Show("MappingEQ 값을 27자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			for (int i = 0; i < (fpSpread3_Sheet1.Rows.Count - 1); i++)
			{
				MappingData mapping = new MappingData();
				mapping.Type = eMappingType.FlowID;
				mapping.FlowID = fpSpread3_Sheet1.Cells[i, 0].Text.Trim();
				mapping.Text = fpSpread3_Sheet1.Cells[i, 1].Text.Trim();
				mappings.Add(mapping);

				if (mapping.FlowID.Length > 12)
				{
					tabControl1.SelectTab(2);
					fpSpread3_Sheet1.SetActiveCell(i, 0);
					MessageBox.Show("FlowID 값을 12자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (mapping.Text.Length > 40)
				{
					tabControl1.SelectTab(2);
					fpSpread3_Sheet1.SetActiveCell(i, 1);
					MessageBox.Show("Description 값을 40자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			for (int i = 0; i < (fpSpread4_Sheet1.Rows.Count - 1); i++)
			{
				MappingData mapping = new MappingData();
				mapping.Type = eMappingType.ECID;
				mapping.ECID = IntParse(fpSpread4_Sheet1.Cells[i, 0].Text.Trim());
				mapping.Text = fpSpread4_Sheet1.Cells[i, 1].Text.Trim();
				mappings.Add(mapping);

				if (mapping.ECID < 0)
				{
					tabControl1.SelectTab(3);
					fpSpread4_Sheet1.SetActiveCell(i, 0);
					MessageBox.Show("ECID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (mapping.Text.Length > 40)
				{
					tabControl1.SelectTab(3);
					fpSpread4_Sheet1.SetActiveCell(i, 1);
					MessageBox.Show("ECName 값을 40자내로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			LCData.Mappings.Clear();
			LCData.Mappings = mappings;
			this.DialogResult = DialogResult.OK;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}