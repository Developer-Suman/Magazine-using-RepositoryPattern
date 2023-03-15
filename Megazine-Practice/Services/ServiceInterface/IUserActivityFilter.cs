using Megazine_Practice.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Megazine_Practice.Services.ServiceInterface
{
    public interface IUserActivityFilter
    {
        List<UserActivity> GetAll();
        UserActivity GetById(int id);
        void OnActionExecuted(ActionExecutedContext context);
        void OnActionExecuting(ActionExecutingContext context);
        void StoreUserActivity(string data, string url, string userName, string ipAddress);
    }
}