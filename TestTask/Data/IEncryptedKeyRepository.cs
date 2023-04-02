using TestTask.Models;

namespace TestTask.Data
{
    public interface IEncryptedKeyRepository
    {
        public IEnumerable<EncryptedKey> GetEncryptedKeys();
    }
}
