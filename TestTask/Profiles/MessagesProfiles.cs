using AutoMapper;
using TestTask.DTOs;
using TestTask.Models;

namespace TestTask.Profiles
{
    public class MessagesProfiles : Profile
    {
        public MessagesProfiles()
        {
            CreateMap<MessageDTO, Message>();
            CreateMap<MessageDTO, EncryptedMessage>();
            CreateMap<EncryptedMessage, EncryptedMessageDTO>();
        }
    }
}
