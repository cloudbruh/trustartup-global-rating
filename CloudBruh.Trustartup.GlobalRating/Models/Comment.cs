using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models;

public class Comment
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
    
    [JsonPropertyName("replied_id")]
    public long? RepliedId { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}