namespace CloudBruh.Trustartup.GlobalRating.Models.RawDtos;

public record PostRawDto(string Header, string Text) : IIdentifiable
{
    public long Id { get; init; }
    
    public long StartupId { get; init; }
    
    public string Header { get; init; } = Header;
    
    public string Text { get; init; } = Text;
    
    public DateTime UpdatedAt { get; init; }
    
    public DateTime CreatedAt { get; init; }
}