namespace ProdPlanManager
{
    partial class ECIDSetForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fpSpread3 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread3_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fpSpread4 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread4_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread3_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread4_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(712, 760);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "ECID Mode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fpSpread3
            // 
            this.fpSpread3.AccessibleDescription = "";
            this.fpSpread3.Location = new System.Drawing.Point(5, 38);
            this.fpSpread3.Name = "fpSpread3";
            this.fpSpread3.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread3_Sheet1});
            this.fpSpread3.Size = new System.Drawing.Size(781, 148);
            this.fpSpread3.TabIndex = 8;
            // 
            // fpSpread3_Sheet1
            // 
            this.fpSpread3_Sheet1.Reset();
            this.fpSpread3_Sheet1.SheetName = "Sheet1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(11, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 272);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ECID";
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.LightBlue;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(161, 179);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(613, 16);
            this.label23.TabIndex = 35;
            this.label23.Text = "STK 수량 \'30\'(ERROR를 의미)이 들어옸을 경우 처리 MODE";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.White;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label28.Location = new System.Drawing.Point(199, 194);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(143, 22);
            this.label28.TabIndex = 30;
            this.label28.Text = "INPUT";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Location = new System.Drawing.Point(199, 215);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(143, 46);
            this.label29.TabIndex = 29;
            this.label29.Text = "CANCEL";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.White;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label31.Location = new System.Drawing.Point(161, 194);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(39, 22);
            this.label31.TabIndex = 27;
            this.label31.Text = "1";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.White;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label34.Location = new System.Drawing.Point(161, 215);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(39, 46);
            this.label34.TabIndex = 21;
            this.label34.Text = "2";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.White;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label38.Location = new System.Drawing.Point(62, 179);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 82);
            this.label38.TabIndex = 19;
            this.label38.Text = "ERROR CONTROL";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label39.Location = new System.Drawing.Point(17, 179);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(46, 82);
            this.label39.TabIndex = 20;
            this.label39.Text = "2";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.LightBlue;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(161, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(613, 17);
            this.label22.TabIndex = 18;
            this.label22.Text = "CST Mapping 처리 모드";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Location = new System.Drawing.Point(199, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 50);
            this.label18.TabIndex = 14;
            this.label18.Text = "STK 수량으로 투입";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Location = new System.Drawing.Point(199, 97);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 34);
            this.label17.TabIndex = 13;
            this.label17.Text = "HOST 수량으로 투입";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Location = new System.Drawing.Point(199, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 46);
            this.label16.TabIndex = 12;
            this.label16.Text = "HOST ↔ STK 수량";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Location = new System.Drawing.Point(161, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 50);
            this.label15.TabIndex = 11;
            this.label15.Text = "3";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Location = new System.Drawing.Point(161, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 34);
            this.label14.TabIndex = 10;
            this.label14.Text = "2";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Yellow;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(341, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(433, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "DESCRIPTION";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Yellow;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(199, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "NAME";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Location = new System.Drawing.Point(161, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 46);
            this.label13.TabIndex = 9;
            this.label13.Text = "1";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Yellow;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(161, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "DEF";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Yellow;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(62, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "MODE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(17, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "ECID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Location = new System.Drawing.Point(62, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 144);
            this.label12.TabIndex = 8;
            this.label12.Text = "INPUT MODE";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Location = new System.Drawing.Point(17, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 144);
            this.label6.TabIndex = 8;
            this.label6.Text = "1";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.fpSpread4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.fpSpread3);
            this.groupBox2.Location = new System.Drawing.Point(12, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(791, 386);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Example";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(241, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(370, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "※ LOCAL 時 CST INFOR에서 Slot 정보는 Update하지 않음";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(533, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "※ Slot 선택 화면 제거, 작업자는 Slot 선택하지 않음, 작업자는 단지 Start Button만 누름";
            // 
            // fpSpread4
            // 
            this.fpSpread4.AccessibleDescription = "";
            this.fpSpread4.Location = new System.Drawing.Point(5, 224);
            this.fpSpread4.Name = "fpSpread4";
            this.fpSpread4.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread4_Sheet1});
            this.fpSpread4.Size = new System.Drawing.Size(782, 148);
            this.fpSpread4.TabIndex = 11;
            // 
            // fpSpread4_Sheet1
            // 
            this.fpSpread4_Sheet1.Reset();
            this.fpSpread4_Sheet1.SheetName = "Sheet1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "2) LOCAL, OFFLINE CASE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "1) REMOTE CASE";
            // 
            // ECIDSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 790);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ECIDSetForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ECID 파라메터 셋팅";
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread3_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread4_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Spread.FpSpread fpSpread3;
        private FarPoint.Win.Spread.SheetView fpSpread3_Sheet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private FarPoint.Win.Spread.FpSpread fpSpread4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private FarPoint.Win.Spread.SheetView fpSpread4_Sheet1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
    }
}