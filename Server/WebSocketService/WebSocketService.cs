using Contracts;
using Contracts.DTO;
using Newtonsoft.Json;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.Drawing;
using PictureMarkingContracts.DTO.Marker;
using PictureMarkingContracts.Interface;
using PictureMarkingContracts.Interface.Marker;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketService
{
    [Register(Policy.Singleton, typeof(ISocketService))]
    public class WebSocketService : ISocketService
    {
        ICreateMarkerService _createMarkerService;
        IReadMarkerService _readMarkerService;
        ConcurrentDictionary<string, List<User>> _doc2users;
        Dictionary<string, Action<DrawingMsg>> _type2func;

        public WebSocketService(ICreateMarkerService createMarkerService, IReadMarkerService readMarkerService)
        {
            _createMarkerService = createMarkerService;
            _readMarkerService = readMarkerService;
            _doc2users = new ConcurrentDictionary<string, List<User>>();
            _type2func = new Dictionary<string, Action<DrawingMsg>>();
            InitType2Func();
        }

        public void InitType2Func()
        {
            _type2func.Add("Ellipse", DrawEllipse);
            _type2func.Add("Rectangle", DrawRectangle);
            _type2func.Add("Free", FreeDraw);
        }

        public async Task Handle(WebSocket socket)
        {
            var buffer = new byte[1024 * 4];
            var msg = await Message(socket, buffer);
           
            while (socket.State == WebSocketState.Open)
            {
                var requestString = Encoding.UTF8.GetString(buffer);
                System.Diagnostics.Debug.WriteLine(requestString + '\n');
                DrawingMsg deserializedMsg = JsonConvert.DeserializeObject<DrawingMsg>(requestString);
                System.Diagnostics.Debug.WriteLine(buffer.Length.ToString() + '\n');
                System.Diagnostics.Debug.WriteLine(msg.Count.ToString() + ' ' + msg.MessageType.ToString() + ' ' + msg.EndOfMessage + '\n');
                if (_type2func.ContainsKey(deserializedMsg.Drawing.DrawType))
                {
                    _type2func[deserializedMsg.Drawing.DrawType](deserializedMsg);
                }
                await Broadcast(_doc2users[deserializedMsg.Drawing.DocumentID], buffer, msg);
                buffer = new byte[1024 * 4];
                msg = await Message(socket, buffer);
            }
            await Close(socket, msg);
        }

        public async Task<WebSocketReceiveResult> Message(WebSocket webSocket, byte[] buffer)
        {
            return await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        public async Task Send(WebSocket webSocket, byte[] buffer, WebSocketReceiveResult msg)
        {
            await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, msg.Count), msg.MessageType, msg.EndOfMessage, CancellationToken.None);
        }

        public async Task Broadcast(List<User> users, byte[] buffer, WebSocketReceiveResult msg)
        {
            foreach (var user in users)
            {
                if (user.Socket.State == WebSocketState.Open)
                {
                    await Send(user.Socket, buffer, msg);
                } else
                {
                    users.Remove(user);
                }
            }
        }

        async Task Close(WebSocket webSocket, WebSocketReceiveResult msg)
        {
            foreach (var docID in _doc2users.Keys)
            {
                User user = _doc2users[docID].FirstOrDefault(x => x.Socket == webSocket);
                if (user != null)
                {
                    _doc2users[docID].Remove(user);
                    break;
                }
            }

            await webSocket.CloseAsync(msg.CloseStatus.Value, msg.CloseStatusDescription, CancellationToken.None);
        }

        public void Add(string docID, string userID, WebSocket socket)
        {
            var user = new User() { Socket = socket, UserID = userID };
            if (!_doc2users.ContainsKey(docID))
            {
                var list = new List<User>();
                _doc2users.TryAdd(docID, list);
            }
            _doc2users[docID].Add(user);
        }

        public void FreeDraw(DrawingMsg msg)
        {
        }

        public void DrawEllipse(DrawingMsg msg)
        {
            var marker = new MarkerDTO()
            {
                DocumentID = msg.Drawing.DocumentID,
                MarkerID = null,
                MarkerType = "Ellipse",
                MarkerLocation = msg.Drawing.DrawObj,
                MarkerColor = "black",
                UserID = msg.Drawing.UserID
            };
            _createMarkerService.CreateMaker(new CreateMarkerRequest() { Marker = marker });
        }

        public void DrawRectangle(DrawingMsg msg)
        {
            var marker = new MarkerDTO()
            {
                DocumentID = msg.Drawing.DocumentID,
                MarkerID = null,
                MarkerType = "Rectangle",
                MarkerLocation = msg.Drawing.DrawObj,
                MarkerColor = "black",
                UserID = msg.Drawing.UserID
            };
            _createMarkerService.CreateMaker(new CreateMarkerRequest() { Marker = marker });
        }
    }
}
