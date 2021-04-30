using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Velo.Controllers
{
    public class SocketClientController : ApiController
    {
        public HttpResponseMessage Get()
        {
            if (HttpContext.Current.IsWebSocketRequest)
            {
                HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler());
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
