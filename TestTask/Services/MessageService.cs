using AutoMapper;
using TestTask.Data;
using TestTask.DTOs;
using TestTask.Interfaces;
using TestTask.Models;

namespace TestTask.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IEncryptService _encryptService;
        private readonly IMapper _mapper;
        private readonly IEncryptedMessageRepository _encryptedMessageRepository;

        public MessageService(IMessageRepository messageRepository, IEncryptedMessageRepository encryptedMessageRepository,IEncryptService encryptService, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _encryptService = encryptService;
            _mapper = mapper;
            _encryptedMessageRepository = encryptedMessageRepository;
        }

        public EncryptedMessage EncryptMessage(MessageDTO message)
        {
            var messageModel = _mapper.Map<Message>(message);
            _messageRepository.AddMessage(messageModel);
            _messageRepository.SaveChanges();

            var encryptResult = _encryptService.EncryptMessage(message);
            _encryptedMessageRepository.AddMessage(encryptResult);
            _encryptedMessageRepository.SaveChanges();
            return encryptResult;
        }
    }
}
