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

namespace Host
{
    static class FluxAssistant
    {

        static BackgroundWorker bw;

        public static string comingsoon = "Wait for next updates";

        public static void Main()
        {
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
        }
        public async static void Bw_DoWork(object sender, DoWorkEventArgs e)
        {

            var worker = sender as BackgroundWorker;
            var key = "627466136:AAFo8004Q5Z_UvZSjMsyiDstRcizoBE6xEQ"; // <<< PUT REAL KEY
            try
            {
                var Bot = new Telegram.Bot.TelegramBotClient(key);

                int offset = 0;
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);

                    foreach (var update in updates)
                    {
                        var message = update.Message;
                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                        {
                            if (message.Text == "/start" || message.Text == "/start@" + AppSettings.FAName)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Good day! I'm Flux Assistant. I am always ready to help you. Right now, I am in Alpha Version. My developer is @AlexBesida", replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Alex Besida", "https://t.me/AlexBesida")));
                            }

                            if (message.Text == "/developer" || message.Text == "/developer@" + AppSettings.FAName)
                            {

                                await Bot.SendTextMessageAsync(message.Chat.Id, "My developer is Alex Besida.", replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Alex Besida", "https://t.me/AlexBesida")));
                            }

                            if (message.Text == "/feedback" || message.Text == "/@" + AppSettings.FAName)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, comingsoon);
                            }

                            if (message.Text == "/help" || message.Text == "/help@" + AppSettings.FAName)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, comingsoon);
                            }

                            if (message.Text == "/settings" || message.Text == "/settings@" + AppSettings.FAName)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, comingsoon);
                            }

                            if (message.Text == "/myid" || message.Text == "/myid@" + AppSettings.FAName)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, message.From.ToString());
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
