using FarfetchToggleService.Repository.Views.Toggle;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarfetchToggleService.Contracts.Toggle
{
    public class ToggleGetByIdResponse
    {
        public string IdToggle { get; set; }
        
        public string Name { get; set; }
        
        public bool Value { get; set; }
        
        public bool OnlyAdmin { get; set; }
    }
}