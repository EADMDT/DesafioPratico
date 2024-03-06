using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNet8VStudio.Logic;
using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private IHotelLogic _hotelLogic;

        public HotelController(ILogger<HotelController> logger, IHotelLogic hotelLogic)
        {
            _logger = logger;
            _hotelLogic = hotelLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_hotelLogic.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var hotel = _hotelLogic.FindByID(id);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] HotelVO hotel)
        {
            return Ok(_hotelLogic.Create(hotel));
        }

        [HttpPut("{id?}")]
        public IActionResult Put([FromBody] HotelVO hotel, long? id)
        {
            if (hotel == null || id!=null) return BadRequest();
            HotelVO result = _hotelLogic.Update(hotel);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            HotelVO result = _hotelLogic.Delete(id);
            if(result==null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
