using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageContext _message;

        public MessageRepository(MessageContext message)
        {
            _message = message;
        }
        public void AddMessage(Message message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            _message.Messages.Add(message);
        }

        public ActionResult<Message> GetMessageById(int id)
        {
            return _message.Messages.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
           return  (_message.SaveChanges() >= 0);
        }


    }
}
