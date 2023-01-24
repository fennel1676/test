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
	public partial class StateRuleDetailForm : Form
	{
		private StateRuleData StateRule;

		public StateRuleDetailForm(StateRuleData stateRule)
		{
			InitializeComponent();
			this.StateRule = stateRule;
		}
		private void StateRuleDetailForm_Load(object sender, EventArgs e)
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

			//HeaderCount
			fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread1_Sheet1.ColumnHeader.RowCount = 1;

			//BodyCount
			fpSpread1_Sheet1.RowCount = 1;
			fpSpread1_Sheet1.ColumnCount = 4;

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
			fpSpread1_Sheet1.Columns[3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

			//Width
			fpSpread1_Sheet1.Columns[0].Width = 60.0f;
			fpSpread1_Sheet1.Columns[1].Width = 140.0f;
			fpSpread1_Sheet1.Columns[2].Width = 80.0f;
			fpSpread1_Sheet1.Columns[3].Width = 400.0f;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "PriorID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "ModuleID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "State";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "Query";

			//CellType
			List<string> moduleList = new List<string>();
			foreach (ModuleData module in LCData.Modules)
			{
				if (module.Layer != LCData.ModuleLayer)
				{
					moduleList.Add(module.ID);
				}
			}

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType1.MaxDrop = 15;
			comboType1.Items = moduleList.ToArray();
			fpSpread1_Sheet1.Columns[1].CellType = comboType1;

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType2.Items = new string[] { "PM", "FAULT", "NORMAL", "INIT", "PAUSE", "SETUP", "EXECUTE", "READY", "IDLE" };
			fpSpread1_Sheet1.Columns[2].CellType = comboType2;

			//Lock
			fpSpread1_Sheet1.Columns[0].Locked = true;
			fpSpread1_Sheet1.Columns[3].Locked = true;

			//Visible
			fpSpread1_Sheet1.Columns[0].Visible = false;

			//Body
			fpSpread1_Sheet1.SetText(0, 0, StateRule.PriorID.ToString());
			fpSpread1_Sheet1.SetText(0, 1, StateRule.ModuleID);
			fpSpread1_Sheet1.SetText(0, 2, StateRule.State);
			fpSpread1_Sheet1.SetText(0, 3, StateRule.Query);

			SetComboBoxData();
		}

		private void SetComboBoxData()
		{
			cbModuleID.Items.Clear();
			cbModuleID.Items.Add("");
			ModuleData module = LCData.FindModule(fpSpread1_Sheet1.GetText(0, 1));
			if (module != null)
			{
				foreach (ModuleData childModule in module.Childs)
				{
					cbModuleID.Items.Add(childModule.ID.Substring(childModule.ID.Length - 4, 4));
				}
			}
		}
		private void fpSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
		{
			if (e.Column == 1)
			{
				fpSpread1_Sheet1.SetText(0, 3, "");
				SetComboBoxData();
			}
		}
		private void fpSpread1_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
		{
			if (e.Column == 0) fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column + 1);
			else fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column - 1);
			fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column);
		}
		
		private void cbModuleID_SelectionChangeCommitted(object sender, EventArgs e)
		{
			string query = fpSpread1_Sheet1.GetText(0, 3).Trim();
			if (query == "")
			{
				fpSpread1_Sheet1.SetText(0, 3, cbModuleID.Text);
			}
			else if (query[query.Length - 1] == '(')
			{
				fpSpread1_Sheet1.SetText(0, 3, query + cbModuleID.Text);
			}
			else if (query[query.Length - 1] == '&' || query[query.Length - 1] == '|')
			{
				fpSpread1_Sheet1.SetText(0, 3, query + " " + cbModuleID.Text);
			}
			cbModuleID.Text = "";
		}
		private void btnAND_Click(object sender, EventArgs e)
		{
			string query = fpSpread1_Sheet1.GetText(0, 3).Trim();
			if (query != "" && query[query.Length - 1] != '(' && query[query.Length - 1] != '&' && query[query.Length - 1] != '|')
			{
				fpSpread1_Sheet1.SetText(0, 3, query + " &");
			}
		}
		private void btnOR_Click(object sender, EventArgs e)
		{
			string query = fpSpread1_Sheet1.GetText(0, 3).Trim();
			if (query != "" && query[query.Length - 1] != '(' && query[query.Length - 1] != '&' && query[query.Length - 1] != '|')
			{
				fpSpread1_Sheet1.SetText(0, 3, query + " |");
			}
		}
		private void btnLParen_Click(object sender, EventArgs e)
		{
			string query = fpSpread1_Sheet1.GetText(0, 3).Trim();
			if (query == "")
			{
				fpSpread1_Sheet1.SetText(0, 3, "(");
			}
			else if (query[query.Length - 1] == '(')
			{
				fpSpread1_Sheet1.SetText(0, 3, query + "(");
			}
			else if (query[query.Length - 1] == '&' || query[query.Length - 1] == '|')
			{
				fpSpread1_Sheet1.SetText(0, 3, query + " (");
			}
		}
		private void btnRParen_Click(object sender, EventArgs e)
		{
			string query = fpSpread1_Sheet1.GetText(0, 3).Trim();
			if (query != "" && query[query.Length - 1] != '(' && query[query.Length - 1] != '&' && query[query.Length - 1] != '|')
			{
				fpSpread1_Sheet1.SetText(0, 3, query + ")");
			}
		}
		private void btnBack_Click(object sender, EventArgs e)
		{
			string query = fpSpread1_Sheet1.GetText(0, 3).Trim();
			if (query != "")
			{
				int lastIndex = query.Length - 1;
				if (query[lastIndex] == '(' || query[lastIndex] == ')' || query[lastIndex] == '&' || query[lastIndex] == '|')
				{
					fpSpread1_Sheet1.SetText(0, 3, query.Substring(0, lastIndex));
				}
				else
				{
					for (int i = lastIndex; i >= 0; i--)
					{
						if (query[i] == ' ' || query[i] == '(' || query[i] == ')' || query[i] == '&' || query[i] == '|')
						{
							fpSpread1_Sheet1.SetText(0, 3, query.Substring(0, i + 1));
							break;
						}
						else if (i == 0)
						{
							fpSpread1_Sheet1.SetText(0, 3, "");
						}
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			StateRule.PriorID = int.Parse(fpSpread1_Sheet1.GetText(0, 0));
			StateRule.ModuleID = fpSpread1_Sheet1.GetText(0, 1);
			StateRule.State = fpSpread1_Sheet1.GetText(0, 2);
			StateRule.Query = fpSpread1_Sheet1.GetText(0, 3).Trim();
			StateRule.Postfix = Notation.GetPostFix(StateRule.Query);

			if (StateRule.ModuleID == "")
			{
				fpSpread1_Sheet1.SetActiveCell(0, 1);
				MessageBox.Show("ModuleID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (StateRule.State == "")
			{
				fpSpread1_Sheet1.SetActiveCell(0, 2);
				MessageBox.Show("State 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string state = LCData.GetState(StateRule.Postfix, "NORMAL");
			if (state != "0" && state != "1")
			{
				fpSpread1_Sheet1.SetActiveCell(0, 3);
				MessageBox.Show("Query 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			this.DialogResult = DialogResult.OK;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}