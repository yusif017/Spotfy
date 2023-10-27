using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploudsControllor : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UploudsControllor(IWebHostEnvironment env)
        {
            _env = env;
        }
        [HttpPost("Uploud")]
        public IActionResult Uploud(IFormFile file)
        {
            var path = "/uploads/" + Guid.NewGuid() + file.FileName;
            using FileStream fileStream = new(_env.WebRootPath + path, FileMode.Create);
            file.CopyToAsync(fileStream);

            return Ok(path);
        }
    }
}
