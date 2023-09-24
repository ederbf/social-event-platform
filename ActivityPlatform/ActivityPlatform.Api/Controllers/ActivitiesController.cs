using Microsoft.AspNetCore.Mvc;

namespace SocialEventPlatform.Api.Controllers
{
    [Route("[controller]")]
    public class SocialEventsController : ApiController
    {
        [HttpGet]
        public IActionResult ListSocialEvents()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
