namespace T8_1_CCS
{
	partial class MappingSettingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MappingSettingForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.fpSpread2 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread2_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.fpSpread3 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread3_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.fpSpread4 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread4_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread2_Sheet1)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread3_Sheet1)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread4_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.Padding = new System.Drawing.Point(6, 4);
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(451, 372);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.fpSpread1);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(443, 342);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = " WorkID ";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// fpSpread1
			// 
			this.fpSpread1.About = "4.0.2001.2005";
			this.fpSpread1.AccessibleDescription = "";
			this.fpSpread1.Location = new System.Drawing.Point(6, 6);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(300, 200);
			this.fpSpread1.TabIndex = 0;
			this.fpSpread1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpread1_KeyDown);
			this.fpSpread1.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpSpread1_Change);
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.fpSpread2);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(443, 342);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = " WorkerID ";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// fpSpread2
			// 
			this.fpSpread2.About = "4.0.2001.2005";
			this.fpSpread2.AccessibleDescription = "";
			this.fpSpread2.Location = new System.Drawing.Point(6, 6);
			this.fpSpread2.Name = "fpSpread2";
			this.fpSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread2_Sheet1});
			this.fpSpread2.Size = new System.Drawing.Size(300, 200);
			this.fpSpread2.TabIndex = 0;
			this.fpSpread2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpread2_KeyDown);
			this.fpSpread2.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpSpread2_Change);
			// 
			// fpSpread2_Sheet1
			// 
			this.fpSpread2_Sheet1.Reset();
			this.fpSpread2_Sheet1.SheetName = "Sheet1";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.fpSpread3);
			this.tabPage3.Location = new System.Drawing.Point(4, 26);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(443, 342);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = " FlowID ";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// fpSpread3
			// 
			this.fpSpread3.About = "4.0.2001.2005";
			this.fpSpread3.AccessibleDescription = "";
			this.fpSpread3.Location = new System.Drawing.Point(6, 6);
			this.fpSpread3.Name = "fpSpread3";
			this.fpSpread3.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread3_Sheet1});
			this.fpSpread3.Size = new System.Drawing.Size(300, 200);
			this.fpSpread3.TabIndex = 0;
			this.fpSpread3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpread3_KeyDown);
			this.fpSpread3.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpSpread3_Change);
			// 
			// fpSpread3_Sheet1
			// 
			this.fpSpread3_Sheet1.Reset();
			this.fpSpread3_Sheet1.SheetName = "Sheet1";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.fpSpread4);
			this.tabPage4.Location = new System.Drawing.Point(4, 26);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(443, 342);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = " ECID ";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// fpSpread4
			// 
			this.fpSpread4.About = "4.0.2001.2005";
			this.fpSpread4.AccessibleDescription = "";
			this.fpSpread4.Location = new System.Drawing.Point(6, 6);
			this.fpSpread4.Name = "fpSpread4";
			this.fpSpread4.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread4_Sheet1});
			this.fpSpread4.Size = new System.Drawing.Size(300, 200);
			this.fpSpread4.TabIndex = 0;
			this.fpSpread4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpread4_KeyDown);
			this.fpSpread4.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpSpread4_Change);
			// 
			// fpSpread4_Sheet1
			// 
			this.fpSpread4_Sheet1.Reset();
			this.fpSpread4_Sheet1.SheetName = "Sheet1";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOK.Location = new System.Drawing.Point(143, 381);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 28);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "확   인";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.Location = new System.Drawing.Point(234, 381);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 28);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "취   소";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// MappingSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 419);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MappingSettingForm";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mapping 설정";
			this.Load += new System.EventHandler(this.MappingSettingForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread2_Sheet1)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread3_Sheet1)).EndInit();
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpSpread4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread4_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpSpread2;
		private FarPoint.Win.Spread.SheetView fpSpread2_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpSpread3;
		private FarPoint.Win.Spread.SheetView fpSpread3_Sheet1;
		private System.Windows.Forms.TabPage tabPage4;
		private FarPoint.Win.Spread.FpSpread fpSpread4;
		private FarPoint.Win.Spread.SheetView fpSpread4_Sheet1;
	}
}