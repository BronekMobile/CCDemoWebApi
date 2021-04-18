using AutoMapper;
using CCDemoAPI.Entities;
using CCDemoAPI.Exceptions;
using CCDemoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Services
{
    public interface IRoomService
    {
        RoomDto GetById(int locationId, int id); 
    }
    public class RoomService : IRoomService
    {
        private readonly CCDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomService> _logger;

        public RoomService(CCDbContext dbContext, IMapper mapper, ILogger<RoomService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;

        }
        public RoomDto GetById(int locationId, int roomId)
        {
            _logger.LogWarning($"Search room with location id {locationId} and room id {roomId}");
            var location = GetLocationById(locationId);
            var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == roomId);

            if (room is null || room.LocationId != locationId)
                throw new NotFoundException("Room not found");

            var roomDto = _mapper.Map<RoomDto>(room);
            return roomDto;
        }

        private Location GetLocationById(int id)
        {
            var location = _dbContext.Locations
                .Include(r => r.Address)
                .Include(r => r.Parking)
                .Include(r => r.Rooms)
                .FirstOrDefault(r => r.Id == id);

            if (location is null)
                throw new NotFoundException("Location not found");

            return location;
        }
    }


}
