using FarfetchToggleService.Repository.Views;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace FarfetchToggleService.Contracts.Toggle
{
    public class TogglePutRequest
    {
        public ObjectId Id { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Value")]
        public bool Value { get; set; }

        [BsonElement("OnlyAdmin")]
        public bool OnlyAdmin { get; set; }
    }
}