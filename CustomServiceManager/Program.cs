using System;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "CustomServiceManager.log.config", Watch = true)]

namespace CustomServiceManager
{
    static class Program
    {
        public static String SelectedGroup = "Default";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Setting.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Manager());
        }
    }
}
