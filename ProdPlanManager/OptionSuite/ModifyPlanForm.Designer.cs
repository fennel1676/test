namespace ProdPlanManager
{
    partial class ModifyPlanForm
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
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.White;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(13, 6);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(156, 20);
            this.lbTitle.TabIndex = 43;
            this.lbTitle.Text = "투입계획변경";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 4;
            this.fpSpread1_Sheet1.RowCount = 31;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "ORDER 1";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "ORDER 2";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "ORDER 3";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "ORDER 4";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "ORDER 1";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 193F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "ORDER 2";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 187F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "ORDER 3";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 182F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "ORDER 4";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 210F;
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(0, 0).Value = "Priority";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(1, 0).Value = "ProdKind";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(2, 0).Value = "ProdType";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(3, 0).Value = "ProcessID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(4, 0).Value = "ProductID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(5, 0).Value = "StepID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(6, 0).Value = "PPID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(7, 0).Value = "FlowID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(8, 0).Value = "BatchID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(9, 0).Value = "BatchState";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(10, 0).Value = "BatchSize";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(11, 0).Value = "P_Maker";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(12, 0).Value = "P_Thckness";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(13, 0).Value = "F_PanelID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(14, 0).Value = "C_PanelID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(15, 0).Value = "InputLine";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(16, 0).Value = "ValidFlag";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(17, 0).Value = "C_QTY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(18, 0).Value = "O_QTY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(19, 0).Value = "R_QTY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(20, 0).Value = "N_QTY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(21, 0).ColumnSpan = 2;
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(21, 0).Value = "FlowGroup 1";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(22, 0).Value = "FlowGroup 2";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(23, 0).Value = "FlowGroup 3";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(24, 0).Value = "FlowGroup 4";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(25, 0).Value = "FlowGroup 5";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(26, 0).Value = "FlowGroup 6";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(27, 0).Value = "FlowGroup 7";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(28, 0).Value = "FlowGroup 8";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(29, 0).Value = "FlowGroup 9";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(30, 0).Value = "FlowGroup 10";
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 121F;
            this.fpSpread1_Sheet1.Rows.Get(0).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(0).Label = "Priority";
            this.fpSpread1_Sheet1.Rows.Get(1).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(1).Label = "ProdKind";
            this.fpSpread1_Sheet1.Rows.Get(2).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(2).Label = "ProdType";
            this.fpSpread1_Sheet1.Rows.Get(3).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(3).Label = "ProcessID";
            this.fpSpread1_Sheet1.Rows.Get(4).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(4).Label = "ProductID";
            this.fpSpread1_Sheet1.Rows.Get(5).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(5).Label = "StepID";
            this.fpSpread1_Sheet1.Rows.Get(6).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(6).Label = "PPID";
            this.fpSpread1_Sheet1.Rows.Get(7).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(7).Label = "FlowID";
            this.fpSpread1_Sheet1.Rows.Get(8).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(8).Label = "BatchID";
            this.fpSpread1_Sheet1.Rows.Get(9).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(9).Label = "BatchState";
            this.fpSpread1_Sheet1.Rows.Get(10).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(10).Label = "BatchSize";
            this.fpSpread1_Sheet1.Rows.Get(11).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(11).Label = "P_Maker";
            this.fpSpread1_Sheet1.Rows.Get(12).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(12).Label = "P_Thckness";
            this.fpSpread1_Sheet1.Rows.Get(13).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(13).Label = "F_PanelID";
            this.fpSpread1_Sheet1.Rows.Get(14).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(14).Label = "C_PanelID";
            this.fpSpread1_Sheet1.Rows.Get(15).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(15).Label = "InputLine";
            this.fpSpread1_Sheet1.Rows.Get(16).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(16).Label = "ValidFlag";
            this.fpSpread1_Sheet1.Rows.Get(17).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(17).Label = "C_QTY";
            this.fpSpread1_Sheet1.Rows.Get(18).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(18).Label = "O_QTY";
            this.fpSpread1_Sheet1.Rows.Get(19).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(19).Label = "R_QTY";
            this.fpSpread1_Sheet1.Rows.Get(20).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(20).Label = "N_QTY";
            this.fpSpread1_Sheet1.Rows.Get(21).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(21).Label = "FlowGroup 1";
            this.fpSpread1_Sheet1.Rows.Get(22).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(22).Label = "FlowGroup 2";
            this.fpSpread1_Sheet1.Rows.Get(23).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(23).Label = "FlowGroup 3";
            this.fpSpread1_Sheet1.Rows.Get(24).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(24).Label = "FlowGroup 4";
            this.fpSpread1_Sheet1.Rows.Get(25).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(25).Label = "FlowGroup 5";
            this.fpSpread1_Sheet1.Rows.Get(26).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(26).Height = 24F;
            this.fpSpread1_Sheet1.Rows.Get(26).Label = "FlowGroup 6";
            this.fpSpread1_Sheet1.Rows.Get(27).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(27).Label = "FlowGroup 7";
            this.fpSpread1_Sheet1.Rows.Get(28).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(28).Label = "FlowGroup 8";
            this.fpSpread1_Sheet1.Rows.Get(29).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(29).Label = "FlowGroup 9";
            this.fpSpread1_Sheet1.Rows.Get(30).Font = new System.Drawing.Font("Arial", 9F);
            this.fpSpread1_Sheet1.Rows.Get(30).Label = "FlowGroup 10";
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpSpread1
            // 
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.Location = new System.Drawing.Point(14, 28);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(354, 265);
            this.fpSpread1.TabIndex = 40;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(307, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(60, 21);
            this.comboBox1.TabIndex = 45;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(137, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 19);
            this.label1.TabIndex = 46;
            this.label1.Text = "Order";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(196, 302);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(86, 25);
            this.btnModify.TabIndex = 42;
            this.btnModify.Text = "변경";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // ModifyPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 332);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.fpSpread1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ModifyPlanForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "생산 계획 정보 수동 변경";
            this.Load += new System.EventHandler(this.ModifyPlanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnClose;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModify;
    }
}