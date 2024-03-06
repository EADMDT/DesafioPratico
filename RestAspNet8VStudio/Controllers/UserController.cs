using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNet8VStudio.Logic;
using RestAspNet8VStudio.VObject;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RestAspNet8VStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserLogic _userLogic;

        public UserController(ILogger<UserController> logger, IUserLogic userService)
        {
            _logger = logger;
            _userLogic = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userLogic.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userLogic.FindByID(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserVO user)
        {
            return Ok(_userLogic.Create(user));
        }

        [HttpPut("{id?}")]
        public IActionResult Put([FromBody] UserVO user, long? id)
        {
            if (user == null || id!=null) return BadRequest();
            UserVO result = _userLogic.Update(user);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            UserVO result = _userLogic.Delete(id);
            if(result==null)
            {
                return NotFound();
            } 
            return NoContent();
        }

    }
}
