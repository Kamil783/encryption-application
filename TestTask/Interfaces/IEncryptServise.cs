using TestTask.DTOs;
using TestTask.Models;

namespace TestTask.Interfaces
{
    public interface IEncryptService
    {
        public EncryptedMessage EncryptMessage(MessageDTO message);
    }
}
