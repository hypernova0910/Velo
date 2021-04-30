using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Velo.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        //Mình tạo ra phương thức Connect sẽ được connect từ server vào vói tham số name
        public void Connect(string name)
        {
            //trả về cho client phương thức  connect
            Clients.Caller.connect(name);
        }
        public void Message(string messageJSON)
        {
            //trả về cho client pt message vs 2 tham số
            Clients.Others.message(messageJSON);
        }
    }
}