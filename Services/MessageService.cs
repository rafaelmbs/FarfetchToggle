using System.Threading.Tasks;
using FarfetchToggleService.Contracts;
using FarfetchToggleService.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FarfetchToggleService.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<SubscribeGetResponse> Subscribe(string email)
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