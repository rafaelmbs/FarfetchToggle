using System.Collections.Generic;
using System.Threading.Tasks;
using FarfetchToggleService.Repository.Views;

namespace FarfetchToggleService.Repository.Repositories
{
    public interface IToggleRepository
    {
        Task<IList<ToggleView>> GetInfo(string icao);
    }
}