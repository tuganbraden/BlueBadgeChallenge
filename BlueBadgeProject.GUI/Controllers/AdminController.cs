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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            IEnumerable<AdminListItem> admins = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("Admin/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AdminListItem>>();
                    readTask.Wait();
                    admins = readTask.Result;
                }
                else
                {
                    admins = Enumerable.Empty<AdminListItem>();
                    
                }
            }

            return View(admins);
        }
        public ActionResult MakeAdmin()
        {

            IEnumerable<UserListItem> users = null;
            List<UserListItem> nonAdmins = new List<UserListItem>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Startup.token.AccessToken);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("User/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserListItem>>();
                    readTask.Wait();
                    users = readTask.Result;
                    foreach(var user in users)
                    {
                        var queryTask = client.GetAsync("Admin/IsAdmin?userId=" + user.UserId);
                        queryTask.Wait();
                        var queryResult = queryTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var isAdminTask = queryResult.Content.ReadAsAsync<bool>();
                            isAdminTask.Wait();

                            if (!isAdminTask.Result)
                            {
                                nonAdmins.Add(user);
                            }
                        }
                    }
                }
                else
                {
                    users = Enumerable.Empty<UserListItem>();
                    //nonAdmins = Enumerable.Empty<UserListItem>();
                }
            }

            return View(nonAdmins);
        }

    }
}