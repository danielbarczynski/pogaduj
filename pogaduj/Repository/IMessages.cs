using pogaduj.Models;

namespace pogaduj.Repository
{
    public interface IMessages
    {
        void Add(MessageModel message);
        IEnumerable<MessageModel> GetAll();
    }
}
