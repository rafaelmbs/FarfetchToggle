using System.Collections.Generic;
using FarfetchToggle.Repository.Views.Toggle;

namespace FarfetchToggle.Contracts.Toggle
{
    public class ToggleGetResponse
    {
        public List<ToggleResultView> items { get; set; }
    }
}
