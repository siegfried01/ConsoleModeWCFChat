using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using static System.Console;

namespace ConsoleModeChatSvcHost
{
    class HostMain
    {
        static void Main(string[] args)
        {
            var uri = new Uri("net.tcp://127.0.0.1:22222/ChatSvc");
            var chatHost = new ServiceHost(typeof(ConsoleModeChatSvcLib.ChatSvcImpl), uri);
            chatHost.Open();
            WriteLine($"Chat service listening on {uri}");
            WriteLine($"Press enter to stop chat service...");
            ReadLine();
            chatHost.Abort();
            chatHost.Close();
        }
    }
}
