using System.Collections.Generic;
using FarfetchToggleService.Repository.Views;

namespace FarfetchToggleService.Contracts
{
    public class ToggleGetResponse
    {
        public List<ToggleView> list { get; set; }
    }
}