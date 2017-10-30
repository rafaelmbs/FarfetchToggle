using System.Collections.Generic;
using FarfetchToggleService.Repository.Views.Toggle;

namespace FarfetchToggleService.Contracts.Toggle
{
    public class ToggleGetResponse
    {
        public List<ToggleResultView> items { get; set; }
    }
}