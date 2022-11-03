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
    public class ContactService : IContactService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ContactService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ContactDto>> GetAll()
        {
            var contacts = await _context.Contact.ToListAsync();

            return _mapper.Map<List<ContactDto>>(contacts);
        }
    }
}
