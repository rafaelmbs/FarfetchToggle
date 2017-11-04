using System.Threading.Tasks;
using FarfetchToggle.Contracts.Message;

namespace FarfetchToggle.Repository.Repositories
{
    public interface IMessageRepository
    {
        Task<SubscriptionGetResponse> Subscribe(string email);

        Task<MessageGetResponse> SendMessage(string subject, string message);
    }
}
