using System;
using Telegram.Bot;
using System.IO;
using System.Threading;

namespace tya
{
    class MainClass
    {
        private static TelegramBotClient tya = new TelegramBotClient("1358036713:AAHL2lP4GK9Tmu6MuRsaGh417LY9Fi2kWFQ");
        public static void Main(string[] args)
        {
            Directory.CreateDirectory("data");
            Directory.CreateDirectory("./data/tya");
            Directory.CreateDirectory("./data/tyalearns");
            Directory.CreateDirectory("./data/tyausers");
            Directory.CreateDirectory("./data/tyamutes");
            tya.OnMessage += Tya_OnMessage;
            tya.StartReceiving();
            while (true)
            {
                string msg = Console.ReadLine();
                if (msg == "exit")
                {
                    Console.WriteLine("Bye!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Sending...");
                    string[] users = Directory.GetFiles("./data/tyausers/");
                    foreach (string user in users)
                    {
                        tya.SendTextMessageAsync(user.Split('/')[3], File.ReadAllText(user) + "," + msg);
                        Console.WriteLine("Sent to: " + File.ReadAllText(user));
                    }
                    Console.WriteLine("Sent...");
                }
            }
        }

        private static void Tya_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (File.Exists("./data/tyamutes/" + e.Message.Chat.Id))
            {
                if(new Random().Next(1, 20) == 13)
                {
                    if (e.Message.Text == null)
                    {
                        tya.SendTextMessageAsync(e.Message.Chat.Id, "...");
                    }
                    else
                    {
                        if(File.Exists("./data/tyamutes/" + 343791619))
                        {
                            if(new Random().Next(1, 20) == 13)
                            {
                                tya.SendTextMessageAsync(343791619, "Daddy!DADDY!\nSomeone is talking to me!!!\n" + e.Message.Chat.Username + "\n" + e.Message.Chat.Id + "\n" + "said:\n" + e.Message.Text);
                            }
                        }
                        else
                        {
                            tya.SendTextMessageAsync(343791619, "Daddy!DADDY!\nSomeone is talking to me!!!\n" + e.Message.Chat.Username + "\n" + e.Message.Chat.Id + "\n" + "said:\n" + e.Message.Text);
                        }
                        if (File.Exists("./data/tyalearns/" + e.Message.Chat.Id))
                        {
                            if (e.Message.Text == "Nothing")
                            {
                                Console.WriteLine("😩");
                                tya.SendTextMessageAsync(e.Message.Chat.Id, "Ok,i won't learn.😩", replyToMessageId: e.Message.MessageId);
                                File.Delete("./data/tyalearns/" + e.Message.Chat.Id);
                            }
                            else
                            {
                                try
                                {
                                    Console.WriteLine(e.Message.Chat.Username + " teached me " + File.ReadAllText("./data/tyalearns/" + e.Message.Chat.Id) + "😃");
                                    File.WriteAllText("./data/tya/" + File.ReadAllText("./data/tyalearns/" + e.Message.Chat.Id), e.Message.Text);
                                    File.Delete("./data/tyalearns/" + e.Message.Chat.Id);
                                    tya.SendTextMessageAsync(e.Message.Chat.Id, "Thank you " + e.Message.Chat.FirstName + ",i love to learn new things!😄", replyToMessageId: e.Message.MessageId);
                                }
                                catch
                                {
                                    Console.WriteLine("MMM?");
                                }
                            }
                        }
                        /*else if (e.Message.Text == "/love")
                        {
                            tya.SendTextMessageAsync(e.Message.Chat.Id, "Thank you!i will be more online to hang out with you!", replyToMessageId: e.Message.MessageId);
                        }
                        else if (e.Message.Text == "/award")
                        {
                            tya.SendTextMessageAsync(e.Message.Chat.Id, "(YAY)Hello,Martia talking.\nTya likes your award and he is stuttering about where to place it.\nHe may come back in a little matter of time.\nRemeber to only give him an award if he is a good boy,\ni don't want him to be selfish...\nThank you.");
                            Thread.Sleep(3000);
                        }*/
                        else if (e.Message.Text.Split('|')[0] == "/modify")
                        {
                            File.WriteAllText("./data/tya/" + e.Message.Text.Split('|')[1], e.Message.Text.Split('|')[2]);
                            tya.SendTextMessageAsync(e.Message.Chat.Id, "Don't blame me!\nNot my fault!", replyToMessageId: e.Message.MessageId);
                        }
                        else if (e.Message.Text == "/mute")
                        {
                            tya.SendTextMessageAsync(e.Message.Chat.Id,"Sorry for disturbing you,i will see you later...🥺");
                            File.WriteAllText("./data/tyamutes/" + e.Message.Chat.Id, "muted");
                        }

                        else if (e.Message.Text == "/unmute")
                        {
                            tya.SendTextMessageAsync(e.Message.Chat.Id, "Hi again!\nThank you for unmuting!🥰");
                            File.Delete("./data/tyamutes/" + e.Message.Chat.Id);
                        }
                        else
                        {
                            if (e.Message.Text == "/start")
                            {
                                Console.WriteLine(e.Message.Chat.Username + " said hello!");
                                tya.SendTextMessageAsync(e.Message.Chat.Id, "Hi " + e.Message.Chat.FirstName + "!i am so excited that i have a new friend!😆🥳\ni am a kind of a computer program that my dad made for me to make me talk to other people.(cause i am not very social,you know,i always only respond if i'm ask for...😕)\n*(also this reply thingy is so awesome!)*", replyToMessageId: e.Message.MessageId);
                                File.WriteAllText("./data/tyausers/" + e.Message.Chat.Id, e.Message.Chat.FirstName);
                            }
                            else
                            {
                                if (File.Exists("./data/tya/" + e.Message.Text))
                                {
                                    try
                                    {
                                        Console.WriteLine(e.Message.Chat.Username + " said:" + e.Message.Text);
                                        tya.SendTextMessageAsync(e.Message.Chat.Id, File.ReadAllText("./data/tya/" + e.Message.Text), replyToMessageId: e.Message.MessageId);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("MMM?");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(e.Message.Chat.FirstName + " is teaching me!☺️");
                                    tya.SendTextMessageAsync(e.Message.Chat.Id, "/", replyToMessageId: e.Message.MessageId);
                                    File.WriteAllText("./data/tyalearns/" + e.Message.Chat.Id, e.Message.Text);
                                }
                            }
                        }
                    }
                }
                else if (e.Message.Text == "/unmute")
                {
                    tya.SendTextMessageAsync(e.Message.Chat.Id, "Hi again!\nThank you for unmuting!🥰");
                    File.Delete("./data/tyamutes/" + e.Message.Chat.Id);
                }
            }
            else
            {
                if (e.Message.Sticker != null)
                {
                    if (File.Exists("./data/tya/" + e.Message.Text))
                    {
                        Console.WriteLine(e.Message.Chat.Username + " sent:" + e.Message.Sticker.Emoji);
                        tya.SendTextMessageAsync(e.Message.Chat.Id, File.ReadAllText("./data/tya/" + e.Message.Sticker.Emoji), replyToMessageId: e.Message.MessageId);
                    }
                    else
                    {
                        Console.WriteLine(e.Message.Chat.FirstName + " is showing emojis to me!☺️");
                        tya.SendTextMessageAsync(e.Message.Chat.Id, "Oh!what does that sticker mean?", replyToMessageId: e.Message.MessageId);
                        File.WriteAllText("./data/tyalearns/" + e.Message.Chat.Id, e.Message.Sticker.Emoji);
                    }
                }
               
                else if (e.Message.Text == null)
                {
                    tya.SendTextMessageAsync(e.Message.Chat.Id, "What is that? *(dad?what is this that "+e.Message.Chat.FirstName+" showed to me?)*");
                }
                else
                {
                    if (File.Exists("./data/tyamutes/" + 343791619))
                    {
                        if (new Random().Next(1, 20) == 13)
                        {

                            tya.SendTextMessageAsync(343791619, "Daddy!DADDY!\nSomeone is talking to me!!!\n" + e.Message.Chat.Username + "\n" + e.Message.Chat.Id + "\n" + "said:\n" + e.Message.Text);
                        }
                    }
                    if (File.Exists("./data/tyalearns/" + e.Message.Chat.Id))
                    {
                        if (e.Message.Text == "Nothing")
                        {
                            Console.WriteLine("😩");
                            tya.SendTextMessageAsync(e.Message.Chat.Id, "Ok,i won't learn.🙁", replyToMessageId: e.Message.MessageId);
                            File.Delete("./data/tyalearns/" + e.Message.Chat.Id);
                        }
                        else
                        {
                            try
                            {
                                Console.WriteLine(e.Message.Chat.Username + " teached me " + File.ReadAllText("./data/tyalearns/" + e.Message.Chat.Id) + "😃");
                                File.WriteAllText("./data/tya/" + File.ReadAllText("./data/tyalearns/" + e.Message.Chat.Id), e.Message.Text);
                                File.Delete("./data/tyalearns/" + e.Message.Chat.Id);
                                tya.SendTextMessageAsync(e.Message.Chat.Id, "Thank you " + e.Message.Chat.FirstName + ",i love to learn new things!😄", replyToMessageId: e.Message.MessageId);
                            }
                            catch
                            {
                                Console.WriteLine("MMM?");
                            }
                        }
                    }
                    else if (e.Message.Text == "/love")
                    {
                        tya.SendTextMessageAsync(e.Message.Chat.Id, "Thank you!i will be more online to hang out with you!", replyToMessageId: e.Message.MessageId);
                    }
                    else if (e.Message.Text == "/award")
                    {
                        tya.SendTextMessageAsync(e.Message.Chat.Id, "Hello,Martia talking.\nTya likes your award and he is stuttering about where to place it.\nRemeber to only give him an award if he is a good boy,\ni don't want him to be selfish...\nThank you.");
                    }
                    else if (e.Message.Text.Split('|')[0] == "/modify")
                    {
                        File.WriteAllText("./data/tya/" + e.Message.Text.Split('|')[1], e.Message.Text.Split('|')[2]);
                        tya.SendTextMessageAsync(e.Message.Chat.Id, "Don't blame me!\nNot my fault!", replyToMessageId: e.Message.MessageId);
                    }
                    else if (e.Message.Text == "/mute")
                    {
                        tya.SendTextMessageAsync(e.Message.Chat.Id, "Sorry for disturbing you,i will see you later...🥺");
                        File.WriteAllText("./data/tyamutes/" + e.Message.Chat.Id, "muted");
                    }
                    else if (e.Message.Text == "/unmute")
                    {
                        tya.SendTextMessageAsync(e.Message.Chat.Id,"Hi again!\nThank you for unmuting!🥰");
                        File.Delete("./data/tyamutes/" + e.Message.Chat.Id);
                    }
                    else
                    {
                        if (e.Message.Text == "/start")
                        {
                            Console.WriteLine(e.Message.Chat.Username + " said hello!");
                            tya.SendTextMessageAsync(e.Message.Chat.Id, "Hi " + e.Message.Chat.FirstName + "!i am so excited that i have a new friend!😆🥳\ni am a kind of a computer program that my dad made for me to make me talk to other people.(cause i am not very social,you know,i always only respond if i'm ask for...😕)\n*(also this reply thingy is so awesome!)*", replyToMessageId: e.Message.MessageId);
                            File.WriteAllText("./data/tyausers/" + e.Message.Chat.Id, e.Message.Chat.FirstName);
                        }
                        else
                        {
                            if (File.Exists("./data/tya/" + e.Message.Text))
                            {
                                Console.WriteLine(e.Message.Chat.Username + " said:" + e.Message.Text);
                                tya.SendTextMessageAsync(e.Message.Chat.Id, File.ReadAllText("./data/tya/" + e.Message.Text), replyToMessageId: e.Message.MessageId);
                            }
                            else
                            {
                                Console.WriteLine(e.Message.Chat.FirstName + " is teaching me!☺️");
                                tya.SendTextMessageAsync(e.Message.Chat.Id, "What shall i respond?", replyToMessageId: e.Message.MessageId);
                                File.WriteAllText("./data/tyalearns/" + e.Message.Chat.Id, e.Message.Text);
                            }
                        }
                    }
                }
            }
        }
    }
}
