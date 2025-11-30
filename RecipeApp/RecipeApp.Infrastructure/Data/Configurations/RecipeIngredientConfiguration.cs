using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Data.Configurations;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount)
            .HasMaxLength(50);

        // Query Filter - Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        // Relationships
        builder.HasOne(x => x.Recipe)
            .WithMany(x => x.RecipeIngredients)
            .HasForeignKey(x => x.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Ingredient)
            .WithMany(x => x.RecipeIngredients)
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => new { x.RecipeId, x.IngredientId }).IsUnique();
    }
}