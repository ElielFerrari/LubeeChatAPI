using BusinessLogic.Services.Dto;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactDto>> GetAll();
    }
}
