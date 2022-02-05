using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public record PostRawDto(string Header, string Text) : IIdentifiable
{
    [JsonPropertyName("id")]
    public long Id { get; init; }
    
    [JsonPropertyName("startupId")]
    public long StartupId { get; init; }
    
    [JsonPropertyName("header")]
    public string Header { get; init; } = Header;
    
    [JsonPropertyName("text")]
    public string Text { get; init; } = Text;
    
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; init; }
    
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; init; }
}