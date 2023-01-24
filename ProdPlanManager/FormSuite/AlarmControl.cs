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
    public partial class AlarmControl : UserControl
    {
        public AlarmControl()
        {
            InitializeComponent();
        }

        public void InitControl()
        {
            //this.Dock = DockStyle.Right;

            //Docking
            AlarmInfoSpread.Dock = DockStyle.Fill;

            //ActiveSkin
            FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(AlarmInfoSpread);

            //Split 설정
            AlarmInfoSpread.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            AlarmInfoSpread.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

            //스크롤바 설정
            AlarmInfoSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            AlarmInfoSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            //TrackPolicy
            AlarmInfoSpread.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

            //TextTipPolicy
            AlarmInfoSpread.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

            //커서 설정
            AlarmInfoSpread.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
            AlarmInfoSpread.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

            //BackColor
            AlarmInfoSpread_Sheet1.GrayAreaBackColor = SystemColors.ControlLight;

            //HeaderCount
            AlarmInfoSpread_Sheet1.RowHeader.ColumnCount = 0;
            AlarmInfoSpread_Sheet1.ColumnHeader.RowCount = 1;

            //BodyCount
            AlarmInfoSpread_Sheet1.RowCount =500;
            AlarmInfoSpread_Sheet1.ColumnCount = 3;

            //Font
            AlarmInfoSpread.Font = new Font("Arial", 8.25f);
            for (int i = 0; i < AlarmInfoSpread_Sheet1.RowHeader.ColumnCount; i++)
                AlarmInfoSpread_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
            for (int i = 0; i < AlarmInfoSpread_Sheet1.ColumnHeader.RowCount; i++)
                AlarmInfoSpread_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

            //Alignment
            for (int i = 0; i < AlarmInfoSpread_Sheet1.ColumnCount; i++)
            {
                AlarmInfoSpread_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                AlarmInfoSpread_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            //Width
            AlarmInfoSpread_Sheet1.Columns[0].Width = 150.0f;
            AlarmInfoSpread_Sheet1.Columns[1].Width = 150.0f;
            AlarmInfoSpread_Sheet1.Columns[2].Width = 370.0f;

            //HeaderText
            AlarmInfoSpread_Sheet1.ColumnHeader.Cells[0, 0].Text = "Time";
            AlarmInfoSpread_Sheet1.ColumnHeader.Cells[0, 1].Text = "ModuleID";
            AlarmInfoSpread_Sheet1.ColumnHeader.Cells[0, 2].Text = "Alarm Description";

            //Lock
            AlarmInfoSpread_Sheet1.Columns[1].Locked = true;
            AlarmInfoSpread_Sheet1.Columns[1].BackColor = Color.WhiteSmoke;

            UpdateDisplay();

            //int height = Sheet.GetHeight(AlarmInfoSpread);
            //btnOK.Top = height + 20;
            //btnCancel.Top = height + 20;
        }
        public void UpdateDisplay()
        {
            int rowCount = 0;
            foreach (AlarmData alarm in LCData.Alarms)
            {
                if (AlarmInfoSpread_Sheet1.RowCount - 1 < rowCount) AlarmInfoSpread_Sheet1.RowCount++;

                string time = alarm.Time.Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/");
                AlarmInfoSpread_Sheet1.SetText(rowCount, 0, time);
                AlarmInfoSpread_Sheet1.SetText(rowCount, 1, alarm.ModuleID);
                AlarmInfoSpread_Sheet1.SetText(rowCount, 2, alarm.Text);
                rowCount++;
            }
            if (rowCount == 0) AlarmInfoSpread_Sheet1.RowCount= 4;
            else
            AlarmInfoSpread_Sheet1.RowCount = rowCount;       
        }
    }
}
