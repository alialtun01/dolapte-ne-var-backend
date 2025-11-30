using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class UserFavorite : AuditableEntity<int>
{
    public int UserId { get; set; }
    public int RecipeId { get; set; }

    // Navigation Properties
    public User User { get; set; } = null!;
    public Recipe Recipe { get; set; } = null!;
}