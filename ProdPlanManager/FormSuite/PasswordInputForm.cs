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
	public partial class PasswordInputForm : Form
	{
		public PasswordInputForm()
		{
			InitializeComponent();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnOK_Click(this, EventArgs.Empty);
			}
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
            if (textBox1.Text == LCData.Password)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("패스워드가 틀렸습니다.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
		}	
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}