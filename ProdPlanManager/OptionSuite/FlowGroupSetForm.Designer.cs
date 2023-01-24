namespace ProdPlanManager
{
    partial class FlowGroupSetForm
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lbTitleUsed = new System.Windows.Forms.Label();
            this.lbTitleITO = new System.Windows.Forms.Label();
            this.lbTitleCF = new System.Windows.Forms.Label();
            this.lbTitleID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.White;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(12, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(397, 36);
            this.lbTitle.TabIndex = 38;
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(334, 314);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(260, 314);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 30);
            this.btnApply.TabIndex = 37;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lbTitleUsed
            // 
            this.lbTitleUsed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitleUsed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitleUsed.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleUsed.Location = new System.Drawing.Point(309, 44);
            this.lbTitleUsed.Name = "lbTitleUsed";
            this.lbTitleUsed.Size = new System.Drawing.Size(100, 23);
            this.lbTitleUsed.TabIndex = 22;
            this.lbTitleUsed.Text = "사용 여부";
            this.lbTitleUsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitleITO
            // 
            this.lbTitleITO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitleITO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitleITO.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleITO.Location = new System.Drawing.Point(210, 44);
            this.lbTitleITO.Name = "lbTitleITO";
            this.lbTitleITO.Size = new System.Drawing.Size(100, 23);
            this.lbTitleITO.TabIndex = 21;
            this.lbTitleITO.Text = "ITO";
            this.lbTitleITO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitleCF
            // 
            this.lbTitleCF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitleCF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitleCF.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleCF.Location = new System.Drawing.Point(111, 44);
            this.lbTitleCF.Name = "lbTitleCF";
            this.lbTitleCF.Size = new System.Drawing.Size(100, 23);
            this.lbTitleCF.TabIndex = 19;
            this.lbTitleCF.Text = "초기";
            this.lbTitleCF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitleID
            // 
            this.lbTitleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitleID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleID.Location = new System.Drawing.Point(12, 44);
            this.lbTitleID.Name = "lbTitleID";
            this.lbTitleID.Size = new System.Drawing.Size(100, 23);
            this.lbTitleID.TabIndex = 20;
            this.lbTitleID.Text = "Flow ID";
            this.lbTitleID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlowGroupSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 349);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lbTitleUsed);
            this.Controls.Add(this.lbTitleITO);
            this.Controls.Add(this.lbTitleCF);
            this.Controls.Add(this.lbTitleID);
            this.Name = "FlowGroupSetForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flow Group 설정 화면";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lbTitleUsed;
        private System.Windows.Forms.Label lbTitleITO;
        private System.Windows.Forms.Label lbTitleCF;
        private System.Windows.Forms.Label lbTitleID;
    }
}