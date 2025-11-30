using RecipeApp.Domain.Common;

namespace RecipeApp.Domain.Entities;

public class UserPreference : AuditableEntity<int>
{
    public int UserId { get; set; }
    public string? DietaryPreferences { get; set; } // JSON array: ["Vejetaryen", "Glutensiz"]
    public string? Allergies { get; set; } // JSON array: ["Fıstık", "Süt"]
    public string? SavedIngredients { get; set; } // JSON array: Benim Buzdolabım malzemeleri

    // Navigation Properties
    public User User { get; set; } = null!;
}