namespace RecipeApp.Domain.Enums;

public enum ReportStatus
{
    Pending = 1,    // Beklemede
    Approved = 2,   // Onaylandı (içerik kaldırıldı)
    Rejected = 3    // Reddedildi
}