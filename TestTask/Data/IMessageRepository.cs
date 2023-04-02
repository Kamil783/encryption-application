using Microsoft.AspNetCore.Mvc;
using TestTask.Models;

namespace TestTask.Data
{
    public interface IMessageRepository
    {
        bool SaveChanges();
        void AddMessage(Message message);
        public ActionResult<Message> GetMessageById(int id);
    }
}
