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
            CreateMap<List<ToggleResultView>, ToggleGetResponse>()
                .ForMember(dest => dest.items, opt => opt.MapFrom(src => src));
        }
    }
}