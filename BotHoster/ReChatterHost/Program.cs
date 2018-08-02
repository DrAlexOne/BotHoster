using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using ReChatterHost;

namespace Host
{
    static class Program
    {
        public static string comingsoon = "Wait for next updates";
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            FA = new BackgroundWorker();
            FA.DoWork += FluxAssistant.Bw_DoWork;
            FA.RunWorkerAsync();

            RC = new BackgroundWorker();
            RC.DoWork += ReChatter.Bw_DoWork;
            RC.RunWorkerAsync(); */

            FluxAssistant.Main();
            ReChatter.Main();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
