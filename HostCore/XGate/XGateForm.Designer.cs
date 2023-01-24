namespace HostCore
{
	partial class XGateForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XGateForm));
			this.xGateOCX = new AxXGateLib.AxXGate();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.xGateOCX)).BeginInit();
			this.SuspendLayout();
			// 
			// xGateOCX
			// 
			this.xGateOCX.Enabled = true;
			this.xGateOCX.Location = new System.Drawing.Point(12, 12);
			this.xGateOCX.Name = "xGateOCX";
			this.xGateOCX.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("xGateOCX.OcxState")));
			this.xGateOCX.Size = new System.Drawing.Size(32, 32);
			this.xGateOCX.TabIndex = 0;
			this.xGateOCX.OnDisconnected += new System.EventHandler(this.xGateOCX_OnDisconnected);
			this.xGateOCX.OnSecsTimeOut += new AxXGateLib._DXProPlusEvents_OnSecsTimeOutEventHandler(this.xGateOCX_OnSecsTimeOut);
			this.xGateOCX.OnSelected += new System.EventHandler(this.xGateOCX_OnSelected);
			this.xGateOCX.OnSecsMsg += new AxXGateLib._DXProPlusEvents_OnSecsMsgEventHandler(this.xGateOCX_OnSecsMsg);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(52, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(250, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "이 Form은 Hsms 프로토콜 통신을 하기위해\r\n상속 받을 수 있는 Form으로 제작하였습니다.";
			this.label1.Visible = false;
			// 
			// XGateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(307, 56);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.xGateOCX);
			this.Name = "XGateForm";
			this.Text = "XGateForm";
			((System.ComponentModel.ISupportInitialize)(this.xGateOCX)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private AxXGateLib.AxXGate xGateOCX;
		private System.Windows.Forms.Label label1;
	}
}