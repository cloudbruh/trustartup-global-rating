using System.Text.Json.Serialization;

namespace CloudBruh.Trustartup.GlobalRating.Models;

public class Startup
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    
    [JsonPropertyName("ending_at")]
    public DateTime EndingAt { get; set; }
    
    [JsonPropertyName("funds_goal")]
    public decimal FundsGoal { get; set; }
    
    [JsonPropertyName("rating")]
    public double Rating { get; set; }
    
    [JsonPropertyName("posts")]
    public List<Post> Posts { get; set; } = new();
    
    [JsonPropertyName("comments")]
    public List<Comment> Comments { get; set; } = new();
    
    [JsonPropertyName("follows")]
    public List<Follow> Follows { get; set; } = new();
    
    [JsonPropertyName("likes")]
    public List<Like> Likes { get; set; } = new();
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}