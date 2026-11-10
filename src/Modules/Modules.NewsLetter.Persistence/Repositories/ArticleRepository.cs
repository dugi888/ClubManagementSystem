using Microsoft.EntityFrameworkCore;
using Modules.NewsLetter.Domain;
using Modules.NewsLetter.Domain.Articles;

namespace Modules.NewsLetter.Persistence.Repositories;

public class ArticleRepository(NewsLetterDbContext db) : IArticleRepository
{
    public void Add(Article article) => db.Articles.Add(article);
    public Task<Article?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => 
        db.Articles.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}