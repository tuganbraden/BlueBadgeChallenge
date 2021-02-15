using BlueBadgeProject.Data;
using BlueBadgeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Services
{
    public class ClientService
    {
        private readonly string _userId;
        public ClientService(string userId)
        {
            _userId = userId;
        }
        public bool CreateClient(ClientCreate model)
        {
            var entity = new Client()
            {
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
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }
        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Clients.Select(
                       e => new ClientListItem
                       {
                           ClientId = e.ClientId,
                           FullName = e.FullName,
                           SubscriberStatus = e.SubscriberStatus,
                           CreatedUtc = e.CreatedUtc
                       });
                return query.ToArray();
            }
        }
        public ClientDetail GetClientById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clients.Single(e => e.ClientId == id);
                return
                    new ClientDetail
                    {
                        ClientId = entity.ClientId,
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
        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Clients.Single(e => e.ClientId == model.ClientId);
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
        public bool DeleteClient(string clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clients.Single(e => e.ClientId == clientId);
                ctx.Clients.Remove(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

    }
}
