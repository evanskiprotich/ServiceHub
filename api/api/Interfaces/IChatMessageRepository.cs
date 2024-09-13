using api.Models;

namespace api.Interfaces
{
    public interface IChatMessageRepository
    {
        Task<ChatMessage> AddChatMessage(ChatMessage chatMessage);
        Task<List<ChatMessage>> GetMessagesByRequestId(int requestId);
        Task<List<ChatMessage>> GetMessagesBetweenUsers(int senderId, int receiverId);
    }
}
