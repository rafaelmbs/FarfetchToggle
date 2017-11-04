using System.Threading.Tasks;
using FarfetchToggle.Contracts.Message;

namespace FarfetchToggle.Repository.Repositories
{
    public interface IMessageRepository
    {
        Task<SubscriptionGetResponse> Subscribe(SubscriptionGetRequest request);

        Task<MessageGetResponse> SendMessage(MessageGetRequest request);
    }
}
