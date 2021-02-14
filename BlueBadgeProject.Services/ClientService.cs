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
        public ClientDetail GetClientById(int id)
        {

        }
    }
}
