using BlueBadgeProject.Data;
using BlueBadgeProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Services
{
    public class AdminService
    {
        private BlueBadgeProject.Data.Migrations.UserManager _userManager;
        public BlueBadgeProject.Data.Migrations.UserManager UserManager
        {
            get
            {
                return _userManager;
            }
            private set
            {
                _userManager = value;
            }
        }
        public AdminService(Data.Migrations.UserManager userManager)
        {
            _userManager = UserManager;

        }
        public IEnumerable<AdminListItem> GetAdmins()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ApplicationUserRoles.Where(e => e.Role.Name == "Admin").Select(u => new AdminListItem
                {
                    CreatedUtc = u.User.CreatedUtc,
                    FullName = u.User.FullName,
                    UserName = u.User.UserName
                });
                return query.ToArray();

            }
        }
        //returns true if user is an admin
        public bool IsAdmin(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {


                var query = ctx.ApplicationUserRoles.Where(r => r.Role.Name == "Admin" && r.UserId == userId);
                return query.Count() == 1;







            }
        }
        //assigns admin role to a user
        public async Task<bool> MakeUserAdmin(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                try
                {
                    var entity = ctx.Users.Single(e => e.UserId == userId);
                    var result = await UserManager.AddToRoleAsync(entity.Id, "Admin");

                    return result.Succeeded;
                }
                catch (Exception e)
                {

                    return false;
                }








            }
        }
        public bool RemoveAdminStatus(string userId)
        {
            if (!IsAdmin(userId))
                return false;
            using (var ctx = new ApplicationDbContext())
            {
                var result = UserManager.RemoveFromRole(userId, "Admin");
                return result.Succeeded;
            }
        }
    }
}
