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
    public class WorkoutPlanController : ApiController
    {
        private WorkoutPlanService CreateWorkoutPlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var workoutPlanService = new WorkoutPlanService(userId);
            return workoutPlanService;
        }

        public IHttpActionResult Get()
        {
            WorkoutPlanService workoutPlanService = CreateWorkoutPlanService();
            var workoutPlans = workoutPlanService.GetPlansFromUser();
            return Ok(workoutPlans);
        }



        public IHttpActionResult Post(WorkoutPlanCreate workoutPlan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWorkoutPlanService();

            if (!service.CreateWorkoutPlan(workoutPlan))
                return InternalServerError();

            return Ok();
        }

    }
}
