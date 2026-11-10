using Microsoft.EntityFrameworkCore;
using Modules.NewsLetter.Persistence.Constants;

namespace Modules.NewsLetter.Persistence;
/// <summary>
/// Represents the NewsLetter module database context. 
/// </summary>
public sealed class NewsLetterDbContext : DbContext 
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NewsLetterDbContext"/> class.
    /// </summary>
    /// <param name="options"> The database context options. </param>
    public NewsLetterDbContext(DbContextOptions<NewsLetterDbContext> options) 
        : base(options)
    {
    }
    
    /// <inheritdoc />
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.NewsLetter);
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    } 
}