namespace ProdPlanManager
{
    partial class PlanInfoControl
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
            this.InputSpread = new FarPoint.Win.Spread.FpSpread();
            this.InputSpread_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.PlanSpread = new FarPoint.Win.Spread.FpSpread();
            this.PlanSpread_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.InputSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputSpread_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanSpread_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // InputSpread
            // 
            this.InputSpread.About = "4.0.2001.2005";
            this.InputSpread.AccessibleDescription = "";
            this.InputSpread.Location = new System.Drawing.Point(0, 252);
            this.InputSpread.Name = "InputSpread";
            this.InputSpread.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.InputSpread_Sheet1});
            this.InputSpread.Size = new System.Drawing.Size(1272, 138);
            this.InputSpread.TabIndex = 8;
            // 
            // InputSpread_Sheet1
            // 
            this.InputSpread_Sheet1.Reset();
            this.InputSpread_Sheet1.SheetName = "Sheet1";
            // 
            // PlanSpread
            // 
            this.PlanSpread.About = "4.0.2001.2005";
            this.PlanSpread.AccessibleDescription = "";
            this.PlanSpread.Location = new System.Drawing.Point(1, 3);
            this.PlanSpread.Name = "PlanSpread";
            this.PlanSpread.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.PlanSpread_Sheet1});
            this.PlanSpread.Size = new System.Drawing.Size(1274, 243);
            this.PlanSpread.TabIndex = 16;
            this.PlanSpread.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.PlanSpread_CellClick);
            this.PlanSpread.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.PlanSpread_CellDoubleClick);
            this.PlanSpread.Leave += new System.EventHandler(this.PlanSpread_MouseLeave);
            // 
            // PlanSpread_Sheet1
            // 
            this.PlanSpread_Sheet1.Reset();
            this.PlanSpread_Sheet1.SheetName = "Sheet1";
            // 
            // PlanInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlanSpread);
            this.Controls.Add(this.InputSpread);
            this.Name = "PlanInfoControl";
            this.Size = new System.Drawing.Size(1312, 397);
            ((System.ComponentModel.ISupportInitialize)(this.InputSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputSpread_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanSpread_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread InputSpread;
        private FarPoint.Win.Spread.SheetView InputSpread_Sheet1;
        private FarPoint.Win.Spread.FpSpread PlanSpread;
        private FarPoint.Win.Spread.SheetView PlanSpread_Sheet1;

    }
}
