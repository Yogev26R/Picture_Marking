using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace WebSocketService
{
    public class User
    {
        public string UserID { get; set; }
        public WebSocket Socket { get; set; }

        public User()
        {
        }
    }
}
