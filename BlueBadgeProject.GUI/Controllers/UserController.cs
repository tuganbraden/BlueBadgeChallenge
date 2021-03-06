using BlueBadgeProject.GUI.Views;
using BlueBadgeProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


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
    }
}