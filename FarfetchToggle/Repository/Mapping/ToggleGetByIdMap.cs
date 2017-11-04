using AutoMapper;
using FarfetchToggle.Contracts.Toggle;
using FarfetchToggle.Repository.Views.Toggle;

namespace FarfetchToggle.Repository.Mapping
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
