using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models;

public class Like
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}