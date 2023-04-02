using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.DTOs;
using TestTask.Interfaces;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMessageRepository messageRepository, IMapper mapper)
        {
            _messageService = messageService;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<Message> AddMessage(MessageDTO message) 
        {
            EncryptedMessage encryptedMessage = _messageService.EncryptMessage(message);

            return CreatedAtRoute(nameof(GetMessageById), new { id = encryptedMessage.Id }, _mapper.Map<EncryptedMessageDTO>(encryptedMessage));
        }

        [HttpGet("id", Name="GetMessageById")]
        public ActionResult<Message> GetMessageById(int id) 
        {
            var comandItem = _messageRepository.GetMessageById(id);
            if(comandItem != null) 
            {
                return Ok(comandItem);
            }
            return NotFound();
        }

    }
}
