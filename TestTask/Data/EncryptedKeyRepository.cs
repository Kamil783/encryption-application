using TestTask.Models;

namespace TestTask.Data
{
    public class EncryptedKeyRepository : IEncryptedKeyRepository
    {
        private readonly MessageContext _messageContext;
        public EncryptedKeyRepository(MessageContext messageContext) 
        {
            _messageContext = messageContext;
        }

        public IEnumerable<EncryptedKey> GetEncryptedKeys()
        {
            return _messageContext.EncryptedKeys.ToList();
        }
    }
}
