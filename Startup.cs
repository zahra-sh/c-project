using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RecipesWebApi.Interfaces;
using RecipesWebApi.Models;
using RecipesWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "mydb"));
            services.AddScoped<ApiContext>();
            services.AddScoped<IMyDependency, MyDependency>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecipesWebApi", Version = "v1" });
            });
            //var options = new DbContextOptionsBuilder<MyContext>()
            //          .UseInMemoryDatabase(databaseName: "MockDB")
            //          .Options;

            //var context = new MyContext(options);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, ApiContext context)
        {
            //var context = app.ApplicationServices.GetService<ApiContext>();
            AddTestData(context);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecipesWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private static void AddTestData(ApiContext _apiContext)
        {
            Recipe r1 = new Recipe { Id = 1, Title = "Noodle", Description = "Italian food" };
            Recipe r2 = new Recipe { Id = 2, Title = "Pizza", Description = "French food" };
            Recipe r3 = new Recipe { Id = 3, Title = "شیرین پلو", Description = "Iranian food" };
            _apiContext.Recipes.Add(r1);
            _apiContext.Recipes.Add(r2);
            _apiContext.Recipes.Add(r3);

            RecipeIngredient ri14 = new RecipeIngredient { RecipeId = 1, IngredientId = 4, Units = 500 };
            RecipeIngredient ri15 = new RecipeIngredient { RecipeId = 1, IngredientId = 5, Units = 10 };
            RecipeIngredient ri16 = new RecipeIngredient { RecipeId = 1, IngredientId = 6, Units = 300 };
            RecipeIngredient ri25 = new RecipeIngredient { RecipeId = 2, IngredientId = 5, Units = 5 };
            RecipeIngredient ri26 = new RecipeIngredient { RecipeId = 2, IngredientId = 6, Units = 300 };
            RecipeIngredient ri31 = new RecipeIngredient { RecipeId = 3, IngredientId = 1, Units = 4 };
            RecipeIngredient ri32 = new RecipeIngredient { RecipeId = 3, IngredientId = 2, Units = 100 };

            //_apiContext.Ingredients.Add(new Ingredient { Id = 1, Name = "برنج", Unit = "پیمانه", Calory = "100 k", RecipeIngredients = { ri31 } });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 2, Name = "شکر", Unit = "گرم", Calory = "5 m", RecipeIngredients = { ri32 } });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 3, Name = "لیمو ترش", Unit = "عدد", Calory = "10 k", RecipeIngredients = { ri31 } });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 4, Name = "ماکارونی", Unit = "گرم", Calory = "150 k" });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 5, Name = "سیب زمینی", Unit = "عدد", Calory = "100 k", RecipeIngredients = { ri31 } });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 6, Name = "گوشت", Unit = "گرم", Calory = "170 k", RecipeIngredients = { ri31 } });

            _apiContext.Kitchens.Add(new Kitchen { Name = "Akbar Juje", Address = "LA", Recipes = new List<Recipe>() { r1, r2, r3 } });
            _apiContext.SaveChanges();
        }

        private static void AddTestData2(ApiContext _apiContext)
        {
            //RecipeIngredient ri14 = new RecipeIngredient { RecipeId = 1, IngredientId = 4, Units = 500 };
            //RecipeIngredient ri15 = new RecipeIngredient { RecipeId = 1, IngredientId = 5, Units = 10 };
            //RecipeIngredient ri16 = new RecipeIngredient { RecipeId = 1, IngredientId = 6, Units = 300 };
            //RecipeIngredient ri25 = new RecipeIngredient { RecipeId = 2, IngredientId = 5, Units = 5 };
            //RecipeIngredient ri26 = new RecipeIngredient { RecipeId = 2, IngredientId = 6, Units = 300 };
            //RecipeIngredient ri31 = new RecipeIngredient { RecipeId = 3, IngredientId = 1, Units = 4 };
            //RecipeIngredient ri32 = new RecipeIngredient { RecipeId = 3, IngredientId = 2, Units = 100 };

            //_apiContext.Ingredients.Add(new Ingredient { Id = 1, Name = "برنج", Unit = "پیمانه", Calory = "100 k", RecipeIngredients = { ri31 } });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 2, Name = "شکر", Unit = "گرم", Calory = "5 m", RecipeIngredients = { ri32 } });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 3, Name = "لیمو ترش", Unit = "عدد", Calory = "10 k", RecipeIngredients = { ri31 } });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 4, Name = "ماکارونی", Unit = "گرم", Calory = "150 k" });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 5, Name = "سیب زمینی", Unit = "عدد", Calory = "100 k", RecipeIngredients = { ri31 } });
            //_apiContext.Ingredients.Add(new Ingredient { Id = 6, Name = "گوشت", Unit = "گرم", Calory = "170 k", RecipeIngredients = { ri31 } });

            //Recipe r1 = new Recipe { Id = 1, Title = "Noodle", Description = "Italian food" , RecipeIngredients = { ri14, ri15, ri16 } };
            //Recipe r2 = new Recipe { Id = 2, Title = "Pizza", Description = "French food", RecipeIngredients = { ri25, ri26 } };
            //Recipe r3 = new Recipe { Id = 3, Title = "شیرین پلو", Description = "Iranian food", RecipeIngredients = { ri31, ri32 } };

            //_apiContext.Recipes.Add(r1);
            //_apiContext.Recipes.Add(r2);
            //_apiContext.Recipes.Add(r3);

            //_apiContext.RecipeIngredients.Add(ri14);
            //_apiContext.RecipeIngredients.Add(ri15);
            //_apiContext.RecipeIngredients.Add(ri16);
            //_apiContext.RecipeIngredients.Add(ri25);
            //_apiContext.RecipeIngredients.Add(ri26);
            //_apiContext.RecipeIngredients.Add(ri31);
            //_apiContext.RecipeIngredients.Add(ri32);

            //_apiContext.Kitchens.Add(new Kitchen { Name = "Akbar Juje", Address = "LA", Recipes = new List<Recipe>() { r1, r2, r3 } });

            //_apiContext.SaveChanges();
        }
    }
}
