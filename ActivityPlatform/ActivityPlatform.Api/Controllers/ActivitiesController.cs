using Microsoft.AspNetCore.Mvc;

namespace ActivityPlatform.Api.Controllers
{
    [Route("[controller]")]
    public class ActivitiesController : ApiController
    {
        [HttpGet]
        public IActionResult ListActivities()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
