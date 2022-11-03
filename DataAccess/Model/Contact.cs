using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public DateTime Date { get; set; }

        public List<Conversation> Conversations { get; set; }
    }
}
