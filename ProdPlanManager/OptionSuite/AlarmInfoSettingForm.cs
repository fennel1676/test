using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClassCore;

namespace T8_1_CCS
{
	public partial class AlarmInfoSettingForm : Form
	{
		private DataTable dataTable = new DataTable();

		public AlarmInfoSettingForm(DataTable dataTable)
		{
			InitializeComponent();
			this.dataTable = dataTable;
		}
		private void AlarmInfoSettingForm_Load(object sender, EventArgs e)
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

			//HeaderCount
			fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread1_Sheet1.ColumnHeader.RowCount = 2;

			//BodyCount
			fpSpread1_Sheet1.RowCount = LCData.AlarmInfos.Count + 1;
			fpSpread1_Sheet1.ColumnCount = 8;

			//Font
			fpSpread1.Font = new Font("Arial", 8.25f);
			for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
				fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
				fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

			//HeaderMerge
			fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 0, 2, 1);
			fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 1, 2, 1);
			fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 2, 2, 1);
			fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 3, 2, 1);
			fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 4, 1, 3);
			fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 7, 2, 1);

			//Alignment
			for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
			{
				fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
				fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			}

			//Width
			fpSpread1_Sheet1.Columns[0].Width = 70.0f;
			fpSpread1_Sheet1.Columns[1].Width = 70.0f;
			fpSpread1_Sheet1.Columns[2].Width = 70.0f;
			fpSpread1_Sheet1.Columns[3].Width = 70.0f;
			fpSpread1_Sheet1.Columns[4].Width = 70.0f;
			fpSpread1_Sheet1.Columns[5].Width = 70.0f;
			fpSpread1_Sheet1.Columns[6].Width = 70.0f;
			fpSpread1_Sheet1.Columns[7].Width = 300.0f;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "Section";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "PLC";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "UnitID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "AlarmID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = "AlarmCode";
			fpSpread1_Sheet1.ColumnHeader.Cells[1, 4].Text = "Type";
			fpSpread1_Sheet1.ColumnHeader.Cells[1, 5].Text = "Reason";
			fpSpread1_Sheet1.ColumnHeader.Cells[1, 6].Text = "Code";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 7].Text = "AlarmText";

			//Body
			string[] sectionList = new string[] { eAlarmSection.MASTER.ToString(), eAlarmSection.PIO.ToString(), eAlarmSection.UNIT.ToString() };
			string[] typeList = new string[] { eAlarmType.Fault.ToString(), eAlarmType.Warning.ToString() };
			string[] reasonList = new string[] { eAlarmReason.OtherEQ.ToString(), eAlarmReason.Parameter.ToString(),
			                                    eAlarmReason.Panel.ToString(), eAlarmReason.Material.ToString(),
			                                    eAlarmReason.EQ.ToString(), eAlarmReason.Safety.ToString() };

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType1.Items = sectionList;
			comboType2.Items = typeList;
			comboType3.Items = reasonList;

			fpSpread1_Sheet1.Columns[0].CellType = comboType1;
			fpSpread1_Sheet1.Columns[4].CellType = comboType2;
			fpSpread1_Sheet1.Columns[5].CellType = comboType3;

			backgroundWorker.RunWorkerAsync();
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
		private short ShortParse(string str)
		{
			short result;

			try
			{
				result = short.Parse(str);
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
				fpSpread1_Sheet1.GetText(e.Row, 1).Trim() == "" &&
				fpSpread1_Sheet1.GetText(e.Row, 2).Trim() == "" &&
				fpSpread1_Sheet1.GetText(e.Row, 3).Trim() == "" &&
				fpSpread1_Sheet1.GetText(e.Row, 7).Trim() == "")
				fpSpread1_Sheet1.Rows[e.Row].Remove();
			else if ((fpSpread1_Sheet1.RowCount - 1) <= e.Row &&
				(fpSpread1_Sheet1.GetText(e.Row, 1).Trim() != "" ||
				fpSpread1_Sheet1.GetText(e.Row, 2).Trim() != "" ||
				fpSpread1_Sheet1.GetText(e.Row, 3).Trim() != "" ||
				fpSpread1_Sheet1.GetText(e.Row, 7).Trim() != ""))
				fpSpread1_Sheet1.RowCount++;

			if (e.Column == 0)
			{
				if (fpSpread1_Sheet1.GetText(e.Row, 0).Trim().ToUpper() == "UNIT") fpSpread1_Sheet1.SetText(e.Row, 2, "COMMON");
			}
			else if (e.Column == 2)
			{
				if (fpSpread1_Sheet1.GetText(e.Row, 2).Trim().ToUpper() == "COMMON") fpSpread1_Sheet1.SetText(e.Row, 0, "UNIT");
			}
			else if (e.Column == 4 || e.Column == 5)
			{
				AlarmData alarmData = new AlarmData();

				if (fpSpread1_Sheet1.GetText(e.Row, 4).Trim() == eAlarmType.Fault.ToString()) alarmData.AlarmType = eAlarmType.Fault;
				else alarmData.AlarmType = eAlarmType.Warning;

				if (fpSpread1_Sheet1.GetText(e.Row, 5).Trim() == eAlarmReason.Safety.ToString()) alarmData.AlarmReason = eAlarmReason.Safety;
				else if (fpSpread1_Sheet1.GetText(e.Row, 5).Trim() == eAlarmReason.Parameter.ToString()) alarmData.AlarmReason = eAlarmReason.Parameter;
				else if (fpSpread1_Sheet1.GetText(e.Row, 5).Trim() == eAlarmReason.EQ.ToString()) alarmData.AlarmReason = eAlarmReason.EQ;
				else if (fpSpread1_Sheet1.GetText(e.Row, 5).Trim() == eAlarmReason.Material.ToString()) alarmData.AlarmReason = eAlarmReason.Material;
				else if (fpSpread1_Sheet1.GetText(e.Row, 5).Trim() == eAlarmReason.Panel.ToString()) alarmData.AlarmReason = eAlarmReason.Panel;
				else alarmData.AlarmReason = eAlarmReason.OtherEQ;

				fpSpread1_Sheet1.SetText(e.Row, 6, alarmData.Code.ToString());
			}
			else if (e.Column == 6)
			{
				AlarmData alarmData = new AlarmData();

				short value = ShortParse(fpSpread1_Sheet1.GetText(e.Row, 6));
				if (0 > value || value > 96) value = 80;
				alarmData.Code = value;

				fpSpread1_Sheet1.SetText(e.Row, 4, alarmData.AlarmType.ToString());
				fpSpread1_Sheet1.SetText(e.Row, 5, alarmData.AlarmReason.ToString());
				fpSpread1_Sheet1.SetText(e.Row, 6, alarmData.Code.ToString());
			}
		}
		private void fpSpread1_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
		{
			if (e.Column == 0) fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column + 1);
			else fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column - 1);
			fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column);
		}
		private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (fpSpread1_Sheet1.ActiveCell.Column.Index != 4 &&
					fpSpread1_Sheet1.ActiveCell.Column.Index != 5)
				{
					fpSpread1_Sheet1.ActiveCell.Text = "";
					if (fpSpread1_Sheet1.RowCount > (fpSpread1_Sheet1.ActiveCell.Row.Index + 1))
					{
						fpSpread1_Change(sender, new FarPoint.Win.Spread.ChangeEventArgs(null,
							fpSpread1_Sheet1.ActiveCell.Row.Index, fpSpread1_Sheet1.ActiveCell.Column.Index));
					}
				}
			}
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			//Password입력
			PasswordInputForm passwordInputForm = new PasswordInputForm();
			DialogResult passwordResult = passwordInputForm.ShowDialog();
			if (passwordResult != DialogResult.OK) return;

			for (int i = 0; i < (fpSpread1_Sheet1.RowCount - 1); i++)
			{
				for (int j = 0; j < (fpSpread1_Sheet1.RowCount - 1); j++)
				{
					if (fpSpread1_Sheet1.Cells[i, 0].Text.Trim().ToUpper() == fpSpread1_Sheet1.Cells[j, 0].Text.Trim().ToUpper() &&
						fpSpread1_Sheet1.Cells[i, 1].Text.Trim().ToUpper() == fpSpread1_Sheet1.Cells[j, 1].Text.Trim().ToUpper() &&
						fpSpread1_Sheet1.Cells[i, 3].Text.Trim().ToUpper() == fpSpread1_Sheet1.Cells[j, 3].Text.Trim().ToUpper() && i != j)
					{
						fpSpread1_Sheet1.SetActiveCell(i, 0);
						MessageBox.Show("동일한 ID값이 존재합니다. 다시 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}

			for (int i = 0; i < (fpSpread1_Sheet1.RowCount - 1); i++)
			{
				string section = fpSpread1_Sheet1.Cells[i, 0].Text.Trim().ToUpper();
				string eqID = fpSpread1_Sheet1.Cells[i, 1].Text.Trim().ToUpper();
				string unitID = fpSpread1_Sheet1.Cells[i, 2].Text.Trim();
				int alarmID = IntParse(fpSpread1_Sheet1.Cells[i, 3].Text);
				short alarmCode = ShortParse(fpSpread1_Sheet1.Cells[i, 6].Text);
				string alarmText = fpSpread1_Sheet1.Cells[i, 7].Text.Trim();

				if (section == "")
				{
					fpSpread1_Sheet1.SetActiveCell(i, 0);
					MessageBox.Show("Section 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (eqID != "PLC1" && eqID != "PLC2")
				{
					fpSpread1_Sheet1.SetActiveCell(i, 1);
					MessageBox.Show("EqID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (unitID == "")
				{
					fpSpread1_Sheet1.SetActiveCell(i, 2);
					MessageBox.Show("UnitID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (alarmID < 0)
				{
					fpSpread1_Sheet1.SetActiveCell(i, 3);
					MessageBox.Show("AlarmID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (alarmCode < 0)
				{
					fpSpread1_Sheet1.SetActiveCell(i, 6);
					MessageBox.Show("AlarmCode 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (alarmText == "")
				{
					fpSpread1_Sheet1.SetActiveCell(i, 7);
					MessageBox.Show("AlarmText 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				object[] datas = new object[] { section, eqID, unitID, alarmID, alarmCode, alarmText };
				dataTable.Rows.Add(datas);
			}

			this.DialogResult = DialogResult.OK;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			int rowCount = 0;
			foreach (AlarmData alarmInfo in LCData.AlarmInfos)
			{
				fpSpread1_Sheet1.SetText(rowCount, 0, alarmInfo.Section.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 1, alarmInfo.EqID);
				fpSpread1_Sheet1.SetText(rowCount, 2, alarmInfo.UnitID);
				fpSpread1_Sheet1.SetText(rowCount, 3, alarmInfo.ID.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 4, alarmInfo.AlarmType.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 5, alarmInfo.AlarmReason.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 6, alarmInfo.Code.ToString());
				fpSpread1_Sheet1.SetText(rowCount, 7, alarmInfo.Text);
				rowCount++;

				if ((rowCount % 20) == 0)
				{
					backgroundWorker.ReportProgress((int)(rowCount * 100 / LCData.AlarmInfos.Count));
					System.Threading.Thread.Sleep(1);
				}
			}
		}
		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}
		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			panelLoading.Visible = false;
		}

	}
}