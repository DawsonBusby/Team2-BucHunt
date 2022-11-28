using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ETSUBucHunt.WebApp.Models;
using ETSUBucHunt.Webapp.Views;


//  Mostly used https://www.tutorialsteacher.com/webapi/implement-post-method-in-web-api
//  and https://www.c-sharpcorner.com/article/post-method-in-asp-net-web-api/
//  and https://learn.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/action-results
//  to help with coding this out.


/* GOAL */
//POST API Method to create player accounts. Required parameter (Email address, phone number)

/* Needed to be functional*/
//      UserViewModel, BucHunt Database, Main Controller API.


/* TO DO */
// Go back and rename things to fit assigned names of other classes, etc
// HTTP response method needs the main controller API


namespace ETSUBucHunt.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }
        //For username I thought to just let it choose random number and let the users change it later
        //hence the Random number generator.
        public Random rnd = new Random();

        //This is the action method from the user clicking submit or some kinda accept button webpage to send data,
        //however it requires that there is actually a UserViewModel (User creation page) to pull the data from.
        [HttpPost]
        public HttpResponseMessage PostNewPlayer ([FromBody]User user)
        {
            try
            {
                //This wont work because it  requires that there is a database to use and methods to handle database, 
                // but once its there it should work. May have to rename things to make it work. 
                using (var newPlayer = new BucHuntDBEntity())
                {

                    // This pulls the email and phone number from UserViewModel and puts it in the required places
                    // for database entries. Requires CRUD setup for the database.
                    newPlayer.Players.Add(new User()
                    {
                        //Again Since the only requirements from new users is email and phonenumber,
                        // for the username I had it be random number, the player can change it later.
                        UserName = rnd.Next(10).ToString(),
                        UserEmailAddress = user.EmailAddress,
                        UserPhoneNumber = user.PhoneNumber
                    });
                    //Saves database changes
                    newPlayer.SaveChanges();

                    //Tells the web user that the process was a success
                    return new HttpResponseMessage() { StatusCode=HttpStatusCode.Ok, Message="Success"};
                }
            }

            //Tells the user the process was a failure, and shows the exception error.
            catch (Exception ex)
            {
                return new HttpResponseMessage() { HttpStatusCode.BadRequest, Message = ex};
            }
           
        }

    }
}
