namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public class FollowRawDto : IIdentifiable
{
    public long Id { get; init; }
    
    public long UserId { get; init; }
    
    public long StartupId { get; init; }
    
    public DateTime CreatedAt { get; init; }
}