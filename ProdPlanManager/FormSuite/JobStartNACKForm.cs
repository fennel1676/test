using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProdPlanManager
{
    public partial class JobStartNACKForm : Form
    {  
        private short _line = 0;
        private short _nack = 0;
        private bool _valid = false;
        private int _portNo = 0;

        public JobStartNACKForm()
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

        public int PORTNO
        {
            get { return _portNo; }
            set { _portNo = value; }
        }

        public void UpdateDisplay(short line, int PortNo, short nackCode, bool check)
        {
            LINE = line;
            if (check) NACK = nackCode;
            VALID = check;
            PORTNO = PortNo;

            lbTitle.Text = string.Format("[LINE {0}] JobStart Command NACK 발생", LINE);           
            

            int selectPort = (PortNo - 1) % 2;

            if (selectPort == 1)
            {
                lbPort1.Text = string.Format("PORT{0}", PortNo - 1);
                lbPort2.Text = string.Format("PORT{0}", PortNo);
            }
            else
            {
                lbPort1.Text = string.Format("PORT{0}", PortNo);
                lbPort2.Text = string.Format("PORT{0}", PortNo + 1);
            }

            switch (selectPort)
            {
                case 0:
                    {
                        switch (nackCode)
                        {
                            case 110: DisplayNACKCode(lbACK1, lbNACK1); break;
                            case 208: DisplayNACKCode(lbACK2, lbNACK2); break;
                            case 209: DisplayNACKCode(lbACK3, lbNACK3); break;
                            case 210: DisplayNACKCode(lbACK3, lbNACK4); break;
                        }

                    }
                    break;
                case 1:
                    {
                        switch (nackCode)
                        {
                            case 110: DisplayNACKCode(lbACK5, lbNACK5); break;
                            case 208: DisplayNACKCode(lbACK6, lbNACK6); break;
                            case 209: DisplayNACKCode(lbACK7, lbNACK7); break;
                            case 210: DisplayNACKCode(lbACK8, lbNACK8); break;
                        }

                    }
                    break;
            }           
        }

        public void Init(short line)
        {
            LINE = 0;
            NACK = 0;
            VALID = false;
            PORTNO = 0;

            lbACK1.BackColor = Color.Transparent;
            lbNACK1.BackColor = Color.Transparent;
            lbACK2.BackColor = Color.Transparent;
            lbNACK2.BackColor = Color.Transparent;
            lbACK3.BackColor = Color.Transparent;
            lbNACK3.BackColor = Color.Transparent;
            lbACK3.BackColor = Color.Transparent;
            lbNACK4.BackColor = Color.Transparent;
            lbACK5.BackColor = Color.Transparent;
            lbNACK5.BackColor = Color.Transparent;
            lbACK6.BackColor = Color.Transparent;
            lbNACK6.BackColor = Color.Transparent;
            lbACK7.BackColor = Color.Transparent;
            lbNACK7.BackColor = Color.Transparent;
            lbACK8.BackColor = Color.Transparent;
            lbNACK8.BackColor = Color.Transparent;      
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