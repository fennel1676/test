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
	public partial class EqInterlockSettingForm : Form
	{
		public EqInterlockSettingForm()
		{
			InitializeComponent();
		}
		private void InterlockSettingForm_Load(object sender, EventArgs e)
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
			fpSpread1_Sheet1.ColumnHeader.RowCount = 1;

			//BodyCount
			fpSpread1_Sheet1.RowCount = 1;
			fpSpread1_Sheet1.ColumnCount = 6;

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
			fpSpread1_Sheet1.Columns[0].Width = 180.0f;
			fpSpread1_Sheet1.Columns[1].Width = 110.0f;
			fpSpread1_Sheet1.Columns[2].Width = 110.0f;
			fpSpread1_Sheet1.Columns[3].Width = 110.0f;
			fpSpread1_Sheet1.Columns[4].Width = 110.0f;
			fpSpread1_Sheet1.Columns[5].Width = 110.0f;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "ModuleID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "ImmediatelyPause";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "TransferStop";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "LoadingStop";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = "SpecificInterlock";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 5].Text = "GlassRefuse";

			//Lock
			fpSpread1_Sheet1.Columns[1].Locked = true;
			fpSpread1_Sheet1.Columns[2].Locked = true;
			fpSpread1_Sheet1.Columns[3].Locked = true;
			fpSpread1_Sheet1.Columns[4].Locked = true;
			fpSpread1_Sheet1.Columns[5].Locked = true;

			//CellType
			List<string> moduleList = new List<string>();
			moduleList.Add("");
			foreach (ModuleData module in LCData.Modules)
			{
				if (module.Layer == LCData.ModuleLayer)
				{
					moduleList.Add(module.ID);
				}
			}

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType.MaxDrop = 15;
			comboType.Items = moduleList.ToArray();
			fpSpread1_Sheet1.Columns[0].CellType = comboType;

			//Color
			for (int i = 1; i < fpSpread1_Sheet1.ColumnCount; i++)
			{
				fpSpread1_Sheet1.Columns[i].BackColor = Color.WhiteSmoke;
			}

			//Body
			foreach (EqInterlockData eqInterlock in LCData.EqInterlocks)
			{
				fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 0, eqInterlock.ModuleID);
				fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 1, eqInterlock.ImmediatelyPause);
				fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 2, eqInterlock.TransferStop);
				fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 3, eqInterlock.LoadingStop);
				fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 4, eqInterlock.SpecificInterlock);
				fpSpread1_Sheet1.SetText(fpSpread1_Sheet1.RowCount - 1, 5, eqInterlock.GlassRefuse);
				fpSpread1_Sheet1.RowCount++;
			}

		}

		private void fpSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
		{
			if (fpSpread1_Sheet1.RowCount - 1 > e.Row &&
				fpSpread1_Sheet1.GetText(e.Row, 0).Trim() == "")
				fpSpread1_Sheet1.Rows[e.Row].Remove();
			else if ((fpSpread1_Sheet1.RowCount - 1) <= e.Row &&
				fpSpread1_Sheet1.GetText(e.Row, 0).Trim() != "")
			{
				fpSpread1_Sheet1.SetText(e.Row, 1, "OFF");
				fpSpread1_Sheet1.SetText(e.Row, 2, "OFF");
				fpSpread1_Sheet1.SetText(e.Row, 3, "OFF");
				fpSpread1_Sheet1.SetText(e.Row, 4, "OFF");
				fpSpread1_Sheet1.SetText(e.Row, 5, "OFF");
				fpSpread1_Sheet1.RowCount++;
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
				if (fpSpread1_Sheet1.ActiveCell.Column.Index == 0)
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
					if (fpSpread1_Sheet1.Cells[i, 0].Text.Trim().ToUpper() == fpSpread1_Sheet1.Cells[j, 0].Text.Trim().ToUpper() && i != j)
					{
						fpSpread1_Sheet1.SetActiveCell(i, 0);
						MessageBox.Show("동일한 ModuleID값이 존재합니다. 다시 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}

			List<EqInterlockData> eqInterlocks = new List<EqInterlockData>();

			for (int i = 0; i < (fpSpread1_Sheet1.RowCount - 1); i++)
			{
				EqInterlockData eqInterlock = new EqInterlockData();
				eqInterlock.ModuleID = fpSpread1_Sheet1.Cells[i, 0].Text.Trim();
				eqInterlock.ImmediatelyPause = fpSpread1_Sheet1.Cells[i, 1].Text.Trim();
				eqInterlock.TransferStop = fpSpread1_Sheet1.Cells[i, 2].Text.Trim();
				eqInterlock.LoadingStop = fpSpread1_Sheet1.Cells[i, 3].Text.Trim();
				eqInterlock.SpecificInterlock = fpSpread1_Sheet1.Cells[i, 4].Text.Trim();
				eqInterlock.GlassRefuse = fpSpread1_Sheet1.Cells[i, 5].Text.Trim();
				eqInterlocks.Add(eqInterlock);
			}

			LCData.EqInterlocks.Clear();
			LCData.EqInterlocks = eqInterlocks;
			this.DialogResult = DialogResult.OK;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}