using BlueBadgeProject.GUI.Views;
using BlueBadgeProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace BlueBadgeProject.GUI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IEnumerable<UserListItem> users = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/");
                var responseTask = client.GetAsync("User/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserListItem>>();
                    readTask.Wait();
                    users = readTask.Result;
                }
                else
                {
                    users = Enumerable.Empty<UserListItem>();
                    Debug.WriteLine("No users");
                }
            }
            
            return View(users);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(UserCreate user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/User/Register");

                var postTask = client.PostAsJsonAsync<UserCreate>(client.BaseAddress, user);
                postTask.Wait();
                var result = postTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(user);
        }
        public ActionResult detail()
        {
            
            return View();
        }
        public ActionResult Edit(string id)
        {
            UserEdit user = new UserEdit();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/User/");
                var responseTask = client.GetAsync("GetUserInfo?userId=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserDetail>();
                    readTask.Wait();
                    user.UserId = id;
                    user.FullName = readTask.Result.FullName;
                    user.Height = readTask.Result.Height;
                    user.Weight = readTask.Result.Weight;
                    user.GoalWeight = readTask.Result.GoalWeight;
                    user.GoalDate = readTask.Result.GoalDate;
                    user.SubscriberStatus = readTask.Result.SubscriberStatus;
                    user.WeeklyCaloricNeed = readTask.Result.WeeklyCaloricNeed;
                    user.BodyType = readTask.Result.BodyType;
                    user.LifeStyleType = readTask.Result.LifeStyleType;
                    user.IsVegetarian = readTask.Result.IsVegetarian;
                    user.IsKeto = readTask.Result.IsKeto;
                    user.IsLactoseFree = readTask.Result.IsLactoseFree;
                    user.IsGlutenFree = readTask.Result.IsGlutenFree;
                    user.DietId = readTask.Result.DietId;


                }
            }
            return View(user);
        }
        
    }
}