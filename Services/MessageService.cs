using System.Threading.Tasks;
using FarfetchToggleService.Contracts;
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

        public Task<MessageGetResponse> SendMessage(string subject, string message)
        {            
            return _messageRepository.SendMessage(subject, message);
        }
    }
}