using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialEventPlatform.Application.Activities.Commands.CreateActivity;
using SocialEventPlatform.Contracts.Activities;

namespace SocialEventPlatform.Api.Controllers
{
    [Route("hosts/{hostId}/activities")]
    public class ActivitiesController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ActivitiesController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(
            CreateActivityRequest request, 
            string hostId)
        {
            var command = _mapper.Map<CreateActivityCommand>((request, hostId));

            var createActivityResult = await _mediator.Send(command);

            return createActivityResult.Match(
                activity => Ok(_mapper.Map<ActivityResponse>(activity)),
                errors => Problem(errors));
        }
    }
}
