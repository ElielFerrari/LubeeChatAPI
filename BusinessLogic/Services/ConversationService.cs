using AutoMapper;
using BusinessLogic.Services.Dto;
using BusinessLogic.Services.Interfaces;
using DataAccess;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ConversationService : IConversationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ConversationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Conversation> GetConversation(int id1, int id2)
        {
            return await _context.Conversation.Include(m => m.Messages).Include(c => c.Contacts)
            .FirstOrDefaultAsync(c => c.Contacts.Any(c => c.ContactId == id1)
            && c.Contacts.Any(c => c.ContactId == id2));
        }

        public async Task<List<MessageDto>> GetConversationMessages(int id1, int id2)
        {
            if (id1 == id2)
                throw new ArgumentException("Los contactos tienen que ser distintos.");

            var conversation = await GetConversation(id1, id2);

            if (conversation == null)
                throw new KeyNotFoundException("No existe la conversación.");

            var messages = conversation.Messages.Select(m => new MessageDto()
            {
                Sender = m.Sender,
                Time = m.Time.ToString("HH:mm"),
                Text = m.Text
            });

            return _mapper.Map<List<MessageDto>>(messages);
        }

        public async Task<ConversationDto> CreateMessage(int recipientId, NewMessageDto message)
        {
            if (recipientId == message.Sender)
                throw new ArgumentException("Los contactos tienen que ser distintos.");

            var newMessage = _mapper.Map<Message>(message);
            newMessage.Time = DateTime.Now;

            var contact1 = await _context.Contact.FindAsync(message.Sender);
            var contact2 = await _context.Contact.FindAsync(recipientId);

            var conversation = await GetConversation(message.Sender, recipientId);

            if (contact1 != null && contact2 != null)
            {

                if (conversation == null)
                {
                    var newConversation = new Conversation()
                    {
                        Contacts = new List<Contact>() { contact1, contact2 },
                        Messages = new List<Message>() { newMessage },
                        LastMessageTime = DateTime.Now,
                    };

                    _context.Conversation.Add(newConversation);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<ConversationDto>(newConversation);
                }

                conversation.LastMessageTime = DateTime.Now;
                conversation.Messages.Add(newMessage);
                await _context.SaveChangesAsync();
                return _mapper.Map<ConversationDto>(conversation);
            }

            throw new KeyNotFoundException("No existe el o los contactos con ese id.");
        }
    }
}
