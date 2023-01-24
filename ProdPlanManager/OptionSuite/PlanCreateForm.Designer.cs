namespace ProdPlanManager
{
    partial class PlanCreateForm
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
            FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer enhancedColumnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer enhancedRowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("ColumnHeaderMetallic");
            FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer enhancedColumnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderMetallic");
            FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer enhancedRowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerMetallic");
            FarPoint.Win.Spread.CellType.EnhancedCornerRenderer enhancedCornerRenderer1 = new FarPoint.Win.Spread.CellType.EnhancedCornerRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            enhancedColumnHeaderRenderer4.ActiveBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedColumnHeaderRenderer4.Name = "enhancedColumnHeaderRenderer4";
            enhancedColumnHeaderRenderer4.NormalBackgroundColor = System.Drawing.Color.Silver;
            enhancedColumnHeaderRenderer4.NormalGridLineColor = System.Drawing.Color.DarkGray;
            enhancedColumnHeaderRenderer4.SelectedActiveBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedColumnHeaderRenderer4.SelectedBackgroundColor = System.Drawing.Color.Gray;
            enhancedColumnHeaderRenderer4.SelectedGridLineColor = System.Drawing.Color.DimGray;
            enhancedColumnHeaderRenderer4.TextRotationAngle = 0;
            enhancedRowHeaderRenderer4.ActiveBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedRowHeaderRenderer4.Name = "enhancedRowHeaderRenderer4";
            enhancedRowHeaderRenderer4.NormalBackgroundColor = System.Drawing.Color.Silver;
            enhancedRowHeaderRenderer4.NormalGridLineColor = System.Drawing.Color.DarkGray;
            enhancedRowHeaderRenderer4.SelectedActiveBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedRowHeaderRenderer4.SelectedBackgroundColor = System.Drawing.Color.Gray;
            enhancedRowHeaderRenderer4.SelectedGridLineColor = System.Drawing.Color.DimGray;
            enhancedRowHeaderRenderer4.TextRotationAngle = 0;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "4.0.2001.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSpread1.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.Silver;
            enhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.DimGray;
            enhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.DimGray;
            enhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.Gray;
            enhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.Gray;
            this.fpSpread1.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.fpSpread1.HorizontalScrollBar.TabIndex = 7;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpSpread1.Location = new System.Drawing.Point(3, 2);
            this.fpSpread1.Name = "fpSpread1";
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            enhancedColumnHeaderRenderer1.ActiveBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedColumnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            enhancedColumnHeaderRenderer1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            enhancedColumnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            enhancedColumnHeaderRenderer1.Name = "";
            enhancedColumnHeaderRenderer1.NormalBackgroundColor = System.Drawing.Color.Silver;
            enhancedColumnHeaderRenderer1.NormalGridLineColor = System.Drawing.Color.DarkGray;
            enhancedColumnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            enhancedColumnHeaderRenderer1.SelectedActiveBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedColumnHeaderRenderer1.SelectedBackgroundColor = System.Drawing.Color.Gray;
            enhancedColumnHeaderRenderer1.SelectedGridLineColor = System.Drawing.Color.DimGray;
            enhancedColumnHeaderRenderer1.TextRotationAngle = 0;
            namedStyle1.Renderer = enhancedColumnHeaderRenderer1;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            enhancedRowHeaderRenderer1.ActiveBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedRowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            enhancedRowHeaderRenderer1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            enhancedRowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            enhancedRowHeaderRenderer1.Name = "";
            enhancedRowHeaderRenderer1.NormalBackgroundColor = System.Drawing.Color.Silver;
            enhancedRowHeaderRenderer1.NormalGridLineColor = System.Drawing.Color.DarkGray;
            enhancedRowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            enhancedRowHeaderRenderer1.SelectedActiveBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedRowHeaderRenderer1.SelectedBackgroundColor = System.Drawing.Color.Gray;
            enhancedRowHeaderRenderer1.SelectedGridLineColor = System.Drawing.Color.DimGray;
            enhancedRowHeaderRenderer1.TextRotationAngle = 0;
            namedStyle2.Renderer = enhancedRowHeaderRenderer1;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            enhancedCornerRenderer1.ActiveBackgroundColor = System.Drawing.Color.Gray;
            enhancedCornerRenderer1.GridLineColor = System.Drawing.Color.DimGray;
            enhancedCornerRenderer1.NormalBackgroundColor = System.Drawing.Color.DarkGray;
            namedStyle3.Renderer = enhancedCornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3});
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(294, 468);
            this.fpSpread1.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Metallic;
            this.fpSpread1.TabIndex = 0;
            this.fpSpread1.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSpread1.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.Silver;
            enhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.DimGray;
            enhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.DimGray;
            enhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.Gray;
            enhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.Gray;
            this.fpSpread1.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.fpSpread1.VerticalScrollBar.TabIndex = 8;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 1;
            this.fpSpread1_Sheet1.RowCount = 23;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "Order1",
        "Order2",
        "Order3",
        "Order4"};
            this.fpSpread1_Sheet1.Cells.Get(0, 0).CellType = comboBoxCellType1;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Cells.Get(0, 0).Value = "Order1";
            this.fpSpread1_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderMetallic";
            this.fpSpread1_Sheet1.ColumnHeader.Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 142F;
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(0, 0).Value = "투입 계획";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(1, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(1, 0).Value = "PRIORITY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(2, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(2, 0).Value = "PROD_KIND";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(3, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(3, 0).Value = "PROCESSID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(4, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(4, 0).Value = "PROD_TYPE";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(5, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(5, 0).Value = "PRODUCTID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(6, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(6, 0).Value = "STEPID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(7, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(7, 0).Value = "PPID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(8, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(8, 0).Value = "FLOWID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(9, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(9, 0).Value = "BATCHID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(10, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(10, 0).Value = "BATCH_STATE";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(11, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(11, 0).Value = "BATCH_SIZE";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(12, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(12, 0).Value = "P_MAKER";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(13, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(13, 0).Value = "P_THICKNESS";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(14, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(14, 0).Value = "F_PANELID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(15, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(15, 0).Value = "C_PANELID";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(16, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(16, 0).Value = "INPUT_LINE";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(17, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(17, 0).Value = "VALID_FLAG";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(18, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(18, 0).Value = "C_QTY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(19, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(19, 0).Value = "O_QTY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(20, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(20, 0).Value = "R_QTY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(21, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(21, 0).Value = "N_QTY";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(22, 0).Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(22, 0).Value = "FlowGroupSetList";
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 140F;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderMetallic";
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "CornerMetallic";
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PlanCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 501);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fpSpread1);
            this.Name = "PlanCreateForm";
            this.Text = "PlanCreateForm";
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Button button1;
    }
}