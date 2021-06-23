using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApi.Models
{
    public class ApiContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
            //LoadRecipes();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Kitchen>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<Recipe>()
               .HasKey(x => x.Id);

            //1-n relation
            // Add the shadow property to the model
            modelBuilder.Entity<Recipe>()
            .Property<int>("KitchenFK");

            // Use the shadow property as a foreign key
            modelBuilder.Entity<Recipe>()
                .HasOne(p => p.Kitchen)
                .WithMany(b => b.Recipes)
                .HasForeignKey("KitchenFK");
            
            //n-n relations
            modelBuilder.Entity<RecipeIngredient>()
            .HasKey(t => new { t.RecipeId, t.IngredientId});

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(pt => pt.Ingredients)
                .WithMany(p => p.RecipeIngredients)
                .HasForeignKey(pt => pt.IngredientId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(pt => pt.Recipes)
                .WithMany(t => t.RecipeIngredients)
                .HasForeignKey(pt => pt.RecipeId);
        }

        //public void LoadRecipes()
        //{
        //    Recipe recipe = new Recipe() { Title = "XXXXXXX", Description="desc1"  };
        //    Recipes.Add(recipe);
        //    recipe = new Recipe() { Title = "WWWWW", Description = "desc2" };
        //    Recipes.Add(recipe);  
        //}

        //public List<Recipe> GetRecipes()
        //{
        //    return Recipes.Local.ToList<Recipe>();
        //}
    }
}


//1-n rel
//modelBuilder.Entity<Kitchen>()
//    .HasMany(b => b.Recipes)
//    .WithOne();