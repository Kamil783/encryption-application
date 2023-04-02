using TestTask.Models;

namespace TestTask.Data
{
    public interface IEncryptedMessageRepository
    {
        IEnumerable<EncryptedMessage> GetAllMessages();
        void AddMessage(EncryptedMessage message);
        public bool SaveChanges();
    }
}
