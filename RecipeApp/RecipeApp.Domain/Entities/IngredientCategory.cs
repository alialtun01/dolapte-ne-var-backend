using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class IngredientCategory : AuditableEntity<int>
{
    public string Name { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}