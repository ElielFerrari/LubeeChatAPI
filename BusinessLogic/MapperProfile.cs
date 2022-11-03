using AutoMapper;
using BusinessLogic.Services.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ConversationDto, Conversation>().ReverseMap();
            CreateMap<MessageDto, Message>().ReverseMap();
            CreateMap<NewMessageDto, Message>().ReverseMap();
            CreateMap<ContactDto, Contact>().ReverseMap();
        }
    }
}
