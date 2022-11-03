using BusinessLogic.Services.Dto;
using BusinessLogic.Services.Interfaces;
using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LubeeChatAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService  _conversationService;
        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        [HttpGet] //Get Conversation
        public async Task<ActionResult<List<MessageDto>>> GetConversation(int senderId, int recipientId)
        {
            try
            {
                return Ok(await _conversationService.GetConversationMessages(senderId, recipientId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] //Post Message
        public async Task<ActionResult<ConversationDto>> CreateMessage(int recipientId, NewMessageDto message)
        {
            try
            {
                return Ok(await _conversationService.CreateMessage(recipientId, message));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
