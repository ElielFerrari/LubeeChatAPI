using BusinessLogic.Services.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IConversationService
    {
        Task<Conversation> GetConversation(int id1, int id2);
        Task<ConversationDto> CreateMessage(int recipientId, NewMessageDto message);
        Task<List<MessageDto>> GetConversationMessages(int id1, int id2);
    }
}
