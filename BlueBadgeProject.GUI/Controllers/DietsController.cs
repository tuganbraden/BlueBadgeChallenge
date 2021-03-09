using BlueBadgeProject.Models;
using BlueBadgeProject.WebAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace BlueBadgeProject.GUI.Controllers
{
    public class DietsController : Controller
    {
        // GET: Diets
        public ActionResult Index()
        {

            IEnumerable<DietListItem> users = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/Diets/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<DietListItem>>();
                    readTask.Wait();
                    users = readTask.Result;
                }
                else
                {
                    users = Enumerable.Empty<DietListItem>();
                    Debug.WriteLine("No users");
                }
            }

            return View(users);
        }
        public ActionResult Create()
        {

            {
                return View();
            }

        }
        [HttpPost]

        public ActionResult Create(DietCreate diet)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/Diets");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var postTask = client.PostAsJsonAsync<DietCreate>(client.BaseAddress, diet);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(diet);
        }
        public ActionResult Details(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/Diets/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("GetDietInfo?dietId=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                DietDetail model = new DietDetail();
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DietDetail>();
                    readTask.Wait();
                    model = readTask.Result;
                }
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            DietEdit diet = new DietEdit();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/Diets/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("GetDietInfo?dietId=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DietDetail>();
                    readTask.Wait();
                    diet.DietId = id;
                    diet.Description = readTask.Result.Description;
                    diet.Name = readTask.Result.Name;
                    diet.CaloriesPerDay = readTask.Result.CaloriesPerDay;
                    diet.IsVegetarian = readTask.Result.IsVegetarian;
                    diet.IsKeto = readTask.Result.IsKeto;
                    diet.IsLactoseFree = readTask.Result.IsLactoseFree;
                    diet.IsGlutenFree = readTask.Result.IsGlutenFree;
                    diet.DietId = readTask.Result.DietId;


                }
            }
            return View(diet);

        }
        [HttpPost]
        public ActionResult Edit(DietEdit model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/Diets/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var puttask = client.PutAsJsonAsync<DietEdit>("Edit", model);
                puttask.Wait();
                var result = puttask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}