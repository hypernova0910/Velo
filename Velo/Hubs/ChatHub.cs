using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Velo.Models;

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
        public string Message(string messageJSON)
        {
            //trả về cho client pt message
            MESSAGE message = JsonConvert.DeserializeObject<MESSAGE>(messageJSON);
            message.Message_ID = Guid.NewGuid().ToString().Substring(0, 10);
            message.Time_sent = DateTime.Now;
            using(var db = new MyDB())
            {
                db.MESSAGEs.Add(message);
                db.SaveChanges();
                message = db.MESSAGEs.Find(message.Message_ID);
            }
            messageJSON = JsonConvert.SerializeObject(message);
            //MESSAGE msg = new MESSAGE();
            //msg.Conversation_ID = message.conversation_id;
            Clients.Others.message(messageJSON);
            return message.Message_ID;
        }
    }
}