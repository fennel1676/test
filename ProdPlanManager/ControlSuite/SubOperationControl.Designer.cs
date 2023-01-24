namespace ProdPlanManager
{
    partial class SubOperationControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelpView = new System.Windows.Forms.Button();
            this.btnECIDSet = new System.Windows.Forms.Button();
            this.btnLogView = new System.Windows.Forms.Button();
            this.btnMaintenanceSet = new System.Windows.Forms.Button();
            this.btnAlarmHistoryView = new System.Windows.Forms.Button();
            this.btnBatchHistoryView = new System.Windows.Forms.Button();
            this.btnInputSet = new System.Windows.Forms.Button();
            this.btnFlowSet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnHelpView);
            this.panel1.Controls.Add(this.btnECIDSet);
            this.panel1.Controls.Add(this.btnLogView);
            this.panel1.Controls.Add(this.btnMaintenanceSet);
            this.panel1.Controls.Add(this.btnAlarmHistoryView);
            this.panel1.Controls.Add(this.btnBatchHistoryView);
            this.panel1.Controls.Add(this.btnInputSet);
            this.panel1.Controls.Add(this.btnFlowSet);
            this.panel1.Location = new System.Drawing.Point(183, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnHelpView
            // 
            this.btnHelpView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelpView.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHelpView.Location = new System.Drawing.Point(910, -1);
            this.btnHelpView.Name = "btnHelpView";
            this.btnHelpView.Size = new System.Drawing.Size(130, 44);
            this.btnHelpView.TabIndex = 1;
            this.btnHelpView.Text = "도움말";
            this.btnHelpView.UseVisualStyleBackColor = true;
            this.btnHelpView.Click += new System.EventHandler(this.btnHelpView_Click);
            // 
            // btnECIDSet
            // 
            this.btnECIDSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnECIDSet.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnECIDSet.Location = new System.Drawing.Point(780, -1);
            this.btnECIDSet.Name = "btnECIDSet";
            this.btnECIDSet.Size = new System.Drawing.Size(130, 44);
            this.btnECIDSet.TabIndex = 0;
            this.btnECIDSet.Text = "카세트 투입 모드";
            this.btnECIDSet.UseVisualStyleBackColor = true;
            this.btnECIDSet.Click += new System.EventHandler(this.btnECIDSet_Click);
            // 
            // btnLogView
            // 
            this.btnLogView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogView.Location = new System.Drawing.Point(650, -1);
            this.btnLogView.Name = "btnLogView";
            this.btnLogView.Size = new System.Drawing.Size(130, 44);
            this.btnLogView.TabIndex = 0;
            this.btnLogView.Text = "투입 현황 이력";
            this.btnLogView.UseVisualStyleBackColor = true;
            this.btnLogView.Click += new System.EventHandler(this.btnLogView_Click);
            // 
            // btnMaintenanceSet
            // 
            this.btnMaintenanceSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenanceSet.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintenanceSet.Location = new System.Drawing.Point(520, -1);
            this.btnMaintenanceSet.Name = "btnMaintenanceSet";
            this.btnMaintenanceSet.Size = new System.Drawing.Size(130, 44);
            this.btnMaintenanceSet.TabIndex = 0;
            this.btnMaintenanceSet.Text = "세팅";
            this.btnMaintenanceSet.UseVisualStyleBackColor = true;
            this.btnMaintenanceSet.Click += new System.EventHandler(this.btnMaintenanceSet_Click);
            // 
            // btnAlarmHistoryView
            // 
            this.btnAlarmHistoryView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarmHistoryView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarmHistoryView.Location = new System.Drawing.Point(390, -1);
            this.btnAlarmHistoryView.Name = "btnAlarmHistoryView";
            this.btnAlarmHistoryView.Size = new System.Drawing.Size(130, 44);
            this.btnAlarmHistoryView.TabIndex = 0;
            this.btnAlarmHistoryView.Text = "알람 이력";
            this.btnAlarmHistoryView.UseVisualStyleBackColor = true;
            this.btnAlarmHistoryView.Click += new System.EventHandler(this.btnAlarmHistoryView_Click);
            // 
            // btnBatchHistoryView
            // 
            this.btnBatchHistoryView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchHistoryView.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBatchHistoryView.Location = new System.Drawing.Point(260, -1);
            this.btnBatchHistoryView.Name = "btnBatchHistoryView";
            this.btnBatchHistoryView.Size = new System.Drawing.Size(130, 44);
            this.btnBatchHistoryView.TabIndex = 0;
            this.btnBatchHistoryView.Text = "투입계획이력";
            this.btnBatchHistoryView.UseVisualStyleBackColor = true;
            this.btnBatchHistoryView.Click += new System.EventHandler(this.btnBatchHistoryView_Click);
            // 
            // btnInputSet
            // 
            this.btnInputSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputSet.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInputSet.Location = new System.Drawing.Point(130, -1);
            this.btnInputSet.Name = "btnInputSet";
            this.btnInputSet.Size = new System.Drawing.Size(130, 44);
            this.btnInputSet.TabIndex = 0;
            this.btnInputSet.Text = "재공관리";
            this.btnInputSet.UseVisualStyleBackColor = true;
            this.btnInputSet.Click += new System.EventHandler(this.btnInputSet_Click);
            // 
            // btnFlowSet
            // 
            this.btnFlowSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlowSet.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlowSet.Location = new System.Drawing.Point(0, -1);
            this.btnFlowSet.Name = "btnFlowSet";
            this.btnFlowSet.Size = new System.Drawing.Size(130, 44);
            this.btnFlowSet.TabIndex = 0;
            this.btnFlowSet.Text = "FLOW RECIPE";
            this.btnFlowSet.UseVisualStyleBackColor = true;
            this.btnFlowSet.Click += new System.EventHandler(this.btnFlowSet_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "PARAMETER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubOperationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "SubOperationControl";
            this.Size = new System.Drawing.Size(1266, 44);
            this.RegionChanged += new System.EventHandler(this.SubOperationControl_RegionChanged);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogView;
        private System.Windows.Forms.Button btnMaintenanceSet;
        private System.Windows.Forms.Button btnAlarmHistoryView;
        private System.Windows.Forms.Button btnBatchHistoryView;
        private System.Windows.Forms.Button btnInputSet;
        private System.Windows.Forms.Button btnFlowSet;
        private System.Windows.Forms.Button btnECIDSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHelpView;

    }
}
