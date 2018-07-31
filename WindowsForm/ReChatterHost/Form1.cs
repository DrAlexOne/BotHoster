using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReChatterHost
{
    public partial class Form1 : Form
    {
        static BackgroundWorker bw;

        public static string comingsoon = "Wait for next updates";

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
            string f = Console.ReadLine();
        }
        async static void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var key = "TOKEN"; // <<< PUT REAL KEY
                        
            try
            {

                var Bot = new Telegram.Bot.TelegramBotClient(key);
                //Bot.SetWebhook("");
                //await Bot.SetWebhookAsync("");



                int offset = 0;
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);

                    foreach (var update in updates)
                    {
                        var message = update.Message;


                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                        {

                            if (message.Text == "/start")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Hi! Welcome to Rechatter Bot!. With me you can send incognito messages to any user. To use me, you should have app ReChatter Bot App on your Windows Device (XBox/WindowsPhone/WindowsPC etc.). Right now you cant find any release for this app. So to get this app contact to developer @AlexBesida. Using me without special app is working in progress.", replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Alex Besida", "https://t.me/AlexBesida")));
                            }


                            if (message.Text == "/developer" || message.Text == "/developer@" + AppSettings.Name)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "I was made by @AlexBesida with @mkenzo_8.");
                            }

                            if (message.Text == "/sendmessage" || message.Text == "/sendmessage@" + AppSettings.Name)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, comingsoon);
                            }

                            if (message.Text == "/feedback" || message.Text == "/feedback@" + AppSettings.Name)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, comingsoon);
                            }

                            if (message.Text == "/help" || message.Text == "/help@" + AppSettings.Name)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, comingsoon);
                            }

                            if (message.Text == "/settings" || message.Text == "/settings@" + AppSettings.Name)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, comingsoon);
                            }

                            if (message.Text == "/id" || message.Text == "/id@" + AppSettings.Name)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Your ID: " + message.Chat.Id + ".");
                            }
                        }

                        offset = update.Id + 1;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

    }
}
