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
    public partial class LogControl : UserControl
    {
        public LogControl()
        {
            InitializeComponent();
        }


        public void UpdateDisplay(eLINE eLine, string Msg)
        {
            switch (eLine)
            {
                case eLINE.LINE1:
                    {
                        ctlList1.Items.Add(DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss").Replace('-', '/') + ":" + Msg.ToString());
                        ctlList1.SelectedIndex = ctlList1.Items.Count - 1;

                        if (ctlList1.Items.Count > LCData.FindParamLine())
                            ctlList1.Items.RemoveAt(0);
                    }
                    break;
                case eLINE.LINE2:
                    {
                        ctlList2.Items.Add(DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss").Replace('-', '/') + ":" + Msg.ToString());
                        ctlList2.SelectedIndex = ctlList2.Items.Count - 1;

                        if (ctlList2.Items.Count > LCData.FindParamLine())
                            ctlList2.Items.RemoveAt(0);
                    }
                    break;               
            }
        }


        public void Init(eLINE eLine)
        {
            switch (eLine)
            {
                case eLINE.LINE1:ctlList1.Items.Clear();break;
                case eLINE.LINE2:ctlList2.Items.Clear();break;
            }
        }



        //private void ctlList1_MeasureItem_1(object sender, MeasureItemEventArgs e)
        //{
        //    float maxSize = 0.0f;
        //    for (int i = 0; i < ctlList1.Items.Count; i++)
        //    {
        //        float stringSize = e.Graphics.MeasureString(ctlList1.Items[i].ToString(), ctlList1.Font).Width;
        //        if (maxSize < stringSize) maxSize = stringSize;
        //    }

        //    ctlList1.HorizontalExtent = (int)maxSize;
        //}

        //private void ctlList2_MeasureItem_1(object sender, MeasureItemEventArgs e)
        //{
        //    float maxSize = 0.0f;
        //    for (int i = 0; i < ctlList2.Items.Count; i++)
        //    {
        //        float stringSize = e.Graphics.MeasureString(ctlList2.Items[i].ToString(), ctlList2.Font).Width;
        //        if (maxSize < stringSize) maxSize = stringSize;
        //    }

        //    ctlList2.HorizontalExtent = (int)maxSize;
        //}

        //private void ctlList1_DrawItem_1(object sender, DrawItemEventArgs e)
        //{
        //    if (e.Index != -1)
        //    {
        //        e.DrawBackground();
        //        e.Graphics.DrawString(ctlList1.Items[e.Index].ToString(), ctlList1.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y, StringFormat.GenericTypographic);
        //        e.DrawFocusRectangle();
        //    }
        //}

        //private void ctlList2_DrawItem_1(object sender, DrawItemEventArgs e)
        //{
        //    if (e.Index != -1)
        //    {
        //        e.DrawBackground();
        //        e.Graphics.DrawString(ctlList2.Items[e.Index].ToString(), ctlList2.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y, StringFormat.GenericTypographic);
        //        e.DrawFocusRectangle();
        //    }
        //}
    }

}
