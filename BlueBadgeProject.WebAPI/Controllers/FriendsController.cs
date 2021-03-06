using BlueBadgeProject.Data;
using BlueBadgeProject.Models;
using BlueBadgeProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace BlueBadgeProject.WebAPI.Controllers
{
    [RoutePrefix("api/Friends")]
    public class FriendsController: ApiController
    {       
        FriendsService friendsService = new FriendsService();
        [HttpPost]
        public IHttpActionResult AddYourFriends([FromBody] FriendsCreate model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty. ");
            }
            if (ModelState.IsValid)
            {

                var friendsAdded = friendsService.AddFriends(model);
                if (friendsAdded == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public IHttpActionResult GetFriendsList([FromBody] string Id)
        {
            return (IHttpActionResult)friendsService.GetListOfFriends(Id);

        }
        [HttpDelete]
        public IHttpActionResult FriendsDelete(FriendsDetail model)
        {
            if (model is null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var friendIsDeleted = friendsService.DeleteFriend(model);
                if (friendIsDeleted == true)
                    return Ok();
                else
                    return BadRequest();
            }

            return BadRequest(ModelState);
        }
        [HttpGet]
        public IHttpActionResult ViewFriendsDiets(string friendId)
        {
          
                if (friendId is null)
                {
                    return BadRequest("Please enter a valid Friend Id. ");
                }
                if (ModelState.IsValid)
                {
                DietDetail friendsDiet = friendsService.ViewFriendsDietPlan(friendId);
                  
                return Ok(friendsDiet.Name);
                }

            return BadRequest();
        }

    }

}