using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Dto
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public DateTime Date { get; set; }
    }
}
