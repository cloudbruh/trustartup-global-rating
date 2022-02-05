using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public record LikeRawDto : IIdentifiable
{
    [JsonPropertyName("id")]
    public long Id { get; init; }
    
    [JsonPropertyName("userId")]
    public long UserId { get; init; }
    
    [JsonPropertyName("likeableId")]
    public long LikeableId { get; init; }
    
    [JsonPropertyName("likeableType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LikeableType LikeableType { get; init; }
    
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; init; }
}