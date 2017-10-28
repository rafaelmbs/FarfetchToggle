using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarfetchToggleService.Repository.Repositories;
using FarfetchToggleService.Repository.Views.Toggle;
using Newtonsoft.Json;
using MongoDB.Bson;
using FarfetchToggleService.Contracts;

namespace FarfetchToggleService.Services
{
    public class ToggleService
    {
        private readonly IToggleRepository _toggleRepository;

        private readonly MessageService _messageService;
        public ToggleService(IToggleRepository toggleRepository, MessageService messageService)
        {
            _toggleRepository = toggleRepository;
            _messageService = messageService;
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

            string subject = string.Format("Service Created - '{0}'", toggle.Name);
            string message = string.Format("The following service '{0}' - '{1}' was created with '{2}' value", toggle.ToggleId, toggle.Name, toggle.Value);

            _messageService.SendMessage(subject, message);
        }

        public void UpdateToggle(int id, TogglePutRequest toggle)
        {
            _toggleRepository.UpdateToggle(id, toggle);

            string subject = string.Format("Service Updated - '{0}'", toggle.Name);
            string message = string.Format("The following service '{0}' - '{1}' was updated to '{2}' value", toggle.ToggleId, toggle.Name, toggle.Value);

            _messageService.SendMessage(subject, message);
        }
    }
}