using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly DataContext _context;

        public ChatMessageRepository(DataContext context)
        {
            _context = context;
        }

        // Add a new chat message
        public async Task<ChatMessage> AddChatMessage(ChatMessage chatMessage)
        {
            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();
            return chatMessage;
        }

        // Get chat messages by request ID
        public async Task<List<ChatMessage>> GetMessagesByRequestId(int requestId)
        {
            return await _context.ChatMessages
                .Where(m => m.RequestID == requestId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        // Get chat messages between two users
        public async Task<List<ChatMessage>> GetMessagesBetweenUsers(int senderId, int receiverId)
        {
            return await _context.ChatMessages
                .Where(m => m.SenderID == senderId && m.ReceiverID == receiverId || m.SenderID == receiverId && m.ReceiverID == senderId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }
    }
}
