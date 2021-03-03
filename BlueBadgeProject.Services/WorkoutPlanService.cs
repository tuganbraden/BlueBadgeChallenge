using BlueBadgeProject.Data;
using BlueBadgeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Services
{
    public class WorkoutPlanService
    {
        public readonly Guid _userId;

        public WorkoutPlanService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorkoutPlan(WorkoutPlanCreate model)
        {
            var entity =
                new WorkoutPlan
                {
                    CreatedBy = _userId.ToString(),
                    PlanName = model.PlanName,
                    Intensity = model.Intensity,
                    ProgramType = (Data.WorkoutType)model.ProgramType
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WorkoutPlans.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkoutPlanListItem> GetPlansFromUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WorkoutPlans
                        .Where(e => e.CreatedBy == _userId.ToString())
                        .Select(
                            e =>
                                new WorkoutPlanListItem
                                {
                                    PlanId = e.PlanId,
                                    PlanName = e.PlanName
                                }
                        );
                return query.ToArray();
            }
        }

        public object GetPlanById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkoutPlans
                        .Single(e => e.PlanId == Id && e.CreatedBy == _userId.ToString());
                return 
                    new WorkoutPlanDetail
                    {
                        PlanId = entity.PlanId,
                        PlanName = entity.PlanName,
                        Intensity = entity.Intensity,
                        ProgramType = (Models.WorkoutType)entity.ProgramType
                    };
            }
        }

        public bool UpdatePlan(WorkoutPlanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkoutPlans
                        .Single(e => e.PlanId == model.PlanId && e.CreatedBy == _userId.ToString());

                entity.PlanName = model.PlanName;
                entity.Intensity = model.Intensity;
                entity.ProgramType = (Data.WorkoutType)model.ProgramType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlan(int planId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkoutPlans
                        .Single(e => e.PlanId == planId && e.CreatedBy == _userId.ToString());

                ctx.WorkoutPlans.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}