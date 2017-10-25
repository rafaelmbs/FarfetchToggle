using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarfetchToggleService.Repository.Repositories;
using FarfetchToggleService.Repository.Views;
using Newtonsoft.Json;
using MongoDB.Bson;
using FarfetchToggleService.Contracts;

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

        public ToggleView GetToggle(int id)
        {
            var result = _toggleRepository.GetToggle(id);

            return result;
        }

        public void CreateToggle(TogglePostRequest toggle)
        {
            _toggleRepository.CreateToggle(toggle);
        }

        public void UpdateToggle(int id, TogglePutRequest toggle)
        {
            _toggleRepository.UpdateToggle(id, toggle);
        }
    }
}