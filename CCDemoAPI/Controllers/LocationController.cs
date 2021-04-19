using CCDemoAPI.Models;
using CCDemoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Controllers
{
    [Route("api/location")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult<List<LocationDto>> GetAll()
        {
            var locations = _locationService.GetAll();
            return Ok(locations);
        }

        /// <summary>
        /// Get location by identity.
        /// </summary>
        /// <param name="id">Location id</param>
        /// <returns>Location specified by identity.</returns>
        [HttpGet("{id}")]
        public ActionResult<LocationDto> Get([FromRoute]int id)
        {
            var location = _locationService.GetById(id);
            return Ok(location);
        }
    }
}
