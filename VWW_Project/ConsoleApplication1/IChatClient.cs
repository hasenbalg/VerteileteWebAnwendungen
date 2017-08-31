using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    [ServiceContract]
    interface IChatClient
    {
        [OperationContract(IsOneWay = true)]
        void RecieveMessage(string user, string message);

        [OperationContract(IsOneWay = true)]
        void UpdateOnlineUsers();

        [OperationContract(IsOneWay = true)]
        void UpdateCalendar();
    }
}
