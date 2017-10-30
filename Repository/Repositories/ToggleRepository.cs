using FarfetchToggleService.Contracts.Toggle;
using FarfetchToggleService.Repository.Views.Toggle;
using FarfetchToggleService.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
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
        private readonly string _collection = "Toggle";
        MongoUrl _mongoUrl;
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public ToggleRepository(IOptions<AppSettings> config)
        {
            _config = config;
            _mongoUrl = new MongoUrl(_config.Value.ConnectionString);
            _client =  new MongoClient(_mongoUrl);
            _server = new MongoServer(MongoServerSettings.FromClientSettings(_client.Settings));
            _db = _server.GetDatabase(_config.Value.Database);
        }

        public List<ToggleResultView> GetToggles()
        {
            var data = _db.GetCollection<ToggleView>(_collection).FindAll();

            var result = new List<ToggleResultView>();

            foreach(var r in data)
            {
                var item = new ToggleResultView();
                item.IdToggle = r.Id.ToString();
                item.Name = r.Name;
                item.Value = r.Value;
                item.OnlyAdmin = r.OnlyAdmin;

                result.Add(item);
            }

            return result;
        }

        public ToggleView GetToggle(ObjectId id)
        {
            var result = Query<ToggleView>.EQ(t => t.Id, id);
            return _db.GetCollection<ToggleView>(_collection).FindOne(result);       
        }

        public void CreateToggle(TogglePostRequest toggle)
        {
            _db.GetCollection<ToggleView>(_collection).Save(toggle);
        }

        public void UpdateToggle(ObjectId id, TogglePutRequest toggle)
        {
            toggle.Id = id;

            var result = Query<ToggleView>.EQ(t => t.Id, id);
            var operation = Update<TogglePutRequest>.Replace(toggle);

            _db.GetCollection<ToggleView>(_collection).Update(result, operation);
        }
    }
}