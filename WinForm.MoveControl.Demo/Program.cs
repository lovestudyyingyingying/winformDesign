using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinForm.MoveControl.Demo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalKeyboardHook.Start();
            Application.Run(new Form1());
            GlobalKeyboardHook.Stop();
        }
    }
}
