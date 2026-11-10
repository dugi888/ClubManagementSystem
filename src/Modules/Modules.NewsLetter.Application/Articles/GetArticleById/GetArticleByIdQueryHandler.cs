using MediatR;
using Modules.NewsLetter.Application.Articles.CreateArticle;
using Modules.NewsLetter.Application.DTOs;
using Modules.NewsLetter.Domain;
using Modules.NewsLetter.Domain.Articles;

namespace Modules.NewsLetter.Application.Articles.GetArticleById;

public class GetArticleByIdQueryHandler(
    IArticleRepository  db) : IRequestHandler<GetArticleByIdQuery, ArticleDto?>
{
    public async Task<ArticleDto?> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var article = await db.GetByIdAsync(request.Id, cancellationToken);
        return article is null
            ? null
            : new ArticleDto(article.Id, article.Title, article.Summary, article.Content,  article.Status.ToString(), article.CreatedAt,  article.PublishedAt, article.CoverImage?.StorageKey);
    }
}