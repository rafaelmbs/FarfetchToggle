using System.Collections.Generic;
using System.Threading.Tasks;
using FarfetchToggleService.Contracts;
using FarfetchToggleService.Repository.Views.Toggle;
using MongoDB.Bson;

namespace FarfetchToggleService.Repository.Repositories
{
    public interface IToggleRepository
    {
        IEnumerable<ToggleView> GetToggles();

        ToggleView GetToggle(ObjectId id);

        void CreateToggle(TogglePostRequest toggle);

        void UpdateToggle(ObjectId id, TogglePutRequest toggle);
    }
}