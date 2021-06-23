using Microsoft.AspNetCore.Mvc;
using RecipesWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApi.Controllers
{
    public class IngredientController : ControllerBase
    {
        private readonly ApiContext _apiContext;
        public IngredientController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

    
        [HttpGet]
        public ActionResult GetIngredient()
        {
            var ingredients = _apiContext.Ingredients;
            if (!ingredients.Any())
                return NotFound("There is no recipe");
            return Ok();
        }
    }
}
