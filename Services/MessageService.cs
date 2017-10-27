using FarfetchToggleService.Repository.Repositories;

namespace FarfetchToggleService.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
    }
}