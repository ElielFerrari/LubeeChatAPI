using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Dto
{
    public class ConversationDto
    {
        public int ConversationId { get; set; }
        public List<ContactDto> Contacts { get; set; }
        public DateTime LastMessageTime { get; set; }
        public List<MessageDto> Messages { get; set; }

    }
}
