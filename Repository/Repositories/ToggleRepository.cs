using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using FarfetchToggleService.Contracts;
using FarfetchToggleService.Repository.Views;
using FarfetchToggleService.Settings;
using Newtonsoft.Json;

namespace FarfetchToggleService.Repository.Repositories
{
    public class ToggleRepository : IToggleRepository
    {
        private readonly IOptions<AppSettings> _config;

        public ToggleRepository(IOptions<AppSettings> config)
        {
            _config = config;
        }

        public async Task<IList<ToggleView>> GetInfo(string icao)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.Value.ConnectionString);
                var response = await client.GetAsync($"/aero/{icao}");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawChart = JsonConvert.DeserializeObject<ToggleGetResponse>(stringResult);
                return rawChart.list;
            }
        }
    }
}