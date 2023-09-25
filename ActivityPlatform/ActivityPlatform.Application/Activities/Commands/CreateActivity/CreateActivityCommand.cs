using ErrorOr;
using MediatR;
using SocialEventPlatform.Domain.ActivityAggregate;

namespace SocialEventPlatform.Application.Activities.Commands.CreateActivity
{
    public record CreateActivityCommand(
        string HostId,
        string Name,
        string Description,
        List<ActivitySectionCommand> Sections) : IRequest<ErrorOr<Activity>>;

    public record ActivitySectionCommand(
        string Name,
        string Description,
        List<ActivityItemCommand> Items);

    public record ActivityItemCommand(
        string Name,
        string Description);
}
