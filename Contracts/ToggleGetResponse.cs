using System.Collections.Generic;
using FarfetchToggleService.Repository.Views.Toggle;

namespace FarfetchToggleService.Contracts
{
    public class ToggleGetResponse
    {
        public IEnumerable<ToggleResultView> listToggle { get; set; }
    }
}