using System.Collections.Generic;
using System.Threading.Tasks;
using FarfetchToggleService.Contracts;
using FarfetchToggleService.Repository.Views;
using MongoDB.Bson;

namespace FarfetchToggleService.Repository.Repositories
{
    public interface IMessageRepository
    {
        Task<SubscribeGetResponse> Subscribe(string email);

        Task<MessageGetResponse> SendMessage(string subject, string message);
    }
}