using PlatformService.DTOs;
using PlatformService.Models;
using AutoMapper;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile(){
            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<PlatformCreateDTO, Platform>();
        }
    }
}