using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public record LikeRawDto : IIdentifiable
{
    public long Id { get; init; }
    
    public long UserId { get; init; }
    
    public long LikeableId { get; init; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LikeableType LikeableType { get; init; }
    
    public DateTime CreatedAt { get; init; }
}