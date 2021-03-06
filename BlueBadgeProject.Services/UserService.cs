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
    public class UserService
    {
        private readonly string _userId;
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
        public UserService(string userId, BlueBadgeProject.Data.Migrations.UserManager userManager)
        {
            _userManager = userManager;
            _userId = userId;
        }
        public async Task<bool> CreateUser(UserCreate model)
        {
            var entity = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                Height = model.Height,
                Weight = model.Weight,
                GoalWeight = model.GoalWeight,
                GoalDate = model.GoalDate,
                SubscriberStatus = model.SubscriberStatus,
                WeeklyCaloricNeed = model.WeeklyCaloricNeed,
                BodyType = model.BodyType,
                LifeStyleType = model.LifeStyleType,
                IsVegetarian = model.IsVegetarian,
                IsKeto = model.IsKeto,
                IsLactoseFree = model.IsLactoseFree,
                IsGlutenFree = model.IsGlutenFree,
                CreatedUtc = DateTimeOffset.Now
            };
            IdentityResult result = await UserManager.CreateAsync(entity, model.Password);

            return result.Succeeded;
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Users.Select(
                       e => new UserListItem
                       {
                           UserName = e.UserName,
                           FullName = e.FullName,
                           SubscriberStatus = e.SubscriberStatus,
                           CreatedUtc = e.CreatedUtc
                       });
                return query.ToArray();
            }
        }
        public UserDetail GetUserById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.Id == id);
                return
                    new UserDetail
                    {
                        UserId = entity.Id,
                        FullName = entity.FullName,
                        CreatedUtc = entity.CreatedUtc,
                        Height = entity.Height,
                        Weight = entity.Weight,
                        GoalDate = entity.GoalDate,
                        GoalWeight = entity.GoalWeight,
                        SubscriberStatus = entity.SubscriberStatus,
                        WeeklyCaloricNeed = entity.WeeklyCaloricNeed,
                        BodyType = entity.BodyType,
                        LifeStyleType = entity.LifeStyleType,
                        IsVegetarian = entity.IsVegetarian,
                        IsKeto = entity.IsKeto,
                        IsLactoseFree = entity.IsLactoseFree,
                        IsGlutenFree = entity.IsGlutenFree,
                        DietId = entity.DietId
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            if (model.UserId != _userId)
            {
                return false;
            }
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Users.Single(e => e.Id == model.UserId);
                entity.FullName = model.FullName;
                entity.Height = model.Height;
                entity.Weight = model.Weight;
                entity.GoalWeight = model.GoalWeight;
                entity.GoalDate = model.GoalDate;
                entity.SubscriberStatus = model.SubscriberStatus;
                entity.WeeklyCaloricNeed = model.WeeklyCaloricNeed;
                entity.BodyType = model.BodyType;
                entity.LifeStyleType = model.LifeStyleType;
                entity.IsVegetarian = model.IsVegetarian;
                entity.IsKeto = model.IsKeto;
                entity.IsLactoseFree = model.IsLactoseFree;
                entity.IsGlutenFree = model.IsGlutenFree;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() >= 1;

            }
        }
        public bool UpdateUserAdmin(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Users.Single(e => e.Id == model.UserId);
                entity.FullName = model.FullName;
                entity.Height = model.Height;
                entity.Weight = model.Weight;
                entity.GoalWeight = model.GoalWeight;
                entity.GoalDate = model.GoalDate;
                entity.SubscriberStatus = model.SubscriberStatus;
                entity.WeeklyCaloricNeed = model.WeeklyCaloricNeed;
                entity.BodyType = model.BodyType;
                entity.LifeStyleType = model.LifeStyleType;
                entity.IsVegetarian = model.IsVegetarian;
                entity.IsKeto = model.IsKeto;
                entity.IsLactoseFree = model.IsLactoseFree;
                entity.IsGlutenFree = model.IsGlutenFree;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() >= 1;

            }
        }
        public bool DeleteUser(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.Id == userId);
                ctx.Users.Remove(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

    }
}
