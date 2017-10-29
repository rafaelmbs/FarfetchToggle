using AutoMapper;
using FarfetchToggleService.Contracts;
using FarfetchToggleService.Repository.Views.Toggle;
using System.Collections.Generic;

namespace FarfetchToggleService.Repository.Mapping
{
    public class ToggleGetMap : Profile
    {
        public ToggleGetMap()
        {
            CreateMap<List<ToggleView>, ToggleGetResponse>()
                .ForMember(dest => dest.listToggle, opt => opt.MapFrom(src => src));;
        }
    }
}