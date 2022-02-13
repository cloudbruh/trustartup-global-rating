namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public record StartupRawDto(string Name, string Description) : IIdentifiable
{
    public long Id { get; init; }
    
    public string Name { get; init; } = Name;

    public string Description { get; init; } = Description;

    public long UserId { get; init; }
    
    public DateTime EndingAt { get; init; }
    
    public decimal FundsGoal { get; init; }
    
    public double Rating { get; init; }
    
    public DateTime UpdatedAt { get; init; }
    
    public DateTime CreatedAt { get; init; }
}