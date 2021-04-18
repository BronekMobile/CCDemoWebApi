using AutoMapper;
using CCDemoAPI.Entities;
using CCDemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI
{
    public class LocationMappingProfile: Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Location, LocationDto>()
               .ForMember(r => r.City, c => c.MapFrom(s => s.Address.City))
               .ForMember(r => r.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
               .ForMember(r => r.Street, c => c.MapFrom(s => s.Address.Street))
               .ForMember(r => r.Parking, c => c.MapFrom(s => s.Parking.Name));

            CreateMap<Room, RoomDto>();
        }
    }
}
