using TestTask.Models;

namespace TestTask.Data
{
    public class EncryptedMessageRepository : IEncryptedMessageRepository
    {
        private readonly MessageContext _message;

        public EncryptedMessageRepository(MessageContext message)
        {
            _message = message;
        }

        public IEnumerable<EncryptedMessage> GetAllMessages()
        {
            return _message.EncryptedMessages.ToList();
        }

        public bool SaveChanges()
        {
            return (_message.SaveChanges() >= 0);
        }

        public void AddMessage(EncryptedMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            _message.EncryptedMessages.Add(message);
        }
    }
}
