using BlueBadgeProject.Data;
using BlueBadgeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Services
{
    public class FriendsService
    {
        //Add Friend
        public bool AddFriends(FriendsCreate model)

        {
            var entity =
                new Friends()
                {
                    FriendUserId = model.FriendUserId,
                    MyUserId = model.MyUserId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Friends.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        //TODO - go through a 2nd lambda to add the friendd name to the list here
        public List<FriendsListItem> GetListOfFriends(string Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Friends
                    .Where(e => Id == e.MyUserId)
                    .Select(e =>
                        new FriendsListItem
                        {
                            MyUserId = e.MyUserId,
                            FriendUserId = e.FriendUserId
                        }
                        );
                return query.ToList();
            }
        }
         //Delete Friend
        public bool DeleteFriend(FriendsDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Friends
                    .Single(e => e.FriendUserId == model.FriendUserId && e.MyUserId == model.MyUserId);
                ctx.Friends.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        //View WorkoutPlan by Friend I
    }
}

