namespace FarfetchToggle.Contracts.Toggle
{
    public class ToggleGetByIdResponse
    {
        public string IdToggle { get; set; }

        public string Name { get; set; }

        public bool Value { get; set; }

        public bool OnlyAdmin { get; set; }
    }
}
