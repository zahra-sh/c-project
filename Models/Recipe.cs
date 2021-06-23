using RecipesWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApi.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        //public int kitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
