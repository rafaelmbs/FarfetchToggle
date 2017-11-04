using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarfetchToggle.Contracts.Toggle
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
