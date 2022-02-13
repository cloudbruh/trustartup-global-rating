using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public record CommentRawDto(string Text) : IIdentifiable
{
    public long Id { get; init; }

    public long UserId { get; init; }
    
    public long CommentableId { get; init; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CommentableType CommentableType { get; init; }
    
    public long? RepliedId { get; init; }
    
    public string Text { get; init; } = Text;
    
    public DateTime UpdatedAt { get; init; }
    
    public DateTime CreatedAt { get; init; }
}