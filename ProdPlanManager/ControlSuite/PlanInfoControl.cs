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
    public partial class PlanInfoControl : UserControl
    {
        private bool isOpen = false;

        public PlanInfoControl()
        {
            InitializeComponent();
        }
        public void InitControl()
        {
            //this.Dock = DockStyle.Right;

            //Docking
            //PlanSpread.Dock = DockStyle.Fill;

            //ActiveSkin
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(PlanSpread);
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(InputSpread);

            //Split 설정
            PlanSpread.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            PlanSpread.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            InputSpread.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            InputSpread.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            PlanSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            PlanSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            InputSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            InputSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //TrackPolicy
            PlanSpread.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            InputSpread.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            PlanSpread.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
            InputSpread.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            PlanSpread.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            PlanSpread.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);
            InputSpread.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            InputSpread.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BackColor
            PlanSpread_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;
            InputSpread_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;


            //HeaderCount
            PlanSpread_Sheet1.RowHeader.ColumnCount = 1;
            PlanSpread_Sheet1.ColumnHeader.RowCount = 1;
            InputSpread_Sheet1.RowHeader.ColumnCount = 1;
            InputSpread_Sheet1.ColumnHeader.RowCount = 1;

            //Cursor
            PlanSpread.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            InputSpread.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);

            //ReadOnly
            PlanSpread_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            InputSpread_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;

            //SelectionUnit
            PlanSpread_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            InputSpread_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;


            //BodyCount
            PlanSpread_Sheet1.RowCount = 34;
            PlanSpread_Sheet1.ColumnCount = 8;
            InputSpread_Sheet1.RowCount = 4;
            InputSpread_Sheet1.ColumnCount = 2;


            //Font
            PlanSpread.Font = new Font("Arial", 8.25f);
            for (int i = 0; i < PlanSpread_Sheet1.RowHeader.ColumnCount; i++)
                PlanSpread_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

            for (int i = 0; i < PlanSpread_Sheet1.ColumnHeader.RowCount; i++)
                PlanSpread_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

            InputSpread.Font = new Font("Arial", 8.25f);
            for (int i = 0; i < InputSpread_Sheet1.RowHeader.ColumnCount; i++)
                InputSpread_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

            for (int i = 0; i < InputSpread_Sheet1.ColumnHeader.RowCount; i++)
                InputSpread_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < PlanSpread_Sheet1.ColumnCount; i++)
            {
                PlanSpread_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                PlanSpread_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            for (int i = 0; i < InputSpread_Sheet1.ColumnCount; i++)
            {
                InputSpread_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                InputSpread_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            PlanSpread_Sheet1.RowHeader.Columns[0].Width = 160.0f;

            PlanSpread_Sheet1.Columns[0].Width = 135.0f;
            PlanSpread_Sheet1.Columns[1].Width = 135.0f;
            PlanSpread_Sheet1.Columns[2].Width = 135.0f;
            PlanSpread_Sheet1.Columns[3].Width = 135.0f;
            PlanSpread_Sheet1.Columns[4].Width = 135.0f;
            PlanSpread_Sheet1.Columns[5].Width = 135.0f;
            PlanSpread_Sheet1.Columns[6].Width = 135.0f;
            PlanSpread_Sheet1.Columns[7].Width = 135.0f;


            InputSpread_Sheet1.RowHeader.Columns[0].Width = 160.0f;
            InputSpread_Sheet1.Columns[0].Width = 540.0f;
            InputSpread_Sheet1.Columns[1].Width = 540.0f;

            //HeaderText
            PlanSpread_Sheet1.ColumnHeader.Cells[0, 0].Text = "Order1";
            PlanSpread_Sheet1.ColumnHeader.Cells[0, 1].Text = "Order2";
            PlanSpread_Sheet1.ColumnHeader.Cells[0, 2].Text = "Order3";
            PlanSpread_Sheet1.ColumnHeader.Cells[0, 3].Text = "Order4";
            PlanSpread_Sheet1.ColumnHeader.Cells[0, 4].Text = "Order1";
            PlanSpread_Sheet1.ColumnHeader.Cells[0, 5].Text = "Order2";
            PlanSpread_Sheet1.ColumnHeader.Cells[0, 6].Text = "Order3";
            PlanSpread_Sheet1.ColumnHeader.Cells[0, 7].Text = "Order4";

            PlanSpread_Sheet1.RowHeader.Cells[0, 0].Text = "BATCH STATE";
            PlanSpread_Sheet1.RowHeader.Cells[1, 0].Text = "C PANELID";
            PlanSpread_Sheet1.RowHeader.Cells[2, 0].Text = "PRODUCTID";
            PlanSpread_Sheet1.RowHeader.Cells[3, 0].Text = "B1ATCHID";
            PlanSpread_Sheet1.RowHeader.Cells[4, 0].Text = "STEPID";
            PlanSpread_Sheet1.RowHeader.Cells[5, 0].Text = "PPID";
            PlanSpread_Sheet1.RowHeader.Cells[6, 0].Text = "F PANELID";
            PlanSpread_Sheet1.RowHeader.Cells[7, 0].Text = "SIZE";
            PlanSpread_Sheet1.RowHeader.Cells[8, 0].Text = "P MAKER";
            PlanSpread_Sheet1.RowHeader.Cells[9, 0].Text = "PROD TYPE";
            PlanSpread_Sheet1.RowHeader.Cells[10, 0].Text = "START TIME";//최초 START 시점
            PlanSpread_Sheet1.RowHeader.Cells[11, 0].Text = "More";
            PlanSpread_Sheet1.RowHeader.Cells[12, 0].Text = "ORDER NO";
            PlanSpread_Sheet1.RowHeader.Cells[13, 0].Text = "PRIORITY";
            PlanSpread_Sheet1.RowHeader.Cells[14, 0].Text = "PROD KIND";
            PlanSpread_Sheet1.RowHeader.Cells[15, 0].Text = "PROCESSID";
            PlanSpread_Sheet1.RowHeader.Cells[16, 0].Text = "FLOWID";
            PlanSpread_Sheet1.RowHeader.Cells[17, 0].Text = "P THICKNESS";
            PlanSpread_Sheet1.RowHeader.Cells[18, 0].Text = "INPUT LINE";
            PlanSpread_Sheet1.RowHeader.Cells[19, 0].Text = "VALID FLAG";
            PlanSpread_Sheet1.RowHeader.Cells[20, 0].Text = "C QTY";
            PlanSpread_Sheet1.RowHeader.Cells[21, 0].Text = "O QTY";
            PlanSpread_Sheet1.RowHeader.Cells[22, 0].Text = "R QTY";
            PlanSpread_Sheet1.RowHeader.Cells[23, 0].Text = "N QTY";
            PlanSpread_Sheet1.RowHeader.Cells[24, 0].Text = "FLOWGROUP";

            InputSpread_Sheet1.ColumnHeader.Cells[0, 0].Text = "Line#01 투입제어";
            InputSpread_Sheet1.ColumnHeader.Cells[0, 1].Text = "Line#02 투입제어";
            InputSpread_Sheet1.RowHeader.Cells[0, 0].Text = "한계재공";
            InputSpread_Sheet1.RowHeader.Cells[1, 0].Text = "현재재공";
            InputSpread_Sheet1.RowHeader.Cells[2, 0].Text = "투입필요";
            InputSpread_Sheet1.RowHeader.Cells[3, 0].Text = "투입모드";

            //span
            PlanSpread_Sheet1.RowHeader.Cells[24, 0].RowSpan = 10;


            PlanSpread_Sheet1.RowHeader.Cells[11, 0].Text = "...";

            //Visible
            for (int i = 12; i < 34; i++)
            {
                PlanSpread_Sheet1.Rows[i].Visible = false;
            }

            //Merge
            PlanSpread_Sheet1.Cells[11, 0].ColumnSpan = PlanSpread_Sheet1.ColumnCount;

            //BodyTest
            PlanSpread_Sheet1.Cells[11, 0].Text = "More...";

            UpdateDisplay();

            //int height = Sheet.GetHeight(PlanSpread);
            //btnL1PlanCreate.Top = height + 20;
            //btnL2PlanCreate.Top = height + 20;
        }

       

        public void UpdateDisplay()
        {
            int colCount = 0;

            if (LCData.PlanInfos1 != null)
            {                
                foreach (ProdPlanInfoData Plan in LCData.PlanInfos1)
                {
                    //if (PlanSpread_Sheet1.RowCount - 1 < colCount) PlanSpread_Sheet1.ColumnCount++;

                    string BatchState = "";

                    switch (Plan.BATCH_STATE)
                    {
                        case 0: BatchState = "Wait"; break;
                        case 1: BatchState = "Busy"; break;
                        case 2: BatchState = "Complete"; break;
                    }

                    PlanSpread_Sheet1.SetText(0, colCount, BatchState);
                    PlanSpread_Sheet1.SetText(1, colCount, Plan.C_PANELID);
                    PlanSpread_Sheet1.SetText(2, colCount, Plan.PRODUCTID);
                    PlanSpread_Sheet1.SetText(3, colCount, Plan.BATCHID);
                    PlanSpread_Sheet1.SetText(4, colCount, Plan.STEPID);
                    PlanSpread_Sheet1.SetText(5, colCount, Plan.PPID);
                    PlanSpread_Sheet1.SetText(6, colCount, Plan.F_PANELID);
                    PlanSpread_Sheet1.SetText(7, colCount, Plan.BATCH_SIZE.ToString());
                    PlanSpread_Sheet1.SetText(8, colCount, Plan.P_MAKER);
                    PlanSpread_Sheet1.SetText(9, colCount, Plan.PROD_TYPE);

                   // PlanSpread_Sheet1.SetText(10, colCount, "2008-09-12 24:00:30");
                    PlanSpread_Sheet1.SetText(12, colCount, Plan.ORDER_NO.ToString());
                    PlanSpread_Sheet1.SetText(13, colCount, Plan.PRIORITY.ToString());
                    PlanSpread_Sheet1.SetText(14, colCount, Plan.PROD_KIND);
                    PlanSpread_Sheet1.SetText(15, colCount, Plan.PROCESSID);
                    PlanSpread_Sheet1.SetText(16, colCount, Plan.FLOWID);
                    PlanSpread_Sheet1.SetText(17, colCount, Plan.P_THICKNESS.ToString());
                    PlanSpread_Sheet1.SetText(18, colCount, Plan.INPUT_LINE);
                    PlanSpread_Sheet1.SetText(19, colCount, Plan.VALID_FLAG.ToString());
                    PlanSpread_Sheet1.SetText(20, colCount, Plan.C_QTY.ToString());
                    PlanSpread_Sheet1.SetText(21, colCount, Plan.O_QTY.ToString());
                    PlanSpread_Sheet1.SetText(22, colCount, Plan.R_QTY.ToString());
                    PlanSpread_Sheet1.SetText(23, colCount, Plan.N_QTY.ToString());

                    int n = 0;
                    string strFlowGrp = "";
                    foreach (FlowGroupData Groups in Plan.FlowGroups)
                    {
                        foreach (bool bn in Groups.FlowList)
                        {
                            strFlowGrp += bn.ToString() + " ";
                        }

                        PlanSpread_Sheet1.SetText(24 + n, colCount, strFlowGrp.Trim()); n++;
                    }                   
                    colCount++;   
                }
            }

            colCount=4;

            if (LCData.PlanInfos2 != null)
            {
                foreach (ProdPlanInfoData Plan in LCData.PlanInfos2)
                {
                    //if (PlanSpread_Sheet1.RowCount - 1 < colCount) PlanSpread_Sheet1.ColumnCount++;

                    string BatchState = "";

                    switch (Plan.BATCH_STATE)
                    {
                        case 0: BatchState = "Wait"; break;
                        case 1: BatchState = "Busy"; break;
                        case 2: BatchState = "Complete"; break;
                    }

                    PlanSpread_Sheet1.SetText(0, colCount, BatchState);
                    PlanSpread_Sheet1.SetText(1, colCount, Plan.C_PANELID);
                    PlanSpread_Sheet1.SetText(2, colCount, Plan.PRODUCTID);
                    PlanSpread_Sheet1.SetText(3, colCount, Plan.BATCHID);
                    PlanSpread_Sheet1.SetText(4, colCount, Plan.STEPID);
                    PlanSpread_Sheet1.SetText(5, colCount, Plan.PPID);
                    PlanSpread_Sheet1.SetText(6, colCount, Plan.F_PANELID);
                    PlanSpread_Sheet1.SetText(7, colCount, Plan.BATCH_SIZE.ToString());
                    PlanSpread_Sheet1.SetText(8, colCount, Plan.P_MAKER);
                    PlanSpread_Sheet1.SetText(9, colCount, Plan.PROD_TYPE);



                   // PlanSpread_Sheet1.SetText(10, colCount, "2008-09-12 24:00:30");
                    PlanSpread_Sheet1.SetText(12, colCount, Plan.ORDER_NO.ToString());
                    PlanSpread_Sheet1.SetText(13, colCount, Plan.PRIORITY.ToString());
                    PlanSpread_Sheet1.SetText(14, colCount, Plan.PROD_KIND);
                    PlanSpread_Sheet1.SetText(15, colCount, Plan.PROCESSID);
                    PlanSpread_Sheet1.SetText(16, colCount, Plan.FLOWID);
                    PlanSpread_Sheet1.SetText(17, colCount, Plan.P_THICKNESS.ToString());
                    PlanSpread_Sheet1.SetText(18, colCount, Plan.INPUT_LINE);
                    PlanSpread_Sheet1.SetText(19, colCount, Plan.VALID_FLAG.ToString());
                    PlanSpread_Sheet1.SetText(20, colCount, Plan.C_QTY.ToString());
                    PlanSpread_Sheet1.SetText(21, colCount, Plan.O_QTY.ToString());
                    PlanSpread_Sheet1.SetText(22, colCount, Plan.R_QTY.ToString());
                    PlanSpread_Sheet1.SetText(23, colCount, Plan.N_QTY.ToString());

                    int n = 0;
                    string strFlowGrp = "";
                    foreach (FlowGroupData Groups in Plan.FlowGroups)
                    {
                        foreach (bool bn in Groups.FlowList)
                        {
                            strFlowGrp += bn.ToString() + " ";
                        }

                        PlanSpread_Sheet1.SetText(24 + n, colCount, strFlowGrp.Trim()); n++;
                    }
                    colCount++;
                }
            }

        }



        public void UpdateStartTime(int nIndex)
        {
            if (nIndex == 9)
            {
                PlanSpread_Sheet1.SetText(10, nIndex, "");   
            }
             string sTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace('-', '/');
             PlanSpread_Sheet1.SetText(10, nIndex, sTime);   
        }

        private void PlanSpread_MouseLeave(object sender, EventArgs e)
        {
            if (isOpen)
            {
                PlanSpread_Sheet1.Rows[11].Visible = true;
                for (int i = 12; i < 33; i++)
                {
                    PlanSpread_Sheet1.Rows[i].Visible = false;
                }
                PlanSpread.Height = 243;
                isOpen = false;
            }
        }

        private void PlanSpread_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row == 11)
            {
                PlanSpread_Sheet1.Rows[11].Visible = false;
                for (int i = 12; i < 33; i++)
                {
                    PlanSpread_Sheet1.Rows[i].Visible = true;
                }

               // int height = Sheet.GetHeight(PlanSpread);
                PlanSpread.Height = 400;
                isOpen = true;
            }
        }

        private void btnL1PlanRequest_Click(object sender, EventArgs e)
        {

        }

        private void PlanSpread_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == false && e.RowHeader == false)
            {
                if (e.Row >= 24 && e.Row < 34)
                {
                    FlowGroupDetailForm Form = new FlowGroupDetailForm(e.Column);
                    DialogResult rusult = Form.ShowDialog();

                    if (rusult == DialogResult.OK)
                    {

                        //sqlManager.SetEqStatePriority(LCData.EqStatePriority);
                        //sqlManager.SetProcStatePriority(LCData.ProcStatePriority);
                        //sqlManager.SetStateRules(LCData.StateRules);
                        //SetMessage("StateRule 설정값을 변경하였습니다.", true);
                    }

                    //PlanSpread_Sheet1.Rows[11].Visible = false;
                    //for (int i = 12; i < 33; i++)
                    //{
                    //    PlanSpread_Sheet1.Rows[i].Visible = true;
                    //}

                    //// int height = Sheet.GetHeight(PlanSpread);
                    //PlanSpread.Height = 400;
                    //isOpen = true;
                }
            }
        }      
    }
}
