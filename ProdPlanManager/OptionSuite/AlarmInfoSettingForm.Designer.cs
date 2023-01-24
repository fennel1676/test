namespace T8_1_CCS
{
	partial class AlarmInfoSettingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmInfoSettingForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panelLoading = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.groupBox1.SuspendLayout();
			this.panelLoading.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.panelLoading);
			this.groupBox1.Controls.Add(this.fpSpread1);
			this.groupBox1.Location = new System.Drawing.Point(10, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(835, 375);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Alarm 정보";
			// 
			// panelLoading
			// 
			this.panelLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelLoading.Controls.Add(this.label2);
			this.panelLoading.Controls.Add(this.label1);
			this.panelLoading.Controls.Add(this.progressBar1);
			this.panelLoading.Location = new System.Drawing.Point(293, 142);
			this.panelLoading.Name = "panelLoading";
			this.panelLoading.Size = new System.Drawing.Size(215, 85);
			this.panelLoading.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(46, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "잠시만 기다려주세요.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(72, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "Loading...";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 55);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(189, 17);
			this.progressBar1.TabIndex = 0;
			// 
			// fpSpread1
			// 
			this.fpSpread1.About = "4.0.2001.2005";
			this.fpSpread1.AccessibleDescription = "";
			this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fpSpread1.Location = new System.Drawing.Point(12, 19);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(811, 344);
			this.fpSpread1.TabIndex = 2;
			this.fpSpread1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpread1_KeyDown);
			this.fpSpread1.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpSpread1_Change);
			this.fpSpread1.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_ComboCloseUp);
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.Location = new System.Drawing.Point(434, 394);
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
			this.btnOK.Location = new System.Drawing.Point(343, 394);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 28);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "확   인";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
			// 
			// AlarmInfoSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(857, 431);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AlarmInfoSettingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Alarm정보 설정";
			this.Load += new System.EventHandler(this.AlarmInfoSettingForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.panelLoading.ResumeLayout(false);
			this.panelLoading.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Panel panelLoading;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
	}
}