using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProdPlanManager
{
    public partial class DisconnectPLCForm : Form
    {
        public DisconnectPLCForm()
        {
            InitializeComponent();
        }

        private void DisconnectPLCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void DisconnectPLCForm_Activated(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void DisconnectPLCForm_Deactivate(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}