using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Data.Configurations;

public class UserPreferenceConfiguration : IEntityTypeConfiguration<UserPreference>
{
    public void Configure(EntityTypeBuilder<UserPreference> builder)
    {

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DietaryPreferences)
            .HasMaxLength(500);

        builder.Property(x => x.Allergies)
            .HasMaxLength(500);

        builder.Property(x => x.SavedIngredients)
            .HasMaxLength(2000);

        // Query Filter - Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        // Indexes
        builder.HasIndex(x => x.UserId).IsUnique();
    }
}