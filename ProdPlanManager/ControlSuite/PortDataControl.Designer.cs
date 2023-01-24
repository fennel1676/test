namespace ProdPlanManager
{
    partial class PortDataControl
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
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColorState = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(1268, 144);
            this.fpSpread1.TabIndex = 0;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            this.fpSpread1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fpSpread1_MouseMove);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "LINE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnColorState
            // 
            this.btnColorState.BackColor = System.Drawing.SystemColors.Control;
            this.btnColorState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorState.Location = new System.Drawing.Point(1, 61);
            this.btnColorState.Name = "btnColorState";
            this.btnColorState.Size = new System.Drawing.Size(185, 21);
            this.btnColorState.TabIndex = 2;
            this.btnColorState.Text = "PORT STATE(색상)";
            this.btnColorState.UseVisualStyleBackColor = false;
            this.btnColorState.Click += new System.EventHandler(this.btnColorState_Click);
            // 
            // PortDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnColorState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fpSpread1);
            this.Name = "PortDataControl";
            this.Size = new System.Drawing.Size(1268, 144);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColorState;
    }
}
