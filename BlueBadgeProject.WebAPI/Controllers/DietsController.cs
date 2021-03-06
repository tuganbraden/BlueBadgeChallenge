using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using BlueBadgeProject.Data;
using BlueBadgeProject.Services;
using BlueBadgeProject.Models;

namespace BlueBadgeProject.WebAPI.Controllers
{
    [RoutePrefix("api/Diets")]
    public class DietsController : ApiController
    {
        DietService dietService = new DietService();
        [HttpPost]
        public IHttpActionResult AddDiet([FromBody] Models.DietCreate model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty. ");
            }
            if (ModelState.IsValid)
            {
                
                var created = dietService.CreateDiet(model);
                if (created == true)
                {
                    return Ok("Diet " + model.Name + " has been created. ");
                }
                else
                {
                    return BadRequest("Your diet was not created. Please try again. ");

                }                      
                        
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public IHttpActionResult GetDietList()
        {
         return (IHttpActionResult) dietService.GetAllDiets();

        }
        [HttpGet]
        public IHttpActionResult GetAUsersDiet(string Id)
        {
            if (Id is null)
            {
                return BadRequest("Your request body cannot be empty. ");
            }
            if (ModelState.IsValid)
            {
                return (IHttpActionResult)dietService.GetDietByUserId(Id);
            }
            return BadRequest(ModelState);           

        }
        [HttpGet]
        public IHttpActionResult GetDietByNeeds(DietFind model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty. ");
            }
            if (ModelState.IsValid)
            {
                return (IHttpActionResult)dietService.GetDietByUserNeeds(model);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IHttpActionResult DietEdit(DietEdit model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty. ");
            }
            if (ModelState.IsValid)
            {
                var edited = dietService.EditADiet(model);
                if (edited == true)
                    return Ok();
                else
                    return BadRequest("Your diet could not be edited. Please try again. ");
            }          
           
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IHttpActionResult DietDelete(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("Please enter a valid Diet Id. ");
            }
            if (ModelState.IsValid)
            {
                var deleted = dietService.DeleteDiet(Id);
                if (deleted == true)
                    return Ok();
                else
                    return BadRequest("Your diet could not be deleted. Please try again. ");
            }

            return BadRequest(ModelState);
        }
        

    }
}