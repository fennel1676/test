namespace ProdPlanManager
{
    partial class FlowIDSetForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.grpFlowID = new System.Windows.Forms.GroupBox();
            this.btnNR01 = new System.Windows.Forms.Button();
            this.btnBM01 = new System.Windows.Forms.Button();
            this.grpFlowID.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(197, 149);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(111, 149);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 25);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // grpFlowID
            // 
            this.grpFlowID.Controls.Add(this.btnBM01);
            this.grpFlowID.Controls.Add(this.btnNR01);
            this.grpFlowID.Location = new System.Drawing.Point(12, 12);
            this.grpFlowID.Name = "grpFlowID";
            this.grpFlowID.Size = new System.Drawing.Size(265, 131);
            this.grpFlowID.TabIndex = 2;
            this.grpFlowID.TabStop = false;
            // 
            // btnNR01
            // 
            this.btnNR01.BackColor = System.Drawing.Color.Red;
            this.btnNR01.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNR01.Location = new System.Drawing.Point(18, 41);
            this.btnNR01.Name = "btnNR01";
            this.btnNR01.Size = new System.Drawing.Size(112, 63);
            this.btnNR01.TabIndex = 0;
            this.btnNR01.Text = "NR01";
            this.btnNR01.UseVisualStyleBackColor = false;
            this.btnNR01.Click += new System.EventHandler(this.btnNR01_Click);
            // 
            // btnBM01
            // 
            this.btnBM01.BackColor = System.Drawing.Color.Red;
            this.btnBM01.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBM01.Location = new System.Drawing.Point(136, 41);
            this.btnBM01.Name = "btnBM01";
            this.btnBM01.Size = new System.Drawing.Size(112, 63);
            this.btnBM01.TabIndex = 0;
            this.btnBM01.Text = "BM01";
            this.btnBM01.UseVisualStyleBackColor = false;
            this.btnBM01.Click += new System.EventHandler(this.btnBM01_Click);
            // 
            // FlowIDSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 186);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpFlowID);
            this.Name = "FlowIDSetForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FlowID 설정 화면";
            this.Load += new System.EventHandler(this.FlowIDSetForm_Load);
            this.grpFlowID.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox grpFlowID;
        private System.Windows.Forms.Button btnBM01;
        private System.Windows.Forms.Button btnNR01;
    }
}