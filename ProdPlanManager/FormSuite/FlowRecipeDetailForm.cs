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
	public partial class FlowRecipeDetailForm : Form
	{
		int flowNo = 0;

		public FlowRecipeDetailForm(int flowNo)
		{
			InitializeComponent();
			this.flowNo = flowNo;
		}
		private void FlowRecipeSettingForm_Load(object sender, EventArgs e)
		{
			//ActiveSkin
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread1);

			//Split 설정
			fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

			//스크롤바 설정
			fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

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
			fpSpread1_Sheet1.RowCount = 10;
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
			fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 4, 1, 4);

			//BodyMerge
			for (int i = 0; i < 5; i++)
				fpSpread1_Sheet1.SetColumnMerge(i, FarPoint.Win.Spread.Model.MergePolicy.Restricted);

			//Alignment
			for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
			{
				fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
				fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			}

			//Width
			fpSpread1_Sheet1.Columns[0].Width = 60.0f;
			fpSpread1_Sheet1.Columns[1].Width = 60.0f;
			fpSpread1_Sheet1.Columns[2].Width = 170.0f;
			fpSpread1_Sheet1.Columns[3].Width = 70.0f;
			fpSpread1_Sheet1.Columns[4].Width = 60.0f;
			fpSpread1_Sheet1.Columns[5].Width = 90.0f;
			fpSpread1_Sheet1.Columns[6].Width = 60.0f;
			fpSpread1_Sheet1.Columns[7].Width = 60.0f;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "FlowNo";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "FlowID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "Description";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "Revisiton";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = "FlowBody";
			fpSpread1_Sheet1.ColumnHeader.Cells[1, 4].Text = "WorkID";
			fpSpread1_Sheet1.ColumnHeader.Cells[1, 5].Text = "WorkType";
			fpSpread1_Sheet1.ColumnHeader.Cells[1, 6].Text = "Operation";
			fpSpread1_Sheet1.ColumnHeader.Cells[1, 7].Text = "Optional";

			//Lock
			fpSpread1_Sheet1.Columns[0].Locked = true;
			fpSpread1_Sheet1.Columns[2].Locked = true;
			fpSpread1_Sheet1.Columns[5].Locked = true;
			fpSpread1_Sheet1.Columns[0].BackColor = Color.WhiteSmoke;
			fpSpread1_Sheet1.Columns[2].BackColor = Color.WhiteSmoke;
			fpSpread1_Sheet1.Columns[5].BackColor = Color.WhiteSmoke;

			//CellType
			string[] operationList = new string[] { eOperation.AND.ToString(), eOperation.OR.ToString(),
													eOperation.BOTH.ToString(), eOperation.END.ToString() };
			string[] optionalReason = new string[] { eOptional.ON.ToString(), eOptional.OFF.ToString() };

			FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

			comboType1.Items = operationList;
			comboType2.Items = optionalReason;
			
			fpSpread1_Sheet1.Columns[3].CellType = textType;
			fpSpread1_Sheet1.Columns[4].CellType = textType;
			fpSpread1_Sheet1.Columns[6].CellType = comboType1;
			fpSpread1_Sheet1.Columns[7].CellType = comboType2;

			//Body
			fpSpread1_Sheet1.Cells[0, 0].RowSpan = 10;
			fpSpread1_Sheet1.Cells[0, 1].RowSpan = 10;
			fpSpread1_Sheet1.Cells[0, 2].RowSpan = 10;
			fpSpread1_Sheet1.Cells[0, 3].RowSpan = 10;
			fpSpread1_Sheet1.Cells[0, 0].Text = flowNo.ToString();

			FlowRecipeData flowRecipe = LCData.GetFlowRecipe(flowNo);
			if (flowRecipe != null)
			{
				int rowCount = 0;
				fpSpread1_Sheet1.SetText(rowCount, 1, flowRecipe.FlowID);
				fpSpread1_Sheet1.SetText(rowCount, 2, LCData.GetMapping(eMappingType.FlowID, flowRecipe.FlowID));
				fpSpread1_Sheet1.SetText(rowCount, 3, flowRecipe.Revision);

				foreach (FlowBodyData flowData in flowRecipe.FlowDatas)
				{
					if (fpSpread1_Sheet1.RowCount - 1 < rowCount) fpSpread1_Sheet1.RowCount++;

					fpSpread1_Sheet1.SetText(rowCount, 4, flowData.WorkID);
					fpSpread1_Sheet1.SetText(rowCount, 5, LCData.GetMapping(eMappingType.WorkID, flowData.WorkID));
					fpSpread1_Sheet1.SetText(rowCount, 6, flowData.Operation.ToString());
					fpSpread1_Sheet1.SetText(rowCount, 7, flowData.Optional.ToString());

					rowCount++;
				}
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
		private int CompareFlowRecipe(FlowRecipeData a, FlowRecipeData b)
		{
			if (a == null)
			{
				if (b == null) return 0;
				else if (b != null) return -1;
			}
			if (b == null) return 1;

			if (a.FlowNo > b.FlowNo) return 1;
			else if (a.FlowNo < b.FlowNo) return -1;

			return 0;
		}

		private void fpSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
		{
			if (e.Column == 1)
			{
				string flowID = fpSpread1_Sheet1.GetText(e.Row, 1).Trim();
				fpSpread1_Sheet1.SetText(e.Row, 2, LCData.GetMapping(eMappingType.FlowID, flowID));
			}
			else if (e.Column == 4)
			{
				string workID = fpSpread1_Sheet1.GetText(e.Row, 4).Trim();
				fpSpread1_Sheet1.SetText(e.Row, 5, LCData.GetMapping(eMappingType.WorkID, workID));
				if (workID == "")
				{
					fpSpread1_Sheet1.SetText(e.Row, 6, "");
					fpSpread1_Sheet1.SetText(e.Row, 7, "");
				}
			}
			else if (e.Column == 6)
			{
				if (fpSpread1_Sheet1.GetText(e.Row, 6) == eOperation.END.ToString())
				{
					for (int i = e.Row + 1; i < 10; i++)
					{
						fpSpread1_Sheet1.SetText(i, 4, "");
						fpSpread1_Sheet1.SetText(i, 6, "");
						fpSpread1_Sheet1.SetText(i, 7, "");
					}
				}
			}
		}
		private void fpSpread1_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
		{
			if (e.Column == 0) fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column + 1);
			else fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column - 1);
			fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			//Password입력
			PasswordInputForm passwordInputForm = new PasswordInputForm();
			DialogResult passwordResult = passwordInputForm.ShowDialog();
			if (passwordResult != DialogResult.OK) return;

			FlowRecipeData flowRecipe = new FlowRecipeData();
			flowRecipe.FlowNo = flowNo;
			flowRecipe.FlowID = fpSpread1_Sheet1.GetText(0, 1).Trim();
			flowRecipe.Revision = fpSpread1_Sheet1.GetText(0, 3).Trim();
			flowRecipe.UpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

			if (flowRecipe.FlowID.Length != 4)
			{
				fpSpread1_Sheet1.SetActiveCell(0, 1);
				MessageBox.Show("FlowID 값을 4자로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (flowRecipe.Revision.Length != 6 || IntParse(flowRecipe.Revision) < 0)
			{
				fpSpread1_Sheet1.SetActiveCell(0, 1);
				MessageBox.Show("Revision 값을 6자리 숫자로 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			for (int i = 0; i < 10; i++)
			{
				if (fpSpread1_Sheet1.GetText(i, 4).Trim() == "") break;

				FlowBodyData flowBody = new FlowBodyData();
				string workID = fpSpread1_Sheet1.GetText(i, 4).Trim();
				string operation = fpSpread1_Sheet1.GetText(i, 6).Trim();
				string optional = fpSpread1_Sheet1.GetText(i, 7).Trim();

				if (!IsBinary(workID, 4))
				{
					fpSpread1_Sheet1.SetActiveCell(i, 4);
					MessageBox.Show("WorkID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (operation == eOperation.AND.ToString()) flowBody.Operation = eOperation.AND;
				else if (operation == eOperation.OR.ToString()) flowBody.Operation = eOperation.OR;
				else if (operation == eOperation.BOTH.ToString()) flowBody.Operation = eOperation.BOTH;
				else if (operation == eOperation.END.ToString()) flowBody.Operation = eOperation.END;
				else
				{
					fpSpread1_Sheet1.SetActiveCell(i, 6);
					MessageBox.Show("Operation 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (optional == eOptional.ON.ToString()) flowBody.Optional = eOptional.ON;
				else if (optional == eOptional.OFF.ToString()) flowBody.Optional = eOptional.OFF;
				else
				{
					fpSpread1_Sheet1.SetActiveCell(i, 7);
					MessageBox.Show("Optional 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				flowBody.WorkID = workID;
				flowRecipe.FlowDatas.Add(flowBody);
			}

			if (flowRecipe.FlowDatas.Count == 0)
			{
				fpSpread1_Sheet1.SetActiveCell(0, 4);
				MessageBox.Show("하나 이상의 공정이 존재하여야합니다.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (flowRecipe.FlowDatas[flowRecipe.FlowDatas.Count - 1].Operation != eOperation.END)
			{
				fpSpread1_Sheet1.SetActiveCell(flowRecipe.FlowDatas.Count - 1, 6);
				MessageBox.Show("마지막 Operation 값은 END가 되어야합니다.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			LCData.SetFlowRecipe(flowRecipe);
			LCData.FlowRecipes.Sort(CompareFlowRecipe);
			this.DialogResult = DialogResult.OK;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}