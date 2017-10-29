using AutoMapper;
using FarfetchToggleService.Contracts;
using FarfetchToggleService.Repository.Repositories;
using FarfetchToggleService.Repository.Views.Toggle;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarfetchToggleService.Services
{
    public class ToggleService
    {
        private readonly IMapper _mapper;
        private readonly IToggleRepository _toggleRepository;

        private readonly MessageService _messageService;
        public ToggleService(IMapper mapper, IToggleRepository toggleRepository, MessageService messageService)
        {
            _mapper = mapper;
            _toggleRepository = toggleRepository;
            _messageService = messageService;
        }

        public ToggleGetResponse GetToggles()
        {
            var result = _toggleRepository.GetToggles();

            var response = _mapper.Map<ToggleGetResponse>(result);

            return response;
        }

        public ToggleGetByIdResponse GetToggle(string id)
        {
            var result = _toggleRepository.GetToggle(new ObjectId(id));

            var response = _mapper.Map<ToggleGetByIdResponse>(result);

            return response;
        }

        public async void CreateToggle(TogglePostRequest toggle)
        {
            _toggleRepository.CreateToggle(toggle);

            string subject = string.Format("Service Created - '{0}'", toggle.Name);
            string message = string.Format("The following service '{0}' was created with '{1}' value", toggle.Name, toggle.Value);

            await _messageService.SendMessage(subject, message);
        }

        public async void UpdateToggle(string id, TogglePutRequest toggle)
        {
            _toggleRepository.UpdateToggle(new ObjectId(id), toggle);

            string subject = string.Format("Service Updated - '{0}'", toggle.Name);
            string message = string.Format("The following service '{0}' was updated to '{1}' value", toggle.Name, toggle.Value);

            await _messageService.SendMessage(subject, message);
        }
    }
}