namespace ProdPlanManager
{
    partial class StateControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbProcState = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOffline = new System.Windows.Forms.Button();
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnRemote = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbEqState = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbEqpID = new System.Windows.Forms.Label();
            this.lbOperator2 = new System.Windows.Forms.Label();
            this.lbOperator1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbMaker = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(520, 32);
            this.label4.TabIndex = 127;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 156);
            this.panel1.TabIndex = 126;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbProcState);
            this.groupBox4.Location = new System.Drawing.Point(392, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(122, 68);
            this.groupBox4.TabIndex = 123;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Process Status";
            // 
            // lbProcState
            // 
            this.lbProcState.BackColor = System.Drawing.SystemColors.Control;
            this.lbProcState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbProcState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProcState.Location = new System.Drawing.Point(7, 18);
            this.lbProcState.Name = "lbProcState";
            this.lbProcState.Size = new System.Drawing.Size(108, 42);
            this.lbProcState.TabIndex = 40;
            this.lbProcState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOffline);
            this.groupBox3.Controls.Add(this.btnLocal);
            this.groupBox3.Controls.Add(this.btnRemote);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(260, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 68);
            this.groupBox3.TabIndex = 122;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Online Mode";
            // 
            // btnOffline
            // 
            this.btnOffline.BackColor = System.Drawing.SystemColors.Control;
            this.btnOffline.Enabled = false;
            this.btnOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffline.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOffline.Location = new System.Drawing.Point(160, 17);
            this.btnOffline.Name = "btnOffline";
            this.btnOffline.Size = new System.Drawing.Size(78, 41);
            this.btnOffline.TabIndex = 125;
            this.btnOffline.Text = "OFFLINE";
            this.btnOffline.UseVisualStyleBackColor = false;
            // 
            // btnLocal
            // 
            this.btnLocal.BackColor = System.Drawing.SystemColors.Control;
            this.btnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocal.Location = new System.Drawing.Point(87, 17);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(74, 41);
            this.btnLocal.TabIndex = 124;
            this.btnLocal.Text = "LOCAL";
            this.btnLocal.UseVisualStyleBackColor = false;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnRemote
            // 
            this.btnRemote.BackColor = System.Drawing.Color.Transparent;
            this.btnRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemote.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemote.Location = new System.Drawing.Point(11, 17);
            this.btnRemote.Name = "btnRemote";
            this.btnRemote.Size = new System.Drawing.Size(77, 41);
            this.btnRemote.TabIndex = 123;
            this.btnRemote.Text = "REMOTE";
            this.btnRemote.UseVisualStyleBackColor = false;
            this.btnRemote.Click += new System.EventHandler(this.btnRemote_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDisconnect);
            this.groupBox5.Controls.Add(this.btnConnect);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(8, 81);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(246, 68);
            this.groupBox5.TabIndex = 121;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PC ↔ PLC";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(122, 20);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(114, 37);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "DISCONNECT";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(9, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(114, 37);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbEqState);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(259, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 68);
            this.groupBox2.TabIndex = 117;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EQ Status";
            // 
            // lbEqState
            // 
            this.lbEqState.BackColor = System.Drawing.SystemColors.Control;
            this.lbEqState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEqState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEqState.Location = new System.Drawing.Point(7, 18);
            this.lbEqState.Name = "lbEqState";
            this.lbEqState.Size = new System.Drawing.Size(108, 42);
            this.lbEqState.TabIndex = 37;
            this.lbEqState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbEqpID);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 68);
            this.groupBox1.TabIndex = 116;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EQPID";
            // 
            // lbEqpID
            // 
            this.lbEqpID.BackColor = System.Drawing.SystemColors.Control;
            this.lbEqpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEqpID.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEqpID.Location = new System.Drawing.Point(9, 17);
            this.lbEqpID.Name = "lbEqpID";
            this.lbEqpID.Size = new System.Drawing.Size(226, 42);
            this.lbEqpID.TabIndex = 35;
            this.lbEqpID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOperator2
            // 
            this.lbOperator2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOperator2.Location = new System.Drawing.Point(332, 15);
            this.lbOperator2.Name = "lbOperator2";
            this.lbOperator2.Size = new System.Drawing.Size(176, 12);
            this.lbOperator2.TabIndex = 135;
            // 
            // lbOperator1
            // 
            this.lbOperator1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOperator1.Location = new System.Drawing.Point(333, 2);
            this.lbOperator1.Name = "lbOperator1";
            this.lbOperator1.Size = new System.Drawing.Size(175, 13);
            this.lbOperator1.TabIndex = 133;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(296, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 130;
            this.label7.Text = "담당:";
            // 
            // lbMaker
            // 
            this.lbMaker.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaker.Location = new System.Drawing.Point(66, 7);
            this.lbMaker.Name = "lbMaker";
            this.lbMaker.Size = new System.Drawing.Size(219, 13);
            this.lbMaker.TabIndex = 131;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 132;
            this.label6.Text = "MAKER :";
            // 
            // StateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbOperator2);
            this.Controls.Add(this.lbOperator1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbMaker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Name = "StateControl";
            this.Size = new System.Drawing.Size(520, 186);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbProcState;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOffline;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnRemote;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbEqState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbEqpID;
        private System.Windows.Forms.Label lbOperator2;
        private System.Windows.Forms.Label lbOperator1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbMaker;
        private System.Windows.Forms.Label label6;
    }
}
