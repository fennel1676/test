namespace HostCore
{
	partial class HostCom
	{
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		/// <param name="disposing">�����Ǵ� ���ҽ��� �����ؾ� �ϸ� true�̰�, �׷��� ������ false�Դϴ�.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form �����̳ʿ��� ������ �ڵ�

		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
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
