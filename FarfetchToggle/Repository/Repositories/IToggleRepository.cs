using System.Collections.Generic;
using FarfetchToggle.Contracts.Toggle;
using FarfetchToggle.Repository.Views.Toggle;
using MongoDB.Bson;

namespace FarfetchToggle.Repository.Repositories
{
    public interface IToggleRepository
    {
        List<ToggleView> GetToggles();

        ToggleView GetToggle(ObjectId id);

        void CreateToggle(TogglePostRequest toggle);

        void UpdateToggle(ObjectId id, TogglePutRequest toggle);
    }
}
