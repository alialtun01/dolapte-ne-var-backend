using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class Ingredient : AuditableEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    // Navigation Properties
    public IngredientCategory Category { get; set; } = null!;
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}