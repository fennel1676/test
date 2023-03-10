using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassCore;


namespace ProdPlanManager
{
    public partial class FlowControlForm : Form
    {



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
        public FlowControlForm()
        {
            InitializeComponent();
        }
        public void InitControl()
        {
           InitFlowGoupControl();
           InitFlowRecipeControl();           
        }
        public void InitFlowGoupControl()
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

            //BackColor
            fpSpread1_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

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
            fpSpread1_Sheet1.ColumnHeader.RowCount = 2;

            //BodyCount
            fpSpread1_Sheet1.RowCount = 2;
            fpSpread1_Sheet1.ColumnCount = 11;

            //Font
            fpSpread1.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            //HeaderMerge
            fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 0, 2, 1);
            fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 1, 2, 1);
            fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 2, 2, 1);
            fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 3, 1, 8);

            //BodyMerge
            fpSpread1_Sheet1.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Restricted);
            fpSpread1_Sheet1.SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Restricted);

            //Alignment
            for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            fpSpread1_Sheet1.Columns[0].Width = 70.0f;
            fpSpread1_Sheet1.Columns[1].Width = 90.0f;
            fpSpread1_Sheet1.Columns[2].Width = 78.0f;
            for (int i = 3; i < 11; i++)
                fpSpread1_Sheet1.Columns[i].Width = 90.0f;

            //HeaderText
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "WorkID";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "WorkType";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "WorkGrp";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "Worker";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 3].Text = "8";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 4].Text = "7";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 5].Text = "6";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 6].Text = "5";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 7].Text = "4";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 8].Text = "3";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 9].Text = "2";
            fpSpread1_Sheet1.ColumnHeader.Cells[1, 10].Text = "1";

            //Lock
            fpSpread1_Sheet1.Columns[1].Locked = true;
            fpSpread1_Sheet1.Columns[1].BackColor = Color.WhiteSmoke;
            for (int i = 3; i < 11; i++)
                fpSpread1_Sheet1.Columns[i].Locked = true;

            //CellType
            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
            fpSpread1_Sheet1.Columns[0].CellType = textType;
            fpSpread1_Sheet1.Columns[2].CellType = textType;

            UpdateFlowGroupDisplay();
        }
        public void InitFlowRecipeControl()
        {
            //this.Dock = DockStyle.Fill;

            //Docking
            //fpSpread1.Dock = DockStyle.Fill;

            //ActiveSkin
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread2);

            //Split 설정
            fpSpread2.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread2.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            fpSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            fpSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            //TrackPolicy
            fpSpread2.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            fpSpread2.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            fpSpread2.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            fpSpread2.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BackColor
            fpSpread2_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

            //BlockOption
            fpSpread2.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            //ReadOnly
            fpSpread2_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;// FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread2_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread2_Sheet1.Columns.Default.Resizable = false;
            fpSpread2_Sheet1.Rows.Default.Resizable = false;

            //HeaderCount
            fpSpread2_Sheet1.RowHeader.ColumnCount = 0;
            fpSpread2_Sheet1.ColumnHeader.RowCount = 2;

            //BodyCount
            fpSpread2_Sheet1.RowCount = 0;
            fpSpread2_Sheet1.ColumnCount = 9;

            //Font
            fpSpread1.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < fpSpread2_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread2_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            for (int i = 0; i < fpSpread2_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread2_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);

            //HeaderMerge
            fpSpread2_Sheet1.Models.ColumnHeaderSpan.Add(0, 0, 2, 1);
            fpSpread2_Sheet1.Models.ColumnHeaderSpan.Add(0, 1, 2, 1);
            fpSpread2_Sheet1.Models.ColumnHeaderSpan.Add(0, 2, 2, 1);
            fpSpread2_Sheet1.Models.ColumnHeaderSpan.Add(0, 3, 2, 1);
            fpSpread2_Sheet1.Models.ColumnHeaderSpan.Add(0, 4, 2, 1);
            fpSpread2_Sheet1.Models.ColumnHeaderSpan.Add(0, 5, 1, 4);

            //BodyMerge
            for (int i = 0; i < 5; i++)
                fpSpread2_Sheet1.SetColumnMerge(i, FarPoint.Win.Spread.Model.MergePolicy.Restricted);

            //Alignment
            for (int i = 0; i < fpSpread2_Sheet1.ColumnCount; i++)
            {
                fpSpread2_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                fpSpread2_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            fpSpread2_Sheet1.Columns[0].Width = 60.0f;
            fpSpread2_Sheet1.Columns[1].Width = 60.0f;
            fpSpread2_Sheet1.Columns[2].Width = 317.0f;
            fpSpread2_Sheet1.Columns[3].Width = 70.0f;
            fpSpread2_Sheet1.Columns[4].Width = 140.0f;
            fpSpread2_Sheet1.Columns[5].Width = 70.0f;
            fpSpread2_Sheet1.Columns[6].Width = 100.0f;
            fpSpread2_Sheet1.Columns[7].Width = 70.0f;
            fpSpread2_Sheet1.Columns[8].Width = 70.0f;

            //HeaderText
            fpSpread2_Sheet1.ColumnHeader.Cells[0, 0].Text = "FlowNo";
            fpSpread2_Sheet1.ColumnHeader.Cells[0, 1].Text = "FlowID";
            fpSpread2_Sheet1.ColumnHeader.Cells[0, 2].Text = "Description";
            fpSpread2_Sheet1.ColumnHeader.Cells[0, 3].Text = "Revision";
            fpSpread2_Sheet1.ColumnHeader.Cells[0, 4].Text = "UpdateTime";
            fpSpread2_Sheet1.ColumnHeader.Cells[0, 5].Text = "FlowBody";
            fpSpread2_Sheet1.ColumnHeader.Cells[1, 5].Text = "WorkID";
            fpSpread2_Sheet1.ColumnHeader.Cells[1, 6].Text = "WorkType";
            fpSpread2_Sheet1.ColumnHeader.Cells[1, 7].Text = "Operation";
            fpSpread2_Sheet1.ColumnHeader.Cells[1, 8].Text = "Optional";

            //CellType
            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
            fpSpread2_Sheet1.Columns[3].CellType = textType;
            fpSpread2_Sheet1.Columns[4].CellType = textType;
            fpSpread2_Sheet1.Columns[5].CellType = textType;

            for (int i = 0; i < fpSpread2_Sheet1.ColumnCount; i++)
            {
                fpSpread2_Sheet1.Columns[i].Locked = true;
            }

            

            UpdateFlowRecipeDisplay();

        }
        public void UpdateFlowGroupDisplay()
        {
            for (int i = 3; i < 11; i++)
                fpSpread1_Sheet1.Columns[i].BackColor = Color.WhiteSmoke;

            int row = 0;
            foreach (FlowGroupData flowGroup in LCData.FlowGroups)
            {
                int workID = Convert.ToInt16(flowGroup.WorkID, 2);
                int workGroup = Convert.ToInt16(flowGroup.WorkGroup, 2);

                fpSpread1_Sheet1.SetText(row, 0, flowGroup.WorkID);
                fpSpread1_Sheet1.SetText(row, 1, LCData.GetMapping(eMappingType.WorkID, flowGroup.WorkID));
                fpSpread1_Sheet1.SetText(row, 2, flowGroup.WorkGroup);

                char[] workers = flowGroup.Worker.ToCharArray();
                int column = 3;
                foreach (char worker in workers)
                {
                    if (worker == '1') fpSpread1_Sheet1.Cells[row, column].BackColor = Color.LightGreen;
                    else fpSpread1_Sheet1.Cells[row, column].BackColor = Color.WhiteSmoke;
                 
                    column++;
                }
                row++;
            }
        }
        public void UpdateFlowRecipeDisplay()
        {
            int rowCount = 0;
            foreach (FlowRecipeData flowRecipe in LCData.FlowRecipes)
            {
				int mergeStartLine = rowCount;
                foreach (FlowBodyData flowData in flowRecipe.FlowDatas)
                {
                    if (fpSpread2_Sheet1.RowCount - 1 < rowCount) fpSpread2_Sheet1.RowCount++;

                    string time = flowRecipe.UpdateTime.Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/");
                    fpSpread2_Sheet1.SetText(rowCount, 0, flowRecipe.FlowNo.ToString());
                    fpSpread2_Sheet1.SetText(rowCount, 1, flowRecipe.FlowID);
                    fpSpread2_Sheet1.SetText(rowCount, 2, LCData.GetMapping(eMappingType.FlowID, flowRecipe.FlowID));
                    fpSpread2_Sheet1.SetText(rowCount, 3, flowRecipe.Revision);
                    fpSpread2_Sheet1.SetText(rowCount, 4, time);
                    fpSpread2_Sheet1.SetText(rowCount, 5, flowData.WorkID);
                    fpSpread2_Sheet1.SetText(rowCount, 6, LCData.GetMapping(eMappingType.WorkID, flowData.WorkID));
                    fpSpread2_Sheet1.SetText(rowCount, 7, flowData.Operation.ToString());
                    fpSpread2_Sheet1.SetText(rowCount, 8, flowData.Optional.ToString());

                    rowCount++;
                }

				int mergeRange = rowCount - mergeStartLine;
				fpSpread2_Sheet1.Cells[mergeStartLine, 0].RowSpan = mergeRange;
				fpSpread2_Sheet1.Cells[mergeStartLine, 1].RowSpan = mergeRange;
				fpSpread2_Sheet1.Cells[mergeStartLine, 2].RowSpan = mergeRange;
				fpSpread2_Sheet1.Cells[mergeStartLine, 3].RowSpan = mergeRange;
				fpSpread2_Sheet1.Cells[mergeStartLine, 4].RowSpan = mergeRange;
            }
            fpSpread2_Sheet1.RowCount = rowCount;

            //int height = Sheet.GetHeight(fpSpread1);
            //btnInsert.Top = height + 20;
            //btnDelete.Top = height + 20;
        }      
        private void fpSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column == 0 || e.Column == 2)
            {
                string workID = fpSpread1_Sheet1.GetText(e.Row, 0).Trim();
                string workGroup = fpSpread1_Sheet1.GetText(e.Row, 2).Trim();
                fpSpread1_Sheet1.SetText(e.Row, 1, LCData.GetMapping(eMappingType.WorkID, workID));

                if (IsBinary(workGroup, 2))
                {
                    int groupNum = Convert.ToInt16(workGroup, 2);

                    for (int i = 3; i < 11; i++)
                    {
                        fpSpread1_Sheet1.Cells[e.Row, i].BackColor = Color.WhiteSmoke;
                        fpSpread1_Sheet1.Cells[e.Row, i].Text = LCData.GetMapping(eMappingType.WorkerID, workID, (groupNum * 8) + (11 - i));
                    }

                    foreach (FlowGroupData flowGroup in LCData.FlowGroups)
                    {
                        if ((workID == flowGroup.WorkID) && (workGroup == flowGroup.WorkGroup))
                        {
                            char[] workers = flowGroup.Worker.ToCharArray();
                            int column = 3;
                            foreach (char worker in workers)
                            {
                                if (worker == '1') fpSpread1_Sheet1.Cells[e.Row, column].BackColor = Color.LightGreen;
                                else fpSpread1_Sheet1.Cells[e.Row, column].BackColor = Color.WhiteSmoke;
                                column++;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 3; i < 11; i++)
                    {
                        fpSpread1_Sheet1.Cells[e.Row, i].Text = "";
                        fpSpread1_Sheet1.Cells[e.Row, i].BackColor = Color.WhiteSmoke;
                    }
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                if (fpSpread1_Sheet1.Cells[i, 0].Text.Trim() == "") continue;
                for (int j = 0; j < fpSpread1_Sheet1.RowCount; j++)
                {
                    if (fpSpread1_Sheet1.Cells[i, 0].Text.Trim().ToUpper() == fpSpread1_Sheet1.Cells[j, 0].Text.Trim().ToUpper() &&
                        fpSpread1_Sheet1.Cells[i, 2].Text.Trim().ToUpper() == fpSpread1_Sheet1.Cells[j, 2].Text.Trim().ToUpper() && i != j)
                    {
                        fpSpread1_Sheet1.SetActiveCell(i, 0);
                        MessageBox.Show("동일한 ID가 존재합니다. 다시 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            List<FlowGroupData> flowGroups = new List<FlowGroupData>();
            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                if (fpSpread1_Sheet1.GetText(i, 0).Trim() != "")
                {
                    string workID = fpSpread1_Sheet1.Cells[i, 0].Text.Trim();
                    string workGroup = fpSpread1_Sheet1.Cells[i, 2].Text.Trim();
                    string worker = "";
                    for (int j = 3; j < 11; j++)
                    {
                        if (fpSpread1_Sheet1.Cells[i, j].BackColor == Color.LightGreen) worker += "1";
                        else worker += "0";
                    }

                    if (!IsBinary(workID, 4))
                    {
                        fpSpread1_Sheet1.SetActiveCell(i, 0);
                        MessageBox.Show("WorkID 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!IsBinary(workGroup, 2))
                    {
                        fpSpread1_Sheet1.SetActiveCell(i, 2);
                        MessageBox.Show("WorkGroup 값을 정확히 입력하여 주십시요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    FlowGroupData flowGroup = new FlowGroupData();
                    flowGroup.WorkID = workID;
                    flowGroup.WorkGroup = workGroup;
                    flowGroup.Worker = worker;
                    flowGroups.Add(flowGroup);
                }
            }
            LCData.FlowGroups = flowGroups;
            this.DialogResult = DialogResult.OK;
        }
        private void FlowControlForm_Load(object sender, EventArgs e)
        {
            InitControl();
        }
        private void FlowControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void FlowControlForm_Activated(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        private void FlowControlForm_Deactivate(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
        private void fpSpread2_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == false)
            {
                int flowNo = int.Parse(fpSpread2_Sheet1.GetText(e.Row, 0));
                FlowRecipeDetailForm flowRecipeForm = new FlowRecipeDetailForm(flowNo);
                DialogResult rusult = flowRecipeForm.ShowDialog();

                if (rusult == DialogResult.OK)
                {
                    UpdateFlowRecipeDisplay();
                    LCData.ModifyFlowRecipeMode = eFlowRecipeMode.Modify;
                    LCData.ModifyFlowRecipe = LCData.GetFlowRecipe(flowNo);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 50; i++)
            {
                FlowRecipeData flowRecipe = LCData.GetFlowRecipe(i);
                if (flowRecipe == null)
                {
                    FlowRecipeDetailForm flowRecipeForm = new FlowRecipeDetailForm(i);
                    DialogResult rusult = flowRecipeForm.ShowDialog();

                    if (rusult == DialogResult.OK)
                    {
                        UpdateFlowRecipeDisplay();
                        LCData.ModifyFlowRecipeMode = eFlowRecipeMode.Create;
                        LCData.ModifyFlowRecipe = LCData.GetFlowRecipe(i);

                        this.DialogResult = DialogResult.OK;
                    }
                    return;
                }
            }
            MessageBox.Show("더이상 추가할수 있는 FlowRecipe가 없습니다.", "알림사항", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int flowNo = int.Parse(fpSpread2_Sheet1.GetText(fpSpread2_Sheet1.ActiveCell.Row.Index, 0));
            DialogResult result = MessageBox.Show(flowNo.ToString() + "번째 FlowRecipe를 정말로 삭제하시겠습니까?", "알림사항", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                FlowRecipeData flowRecipe = LCData.GetFlowRecipe(flowNo);
                LCData.FlowRecipes.Remove(flowRecipe);
                UpdateFlowRecipeDisplay();
                LCData.ModifyFlowRecipeMode = eFlowRecipeMode.Delete;
                LCData.ModifyFlowRecipe = flowRecipe;

                MessageBox.Show("삭제 완료 하였습니다.", "알림사항", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = DialogResult.OK;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}