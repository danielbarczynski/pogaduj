using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using pogaduj.Models;
using pogaduj.Repository;

namespace pogaduj.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private IMessages _repository;
        public ChatHub(IMessages repository)
        {
            _repository = repository;
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            var currentUser = Context.User.Identity.Name;
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public Task JoinMessage(string roomName)
        {
            var currentUser = Context.User.Identity.Name;       
            return Clients.Group(roomName).SendAsync("OnMessageSent", "System: ", $"Użytkownik {currentUser} dołączył do pokoju");
        }

        public Task LeaveMessage(string roomName)
        {
            var currentUser = Context.User.Identity.Name;
            return Clients.Group(roomName).SendAsync("OnMessageSent", "System", $"Użytkownik {currentUser} opuścił pokój");
        }

        public Task SendMessage(string message, string roomName)
        {
            var currentUser = Context.User.Identity.Name;
            return Clients.Group(roomName).SendAsync("OnMessageSent", currentUser, message);

            //var messageEntity = new MessageModel()
            //{
            //    Username = currentUser,
            //    Message = message,
            //};

            //_repository.Add(messageEntity);
        }
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception e)
        //{
        //    await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
        //    await base.OnDisconnectedAsync(e);
        //}

    }

}
