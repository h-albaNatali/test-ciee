using AutoMapper;
using ZooManager.Domain.Entities;
using ZooManager.Application.DTOs;

namespace ZooManager.Application.Mappings;

public class CareProfile : Profile
{
    public CareProfile()
    {
        CreateMap<CreateCareDto, Care>();
        CreateMap<Care, CareDto>();
    }
}
