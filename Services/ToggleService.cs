using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarfetchToggleService.Repository.Repositories;
using FarfetchToggleService.Repository.Views;
using Newtonsoft.Json;

namespace FarfetchToggleService.Services
{
    public class ToggleService
    {
        private readonly IToggleRepository _aeroRepository;
        public ToggleService(IToggleRepository aeroRepository)
        {
            _aeroRepository = aeroRepository;
        }

        public async Task<IList<ToggleView>> GetInfo(string icao)
        {
            var result = await _aeroRepository.GetInfo(icao);

            return result;
        }
    }
}