namespace HostCore
{
	partial class HostCom
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
			this.logManager = new LogCore.LogManager(this.components);
			this.SuspendLayout();
			// 
			// logManager
			// 
			this.logManager.LogDeleteDay = 100;
			this.logManager.LogFilePath = "";
			// 
			// HostCom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.ClientSize = new System.Drawing.Size(307, 56);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "HostCom";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private LogCore.LogManager logManager;
	}
}
