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
    public partial class CstControl : UserControl
    {
        public CstControl()
        {
            InitializeComponent();
        }

        public void InitControl()
        {
           // this.Dock = DockStyle.Right;

            //Docking
            //CstSpread.Dock = DockStyle.Fill;

            //ActiveSkin
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(CstSpread);

            //Split 설정
            CstSpread.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            CstSpread.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            CstSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            CstSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //TrackPolicy
            CstSpread.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            CstSpread.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            CstSpread.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            CstSpread.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BackColor
            CstSpread_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

            //HeaderCount
            CstSpread_Sheet1.RowHeader.ColumnCount = 1;
            CstSpread_Sheet1.ColumnHeader.RowCount = 2;


            //BodyCount
            CstSpread_Sheet1.RowCount =6;
            CstSpread_Sheet1.ColumnCount = 4;

            //HeaderMerge
            CstSpread_Sheet1.Models.ColumnHeaderSpan.Add(0, 0, 1, 2);
            CstSpread_Sheet1.Models.ColumnHeaderSpan.Add(0, 1, 1, 2);
            CstSpread_Sheet1.Models.ColumnHeaderSpan.Add(0, 2, 1, 2);
            CstSpread_Sheet1.Models.ColumnHeaderSpan.Add(0, 3, 1, 4);

            //Font
            CstSpread.Font = new Font("Arial", 8.25f);
            for (int i = 0; i < CstSpread_Sheet1.RowHeader.ColumnCount; i++)
                CstSpread_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
            for (int i = 0; i < CstSpread_Sheet1.ColumnHeader.RowCount; i++)
                CstSpread_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < CstSpread_Sheet1.ColumnCount; i++)
            {
                CstSpread_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                CstSpread_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            CstSpread_Sheet1.RowHeader.Columns[0].Width = 160.0f;
            CstSpread_Sheet1.Columns[0].Width = 270.0f;
            CstSpread_Sheet1.Columns[1].Width = 270.0f;
            CstSpread_Sheet1.Columns[2].Width = 270.0f;
            CstSpread_Sheet1.Columns[3].Width = 270.0f;
   
            //HeaderText
            CstSpread_Sheet1.ColumnHeader.Cells[0, 0].Text = "Line #01";
            //CstSpread_Sheet1.ColumnHeader.Cells[0, 1].Text = "Line #01";
            CstSpread_Sheet1.ColumnHeader.Cells[0, 2].Text = "Line #02";
            //CstSpread_Sheet1.ColumnHeader.Cells[0, 3].Text = "Line #02";
            CstSpread_Sheet1.ColumnHeader.Cells[1, 0].Text = "PORT 1";
            CstSpread_Sheet1.ColumnHeader.Cells[1, 1].Text = "PORT 2";
            CstSpread_Sheet1.ColumnHeader.Cells[1, 2].Text = "PORT 3";
            CstSpread_Sheet1.ColumnHeader.Cells[1, 3].Text = "PORT 4";


            //HeaderText
            CstSpread_Sheet1.RowHeader.Cells[0, 0].Text = "CST ID";
            CstSpread_Sheet1.RowHeader.Cells[1, 0].Text = "PORT ID";
            CstSpread_Sheet1.RowHeader.Cells[2, 0].Text = "PORT STATE";
            CstSpread_Sheet1.RowHeader.Cells[3, 0].Text = "BATCH ID";
            CstSpread_Sheet1.RowHeader.Cells[4, 0].Text = "FLOW ID";
            CstSpread_Sheet1.RowHeader.Cells[5, 0].Text = "CRATE ID";

            //Lock
            //CstSpread_Sheet1.Columns[0].Locked = true;
            //CstSpread_Sheet1.Columns[1].Locked = true;
            //CstSpread_Sheet1.Columns[2].Locked = true;
            //CstSpread_Sheet1.Columns[3].Locked = true;
            //CstSpread_Sheet1.Columns[0].BackColor = Color.WhiteSmoke;
            //CstSpread_Sheet1.Columns[1].BackColor = Color.WhiteSmoke;
            //CstSpread_Sheet1.Columns[2].BackColor = Color.WhiteSmoke;
            //CstSpread_Sheet1.Columns[3].BackColor = Color.WhiteSmoke;

            //Border
         //   FarPoint.Win.LineBorder border = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 3, false, false, true, false);
         //   CstSpread_Sheet1.ColumnHeader.Columns[1].Border = border;
         //   CstSpread_Sheet1.Columns[1].Border = border;

            UpdatePortInfoDisplay();

            //int height = Sheet.GetHeight(CstSpread);
            //btnOK.Top = height + 20;
            //btnCancel.Top = height + 20;
        }

        public void UpdateCstInfoDisplay()
        {
            int colCount = 0;

            if (LCData.CstInfos != null)
            {

                foreach (CassetteInfoData Info in LCData.CstInfos)
                {
                    if (Info.Port.PortID == "IP02") colCount = 1;
                    else if (Info.Port.PortID == "IP03") colCount = 2;
                    else if (Info.Port.PortID == "IP04") colCount = 3;
                    else if (Info.Port.PortID == "IP01") colCount = 0;

                    CstSpread_Sheet1.SetText(3, colCount, Info.GlassDatas[0].BatchID);
                    CstSpread_Sheet1.SetText(4, colCount, Info.GlassDatas[0].FlowID);
                    CstSpread_Sheet1.SetText(5, colCount, Info.GlassDatas[0].PanelPairProp.PairProductID);
                }
            }            
        }

        public void UpdatePortInfoDisplay()
        {
            int colCount = 0;

            if (LCData.PortInfos != null)
            {

                foreach (PortInfoData Info in LCData.PortInfos)
                {
                    if (Info.PortID == "IP02") colCount = 1;
                    else if (Info.PortID == "IP03") colCount = 2;
                    else if (Info.PortID == "IP04") colCount = 3;
                    else colCount = 0;



                    //if (CstSpread_Sheet1.RowCount - 1 < colCount) CstSpread_Sheet1.ColumnCount++;

                    CstSpread_Sheet1.SetText(0, colCount, Info.Current.CstID);
                    CstSpread_Sheet1.SetText(1, colCount, Info.PortID);
                   // CstSpread_Sheet1.SetText(2, colCount, Info.Current.PortState.ToString());


                    switch (Info.Current.PortState)
                    {
                        case eMPortState.Empty: CstSpread_Sheet1.SetText(2, colCount, "Empty"); break;
                        case eMPortState.Idle: CstSpread_Sheet1.SetText(2, colCount, "Idle"); break;
                        case eMPortState.Ready: CstSpread_Sheet1.SetText(2, colCount, "Ready"); break;
                        case eMPortState.Wait: CstSpread_Sheet1.SetText(2, colCount, "Wait"); break;
                        case eMPortState.Reserve: CstSpread_Sheet1.SetText(2, colCount, "Reserve"); break;
                        case eMPortState.Busy: CstSpread_Sheet1.SetText(2, colCount, "Busy"); break;
                        case eMPortState.Complete: CstSpread_Sheet1.SetText(2, colCount, "Complete"); break;
                        case eMPortState.Abort: CstSpread_Sheet1.SetText(2, colCount, "Abort"); break;
                        case eMPortState.Cancel: CstSpread_Sheet1.SetText(2, colCount, "Cancel"); break;
                        case eMPortState.Pause: CstSpread_Sheet1.SetText(2, colCount, "Pause"); break;
                        case eMPortState.Disable: CstSpread_Sheet1.SetText(2, colCount, "Disable"); break;
                    }

                    //colCount++;
                }
            }
            
        }

        private void CstSpread_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == false  && e.RowHeader == false)
            {                
                PortInputForm PortForm = new PortInputForm(e.Column);
                DialogResult rusult = PortForm.ShowDialog();

                if (rusult == DialogResult.OK)
                {


                    UpdatePortInfoDisplay();
                    this.OnRegionChanged(EventArgs.Empty);
                }
            }
        }


    }
    
}
