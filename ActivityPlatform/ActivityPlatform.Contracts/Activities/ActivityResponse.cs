namespace SocialEventPlatform.Contracts.Activities
{
    public record ActivityResponse(
        Guid Id,
        string Name,
        string Description,
        float? AverageRating,
        List<ActivitySectionResponse> Sections,
        string HostId,
        List<string> SocialEventIds,
        List<string> ActivityReviewIds,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record ActivitySectionResponse(
        string Id,
        string Name,
        string Description,
        List<ActivityItemResponse> Items);

    public record ActivityItemResponse(
        string Id,
        string Name,
        string Description);
}
