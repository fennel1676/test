namespace ProdPlanManager
{
    partial class LogControl
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
            this.ctlList1 = new System.Windows.Forms.ListBox();
            this.ctlList2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctlList1
            // 
            this.ctlList1.BackColor = System.Drawing.Color.Black;
            this.ctlList1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlList1.ForeColor = System.Drawing.Color.White;
            this.ctlList1.FormattingEnabled = true;
            this.ctlList1.HorizontalScrollbar = true;
            this.ctlList1.Location = new System.Drawing.Point(184, 2);
            this.ctlList1.Name = "ctlList1";
            this.ctlList1.Size = new System.Drawing.Size(542, 134);
            this.ctlList1.TabIndex = 81;
            // 
            // ctlList2
            // 
            this.ctlList2.BackColor = System.Drawing.Color.Black;
            this.ctlList2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlList2.ForeColor = System.Drawing.Color.White;
            this.ctlList2.FormattingEnabled = true;
            this.ctlList2.HorizontalScrollbar = true;
            this.ctlList2.Location = new System.Drawing.Point(724, 2);
            this.ctlList2.Name = "ctlList2";
            this.ctlList2.Size = new System.Drawing.Size(542, 134);
            this.ctlList2.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(54, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 83;
            this.label1.Text = "투입 현황";
            // 
            // LogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlList1);
            this.Controls.Add(this.ctlList2);
            this.Name = "LogControl";
            this.Size = new System.Drawing.Size(1268, 138);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ctlList1;
        private System.Windows.Forms.ListBox ctlList2;
        private System.Windows.Forms.Label label1;
    }
}
