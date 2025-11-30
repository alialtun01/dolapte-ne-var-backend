using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class RecipeIngredient : AuditableEntity<int>
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public string? Amount { get; set; } // Miktar (opsiyonel: "2 su bardağı", "1 çay kaşığı", null)

    // Navigation Properties
    public Recipe Recipe { get; set; } = null!;
    public Ingredient Ingredient { get; set; } = null!;
}