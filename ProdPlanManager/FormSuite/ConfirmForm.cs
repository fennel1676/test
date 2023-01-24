using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProdPlanManager
{
    public partial class ConfirmForm : Form
    {
        public string InformMsg = "";

        public ConfirmForm(string Msg)
        {
            InitializeComponent();
            InformMsg = Msg;
        }
        private void ConfirmForm_Load(object sender, EventArgs e)
        {
           // label1.Text = InformMsg;
            timerEnd.Start();
        }

        private void timerEnd_Tick(object sender, EventArgs e)
        {
            CloseMesssage();
        }

        private void CloseMesssage()
        {
            timerEnd.Stop();
            this.DialogResult = DialogResult.OK;
        }
    }
}
