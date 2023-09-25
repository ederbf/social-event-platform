using ErrorOr;
using MediatR;
using SocialEventPlatform.Application.Common.Interfaces.Persistence;
using SocialEventPlatform.Domain.ActivityAggregate;
using SocialEventPlatform.Domain.ActivityAggregate.Entities;
using SocialEventPlatform.Domain.HostAggregate.ValueObjects;

namespace SocialEventPlatform.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, ErrorOr<Activity>>
    {
        private readonly IActivityRepository _activityRepository;

        public CreateActivityCommandHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<ErrorOr<Activity>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1. Create Activity
            var activity = Activity.Create(
                request.Name,
                request.Description,
                HostId.Create(request.HostId),
                request.Sections.Select(section => ActivitySection.Create(
                    section.Name,
                    section.Description,
                    section.Items.Select(item => ActivityItem.Create(
                        item.Name,
                        item.Description)).ToList())).ToList());

            //2. Persist Activity
            _activityRepository.Add(activity);

            //3. Return Activity
            return activity;
        }
    }
}
