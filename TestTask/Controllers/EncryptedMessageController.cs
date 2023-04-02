using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptedMessageController : ControllerBase
    {
        private readonly IEncryptedMessageRepository _messageRepository;

        public EncryptedMessageController(IEncryptedMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EncryptedMessage>> GetAllMessages()
        {
            var messages = _messageRepository.GetAllMessages();
            return Ok(messages);
        }
    }
}
