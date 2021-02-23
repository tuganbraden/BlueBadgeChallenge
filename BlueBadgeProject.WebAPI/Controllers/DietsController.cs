using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static BlueBadgeProject.Models.DietModels;
using System.Data.Entity;
using BlueBadgeProject.Data;

namespace BlueBadgeProject.WebAPI.Controllers
{
    public class DietsController : ApiController
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        
        public IHttpActionResult AddDiet([FromBody] Diet model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty. ");
            }
            if (ModelState.IsValid)
            {
                Diets DietEntity = new Diets(
                    model.DietId,
                    model.Name,
                    model.IsVegetarian,
                    model.IsKeto,
                    model.IsLactoseFree,
                    model.IsGlutenFree,
                    model.Description,
                    model.CaloriesPerDay);
                Diets var = ctx.Diets.Add(DietEntity);

                return Ok("Diet " + model.Name + " has been created! ");
            }
            return BadRequest(ModelState);
        }
    }
}