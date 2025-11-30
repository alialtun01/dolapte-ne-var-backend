using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Data.Configurations;

public class RecipeReportConfiguration : IEntityTypeConfiguration<RecipeReport>
{
    public void Configure(EntityTypeBuilder<RecipeReport> builder)
    {

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Reason)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.AdminNote)
            .HasMaxLength(500);

        // Query Filter - Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        // Relationships
        builder.HasOne(x => x.Recipe)
            .WithMany()
            .HasForeignKey(x => x.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.ReportedBy)
            .WithMany(x => x.RecipeReports)
            .HasForeignKey(x => x.ReportedByUserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.Status);
    }
}