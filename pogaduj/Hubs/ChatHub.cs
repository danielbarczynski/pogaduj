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
        public async Task SendMessage(string message)
        {
            var currentUser = Context.User.Identity.Name;
            await Clients.All.SendAsync("OnMessageSent", currentUser, message);

            var messageEntity = new MessageModel()
            {
                Username = currentUser,
                Message = message,
            };

            _repository.Add(messageEntity);
        }
    }

}
