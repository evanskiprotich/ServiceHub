using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageRepository _chatMessageRepository;

        public ChatMessageController(IChatMessageRepository chatMessageRepository)
        {
            _chatMessageRepository = chatMessageRepository;
        }

        // POST: api/chatmessage
        [HttpPost]
        public async Task<IActionResult> AddChatMessage([FromBody] ChatMessage chatMessage)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdMessage = await _chatMessageRepository.AddChatMessage(chatMessage);
            return CreatedAtAction(nameof(GetMessagesByRequestId), new { requestId = createdMessage.RequestID }, createdMessage);
        }

        // GET: api/chatmessage/request/{requestId}
        [HttpGet("request/{requestId}")]
        public async Task<IActionResult> GetMessagesByRequestId(int requestId)
        {
            var messages = await _chatMessageRepository.GetMessagesByRequestId(requestId);
            if (messages == null || messages.Count == 0) return NotFound("No messages found for the specified request.");

            return Ok(messages);
        }

        // GET: api/chatmessage/users/{senderId}/{receiverId}
        [HttpGet("users/{senderId}/{receiverId}")]
        public async Task<IActionResult> GetMessagesBetweenUsers(int senderId, int receiverId)
        {
            var messages = await _chatMessageRepository.GetMessagesBetweenUsers(senderId, receiverId);
            if (messages == null || messages.Count == 0) return NotFound("No messages found between the specified users.");

            return Ok(messages);
        }
    }
}
