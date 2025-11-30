using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class User : AuditableEntity<int>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? FullName { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? Bio { get; set; }
    public decimal ChefScore { get; set; } // Mutfak Skoru

    // Navigation Properties
    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<UserFavorite> Favorites { get; set; } = new List<UserFavorite>();
    public ICollection<ShoppingListItem> ShoppingList { get; set; } = new List<ShoppingListItem>();
    public ICollection<RecipeReport> RecipeReports { get; set; } = new List<RecipeReport>();
    public ICollection<ReviewReport> ReviewReports { get; set; } = new List<ReviewReport>();
    public UserPreference? Preference { get; set; }
}