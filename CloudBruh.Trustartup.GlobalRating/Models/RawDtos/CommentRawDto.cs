using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public record CommentRawDto(string Text) : IIdentifiable
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("userId")]
    public long UserId { get; init; }
    
    [JsonPropertyName("commentableId")]
    public long CommentableId { get; init; }
    
    [JsonPropertyName("commentableType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CommentableType CommentableType { get; init; }
    
    [JsonPropertyName("repliedId")]
    public long? RepliedId { get; init; }
    
    [JsonPropertyName("text")]
    public string Text { get; init; } = Text;
    
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; init; }
    
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; init; }
}