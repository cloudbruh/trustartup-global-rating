using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public class FollowRawDto : IIdentifiable
{
    [JsonPropertyName("id")]
    public long Id { get; init; }
    
    [JsonPropertyName("userId")]
    public long UserId { get; init; }
    
    [JsonPropertyName("startupId")]
    public long StartupId { get; init; }
    
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; init; }
}