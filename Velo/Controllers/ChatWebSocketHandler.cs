using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Velo.Controllers
{
    public class ChatWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection _chatClients = new WebSocketCollection();

        public override void OnOpen()
        {
            _chatClients.Add(this);
        }

        public override void OnMessage(string recordType)
        {

            for (int i = 0; i < 10; i++)
            {
                _chatClients.Broadcast(i.ToString());
                System.Threading.Thread.Sleep(1000);
            }
        }

        public override void OnClose()
        {
            _chatClients.Remove(this);
        }
    }
}