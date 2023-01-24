namespace ProdPlanManager
{
    partial class CreatePlanForm
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
            this.btnCrate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrate
            // 
            this.btnCrate.Location = new System.Drawing.Point(196, 302);
            this.btnCrate.Name = "btnCrate";
            this.btnCrate.Size = new System.Drawing.Size(86, 25);
            this.btnCrate.TabIndex = 1;
            this.btnCrate.Text = "생성";
            this.btnCrate.UseVisualStyleBackColor = true;
            this.btnCrate.Click += new System.EventHandler(this.btnCrate_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "투입계획생성";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(282, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // 
            // fpSpread1
            // 
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.Location = new System.Drawing.Point(14, 28);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(354, 265);
            this.fpSpread1.TabIndex = 3;
            // 
            // CreatePlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 332);
            this.ControlBox = false;
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCrate);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePlanForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "생산 계획 정보 수동 생성";
            this.Load += new System.EventHandler(this.CreatePlanForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CreatePlanForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
    }
}