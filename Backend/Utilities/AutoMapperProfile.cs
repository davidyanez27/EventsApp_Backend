using AutoMapper;
using Backend.DTO;
using Backend.Models;
using System.Globalization;

namespace Backend.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            #region Event
            CreateMap<Event, EventDTO>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToString("dd-MM-yyyy")))
                .ForMember(dest => dest.startTime, opt => opt.MapFrom(src => src.StartDate.ToString("hh-mm")))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToString("hh-mm")))
                .ForMember(dest => dest.endTime, opt => opt.MapFrom(src => src.EndDate.ToString("hh-mm"))).ReverseMap();
                ;
            #endregion

            #region Event
            CreateMap<User, UserDTO>().ReverseMap();
            #endregion

        }

    }
}
