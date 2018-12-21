using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsoleModeChatSvcLib
{

    public class ChatSvcImpl : IChat
    {
        string name;
        public static Dictionary<string, IChatCallback> members = new Dictionary<string, IChatCallback>();
        public void join(string what)
        {
            this.name = what;
            var ctx = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            members.Add(what, ctx);
        }

        public void leave()
        {
            if (members.ContainsKey(name))
                members.Remove(name);
        }

        public void send(string what)
        {
            foreach (var key in members.Keys)
                members[key].receive($"\nto {key} \"{what}\"", this.name);
        }
    }
}
