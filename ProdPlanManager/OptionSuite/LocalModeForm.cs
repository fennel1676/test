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
    public partial class LocalModeForm : Form
    {
        //int i = 0;

        public C14ProcessPortCmd ProcCmd = null;
        public LocalModeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PortInfoData Port = LCData.FindPort("IP01");


            ModuleData module = LCData.FindModule(Port.ModuleID);

            if (module != null)
            {
                ProcCmd = new C14ProcessPortCmd();

                ProcCmd.Target.SrcEq = "LC";
                ProcCmd.Target.SrcUnit = "N/A";
                ProcCmd.Target.DesEq = module.EqID;
                ProcCmd.Target.DesUnit = module.UnitID;//해당 되는 Unit에 Command 전송.

                ProcCmd.PortNo = 1;
                ProcCmd.Command = eRCMD.JobProcessStart;

                CassetteInfoData CstInfo = LCData.FindCassette(Port.CstID);
                if (CstInfo != null)
                {
                    ProcCmd.CstID = CstInfo.CstID;

                    //CassetteInfoData CstInfo = LCData.FindCassette(recv.IPID); //MapStif가 내려오지 않으므로, CassetteID와 동일한 Cassette 정보에서 MapStif 정보를 가져온다.

                    ProcCmd.MapStif = System.Convert.ToInt32(Port.MapStif.PadLeft(20, '0'), 2).ToString(); ///int.Parse(LCData.GetSlotCount(CstInfo.MapStif));
                    ProcCmd.StartStif = System.Convert.ToInt32(Port.CurStif.PadLeft(20, '0'), 2).ToString();  //int.Parse(LCData.GetSlotCount(CstInfo.StartStif));
                    //// binary -> Decimal 형태로 변환
                    ProcCmd.ByWho = eByWho.ByOperator;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }               
            }

            
        }

        private void LocalModeForm_Load(object sender, EventArgs e)
        {

            ////////LCData.PortInfos.IndexOf(0);
            ////////label1.Text = LCData.PortInfos.IndexOf(0);
            ////////label2.Text = LCData.PortInfos.IndexOf(1);
            ////////label3.Text = LCData.PortInfos.IndexOf(2);
            ////////label4.Text = LCData.PortInfos.IndexOf(3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PortInfoData Port = LCData.FindPort("IP02");


            ModuleData module = LCData.FindModule(Port.ModuleID);

            if (module != null)
            {
                C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();

                ProcCmd.Target.SrcEq = "LC";
                ProcCmd.Target.SrcUnit = "N/A";
                ProcCmd.Target.DesEq = module.EqID;
                ProcCmd.Target.DesUnit = module.UnitID;//해당 되는 Unit에 Command 전송.

                ProcCmd.PortNo = 1;
                ProcCmd.Command = eRCMD.JobProcessStart;

                CassetteInfoData CstInfo = LCData.FindCassette(Port.CstID);
                if (CstInfo != null)
                {
                    ProcCmd.CstID = CstInfo.CstID;

                    //CassetteInfoData CstInfo = LCData.FindCassette(recv.IPID); //MapStif가 내려오지 않으므로, CassetteID와 동일한 Cassette 정보에서 MapStif 정보를 가져온다.

                    ProcCmd.MapStif = System.Convert.ToInt32(Port.MapStif.PadLeft(20, '0'), 2).ToString(); ///int.Parse(LCData.GetSlotCount(CstInfo.MapStif));
                    ProcCmd.StartStif = System.Convert.ToInt32(Port.CurStif.PadLeft(20, '0'), 2).ToString();  //int.Parse(LCData.GetSlotCount(CstInfo.StartStif));
                    //// binary -> Decimal 형태로 변환
                    ProcCmd.ByWho = eByWho.ByOperator;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PortInfoData Port = LCData.FindPort("IP01");


            ModuleData module = LCData.FindModule(Port.ModuleID);

            if (module != null)
            {
                C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();

                ProcCmd.Target.SrcEq = "LC";
                ProcCmd.Target.SrcUnit = "N/A";
                ProcCmd.Target.DesEq = module.EqID;
                ProcCmd.Target.DesUnit = module.UnitID;//해당 되는 Unit에 Command 전송.

                ProcCmd.PortNo = 1;
                ProcCmd.Command = eRCMD.JobProcessCancel;

                CassetteInfoData CstInfo = LCData.FindCassette(Port.CstID);
                if (CstInfo != null)
                {
                    ProcCmd.CstID = CstInfo.CstID;

                    //CassetteInfoData CstInfo = LCData.FindCassette(recv.IPID); //MapStif가 내려오지 않으므로, CassetteID와 동일한 Cassette 정보에서 MapStif 정보를 가져온다.

                    ProcCmd.MapStif = System.Convert.ToInt32(Port.MapStif.PadLeft(20, '0'), 2).ToString(); ///int.Parse(LCData.GetSlotCount(CstInfo.MapStif));
                    ProcCmd.StartStif = System.Convert.ToInt32(Port.CurStif.PadLeft(20, '0'), 2).ToString();  //int.Parse(LCData.GetSlotCount(CstInfo.StartStif));
                    //// binary -> Decimal 형태로 변환
                    ProcCmd.ByWho = eByWho.ByOperator;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PortInfoData Port = LCData.FindPort("IP01");


            ModuleData module = LCData.FindModule(Port.ModuleID);

            if (module != null)
            {
                C14ProcessPortCmd ProcCmd = new C14ProcessPortCmd();

                ProcCmd.Target.SrcEq = "LC";
                ProcCmd.Target.SrcUnit = "N/A";
                ProcCmd.Target.DesEq = module.EqID;
                ProcCmd.Target.DesUnit = module.UnitID;//해당 되는 Unit에 Command 전송.

                ProcCmd.PortNo = 1;
                ProcCmd.Command = eRCMD.JobProcessAbort;

                CassetteInfoData CstInfo = LCData.FindCassette(Port.CstID);
                if (CstInfo != null)
                {
                    ProcCmd.CstID = CstInfo.CstID;

                    //CassetteInfoData CstInfo = LCData.FindCassette(recv.IPID); //MapStif가 내려오지 않으므로, CassetteID와 동일한 Cassette 정보에서 MapStif 정보를 가져온다.

                    ProcCmd.MapStif = System.Convert.ToInt32(Port.MapStif.PadLeft(20, '0'), 2).ToString(); ///int.Parse(LCData.GetSlotCount(CstInfo.MapStif));
                    ProcCmd.StartStif = System.Convert.ToInt32(Port.CurStif.PadLeft(20, '0'), 2).ToString();  //int.Parse(LCData.GetSlotCount(CstInfo.StartStif));
                    //// binary -> Decimal 형태로 변환
                    ProcCmd.ByWho = eByWho.ByOperator;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("해당 Port에 Cst정보가 없습니다.", "Job Start 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}