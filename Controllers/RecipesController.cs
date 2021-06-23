using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesWebApi.Interfaces;
using RecipesWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ApiContext _apiContext;
        //private readonly IMyDependency myDependency;
        public RecipesController(ApiContext apiContext)
        {
            _apiContext = apiContext;

            //if (!_apiContext.Recipes.Any())
            //{
            //    _apiContext.Recipes.Add(new Recipe { Title = "Noodle", Description = "Italian food" });
            //    _apiContext.Recipes.Add(new Recipe { Title = "Pizza", Description = "French food" });
            //    _apiContext.SaveChanges();
            //}
        }

        // GET api/values  
        [HttpGet("/{id}")]
        public ActionResult Get(int id)
        {
            //List<Ingredient> ris
            Recipe r = _apiContext.Recipes.Find(id);
            //Recipe r = _apiContext.Recipes.Where(i => i.Id == Id).FirstOrDefault(); //&& i.RecipeIngredients )
            return Ok(r);
        }

        [HttpGet]
        public ActionResult GetRecipes([FromQuery] int count)
        {
            var recipes = _apiContext.Recipes;
            if (!recipes.Any())
                return NotFound("There is no recipe");
            return Ok(recipes.Take(count));
        }
        [HttpPost]
        public ActionResult CreateNewRecipe([FromBody] Recipe newRecipe)
        {
            if (newRecipe == null)
                return BadRequest();
            _apiContext.Recipes.Add(newRecipe);
            _apiContext.SaveChanges();
            return Created("", newRecipe);
        }

        [HttpDelete]
        public ActionResult DeleteRecipes(int Id)
        {
            if (Id == 0)
                return BadRequest();
            Recipe r = _apiContext.Recipes.FirstOrDefault(i => i.Id == Id);
            if (r == null)
                return NotFound();

            _apiContext.Recipes.Remove(r);
            _apiContext.SaveChanges();
            return new NoContentResult();
        }

        [HttpPut("{id}")] // means that this id will come from route  
        public IActionResult UpdateWorkshopByID(int id, [FromBody] Recipe recipe)
        {

            if (recipe == null || recipe.Id != id)
                return BadRequest();

            var r = _apiContext.Recipes.FirstOrDefault(i => i.Id == id);
            if (r == null)
                return NotFound();

            r.Title = recipe.Title;
            r.Description = recipe.Description;

            _apiContext.Recipes.Update(r);
            _apiContext.SaveChanges();
            return new NoContentResult();
        }


    }
}

