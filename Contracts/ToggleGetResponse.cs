using System.Collections.Generic;
using FarfetchToggleService.Repository.Views.Toggle;

namespace FarfetchToggleService.Contracts
{
    public class ToggleGetResponse
    {
        public List<ToggleView> list { get; set; }
    }
}