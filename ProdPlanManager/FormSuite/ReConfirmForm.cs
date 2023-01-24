using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProdPlanManager
{
    public partial class ReConfirmForm : Form
    {
        private string Message = "";

        public ReConfirmForm(string Msg)
        {
            InitializeComponent();

            Message = Msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ReConfirmForm_Load(object sender, EventArgs e)
        {
            label1.Text = Message;
        }
    }
}