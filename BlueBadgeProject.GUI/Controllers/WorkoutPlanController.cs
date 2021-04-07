using BlueBadgeProject.Models;
using BlueBadgeProject.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace BlueBadgeProject.GUI.Controllers
{
    public class WorkoutPlanController : Controller
    {
        // GET: WorkoutPlan
        public ActionResult Index()
        {
            IEnumerable<WorkoutPlanListItem> workouts = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://fitnesswebapi.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("WorkoutPlan");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<WorkoutPlanListItem>>();
                    readTask.Wait();
                    workouts = readTask.Result;
                }
                else
                {
                    workouts = Enumerable.Empty<WorkoutPlanListItem>();

                }
            }

            return View(workouts);
        }
        public ActionResult Create()
        {

            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Create(WorkoutPlanCreate plan)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/WorkoutPlan");


                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var postTask = client.PostAsJsonAsync<WorkoutPlanCreate>(client.BaseAddress, plan);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(plan);
        }
        public ActionResult Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://fitnesswebapi.azurewebsites.net/api/WorkoutPlan/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                WorkoutPlanDetail model = new WorkoutPlanDetail();
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<WorkoutPlanDetail>();
                    readTask.Wait();
                    model = readTask.Result;
                }
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            WorkoutPlanEdit plan = new WorkoutPlanEdit();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/WorkoutPlan/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<WorkoutPlanDetail>();
                    readTask.Wait();
                    plan.PlanId = id;
                    plan.PlanName = readTask.Result.PlanName;
                    plan.ProgramType = readTask.Result.ProgramType;
                    plan.Intensity = readTask.Result.Intensity;

                }
            }
            return View(plan);

        }
        [HttpPost]
        public ActionResult Edit(WorkoutPlanEdit model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://fitnesswebapi.azurewebsites.net/api/WorkoutPlan/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var puttask = client.PutAsJsonAsync<WorkoutPlanEdit>("Edit", model);
                puttask.Wait();
                var result = puttask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/WorkoutPlan/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}