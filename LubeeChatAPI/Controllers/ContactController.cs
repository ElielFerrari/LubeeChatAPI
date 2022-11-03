using BusinessLogic.Services.Dto;
using BusinessLogic.Services.Interfaces;
using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LubeeChatAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService  _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet] //Get All Contacts
        public async Task<ActionResult<List<ContactDto>>> GetAll() 
        {
            try
            {
                return Ok(await _contactService.GetAll());
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
    }
}
