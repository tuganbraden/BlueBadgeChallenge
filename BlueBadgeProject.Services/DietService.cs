using BlueBadgeProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlueBadgeProject.Models.DietModels;


public class DietService
{


    public bool CreateDiet(Diet model)
    {
        var entity =
            new Diets()
            {
                Name = model.Name,
                IsVegetarian = model.IsVegetarian,
                IsKeto = model.IsKeto,
                IsLactoseFree = model.IsLactoseFree,
                IsGlutenFree = model.IsGlutenFree,
                Description = model.Description,
                CaloriesPerDay = model.CaloriesPerDay
            };
        using (var ctx = new ApplicationDbContext())
        {
            ctx.Diets.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }

    public List<Diets> GetAllDiets()
    {
        using (var ctx = new ApplicationDbContext())
        {
            //TODO: Will this .Select return one or a list?
            var query =
                ctx
                .Diets
                .Select(e =>
                    new Diets
                    {
                        Name = e.Name,
                        IsVegetarian = e.IsVegetarian,
                        IsKeto = e.IsKeto,
                        IsLactoseFree = e.IsLactoseFree,
                        IsGlutenFree = e.IsGlutenFree,
                        Description = e.Description,
                        CaloriesPerDay = e.CaloriesPerDay
                    }
                    );
            return query.ToList();
        }
    }

    public Diet GetDietByClientId(string ClientId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var myclient =
                ctx
                .Clients
                .Single(e => e.ClientId == ClientId);

            var DietId = myclient.DietId;

            var Entity =
                ctx
                .Diets
                .Single(e => e.DietId == DietId);

            return
                new Diet
                {
                    DietId = Entity.DietId,
                    Name = Entity.Name,
                    IsVegetarian = Entity.IsVegetarian,
                    IsKeto = Entity.IsKeto,
                    IsLactoseFree = Entity.IsLactoseFree,
                    IsGlutenFree = Entity.IsGlutenFree,
                    Description = Entity.Description,
                    CaloriesPerDay = Entity.CaloriesPerDay

                };
        }
    }

    public List<Diets> GetDietByClientsNeeds(Diet needs)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx
                .Diets
                .Where(
                    e => e.IsVegetarian == needs.IsVegetarian &&
                            e.IsKeto == needs.IsKeto &&
                            e.IsLactoseFree == needs.IsLactoseFree &&
                            e.IsGlutenFree == needs.IsGlutenFree
                    )
                .Select(e =>
                    new Diets
                    {
                        Name = e.Name,
                        IsVegetarian = e.IsVegetarian,
                        IsKeto = e.IsKeto,
                        IsLactoseFree = e.IsLactoseFree,
                        IsGlutenFree = e.IsGlutenFree,
                        Description = e.Description,
                        CaloriesPerDay = e.CaloriesPerDay
                    }
                    );
            return query.ToList();

        }
    }

    public bool EditADiet(Diet model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Diets
                .Single(e => e.DietId == model.DietId);
            entity.DietId = model.DietId;
            entity.Name = model.Name;
            entity.IsVegetarian = model.IsVegetarian;
            entity.IsKeto = model.IsKeto;
            entity.IsLactoseFree = model.IsLactoseFree;
            entity.IsGlutenFree = model.IsGlutenFree;
            entity.Description = model.Description;
            entity.CaloriesPerDay = model.CaloriesPerDay;


            return ctx.SaveChanges() == 1;

        }
    }

    public bool DeleteDiet(int Id)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Diets
                .Single(e => e.DietId == Id);
            ctx.Diets.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }

}