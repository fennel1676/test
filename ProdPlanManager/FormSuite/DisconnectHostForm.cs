using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProdPlanManager
{
	public partial class DisconnectHostForm : Form
	{
		public DisconnectHostForm()
		{
			InitializeComponent();
		}

		private void DisconnectHostForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
		private void DisconnectHostForm_Activated(object sender, EventArgs e)
		{
			this.TopMost = true;
		}
		private void DisconnectHostForm_Deactivate(object sender, EventArgs e)
		{
			this.TopMost = false;
		}
	}
}