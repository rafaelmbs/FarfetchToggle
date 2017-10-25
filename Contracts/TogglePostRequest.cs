using System.Collections.Generic;
using FarfetchToggleService.Repository.Views;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarfetchToggleService.Contracts
{
    public class TogglePostRequest
    {
         public ObjectId Id { get; set; }

        [BsonElement("ToggleId")]
        public int ToggleId { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Value")]
        public bool Value { get; set; }

        [BsonElement("OnlyAdmin")]
        public bool OnlyAdmin { get; set; }
    }
}