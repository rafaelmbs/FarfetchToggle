using System;
using System.Net.Http;
using System.Threading.Tasks;
using FarfetchToggle.Contracts.Message;
using FarfetchToggle.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FarfetchToggle.Repository.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptions<AppSettings> _config;

        public MessageRepository(IOptions<AppSettings> config)
        {
            _config = config;
        }

        public async Task<SubscriptionGetResponse> Subscribe(string email)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.Value.URI_SNS);
                var response = await client.GetAsync($"subscription/{email}");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SubscriptionGetResponse>(stringResult);
                return result;
            }
        }

        public async Task<MessageGetResponse> SendMessage(string subject, string message)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.Value.URI_SNS);
                var response = await client.GetAsync($"notification/{subject}/{message}");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MessageGetResponse>(stringResult);
                return result;
            }
        }
    }
}
