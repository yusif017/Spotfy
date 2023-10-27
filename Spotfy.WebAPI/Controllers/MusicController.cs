
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Spotfy.Business.Abstract;
using Spotfy.Entities.DTOs.MusicDTOs;
using System.IdentityModel.Tokens.Jwt;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
       private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;

 
        }


        [HttpPost("musicpost")]
        public IActionResult MusicPost([FromBody] MusicCreateDTO musicCreateDTO)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            int.TryParse(userId, out int convertingUserId);
            var result = _musicService.AddMusic(convertingUserId, musicCreateDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
