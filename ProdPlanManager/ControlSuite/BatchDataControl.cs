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
    public partial class BatchDataControl : UserControl
    {
        private static bool isOpen = true;
        public BatchDataControl()
        {
            InitializeComponent();
        }
        public void InitControl()
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
            //BackColor
            fpSpread1_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;
            //HeaderCount
            fpSpread1_Sheet1.RowHeader.ColumnCount = 1;
            fpSpread1_Sheet1.ColumnHeader.RowCount = 1;
            //Cursor
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            //BlockOption
            fpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            //ReadOnly
            fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread1_Sheet1.Columns.Default.Resizable = false;
            fpSpread1_Sheet1.Rows.Default.Resizable = false;
            //BodyCount
            fpSpread1_Sheet1.RowCount = 34;
            fpSpread1_Sheet1.ColumnCount = 8;
            //Font
            fpSpread1.Font = new Font("Verdana", 8.25f);
            for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
                fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
                fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Verdana", 8.25f, FontStyle.Bold);
            //Alignment
            for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
            {
                fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            //Cell Type
            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
            for (int i = 0; i < 8; i++)
            {
                fpSpread1_Sheet1.Columns[i].CellType = textType;
            }
            //Width
            fpSpread1_Sheet1.RowHeader.Columns[0].Width = 184.0f;
            fpSpread1_Sheet1.Columns[0].Width = 135.0f;
            fpSpread1_Sheet1.Columns[1].Width = 135.0f;
            fpSpread1_Sheet1.Columns[2].Width = 135.0f;
            fpSpread1_Sheet1.Columns[3].Width = 135.0f;
            fpSpread1_Sheet1.Columns[4].Width = 135.0f;
            fpSpread1_Sheet1.Columns[5].Width = 135.0f;
            fpSpread1_Sheet1.Columns[6].Width = 135.0f;
            fpSpread1_Sheet1.Columns[7].Width = 135.0f;
            //HeaderText
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "Order1";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "Order2";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "Order3";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 3].Text = "Order4";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 4].Text = "Order1";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 5].Text = "Order2";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 6].Text = "Order3";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 7].Text = "Order4";

            fpSpread1_Sheet1.RowHeader.Cells[0, 0].Text = "BATCH STATE";
            fpSpread1_Sheet1.RowHeader.Cells[1, 0].Text = "F PANELID";
            fpSpread1_Sheet1.RowHeader.Cells[2, 0].Text = "END_GLASSID";
            fpSpread1_Sheet1.RowHeader.Cells[3, 0].Text = "C PANELID";
            fpSpread1_Sheet1.RowHeader.Cells[4, 0].Text = "SIZE";
            fpSpread1_Sheet1.RowHeader.Cells[5, 0].Text = "O_QTY";
            fpSpread1_Sheet1.RowHeader.Cells[6, 0].Text = "PRODUCTID";
            fpSpread1_Sheet1.RowHeader.Cells[7, 0].Text = "BATCHID";
            fpSpread1_Sheet1.RowHeader.Cells[8, 0].Text = "P MAKER";
            fpSpread1_Sheet1.RowHeader.Cells[9, 0].Text = "PPID";
            fpSpread1_Sheet1.RowHeader.Cells[10, 0].Text = "PROD TYPE";
            fpSpread1_Sheet1.RowHeader.Cells[11, 0].Text = "START TIME";//최초 START 시점
            fpSpread1_Sheet1.RowHeader.Cells[12, 0].Text = "PROCESSID";
            fpSpread1_Sheet1.RowHeader.Cells[13, 0].Text = "ORDER NO";
            fpSpread1_Sheet1.RowHeader.Cells[14, 0].Text = "PRIORITY";
            fpSpread1_Sheet1.RowHeader.Cells[15, 0].Text = "PROD KIND";
            fpSpread1_Sheet1.RowHeader.Cells[16, 0].Text = "FLOWID";
            fpSpread1_Sheet1.RowHeader.Cells[17, 0].Text = "P THICKNESS";
            fpSpread1_Sheet1.RowHeader.Cells[18, 0].Text = "INPUT LINE";
            fpSpread1_Sheet1.RowHeader.Cells[19, 0].Text = "VALID FLAG";
            fpSpread1_Sheet1.RowHeader.Cells[20, 0].Text = "STEPID";
            fpSpread1_Sheet1.RowHeader.Cells[21, 0].Text = "C_QTY";
            fpSpread1_Sheet1.RowHeader.Cells[22, 0].Text = "R_QTY";
            fpSpread1_Sheet1.RowHeader.Cells[23, 0].Text = "N_QTY";
            fpSpread1_Sheet1.RowHeader.Cells[24, 0].Text = "FLOWGROUP";

            //span
            fpSpread1_Sheet1.RowHeader.Cells[24, 0].RowSpan = 10;
            //Visible            
            for (int i = 13; i < 34; i++)
            {
                fpSpread1_Sheet1.Rows[i].Visible = false;
            }
            //Merge
            //fpSpread1_Sheet1.Cells[11, 0].ColumnSpan = fpSpread1_Sheet1.ColumnCount;
            // Border
            FarPoint.Win.LineBorder border = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 3, false, false, true, false);
            fpSpread1_Sheet1.ColumnHeader.Columns[3].Border = border;
            fpSpread1_Sheet1.Columns[3].Border = border;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 34; j++)
                {
                    if ((j % 2) != 0)
                        fpSpread1_Sheet1.Cells[j, i].BackColor = Color.WhiteSmoke;
                }
            }
        }
        public void UpdateDisplay(eLINE Line)
        {
            BatchManager BatchMng = LCData.FindBatch(Line);
            if (BatchMng != null)
            {
                int StartPos,Index = 0;
                switch (Line)
                {
                    case eLINE.LINE1: StartPos = 0; break;
                    case eLINE.LINE2: StartPos = 4; break;
                    default: return;
                }

                Index = StartPos;
                foreach (BatchObject BatchData in BatchMng.BatchDatas)
                {
                    fpSpread1_Sheet1.SetText(0, Index, string.Format("{0}", BatchData.BATCH_STATE.ToString()));
                    fpSpread1_Sheet1.SetText(1, Index, BatchData.F_PANELID);
                    fpSpread1_Sheet1.SetText(2, Index, BatchData.END_PANELID);
                    fpSpread1_Sheet1.SetText(3, Index, BatchData.C_PANELID);
                    fpSpread1_Sheet1.SetText(4, Index, string.Format("{0}", BatchData.BATCH_SIZE));
                    fpSpread1_Sheet1.SetText(5, Index, string.Format("{0}", BatchData.O_QTY));
                    fpSpread1_Sheet1.SetText(6, Index, BatchData.PRODUCTID);
                    fpSpread1_Sheet1.SetText(7, Index, BatchData.BATCHID);
                    fpSpread1_Sheet1.SetText(8, Index, BatchData.P_MAKER);
                    fpSpread1_Sheet1.SetText(9, Index, BatchData.PPID);
                    fpSpread1_Sheet1.SetText(10, Index, BatchData.PROD_TYPE);
                    fpSpread1_Sheet1.SetText(11, Index, BatchData.StartTime);
                    fpSpread1_Sheet1.SetText(12, Index, BatchData.PROCESSID);
                    fpSpread1_Sheet1.SetText(13, Index, string.Format("{0}", BatchData.ORDER_NO));
                    fpSpread1_Sheet1.SetText(14, Index, string.Format("{0}", BatchData.PRIORITY));
                    fpSpread1_Sheet1.SetText(15, Index, BatchData.PROD_KIND);
                    fpSpread1_Sheet1.SetText(16, Index, BatchData.FLOWID);
                    fpSpread1_Sheet1.SetText(17, Index, string.Format("{0}", BatchData.P_THICKNESS));
                    fpSpread1_Sheet1.SetText(18, Index, BatchData.INPUT_LINE);
                    fpSpread1_Sheet1.SetText(19, Index, string.Format("{0}", BatchData.VALID_FLAG));
                    fpSpread1_Sheet1.SetText(20, Index, BatchData.STEPID);
                    fpSpread1_Sheet1.SetText(21, Index, string.Format("{0}", BatchData.C_QTY));
                    fpSpread1_Sheet1.SetText(22, Index, string.Format("{0}", BatchData.R_QTY));
                    fpSpread1_Sheet1.SetText(23, Index, string.Format("{0}", BatchData.N_QTY)); 

                    int idx = 23;
                    foreach (FlowGroupData group in BatchData.FlowGroups)
                    {
                        fpSpread1_Sheet1.SetText(++idx, Index, string.Format("{0}", group.Binary));
                    }
                    Index++;
                }

                for (int i = 0; i < 34; i++)
                {
                    for (int j = StartPos; j < (StartPos + 4); j++)
                    {
                        if (BatchMng.BatchDatas.Count > (j - StartPos)) continue;
                        fpSpread1_Sheet1.SetText(i, j, "");
                    }
                }
                
            }
        }

        //public void UpdateDisplay(eLINE Line, bool bState)
        //{
        //    BatchManager BatchMng = LCData.FindBatch((short)Line);
        //    if (BatchMng != null)
        //    {
        //        int index = 0;
        //        switch (Line)
        //        {
        //            case eLINE.LINE1: index = 0; break;
        //            case eLINE.LINE2: index = 4; break;
        //            default: return;
        //        }

        //        if (BatchMng.BatchDatas.Count > 0)
        //        {
        //            fpSpread1_Sheet1.SetText(0, index, string.Format("{0}", BatchMng.BatchDatas[0].BATCH_STATE.ToString()));
        //            //fpSpread1_Sheet1.SetText(1, index, BatchData.F_PANELID);
        //            //fpSpread1_Sheet1.SetText(2, index, BatchData.END_PANELID);
        //            fpSpread1_Sheet1.SetText(3, index, BatchMng.BatchDatas[0].C_PANELID);
        //            //fpSpread1_Sheet1.SetText(4, index, string.Format("{0}", BatchData.BATCH_SIZE.ToString()));
        //            fpSpread1_Sheet1.SetText(5, index, string.Format("{0}", BatchMng.BatchDatas[0].O_QTY.ToString()));
        //            //fpSpread1_Sheet1.SetText(6, index, BatchData.PRODUCTID);
        //            //fpSpread1_Sheet1.SetText(7, index, BatchData.BATCHID);
        //            //fpSpread1_Sheet1.SetText(8, index, BatchData.P_MAKER);
        //            //fpSpread1_Sheet1.SetText(9, index, BatchData.PPID);
        //            //fpSpread1_Sheet1.SetText(10, index, BatchData.PROD_TYPE);
        //            //fpSpread1_Sheet1.SetText(11, index, BatchData.StartTime);
        //            //fpSpread1_Sheet1.SetText(12, index, BatchData.PROCESSID);
        //            //fpSpread1_Sheet1.SetText(13, index, string.Format("{0}", BatchData.ORDER_NO.ToString()));
        //            //fpSpread1_Sheet1.SetText(14, index, string.Format("{0}", BatchData.PRIORITY.ToString()));
        //            //fpSpread1_Sheet1.SetText(15, index, BatchData.PROD_KIND);
        //            //fpSpread1_Sheet1.SetText(16, index, BatchData.FLOWID);
        //            //fpSpread1_Sheet1.SetText(17, index, string.Format("{0}", BatchData.P_THICKNESS.ToString()));
        //            //fpSpread1_Sheet1.SetText(18, index, BatchData.INPUT_LINE);
        //            //fpSpread1_Sheet1.SetText(19, index, string.Format("{0}", BatchData.VALID_FLAG.ToString()));
        //            //fpSpread1_Sheet1.SetText(20, index, BatchData.STEPID);
        //            //fpSpread1_Sheet1.SetText(21, index, string.Format("{0}", BatchData.C_QTY.ToString()));
        //            fpSpread1_Sheet1.SetText(22, index, string.Format("{0}", BatchMng.BatchDatas[0].R_QTY.ToString()));
        //            //fpSpread1_Sheet1.SetText(23, index, string.Format("{0}", BatchData.N_QTY.ToString()));

        //            //int idx = 23;
        //            //foreach (FlowGroupData group in BatchData.FlowGroups)
        //            //{
        //            //    fpSpread1_Sheet1.SetText(++idx, index, group.StringList);
        //            //}
        //        }

        //        for (int i = 0; i < 34; i++)
        //        {
        //            for (int j = index; j < (index + 4); j++)
        //            {
        //                if (BatchMng.BatchDatas.Count > (j - index)) continue;
        //                fpSpread1_Sheet1.SetText(i, j, "");
        //            }
        //        }
        //    }
        //}


        private void btnExpandPlanInfo_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                btnExpandPlanInfo.Text = "Return";
                //PlanSpread.Size = new Size(1262, 471);
                fpSpread1.Height += 166;
                this.Height += 166;

                //Visible
                for (int i = 13; i < 34; i++)
                {
                    fpSpread1_Sheet1.Rows[i].Visible = true;
                }
                //btnManualCreate1.Top += 100;
                isOpen = false;
            }
            else
            {
                btnExpandPlanInfo.Text = "More";
                //PlanSpread.Size = new Size(1262, 260);
                fpSpread1.ShowCell(0, 0, 0, 0, FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                fpSpread1.Height -= 166;
                this.Height -= 166;

                for (int i = 13; i < 34; i++)
                {
                    fpSpread1_Sheet1.Rows[i].Visible = false;
                }
                //btnManualCreate1.Top -= 100;
                isOpen = true;
            }
        }
    }


}
