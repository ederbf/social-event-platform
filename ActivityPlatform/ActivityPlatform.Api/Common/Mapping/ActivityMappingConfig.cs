using Mapster;
using SocialEventPlatform.Application.Activities.Commands.CreateActivity;
using SocialEventPlatform.Contracts.Activities;
using SocialEventPlatform.Domain.ActivityAggregate;
using ActivitySection = SocialEventPlatform.Domain.ActivityAggregate.Entities.ActivitySection;
using ActivityItem = SocialEventPlatform.Domain.ActivityAggregate.Entities.ActivityItem;
using SocialEventPlatform.Domain.ActivityReviewAggregate.ValueObjects;


namespace SocialEventPlatform.Api.Common.Mapping
{
    public class ActivityMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) 
        {
            config.NewConfig<(CreateActivityRequest Request, string HostId), CreateActivityCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Activity, ActivityResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AverageRating, src => src.AverageRating != null && src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : (float?)null)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.SocialEventIds, src => src.SocialEventIds.Select(socialEventId => socialEventId.Value))
                .Map(dest => dest.ActivityReviewIds, src => src.ActivityReviewIds.Select(ActivityReviewId => ActivityReviewId.Value));

            config.NewConfig<ActivitySection, ActivitySectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<ActivityItem, ActivityItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
