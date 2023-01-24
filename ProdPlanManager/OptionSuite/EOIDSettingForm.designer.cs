namespace T8_1_CCS
{
	partial class EOIDSettingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EOIDSettingForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fpSpread1);
			this.groupBox1.Location = new System.Drawing.Point(10, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(428, 345);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "EOID 정보";
			// 
			// fpSpread1
			// 
			this.fpSpread1.About = "4.0.2001.2005";
			this.fpSpread1.AccessibleDescription = "";
			this.fpSpread1.Location = new System.Drawing.Point(12, 19);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(404, 314);
			this.fpSpread1.TabIndex = 0;
			this.fpSpread1.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_ComboCloseUp);
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(230, 366);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 28);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "취   소";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(139, 366);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 28);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "확   인";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// EOIDSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 404);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EOIDSettingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EOID 설정";
			this.Load += new System.EventHandler(this.EOIDSettingForm_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
	}
}