namespace EqCore
{
	partial class EqCom
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EqCom));
			this.label1 = new System.Windows.Forms.Label();
			this.coreNetOCX = new AxCoreNetLibLib.AxCoreNetLib();
			this.logManager = new LogCore.LogManager(this.components);
			this.timerSecond10 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.coreNetOCX)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(52, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "이 Form은 X-Net 프로토콜 통신을 하기위해\r\nXml Parse 기능을 포함하여 제작하였습니다.";
			this.label1.Visible = false;
			// 
			// coreNetOCX
			// 
			this.coreNetOCX.Enabled = true;
			this.coreNetOCX.Location = new System.Drawing.Point(12, 12);
			this.coreNetOCX.Name = "coreNetOCX";
			this.coreNetOCX.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("coreNetOCX.OcxState")));
			this.coreNetOCX.Size = new System.Drawing.Size(32, 32);
			this.coreNetOCX.TabIndex = 4;
			this.coreNetOCX.OnConnection += new System.EventHandler(this.coreNetOCX_OnConnection);
			this.coreNetOCX.OnReceive += new AxCoreNetLibLib._DCoreNetLibEvents_OnReceiveEventHandler(this.coreNetOCX_OnReceive);
			this.coreNetOCX.OnClose += new System.EventHandler(this.coreNetOCX_OnClose);
			// 
			// logManager
			// 
			this.logManager.LogDeleteDay = 100;
			this.logManager.LogFilePath = "";
			// 
			// timerSecond10
			// 
			this.timerSecond10.Enabled = true;
			this.timerSecond10.Interval = 10000;
			this.timerSecond10.Tick += new System.EventHandler(this.timerSecond10_Tick);
			// 
			// EqCom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(307, 56);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.coreNetOCX);
			this.Name = "EqCom";
			this.Text = "EqCom";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EqCom_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.coreNetOCX)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private AxCoreNetLibLib.AxCoreNetLib coreNetOCX;
		private LogCore.LogManager logManager;
		private System.Windows.Forms.Timer timerSecond10;
	}
}