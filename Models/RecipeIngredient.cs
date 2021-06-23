using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApi.Models
{
    public class RecipeIngredient
    {
        public float Units  { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipes{ get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredients { get; set; }
    }
}
