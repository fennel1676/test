namespace T8_1_CCS
{
	partial class StateRuleDetailForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateRuleDetailForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnRParen = new System.Windows.Forms.Button();
			this.btnLParen = new System.Windows.Forms.Button();
			this.btnOR = new System.Windows.Forms.Button();
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.btnAND = new System.Windows.Forms.Button();
			this.cbModuleID = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnBack);
			this.groupBox1.Controls.Add(this.btnRParen);
			this.groupBox1.Controls.Add(this.btnLParen);
			this.groupBox1.Controls.Add(this.btnOR);
			this.groupBox1.Controls.Add(this.fpSpread1);
			this.groupBox1.Controls.Add(this.btnAND);
			this.groupBox1.Controls.Add(this.cbModuleID);
			this.groupBox1.Location = new System.Drawing.Point(10, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(646, 98);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "State 조합공식 (Combination Rule)";
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnBack.Location = new System.Drawing.Point(596, 69);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(40, 20);
			this.btnBack.TabIndex = 15;
			this.btnBack.Text = "←";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnRParen
			// 
			this.btnRParen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRParen.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnRParen.Location = new System.Drawing.Point(550, 69);
			this.btnRParen.Name = "btnRParen";
			this.btnRParen.Size = new System.Drawing.Size(40, 20);
			this.btnRParen.TabIndex = 14;
			this.btnRParen.Text = ")";
			this.btnRParen.UseVisualStyleBackColor = true;
			this.btnRParen.Click += new System.EventHandler(this.btnRParen_Click);
			// 
			// btnLParen
			// 
			this.btnLParen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLParen.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnLParen.Location = new System.Drawing.Point(504, 69);
			this.btnLParen.Name = "btnLParen";
			this.btnLParen.Size = new System.Drawing.Size(40, 20);
			this.btnLParen.TabIndex = 13;
			this.btnLParen.Text = "(";
			this.btnLParen.UseVisualStyleBackColor = true;
			this.btnLParen.Click += new System.EventHandler(this.btnLParen_Click);
			// 
			// btnOR
			// 
			this.btnOR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOR.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnOR.Location = new System.Drawing.Point(458, 69);
			this.btnOR.Name = "btnOR";
			this.btnOR.Size = new System.Drawing.Size(40, 20);
			this.btnOR.TabIndex = 12;
			this.btnOR.Text = "OR";
			this.btnOR.UseVisualStyleBackColor = true;
			this.btnOR.Click += new System.EventHandler(this.btnOR_Click);
			// 
			// fpSpread1
			// 
			this.fpSpread1.About = "4.0.2001.2005";
			this.fpSpread1.AccessibleDescription = "";
			this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fpSpread1.Location = new System.Drawing.Point(12, 19);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(624, 44);
			this.fpSpread1.TabIndex = 0;
			this.fpSpread1.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpSpread1_Change);
			this.fpSpread1.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_ComboCloseUp);
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// btnAND
			// 
			this.btnAND.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAND.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnAND.Location = new System.Drawing.Point(412, 69);
			this.btnAND.Name = "btnAND";
			this.btnAND.Size = new System.Drawing.Size(40, 20);
			this.btnAND.TabIndex = 11;
			this.btnAND.Text = "AND";
			this.btnAND.UseVisualStyleBackColor = true;
			this.btnAND.Click += new System.EventHandler(this.btnAND_Click);
			// 
			// cbModuleID
			// 
			this.cbModuleID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbModuleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModuleID.FormattingEnabled = true;
			this.cbModuleID.Location = new System.Drawing.Point(351, 69);
			this.cbModuleID.Name = "cbModuleID";
			this.cbModuleID.Size = new System.Drawing.Size(55, 20);
			this.cbModuleID.TabIndex = 10;
			this.cbModuleID.SelectionChangeCommitted += new System.EventHandler(this.cbModuleID_SelectionChangeCommitted);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.btnCancel.Location = new System.Drawing.Point(341, 116);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 28);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "취   소";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.btnOK.Location = new System.Drawing.Point(246, 116);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 28);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "확   인";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// StateRuleDetailForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 153);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StateRuleDetailForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "StateRule 설정";
			this.Load += new System.EventHandler(this.StateRuleDetailForm_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ComboBox cbModuleID;
		private System.Windows.Forms.Button btnAND;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnRParen;
		private System.Windows.Forms.Button btnLParen;
		private System.Windows.Forms.Button btnOR;
	}
}