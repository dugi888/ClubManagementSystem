using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.NewsLetter.Domain;

namespace Modules.NewsLetter.Persistence.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("articles");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedNever();
        
        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
        
        builder.Property(a => a.Summary).HasMaxLength(500);
        
        builder.Property(a => a.Content).HasConversion<string>().IsRequired();
        
        builder.Property(a => a.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt).IsRequired();
        builder.Property(a => a.PublishedAt).IsRequired(false);

        builder.OwnsOne(a => a.CoverImage, image =>
        {
            image.Property(i => i.StorageKey).HasColumnName("cover_image_storage_key").IsRequired();
            image.Property(i => i.AltText).HasColumnName("cover_image_alt_text").IsRequired(false);
            image.Property(i => i.ContentType).HasColumnName("cover_image_content_type").IsRequired();
            image.Property(i => i.Width).HasColumnName("cover_image_width").IsRequired();
            image.Property(i => i.Height).HasColumnName("cover_image_height").IsRequired();
        });

        // Index for sorting to get newest and published first 
        builder.HasIndex(a => new { a.Status, a.PublishedAt });
    }
}