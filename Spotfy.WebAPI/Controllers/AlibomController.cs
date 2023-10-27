using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Spofy.Business.Abstract;
using Spotfy.Business.Abstract;
using Spotfy.Entities.DTOs.AlibomDTOs;
using Spotfy.Entities.DTOs.MusicDTOs;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlibomController : ControllerBase 
    { 
        private readonly IAlibomService _service;

        public AlibomController(IAlibomService service)
        {
            _service = service;
        }

        [HttpPost("Alibompost")]
        public IActionResult AlibomPost([FromBody] AlibomCreateDTO alibomCreateDTO)
    {
        var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
        var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
        int.TryParse(userId, out int convertingUserId);
        var result = _service.AddAlibom(convertingUserId, alibomCreateDTO);
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }
        [HttpGet("GetAllUseralibomlist")]
        public IActionResult GetAllUserAlibomList()
        {

            var result = _service.GetUserAllAlibomList();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("GetAlibomlist/{id}")]
        public IActionResult GetAlibomList(int id)
        {

            var result = _service.GetAlibom(id);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

    }
}
