using Microsoft.AspNetCore.Mvc;
using RecipesWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenController : ControllerBase
    {
        private readonly ApiContext _apiContext;
        public KitchenController(ApiContext apiContext)
        {
            _apiContext = apiContext;    
        }

        [HttpGet]
        public ActionResult GetKitchens()
        {
            
            var kitchens = _apiContext.Kitchens;
            if (!kitchens.Any())
                return NotFound("There is no recipe");
            return Ok(kitchens);
        }
    }
}
