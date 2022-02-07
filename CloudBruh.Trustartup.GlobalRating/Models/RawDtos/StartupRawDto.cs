using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public record StartupRawDto(string Name, string Description) : IIdentifiable
{
    [JsonPropertyName("id")]
    public long Id { get; init; }
    
    [JsonPropertyName("name")]
    public string Name { get; init; } = Name;

    [JsonPropertyName("description")]
    public string Description { get; init; } = Description;

    [JsonPropertyName("userId")]
    public long UserId { get; init; }
    
    [JsonPropertyName("endingAt")]
    public DateTime EndingAt { get; init; }
    
    [JsonPropertyName("fundsGoal")]
    public decimal FundsGoal { get; init; }
    
    [JsonPropertyName("rating")]
    public double Rating { get; init; }
    
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; init; }
    
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; init; }
}