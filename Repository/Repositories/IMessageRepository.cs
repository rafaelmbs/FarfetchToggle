using System.Collections.Generic;
using System.Threading.Tasks;
using FarfetchToggleService.Contracts.Message;
using FarfetchToggleService.Repository.Views;
using MongoDB.Bson;

namespace FarfetchToggleService.Repository.Repositories
{
    public interface IMessageRepository
    {
        Task<SubscriptionGetResponse> Subscribe(string email);

        Task<MessageGetResponse> SendMessage(string subject, string message);
    }
}