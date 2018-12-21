using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using static System.Console;

namespace ConsoleModeChatClient
{
    class ChatCallback : ChatClient.IChatCallback
    {
        public void receive(string what, string from)
        {
            WriteLine($"\n{from} says {what}");
        }
    }
    class ChatClientMain
    {
        static void Main(string[] args)
        {
            var ctx = new InstanceContext(new ChatCallback());
            //var chatClient = new ConsoleModeChatClient.ChatClient.ChatSvcClient(ctx);
            var chatClient = new DuplexChannelFactory<ChatClient.IChat>(ctx, "netTcpBinding.ChatSvc").CreateChannel();
            var name = args.Count() == 0 ? "Mr Nobody" : args[0];
            chatClient.join(name);
            string what = ReadAndPrompt(name);
            while (what != null)
            {
                chatClient.send(what);
                what = ReadAndPrompt(name);
            }
            chatClient.leave();
        }

        private static string ReadAndPrompt(string name)
        {
            Write($"\n what does {name} say?  ");
            var what = ReadLine();
            return what;
        }
    }
}
