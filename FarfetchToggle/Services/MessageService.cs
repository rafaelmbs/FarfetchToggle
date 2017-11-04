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

        public async Task<SubscriptionGetResponse> Subscribe(SubscriptionGetRequest request)
        {
            var result = await _messageRepository.Subscribe(request);

            return result;
        }

        public async Task<MessageGetResponse> SendMessage(MessageGetRequest request)
        {
            var result = await _messageRepository.SendMessage(request);

            return result;
        }
    }
}
