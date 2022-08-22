using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TabletimeBot
{
    class Program
    {
        private static string token { get; set; } = "5640893400:AAG9qA2bgpEQV9M0WNehESZzxU_ks-UENkk";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
            
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                
  //              await client.SendTextMessageAsync(msg.Chat.Id, "привет(;", replyMarkup: GetButtons());
  //              var stic = client.SendStickerAsync(
  //                  chatId: msg.Chat.Id,
  //                  sticker: "https://tlgrm.ru/_/stickers/ccd/a8d/ccda8d5d-d492-4393-8bb7-e33f77c24907/20.jpg",
  //                  replyToMessageId: msg.MessageId);
                switch(msg.Text)
                {
                    case "Стикер":
                        var stic = client.SendStickerAsync(
                      chatId: msg.Chat.Id,
                      sticker: "https://tlgrm.ru/_/stickers/b0d/85f/b0d85fbf-de1b-4aaf-836c-1cddaa16e002/1.webp",
                      replyToMessageId: msg.MessageId);
                      break;
                    case "Привет":
                        await client.SendTextMessageAsync(msg.Chat.Id, "привет(;", replyMarkup: GetButtons());
                        break;
                    case "picture":
                        var picture = client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            "https://tlgrm.ru/_/stickers/ccd/a8d/ccda8d5d-d492-4393-8bb7-e33f77c24907/20.jpg",
                            replyMarkup: GetButtons());
                        break;
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "write a word");
                        break;
                }
            }
            
        }

        private static IReplyMarkup GetButtons()
        {

            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                     {

                        new List<KeyboardButton>{ new KeyboardButton { Text = "Стикер"}, new KeyboardButton { Text = "Привет"} },
                        new List<KeyboardButton>{ new KeyboardButton { Text = "picture"}, new KeyboardButton { Text = "456"} },
                        new List<KeyboardButton>{ new KeyboardButton {  Text = "deiwdwefjewfwj"}, new KeyboardButton { Text = "21312fe2"},  new KeyboardButton { Text = "456"}, new KeyboardButton { Text = "Стикер" }, }
                    }
            };

        }
    } 

}
