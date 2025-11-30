using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Data.Configurations;

public class UserFavoriteConfiguration : IEntityTypeConfiguration<UserFavorite>
{
    public void Configure(EntityTypeBuilder<UserFavorite> builder)
    {

        builder.HasKey(x => x.Id);

        // Query Filter - Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        // Relationships
        builder.HasOne(x => x.User)
            .WithMany(x => x.Favorites)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Recipe)
            .WithMany(x => x.Favorites)
            .HasForeignKey(x => x.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => new { x.UserId, x.RecipeId }).IsUnique();
    }
}