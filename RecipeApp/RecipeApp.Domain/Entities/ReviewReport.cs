using RecipeApp.Domain.Common;
using RecipeApp.Domain.Enums;

namespace RecipeApp.Domain.Entities;

public class ReviewReport : AuditableEntity<int>
{
    public int ReviewId { get; set; }
    public int ReportedByUserId { get; set; }
    public string Reason { get; set; } = string.Empty;
    public ReportStatus Status { get; set; }
    public string? AdminNote { get; set; }

    // Navigation Properties
    public Review Review { get; set; } = null!;
    public User ReportedBy { get; set; } = null!;
}