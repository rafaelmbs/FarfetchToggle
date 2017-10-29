using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarfetchToggleService.Repository.Views.Toggle
{
    public class ToggleResultView
    {
        public string IdToggle { get; set; }
        public string Name { get; set; }
        public bool Value { get; set; }
        public bool OnlyAdmin { get; set; }
    }
}