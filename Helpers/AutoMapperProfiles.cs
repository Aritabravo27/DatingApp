using System.Linq;
using entities;
using Extensions;
using AutoMapper;
using DTOs;

namespace Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDato>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                    src.Photos.FirstOrDefault(x => x.IsMain).Url));
                
            CreateMap<Photo, PhotoDto>();
        }
    }
} 