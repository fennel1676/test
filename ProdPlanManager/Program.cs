using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProdPlanManager
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 중복 실행 방지
            bool outResult;
            string type = "ProdPlanManager";
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, type, out outResult);

            if (!outResult)
            {
                MessageBox.Show("프로그램이 이미 실행중입니다.", "실행오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mutex.ReleaseMutex();
            }
        }
    }
}