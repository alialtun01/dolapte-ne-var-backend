using RecipeApp.Domain.Common;
using RecipeApp.Domain.Enums;

namespace RecipeApp.Domain.Entities;

public class RecipeMedia : AuditableEntity<int>
{
    public int RecipeId { get; set; }
    public string Url { get; set; } = string.Empty;
    public MediaType Type { get; set; } // Image veya Video
    public int Order { get; set; } // Sıralama

    // Navigation Properties
    public Recipe Recipe { get; set; } = null!;
}