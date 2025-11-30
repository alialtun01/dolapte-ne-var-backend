using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class Review : AuditableEntity<int>
{
    public int RecipeId { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; } // 1-5 yıldız
    public string? Comment { get; set; }
    public string? ImageUrl { get; set; } // Fotoğraflı yorum

    // Navigation Properties
    public Recipe Recipe { get; set; } = null!;
    public User User { get; set; } = null!;
    public ICollection<ReviewReport> Reports { get; set; } = new List<ReviewReport>();
}