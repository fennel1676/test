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
    public partial class PortDataControl : UserControl
    {
        public delegate void SelectPortEventHandler(int PortNo);
        public event SelectPortEventHandler SelectPortEvent;

        //private int _portNo = 0;
        public PortDataControl()
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

            //BlockOption
            fpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            //ReadOnly
            fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;// | FarPoint.Win.Spread.OperationMode.Normal;
            fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            //Sizeble
            fpSpread1_Sheet1.Columns.Default.Resizable = false;
            fpSpread1_Sheet1.Rows.Default.Resizable = false;

            //HeaderCount
            fpSpread1_Sheet1.RowHeader.ColumnCount = 1;
            fpSpread1_Sheet1.ColumnHeader.RowCount = 1;


            //BodyCount
            fpSpread1_Sheet1.RowCount = 6;
            fpSpread1_Sheet1.ColumnCount = 4;

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

            //Width
            fpSpread1_Sheet1.RowHeader.Columns[0].Width = 184.0f;
            fpSpread1_Sheet1.Columns[0].Width = 270.0f;
            fpSpread1_Sheet1.Columns[1].Width = 270.0f;
            fpSpread1_Sheet1.Columns[2].Width = 270.0f;
            fpSpread1_Sheet1.Columns[3].Width = 270.0f;


            //HeaderText
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "1 Line";
            fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "2 Line";

            //Column Header 병합
            fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 0, 1, 2);
            fpSpread1_Sheet1.Models.ColumnHeaderSpan.Add(0, 2, 1, 2);

            //HeaderText
            fpSpread1_Sheet1.RowHeader.Cells[0, 0].Text = "CST ID";
            fpSpread1_Sheet1.RowHeader.Cells[1, 0].Text = "PORT ID";
            fpSpread1_Sheet1.RowHeader.Cells[2, 0].Text = "PORT STATE";
            fpSpread1_Sheet1.RowHeader.Cells[3, 0].Text = "BATCH ID";
            fpSpread1_Sheet1.RowHeader.Cells[4, 0].Text = "FLOW ID";
            fpSpread1_Sheet1.RowHeader.Cells[5, 0].Text = "CRATE ID";

            //Lock
            fpSpread1_Sheet1.Rows[0].Locked = true;
            fpSpread1_Sheet1.Rows[1].Locked = true;
            fpSpread1_Sheet1.Rows[2].Locked = true;
            fpSpread1_Sheet1.Rows[3].Locked = true;
            fpSpread1_Sheet1.Rows[4].Locked = true;
            fpSpread1_Sheet1.Rows[5].Locked = true;

            fpSpread1_Sheet1.Rows[0].BackColor = Color.WhiteSmoke;
            fpSpread1_Sheet1.Rows[1].BackColor = Color.WhiteSmoke;
            fpSpread1_Sheet1.Rows[2].BackColor = Color.WhiteSmoke;
            fpSpread1_Sheet1.Rows[3].BackColor = Color.WhiteSmoke;
            fpSpread1_Sheet1.Rows[4].BackColor = Color.WhiteSmoke;
            fpSpread1_Sheet1.Rows[5].BackColor = Color.WhiteSmoke;

            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
            for (int i = 0; i < 4; i++)
            {
                fpSpread1_Sheet1.Columns[i].CellType = textType;
            }

            fpSpread1_Sheet1.Cells[1, 0].BackColor = Color.Ivory;
            fpSpread1_Sheet1.Cells[1, 1].BackColor = Color.Ivory;
            fpSpread1_Sheet1.Cells[1, 2].BackColor = Color.Ivory;
            fpSpread1_Sheet1.Cells[1, 3].BackColor = Color.Ivory;

            // Border
            FarPoint.Win.LineBorder border = new FarPoint.Win.LineBorder(System.Drawing.SystemColors.WindowFrame, 3, false, false, true, false);
            fpSpread1_Sheet1.ColumnHeader.Columns[0].Border = border;
            fpSpread1_Sheet1.Columns[1].Border = border;

            fpSpread1_Sheet1.Cells[1, 0].Text = "IP01";
            fpSpread1_Sheet1.Cells[1, 1].Text = "IP02";
            fpSpread1_Sheet1.Cells[1, 2].Text = "IP03";
            fpSpread1_Sheet1.Cells[1, 3].Text = "IP04";          
        }

        public void UpdateDisplay(int PortNo)
        {
            BatchManager BatchMng = LCData.FindBatch(PortNo);
            if (BatchMng != null)
            {
                int selectPort = ((PortNo -= 1) % 2);

                fpSpread1_Sheet1.SetText(0, PortNo, BatchMng.PortDatas[selectPort].Port.CstID);
                fpSpread1_Sheet1.SetText(2, PortNo, BatchMng.PortDatas[selectPort].Port.PortState.ToString());

                switch (BatchMng.PortDatas[selectPort].Port.PortState)
                {
                    case ePortState.Empty: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(191, 191, 190); break;
                    case ePortState.Idle: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(255, 255, 130); break;
                    case ePortState.Ready: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(126, 255, 130); break;
                    case ePortState.Wait: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(255, 253, 0); break;
                    case ePortState.Reserve: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(129, 254, 255); break;
                    case ePortState.Busy: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(0, 255, 0); break;
                    case ePortState.Complete: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(0, 251, 235); break;
                    case ePortState.Abort: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(255, 0, 255); break;
                    case ePortState.Cancel: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(255, 253, 0); break;
                    case ePortState.Pause: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(255, 128, 1); break;
                    case ePortState.Disable: fpSpread1_Sheet1.Cells[2, PortNo].BackColor = Color.FromArgb(130, 0, 255); break;
                }

                if (BatchMng.PortDatas[selectPort].Cassette != null && BatchMng.PortDatas[selectPort].Cassette.GlassDatas.Count != 0)
                {
                    fpSpread1_Sheet1.SetText(3, PortNo, BatchMng.PortDatas[selectPort].Cassette.GlassDatas[0].BatchID);
                    fpSpread1_Sheet1.SetText(4, PortNo, BatchMng.PortDatas[selectPort].Cassette.GlassDatas[0].FlowID + "(" + BatchMng.PortDatas[selectPort].Cassette.GlassDatas[0].FlowGroupName + ")");
                    fpSpread1_Sheet1.SetText(5, PortNo, BatchMng.PortDatas[selectPort].Cassette.GlassDatas[0].PanelPairProp.PairProductID);
                }
                else
                {
                    fpSpread1_Sheet1.SetText(3, PortNo, "");
                    fpSpread1_Sheet1.SetText(4, PortNo, "");
                    fpSpread1_Sheet1.SetText(5, PortNo, "");

                }
            }
        }
        private void btnColorState_Click(object sender, EventArgs e)
        {
            DisplayPortState StateForm = new DisplayPortState();
            DialogResult rusult = StateForm.ShowDialog();
        }

        private void fpSpread1_MouseMove(object sender, MouseEventArgs e)
        {
            FarPoint.Win.Spread.Model.CellRange cr = fpSpread1.GetCellFromPixel(0, 0, e.X, e.Y);

            for (int i = 0; i < 4; i++)
            {
                fpSpread1_Sheet1.Cells[0, i].BackColor = Color.WhiteSmoke;
                fpSpread1_Sheet1.Cells[3, i].BackColor = Color.WhiteSmoke;
                fpSpread1_Sheet1.Cells[4, i].BackColor = Color.WhiteSmoke;
                fpSpread1_Sheet1.Cells[5, i].BackColor = Color.WhiteSmoke;
            }
            switch (cr.Column)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    {
                        fpSpread1_Sheet1.Cells[0, cr.Column].BackColor = Color.Khaki;
                        fpSpread1_Sheet1.Cells[3, cr.Column].BackColor = Color.Khaki;
                        fpSpread1_Sheet1.Cells[4, cr.Column].BackColor = Color.Khaki;
                        fpSpread1_Sheet1.Cells[5, cr.Column].BackColor = Color.Khaki;
                    }
                    break;
            }        
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == false && e.RowHeader == false)
            {
                SelectPortEvent(e.Column + 1);
            }        
        }
    }
}
