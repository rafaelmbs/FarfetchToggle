using System.Collections.Generic;
using System.Threading.Tasks;
using FarfetchToggleService.Repository.Views;
using MongoDB.Bson;

namespace FarfetchToggleService.Repository.Repositories
{
    public interface IToggleRepository
    {
        IEnumerable<ToggleView> GetToggles();

        ToggleView GetToggle(ObjectId id);

        ToggleView CreateToggle(ToggleView toggle);

        void UpdateToggle(ObjectId id, ToggleView toggle);
    }
}