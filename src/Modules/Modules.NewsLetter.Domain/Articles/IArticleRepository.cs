using Modules.NewsLetter.Domain;

namespace Modules.NewsLetter.Domain.Articles;

public interface IArticleRepository
{
    public void Add(Article article);
    public Task<Article?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

}