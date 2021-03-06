using BlueBadgeProject.Models;
using BlueBadgeProject.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeProject.WebAPI.Controllers
{
    [RoutePrefix("api/WorkoutPlans")]
    public class WorkoutPlanController : ApiController
    {
        [HttpPost]
        private WorkoutPlanService CreateWorkoutPlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var workoutPlanService = new WorkoutPlanService(userId);
            return workoutPlanService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            WorkoutPlanService workoutPlanService = CreateWorkoutPlanService();
            var workoutPlans = workoutPlanService.GetPlansFromUser();
            return Ok(workoutPlans);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            WorkoutPlanService workoutPlanService = CreateWorkoutPlanService();
            var workoutPlan = workoutPlanService.GetPlanById(id);
            return Ok(workoutPlan);
        }

        [HttpPost]
        public IHttpActionResult Post(WorkoutPlanCreate workoutPlan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWorkoutPlanService();

            if (!service.CreateWorkoutPlan(workoutPlan))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(WorkoutPlanEdit plan)
        {
            if(ModelState.IsValid)
            {
                var service = CreateWorkoutPlanService();

                if (service.UpdatePlan(plan))
                    return Ok();

                return InternalServerError();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateWorkoutPlanService();

            if (service.DeletePlan(id))
                return Ok();

            return InternalServerError();
        }
    }
}
