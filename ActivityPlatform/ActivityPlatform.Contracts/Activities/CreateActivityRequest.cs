namespace SocialEventPlatform.Contracts.Activities
{
    public record CreateActivityRequest(
        string Name,
        string Description,
        List<ActivitySection> Sections);

    public record ActivitySection(
        string Name,
        string Description,
        List<ActivityItem> Items);

    public record ActivityItem(
        string Name,
        string Description);
}
