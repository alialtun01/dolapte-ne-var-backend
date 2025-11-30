using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class RecipeCategory : AuditableEntity<int>
{
    public int RecipeId { get; set; }
    public int CategoryId { get; set; }

    // Navigation Properties
    public Recipe Recipe { get; set; } = null!;
    public Category Category { get; set; } = null!;
}