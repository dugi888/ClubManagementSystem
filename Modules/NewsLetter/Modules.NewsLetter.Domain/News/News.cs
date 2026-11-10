namespace ClubManagementSystem.Modules.NewsLetter.Modules.NewsLetter.Domain.News;

public class News
{
    private Guid id { get; set; }
    private string title { get; set; }
    private string? description { get; set; } // this is small text following the heading, if there is not any text. Take first X characters of the content and use it as description
    private Content content { get; set; }
    
    
    private DateTime created_at { get; set; }
    // private DateTime updated_at { get; set; }
}