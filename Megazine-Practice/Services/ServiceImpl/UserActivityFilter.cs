using Megazine_Practice.Data;
using Megazine_Practice.Models;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Megazine_Practice.Services.ServiceImpl
{
    public class UserActivityFilter : IActionFilter, IUserActivityFilter
    {
        private AppDbContext context;

        public UserActivityFilter(AppDbContext _context)
        {
            context = _context;
        }



        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var data = "";
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            //Url the user has visited
            var url = $"{controllerName}/{actionName}";

            if (!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {
                //User sent data through Url
                data = context.HttpContext.Request.QueryString.Value;
            }
            else
            {
                //User sent data through form
                var userData = context.ActionArguments.FirstOrDefault();
                var stringUserData = JsonConvert.SerializeObject(userData);

                data = stringUserData;
            }

            //Track Username
            //If uer are logged than you get the name otherwise you get null
            var userName = context.HttpContext.User.Identity.Name;

            //Track Ip address
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();

            StoreUserActivity(data, url, userName, ipAddress);



        }


        public void StoreUserActivity(string data, string url, string userName, string ipAddress)
        {
            var userActivity = new UserActivity
            {
                Data = data,
                Url = url,
                UserName = userName,
                IpAddress = ipAddress
            };

            context.UserActivities.Add(userActivity);
            context.SaveChanges();

        }

        public List<UserActivity> GetAll()
        {
            return context.UserActivities.ToList();
        }
        public UserActivity GetById(int id)
        {
            var userActivity = context.UserActivities.Find(id);
            return userActivity;
        }


    }
}
