namespace Modules.NewsLetter.Domain;

public sealed record ArticleImage
{
    public string StorageKey { get; } // not full URL - "articles/2026/11/example1.jpg"
    public string? AltText { get; } // "Example 1"
    public string ContentType { get; } // "image/jpeg"
    public int Width { get; } 
    public int Height { get; }
    
    public ArticleImage(string storageKey, string? altText, string contentType, int width, int height)
    {
        StorageKey = storageKey;
        AltText = altText;
        ContentType = contentType;
        Width = width;
        Height = height;
    }
    
    private static readonly HashSet<string> AllowedTypes = new(){"image/jpeg", "image/png", "image/gif", "image/webp"}; 
};