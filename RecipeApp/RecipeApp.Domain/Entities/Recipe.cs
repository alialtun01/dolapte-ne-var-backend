using RecipeApp.Domain.Common;
using RecipeApp.Domain.Enums;

namespace RecipeApp.Domain.Entities;

public class Recipe : AuditableEntity<int>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public int PreparationTime { get; set; } // Dakika
    public int CookingTime { get; set; } // Dakika
    public int ServingSize { get; set; } // Porsiyon sayısı
    public DifficultyLevel Difficulty { get; set; }
    public RecipeStatus Status { get; set; }
    public decimal AverageRating { get; set; } // Ortalama puan
    public int ReviewCount { get; set; } // Yorum sayısı
    public int UserId { get; set; }
    public string? RejectionReason { get; set; } // Admin red nedeni

    // Navigation Properties
    public User User { get; set; } = null!;
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
    public ICollection<RecipeMedia> RecipeMedias { get; set; } = new List<RecipeMedia>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<UserFavorite> Favorites { get; set; } = new List<UserFavorite>();
}