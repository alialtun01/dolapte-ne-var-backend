using RecipeApp.Domain.Common;
using RecipeApp.Domain.Enums;

namespace RecipeApp.Domain.Entities;

public class Category : AuditableEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public CategoryType Type { get; set; } // Yemek Tipi, Diyet Tipi, Mutfak Tipi

    // Navigation Properties
    public ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
}