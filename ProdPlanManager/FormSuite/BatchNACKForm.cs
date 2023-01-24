using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ProdPlanManager
{
    public partial class BatchNACKForm : Form
    {
        private short _line = 0;
        private short _nack = 0;
        private bool _valid = false;

        public BatchNACKForm()
        {
            InitializeComponent();        
        }

        public short LINE
        {
            get { return _line; }
            set { _line = value; }
        }

        public short NACK
        {
            get { return _nack; }
            set { _nack = value; }
        }

        public bool VALID
        {
            get { return _valid; }
            set { _valid = value; }
        }

        public void UpdateDisplay(short line, short nackCode, bool check)
        {
            LINE = line;
            if (check) NACK = nackCode;
            VALID = check;

            lbTitle.Text = string.Format("[LINE {0}] 투입계획정보 NACK 발생", LINE);
            switch (nackCode)
            {
                case 1: DisplayNACKCode(lbACK1, lbNACK1); break;
                case 9: DisplayNACKCode(lbACK2, lbNACK2); break;
                case 10: DisplayNACKCode(lbACK3, lbNACK3); break;
                case 2: DisplayNACKCode(lbACK4, lbNACK4); break;
            }
        }

        public void Init(short line)
        {
            LINE = 0;
            NACK = 0;
            VALID = false;

            lbACK1.BackColor = Color.Transparent;
            lbNACK1.BackColor = Color.Transparent;
            lbACK2.BackColor = Color.Transparent;
            lbNACK2.BackColor = Color.Transparent;
            lbACK3.BackColor = Color.Transparent;
            lbNACK3.BackColor = Color.Transparent;
            lbACK4.BackColor = Color.Transparent;
            lbNACK4.BackColor = Color.Transparent;            
        }



        private void DisplayNACKCode(System.Windows.Forms.Label lb1, System.Windows.Forms.Label lb2)
        {
            if (VALID)
            {
                lb1.BackColor = Color.Transparent;
                lb2.BackColor = Color.Red;
            }
            else
            {
                lb1.BackColor = Color.Lime;
                lb2.BackColor = Color.Transparent;
            }
        }        
    }
}