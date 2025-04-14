using AutoMapper;
using ZooManager.Application.DTOs;
using ZooManager.Domain.Entities;

namespace ZooManager.Application.Mappings;

public class AnimalProfile : Profile
{
    public AnimalProfile()
    {
        CreateMap<DateTime, DateOnly>().ConvertUsing(src => DateOnly.FromDateTime(src));
        CreateMap<DateOnly, DateTime>().ConvertUsing(src => src.ToDateTime(TimeOnly.MinValue));

        CreateMap<CreateAnimalDto, Animal>()
            .ForMember(dest => dest.AnimalCares, opt => opt.MapFrom(src =>
                src.CareIds.Select(id => new AnimalCare { CareId = id })));

        CreateMap<UpdateAnimalDto, Animal>()
            .ForMember(dest => dest.AnimalCares,
                opt => opt.MapFrom(src => src.CareIds.Select(id => new AnimalCare { CareId = id })));

        CreateMap<Animal, AnimalDto>()
            .ForMember(dest => dest.Cares, opt => opt.MapFrom(src =>
                src.AnimalCares.Select(ac => ac.Care)));

        CreateMap<Care, CareDto>();
    }
}
