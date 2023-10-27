using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Spofy.Business.Abstract;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlibomMusicController : ControllerBase
    {
        private readonly IAlibomMusicService _service;

        public AlibomMusicController(IAlibomMusicService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public IActionResult Add([FromQuery] int alibomId, [FromQuery] AlibomMusicListAddDto AddDto)
        {
            
            var result = _service.AddAlibomList( alibomId , AddDto);
            return Ok(result);
        }

        [HttpGet("useralibomlist")]
        public IActionResult GetUserAlibomList()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            var user = Convert.ToInt32(userId);
            var result = _service.GetUserAlibomList(user);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetAllalibomlist")]
        public IActionResult GetAllAlibomList()
        {
            
            var result = _service.GetAllAlibomList();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
