using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PictureMarkingContracts.Interface
{
    public interface ISocketService
    {
        void Add(string docID, string userID, WebSocket socket);
        Task Handle(WebSocket webSocket);
        Task<WebSocketReceiveResult> Message(WebSocket webSocket, byte[] buffer);
    }
}
