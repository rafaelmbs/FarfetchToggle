using FarfetchToggleService.Contracts.Toggle;
using FarfetchToggleService.Repository.Views.Toggle;
using FarfetchToggleService.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FarfetchToggleService.Repository.Repositories
{
    public class ToggleRepository : IToggleRepository
    {
        private readonly IOptions<AppSettings> _config;
        MongoUrl _mongoUrl;
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        MongoCollection<ToggleView> _collection;

        public ToggleRepository(IOptions<AppSettings> config)
        {
            _config = config;
            _mongoUrl = new MongoUrl(_config.Value.ConnectionString);
            _client =  new MongoClient(_mongoUrl);
            _server = new MongoServer(MongoServerSettings.FromClientSettings(_client.Settings));
            _db = _server.GetDatabase(_config.Value.Database);
            _collection = _db.GetCollection<ToggleView>(_config.Value.Collection);
        }

        public List<ToggleView> GetToggles()
        {
            var result = new List<ToggleView>();
            var data = _collection.FindAll();

            foreach(var r in data)
            {
                var item = new ToggleView();
                item.Id = r.Id;
                item.Name = r.Name;
                item.Value = r.Value;
                item.OnlyAdmin = r.OnlyAdmin;

                result.Add(item);
            }

            return result;
        }

        public ToggleView GetToggle(ObjectId id)
        {
            var query = Query<ToggleView>.EQ(t => t.Id, id);
            var result = _collection.FindOne(query);
            return result;       
        }

        public void CreateToggle(TogglePostRequest toggle)
        {
            _collection.Save(toggle);
        }

        public void UpdateToggle(ObjectId id, TogglePutRequest toggle)
        {
            toggle.Id = id;

            var result = Query<ToggleView>.EQ(t => t.Id, id);
            var operation = Update<TogglePutRequest>.Replace(toggle);

            _collection.Update(result, operation);
        }
    }
}