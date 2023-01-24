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
    public partial class PlanProcessControl : UserControl
    {
        //string data = "";
        public PlanProcessControl()
        {
            InitializeComponent();
        }
        public void InitControl()
        {
          //  //this.Dock = DockStyle.Right;

          //  //Docking
          //  ProcessSpread.Dock = DockStyle.Fill;

          //   //ActiveSkin
          //  FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(ProcessSpread);

          //  //Split 설정
          //  ProcessSpread.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
          //  ProcessSpread.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

          //  //스크롤바 설정
          //  ProcessSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
          //  ProcessSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

          //  //TrackPolicy
          //  ProcessSpread.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

          //  //TextTipPolicy
          //  ProcessSpread.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

          //  //커서 설정
          //  ProcessSpread.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
          //  ProcessSpread.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

          //  //BackColor
          //  ProcessSpread_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

          //  //HeaderCount
          //  ProcessSpread_Sheet1.RowHeader.ColumnCount = 1;
          //  ProcessSpread_Sheet1.ColumnHeader.RowCount = 0;

          //  //BodyCount
          //  ProcessSpread_Sheet1.RowCount = 1;
          //  ProcessSpread_Sheet1.ColumnCount = 2;


          //  //Font
          //  ProcessSpread.Font = new Font("Arial", 8.25f);
          //  for (int i = 0; i < ProcessSpread_Sheet1.RowHeader.ColumnCount; i++)
          //      ProcessSpread_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
          //  for (int i = 0; i < ProcessSpread_Sheet1.ColumnHeader.RowCount; i++)
          //      ProcessSpread_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

          //  //Alignment
          //  //for (int i = 0; i < ProcessSpread_Sheet1.ColumnCount; i++)
          //  //{
          //  //    ProcessSpread_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
          //  //    ProcessSpread_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
          //  //}

          //  //Width
          //  ProcessSpread_Sheet1.RowHeader.Columns[0].Width = 160.0f;
          //  ProcessSpread_Sheet1.Columns[0].Width = 540.0f;
          //  ProcessSpread_Sheet1.Columns[1].Width = 540.0f;

          //  ProcessSpread_Sheet1.Columns[0].
          //  //Height
          //  ProcessSpread_Sheet1.Rows[0].Height = 190.0f;           

          //  //HeaderText
          //  ProcessSpread_Sheet1.RowHeader.Cells[0, 0].Text = "투입 현황";

          //  //Cell Type
          // // FarPoint.Win.Spread.CellType.ListBoxCellType ListType = new FarPoint.Win.Spread.CellType.ListBoxCellType();
          ////  ProcessSpread_Sheet1.Rows[0].CellType = ListType;

            //  //this.Dock = DockStyle.Right;

            //  //Docking
          //   panel1.Dock = DockStyle.Fill;
          //  listBox1.Dock = DockStyle.Fill;
          //  listBox2.Dock = DockStyle.Fill;


           //panel1.Height = 130;
           //panel1.Width = 150;
            //listBox1.Height = 130;
            //listBox1.Width = 540;
            //listBox2.Height = 130;
            //listBox2.Width = 540;
           // listBox2.Margin.Left(1);
            

         //   UpdateDisplay(1, "1호기 투입 가동 중입니다.");
         //   UpdateDisplay(2, "2호기 투입 가동 중입니다.");
          // // UpdateDisplay(1, ".....");
           // UpdateDisplay(2, ".....");


            //int height = Sheet.GetHeight(ProcessSpread);
            //btnOK.Top = height + 20;
            //btnCancel.Top = height + 20;
        }
        public void UpdateDisplay(int Line , string Msg)
        {
            string sTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace('-', '/');
            switch (Line)
            {
                case 1:
                    {
                        listBox1.Items.Add(sTime + ":" + Msg.ToString());
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }
                    break;
                case 2:
                    {
                        listBox2.Items.Add(sTime + ":" + Msg.ToString());                     
                        listBox2.SelectedIndex = listBox2.Items.Count - 1;
                    }
                    break;
            }
        }

        public void ClearDisplay(int Line, string Msg)
        {
            string sTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace('-', '/');

            switch (Line)
            {
                case 1:
                    {
                        this.listBox1.Items.Clear();
                        listBox1.Items.Add(sTime + ":" + Msg.ToString());
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }
                    break;
                case 2:
                    {
                        this.listBox2.Items.Clear();
                        listBox2.Items.Add(sTime + ":" + Msg.ToString());
                        listBox2.SelectedIndex = listBox2.Items.Count - 1;
                    } 
                    break;
            }
        }

      
        private void PlanProcessControl_Load(object sender, EventArgs e)
        {
         

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
