using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProdPlanManager
{
    public partial class DisplayPortState : Form
    {
        public DisplayPortState()
        {
            InitializeComponent();
        }

        private void DisplayPortState_Load(object sender, EventArgs e)
        {
            lbEmptyColor.BackColor = Color.FromArgb(191,191,190);
            label2.BackColor = Color.FromArgb(255, 255, 130);
            label20.BackColor = Color.FromArgb(126, 255, 130);
            label4.BackColor = Color.FromArgb(255, 253, 0);
            label6.BackColor = Color.FromArgb(129, 254, 255);
            label8.BackColor = Color.FromArgb(0, 255, 0);
            label10.BackColor = Color.FromArgb(0, 251, 235);
            label12.BackColor = Color.FromArgb(255, 0, 255);
            label14.BackColor = Color.FromArgb(255, 253, 0);
            label16.BackColor = Color.FromArgb(255, 128, 1);
            label18.BackColor = Color.FromArgb(130, 0, 255); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}