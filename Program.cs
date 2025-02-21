using System;
using System.Windows.Forms;

namespace QRScannerApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QRScannerForm());
        }
    }
}
