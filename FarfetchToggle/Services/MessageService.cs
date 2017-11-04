using System.Threading.Tasks;
using FarfetchToggle.Contracts.Message;
using FarfetchToggle.Repository.Repositories;

namespace FarfetchToggle.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<SubscriptionGetResponse> Subscribe(string email)
        {
            var result = await _messageRepository.Subscribe(email);

            return result;
        }

        public async Task<MessageGetResponse> SendMessage(string subject, string message)
        {
            var result = await _messageRepository.SendMessage(subject, message);

            return result;
        }
    }
}
