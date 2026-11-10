namespace Modules.NewsLetter.Domain;

public class Article 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Summary { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? PublishedAt { get; set; }
    public bool IsPublished { get; set; } // Indicates whether the article is draft or not
    public ArticleImage CoverImage { get; set; }

    public void Publish(DateTime now)
    {
        if (IsPublished) return;
        
        // TODO: This should be in the rules
        if(string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Content) || string.IsNullOrWhiteSpace(Summary))
        {
            throw new InvalidOperationException("Cannot publish an article with empty title, content, or summary.");
        }

        IsPublished = true;
        PublishedAt= now;
    }
}