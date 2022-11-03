using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public List<Contact> Contacts { get; set; }
        public DateTime LastMessageTime { get; set; }
        public List<Message> Messages { get; set; } 
    }
}
