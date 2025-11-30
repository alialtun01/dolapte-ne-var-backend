using RecipeApp.Domain.Common;
using RecipeApp.Domain.Enums;

namespace RecipeApp.Domain.Entities;

public class RecipeReport : AuditableEntity<int>
{
    public int RecipeId { get; set; }
    public int ReportedByUserId { get; set; }
    public string Reason { get; set; } = string.Empty;
    public ReportStatus Status { get; set; }
    public string? AdminNote { get; set; }

    // Navigation Properties
    public Recipe Recipe { get; set; } = null!;
    public User ReportedBy { get; set; } = null!;
}