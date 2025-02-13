using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl,
                o => o.MapFrom(src => 
                    src.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(dist => dist.Age, 
                opt => opt.MapFrom(src => 
                    src.DateOfBirth.CalculateAge()));
        CreateMap<Photo, PhotoDto>();
    }
}