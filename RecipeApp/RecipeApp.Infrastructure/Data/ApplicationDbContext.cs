using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Common;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Data.Configurations;
using RecipeApp.Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RecipeApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientCategory> IngredientCategories { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<RecipeCategory> RecipeCategories { get; set; }
    public DbSet<RecipeMedia> RecipeMedias { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<UserFavorite> UserFavorites { get; set; }
    public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
    public DbSet<UserPreference> UserPreferences { get; set; }
    public DbSet<RecipeReport> RecipeReports { get; set; }
    public DbSet<ReviewReport> ReviewReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeIngredientConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeMediaConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new UserFavoriteConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingListItemConfiguration());
        modelBuilder.ApplyConfiguration(new UserPreferenceConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeReportConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewReportConfiguration());


    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is AuditableEntity<int> &&
                       (e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted));

        foreach (var entry in entries)
        {
            var entity = (AuditableEntity<int>)entry.Entity;

            // TODO: Gerçek kullanıcı ID'si JWT'den gelecek, şimdilik null
            var userId = GetCurrentUserId();

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedOn = DateTime.UtcNow;
                    entity.CreatedBy = userId;
                    entity.IsDeleted = false;
                    break;

                case EntityState.Modified:
                    entity.ModifiedOn = DateTime.UtcNow;
                    entity.ModifiedBy = userId;
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified; // Soft delete
                    entity.IsDeleted = true;
                    entity.DeletedOn = DateTime.UtcNow;
                    entity.DeletedBy = userId;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    private string? GetCurrentUserId()
    {
        // TODO: IHttpContextAccessor ile JWT'den kullanıcı ID'si alınacak
        // Şimdilik null dönüyor
        return null;
    }
}