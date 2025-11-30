using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class ShoppingListItem : AuditableEntity<int>
{
    public int UserId { get; set; }
    public int IngredientId { get; set; }
    public string? Amount { get; set; }
    public bool IsChecked { get; set; } // Satın alındı mı?

    // Navigation Properties
    public User User { get; set; } = null!;
    public Ingredient Ingredient { get; set; } = null!;
}