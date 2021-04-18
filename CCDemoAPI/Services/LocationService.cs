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
    public interface ILocationService
    {
        LocationDto GetById(int id);
    }

    public class LocationService : ILocationService
    {
        private readonly CCDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<LocationService> _logger;

        public LocationService(CCDbContext dbContext, IMapper mapper, ILogger<LocationService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get Location by id of location
        /// </summary>
        /// <param name="id">Identity of the location</param>
        /// <returns>Returns location specified by identity.</returns>
        public LocationDto GetById(int id)
        {
            var location = _dbContext.Locations
                .Include(r => r.Address)
                .Include(r => r.Parking)
                .Include(r => r.Rooms)
                .FirstOrDefault(r => r.Id == id);

            if (location is null)
                throw new NotFoundException("Location not found");

            var locationDto = _mapper.Map<LocationDto>(location);
            return locationDto;

        }
    }
}
