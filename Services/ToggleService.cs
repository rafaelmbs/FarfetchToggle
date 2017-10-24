using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarfetchToggleService.Repository.Repositories;
using FarfetchToggleService.Repository.Views;
using Newtonsoft.Json;
using MongoDB.Bson;

namespace FarfetchToggleService.Services
{
    public class ToggleService
    {
        private readonly IToggleRepository _toggleRepository;
        public ToggleService(IToggleRepository toggleRepository)
        {
            _toggleRepository = toggleRepository;
        }

        public IEnumerable<ToggleView> GetToggles()
        {
            var result = _toggleRepository.GetToggles();

            return result;
        }

        public ToggleView GetToggle(ObjectId id)
        {
            var result = _toggleRepository.GetToggle(id);

            return result;
        }

        public ToggleView CreateToggle(ToggleView toggle)
        {
            var result = _toggleRepository.CreateToggle(toggle);

            return result;
        }

        public void UpdateToggle(ObjectId id, ToggleView toggle)
        {
            _toggleRepository.UpdateToggle(id, toggle);
        }
    }
}