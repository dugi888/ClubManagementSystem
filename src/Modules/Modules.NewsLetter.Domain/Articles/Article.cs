using Domain;
using Modules.NewsLetter.Domain.Articles;

namespace Modules.NewsLetter.Domain;

public class Article : Entity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Summary { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }
    public DateTimeOffset? PublishedAt { get; private set; }
    public ArticleStatus Status { get; private set; }
    public ArticleImage? CoverImage { get; private set; }

    private Article(){}

    public void Publish(DateTime now)
    {
        if (Status == ArticleStatus.Published) return;
        
        // TODO: This should be in the rules
        if(string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Content) || string.IsNullOrWhiteSpace(Summary))
        {
            throw new InvalidOperationException("Cannot publish an article with empty title, content, or summary.");
        }

        Status = ArticleStatus.Published;
        PublishedAt= now;
        UpdatedAt = now;
    }

    public void SetCoverImage(ArticleImage image, DateTimeOffset now)
    {
        CoverImage = image;
        UpdatedAt = now;
    }
    public static Article CreateDraft(string title, string summary, string content, DateTimeOffset now)
    {
        if(string.IsNullOrWhiteSpace(title)) throw new InvalidOperationException("Title cannot be empty.");

        return new Article
        {
            Title = title,
            Summary = summary,
            Content = content,
            Status = ArticleStatus.Draft,
            CreatedAt = now,
            UpdatedAt = now,
        };
    }
}