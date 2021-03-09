using BlueBadgeProject.Data;
using BlueBadgeProject.Models;
using BlueBadgeProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DietService
{
    public bool CreateDiet(BlueBadgeProject.Models.DietCreate model)
    {
        var entity =
            new BlueBadgeProject.Data.Diets()
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

    public List<DietDetail> GetAllDiets()
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx
                .Diets
                .Select(e =>
                    new DietDetail
                    {             
                        DietId = e.DietId,
                        Name = e.Name,
                        IsVegetarian = e.IsVegetarian,
                        IsKeto = e.IsKeto,
                        IsLactoseFree = e.IsLactoseFree,
                        IsGlutenFree = e.IsGlutenFree,
                        Description = e.Description,
                        CaloriesPerDay = e.CaloriesPerDay

                    }
                    ) ;
            return query.ToList();
        }
    }

    public DietDetail GetDietByUserId(string UserId)
    {
        var userService = new UserService("3", null);    //TODO: We need to understand these parms so we can fill them correctly
        UserDetail myUser;
        myUser = userService.GetUserById(UserId);
        var DietId = myUser.DietId;
        using (var ctx1 = new ApplicationDbContext())
        {
            var Entity =
               ctx1
               .Diets
               .Single(e => e.DietId == DietId);

            return
                new DietDetail
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

        /*
        using (var ctx = new ApplicationDbContext())
        {
            var myuser =
                ctx
                .Users
                .Single(e => e.UserId == UserId);

            var DietId = myuser.DietId;

            var Entity =
                ctx
                .Diets
                .Single(e => e.DietId == DietId);

            return
                new DietDetail
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
        */
    }


    public List<DietListItem> GetDietByUserNeeds(DietFind needs)
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
                    new DietListItem
                    {   DietId = e.DietId,
                        Name = e.Name,                      
                        Description = e.Description                
                    }
                    );
            return query.ToList();

        }
    }

    public bool EditADiet(DietEdit model)
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