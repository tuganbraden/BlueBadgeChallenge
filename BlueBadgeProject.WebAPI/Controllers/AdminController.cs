using BlueBadgeProject.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BlueBadgeProject.WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        public AdminController()
        {

        }
        [Route("Register")]
        [HttpPut]
        public async Task<IHttpActionResult> Register(string userId)
        {
            var service = CreateAdminService();
            if (!await service.MakeUserAdmin(userId))



                return InternalServerError();


            return Ok();

        }
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var service = CreateAdminService();
            return Ok(service.GetAdmins());
        }
        [Route("IsAdmin")]
        [HttpGet]
        public IHttpActionResult IsAdmin(string userId)
        {
            var service = CreateAdminService();
            if (service.IsAdmin(userId)){
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        [Route("RemoveStatus")]
        [HttpDelete]
        public IHttpActionResult RemoveAdminStatus(string userId)
        {
            var service = CreateAdminService();
            try
            {
                if (!service.RemoveAdminStatus(userId))
                    return InternalServerError();
                return Ok();
            }
            catch (Exception e)
            {

                return InternalServerError();
            }
        }


        #region Helpers
        private AdminService CreateAdminService()
        {
            Data.Migrations.UserManager userManager = Request.GetOwinContext().GetUserManager<Data.Migrations.UserManager>();
            var adminService = new AdminService(userManager);
            return adminService;
            
        }
        #endregion
    }
}
