using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNet8VStudio.Logic;
using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomLogic _roomLogic;

        public RoomController(ILogger<RoomController> logger, IRoomLogic roomLogic)
        {
            _logger = logger;
            _roomLogic = roomLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_roomLogic.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var room = _roomLogic.FindByID(id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RoomVO room)
        {
            return Ok(_roomLogic.Create(room));
        }

        [HttpPut("{id?}")]
        public IActionResult Put([FromBody] RoomVO room, long? id)
        {
            if (room == null || id!=null) return BadRequest();
            RoomVO result = _roomLogic.Update(room);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            RoomVO result = _roomLogic.Delete(id);
            if(result==null)
            {
                return NotFound();
            } 
            return NoContent();
        }

    }
}
