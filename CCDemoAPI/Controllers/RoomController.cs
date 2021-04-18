using CCDemoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Controllers
{
    [ApiController]
    [Route("/api/location/{locationId}/room")]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }


        [HttpGet("{roomId}")]
        //[AllowAnonymous]
        public ActionResult GetById([FromRoute]int locationId, [FromRoute] int roomId)
        {
            var room = _service.GetById(locationId, roomId);
            return Ok(room);
        }
    }
}
