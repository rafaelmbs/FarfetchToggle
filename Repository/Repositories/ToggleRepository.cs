using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using FarfetchToggleService.Contracts;
using FarfetchToggleService.Repository.Views;
using FarfetchToggleService.Settings;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace FarfetchToggleService.Repository.Repositories
{
    public class ToggleRepository : IToggleRepository
    {
        private readonly IOptions<AppSettings> _config;
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public ToggleRepository(IOptions<AppSettings> config)
        {
            _config = config;
            _client = new MongoClient(_config.Value.ConnectionString);
            _server = _client.GetServer();
            _db = _server.GetDatabase(_config.Value.Database);
        }

        public IEnumerable<ToggleView> GetToggles()
        {
            return _db.GetCollection<ToggleView>("Toggle").FindAll();
        }

        public ToggleView GetToggle(int id)
        {
            var result = Query<ToggleView>.EQ(t => t.ToggleId, id);
            return _db.GetCollection<ToggleView>("Toggle").FindOne(result);
        }

        public void CreateToggle(TogglePostRequest toggle)
        {
            _db.GetCollection<ToggleView>("Toggle").Save(toggle);
        }

        public void UpdateToggle(int id, TogglePutRequest toggle)
        {
            toggle.ToggleId = id;

            var result = Query<ToggleView>.EQ(t => t.ToggleId, id);

            var operation = Update<TogglePutRequest>.Replace(toggle);

            _db.GetCollection<ToggleView>("Toggle").Update(result, operation);
        }
    }
}