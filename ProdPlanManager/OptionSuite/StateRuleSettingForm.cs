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
	public partial class StateRuleSettingForm : Form
	{
		public StateRuleSettingForm()
		{
			InitializeComponent();
		}
		private void StateRuleSettingForm_Load(object sender, EventArgs e)
		{
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
			fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			fpSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			fpSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			fpSpread3.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			fpSpread3.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

			//TrackPolicy
			fpSpread1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
			fpSpread2.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
			fpSpread3.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

			//TextTipPolicy
			fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
			fpSpread2.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
			fpSpread3.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

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
			fpSpread3_Sheet1.RowHeader.ColumnCount = 1;
			fpSpread3_Sheet1.ColumnHeader.RowCount = 1;

			//BodyCount
			fpSpread1_Sheet1.RowCount = 1;
			fpSpread1_Sheet1.ColumnCount = 3;
			fpSpread2_Sheet1.RowCount = 1;
			fpSpread2_Sheet1.ColumnCount = 6;
			fpSpread3_Sheet1.RowCount = LCData.StateRules.Count;
			fpSpread3_Sheet1.ColumnCount = 5;

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
			fpSpread3_Sheet1.Columns[3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			fpSpread3_Sheet1.Columns[4].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

			//Width
			for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
			{
				fpSpread1_Sheet1.Columns[i].Width = 70.0f;
			}
			for (int i = 0; i < fpSpread2_Sheet1.ColumnCount; i++)
			{
				fpSpread2_Sheet1.Columns[i].Width = 70.0f;
			}
			fpSpread3_Sheet1.Columns[0].Width = 60.0f;
			fpSpread3_Sheet1.Columns[1].Width = 140.0f;
			fpSpread3_Sheet1.Columns[2].Width = 80.0f;
			fpSpread3_Sheet1.Columns[3].Width = 402.0f;
			fpSpread3_Sheet1.Columns[4].Width = 400.0f;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeaderAutoText = FarPoint.Win.Spread.HeaderAutoText.Numbers;
			fpSpread1.AllowColumnMove = true;
			fpSpread2_Sheet1.ColumnHeaderAutoText = FarPoint.Win.Spread.HeaderAutoText.Numbers;
			fpSpread2.AllowColumnMove = true;
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 0].Text = "PriorID";
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 1].Text = "ModuleID";
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 2].Text = "State";
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 3].Text = "Query";
			fpSpread3_Sheet1.ColumnHeader.Cells[0, 4].Text = "PostFix";
			fpSpread3.AllowRowMove = true;

			//Lock
			fpSpread1_Sheet1.Rows[0].Locked = true;
			fpSpread2_Sheet1.Rows[0].Locked = true;
			fpSpread3_Sheet1.Columns[0].Locked = true;
			fpSpread3_Sheet1.Columns[1].Locked = true;
			fpSpread3_Sheet1.Columns[2].Locked = true;
			fpSpread3_Sheet1.Columns[3].Locked = true;
			fpSpread3_Sheet1.Columns[4].Locked = true;

			//Visible
			fpSpread3_Sheet1.Columns[0].Visible = false;
			fpSpread3_Sheet1.Columns[4].Visible = false;

			//Body
			for (int i = 0; i < LCData.EqStatePriority.Count; i++)
			{
				fpSpread1_Sheet1.SetText(0, i, LCData.EqStatePriority[i]);
			}
			for (int i = 0; i < LCData.ProcStatePriority.Count; i++)
			{
				fpSpread2_Sheet1.SetText(0, i, LCData.ProcStatePriority[i]);
			}
			for (int i = 0; i < LCData.StateRules.Count; i++)
			{
				fpSpread3_Sheet1.SetText(i, 0, LCData.StateRules[i].PriorID.ToString());
				fpSpread3_Sheet1.SetText(i, 1, LCData.StateRules[i].ModuleID);
				fpSpread3_Sheet1.SetText(i, 2, LCData.StateRules[i].State);
				fpSpread3_Sheet1.SetText(i, 3, LCData.StateRules[i].Query);
				fpSpread3_Sheet1.SetText(i, 4, LCData.StateRules[i].Postfix);
			}

		}

		private void SortPriorID()
		{
			for (int i = 0; i < fpSpread3_Sheet1.RowCount; i++)
			{
				fpSpread3_Sheet1.SetText(i, 0, i.ToString());
			}
		}
		private void fpSpread3_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if (e.ColumnHeader == false)
			{
				StateRuleData stateRule = new StateRuleData();
				stateRule.PriorID = int.Parse(fpSpread3_Sheet1.GetText(e.Row, 0));
				stateRule.ModuleID = fpSpread3_Sheet1.GetText(e.Row, 1);
				stateRule.State = fpSpread3_Sheet1.GetText(e.Row, 2);
				stateRule.Query = fpSpread3_Sheet1.GetText(e.Row, 3);
				stateRule.Postfix = fpSpread3_Sheet1.GetText(e.Row, 4);
				StateRuleDetailForm stateRuleDetailForm = new StateRuleDetailForm(stateRule);
				DialogResult rusult = stateRuleDetailForm.ShowDialog();

				if (rusult == DialogResult.OK)
				{
					fpSpread3_Sheet1.SetText(stateRule.PriorID, 0, stateRule.PriorID.ToString());
					fpSpread3_Sheet1.SetText(stateRule.PriorID, 1, stateRule.ModuleID);
					fpSpread3_Sheet1.SetText(stateRule.PriorID, 2, stateRule.State);
					fpSpread3_Sheet1.SetText(stateRule.PriorID, 3, stateRule.Query);
					fpSpread3_Sheet1.SetText(stateRule.PriorID, 4, stateRule.Postfix);
				}
			}
		}
		private void fpSpread3_RowDragMoveCompleted(object sender, FarPoint.Win.Spread.DragMoveCompletedEventArgs e)
		{
			SortPriorID();
		}
		private void btnInsert_Click(object sender, EventArgs e)
		{
			StateRuleData stateRule = new StateRuleData();
			stateRule.PriorID = fpSpread3_Sheet1.RowCount;
			StateRuleDetailForm stateRuleDetailForm = new StateRuleDetailForm(stateRule);
			DialogResult rusult = stateRuleDetailForm.ShowDialog();

			if (rusult == DialogResult.OK)
			{
				fpSpread3_Sheet1.RowCount++;
				fpSpread3_Sheet1.SetText(stateRule.PriorID, 0, stateRule.PriorID.ToString());
				fpSpread3_Sheet1.SetText(stateRule.PriorID, 1, stateRule.ModuleID);
				fpSpread3_Sheet1.SetText(stateRule.PriorID, 2, stateRule.State);
				fpSpread3_Sheet1.SetText(stateRule.PriorID, 3, stateRule.Query);
				fpSpread3_Sheet1.SetText(stateRule.PriorID, 4, stateRule.Postfix);
			}
		}
		private void btnDelete_Click(object sender, EventArgs e)
		{
			string moduleID = fpSpread3_Sheet1.GetText(fpSpread3_Sheet1.ActiveCell.Row.Index, 1);
			DialogResult result = MessageBox.Show(moduleID + " StateRule을 정말로 삭제하시겠습니까?", "알림사항", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				fpSpread3_Sheet1.Rows.Remove(fpSpread3_Sheet1.ActiveCell.Row.Index, 1);
				SortPriorID();
			}
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			//Password입력
			PasswordInputForm passwordInputForm = new PasswordInputForm();
			DialogResult passwordResult = passwordInputForm.ShowDialog();
			if (passwordResult != DialogResult.OK) return;

			for (int i = 0; i < fpSpread3_Sheet1.RowCount; i++)
			{
				for (int j = 0; j < fpSpread3_Sheet1.RowCount; j++)
				{
					if (fpSpread3_Sheet1.Cells[i, 1].Text == fpSpread3_Sheet1.Cells[j, 1].Text &&
						fpSpread3_Sheet1.Cells[i, 2].Text == fpSpread3_Sheet1.Cells[j, 2].Text && i != j)
					{
						fpSpread1_Sheet1.SetActiveCell(i, 1);
						MessageBox.Show("동일한 ModuleID의 State 값이 존재합니다. 다시 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}

			List<string> eqStatePriority = new List<string>();
			for (int i = 0; i < fpSpread1_Sheet1.Columns.Count; i++)
				eqStatePriority.Add(fpSpread1_Sheet1.Cells[0, i].Text);

			List<string> procStatePriority = new List<string>();
			for (int i = 0; i < fpSpread2_Sheet1.Columns.Count; i++)
				procStatePriority.Add(fpSpread2_Sheet1.Cells[0, i].Text);

			List<StateRuleData> stateRules = new List<StateRuleData>();
			for (int i = 0; i < fpSpread3_Sheet1.RowCount; i++)
			{
				StateRuleData stateRule = new StateRuleData();
				stateRule.PriorID = int.Parse(fpSpread3_Sheet1.GetText(i, 0));
				stateRule.ModuleID = fpSpread3_Sheet1.GetText(i, 1);
				stateRule.State = fpSpread3_Sheet1.GetText(i, 2);
				stateRule.Query = fpSpread3_Sheet1.GetText(i, 3);
				stateRule.Postfix = fpSpread3_Sheet1.GetText(i, 4);
				stateRules.Add(stateRule);
			}

			LCData.EqStatePriority = eqStatePriority;
			LCData.ProcStatePriority = procStatePriority;
			LCData.StateRules = stateRules;
			this.DialogResult = DialogResult.OK;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}