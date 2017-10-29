using System.Collections.Generic;
using FarfetchToggleService.Repository.Views.Toggle;

namespace FarfetchToggleService.Contracts
{
    public class ToggleGetResponse
    {
        public IList<ToggleResultView> items { get; set;}
    }
}