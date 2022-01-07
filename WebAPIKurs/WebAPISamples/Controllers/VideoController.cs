using Microsoft.AspNetCore.Mvc;
using WebAPISamples.Services;

namespace WebAPISamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private IVideoService _videoStream;

        public VideoController(IVideoService videoService)
        {
            _videoStream = videoService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> Index(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();


            var stream = await _videoStream.GetVideoByName(name);

            return new FileStreamResult(stream, "video/mp4");
        }
    }
}
