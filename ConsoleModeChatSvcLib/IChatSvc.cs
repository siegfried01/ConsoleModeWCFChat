using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsoleModeChatSvcLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required
    , CallbackContract = typeof(IChatCallback)
     )]
    public interface IChat
    {
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void send(string what);

        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void join(string what);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void leave();

    }
    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void receive(string what, string from);
    }

}
