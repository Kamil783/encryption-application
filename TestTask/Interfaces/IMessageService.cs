using TestTask.DTOs;
using TestTask.Models;

namespace TestTask.Interfaces
{
    public interface IMessageService
    {
        public EncryptedMessage EncryptMessage(MessageDTO message);
    }
}
