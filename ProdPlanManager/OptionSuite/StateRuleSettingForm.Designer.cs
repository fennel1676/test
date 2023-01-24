namespace T8_1_CCS
{
	partial class StateRuleSettingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateRuleSettingForm));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.fpSpread2 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread2_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnInsert = new System.Windows.Forms.Button();
			this.fpSpread3 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread3_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread2_Sheet1)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread3_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.Location = new System.Drawing.Point(353, 383);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 28);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "취   소";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOK.Location = new System.Drawing.Point(262, 383);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 28);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "확   인";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fpSpread1);
			this.groupBox1.Location = new System.Drawing.Point(10, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(226, 69);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "EqState 우선순위";
			// 
			// fpSpread1
			// 
			this.fpSpread1.About = "4.0.2001.2005";
			this.fpSpread1.AccessibleDescription = "";
			this.fpSpread1.Location = new System.Drawing.Point(6, 19);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(214, 44);
			this.fpSpread1.TabIndex = 0;
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.fpSpread2);
			this.groupBox2.Location = new System.Drawing.Point(248, 10);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(435, 69);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "ProcessState 우선순위";
			// 
			// fpSpread2
			// 
			this.fpSpread2.About = "4.0.2001.2005";
			this.fpSpread2.AccessibleDescription = "";
			this.fpSpread2.Location = new System.Drawing.Point(5, 19);
			this.fpSpread2.Name = "fpSpread2";
			this.fpSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread2_Sheet1});
			this.fpSpread2.Size = new System.Drawing.Size(424, 44);
			this.fpSpread2.TabIndex = 0;
			// 
			// fpSpread2_Sheet1
			// 
			this.fpSpread2_Sheet1.Reset();
			this.fpSpread2_Sheet1.SheetName = "Sheet1";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.btnDelete);
			this.groupBox3.Controls.Add(this.btnInsert);
			this.groupBox3.Controls.Add(this.fpSpread3);
			this.groupBox3.Location = new System.Drawing.Point(10, 85);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(673, 292);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "State 조합공식 (Combination Rule)";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(77, 262);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(65, 24);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "삭  제";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnInsert
			// 
			this.btnInsert.Location = new System.Drawing.Point(6, 262);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(65, 24);
			this.btnInsert.TabIndex = 7;
			this.btnInsert.Text = "추  가";
			this.btnInsert.UseVisualStyleBackColor = true;
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// fpSpread3
			// 
			this.fpSpread3.About = "4.0.2001.2005";
			this.fpSpread3.AccessibleDescription = "";
			this.fpSpread3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fpSpread3.Location = new System.Drawing.Point(6, 20);
			this.fpSpread3.Name = "fpSpread3";
			this.fpSpread3.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread3_Sheet1});
			this.fpSpread3.Size = new System.Drawing.Size(661, 239);
			this.fpSpread3.TabIndex = 0;
			this.fpSpread3.RowDragMoveCompleted += new FarPoint.Win.Spread.DragMoveCompletedEventHandler(this.fpSpread3_RowDragMoveCompleted);
			this.fpSpread3.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread3_CellDoubleClick);
			// 
			// fpSpread3_Sheet1
			// 
			this.fpSpread3_Sheet1.Reset();
			this.fpSpread3_Sheet1.SheetName = "Sheet1";
			// 
			// StateRuleSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 418);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StateRuleSettingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "StateRule 설정";
			this.Load += new System.EventHandler(this.StateRuleSettingForm_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread2_Sheet1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread3_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpSpread2;
		private FarPoint.Win.Spread.SheetView fpSpread2_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpSpread3;
		private FarPoint.Win.Spread.SheetView fpSpread3_Sheet1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnInsert;
	}
}