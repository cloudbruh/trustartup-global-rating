using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models;

public class Post
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("startup_id")]
    public long StartupId { get; set; }
    
    [JsonPropertyName("header")]
    public string Header { get; set; } = string.Empty;
    
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
    
    [JsonPropertyName("comments")]
    public List<Comment> Comments { get; set; } = new();
    
    [JsonPropertyName("likes")]
    public List<Like> Likes { get; set; } = new();
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}