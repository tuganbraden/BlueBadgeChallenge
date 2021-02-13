using BlueBadgeProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Services
{
    public class DietService
    {
        private readonly Guid _dietId;
            public DietService(Guid dietId)
            {
             _dietId = dietId;
            }

        public bool CreateDiet(DietCreate model)
        {
            var entity =
                new Diet()
                {
                    //OwnerId = _userId,
                    //Title = model.Title,
                    //Content = model.Content,
                    //CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Diets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
