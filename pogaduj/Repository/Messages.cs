using pogaduj.Models;

namespace pogaduj.Repository
{
    public class Messages : IMessages
    {
        public readonly List<MessageModel> _messages = new List<MessageModel>();
        public void Add(MessageModel message)
        {
            _messages.Add(message);
        }
        public IEnumerable<MessageModel> GetAll()
        {
            return _messages;
        }

    }
}
