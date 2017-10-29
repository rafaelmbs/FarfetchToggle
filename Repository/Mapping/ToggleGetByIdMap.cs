using AutoMapper;
using FarfetchToggleService.Contracts;
using FarfetchToggleService.Repository.Views.Toggle;
using System.Collections.Generic;

namespace FarfetchToggleService.Repository.Mapping
{
    public class ToggleGetByIdMap : Profile
    {
        public ToggleGetByIdMap()
        {
            CreateMap<ToggleView, ToggleGetByIdResponse>()
                .ForMember(dest => dest.IdToggle, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.OnlyAdmin, opt => opt.MapFrom(src => src.OnlyAdmin));
        }
    }
}