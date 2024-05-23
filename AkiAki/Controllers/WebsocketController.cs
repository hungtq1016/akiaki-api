using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace AkiAki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSocketController : ControllerBase
    {
        private static ConcurrentDictionary<string, WebSocket> connections = new ConcurrentDictionary<string, WebSocket>();
        private static WebSocket adminSocket = null;
        private static string adminUserName = "admin";

        [HttpGet("ws")]
        public async Task<IActionResult> WebSocketHandler([FromQuery] string name = "anonymous")
        {
            if (!HttpContext.WebSockets.IsWebSocketRequest)
                return BadRequest();    

            var userName = name;
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            if (userName == adminUserName)
            {
                adminSocket = webSocket;
            }
            else
            {
                connections.TryAdd(userName, webSocket);
                await NotifyAdminUserConnected(userName);
            }

            await ReceiveMessage(userName, webSocket);

            return Ok();
        }

        [HttpGet("users")]
        public IActionResult GetConnectedUsers()
        {
            var users = connections.Keys.ToList();
            return Ok(new Core.Response<List<string>>
            {
                Data = users,
                IsError = false,
                Message = "Successfully!",
                StatusCode = 200,
            });
        }

       [HttpPost("send")]
        public async Task<IActionResult> SendMessageToUser([FromBody] AdminMessage message)
        {
            if (connections.TryGetValue(message.TargetUser, out var socket) && socket.State == WebSocketState.Open)
            {
                var msgBytes = Encoding.UTF8.GetBytes(message.Content);
                var arraySegment = new ArraySegment<byte>(msgBytes, 0, msgBytes.Length);
                await socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                return Ok();
            }
            return NotFound();
        }

        public class AdminMessage
        {
            public string TargetUser { get; set; }
            public string Content { get; set; }
        }



        private async Task ReceiveMessage(string userName, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        await Broadcast($"{userName}: {message}");
                    }
                    else if (result.MessageType == WebSocketMessageType.Close || webSocket.State == WebSocketState.Aborted)
                    {
                        break;
                    }
                }
            }
            finally
            {
                connections.TryRemove(userName, out _);
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", CancellationToken.None);
            }
        }

        private async Task Broadcast(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            var tasks = new List<Task>();
            foreach (var socket in connections.Values)
            {
                if (socket.State == WebSocketState.Open)
                {
                    var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
                    tasks.Add(socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None));
                }
            }
            await Task.WhenAll(tasks);
        }

        private async Task NotifyAdminUserConnected(string userName)
        {
            if (adminSocket != null && adminSocket.State == WebSocketState.Open)
            {
                var msgBytes = Encoding.UTF8.GetBytes($"User {userName} has connected.");
                var arraySegment = new ArraySegment<byte>(msgBytes, 0, msgBytes.Length);
                await adminSocket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
